//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace OpenDentBusiness.Crud{
	public class AdjustmentCrud {
		///<summary>Gets one Adjustment object from the database using the primary key.  Returns null if not found.</summary>
		public static Adjustment SelectOne(long adjNum) {
			string command="SELECT * FROM adjustment "
				+"WHERE AdjNum = "+POut.Long(adjNum);
			List<Adjustment> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Adjustment object from the database using a query.</summary>
		public static Adjustment SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Adjustment> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Adjustment objects from the database using a query.</summary>
		public static List<Adjustment> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Adjustment> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Adjustment> TableToList(DataTable table) {
			List<Adjustment> retVal=new List<Adjustment>();
			Adjustment adjustment;
			foreach(DataRow row in table.Rows) {
				adjustment=new Adjustment();
				adjustment.AdjNum         = PIn.Long  (row["AdjNum"].ToString());
				adjustment.AdjDate        = PIn.Date  (row["AdjDate"].ToString());
				adjustment.AdjAmt         = PIn.Double(row["AdjAmt"].ToString());
				adjustment.PatNum         = PIn.Long  (row["PatNum"].ToString());
				adjustment.AdjType        = PIn.Long  (row["AdjType"].ToString());
				adjustment.ProvNum        = PIn.Long  (row["ProvNum"].ToString());
				adjustment.AdjNote        = PIn.String(row["AdjNote"].ToString());
				adjustment.ProcDate       = PIn.Date  (row["ProcDate"].ToString());
				adjustment.ProcNum        = PIn.Long  (row["ProcNum"].ToString());
				adjustment.DateEntry      = PIn.Date  (row["DateEntry"].ToString());
				adjustment.ClinicNum      = PIn.Long  (row["ClinicNum"].ToString());
				adjustment.StatementNum   = PIn.Long  (row["StatementNum"].ToString());
				adjustment.SecUserNumEntry= PIn.Long  (row["SecUserNumEntry"].ToString());
				adjustment.SecDateTEdit   = PIn.DateT (row["SecDateTEdit"].ToString());
				retVal.Add(adjustment);
			}
			return retVal;
		}

		///<summary>Converts a list of Adjustment into a DataTable.</summary>
		public static DataTable ListToTable(List<Adjustment> listAdjustments,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Adjustment";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("AdjNum");
			table.Columns.Add("AdjDate");
			table.Columns.Add("AdjAmt");
			table.Columns.Add("PatNum");
			table.Columns.Add("AdjType");
			table.Columns.Add("ProvNum");
			table.Columns.Add("AdjNote");
			table.Columns.Add("ProcDate");
			table.Columns.Add("ProcNum");
			table.Columns.Add("DateEntry");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("StatementNum");
			table.Columns.Add("SecUserNumEntry");
			table.Columns.Add("SecDateTEdit");
			table.Columns.Add("TaxTransID");
			foreach(Adjustment adjustment in listAdjustments) {
				table.Rows.Add(new object[] {
					POut.Long  (adjustment.AdjNum),
					POut.DateT (adjustment.AdjDate,false),
					POut.Double(adjustment.AdjAmt),
					POut.Long  (adjustment.PatNum),
					POut.Long  (adjustment.AdjType),
					POut.Long  (adjustment.ProvNum),
					            adjustment.AdjNote,
					POut.DateT (adjustment.ProcDate,false),
					POut.Long  (adjustment.ProcNum),
					POut.DateT (adjustment.DateEntry,false),
					POut.Long  (adjustment.ClinicNum),
					POut.Long  (adjustment.StatementNum),
					POut.Long  (adjustment.SecUserNumEntry),
					POut.DateT (adjustment.SecDateTEdit,false)
				});
			}
			return table;
		}

		///<summary>Inserts one Adjustment into the database.  Returns the new priKey.</summary>
		public static long Insert(Adjustment adjustment) {
			return Insert(adjustment,false);
		}

		///<summary>Inserts one Adjustment into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Adjustment adjustment,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				adjustment.AdjNum=ReplicationServers.GetKey("adjustment","AdjNum");
			}
			string command="INSERT INTO adjustment (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="AdjNum,";
			}
			command+="AdjDate,AdjAmt,PatNum,AdjType,ProvNum,AdjNote,ProcDate,ProcNum,DateEntry,ClinicNum,StatementNum,SecUserNumEntry,TaxTransID) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(adjustment.AdjNum)+",";
			}
			command+=
				     POut.Date  (adjustment.AdjDate)+","
				+"'"+POut.Double(adjustment.AdjAmt)+"',"
				+    POut.Long  (adjustment.PatNum)+","
				+    POut.Long  (adjustment.AdjType)+","
				+    POut.Long  (adjustment.ProvNum)+","
				+    DbHelper.ParamChar+"paramAdjNote,"
				+    POut.Date  (adjustment.ProcDate)+","
				+    POut.Long  (adjustment.ProcNum)+","
				+    DbHelper.Now()+","
				+    POut.Long  (adjustment.ClinicNum)+","
				+    POut.Long  (adjustment.StatementNum)+","
				+    POut.Long  (adjustment.SecUserNumEntry)+")";
			if(adjustment.AdjNote==null) {
				adjustment.AdjNote="";
			}
			OdSqlParameter paramAdjNote=new OdSqlParameter("paramAdjNote",OdDbType.Text,POut.StringNote(adjustment.AdjNote));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramAdjNote);
			}
			else {
				adjustment.AdjNum=Db.NonQ(command,true,"AdjNum","adjustment",paramAdjNote);
			}
			return adjustment.AdjNum;
		}

		///<summary>Inserts many Adjustments into the database.</summary>
		public static void InsertMany(List<Adjustment> listAdjustments) {
			InsertMany(listAdjustments,false);
		}

		///<summary>Inserts many Adjustments into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<Adjustment> listAdjustments,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(Adjustment adjustment in listAdjustments) {
					Insert(adjustment);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listAdjustments.Count) {
					Adjustment adjustment=listAdjustments[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO adjustment (");
						if(useExistingPK) {
							sbCommands.Append("AdjNum,");
						}
						sbCommands.Append("AdjDate,AdjAmt,PatNum,AdjType,ProvNum,AdjNote,ProcDate,ProcNum,DateEntry,ClinicNum,StatementNum,SecUserNumEntry,TaxTransID) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(adjustment.AdjNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Date(adjustment.AdjDate)); sbRow.Append(",");
					sbRow.Append("'"+POut.Double(adjustment.AdjAmt)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Long(adjustment.PatNum)); sbRow.Append(",");
					sbRow.Append(POut.Long(adjustment.AdjType)); sbRow.Append(",");
					sbRow.Append(POut.Long(adjustment.ProvNum)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(adjustment.AdjNote)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Date(adjustment.ProcDate)); sbRow.Append(",");
					sbRow.Append(POut.Long(adjustment.ProcNum)); sbRow.Append(",");
					sbRow.Append(DbHelper.Now()); sbRow.Append(",");
					sbRow.Append(POut.Long(adjustment.ClinicNum)); sbRow.Append(",");
					sbRow.Append(POut.Long(adjustment.StatementNum)); sbRow.Append(",");
					sbRow.Append(POut.Long(adjustment.SecUserNumEntry)); sbRow.Append(")");
					if(sbCommands.Length+sbRow.Length+1 > TableBase.MaxAllowedPacketCount && countRows > 0) {
						Db.NonQ(sbCommands.ToString());
						sbCommands=null;
					}
					else {
						if(hasComma) {
							sbCommands.Append(",");
						}
						sbCommands.Append(sbRow.ToString());
						countRows++;
						if(index==listAdjustments.Count-1) {
							Db.NonQ(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one Adjustment into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Adjustment adjustment) {
			return InsertNoCache(adjustment,false);
		}

		///<summary>Inserts one Adjustment into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Adjustment adjustment,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO adjustment (";
			if(!useExistingPK && isRandomKeys) {
				adjustment.AdjNum=ReplicationServers.GetKeyNoCache("adjustment","AdjNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="AdjNum,";
			}
			command+="AdjDate,AdjAmt,PatNum,AdjType,ProvNum,AdjNote,ProcDate,ProcNum,DateEntry,ClinicNum,StatementNum,SecUserNumEntry,TaxTransID) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(adjustment.AdjNum)+",";
			}
			command+=
				     POut.Date  (adjustment.AdjDate)+","
				+"'"+POut.Double(adjustment.AdjAmt)+"',"
				+    POut.Long  (adjustment.PatNum)+","
				+    POut.Long  (adjustment.AdjType)+","
				+    POut.Long  (adjustment.ProvNum)+","
				+    DbHelper.ParamChar+"paramAdjNote,"
				+    POut.Date  (adjustment.ProcDate)+","
				+    POut.Long  (adjustment.ProcNum)+","
				+    DbHelper.Now()+","
				+    POut.Long  (adjustment.ClinicNum)+","
				+    POut.Long  (adjustment.StatementNum)+","
				+    POut.Long  (adjustment.SecUserNumEntry)+")";
			if(adjustment.AdjNote==null) {
				adjustment.AdjNote="";
			}
			OdSqlParameter paramAdjNote=new OdSqlParameter("paramAdjNote",OdDbType.Text,POut.StringNote(adjustment.AdjNote));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramAdjNote);
			}
			else {
				adjustment.AdjNum=Db.NonQ(command,true,"AdjNum","adjustment",paramAdjNote);
			}
			return adjustment.AdjNum;
		}

		///<summary>Updates one Adjustment in the database.</summary>
		public static void Update(Adjustment adjustment) {
			string command="UPDATE adjustment SET "
				+"AdjDate        =  "+POut.Date  (adjustment.AdjDate)+", "
				+"AdjAmt         = '"+POut.Double(adjustment.AdjAmt)+"', "
				+"PatNum         =  "+POut.Long  (adjustment.PatNum)+", "
				+"AdjType        =  "+POut.Long  (adjustment.AdjType)+", "
				+"ProvNum        =  "+POut.Long  (adjustment.ProvNum)+", "
				+"AdjNote        =  "+DbHelper.ParamChar+"paramAdjNote, "
				+"ProcDate       =  "+POut.Date  (adjustment.ProcDate)+", "
				+"ProcNum        =  "+POut.Long  (adjustment.ProcNum)+", "
				//DateEntry not allowed to change
				+"ClinicNum      =  "+POut.Long  (adjustment.ClinicNum)+", "
				+"StatementNum   =  "+POut.Long  (adjustment.StatementNum)+" "
				+"WHERE AdjNum = "+POut.Long(adjustment.AdjNum);
			if(adjustment.AdjNote==null) {
				adjustment.AdjNote="";
			}
			OdSqlParameter paramAdjNote=new OdSqlParameter("paramAdjNote",OdDbType.Text,POut.StringNote(adjustment.AdjNote));
			Db.NonQ(command,paramAdjNote);
		}

		///<summary>Updates one Adjustment in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Adjustment adjustment,Adjustment oldAdjustment) {
			string command="";
			if(adjustment.AdjDate.Date != oldAdjustment.AdjDate.Date) {
				if(command!="") { command+=",";}
				command+="AdjDate = "+POut.Date(adjustment.AdjDate)+"";
			}
			if(adjustment.AdjAmt != oldAdjustment.AdjAmt) {
				if(command!="") { command+=",";}
				command+="AdjAmt = '"+POut.Double(adjustment.AdjAmt)+"'";
			}
			if(adjustment.PatNum != oldAdjustment.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(adjustment.PatNum)+"";
			}
			if(adjustment.AdjType != oldAdjustment.AdjType) {
				if(command!="") { command+=",";}
				command+="AdjType = "+POut.Long(adjustment.AdjType)+"";
			}
			if(adjustment.ProvNum != oldAdjustment.ProvNum) {
				if(command!="") { command+=",";}
				command+="ProvNum = "+POut.Long(adjustment.ProvNum)+"";
			}
			if(adjustment.AdjNote != oldAdjustment.AdjNote) {
				if(command!="") { command+=",";}
				command+="AdjNote = "+DbHelper.ParamChar+"paramAdjNote";
			}
			if(adjustment.ProcDate.Date != oldAdjustment.ProcDate.Date) {
				if(command!="") { command+=",";}
				command+="ProcDate = "+POut.Date(adjustment.ProcDate)+"";
			}
			if(adjustment.ProcNum != oldAdjustment.ProcNum) {
				if(command!="") { command+=",";}
				command+="ProcNum = "+POut.Long(adjustment.ProcNum)+"";
			}
			//DateEntry not allowed to change
			if(adjustment.ClinicNum != oldAdjustment.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(adjustment.ClinicNum)+"";
			}
			if(adjustment.StatementNum != oldAdjustment.StatementNum) {
				if(command!="") { command+=",";}
				command+="StatementNum = "+POut.Long(adjustment.StatementNum)+"";
			}
			//SecUserNumEntry excluded from update
			//SecDateTEdit can only be set by MySQL
			if(command=="") {
				return false;
			}
			if(adjustment.AdjNote==null) {
				adjustment.AdjNote="";
			}
			OdSqlParameter paramAdjNote=new OdSqlParameter("paramAdjNote",OdDbType.Text,POut.StringNote(adjustment.AdjNote));
			command="UPDATE adjustment SET "+command
				+" WHERE AdjNum = "+POut.Long(adjustment.AdjNum);
			Db.NonQ(command,paramAdjNote);
			return true;
		}

		///<summary>Returns true if Update(Adjustment,Adjustment) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Adjustment adjustment,Adjustment oldAdjustment) {
			if(adjustment.AdjDate.Date != oldAdjustment.AdjDate.Date) {
				return true;
			}
			if(adjustment.AdjAmt != oldAdjustment.AdjAmt) {
				return true;
			}
			if(adjustment.PatNum != oldAdjustment.PatNum) {
				return true;
			}
			if(adjustment.AdjType != oldAdjustment.AdjType) {
				return true;
			}
			if(adjustment.ProvNum != oldAdjustment.ProvNum) {
				return true;
			}
			if(adjustment.AdjNote != oldAdjustment.AdjNote) {
				return true;
			}
			if(adjustment.ProcDate.Date != oldAdjustment.ProcDate.Date) {
				return true;
			}
			if(adjustment.ProcNum != oldAdjustment.ProcNum) {
				return true;
			}
			//DateEntry not allowed to change
			if(adjustment.ClinicNum != oldAdjustment.ClinicNum) {
				return true;
			}
			if(adjustment.StatementNum != oldAdjustment.StatementNum) {
				return true;
			}
			//SecUserNumEntry excluded from update
			//SecDateTEdit can only be set by MySQL
			return false;
		}

		///<summary>Deletes one Adjustment from the database.</summary>
		public static void Delete(long adjNum) {
			string command="DELETE FROM adjustment "
				+"WHERE AdjNum = "+POut.Long(adjNum);
			Db.NonQ(command);
		}

	}
}