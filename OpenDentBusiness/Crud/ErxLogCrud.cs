//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ErxLogCrud {
		///<summary>Gets one ErxLog object from the database using the primary key.  Returns null if not found.</summary>
		public static ErxLog SelectOne(long erxLogNum) {
			string command="SELECT * FROM erxlog "
				+"WHERE ErxLogNum = "+POut.Long(erxLogNum);
			List<ErxLog> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ErxLog object from the database using a query.</summary>
		public static ErxLog SelectOne(string command) {

			List<ErxLog> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ErxLog objects from the database using a query.</summary>
		public static List<ErxLog> SelectMany(string command) {

			List<ErxLog> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ErxLog> TableToList(DataTable table) {
			List<ErxLog> retVal=new List<ErxLog>();
			ErxLog erxLog;
			foreach(DataRow row in table.Rows) {
				erxLog=new ErxLog();
				erxLog.ErxLogNum = PIn.Long  (row["ErxLogNum"].ToString());
				erxLog.PatNum    = PIn.Long  (row["PatNum"].ToString());
				erxLog.MsgText   = PIn.String(row["MsgText"].ToString());
				erxLog.DateTStamp= PIn.DateT (row["DateTStamp"].ToString());
				erxLog.ProvNum   = PIn.Long  (row["ProvNum"].ToString());
				erxLog.UserNum   = PIn.Long  (row["UserNum"].ToString());
				retVal.Add(erxLog);
			}
			return retVal;
		}

		///<summary>Converts a list of ErxLog into a DataTable.</summary>
		public static DataTable ListToTable(List<ErxLog> listErxLogs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ErxLog";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ErxLogNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("MsgText");
			table.Columns.Add("DateTStamp");
			table.Columns.Add("ProvNum");
			table.Columns.Add("UserNum");
			foreach(ErxLog erxLog in listErxLogs) {
				table.Rows.Add(new object[] {
					POut.Long  (erxLog.ErxLogNum),
					POut.Long  (erxLog.PatNum),
					            erxLog.MsgText,
					POut.DateT (erxLog.DateTStamp,false),
					POut.Long  (erxLog.ProvNum),
					POut.Long  (erxLog.UserNum),
				});
			}
			return table;
		}

		///<summary>Inserts one ErxLog into the database.  Returns the new priKey.</summary>
		public static long Insert(ErxLog erxLog) {
			return Insert(erxLog,false);
		}

		///<summary>Inserts one ErxLog into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ErxLog erxLog,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				erxLog.ErxLogNum=ReplicationServers.GetKey("erxlog","ErxLogNum");
			}
			string command="INSERT INTO erxlog (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ErxLogNum,";
			}
			command+="PatNum,MsgText,ProvNum,UserNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(erxLog.ErxLogNum)+",";
			}
			command+=
				     POut.Long  (erxLog.PatNum)+","
				+    DbHelper.ParamChar+"paramMsgText,"
				//DateTStamp can only be set by MySQL
				+    POut.Long  (erxLog.ProvNum)+","
				+    POut.Long  (erxLog.UserNum)+")";
			if(erxLog.MsgText==null) {
				erxLog.MsgText="";
			}
			OdSqlParameter paramMsgText=new OdSqlParameter("paramMsgText",OdDbType.Text,POut.StringParam(erxLog.MsgText));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramMsgText);
			}
			else {
				erxLog.ErxLogNum=Db.NonQ(command,true,"ErxLogNum","erxLog",paramMsgText);
			}
			return erxLog.ErxLogNum;
		}

		///<summary>Inserts one ErxLog into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ErxLog erxLog) {
			return InsertNoCache(erxLog,false);
		}

		///<summary>Inserts one ErxLog into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ErxLog erxLog,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO erxlog (";
			if(!useExistingPK && isRandomKeys) {
				erxLog.ErxLogNum=ReplicationServers.GetKeyNoCache("erxlog","ErxLogNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ErxLogNum,";
			}
			command+="PatNum,MsgText,ProvNum,UserNum) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(erxLog.ErxLogNum)+",";
			}
			command+=
				     POut.Long  (erxLog.PatNum)+","
				+    DbHelper.ParamChar+"paramMsgText,"
				//DateTStamp can only be set by MySQL
				+    POut.Long  (erxLog.ProvNum)+","
				+    POut.Long  (erxLog.UserNum)+")";
			if(erxLog.MsgText==null) {
				erxLog.MsgText="";
			}
			OdSqlParameter paramMsgText=new OdSqlParameter("paramMsgText",OdDbType.Text,POut.StringParam(erxLog.MsgText));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramMsgText);
			}
			else {
				erxLog.ErxLogNum=Db.NonQ(command,true,"ErxLogNum","erxLog",paramMsgText);
			}
			return erxLog.ErxLogNum;
		}

		///<summary>Updates one ErxLog in the database.</summary>
		public static void Update(ErxLog erxLog) {
			string command="UPDATE erxlog SET "
				+"PatNum    =  "+POut.Long  (erxLog.PatNum)+", "
				+"MsgText   =  "+DbHelper.ParamChar+"paramMsgText, "
				//DateTStamp can only be set by MySQL
				+"ProvNum   =  "+POut.Long  (erxLog.ProvNum)+", "
				+"UserNum   =  "+POut.Long  (erxLog.UserNum)+" "
				+"WHERE ErxLogNum = "+POut.Long(erxLog.ErxLogNum);
			if(erxLog.MsgText==null) {
				erxLog.MsgText="";
			}
			OdSqlParameter paramMsgText=new OdSqlParameter("paramMsgText",OdDbType.Text,POut.StringParam(erxLog.MsgText));
			Db.NonQ(command,paramMsgText);
		}

		///<summary>Updates one ErxLog in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ErxLog erxLog,ErxLog oldErxLog) {
			string command="";
			if(erxLog.PatNum != oldErxLog.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(erxLog.PatNum)+"";
			}
			if(erxLog.MsgText != oldErxLog.MsgText) {
				if(command!="") { command+=",";}
				command+="MsgText = "+DbHelper.ParamChar+"paramMsgText";
			}
			//DateTStamp can only be set by MySQL
			if(erxLog.ProvNum != oldErxLog.ProvNum) {
				if(command!="") { command+=",";}
				command+="ProvNum = "+POut.Long(erxLog.ProvNum)+"";
			}
			if(erxLog.UserNum != oldErxLog.UserNum) {
				if(command!="") { command+=",";}
				command+="UserNum = "+POut.Long(erxLog.UserNum)+"";
			}
			if(command=="") {
				return false;
			}
			if(erxLog.MsgText==null) {
				erxLog.MsgText="";
			}
			OdSqlParameter paramMsgText=new OdSqlParameter("paramMsgText",OdDbType.Text,POut.StringParam(erxLog.MsgText));
			command="UPDATE erxlog SET "+command
				+" WHERE ErxLogNum = "+POut.Long(erxLog.ErxLogNum);
			Db.NonQ(command,paramMsgText);
			return true;
		}

		///<summary>Returns true if Update(ErxLog,ErxLog) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ErxLog erxLog,ErxLog oldErxLog) {
			if(erxLog.PatNum != oldErxLog.PatNum) {
				return true;
			}
			if(erxLog.MsgText != oldErxLog.MsgText) {
				return true;
			}
			//DateTStamp can only be set by MySQL
			if(erxLog.ProvNum != oldErxLog.ProvNum) {
				return true;
			}
			if(erxLog.UserNum != oldErxLog.UserNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ErxLog from the database.</summary>
		public static void Delete(long erxLogNum) {
			string command="DELETE FROM erxlog "
				+"WHERE ErxLogNum = "+POut.Long(erxLogNum);
			Db.NonQ(command);
		}

	}
}