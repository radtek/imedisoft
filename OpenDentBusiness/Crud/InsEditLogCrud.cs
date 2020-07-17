//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace OpenDentBusiness.Crud{
	public class InsEditLogCrud {
		///<summary>Gets one InsEditLog object from the database using the primary key.  Returns null if not found.</summary>
		public static InsEditLog SelectOne(long insEditLogNum) {
			string command="SELECT * FROM inseditlog "
				+"WHERE InsEditLogNum = "+POut.Long(insEditLogNum);
			List<InsEditLog> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one InsEditLog object from the database using a query.</summary>
		public static InsEditLog SelectOne(string command) {

			List<InsEditLog> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of InsEditLog objects from the database using a query.</summary>
		public static List<InsEditLog> SelectMany(string command) {

			List<InsEditLog> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<InsEditLog> TableToList(DataTable table) {
			List<InsEditLog> retVal=new List<InsEditLog>();
			InsEditLog insEditLog;
			foreach(DataRow row in table.Rows) {
				insEditLog=new InsEditLog();
				insEditLog.InsEditLogNum= PIn.Long  (row["InsEditLogNum"].ToString());
				insEditLog.FKey         = PIn.Long  (row["FKey"].ToString());
				insEditLog.LogType      = (OpenDentBusiness.InsEditLogType)PIn.Int(row["LogType"].ToString());
				insEditLog.FieldName    = PIn.String(row["FieldName"].ToString());
				insEditLog.OldValue     = PIn.String(row["OldValue"].ToString());
				insEditLog.NewValue     = PIn.String(row["NewValue"].ToString());
				insEditLog.UserNum      = PIn.Long  (row["UserNum"].ToString());
				insEditLog.DateTStamp   = PIn.Date (row["DateTStamp"].ToString());
				insEditLog.ParentKey    = PIn.Long  (row["ParentKey"].ToString());
				insEditLog.Description  = PIn.String(row["Description"].ToString());
				retVal.Add(insEditLog);
			}
			return retVal;
		}

		///<summary>Converts a list of InsEditLog into a DataTable.</summary>
		public static DataTable ListToTable(List<InsEditLog> listInsEditLogs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="InsEditLog";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("InsEditLogNum");
			table.Columns.Add("FKey");
			table.Columns.Add("LogType");
			table.Columns.Add("FieldName");
			table.Columns.Add("OldValue");
			table.Columns.Add("NewValue");
			table.Columns.Add("UserNum");
			table.Columns.Add("DateTStamp");
			table.Columns.Add("ParentKey");
			table.Columns.Add("Description");
			foreach(InsEditLog insEditLog in listInsEditLogs) {
				table.Rows.Add(new object[] {
					POut.Long  (insEditLog.InsEditLogNum),
					POut.Long  (insEditLog.FKey),
					POut.Int   ((int)insEditLog.LogType),
					            insEditLog.FieldName,
					            insEditLog.OldValue,
					            insEditLog.NewValue,
					POut.Long  (insEditLog.UserNum),
					POut.DateT (insEditLog.DateTStamp,false),
					POut.Long  (insEditLog.ParentKey),
					            insEditLog.Description,
				});
			}
			return table;
		}

		///<summary>Inserts one InsEditLog into the database.  Returns the new priKey.</summary>
		public static long Insert(InsEditLog insEditLog) {
			return Insert(insEditLog,false);
		}

		///<summary>Inserts one InsEditLog into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(InsEditLog insEditLog,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				insEditLog.InsEditLogNum=ReplicationServers.GetKey("inseditlog","InsEditLogNum");
			}
			string command="INSERT INTO inseditlog (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="InsEditLogNum,";
			}
			command+="FKey,LogType,FieldName,OldValue,NewValue,UserNum,ParentKey,Description) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(insEditLog.InsEditLogNum)+",";
			}
			command+=
				     POut.Long  (insEditLog.FKey)+","
				+    POut.Int   ((int)insEditLog.LogType)+","
				+"'"+POut.String(insEditLog.FieldName)+"',"
				+"'"+POut.String(insEditLog.OldValue)+"',"
				+"'"+POut.String(insEditLog.NewValue)+"',"
				+    POut.Long  (insEditLog.UserNum)+","
				//DateTStamp can only be set by MySQL
				+    POut.Long  (insEditLog.ParentKey)+","
				+"'"+POut.String(insEditLog.Description)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				insEditLog.InsEditLogNum=Database.ExecuteInsert(command);
			}
			return insEditLog.InsEditLogNum;
		}

		///<summary>Inserts many InsEditLogs into the database.</summary>
		public static void InsertMany(List<InsEditLog> listInsEditLogs) {
			InsertMany(listInsEditLogs,false);
		}

		///<summary>Inserts many InsEditLogs into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<InsEditLog> listInsEditLogs,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(InsEditLog insEditLog in listInsEditLogs) {
					Insert(insEditLog);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listInsEditLogs.Count) {
					InsEditLog insEditLog=listInsEditLogs[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO inseditlog (");
						if(useExistingPK) {
							sbCommands.Append("InsEditLogNum,");
						}
						sbCommands.Append("FKey,LogType,FieldName,OldValue,NewValue,UserNum,ParentKey,Description) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(insEditLog.InsEditLogNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Long(insEditLog.FKey)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)insEditLog.LogType)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(insEditLog.FieldName)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(insEditLog.OldValue)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(insEditLog.NewValue)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Long(insEditLog.UserNum)); sbRow.Append(",");
					//DateTStamp can only be set by MySQL
					sbRow.Append(POut.Long(insEditLog.ParentKey)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(insEditLog.Description)+"'"); sbRow.Append(")");
					if(sbCommands.Length+sbRow.Length+1 > TableBase.MaxAllowedPacketCount && countRows > 0) {
						Database.ExecuteNonQuery(sbCommands.ToString());
						sbCommands=null;
					}
					else {
						if(hasComma) {
							sbCommands.Append(",");
						}
						sbCommands.Append(sbRow.ToString());
						countRows++;
						if(index==listInsEditLogs.Count-1) {
							Database.ExecuteNonQuery(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one InsEditLog into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(InsEditLog insEditLog) {
			return InsertNoCache(insEditLog,false);
		}

		///<summary>Inserts one InsEditLog into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(InsEditLog insEditLog,bool useExistingPK) {
			
			string command="INSERT INTO inseditlog (";
			if(!useExistingPK) {
				insEditLog.InsEditLogNum=ReplicationServers.GetKeyNoCache("inseditlog","InsEditLogNum");
			}
			if(useExistingPK) {
				command+="InsEditLogNum,";
			}
			command+="FKey,LogType,FieldName,OldValue,NewValue,UserNum,ParentKey,Description) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(insEditLog.InsEditLogNum)+",";
			}
			command+=
				     POut.Long  (insEditLog.FKey)+","
				+    POut.Int   ((int)insEditLog.LogType)+","
				+"'"+POut.String(insEditLog.FieldName)+"',"
				+"'"+POut.String(insEditLog.OldValue)+"',"
				+"'"+POut.String(insEditLog.NewValue)+"',"
				+    POut.Long  (insEditLog.UserNum)+","
				//DateTStamp can only be set by MySQL
				+    POut.Long  (insEditLog.ParentKey)+","
				+"'"+POut.String(insEditLog.Description)+"')";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				insEditLog.InsEditLogNum=Database.ExecuteInsert(command);
			}
			return insEditLog.InsEditLogNum;
		}

		///<summary>Updates one InsEditLog in the database.</summary>
		public static void Update(InsEditLog insEditLog) {
			string command="UPDATE inseditlog SET "
				+"FKey         =  "+POut.Long  (insEditLog.FKey)+", "
				+"LogType      =  "+POut.Int   ((int)insEditLog.LogType)+", "
				+"FieldName    = '"+POut.String(insEditLog.FieldName)+"', "
				+"OldValue     = '"+POut.String(insEditLog.OldValue)+"', "
				+"NewValue     = '"+POut.String(insEditLog.NewValue)+"', "
				+"UserNum      =  "+POut.Long  (insEditLog.UserNum)+", "
				//DateTStamp can only be set by MySQL
				+"ParentKey    =  "+POut.Long  (insEditLog.ParentKey)+", "
				+"Description  = '"+POut.String(insEditLog.Description)+"' "
				+"WHERE InsEditLogNum = "+POut.Long(insEditLog.InsEditLogNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one InsEditLog in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(InsEditLog insEditLog,InsEditLog oldInsEditLog) {
			string command="";
			if(insEditLog.FKey != oldInsEditLog.FKey) {
				if(command!="") { command+=",";}
				command+="FKey = "+POut.Long(insEditLog.FKey)+"";
			}
			if(insEditLog.LogType != oldInsEditLog.LogType) {
				if(command!="") { command+=",";}
				command+="LogType = "+POut.Int   ((int)insEditLog.LogType)+"";
			}
			if(insEditLog.FieldName != oldInsEditLog.FieldName) {
				if(command!="") { command+=",";}
				command+="FieldName = '"+POut.String(insEditLog.FieldName)+"'";
			}
			if(insEditLog.OldValue != oldInsEditLog.OldValue) {
				if(command!="") { command+=",";}
				command+="OldValue = '"+POut.String(insEditLog.OldValue)+"'";
			}
			if(insEditLog.NewValue != oldInsEditLog.NewValue) {
				if(command!="") { command+=",";}
				command+="NewValue = '"+POut.String(insEditLog.NewValue)+"'";
			}
			if(insEditLog.UserNum != oldInsEditLog.UserNum) {
				if(command!="") { command+=",";}
				command+="UserNum = "+POut.Long(insEditLog.UserNum)+"";
			}
			//DateTStamp can only be set by MySQL
			if(insEditLog.ParentKey != oldInsEditLog.ParentKey) {
				if(command!="") { command+=",";}
				command+="ParentKey = "+POut.Long(insEditLog.ParentKey)+"";
			}
			if(insEditLog.Description != oldInsEditLog.Description) {
				if(command!="") { command+=",";}
				command+="Description = '"+POut.String(insEditLog.Description)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE inseditlog SET "+command
				+" WHERE InsEditLogNum = "+POut.Long(insEditLog.InsEditLogNum);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(InsEditLog,InsEditLog) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(InsEditLog insEditLog,InsEditLog oldInsEditLog) {
			if(insEditLog.FKey != oldInsEditLog.FKey) {
				return true;
			}
			if(insEditLog.LogType != oldInsEditLog.LogType) {
				return true;
			}
			if(insEditLog.FieldName != oldInsEditLog.FieldName) {
				return true;
			}
			if(insEditLog.OldValue != oldInsEditLog.OldValue) {
				return true;
			}
			if(insEditLog.NewValue != oldInsEditLog.NewValue) {
				return true;
			}
			if(insEditLog.UserNum != oldInsEditLog.UserNum) {
				return true;
			}
			//DateTStamp can only be set by MySQL
			if(insEditLog.ParentKey != oldInsEditLog.ParentKey) {
				return true;
			}
			if(insEditLog.Description != oldInsEditLog.Description) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one InsEditLog from the database.</summary>
		public static void Delete(long insEditLogNum) {
			string command="DELETE FROM inseditlog "
				+"WHERE InsEditLogNum = "+POut.Long(insEditLogNum);
			Database.ExecuteNonQuery(command);
		}

	}
}