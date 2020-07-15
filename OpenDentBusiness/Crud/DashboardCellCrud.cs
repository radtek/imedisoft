//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class DashboardCellCrud {
		///<summary>Gets one DashboardCell object from the database using the primary key.  Returns null if not found.</summary>
		public static DashboardCell SelectOne(long dashboardCellNum) {
			string command="SELECT * FROM dashboardcell "
				+"WHERE DashboardCellNum = "+POut.Long(dashboardCellNum);
			List<DashboardCell> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one DashboardCell object from the database using a query.</summary>
		public static DashboardCell SelectOne(string command) {

			List<DashboardCell> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of DashboardCell objects from the database using a query.</summary>
		public static List<DashboardCell> SelectMany(string command) {

			List<DashboardCell> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<DashboardCell> TableToList(DataTable table) {
			List<DashboardCell> retVal=new List<DashboardCell>();
			DashboardCell dashboardCell;
			foreach(DataRow row in table.Rows) {
				dashboardCell=new DashboardCell();
				dashboardCell.DashboardCellNum  = PIn.Long  (row["DashboardCellNum"].ToString());
				dashboardCell.DashboardLayoutNum= PIn.Long  (row["DashboardLayoutNum"].ToString());
				dashboardCell.CellRow           = PIn.Int   (row["CellRow"].ToString());
				dashboardCell.CellColumn        = PIn.Int   (row["CellColumn"].ToString());
				string cellType=row["CellType"].ToString();
				if(cellType=="") {
					dashboardCell.CellType        =(OpenDentBusiness.DashboardCellType)0;
				}
				else try{
					dashboardCell.CellType        =(OpenDentBusiness.DashboardCellType)Enum.Parse(typeof(OpenDentBusiness.DashboardCellType),cellType);
				}
				catch{
					dashboardCell.CellType        =(OpenDentBusiness.DashboardCellType)0;
				}
				dashboardCell.CellSettings      = PIn.String(row["CellSettings"].ToString());
				dashboardCell.LastQueryTime     = PIn.Date (row["LastQueryTime"].ToString());
				dashboardCell.LastQueryData     = PIn.String(row["LastQueryData"].ToString());
				dashboardCell.RefreshRateSeconds= PIn.Int   (row["RefreshRateSeconds"].ToString());
				retVal.Add(dashboardCell);
			}
			return retVal;
		}

		///<summary>Converts a list of DashboardCell into a DataTable.</summary>
		public static DataTable ListToTable(List<DashboardCell> listDashboardCells,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="DashboardCell";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("DashboardCellNum");
			table.Columns.Add("DashboardLayoutNum");
			table.Columns.Add("CellRow");
			table.Columns.Add("CellColumn");
			table.Columns.Add("CellType");
			table.Columns.Add("CellSettings");
			table.Columns.Add("LastQueryTime");
			table.Columns.Add("LastQueryData");
			table.Columns.Add("RefreshRateSeconds");
			foreach(DashboardCell dashboardCell in listDashboardCells) {
				table.Rows.Add(new object[] {
					POut.Long  (dashboardCell.DashboardCellNum),
					POut.Long  (dashboardCell.DashboardLayoutNum),
					POut.Int   (dashboardCell.CellRow),
					POut.Int   (dashboardCell.CellColumn),
					POut.Int   ((int)dashboardCell.CellType),
					            dashboardCell.CellSettings,
					POut.DateT (dashboardCell.LastQueryTime,false),
					            dashboardCell.LastQueryData,
					POut.Int   (dashboardCell.RefreshRateSeconds),
				});
			}
			return table;
		}

		///<summary>Inserts one DashboardCell into the database.  Returns the new priKey.</summary>
		public static long Insert(DashboardCell dashboardCell) {
			return Insert(dashboardCell,false);
		}

		///<summary>Inserts one DashboardCell into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(DashboardCell dashboardCell,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				dashboardCell.DashboardCellNum=ReplicationServers.GetKey("dashboardcell","DashboardCellNum");
			}
			string command="INSERT INTO dashboardcell (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="DashboardCellNum,";
			}
			command+="DashboardLayoutNum,CellRow,CellColumn,CellType,CellSettings,LastQueryTime,LastQueryData,RefreshRateSeconds) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(dashboardCell.DashboardCellNum)+",";
			}
			command+=
				     POut.Long  (dashboardCell.DashboardLayoutNum)+","
				+    POut.Int   (dashboardCell.CellRow)+","
				+    POut.Int   (dashboardCell.CellColumn)+","
				+"'"+POut.String(dashboardCell.CellType.ToString())+"',"
				+    DbHelper.ParamChar+"paramCellSettings,"
				+    POut.DateT (dashboardCell.LastQueryTime)+","
				+    DbHelper.ParamChar+"paramLastQueryData,"
				+    POut.Int   (dashboardCell.RefreshRateSeconds)+")";
			if(dashboardCell.CellSettings==null) {
				dashboardCell.CellSettings="";
			}
			OdSqlParameter paramCellSettings=new OdSqlParameter("paramCellSettings",OdDbType.Text,POut.StringParam(dashboardCell.CellSettings));
			if(dashboardCell.LastQueryData==null) {
				dashboardCell.LastQueryData="";
			}
			OdSqlParameter paramLastQueryData=new OdSqlParameter("paramLastQueryData",OdDbType.Text,POut.StringParam(dashboardCell.LastQueryData));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramCellSettings,paramLastQueryData);
			}
			else {
				dashboardCell.DashboardCellNum=Db.NonQ(command,true,"DashboardCellNum","dashboardCell",paramCellSettings,paramLastQueryData);
			}
			return dashboardCell.DashboardCellNum;
		}

		///<summary>Inserts one DashboardCell into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(DashboardCell dashboardCell) {
			return InsertNoCache(dashboardCell,false);
		}

		///<summary>Inserts one DashboardCell into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(DashboardCell dashboardCell,bool useExistingPK) {
			
			string command="INSERT INTO dashboardcell (";
			if(!useExistingPK) {
				dashboardCell.DashboardCellNum=ReplicationServers.GetKeyNoCache("dashboardcell","DashboardCellNum");
			}
			if(useExistingPK) {
				command+="DashboardCellNum,";
			}
			command+="DashboardLayoutNum,CellRow,CellColumn,CellType,CellSettings,LastQueryTime,LastQueryData,RefreshRateSeconds) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(dashboardCell.DashboardCellNum)+",";
			}
			command+=
				     POut.Long  (dashboardCell.DashboardLayoutNum)+","
				+    POut.Int   (dashboardCell.CellRow)+","
				+    POut.Int   (dashboardCell.CellColumn)+","
				+"'"+POut.String(dashboardCell.CellType.ToString())+"',"
				+    DbHelper.ParamChar+"paramCellSettings,"
				+    POut.DateT (dashboardCell.LastQueryTime)+","
				+    DbHelper.ParamChar+"paramLastQueryData,"
				+    POut.Int   (dashboardCell.RefreshRateSeconds)+")";
			if(dashboardCell.CellSettings==null) {
				dashboardCell.CellSettings="";
			}
			OdSqlParameter paramCellSettings=new OdSqlParameter("paramCellSettings",OdDbType.Text,POut.StringParam(dashboardCell.CellSettings));
			if(dashboardCell.LastQueryData==null) {
				dashboardCell.LastQueryData="";
			}
			OdSqlParameter paramLastQueryData=new OdSqlParameter("paramLastQueryData",OdDbType.Text,POut.StringParam(dashboardCell.LastQueryData));
			if(useExistingPK) {
				Db.NonQ(command,paramCellSettings,paramLastQueryData);
			}
			else {
				dashboardCell.DashboardCellNum=Db.NonQ(command,true,"DashboardCellNum","dashboardCell",paramCellSettings,paramLastQueryData);
			}
			return dashboardCell.DashboardCellNum;
		}

		///<summary>Updates one DashboardCell in the database.</summary>
		public static void Update(DashboardCell dashboardCell) {
			string command="UPDATE dashboardcell SET "
				+"DashboardLayoutNum=  "+POut.Long  (dashboardCell.DashboardLayoutNum)+", "
				+"CellRow           =  "+POut.Int   (dashboardCell.CellRow)+", "
				+"CellColumn        =  "+POut.Int   (dashboardCell.CellColumn)+", "
				+"CellType          = '"+POut.String(dashboardCell.CellType.ToString())+"', "
				+"CellSettings      =  "+DbHelper.ParamChar+"paramCellSettings, "
				+"LastQueryTime     =  "+POut.DateT (dashboardCell.LastQueryTime)+", "
				+"LastQueryData     =  "+DbHelper.ParamChar+"paramLastQueryData, "
				+"RefreshRateSeconds=  "+POut.Int   (dashboardCell.RefreshRateSeconds)+" "
				+"WHERE DashboardCellNum = "+POut.Long(dashboardCell.DashboardCellNum);
			if(dashboardCell.CellSettings==null) {
				dashboardCell.CellSettings="";
			}
			OdSqlParameter paramCellSettings=new OdSqlParameter("paramCellSettings",OdDbType.Text,POut.StringParam(dashboardCell.CellSettings));
			if(dashboardCell.LastQueryData==null) {
				dashboardCell.LastQueryData="";
			}
			OdSqlParameter paramLastQueryData=new OdSqlParameter("paramLastQueryData",OdDbType.Text,POut.StringParam(dashboardCell.LastQueryData));
			Db.NonQ(command,paramCellSettings,paramLastQueryData);
		}

		///<summary>Updates one DashboardCell in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(DashboardCell dashboardCell,DashboardCell oldDashboardCell) {
			string command="";
			if(dashboardCell.DashboardLayoutNum != oldDashboardCell.DashboardLayoutNum) {
				if(command!="") { command+=",";}
				command+="DashboardLayoutNum = "+POut.Long(dashboardCell.DashboardLayoutNum)+"";
			}
			if(dashboardCell.CellRow != oldDashboardCell.CellRow) {
				if(command!="") { command+=",";}
				command+="CellRow = "+POut.Int(dashboardCell.CellRow)+"";
			}
			if(dashboardCell.CellColumn != oldDashboardCell.CellColumn) {
				if(command!="") { command+=",";}
				command+="CellColumn = "+POut.Int(dashboardCell.CellColumn)+"";
			}
			if(dashboardCell.CellType != oldDashboardCell.CellType) {
				if(command!="") { command+=",";}
				command+="CellType = '"+POut.String(dashboardCell.CellType.ToString())+"'";
			}
			if(dashboardCell.CellSettings != oldDashboardCell.CellSettings) {
				if(command!="") { command+=",";}
				command+="CellSettings = "+DbHelper.ParamChar+"paramCellSettings";
			}
			if(dashboardCell.LastQueryTime != oldDashboardCell.LastQueryTime) {
				if(command!="") { command+=",";}
				command+="LastQueryTime = "+POut.DateT(dashboardCell.LastQueryTime)+"";
			}
			if(dashboardCell.LastQueryData != oldDashboardCell.LastQueryData) {
				if(command!="") { command+=",";}
				command+="LastQueryData = "+DbHelper.ParamChar+"paramLastQueryData";
			}
			if(dashboardCell.RefreshRateSeconds != oldDashboardCell.RefreshRateSeconds) {
				if(command!="") { command+=",";}
				command+="RefreshRateSeconds = "+POut.Int(dashboardCell.RefreshRateSeconds)+"";
			}
			if(command=="") {
				return false;
			}
			if(dashboardCell.CellSettings==null) {
				dashboardCell.CellSettings="";
			}
			OdSqlParameter paramCellSettings=new OdSqlParameter("paramCellSettings",OdDbType.Text,POut.StringParam(dashboardCell.CellSettings));
			if(dashboardCell.LastQueryData==null) {
				dashboardCell.LastQueryData="";
			}
			OdSqlParameter paramLastQueryData=new OdSqlParameter("paramLastQueryData",OdDbType.Text,POut.StringParam(dashboardCell.LastQueryData));
			command="UPDATE dashboardcell SET "+command
				+" WHERE DashboardCellNum = "+POut.Long(dashboardCell.DashboardCellNum);
			Db.NonQ(command,paramCellSettings,paramLastQueryData);
			return true;
		}

		///<summary>Returns true if Update(DashboardCell,DashboardCell) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(DashboardCell dashboardCell,DashboardCell oldDashboardCell) {
			if(dashboardCell.DashboardLayoutNum != oldDashboardCell.DashboardLayoutNum) {
				return true;
			}
			if(dashboardCell.CellRow != oldDashboardCell.CellRow) {
				return true;
			}
			if(dashboardCell.CellColumn != oldDashboardCell.CellColumn) {
				return true;
			}
			if(dashboardCell.CellType != oldDashboardCell.CellType) {
				return true;
			}
			if(dashboardCell.CellSettings != oldDashboardCell.CellSettings) {
				return true;
			}
			if(dashboardCell.LastQueryTime != oldDashboardCell.LastQueryTime) {
				return true;
			}
			if(dashboardCell.LastQueryData != oldDashboardCell.LastQueryData) {
				return true;
			}
			if(dashboardCell.RefreshRateSeconds != oldDashboardCell.RefreshRateSeconds) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one DashboardCell from the database.</summary>
		public static void Delete(long dashboardCellNum) {
			string command="DELETE FROM dashboardcell "
				+"WHERE DashboardCellNum = "+POut.Long(dashboardCellNum);
			Db.NonQ(command);
		}

	}
}