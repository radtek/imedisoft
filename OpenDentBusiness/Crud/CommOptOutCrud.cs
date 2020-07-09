//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace OpenDentBusiness.Crud{
	public class CommOptOutCrud {
		///<summary>Gets one CommOptOut object from the database using the primary key.  Returns null if not found.</summary>
		public static CommOptOut SelectOne(long commOptOutNum) {
			string command="SELECT * FROM commoptout "
				+"WHERE CommOptOutNum = "+POut.Long(commOptOutNum);
			List<CommOptOut> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one CommOptOut object from the database using a query.</summary>
		public static CommOptOut SelectOne(string command) {

			List<CommOptOut> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of CommOptOut objects from the database using a query.</summary>
		public static List<CommOptOut> SelectMany(string command) {

			List<CommOptOut> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<CommOptOut> TableToList(DataTable table) {
			List<CommOptOut> retVal=new List<CommOptOut>();
			CommOptOut commOptOut;
			foreach(DataRow row in table.Rows) {
				commOptOut=new CommOptOut();
				commOptOut.CommOptOutNum= PIn.Long  (row["CommOptOutNum"].ToString());
				commOptOut.PatNum       = PIn.Long  (row["PatNum"].ToString());
				commOptOut.CommType     = (OpenDentBusiness.CommOptOutType)PIn.Int(row["CommType"].ToString());
				commOptOut.CommMode     = (OpenDentBusiness.CommOptOutMode)PIn.Int(row["CommMode"].ToString());
				retVal.Add(commOptOut);
			}
			return retVal;
		}

		///<summary>Converts a list of CommOptOut into a DataTable.</summary>
		public static DataTable ListToTable(List<CommOptOut> listCommOptOuts,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="CommOptOut";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("CommOptOutNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("CommType");
			table.Columns.Add("CommMode");
			foreach(CommOptOut commOptOut in listCommOptOuts) {
				table.Rows.Add(new object[] {
					POut.Long  (commOptOut.CommOptOutNum),
					POut.Long  (commOptOut.PatNum),
					POut.Int   ((int)commOptOut.CommType),
					POut.Int   ((int)commOptOut.CommMode),
				});
			}
			return table;
		}

		///<summary>Inserts one CommOptOut into the database.  Returns the new priKey.</summary>
		public static long Insert(CommOptOut commOptOut) {
			return Insert(commOptOut,false);
		}

		///<summary>Inserts one CommOptOut into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(CommOptOut commOptOut,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				commOptOut.CommOptOutNum=ReplicationServers.GetKey("commoptout","CommOptOutNum");
			}
			string command="INSERT INTO commoptout (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="CommOptOutNum,";
			}
			command+="PatNum,CommType,CommMode) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(commOptOut.CommOptOutNum)+",";
			}
			command+=
				     POut.Long  (commOptOut.PatNum)+","
				+    POut.Int   ((int)commOptOut.CommType)+","
				+    POut.Int   ((int)commOptOut.CommMode)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				commOptOut.CommOptOutNum=Db.NonQ(command,true,"CommOptOutNum","commOptOut");
			}
			return commOptOut.CommOptOutNum;
		}

		///<summary>Inserts many CommOptOuts into the database.</summary>
		public static void InsertMany(List<CommOptOut> listCommOptOuts) {
			InsertMany(listCommOptOuts,false);
		}

		///<summary>Inserts many CommOptOuts into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<CommOptOut> listCommOptOuts,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(CommOptOut commOptOut in listCommOptOuts) {
					Insert(commOptOut);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listCommOptOuts.Count) {
					CommOptOut commOptOut=listCommOptOuts[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO commoptout (");
						if(useExistingPK) {
							sbCommands.Append("CommOptOutNum,");
						}
						sbCommands.Append("PatNum,CommType,CommMode) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(commOptOut.CommOptOutNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Long(commOptOut.PatNum)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)commOptOut.CommType)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)commOptOut.CommMode)); sbRow.Append(")");
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
						if(index==listCommOptOuts.Count-1) {
							Db.NonQ(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one CommOptOut into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(CommOptOut commOptOut) {
			return InsertNoCache(commOptOut,false);
		}

		///<summary>Inserts one CommOptOut into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(CommOptOut commOptOut,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO commoptout (";
			if(!useExistingPK && isRandomKeys) {
				commOptOut.CommOptOutNum=ReplicationServers.GetKeyNoCache("commoptout","CommOptOutNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="CommOptOutNum,";
			}
			command+="PatNum,CommType,CommMode) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(commOptOut.CommOptOutNum)+",";
			}
			command+=
				     POut.Long  (commOptOut.PatNum)+","
				+    POut.Int   ((int)commOptOut.CommType)+","
				+    POut.Int   ((int)commOptOut.CommMode)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				commOptOut.CommOptOutNum=Db.NonQ(command,true,"CommOptOutNum","commOptOut");
			}
			return commOptOut.CommOptOutNum;
		}

		///<summary>Updates one CommOptOut in the database.</summary>
		public static void Update(CommOptOut commOptOut) {
			string command="UPDATE commoptout SET "
				+"PatNum       =  "+POut.Long  (commOptOut.PatNum)+", "
				+"CommType     =  "+POut.Int   ((int)commOptOut.CommType)+", "
				+"CommMode     =  "+POut.Int   ((int)commOptOut.CommMode)+" "
				+"WHERE CommOptOutNum = "+POut.Long(commOptOut.CommOptOutNum);
			Db.NonQ(command);
		}

		///<summary>Updates one CommOptOut in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(CommOptOut commOptOut,CommOptOut oldCommOptOut) {
			string command="";
			if(commOptOut.PatNum != oldCommOptOut.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(commOptOut.PatNum)+"";
			}
			if(commOptOut.CommType != oldCommOptOut.CommType) {
				if(command!="") { command+=",";}
				command+="CommType = "+POut.Int   ((int)commOptOut.CommType)+"";
			}
			if(commOptOut.CommMode != oldCommOptOut.CommMode) {
				if(command!="") { command+=",";}
				command+="CommMode = "+POut.Int   ((int)commOptOut.CommMode)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE commoptout SET "+command
				+" WHERE CommOptOutNum = "+POut.Long(commOptOut.CommOptOutNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(CommOptOut,CommOptOut) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(CommOptOut commOptOut,CommOptOut oldCommOptOut) {
			if(commOptOut.PatNum != oldCommOptOut.PatNum) {
				return true;
			}
			if(commOptOut.CommType != oldCommOptOut.CommType) {
				return true;
			}
			if(commOptOut.CommMode != oldCommOptOut.CommMode) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one CommOptOut from the database.</summary>
		public static void Delete(long commOptOutNum) {
			string command="DELETE FROM commoptout "
				+"WHERE CommOptOutNum = "+POut.Long(commOptOutNum);
			Db.NonQ(command);
		}

	}
}