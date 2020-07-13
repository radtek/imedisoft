//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class TreatPlanCrud {
		///<summary>Gets one TreatPlan object from the database using the primary key.  Returns null if not found.</summary>
		public static TreatPlan SelectOne(long treatPlanNum) {
			string command="SELECT * FROM treatplan "
				+"WHERE TreatPlanNum = "+POut.Long(treatPlanNum);
			List<TreatPlan> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one TreatPlan object from the database using a query.</summary>
		public static TreatPlan SelectOne(string command) {

			List<TreatPlan> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of TreatPlan objects from the database using a query.</summary>
		public static List<TreatPlan> SelectMany(string command) {

			List<TreatPlan> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<TreatPlan> TableToList(DataTable table) {
			List<TreatPlan> retVal=new List<TreatPlan>();
			TreatPlan treatPlan;
			foreach(DataRow row in table.Rows) {
				treatPlan=new TreatPlan();
				treatPlan.TreatPlanNum         = PIn.Long  (row["TreatPlanNum"].ToString());
				treatPlan.PatNum               = PIn.Long  (row["PatNum"].ToString());
				treatPlan.DateTP               = PIn.Date  (row["DateTP"].ToString());
				treatPlan.Heading              = PIn.String(row["Heading"].ToString());
				treatPlan.Note                 = PIn.String(row["Note"].ToString());
				treatPlan.Signature            = PIn.String(row["Signature"].ToString());
				treatPlan.SigIsTopaz           = PIn.Bool  (row["SigIsTopaz"].ToString());
				treatPlan.ResponsParty         = PIn.Long  (row["ResponsParty"].ToString());
				treatPlan.DocNum               = PIn.Long  (row["DocNum"].ToString());
				treatPlan.TPStatus             = (OpenDentBusiness.TreatPlanStatus)PIn.Int(row["TPStatus"].ToString());
				treatPlan.SecUserNumEntry      = PIn.Long  (row["SecUserNumEntry"].ToString());
				treatPlan.SecDateEntry         = PIn.Date  (row["SecDateEntry"].ToString());
				treatPlan.SecDateTEdit         = PIn.DateT (row["SecDateTEdit"].ToString());
				treatPlan.UserNumPresenter     = PIn.Long  (row["UserNumPresenter"].ToString());
				treatPlan.TPType               = (OpenDentBusiness.TreatPlanType)PIn.Int(row["TPType"].ToString());
				treatPlan.SignaturePractice    = PIn.String(row["SignaturePractice"].ToString());
				treatPlan.DateTSigned          = PIn.DateT (row["DateTSigned"].ToString());
				treatPlan.DateTPracticeSigned  = PIn.DateT (row["DateTPracticeSigned"].ToString());
				treatPlan.SignatureText        = PIn.String(row["SignatureText"].ToString());
				treatPlan.SignaturePracticeText= PIn.String(row["SignaturePracticeText"].ToString());
				retVal.Add(treatPlan);
			}
			return retVal;
		}

		///<summary>Converts a list of TreatPlan into a DataTable.</summary>
		public static DataTable ListToTable(List<TreatPlan> listTreatPlans,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="TreatPlan";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("TreatPlanNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("DateTP");
			table.Columns.Add("Heading");
			table.Columns.Add("Note");
			table.Columns.Add("Signature");
			table.Columns.Add("SigIsTopaz");
			table.Columns.Add("ResponsParty");
			table.Columns.Add("DocNum");
			table.Columns.Add("TPStatus");
			table.Columns.Add("SecUserNumEntry");
			table.Columns.Add("SecDateEntry");
			table.Columns.Add("SecDateTEdit");
			table.Columns.Add("UserNumPresenter");
			table.Columns.Add("TPType");
			table.Columns.Add("SignaturePractice");
			table.Columns.Add("DateTSigned");
			table.Columns.Add("DateTPracticeSigned");
			table.Columns.Add("SignatureText");
			table.Columns.Add("SignaturePracticeText");
			foreach(TreatPlan treatPlan in listTreatPlans) {
				table.Rows.Add(new object[] {
					POut.Long  (treatPlan.TreatPlanNum),
					POut.Long  (treatPlan.PatNum),
					POut.DateT (treatPlan.DateTP,false),
					            treatPlan.Heading,
					            treatPlan.Note,
					            treatPlan.Signature,
					POut.Bool  (treatPlan.SigIsTopaz),
					POut.Long  (treatPlan.ResponsParty),
					POut.Long  (treatPlan.DocNum),
					POut.Int   ((int)treatPlan.TPStatus),
					POut.Long  (treatPlan.SecUserNumEntry),
					POut.DateT (treatPlan.SecDateEntry,false),
					POut.DateT (treatPlan.SecDateTEdit,false),
					POut.Long  (treatPlan.UserNumPresenter),
					POut.Int   ((int)treatPlan.TPType),
					            treatPlan.SignaturePractice,
					POut.DateT (treatPlan.DateTSigned,false),
					POut.DateT (treatPlan.DateTPracticeSigned,false),
					            treatPlan.SignatureText,
					            treatPlan.SignaturePracticeText,
				});
			}
			return table;
		}

		///<summary>Inserts one TreatPlan into the database.  Returns the new priKey.</summary>
		public static long Insert(TreatPlan treatPlan) {
			return Insert(treatPlan,false);
		}

		///<summary>Inserts one TreatPlan into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(TreatPlan treatPlan,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				treatPlan.TreatPlanNum=ReplicationServers.GetKey("treatplan","TreatPlanNum");
			}
			string command="INSERT INTO treatplan (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="TreatPlanNum,";
			}
			command+="PatNum,DateTP,Heading,Note,Signature,SigIsTopaz,ResponsParty,DocNum,TPStatus,SecUserNumEntry,SecDateEntry,UserNumPresenter,TPType,SignaturePractice,DateTSigned,DateTPracticeSigned,SignatureText,SignaturePracticeText) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(treatPlan.TreatPlanNum)+",";
			}
			command+=
				     POut.Long  (treatPlan.PatNum)+","
				+    POut.Date  (treatPlan.DateTP)+","
				+"'"+POut.String(treatPlan.Heading)+"',"
				+    DbHelper.ParamChar+"paramNote,"
				+    DbHelper.ParamChar+"paramSignature,"
				+    POut.Bool  (treatPlan.SigIsTopaz)+","
				+    POut.Long  (treatPlan.ResponsParty)+","
				+    POut.Long  (treatPlan.DocNum)+","
				+    POut.Int   ((int)treatPlan.TPStatus)+","
				+    POut.Long  (treatPlan.SecUserNumEntry)+","
				+    DbHelper.Now()+","
				//SecDateTEdit can only be set by MySQL
				+    POut.Long  (treatPlan.UserNumPresenter)+","
				+    POut.Int   ((int)treatPlan.TPType)+","
				+    DbHelper.ParamChar+"paramSignaturePractice,"
				+    POut.DateT (treatPlan.DateTSigned)+","
				+    POut.DateT (treatPlan.DateTPracticeSigned)+","
				+"'"+POut.String(treatPlan.SignatureText)+"',"
				+"'"+POut.String(treatPlan.SignaturePracticeText)+"')";
			if(treatPlan.Note==null) {
				treatPlan.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringParam(treatPlan.Note));
			if(treatPlan.Signature==null) {
				treatPlan.Signature="";
			}
			OdSqlParameter paramSignature=new OdSqlParameter("paramSignature",OdDbType.Text,POut.StringParam(treatPlan.Signature));
			if(treatPlan.SignaturePractice==null) {
				treatPlan.SignaturePractice="";
			}
			OdSqlParameter paramSignaturePractice=new OdSqlParameter("paramSignaturePractice",OdDbType.Text,POut.StringParam(treatPlan.SignaturePractice));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramNote,paramSignature,paramSignaturePractice);
			}
			else {
				treatPlan.TreatPlanNum=Db.NonQ(command,true,"TreatPlanNum","treatPlan",paramNote,paramSignature,paramSignaturePractice);
			}
			return treatPlan.TreatPlanNum;
		}

		///<summary>Inserts one TreatPlan into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(TreatPlan treatPlan) {
			return InsertNoCache(treatPlan,false);
		}

		///<summary>Inserts one TreatPlan into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(TreatPlan treatPlan,bool useExistingPK) {
			
			string command="INSERT INTO treatplan (";
			if(!useExistingPK) {
				treatPlan.TreatPlanNum=ReplicationServers.GetKeyNoCache("treatplan","TreatPlanNum");
			}
			if(useExistingPK) {
				command+="TreatPlanNum,";
			}
			command+="PatNum,DateTP,Heading,Note,Signature,SigIsTopaz,ResponsParty,DocNum,TPStatus,SecUserNumEntry,SecDateEntry,UserNumPresenter,TPType,SignaturePractice,DateTSigned,DateTPracticeSigned,SignatureText,SignaturePracticeText) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(treatPlan.TreatPlanNum)+",";
			}
			command+=
				     POut.Long  (treatPlan.PatNum)+","
				+    POut.Date  (treatPlan.DateTP)+","
				+"'"+POut.String(treatPlan.Heading)+"',"
				+    DbHelper.ParamChar+"paramNote,"
				+    DbHelper.ParamChar+"paramSignature,"
				+    POut.Bool  (treatPlan.SigIsTopaz)+","
				+    POut.Long  (treatPlan.ResponsParty)+","
				+    POut.Long  (treatPlan.DocNum)+","
				+    POut.Int   ((int)treatPlan.TPStatus)+","
				+    POut.Long  (treatPlan.SecUserNumEntry)+","
				+    DbHelper.Now()+","
				//SecDateTEdit can only be set by MySQL
				+    POut.Long  (treatPlan.UserNumPresenter)+","
				+    POut.Int   ((int)treatPlan.TPType)+","
				+    DbHelper.ParamChar+"paramSignaturePractice,"
				+    POut.DateT (treatPlan.DateTSigned)+","
				+    POut.DateT (treatPlan.DateTPracticeSigned)+","
				+"'"+POut.String(treatPlan.SignatureText)+"',"
				+"'"+POut.String(treatPlan.SignaturePracticeText)+"')";
			if(treatPlan.Note==null) {
				treatPlan.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringParam(treatPlan.Note));
			if(treatPlan.Signature==null) {
				treatPlan.Signature="";
			}
			OdSqlParameter paramSignature=new OdSqlParameter("paramSignature",OdDbType.Text,POut.StringParam(treatPlan.Signature));
			if(treatPlan.SignaturePractice==null) {
				treatPlan.SignaturePractice="";
			}
			OdSqlParameter paramSignaturePractice=new OdSqlParameter("paramSignaturePractice",OdDbType.Text,POut.StringParam(treatPlan.SignaturePractice));
			if(useExistingPK) {
				Db.NonQ(command,paramNote,paramSignature,paramSignaturePractice);
			}
			else {
				treatPlan.TreatPlanNum=Db.NonQ(command,true,"TreatPlanNum","treatPlan",paramNote,paramSignature,paramSignaturePractice);
			}
			return treatPlan.TreatPlanNum;
		}

		///<summary>Updates one TreatPlan in the database.</summary>
		public static void Update(TreatPlan treatPlan) {
			string command="UPDATE treatplan SET "
				+"PatNum               =  "+POut.Long  (treatPlan.PatNum)+", "
				+"DateTP               =  "+POut.Date  (treatPlan.DateTP)+", "
				+"Heading              = '"+POut.String(treatPlan.Heading)+"', "
				+"Note                 =  "+DbHelper.ParamChar+"paramNote, "
				+"Signature            =  "+DbHelper.ParamChar+"paramSignature, "
				+"SigIsTopaz           =  "+POut.Bool  (treatPlan.SigIsTopaz)+", "
				+"ResponsParty         =  "+POut.Long  (treatPlan.ResponsParty)+", "
				+"DocNum               =  "+POut.Long  (treatPlan.DocNum)+", "
				+"TPStatus             =  "+POut.Int   ((int)treatPlan.TPStatus)+", "
				//SecUserNumEntry excluded from update
				//SecDateEntry not allowed to change
				//SecDateTEdit can only be set by MySQL
				+"UserNumPresenter     =  "+POut.Long  (treatPlan.UserNumPresenter)+", "
				+"TPType               =  "+POut.Int   ((int)treatPlan.TPType)+", "
				+"SignaturePractice    =  "+DbHelper.ParamChar+"paramSignaturePractice, "
				+"DateTSigned          =  "+POut.DateT (treatPlan.DateTSigned)+", "
				+"DateTPracticeSigned  =  "+POut.DateT (treatPlan.DateTPracticeSigned)+", "
				+"SignatureText        = '"+POut.String(treatPlan.SignatureText)+"', "
				+"SignaturePracticeText= '"+POut.String(treatPlan.SignaturePracticeText)+"' "
				+"WHERE TreatPlanNum = "+POut.Long(treatPlan.TreatPlanNum);
			if(treatPlan.Note==null) {
				treatPlan.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringParam(treatPlan.Note));
			if(treatPlan.Signature==null) {
				treatPlan.Signature="";
			}
			OdSqlParameter paramSignature=new OdSqlParameter("paramSignature",OdDbType.Text,POut.StringParam(treatPlan.Signature));
			if(treatPlan.SignaturePractice==null) {
				treatPlan.SignaturePractice="";
			}
			OdSqlParameter paramSignaturePractice=new OdSqlParameter("paramSignaturePractice",OdDbType.Text,POut.StringParam(treatPlan.SignaturePractice));
			Db.NonQ(command,paramNote,paramSignature,paramSignaturePractice);
		}

		///<summary>Updates one TreatPlan in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(TreatPlan treatPlan,TreatPlan oldTreatPlan) {
			string command="";
			if(treatPlan.PatNum != oldTreatPlan.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(treatPlan.PatNum)+"";
			}
			if(treatPlan.DateTP.Date != oldTreatPlan.DateTP.Date) {
				if(command!="") { command+=",";}
				command+="DateTP = "+POut.Date(treatPlan.DateTP)+"";
			}
			if(treatPlan.Heading != oldTreatPlan.Heading) {
				if(command!="") { command+=",";}
				command+="Heading = '"+POut.String(treatPlan.Heading)+"'";
			}
			if(treatPlan.Note != oldTreatPlan.Note) {
				if(command!="") { command+=",";}
				command+="Note = "+DbHelper.ParamChar+"paramNote";
			}
			if(treatPlan.Signature != oldTreatPlan.Signature) {
				if(command!="") { command+=",";}
				command+="Signature = "+DbHelper.ParamChar+"paramSignature";
			}
			if(treatPlan.SigIsTopaz != oldTreatPlan.SigIsTopaz) {
				if(command!="") { command+=",";}
				command+="SigIsTopaz = "+POut.Bool(treatPlan.SigIsTopaz)+"";
			}
			if(treatPlan.ResponsParty != oldTreatPlan.ResponsParty) {
				if(command!="") { command+=",";}
				command+="ResponsParty = "+POut.Long(treatPlan.ResponsParty)+"";
			}
			if(treatPlan.DocNum != oldTreatPlan.DocNum) {
				if(command!="") { command+=",";}
				command+="DocNum = "+POut.Long(treatPlan.DocNum)+"";
			}
			if(treatPlan.TPStatus != oldTreatPlan.TPStatus) {
				if(command!="") { command+=",";}
				command+="TPStatus = "+POut.Int   ((int)treatPlan.TPStatus)+"";
			}
			//SecUserNumEntry excluded from update
			//SecDateEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			if(treatPlan.UserNumPresenter != oldTreatPlan.UserNumPresenter) {
				if(command!="") { command+=",";}
				command+="UserNumPresenter = "+POut.Long(treatPlan.UserNumPresenter)+"";
			}
			if(treatPlan.TPType != oldTreatPlan.TPType) {
				if(command!="") { command+=",";}
				command+="TPType = "+POut.Int   ((int)treatPlan.TPType)+"";
			}
			if(treatPlan.SignaturePractice != oldTreatPlan.SignaturePractice) {
				if(command!="") { command+=",";}
				command+="SignaturePractice = "+DbHelper.ParamChar+"paramSignaturePractice";
			}
			if(treatPlan.DateTSigned != oldTreatPlan.DateTSigned) {
				if(command!="") { command+=",";}
				command+="DateTSigned = "+POut.DateT(treatPlan.DateTSigned)+"";
			}
			if(treatPlan.DateTPracticeSigned != oldTreatPlan.DateTPracticeSigned) {
				if(command!="") { command+=",";}
				command+="DateTPracticeSigned = "+POut.DateT(treatPlan.DateTPracticeSigned)+"";
			}
			if(treatPlan.SignatureText != oldTreatPlan.SignatureText) {
				if(command!="") { command+=",";}
				command+="SignatureText = '"+POut.String(treatPlan.SignatureText)+"'";
			}
			if(treatPlan.SignaturePracticeText != oldTreatPlan.SignaturePracticeText) {
				if(command!="") { command+=",";}
				command+="SignaturePracticeText = '"+POut.String(treatPlan.SignaturePracticeText)+"'";
			}
			if(command=="") {
				return false;
			}
			if(treatPlan.Note==null) {
				treatPlan.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringParam(treatPlan.Note));
			if(treatPlan.Signature==null) {
				treatPlan.Signature="";
			}
			OdSqlParameter paramSignature=new OdSqlParameter("paramSignature",OdDbType.Text,POut.StringParam(treatPlan.Signature));
			if(treatPlan.SignaturePractice==null) {
				treatPlan.SignaturePractice="";
			}
			OdSqlParameter paramSignaturePractice=new OdSqlParameter("paramSignaturePractice",OdDbType.Text,POut.StringParam(treatPlan.SignaturePractice));
			command="UPDATE treatplan SET "+command
				+" WHERE TreatPlanNum = "+POut.Long(treatPlan.TreatPlanNum);
			Db.NonQ(command,paramNote,paramSignature,paramSignaturePractice);
			return true;
		}

		///<summary>Returns true if Update(TreatPlan,TreatPlan) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(TreatPlan treatPlan,TreatPlan oldTreatPlan) {
			if(treatPlan.PatNum != oldTreatPlan.PatNum) {
				return true;
			}
			if(treatPlan.DateTP.Date != oldTreatPlan.DateTP.Date) {
				return true;
			}
			if(treatPlan.Heading != oldTreatPlan.Heading) {
				return true;
			}
			if(treatPlan.Note != oldTreatPlan.Note) {
				return true;
			}
			if(treatPlan.Signature != oldTreatPlan.Signature) {
				return true;
			}
			if(treatPlan.SigIsTopaz != oldTreatPlan.SigIsTopaz) {
				return true;
			}
			if(treatPlan.ResponsParty != oldTreatPlan.ResponsParty) {
				return true;
			}
			if(treatPlan.DocNum != oldTreatPlan.DocNum) {
				return true;
			}
			if(treatPlan.TPStatus != oldTreatPlan.TPStatus) {
				return true;
			}
			//SecUserNumEntry excluded from update
			//SecDateEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			if(treatPlan.UserNumPresenter != oldTreatPlan.UserNumPresenter) {
				return true;
			}
			if(treatPlan.TPType != oldTreatPlan.TPType) {
				return true;
			}
			if(treatPlan.SignaturePractice != oldTreatPlan.SignaturePractice) {
				return true;
			}
			if(treatPlan.DateTSigned != oldTreatPlan.DateTSigned) {
				return true;
			}
			if(treatPlan.DateTPracticeSigned != oldTreatPlan.DateTPracticeSigned) {
				return true;
			}
			if(treatPlan.SignatureText != oldTreatPlan.SignatureText) {
				return true;
			}
			if(treatPlan.SignaturePracticeText != oldTreatPlan.SignaturePracticeText) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one TreatPlan from the database.</summary>
		public static void Delete(long treatPlanNum) {
			string command="DELETE FROM treatplan "
				+"WHERE TreatPlanNum = "+POut.Long(treatPlanNum);
			Db.NonQ(command);
		}

	}
}