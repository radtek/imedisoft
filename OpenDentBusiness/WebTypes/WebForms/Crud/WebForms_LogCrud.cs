//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.WebTypes.WebForms.Crud{
	public class WebForms_LogCrud {
		///<summary>Gets one WebForms_Log object from the database using the primary key.  Returns null if not found.</summary>
		public static WebForms_Log SelectOne(long logNum) {
			string command="SELECT * FROM webforms_log "
				+"WHERE LogNum = "+POut.Long(logNum);
			List<WebForms_Log> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one WebForms_Log object from the database using a query.</summary>
		public static WebForms_Log SelectOne(string command) {

			List<WebForms_Log> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of WebForms_Log objects from the database using a query.</summary>
		public static List<WebForms_Log> SelectMany(string command) {

			List<WebForms_Log> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<WebForms_Log> TableToList(DataTable table) {
			List<WebForms_Log> retVal=new List<WebForms_Log>();
			WebForms_Log webForms_Log;
			foreach(DataRow row in table.Rows) {
				webForms_Log=new WebForms_Log();
				webForms_Log.LogNum        = PIn.Long  (row["LogNum"].ToString());
				webForms_Log.DentalOfficeID= PIn.Long  (row["DentalOfficeID"].ToString());
				webForms_Log.WebSheetDefIDs= PIn.String(row["WebSheetDefIDs"].ToString());
				webForms_Log.LogMessage    = PIn.String(row["LogMessage"].ToString());
				webForms_Log.DateTStamp    = PIn.Date (row["DateTStamp"].ToString());
				retVal.Add(webForms_Log);
			}
			return retVal;
		}

		///<summary>Converts a list of WebForms_Log into a DataTable.</summary>
		public static DataTable ListToTable(List<WebForms_Log> listWebForms_Logs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="WebForms_Log";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("LogNum");
			table.Columns.Add("DentalOfficeID");
			table.Columns.Add("WebSheetDefIDs");
			table.Columns.Add("LogMessage");
			table.Columns.Add("DateTStamp");
			foreach(WebForms_Log webForms_Log in listWebForms_Logs) {
				table.Rows.Add(new object[] {
					POut.Long  (webForms_Log.LogNum),
					POut.Long  (webForms_Log.DentalOfficeID),
					            webForms_Log.WebSheetDefIDs,
					            webForms_Log.LogMessage,
					POut.DateT (webForms_Log.DateTStamp,false),
				});
			}
			return table;
		}

		///<summary>Inserts one WebForms_Log into the database.  Returns the new priKey.</summary>
		public static long Insert(WebForms_Log webForms_Log) {
			return Insert(webForms_Log,false);
		}

		///<summary>Inserts one WebForms_Log into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(WebForms_Log webForms_Log,bool useExistingPK) {
			string command="INSERT INTO webforms_log (";
			if(useExistingPK) {
				command+="LogNum,";
			}
			command+="DentalOfficeID,WebSheetDefIDs,LogMessage) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(webForms_Log.LogNum)+",";
			}
			command+=
				     POut.Long  (webForms_Log.DentalOfficeID)+","
				+"'"+POut.String(webForms_Log.WebSheetDefIDs)+"',"
				+    DbHelper.ParamChar+"paramLogMessage)";
				//DateTStamp can only be set by MySQL
			if(webForms_Log.LogMessage==null) {
				webForms_Log.LogMessage="";
			}
			OdSqlParameter paramLogMessage=new OdSqlParameter("paramLogMessage",OdDbType.Text,POut.StringParam(webForms_Log.LogMessage));
			if(useExistingPK) {
				Db.NonQ(command,paramLogMessage);
			}
			else {
				webForms_Log.LogNum=Db.NonQ(command,true,"LogNum","webForms_Log",paramLogMessage);
			}
			return webForms_Log.LogNum;
		}

		///<summary>Inserts one WebForms_Log into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(WebForms_Log webForms_Log) {
			return InsertNoCache(webForms_Log,false);
		}

		///<summary>Inserts one WebForms_Log into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(WebForms_Log webForms_Log,bool useExistingPK) {
			string command="INSERT INTO webforms_log (";
			if(useExistingPK) {
				command+="LogNum,";
			}
			command+="DentalOfficeID,WebSheetDefIDs,LogMessage) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(webForms_Log.LogNum)+",";
			}
			command+=
				     POut.Long  (webForms_Log.DentalOfficeID)+","
				+"'"+POut.String(webForms_Log.WebSheetDefIDs)+"',"
				+    DbHelper.ParamChar+"paramLogMessage)";
				//DateTStamp can only be set by MySQL
			if(webForms_Log.LogMessage==null) {
				webForms_Log.LogMessage="";
			}
			OdSqlParameter paramLogMessage=new OdSqlParameter("paramLogMessage",OdDbType.Text,POut.StringParam(webForms_Log.LogMessage));
			if(useExistingPK) {
				Db.NonQ(command,paramLogMessage);
			}
			else {
				webForms_Log.LogNum=Db.NonQ(command,true,"LogNum","webForms_Log",paramLogMessage);
			}
			return webForms_Log.LogNum;
		}

		///<summary>Updates one WebForms_Log in the database.</summary>
		public static void Update(WebForms_Log webForms_Log) {
			string command="UPDATE webforms_log SET "
				+"DentalOfficeID=  "+POut.Long  (webForms_Log.DentalOfficeID)+", "
				+"WebSheetDefIDs= '"+POut.String(webForms_Log.WebSheetDefIDs)+"', "
				+"LogMessage    =  "+DbHelper.ParamChar+"paramLogMessage "
				//DateTStamp can only be set by MySQL
				+"WHERE LogNum = "+POut.Long(webForms_Log.LogNum);
			if(webForms_Log.LogMessage==null) {
				webForms_Log.LogMessage="";
			}
			OdSqlParameter paramLogMessage=new OdSqlParameter("paramLogMessage",OdDbType.Text,POut.StringParam(webForms_Log.LogMessage));
			Db.NonQ(command,paramLogMessage);
		}

		///<summary>Updates one WebForms_Log in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(WebForms_Log webForms_Log,WebForms_Log oldWebForms_Log) {
			string command="";
			if(webForms_Log.DentalOfficeID != oldWebForms_Log.DentalOfficeID) {
				if(command!="") { command+=",";}
				command+="DentalOfficeID = "+POut.Long(webForms_Log.DentalOfficeID)+"";
			}
			if(webForms_Log.WebSheetDefIDs != oldWebForms_Log.WebSheetDefIDs) {
				if(command!="") { command+=",";}
				command+="WebSheetDefIDs = '"+POut.String(webForms_Log.WebSheetDefIDs)+"'";
			}
			if(webForms_Log.LogMessage != oldWebForms_Log.LogMessage) {
				if(command!="") { command+=",";}
				command+="LogMessage = "+DbHelper.ParamChar+"paramLogMessage";
			}
			//DateTStamp can only be set by MySQL
			if(command=="") {
				return false;
			}
			if(webForms_Log.LogMessage==null) {
				webForms_Log.LogMessage="";
			}
			OdSqlParameter paramLogMessage=new OdSqlParameter("paramLogMessage",OdDbType.Text,POut.StringParam(webForms_Log.LogMessage));
			command="UPDATE webforms_log SET "+command
				+" WHERE LogNum = "+POut.Long(webForms_Log.LogNum);
			Db.NonQ(command,paramLogMessage);
			return true;
		}

		///<summary>Returns true if Update(WebForms_Log,WebForms_Log) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(WebForms_Log webForms_Log,WebForms_Log oldWebForms_Log) {
			if(webForms_Log.DentalOfficeID != oldWebForms_Log.DentalOfficeID) {
				return true;
			}
			if(webForms_Log.WebSheetDefIDs != oldWebForms_Log.WebSheetDefIDs) {
				return true;
			}
			if(webForms_Log.LogMessage != oldWebForms_Log.LogMessage) {
				return true;
			}
			//DateTStamp can only be set by MySQL
			return false;
		}

		///<summary>Deletes one WebForms_Log from the database.</summary>
		public static void Delete(long logNum) {
			string command="DELETE FROM webforms_log "
				+"WHERE LogNum = "+POut.Long(logNum);
			Db.NonQ(command);
		}

	}
}