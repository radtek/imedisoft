//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class DatabaseMaintenanceCrud {
		///<summary>Gets one DatabaseMaintenance object from the database using the primary key.  Returns null if not found.</summary>
		public static DatabaseMaintenance SelectOne(long databaseMaintenanceNum) {
			string command="SELECT * FROM databasemaintenance "
				+"WHERE DatabaseMaintenanceNum = "+POut.Long(databaseMaintenanceNum);
			List<DatabaseMaintenance> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one DatabaseMaintenance object from the database using a query.</summary>
		public static DatabaseMaintenance SelectOne(string command) {
			List<DatabaseMaintenance> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of DatabaseMaintenance objects from the database using a query.</summary>
		public static List<DatabaseMaintenance> SelectMany(string command) {
			List<DatabaseMaintenance> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<DatabaseMaintenance> TableToList(DataTable table) {
			List<DatabaseMaintenance> retVal=new List<DatabaseMaintenance>();
			DatabaseMaintenance databaseMaintenance;
			foreach(DataRow row in table.Rows) {
				databaseMaintenance=new DatabaseMaintenance();
				databaseMaintenance.DatabaseMaintenanceNum= PIn.Long  (row["DatabaseMaintenanceNum"].ToString());
				databaseMaintenance.MethodName            = PIn.String(row["MethodName"].ToString());
				databaseMaintenance.IsHidden              = PIn.Bool  (row["IsHidden"].ToString());
				databaseMaintenance.IsOld                 = PIn.Bool  (row["IsOld"].ToString());
				databaseMaintenance.DateLastRun           = PIn.Date (row["DateLastRun"].ToString());
				retVal.Add(databaseMaintenance);
			}
			return retVal;
		}

		///<summary>Converts a list of DatabaseMaintenance into a DataTable.</summary>
		public static DataTable ListToTable(List<DatabaseMaintenance> listDatabaseMaintenances,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="DatabaseMaintenance";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("DatabaseMaintenanceNum");
			table.Columns.Add("MethodName");
			table.Columns.Add("IsHidden");
			table.Columns.Add("IsOld");
			table.Columns.Add("DateLastRun");
			foreach(DatabaseMaintenance databaseMaintenance in listDatabaseMaintenances) {
				table.Rows.Add(new object[] {
					POut.Long  (databaseMaintenance.DatabaseMaintenanceNum),
					            databaseMaintenance.MethodName,
					POut.Bool  (databaseMaintenance.IsHidden),
					POut.Bool  (databaseMaintenance.IsOld),
					POut.DateT (databaseMaintenance.DateLastRun,false),
				});
			}
			return table;
		}

		///<summary>Inserts one DatabaseMaintenance into the database.  Returns the new priKey.</summary>
		public static long Insert(DatabaseMaintenance databaseMaintenance) {
			return Insert(databaseMaintenance,false);
		}

		///<summary>Inserts one DatabaseMaintenance into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(DatabaseMaintenance databaseMaintenance,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				databaseMaintenance.DatabaseMaintenanceNum=ReplicationServers.GetKey("databasemaintenance","DatabaseMaintenanceNum");
			}
			string command="INSERT INTO databasemaintenance (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="DatabaseMaintenanceNum,";
			}
			command+="MethodName,IsHidden,IsOld,DateLastRun) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(databaseMaintenance.DatabaseMaintenanceNum)+",";
			}
			command+=
				 "'"+POut.String(databaseMaintenance.MethodName)+"',"
				+    POut.Bool  (databaseMaintenance.IsHidden)+","
				+    POut.Bool  (databaseMaintenance.IsOld)+","
				+    POut.DateT (databaseMaintenance.DateLastRun)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				databaseMaintenance.DatabaseMaintenanceNum=Database.ExecuteInsert(command);
			}
			return databaseMaintenance.DatabaseMaintenanceNum;
		}

		///<summary>Inserts one DatabaseMaintenance into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(DatabaseMaintenance databaseMaintenance) {
			return InsertNoCache(databaseMaintenance,false);
		}

		///<summary>Inserts one DatabaseMaintenance into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(DatabaseMaintenance databaseMaintenance,bool useExistingPK) {
			
			string command="INSERT INTO databasemaintenance (";
			if(!useExistingPK) {
				databaseMaintenance.DatabaseMaintenanceNum=ReplicationServers.GetKeyNoCache("databasemaintenance","DatabaseMaintenanceNum");
			}
			if(useExistingPK) {
				command+="DatabaseMaintenanceNum,";
			}
			command+="MethodName,IsHidden,IsOld,DateLastRun) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(databaseMaintenance.DatabaseMaintenanceNum)+",";
			}
			command+=
				 "'"+POut.String(databaseMaintenance.MethodName)+"',"
				+    POut.Bool  (databaseMaintenance.IsHidden)+","
				+    POut.Bool  (databaseMaintenance.IsOld)+","
				+    POut.DateT (databaseMaintenance.DateLastRun)+")";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				databaseMaintenance.DatabaseMaintenanceNum=Database.ExecuteInsert(command);
			}
			return databaseMaintenance.DatabaseMaintenanceNum;
		}

		///<summary>Updates one DatabaseMaintenance in the database.</summary>
		public static void Update(DatabaseMaintenance databaseMaintenance) {
			string command="UPDATE databasemaintenance SET "
				+"MethodName            = '"+POut.String(databaseMaintenance.MethodName)+"', "
				+"IsHidden              =  "+POut.Bool  (databaseMaintenance.IsHidden)+", "
				+"IsOld                 =  "+POut.Bool  (databaseMaintenance.IsOld)+", "
				+"DateLastRun           =  "+POut.DateT (databaseMaintenance.DateLastRun)+" "
				+"WHERE DatabaseMaintenanceNum = "+POut.Long(databaseMaintenance.DatabaseMaintenanceNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one DatabaseMaintenance in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(DatabaseMaintenance databaseMaintenance,DatabaseMaintenance oldDatabaseMaintenance) {
			string command="";
			if(databaseMaintenance.MethodName != oldDatabaseMaintenance.MethodName) {
				if(command!="") { command+=",";}
				command+="MethodName = '"+POut.String(databaseMaintenance.MethodName)+"'";
			}
			if(databaseMaintenance.IsHidden != oldDatabaseMaintenance.IsHidden) {
				if(command!="") { command+=",";}
				command+="IsHidden = "+POut.Bool(databaseMaintenance.IsHidden)+"";
			}
			if(databaseMaintenance.IsOld != oldDatabaseMaintenance.IsOld) {
				if(command!="") { command+=",";}
				command+="IsOld = "+POut.Bool(databaseMaintenance.IsOld)+"";
			}
			if(databaseMaintenance.DateLastRun != oldDatabaseMaintenance.DateLastRun) {
				if(command!="") { command+=",";}
				command+="DateLastRun = "+POut.DateT(databaseMaintenance.DateLastRun)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE databasemaintenance SET "+command
				+" WHERE DatabaseMaintenanceNum = "+POut.Long(databaseMaintenance.DatabaseMaintenanceNum);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(DatabaseMaintenance,DatabaseMaintenance) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(DatabaseMaintenance databaseMaintenance,DatabaseMaintenance oldDatabaseMaintenance) {
			if(databaseMaintenance.MethodName != oldDatabaseMaintenance.MethodName) {
				return true;
			}
			if(databaseMaintenance.IsHidden != oldDatabaseMaintenance.IsHidden) {
				return true;
			}
			if(databaseMaintenance.IsOld != oldDatabaseMaintenance.IsOld) {
				return true;
			}
			if(databaseMaintenance.DateLastRun != oldDatabaseMaintenance.DateLastRun) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one DatabaseMaintenance from the database.</summary>
		public static void Delete(long databaseMaintenanceNum) {
			string command="DELETE FROM databasemaintenance "
				+"WHERE DatabaseMaintenanceNum = "+POut.Long(databaseMaintenanceNum);
			Database.ExecuteNonQuery(command);
		}

	}
}