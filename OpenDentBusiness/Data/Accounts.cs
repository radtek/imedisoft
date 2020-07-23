using Imedisoft.Data;
using Imedisoft.Data.Cache;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace OpenDentBusiness
{
    public partial class Accounts
	{
		private class AccountCache : ListCache<Account>
		{
			protected override IEnumerable<Account> Load()
				=> SelectMany("SELECT * FROM `accounts` ORDER BY `type`, `description`");
		}

		private static readonly AccountCache cache = new AccountCache();

		public static void RefreshCache() 
			=> cache.Refresh();

		public static List<Account> All 
			=> cache.GetAll();

		public static Account GetFirstOrDefault(Predicate<Account> predicate) 
			=> cache.FirstOrDefault(predicate);

		/// <summary>
		/// Also updates existing journal entry splits linked to this account that have not been locked.
		/// </summary>
		public static void Update2(Account acct, Account acctOld)
		{
			Update(acct, acctOld);

			if (acct.Description == acctOld.Description)
			{
				return; //No need to update splits on attached journal entries.
			}

			// The account was renamed, so update journalentry.Splits.
			string command = @"SELECT je2.*,account.Description
					FROM journalentry 
					INNER JOIN journalentry je2 ON je2.TransactionNum=journalentry.TransactionNum
					INNER JOIN account ON account.AccountNum=je2.AccountNum
					WHERE journalentry.AccountNum=" + acct.Id + @"
					AND journalentry.DateDisplayed > " + POut.Date(PrefC.GetDate(PrefName.AccountingLockDate)) + @"
					ORDER BY je2.TransactionNum";

			DataTable table = Database.ExecuteDataTable(command);
			if (table.Rows.Count == 0)
			{
				return;
			}

			List<JournalEntry> listJournalEntries = Crud.JournalEntryCrud.TableToList(table);
			//Construct a dictionary that has the description for each JournalEntryNum.
			Dictionary<long, string> dictJournalEntryDescriptions = table.Rows.Cast<DataRow>()
				.GroupBy(x => PIn.Long(x["JournalEntryNum"].ToString()))
				.ToDictionary(x => x.Key, x => PIn.String(x.First()["Description"].ToString()));

			// Now we will loop through all the journal entries and find the other journal entries that are attached to the same transaction and update
			// those splits.
			List<int> listIndexesForTrans = new List<int>();
			long curTransactionNum = listJournalEntries[0].TransactionNum;
			for (int i = 0; i < listJournalEntries.Count; i++)
			{
				if (listJournalEntries[i].TransactionNum == curTransactionNum)
				{
					listIndexesForTrans.Add(i);
					continue;
				}
				UpdateJournalEntrySplits(listJournalEntries, listIndexesForTrans, dictJournalEntryDescriptions, acct);
				curTransactionNum = listJournalEntries[i].TransactionNum;
				listIndexesForTrans.Clear();
				listIndexesForTrans.Add(i);
			}

			UpdateJournalEntrySplits(listJournalEntries, listIndexesForTrans, dictJournalEntryDescriptions, acct);
		}

		/// <summary>
		/// Updates the splits on the journal entries whose indexes are passed in.
		/// </summary>
		/// <param name="journalEntries">All journal entries for a particular account.</param>
		/// <param name="listIndexesForTrans">The index of the journal entries in listJournalEntries. These are the ones that will be updated.</param>
		/// <param name="journalEntryDescriptions">A dictionary where the key is the JournalEntryNum and the value is the journal entry's account description.</param>
		/// <param name="acct">The account that whose description is being updates.</param>
		private static void UpdateJournalEntrySplits(List<JournalEntry> journalEntries, List<int> listIndexesForTrans,
			Dictionary<long, string> journalEntryDescriptions, Account acct)
		{
			foreach (int index in listIndexesForTrans.Where(x => journalEntries[x].AccountNum != acct.Id))
			{
				JournalEntry journalEntry = journalEntries[index];
				if (listIndexesForTrans.Count <= 2)
				{
					//When a transaction only has two splits, the Splits column will simply be the name of the account of the other split.
					journalEntry.Splits = acct.Description;
				}
				else
				{
					//When a transaction has three or more splits, the Splits column will be the names of the account and the amount of the other splits.
					//Ex.: 
					//Patient Fee Income 85.00
					//Supplies 110.00
					journalEntry.Splits = string.Join("\r\n", listIndexesForTrans
						.Where(x => journalEntries[x].JournalEntryNum != journalEntry.JournalEntryNum)
						.Select(x => journalEntryDescriptions[journalEntries[x].JournalEntryNum] + " " +
						(journalEntries[x].DebitAmt > 0 ?
							journalEntries[x].DebitAmt.ToString("n") :
							journalEntries[x].CreditAmt.ToString("n"))));
				}
				JournalEntries.Update(journalEntry);
			}
		}

		/// <summary>
		/// Loops through listLong to find a description for the specified account. 0 returns an empty string.
		/// </summary>
		public static string GetDescript(long accountNum)
		{
			Account account = GetFirstOrDefault(x => x.Id == accountNum);
			return (account == null ? "" : account.Description);
		}

		/// <summary>
		/// Loops through listLong to find an account.  Will return null if accountNum is 0.
		/// </summary>
		public static Account GetAccount(long accountNum)
		{
			//No need to check RemotingRole; no call to db.
			return GetFirstOrDefault(x => x.Id == accountNum);
		}

		/// <summary>Throws exception if account is in use.</summary>
		public static void Delete2(Account account)
		{
			// TODO: Fix me...

			// Check to see if account has any journal entries
			if (Database.ExecuteLong("SELECT COUNT(*) FROM journalentry WHERE AccountNum=" + account.Id) != 0)
			{
				throw new ApplicationException(
					"Not allowed to delete an account with existing journal entries.");
			}

			// TODO: Use Prefs class to access preferences...

			var result = Database.ExecuteString("SELECT ValueString FROM preference WHERE PrefName='AccountingDepositAccounts'");
			string[] strArray = result.Split(new char[] { ',' });
			for (int i = 0; i < strArray.Length; i++)
			{
				if (strArray[i] == account.Id.ToString())
				{
					throw new ApplicationException("Account is in use in the setup section.");
				}
			}

			result = Database.ExecuteString("SELECT ValueString FROM preference WHERE PrefName='AccountingIncomeAccount'");
			if (result == account.Id.ToString())
			{
				throw new ApplicationException("Account is in use in the setup section.");
			}

			result = Database.ExecuteString("SELECT ValueString FROM preference WHERE PrefName='AccountingCashIncomeAccount'");
			if (result == account.Id.ToString())
			{
				throw new ApplicationException("Account is in use in the setup section.");
			}

			var autoPays = AccountingAutoPays.GetDeepCopy();
			for (int i = 0; i < autoPays.Count; i++)
			{
				strArray = autoPays[i].PickList.Split(new char[] { ',' });
				for (int s = 0; s < strArray.Length; s++)
				{
					if (strArray[s] == account.Id.ToString())
					{
						throw new ApplicationException("Account is in use in the setup section.");
					}
				}
			}

			Database.ExecuteNonQuery("DELETE FROM account WHERE AccountNum = " + account.Id);
		}

		/// <summary>
		/// Used to test the sign on debits and credits for the five different account types
		/// </summary>
		public static bool DebitIsPos(AccountType type)
		{
			switch (type)
			{
				case AccountType.Asset:
				case AccountType.Expense:
					return true;

				case AccountType.Liability:
				case AccountType.Equity: // Because liabilities and equity are treated the same.
				case AccountType.Income:
					return false;
			}

			return true;
		}

		/// <summary>
		/// Gets the balance of an account directly from the database.
		/// </summary>
		public static double GetBalance(long accountId, AccountType accountType)
		{
			string command = "SELECT SUM(DebitAmt), SUM(CreditAmt) FROM journalentry WHERE AccountNum=" + accountId + " GROUP BY AccountNum";
			DataTable table = Database.ExecuteDataTable(command);
			
			double debit = 0;
			double credit = 0;
			if (table.Rows.Count > 0)
			{
				debit = PIn.Double(table.Rows[0][0].ToString());
				credit = PIn.Double(table.Rows[0][1].ToString());
			}

			return DebitIsPos(accountType) ? 
				debit - credit : 
				credit - debit;
		}

		/// <summary>
		/// Checks the loaded prefs to see if user has setup deposit linking.  Returns true if so.
		/// </summary>
		public static bool DepositsLinked()
		{
			if (PrefC.GetInt(PrefName.AccountingSoftware) == (int)AccountingSoftware.QuickBooks)
			{
				if (PrefC.GetString(PrefName.QuickBooksDepositAccounts) == "")
				{
					return false;
				}
				if (PrefC.GetString(PrefName.QuickBooksIncomeAccount) == "")
				{
					return false;
				}
			}
			else
			{
				if (PrefC.GetString(PrefName.AccountingDepositAccounts) == "")
				{
					return false;
				}
				if (PrefC.GetLong(PrefName.AccountingIncomeAccount) == 0)
				{
					return false;
				}
			}

			return true;
		}

		///<summary>Checks the loaded prefs and accountingAutoPays to see if user has setup auto pay linking.  Returns true if so.</summary>
		public static bool PaymentsLinked()
		{
			//No need to check RemotingRole; no call to db.
			if (AccountingAutoPays.GetCount() == 0)
			{
				return false;
			}
			if (PrefC.GetLong(PrefName.AccountingCashIncomeAccount) == 0)
			{
				return false;
			}
			//might add a few more checks later.
			return true;
		}

		///<summary></summary>
		public static long[] GetDepositAccounts()
		{
			//No need to check RemotingRole; no call to db.
			string depStr = PrefC.GetString(PrefName.AccountingDepositAccounts);
			string[] depStrArray = depStr.Split(new char[] { ',' });
			ArrayList depAL = new ArrayList();
			for (int i = 0; i < depStrArray.Length; i++)
			{
				if (depStrArray[i] == "")
				{
					continue;
				}
				depAL.Add(PIn.Long(depStrArray[i]));
			}
			long[] retVal = new long[depAL.Count];
			depAL.CopyTo(retVal);
			return retVal;
		}

		///<summary></summary>
		public static List<string> GetDepositAccountsQB()
		{
			//No need to check RemotingRole; no call to db.
			string depStr = PrefC.GetString(PrefName.QuickBooksDepositAccounts);
			string[] depStrArray = depStr.Split(new char[] { ',' });
			List<string> retVal = new List<string>();
			for (int i = 0; i < depStrArray.Length; i++)
			{
				if (depStrArray[i] == "")
				{
					continue;
				}
				retVal.Add(depStrArray[i]);
			}
			return retVal;
		}

		///<summary></summary>
		public static List<string> GetIncomeAccountsQB()
		{
			//No need to check RemotingRole; no call to db.
			string incomeStr = PrefC.GetString(PrefName.QuickBooksIncomeAccount);
			string[] incomeStrArray = incomeStr.Split(new char[] { ',' });
			List<string> retVal = new List<string>();
			for (int i = 0; i < incomeStrArray.Length; i++)
			{
				if (incomeStrArray[i] == "")
				{
					continue;
				}
				retVal.Add(incomeStrArray[i]);
			}
			return retVal;
		}

		/// <summary>
		/// Gets the full list to display in the Chart of Accounts, including balances.
		/// </summary>
		public static DataTable GetFullList(DateTime asOfDate, bool showInactive)
		{
			DataTable table = new DataTable("Accounts");
			DataRow row;
			//columns that start with lowercase are altered for display rather than being raw data.
			table.Columns.Add("type");
			table.Columns.Add("Description");
			table.Columns.Add("balance");
			table.Columns.Add("BankNumber");
			table.Columns.Add("inactive");
			table.Columns.Add("color");
			table.Columns.Add("AccountNum");
			//but we won't actually fill this table with rows until the very end.  It's more useful to use a List<> for now.
			List<DataRow> rows = new List<DataRow>();
			//first, the entire history for the asset, liability, and equity accounts (except Retained Earnings)-----------
			string command = "SELECT account.AcctType, account.Description, account.AccountNum, "
				+ "SUM(DebitAmt) AS SumDebit, SUM(CreditAmt) AS SumCredit, account.BankNumber, account.Inactive, account.AccountColor "
				+ "FROM account "
				+ "LEFT JOIN journalentry ON journalentry.AccountNum=account.AccountNum AND "
				+ "DateDisplayed <= " + POut.Date(asOfDate) + " WHERE AcctType<=2 ";
			if (!showInactive)
			{
				command += "AND Inactive=0 ";
			}
			command += "GROUP BY account.AccountNum, account.AcctType, account.Description, account.BankNumber,"
				+ "account.Inactive, account.AccountColor ORDER BY AcctType, Description";
			DataTable rawTable = Database.ExecuteDataTable(command);
			AccountType aType;
			decimal debit = 0;
			decimal credit = 0;
			for (int i = 0; i < rawTable.Rows.Count; i++)
			{
				row = table.NewRow();
				aType = (AccountType)PIn.Long(rawTable.Rows[i]["AcctType"].ToString());
				row["type"] = Lans.g("enumAccountType", aType.ToString());
				row["Description"] = rawTable.Rows[i]["Description"].ToString();
				debit = PIn.Decimal(rawTable.Rows[i]["SumDebit"].ToString());
				credit = PIn.Decimal(rawTable.Rows[i]["SumCredit"].ToString());
				if (DebitIsPos(aType))
				{
					row["balance"] = (debit - credit).ToString("N");
				}
				else
				{
					row["balance"] = (credit - debit).ToString("N");
				}
				row["BankNumber"] = rawTable.Rows[i]["BankNumber"].ToString();
				if (rawTable.Rows[i]["Inactive"].ToString() == "0")
				{
					row["inactive"] = "";
				}
				else
				{
					row["inactive"] = "X";
				}
				row["color"] = rawTable.Rows[i]["AccountColor"].ToString();//it will be an unsigned int at this point.
				row["AccountNum"] = rawTable.Rows[i]["AccountNum"].ToString();
				rows.Add(row);
			}
			//now, the Retained Earnings (auto) account-----------------------------------------------------------------
			DateTime firstofYear = new DateTime(asOfDate.Year, 1, 1);
			command = "SELECT AcctType, SUM(DebitAmt) AS SumDebit, SUM(CreditAmt) AS SumCredit "
				+ "FROM account,journalentry "
				+ "WHERE journalentry.AccountNum=account.AccountNum "
				+ "AND DateDisplayed < " + POut.Date(firstofYear)//all from previous years
				+ " AND (AcctType=3 OR AcctType=4) "//income or expenses
				+ "GROUP BY AcctType ORDER BY AcctType";//income first, but could return zero rows.
			rawTable = Database.ExecuteDataTable(command);
			decimal balance = 0;
			for (int i = 0; i < rawTable.Rows.Count; i++)
			{
				aType = (AccountType)PIn.Long(rawTable.Rows[i]["AcctType"].ToString());
				debit = PIn.Decimal(rawTable.Rows[i]["SumDebit"].ToString());
				credit = PIn.Decimal(rawTable.Rows[i]["SumCredit"].ToString());
				//this works for both income and expenses, because we are subracting expenses, so signs cancel
				balance += credit - debit;
			}
			row = table.NewRow();
			row["type"] = Lans.g("enumAccountType", AccountType.Equity.ToString());
			row["Description"] = Lans.g("Accounts", "Retained Earnings (auto)");
			row["balance"] = balance.ToString("N");
			row["BankNumber"] = "";
			row["color"] = Color.White.ToArgb();
			row["AccountNum"] = "0";
			rows.Add(row);
			//finally, income and expenses------------------------------------------------------------------------------
			command = "SELECT account.AcctType, account.Description, account.AccountNum, "
				+ "SUM(DebitAmt) AS SumDebit, SUM(CreditAmt) AS SumCredit, account.BankNumber, account.Inactive, account.AccountColor "
				+ "FROM account "
				+ "LEFT JOIN journalentry ON journalentry.AccountNum=account.AccountNum "
				+ "AND DateDisplayed <= " + POut.Date(asOfDate)
				+ " AND DateDisplayed >= " + POut.Date(firstofYear)//only for this year
				+ " WHERE (AcctType=3 OR AcctType=4) ";
			if (!showInactive)
			{
				command += "AND Inactive=0 ";
			}
			command += "GROUP BY account.AccountNum, account.AcctType, account.Description, account.BankNumber,"
				+ "account.Inactive, account.AccountColor ORDER BY AcctType, Description";
			rawTable = Database.ExecuteDataTable(command);
			for (int i = 0; i < rawTable.Rows.Count; i++)
			{
				row = table.NewRow();
				aType = (AccountType)PIn.Long(rawTable.Rows[i]["AcctType"].ToString());
				row["type"] = Lans.g("enumAccountType", aType.ToString());
				row["Description"] = rawTable.Rows[i]["Description"].ToString();
				debit = PIn.Decimal(rawTable.Rows[i]["SumDebit"].ToString());
				credit = PIn.Decimal(rawTable.Rows[i]["SumCredit"].ToString());
				if (DebitIsPos(aType))
				{
					row["balance"] = (debit - credit).ToString("N");
				}
				else
				{
					row["balance"] = (credit - debit).ToString("N");
				}
				row["BankNumber"] = rawTable.Rows[i]["BankNumber"].ToString();
				if (rawTable.Rows[i]["Inactive"].ToString() == "0")
				{
					row["inactive"] = "";
				}
				else
				{
					row["inactive"] = "X";
				}
				row["color"] = rawTable.Rows[i]["AccountColor"].ToString();//it will be an unsigned int at this point.
				row["AccountNum"] = rawTable.Rows[i]["AccountNum"].ToString();
				rows.Add(row);
			}
			for (int i = 0; i < rows.Count; i++)
			{
				table.Rows.Add(rows[i]);
			}
			return table;
		}

		/// <summary>
		/// Gets the full GeneralLedger list.
		/// </summary>
		public static DataTable GetGeneralLedger(DateTime dateStart, DateTime dateEnd)
		{
			string queryString = @"SELECT DATE(" + POut.Date(new DateTime(dateStart.Year - 1, 12, 31)) + @") DateDisplayed,
				'' Memo,
				'' Splits,
				'' CheckNumber,
				startingbals.SumTotal DebitAmt,
				0 CreditAmt,
				'' Balance,
				startingbals.Description,
				startingbals.AcctType,
				startingbals.AccountNum
				FROM (
					SELECT account.AccountNum,
					account.Description,
					account.AcctType,
					ROUND(SUM(journalentry.DebitAmt-journalentry.CreditAmt),2) SumTotal
					FROM account
					INNER JOIN journalentry ON journalentry.AccountNum=account.AccountNum
					AND journalentry.DateDisplayed < " + POut.Date(dateStart) + @" 
					AND account.AcctType IN (0,1,2)/*assets,liablities,equity*/
					GROUP BY account.AccountNum
				) startingbals

				UNION ALL
	
				SELECT journalentry.DateDisplayed,
				journalentry.Memo,
				journalentry.Splits,
				journalentry.CheckNumber,
				journalentry.DebitAmt, 
				journalentry.CreditAmt,
				'' Balance,
				account.Description,
				account.AcctType,
				account.AccountNum 
				FROM account
				LEFT JOIN journalentry ON account.AccountNum=journalentry.AccountNum 
					AND journalentry.DateDisplayed >= " + POut.Date(dateStart) + @" 
					AND journalentry.DateDisplayed <= " + POut.Date(dateEnd) + @" 
				WHERE account.AcctType IN(0,1,2)
				
				UNION ALL 
				
				SELECT journalentry.DateDisplayed, 
				journalentry.Memo, 
				journalentry.Splits, 
				journalentry.CheckNumber,
				journalentry.DebitAmt, 
				journalentry.CreditAmt, 
				'' Balance,
				account.Description, 
				account.AcctType,
				account.AccountNum 
				FROM account 
				LEFT JOIN journalentry ON account.AccountNum=journalentry.AccountNum 
					AND journalentry.DateDisplayed >= " + POut.Date(dateStart) + @"  
					AND journalentry.DateDisplayed <= " + POut.Date(dateEnd) + @"  
				WHERE account.AcctType IN(3,4)
				
				ORDER BY AcctType, Description, DateDisplayed;";
			return Database.ExecuteDataTable(queryString);
		}

		/// <summary>
		/// Gets the full list to display in the Chart of Accounts, including balances.
		/// </summary>
		public static DataTable GetAssetTable(DateTime asOfDate) 
			=> GetAccountTotalByType(asOfDate, AccountType.Asset);

		/// <summary>
		/// Gets the full list to display in the Chart of Accounts, including balances.
		/// </summary>
		public static DataTable GetLiabilityTable(DateTime asOfDate) 
			=> GetAccountTotalByType(asOfDate, AccountType.Liability);

		/// <summary>
		/// Gets the full list to display in the Chart of Accounts, including balances.
		/// </summary>
		public static DataTable GetEquityTable(DateTime asOfDate) 
			=> GetAccountTotalByType(asOfDate, AccountType.Equity);

		public static DataTable GetAccountTotalByType(DateTime asOfDate, AccountType acctType)
		{
            string sumTotalStr;
            if (acctType == AccountType.Asset)
			{
				sumTotalStr = "SUM(ROUND(DebitAmt,3)-ROUND(CreditAmt,3))";
			}
			else
			{//Liability or equity
				sumTotalStr = "SUM(ROUND(CreditAmt,3)-ROUND(DebitAmt,3))";
			}

			string command = "SELECT Description, " + sumTotalStr + " SumTotal, AcctType "
				+ "FROM account, journalentry "
				+ "WHERE account.AccountNum=journalentry.AccountNum AND DateDisplayed <= " + POut.Date(asOfDate) + " AND AcctType=" + POut.Int((int)acctType) + " "
				+ "GROUP BY account.AccountNum "
				+ "ORDER BY Description, DateDisplayed ";

			return Database.ExecuteDataTable(command);
		}

		public static DataTable GetAccountTotalByType(DateTime dateStart, DateTime dateEnd, AccountType acctType)
		{
			string sumTotalStr = "";
			if (acctType == AccountType.Expense)
			{
				sumTotalStr = "SUM(ROUND(DebitAmt,3)-ROUND(CreditAmt,3))";
			}
			else
			{//Income instead of expense
				sumTotalStr = "SUM(ROUND(CreditAmt,3)-ROUND(DebitAmt,3))";
			}
			string command = "SELECT Description, " + sumTotalStr + " SumTotal, AcctType "
				+ "FROM account, journalentry "
				+ "WHERE account.AccountNum=journalentry.AccountNum AND DateDisplayed >= " + POut.Date(dateStart) + " "
				+ "AND DateDisplayed <= " + POut.Date(dateEnd) + " "
				+ "AND AcctType=" + POut.Int((int)acctType) + " "
				+ "GROUP BY account.AccountNum "
				+ "ORDER BY Description, DateDisplayed ";
			return Database.ExecuteDataTable(command);
		}

		///<Summary>Gets sum of all income-expenses for all previous years. asOfDate could be any date</Summary>
		public static double RetainedEarningsAuto(DateTime asOfDate)
		{
			DateTime firstOfYear = new DateTime(asOfDate.Year, 1, 1);
			string command = "SELECT SUM(ROUND(CreditAmt,3)), SUM(ROUND(DebitAmt,3)), AcctType "
			+ "FROM journalentry,account "
			+ "WHERE journalentry.AccountNum=account.AccountNum "
			+ "AND DateDisplayed < " + POut.Date(firstOfYear)
			+ " GROUP BY AcctType";
			DataTable table = Database.ExecuteDataTable(command);
			double retVal = 0;
			for (int i = 0; i < table.Rows.Count; i++)
			{
				if (table.Rows[i][2].ToString() == "3"//income
					|| table.Rows[i][2].ToString() == "4")//expense
				{
					retVal += PIn.Double(table.Rows[i][0].ToString());//add credit
					retVal -= PIn.Double(table.Rows[i][1].ToString());//subtract debit
																	  //if it's an expense, we are subtracting (income-expense), but the signs cancel.
				}
			}
			return retVal;
		}

		///<Summary>asOfDate is typically 12/31/...  </Summary>
		public static double NetIncomeThisYear(DateTime asOfDate)
		{
			DateTime firstOfYear = new DateTime(asOfDate.Year, 1, 1);
			string command = "SELECT SUM(ROUND(CreditAmt,3)), SUM(ROUND(DebitAmt,3)), AcctType "
			+ "FROM journalentry,account "
			+ "WHERE journalentry.AccountNum=account.AccountNum "
			+ "AND DateDisplayed >= " + POut.Date(firstOfYear)
			+ " AND DateDisplayed <= " + POut.Date(asOfDate)
			+ " GROUP BY AcctType";
			DataTable table = Database.ExecuteDataTable(command);
			double retVal = 0;
			for (int i = 0; i < table.Rows.Count; i++)
			{
				if (table.Rows[i][2].ToString() == "3"//income
					|| table.Rows[i][2].ToString() == "4")//expense
				{
					retVal += PIn.Double(table.Rows[i][0].ToString());//add credit
					retVal -= PIn.Double(table.Rows[i][1].ToString());//subtract debit
																	  //if it's an expense, we are subtracting (income-expense), but the signs cancel.
				}
			}
			return retVal;
		}
	}
}