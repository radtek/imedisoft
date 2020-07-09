//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class CommlogCrud {
		///<summary>Gets one Commlog object from the database using the primary key.  Returns null if not found.</summary>
		public static Commlog SelectOne(long commlogNum) {
			string command="SELECT * FROM commlog "
				+"WHERE CommlogNum = "+POut.Long(commlogNum);
			List<Commlog> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Commlog object from the database using a query.</summary>
		public static Commlog SelectOne(string command) {

			List<Commlog> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Commlog objects from the database using a query.</summary>
		public static List<Commlog> SelectMany(string command) {

			List<Commlog> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Commlog> TableToList(DataTable table) {
			List<Commlog> retVal=new List<Commlog>();
			Commlog commlog;
			foreach(DataRow row in table.Rows) {
				commlog=new Commlog();
				commlog.CommlogNum    = PIn.Long  (row["CommlogNum"].ToString());
				commlog.PatNum        = PIn.Long  (row["PatNum"].ToString());
				commlog.CommDateTime  = PIn.DateT (row["CommDateTime"].ToString());
				commlog.CommType      = PIn.Long  (row["CommType"].ToString());
				commlog.Note          = PIn.String(row["Note"].ToString());
				commlog.Mode_         = (OpenDentBusiness.CommItemMode)PIn.Int(row["Mode_"].ToString());
				commlog.SentOrReceived= (OpenDentBusiness.CommSentOrReceived)PIn.Int(row["SentOrReceived"].ToString());
				commlog.UserNum       = PIn.Long  (row["UserNum"].ToString());
				commlog.Signature     = PIn.String(row["Signature"].ToString());
				commlog.SigIsTopaz    = PIn.Bool  (row["SigIsTopaz"].ToString());
				commlog.DateTStamp    = PIn.DateT (row["DateTStamp"].ToString());
				commlog.DateTimeEnd   = PIn.DateT (row["DateTimeEnd"].ToString());
				commlog.CommSource    = (OpenDentBusiness.CommItemSource)PIn.Int(row["CommSource"].ToString());
				commlog.ProgramNum    = PIn.Long  (row["ProgramNum"].ToString());
				retVal.Add(commlog);
			}
			return retVal;
		}

		///<summary>Converts a list of Commlog into a DataTable.</summary>
		public static DataTable ListToTable(List<Commlog> listCommlogs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Commlog";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("CommlogNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("CommDateTime");
			table.Columns.Add("CommType");
			table.Columns.Add("Note");
			table.Columns.Add("Mode_");
			table.Columns.Add("SentOrReceived");
			table.Columns.Add("UserNum");
			table.Columns.Add("Signature");
			table.Columns.Add("SigIsTopaz");
			table.Columns.Add("DateTStamp");
			table.Columns.Add("DateTimeEnd");
			table.Columns.Add("CommSource");
			table.Columns.Add("ProgramNum");
			foreach(Commlog commlog in listCommlogs) {
				table.Rows.Add(new object[] {
					POut.Long  (commlog.CommlogNum),
					POut.Long  (commlog.PatNum),
					POut.DateT (commlog.CommDateTime,false),
					POut.Long  (commlog.CommType),
					            commlog.Note,
					POut.Int   ((int)commlog.Mode_),
					POut.Int   ((int)commlog.SentOrReceived),
					POut.Long  (commlog.UserNum),
					            commlog.Signature,
					POut.Bool  (commlog.SigIsTopaz),
					POut.DateT (commlog.DateTStamp,false),
					POut.DateT (commlog.DateTimeEnd,false),
					POut.Int   ((int)commlog.CommSource),
					POut.Long  (commlog.ProgramNum),
				});
			}
			return table;
		}

		///<summary>Inserts one Commlog into the database.  Returns the new priKey.</summary>
		public static long Insert(Commlog commlog) {
			return Insert(commlog,false);
		}

		///<summary>Inserts one Commlog into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Commlog commlog,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				commlog.CommlogNum=ReplicationServers.GetKey("commlog","CommlogNum");
			}
			string command="INSERT INTO commlog (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="CommlogNum,";
			}
			command+="PatNum,CommDateTime,CommType,Note,Mode_,SentOrReceived,UserNum,Signature,SigIsTopaz,DateTimeEnd,CommSource,ProgramNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(commlog.CommlogNum)+",";
			}
			command+=
				     POut.Long  (commlog.PatNum)+","
				+    POut.DateT (commlog.CommDateTime)+","
				+    POut.Long  (commlog.CommType)+","
				+    DbHelper.ParamChar+"paramNote,"
				+    POut.Int   ((int)commlog.Mode_)+","
				+    POut.Int   ((int)commlog.SentOrReceived)+","
				+    POut.Long  (commlog.UserNum)+","
				+    DbHelper.ParamChar+"paramSignature,"
				+    POut.Bool  (commlog.SigIsTopaz)+","
				//DateTStamp can only be set by MySQL
				+    POut.DateT (commlog.DateTimeEnd)+","
				+    POut.Int   ((int)commlog.CommSource)+","
				+    POut.Long  (commlog.ProgramNum)+")";
			if(commlog.Note==null) {
				commlog.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringNote(commlog.Note));
			if(commlog.Signature==null) {
				commlog.Signature="";
			}
			OdSqlParameter paramSignature=new OdSqlParameter("paramSignature",OdDbType.Text,POut.StringParam(commlog.Signature));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramNote,paramSignature);
			}
			else {
				commlog.CommlogNum=Db.NonQ(command,true,"CommlogNum","commlog",paramNote,paramSignature);
			}
			return commlog.CommlogNum;
		}

		///<summary>Inserts one Commlog into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Commlog commlog) {
			return InsertNoCache(commlog,false);
		}

		///<summary>Inserts one Commlog into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Commlog commlog,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO commlog (";
			if(!useExistingPK && isRandomKeys) {
				commlog.CommlogNum=ReplicationServers.GetKeyNoCache("commlog","CommlogNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="CommlogNum,";
			}
			command+="PatNum,CommDateTime,CommType,Note,Mode_,SentOrReceived,UserNum,Signature,SigIsTopaz,DateTimeEnd,CommSource,ProgramNum) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(commlog.CommlogNum)+",";
			}
			command+=
				     POut.Long  (commlog.PatNum)+","
				+    POut.DateT (commlog.CommDateTime)+","
				+    POut.Long  (commlog.CommType)+","
				+    DbHelper.ParamChar+"paramNote,"
				+    POut.Int   ((int)commlog.Mode_)+","
				+    POut.Int   ((int)commlog.SentOrReceived)+","
				+    POut.Long  (commlog.UserNum)+","
				+    DbHelper.ParamChar+"paramSignature,"
				+    POut.Bool  (commlog.SigIsTopaz)+","
				//DateTStamp can only be set by MySQL
				+    POut.DateT (commlog.DateTimeEnd)+","
				+    POut.Int   ((int)commlog.CommSource)+","
				+    POut.Long  (commlog.ProgramNum)+")";
			if(commlog.Note==null) {
				commlog.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringNote(commlog.Note));
			if(commlog.Signature==null) {
				commlog.Signature="";
			}
			OdSqlParameter paramSignature=new OdSqlParameter("paramSignature",OdDbType.Text,POut.StringParam(commlog.Signature));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramNote,paramSignature);
			}
			else {
				commlog.CommlogNum=Db.NonQ(command,true,"CommlogNum","commlog",paramNote,paramSignature);
			}
			return commlog.CommlogNum;
		}

		///<summary>Updates one Commlog in the database.</summary>
		public static void Update(Commlog commlog) {
			string command="UPDATE commlog SET "
				+"PatNum        =  "+POut.Long  (commlog.PatNum)+", "
				+"CommDateTime  =  "+POut.DateT (commlog.CommDateTime)+", "
				+"CommType      =  "+POut.Long  (commlog.CommType)+", "
				+"Note          =  "+DbHelper.ParamChar+"paramNote, "
				+"Mode_         =  "+POut.Int   ((int)commlog.Mode_)+", "
				+"SentOrReceived=  "+POut.Int   ((int)commlog.SentOrReceived)+", "
				+"UserNum       =  "+POut.Long  (commlog.UserNum)+", "
				+"Signature     =  "+DbHelper.ParamChar+"paramSignature, "
				+"SigIsTopaz    =  "+POut.Bool  (commlog.SigIsTopaz)+", "
				//DateTStamp can only be set by MySQL
				+"DateTimeEnd   =  "+POut.DateT (commlog.DateTimeEnd)+", "
				+"CommSource    =  "+POut.Int   ((int)commlog.CommSource)+", "
				+"ProgramNum    =  "+POut.Long  (commlog.ProgramNum)+" "
				+"WHERE CommlogNum = "+POut.Long(commlog.CommlogNum);
			if(commlog.Note==null) {
				commlog.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringNote(commlog.Note));
			if(commlog.Signature==null) {
				commlog.Signature="";
			}
			OdSqlParameter paramSignature=new OdSqlParameter("paramSignature",OdDbType.Text,POut.StringParam(commlog.Signature));
			Db.NonQ(command,paramNote,paramSignature);
		}

		///<summary>Updates one Commlog in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Commlog commlog,Commlog oldCommlog) {
			string command="";
			if(commlog.PatNum != oldCommlog.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(commlog.PatNum)+"";
			}
			if(commlog.CommDateTime != oldCommlog.CommDateTime) {
				if(command!="") { command+=",";}
				command+="CommDateTime = "+POut.DateT(commlog.CommDateTime)+"";
			}
			if(commlog.CommType != oldCommlog.CommType) {
				if(command!="") { command+=",";}
				command+="CommType = "+POut.Long(commlog.CommType)+"";
			}
			if(commlog.Note != oldCommlog.Note) {
				if(command!="") { command+=",";}
				command+="Note = "+DbHelper.ParamChar+"paramNote";
			}
			if(commlog.Mode_ != oldCommlog.Mode_) {
				if(command!="") { command+=",";}
				command+="Mode_ = "+POut.Int   ((int)commlog.Mode_)+"";
			}
			if(commlog.SentOrReceived != oldCommlog.SentOrReceived) {
				if(command!="") { command+=",";}
				command+="SentOrReceived = "+POut.Int   ((int)commlog.SentOrReceived)+"";
			}
			if(commlog.UserNum != oldCommlog.UserNum) {
				if(command!="") { command+=",";}
				command+="UserNum = "+POut.Long(commlog.UserNum)+"";
			}
			if(commlog.Signature != oldCommlog.Signature) {
				if(command!="") { command+=",";}
				command+="Signature = "+DbHelper.ParamChar+"paramSignature";
			}
			if(commlog.SigIsTopaz != oldCommlog.SigIsTopaz) {
				if(command!="") { command+=",";}
				command+="SigIsTopaz = "+POut.Bool(commlog.SigIsTopaz)+"";
			}
			//DateTStamp can only be set by MySQL
			if(commlog.DateTimeEnd != oldCommlog.DateTimeEnd) {
				if(command!="") { command+=",";}
				command+="DateTimeEnd = "+POut.DateT(commlog.DateTimeEnd)+"";
			}
			if(commlog.CommSource != oldCommlog.CommSource) {
				if(command!="") { command+=",";}
				command+="CommSource = "+POut.Int   ((int)commlog.CommSource)+"";
			}
			if(commlog.ProgramNum != oldCommlog.ProgramNum) {
				if(command!="") { command+=",";}
				command+="ProgramNum = "+POut.Long(commlog.ProgramNum)+"";
			}
			if(command=="") {
				return false;
			}
			if(commlog.Note==null) {
				commlog.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringNote(commlog.Note));
			if(commlog.Signature==null) {
				commlog.Signature="";
			}
			OdSqlParameter paramSignature=new OdSqlParameter("paramSignature",OdDbType.Text,POut.StringParam(commlog.Signature));
			command="UPDATE commlog SET "+command
				+" WHERE CommlogNum = "+POut.Long(commlog.CommlogNum);
			Db.NonQ(command,paramNote,paramSignature);
			return true;
		}

		///<summary>Returns true if Update(Commlog,Commlog) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Commlog commlog,Commlog oldCommlog) {
			if(commlog.PatNum != oldCommlog.PatNum) {
				return true;
			}
			if(commlog.CommDateTime != oldCommlog.CommDateTime) {
				return true;
			}
			if(commlog.CommType != oldCommlog.CommType) {
				return true;
			}
			if(commlog.Note != oldCommlog.Note) {
				return true;
			}
			if(commlog.Mode_ != oldCommlog.Mode_) {
				return true;
			}
			if(commlog.SentOrReceived != oldCommlog.SentOrReceived) {
				return true;
			}
			if(commlog.UserNum != oldCommlog.UserNum) {
				return true;
			}
			if(commlog.Signature != oldCommlog.Signature) {
				return true;
			}
			if(commlog.SigIsTopaz != oldCommlog.SigIsTopaz) {
				return true;
			}
			//DateTStamp can only be set by MySQL
			if(commlog.DateTimeEnd != oldCommlog.DateTimeEnd) {
				return true;
			}
			if(commlog.CommSource != oldCommlog.CommSource) {
				return true;
			}
			if(commlog.ProgramNum != oldCommlog.ProgramNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one Commlog from the database.</summary>
		public static void Delete(long commlogNum) {
			string command="DELETE FROM commlog "
				+"WHERE CommlogNum = "+POut.Long(commlogNum);
			Db.NonQ(command);
		}

	}
}