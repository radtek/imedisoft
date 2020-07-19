using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace OpenDentBusiness{
	///<summary></summary>
	public class Transactions {
		#region Get Methods
		#endregion

		#region Modification Methods
		
		#region Insert
		#endregion

		#region Update
		#endregion

		#region Delete
		#endregion

		#endregion

		#region Misc Methods
		#endregion

		///<summary>Since transactions are always viewed individually, this function returns one transaction</summary>
		public static Transaction GetTrans(long transactionNum) {
			
			return Crud.TransactionCrud.SelectOne(transactionNum);
		}

		public static List<Transaction> GetManyTrans(List<long> listTransactionNums) {
			if(listTransactionNums==null || listTransactionNums.Count<=0) {
				return new List<Transaction>();
			}
			
			string command="SELECT * FROM transaction WHERE transaction.TransactionNum IN("+string.Join(",",listTransactionNums)+")";
			return Crud.TransactionCrud.SelectMany(command);
		}

		///<summary>Gets one transaction directly from the database which has this deposit attached to it.  If none exist, then returns null.</summary>
		public static Transaction GetAttachedToDeposit(long depositNum) {
			
			string command=
				"SELECT * FROM transaction "
				+"WHERE DepositNum="+POut.Long(depositNum);
			return Crud.TransactionCrud.SelectOne(command);
		}

		///<summary>Gets one transaction directly from the database which has this payment attached to it.  If none exist, then returns null.  There should never be more than one, so that's why it doesn't return more than one.</summary>
		public static Transaction GetAttachedToPayment(long payNum) {
			
			string command=
				"SELECT * FROM transaction "
				+"WHERE PayNum="+POut.Long(payNum);
			return Crud.TransactionCrud.SelectOne(command);
		}

		///<summary></summary>
		public static long Insert(Transaction trans) {
			trans.SecUserNumEdit=Security.CurUser.Id;//Before middle tier check to catch user at workstation
			
			return Crud.TransactionCrud.Insert(trans);
		}

		///<summary></summary>
		public static void Update(Transaction trans) {
			trans.SecUserNumEdit=Security.CurUser.Id;//Before middle tier check to catch user at workstation
			
			Crud.TransactionCrud.Update(trans);
		}

		///<summary>Also deletes all journal entries for the transaction.  Will later throw an error if journal entries attached to any reconciles.  Be sure to surround with try-catch.</summary>
		public static void Delete(Transaction trans) {
			
			string command="SELECT IsLocked FROM journalentry j, reconcile r WHERE j.TransactionNum="+POut.Long(trans.TransactionNum)
				+" AND j.ReconcileNum = r.ReconcileNum";
			DataTable table=Database.ExecuteDataTable(command);
			if(table.Rows.Count>0) {
				if(PIn.Int(table.Rows[0][0].ToString())==1) {
					throw new ApplicationException(Lans.g("Transactions","Not allowed to delete transactions because it is attached to a reconcile that is locked."));
				}
			}
			command="DELETE FROM journalentry WHERE TransactionNum="+POut.Long(trans.TransactionNum);
			Database.ExecuteNonQuery(command);
			command= "DELETE FROM transaction WHERE TransactionNum="+POut.Long(trans.TransactionNum);
			Database.ExecuteNonQuery(command);
		}

	
	
		///<summary></summary>
		public static bool IsReconciled(Transaction trans){
			
			string command="SELECT COUNT(*) FROM journalentry WHERE ReconcileNum !=0"
				+" AND TransactionNum="+POut.Long(trans.TransactionNum);
			if(Database.ExecuteString(command)=="0") {
				return false;
			}
			return true;
		}



	}

	
}




