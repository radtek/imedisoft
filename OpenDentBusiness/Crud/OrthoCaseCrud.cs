//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class OrthoCaseCrud {
		///<summary>Gets one OrthoCase object from the database using the primary key.  Returns null if not found.</summary>
		public static OrthoCase SelectOne(long orthoCaseNum) {
			string command="SELECT * FROM orthocase "
				+"WHERE OrthoCaseNum = "+POut.Long(orthoCaseNum);
			List<OrthoCase> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one OrthoCase object from the database using a query.</summary>
		public static OrthoCase SelectOne(string command) {

			List<OrthoCase> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of OrthoCase objects from the database using a query.</summary>
		public static List<OrthoCase> SelectMany(string command) {

			List<OrthoCase> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<OrthoCase> TableToList(DataTable table) {
			List<OrthoCase> retVal=new List<OrthoCase>();
			OrthoCase orthoCase;
			foreach(DataRow row in table.Rows) {
				orthoCase=new OrthoCase();
				orthoCase.OrthoCaseNum      = PIn.Long  (row["OrthoCaseNum"].ToString());
				orthoCase.PatNum            = PIn.Long  (row["PatNum"].ToString());
				orthoCase.ProvNum           = PIn.Long  (row["ProvNum"].ToString());
				orthoCase.ClinicNum         = PIn.Long  (row["ClinicNum"].ToString());
				orthoCase.Fee               = PIn.Double(row["Fee"].ToString());
				orthoCase.FeeInsPrimary     = PIn.Double(row["FeeInsPrimary"].ToString());
				orthoCase.FeePat            = PIn.Double(row["FeePat"].ToString());
				orthoCase.BandingDate       = PIn.Date  (row["BandingDate"].ToString());
				orthoCase.DebondDate        = PIn.Date  (row["DebondDate"].ToString());
				orthoCase.DebondDateExpected= PIn.Date  (row["DebondDateExpected"].ToString());
				orthoCase.IsTransfer        = PIn.Bool  (row["IsTransfer"].ToString());
				orthoCase.OrthoType         = PIn.Long  (row["OrthoType"].ToString());
				orthoCase.SecDateTEntry     = PIn.DateT (row["SecDateTEntry"].ToString());
				orthoCase.SecUserNumEntry   = PIn.Long  (row["SecUserNumEntry"].ToString());
				orthoCase.SecDateTEdit      = PIn.DateT (row["SecDateTEdit"].ToString());
				orthoCase.IsActive          = PIn.Bool  (row["IsActive"].ToString());
				orthoCase.FeeInsSecondary   = PIn.Double(row["FeeInsSecondary"].ToString());
				retVal.Add(orthoCase);
			}
			return retVal;
		}

		///<summary>Converts a list of OrthoCase into a DataTable.</summary>
		public static DataTable ListToTable(List<OrthoCase> listOrthoCases,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="OrthoCase";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("OrthoCaseNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("ProvNum");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("Fee");
			table.Columns.Add("FeeInsPrimary");
			table.Columns.Add("FeePat");
			table.Columns.Add("BandingDate");
			table.Columns.Add("DebondDate");
			table.Columns.Add("DebondDateExpected");
			table.Columns.Add("IsTransfer");
			table.Columns.Add("OrthoType");
			table.Columns.Add("SecDateTEntry");
			table.Columns.Add("SecUserNumEntry");
			table.Columns.Add("SecDateTEdit");
			table.Columns.Add("IsActive");
			table.Columns.Add("FeeInsSecondary");
			foreach(OrthoCase orthoCase in listOrthoCases) {
				table.Rows.Add(new object[] {
					POut.Long  (orthoCase.OrthoCaseNum),
					POut.Long  (orthoCase.PatNum),
					POut.Long  (orthoCase.ProvNum),
					POut.Long  (orthoCase.ClinicNum),
					POut.Double(orthoCase.Fee),
					POut.Double(orthoCase.FeeInsPrimary),
					POut.Double(orthoCase.FeePat),
					POut.DateT (orthoCase.BandingDate,false),
					POut.DateT (orthoCase.DebondDate,false),
					POut.DateT (orthoCase.DebondDateExpected,false),
					POut.Bool  (orthoCase.IsTransfer),
					POut.Long  (orthoCase.OrthoType),
					POut.DateT (orthoCase.SecDateTEntry,false),
					POut.Long  (orthoCase.SecUserNumEntry),
					POut.DateT (orthoCase.SecDateTEdit,false),
					POut.Bool  (orthoCase.IsActive),
					POut.Double(orthoCase.FeeInsSecondary),
				});
			}
			return table;
		}

		///<summary>Inserts one OrthoCase into the database.  Returns the new priKey.</summary>
		public static long Insert(OrthoCase orthoCase) {
			return Insert(orthoCase,false);
		}

		///<summary>Inserts one OrthoCase into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(OrthoCase orthoCase,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				orthoCase.OrthoCaseNum=ReplicationServers.GetKey("orthocase","OrthoCaseNum");
			}
			string command="INSERT INTO orthocase (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="OrthoCaseNum,";
			}
			command+="PatNum,ProvNum,ClinicNum,Fee,FeeInsPrimary,FeePat,BandingDate,DebondDate,DebondDateExpected,IsTransfer,OrthoType,SecDateTEntry,SecUserNumEntry,IsActive,FeeInsSecondary) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(orthoCase.OrthoCaseNum)+",";
			}
			command+=
				     POut.Long  (orthoCase.PatNum)+","
				+    POut.Long  (orthoCase.ProvNum)+","
				+    POut.Long  (orthoCase.ClinicNum)+","
				+"'"+POut.Double(orthoCase.Fee)+"',"
				+"'"+POut.Double(orthoCase.FeeInsPrimary)+"',"
				+"'"+POut.Double(orthoCase.FeePat)+"',"
				+    POut.Date  (orthoCase.BandingDate)+","
				+    POut.Date  (orthoCase.DebondDate)+","
				+    POut.Date  (orthoCase.DebondDateExpected)+","
				+    POut.Bool  (orthoCase.IsTransfer)+","
				+    POut.Long  (orthoCase.OrthoType)+","
				+    DbHelper.Now()+","
				+    POut.Long  (orthoCase.SecUserNumEntry)+","
				//SecDateTEdit can only be set by MySQL
				+    POut.Bool  (orthoCase.IsActive)+","
				+"'"+POut.Double(orthoCase.FeeInsSecondary)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				orthoCase.OrthoCaseNum=Db.NonQ(command,true,"OrthoCaseNum","orthoCase");
			}
			return orthoCase.OrthoCaseNum;
		}

		///<summary>Inserts one OrthoCase into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(OrthoCase orthoCase) {
			return InsertNoCache(orthoCase,false);
		}

		///<summary>Inserts one OrthoCase into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(OrthoCase orthoCase,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO orthocase (";
			if(!useExistingPK && isRandomKeys) {
				orthoCase.OrthoCaseNum=ReplicationServers.GetKeyNoCache("orthocase","OrthoCaseNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="OrthoCaseNum,";
			}
			command+="PatNum,ProvNum,ClinicNum,Fee,FeeInsPrimary,FeePat,BandingDate,DebondDate,DebondDateExpected,IsTransfer,OrthoType,SecDateTEntry,SecUserNumEntry,IsActive,FeeInsSecondary) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(orthoCase.OrthoCaseNum)+",";
			}
			command+=
				     POut.Long  (orthoCase.PatNum)+","
				+    POut.Long  (orthoCase.ProvNum)+","
				+    POut.Long  (orthoCase.ClinicNum)+","
				+"'"+POut.Double(orthoCase.Fee)+"',"
				+"'"+POut.Double(orthoCase.FeeInsPrimary)+"',"
				+"'"+POut.Double(orthoCase.FeePat)+"',"
				+    POut.Date  (orthoCase.BandingDate)+","
				+    POut.Date  (orthoCase.DebondDate)+","
				+    POut.Date  (orthoCase.DebondDateExpected)+","
				+    POut.Bool  (orthoCase.IsTransfer)+","
				+    POut.Long  (orthoCase.OrthoType)+","
				+    DbHelper.Now()+","
				+    POut.Long  (orthoCase.SecUserNumEntry)+","
				//SecDateTEdit can only be set by MySQL
				+    POut.Bool  (orthoCase.IsActive)+","
				+"'"+POut.Double(orthoCase.FeeInsSecondary)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				orthoCase.OrthoCaseNum=Db.NonQ(command,true,"OrthoCaseNum","orthoCase");
			}
			return orthoCase.OrthoCaseNum;
		}

		///<summary>Updates one OrthoCase in the database.</summary>
		public static void Update(OrthoCase orthoCase) {
			string command="UPDATE orthocase SET "
				+"PatNum            =  "+POut.Long  (orthoCase.PatNum)+", "
				+"ProvNum           =  "+POut.Long  (orthoCase.ProvNum)+", "
				+"ClinicNum         =  "+POut.Long  (orthoCase.ClinicNum)+", "
				+"Fee               = '"+POut.Double(orthoCase.Fee)+"', "
				+"FeeInsPrimary     = '"+POut.Double(orthoCase.FeeInsPrimary)+"', "
				+"FeePat            = '"+POut.Double(orthoCase.FeePat)+"', "
				+"BandingDate       =  "+POut.Date  (orthoCase.BandingDate)+", "
				+"DebondDate        =  "+POut.Date  (orthoCase.DebondDate)+", "
				+"DebondDateExpected=  "+POut.Date  (orthoCase.DebondDateExpected)+", "
				+"IsTransfer        =  "+POut.Bool  (orthoCase.IsTransfer)+", "
				+"OrthoType         =  "+POut.Long  (orthoCase.OrthoType)+", "
				//SecDateTEntry not allowed to change
				+"SecUserNumEntry   =  "+POut.Long  (orthoCase.SecUserNumEntry)+", "
				//SecDateTEdit can only be set by MySQL
				+"IsActive          =  "+POut.Bool  (orthoCase.IsActive)+", "
				+"FeeInsSecondary   = '"+POut.Double(orthoCase.FeeInsSecondary)+"' "
				+"WHERE OrthoCaseNum = "+POut.Long(orthoCase.OrthoCaseNum);
			Db.NonQ(command);
		}

		///<summary>Updates one OrthoCase in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(OrthoCase orthoCase,OrthoCase oldOrthoCase) {
			string command="";
			if(orthoCase.PatNum != oldOrthoCase.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(orthoCase.PatNum)+"";
			}
			if(orthoCase.ProvNum != oldOrthoCase.ProvNum) {
				if(command!="") { command+=",";}
				command+="ProvNum = "+POut.Long(orthoCase.ProvNum)+"";
			}
			if(orthoCase.ClinicNum != oldOrthoCase.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(orthoCase.ClinicNum)+"";
			}
			if(orthoCase.Fee != oldOrthoCase.Fee) {
				if(command!="") { command+=",";}
				command+="Fee = '"+POut.Double(orthoCase.Fee)+"'";
			}
			if(orthoCase.FeeInsPrimary != oldOrthoCase.FeeInsPrimary) {
				if(command!="") { command+=",";}
				command+="FeeInsPrimary = '"+POut.Double(orthoCase.FeeInsPrimary)+"'";
			}
			if(orthoCase.FeePat != oldOrthoCase.FeePat) {
				if(command!="") { command+=",";}
				command+="FeePat = '"+POut.Double(orthoCase.FeePat)+"'";
			}
			if(orthoCase.BandingDate.Date != oldOrthoCase.BandingDate.Date) {
				if(command!="") { command+=",";}
				command+="BandingDate = "+POut.Date(orthoCase.BandingDate)+"";
			}
			if(orthoCase.DebondDate.Date != oldOrthoCase.DebondDate.Date) {
				if(command!="") { command+=",";}
				command+="DebondDate = "+POut.Date(orthoCase.DebondDate)+"";
			}
			if(orthoCase.DebondDateExpected.Date != oldOrthoCase.DebondDateExpected.Date) {
				if(command!="") { command+=",";}
				command+="DebondDateExpected = "+POut.Date(orthoCase.DebondDateExpected)+"";
			}
			if(orthoCase.IsTransfer != oldOrthoCase.IsTransfer) {
				if(command!="") { command+=",";}
				command+="IsTransfer = "+POut.Bool(orthoCase.IsTransfer)+"";
			}
			if(orthoCase.OrthoType != oldOrthoCase.OrthoType) {
				if(command!="") { command+=",";}
				command+="OrthoType = "+POut.Long(orthoCase.OrthoType)+"";
			}
			//SecDateTEntry not allowed to change
			if(orthoCase.SecUserNumEntry != oldOrthoCase.SecUserNumEntry) {
				if(command!="") { command+=",";}
				command+="SecUserNumEntry = "+POut.Long(orthoCase.SecUserNumEntry)+"";
			}
			//SecDateTEdit can only be set by MySQL
			if(orthoCase.IsActive != oldOrthoCase.IsActive) {
				if(command!="") { command+=",";}
				command+="IsActive = "+POut.Bool(orthoCase.IsActive)+"";
			}
			if(orthoCase.FeeInsSecondary != oldOrthoCase.FeeInsSecondary) {
				if(command!="") { command+=",";}
				command+="FeeInsSecondary = '"+POut.Double(orthoCase.FeeInsSecondary)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE orthocase SET "+command
				+" WHERE OrthoCaseNum = "+POut.Long(orthoCase.OrthoCaseNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(OrthoCase,OrthoCase) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(OrthoCase orthoCase,OrthoCase oldOrthoCase) {
			if(orthoCase.PatNum != oldOrthoCase.PatNum) {
				return true;
			}
			if(orthoCase.ProvNum != oldOrthoCase.ProvNum) {
				return true;
			}
			if(orthoCase.ClinicNum != oldOrthoCase.ClinicNum) {
				return true;
			}
			if(orthoCase.Fee != oldOrthoCase.Fee) {
				return true;
			}
			if(orthoCase.FeeInsPrimary != oldOrthoCase.FeeInsPrimary) {
				return true;
			}
			if(orthoCase.FeePat != oldOrthoCase.FeePat) {
				return true;
			}
			if(orthoCase.BandingDate.Date != oldOrthoCase.BandingDate.Date) {
				return true;
			}
			if(orthoCase.DebondDate.Date != oldOrthoCase.DebondDate.Date) {
				return true;
			}
			if(orthoCase.DebondDateExpected.Date != oldOrthoCase.DebondDateExpected.Date) {
				return true;
			}
			if(orthoCase.IsTransfer != oldOrthoCase.IsTransfer) {
				return true;
			}
			if(orthoCase.OrthoType != oldOrthoCase.OrthoType) {
				return true;
			}
			//SecDateTEntry not allowed to change
			if(orthoCase.SecUserNumEntry != oldOrthoCase.SecUserNumEntry) {
				return true;
			}
			//SecDateTEdit can only be set by MySQL
			if(orthoCase.IsActive != oldOrthoCase.IsActive) {
				return true;
			}
			if(orthoCase.FeeInsSecondary != oldOrthoCase.FeeInsSecondary) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one OrthoCase from the database.</summary>
		public static void Delete(long orthoCaseNum) {
			string command="DELETE FROM orthocase "
				+"WHERE OrthoCaseNum = "+POut.Long(orthoCaseNum);
			Db.NonQ(command);
		}

	}
}