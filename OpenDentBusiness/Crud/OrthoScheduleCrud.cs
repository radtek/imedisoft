//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class OrthoScheduleCrud {
		///<summary>Gets one OrthoSchedule object from the database using the primary key.  Returns null if not found.</summary>
		public static OrthoSchedule SelectOne(long orthoScheduleNum) {
			string command="SELECT * FROM orthoschedule "
				+"WHERE OrthoScheduleNum = "+POut.Long(orthoScheduleNum);
			List<OrthoSchedule> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one OrthoSchedule object from the database using a query.</summary>
		public static OrthoSchedule SelectOne(string command) {

			List<OrthoSchedule> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of OrthoSchedule objects from the database using a query.</summary>
		public static List<OrthoSchedule> SelectMany(string command) {

			List<OrthoSchedule> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<OrthoSchedule> TableToList(DataTable table) {
			List<OrthoSchedule> retVal=new List<OrthoSchedule>();
			OrthoSchedule orthoSchedule;
			foreach(DataRow row in table.Rows) {
				orthoSchedule=new OrthoSchedule();
				orthoSchedule.OrthoScheduleNum   = PIn.Long  (row["OrthoScheduleNum"].ToString());
				orthoSchedule.BandingDateOverride= PIn.Date  (row["BandingDateOverride"].ToString());
				orthoSchedule.DebondDateOverride = PIn.Date  (row["DebondDateOverride"].ToString());
				orthoSchedule.BandingAmount      = PIn.Double(row["BandingAmount"].ToString());
				orthoSchedule.VisitAmount        = PIn.Double(row["VisitAmount"].ToString());
				orthoSchedule.DebondAmount       = PIn.Double(row["DebondAmount"].ToString());
				orthoSchedule.IsActive           = PIn.Bool  (row["IsActive"].ToString());
				orthoSchedule.SecDateTEdit       = PIn.Date (row["SecDateTEdit"].ToString());
				retVal.Add(orthoSchedule);
			}
			return retVal;
		}

		///<summary>Converts a list of OrthoSchedule into a DataTable.</summary>
		public static DataTable ListToTable(List<OrthoSchedule> listOrthoSchedules,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="OrthoSchedule";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("OrthoScheduleNum");
			table.Columns.Add("BandingDateOverride");
			table.Columns.Add("DebondDateOverride");
			table.Columns.Add("BandingAmount");
			table.Columns.Add("VisitAmount");
			table.Columns.Add("DebondAmount");
			table.Columns.Add("IsActive");
			table.Columns.Add("SecDateTEdit");
			foreach(OrthoSchedule orthoSchedule in listOrthoSchedules) {
				table.Rows.Add(new object[] {
					POut.Long  (orthoSchedule.OrthoScheduleNum),
					POut.DateT (orthoSchedule.BandingDateOverride,false),
					POut.DateT (orthoSchedule.DebondDateOverride,false),
					POut.Double(orthoSchedule.BandingAmount),
					POut.Double(orthoSchedule.VisitAmount),
					POut.Double(orthoSchedule.DebondAmount),
					POut.Bool  (orthoSchedule.IsActive),
					POut.DateT (orthoSchedule.SecDateTEdit,false),
				});
			}
			return table;
		}

		///<summary>Inserts one OrthoSchedule into the database.  Returns the new priKey.</summary>
		public static long Insert(OrthoSchedule orthoSchedule) {
			return Insert(orthoSchedule,false);
		}

		///<summary>Inserts one OrthoSchedule into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(OrthoSchedule orthoSchedule,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				orthoSchedule.OrthoScheduleNum=ReplicationServers.GetKey("orthoschedule","OrthoScheduleNum");
			}
			string command="INSERT INTO orthoschedule (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="OrthoScheduleNum,";
			}
			command+="BandingDateOverride,DebondDateOverride,BandingAmount,VisitAmount,DebondAmount,IsActive) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(orthoSchedule.OrthoScheduleNum)+",";
			}
			command+=
				     POut.Date  (orthoSchedule.BandingDateOverride)+","
				+    POut.Date  (orthoSchedule.DebondDateOverride)+","
				+"'"+POut.Double(orthoSchedule.BandingAmount)+"',"
				+"'"+POut.Double(orthoSchedule.VisitAmount)+"',"
				+"'"+POut.Double(orthoSchedule.DebondAmount)+"',"
				+    POut.Bool  (orthoSchedule.IsActive)+")";
				//SecDateTEdit can only be set by MySQL
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				orthoSchedule.OrthoScheduleNum=Db.NonQ(command,true,"OrthoScheduleNum","orthoSchedule");
			}
			return orthoSchedule.OrthoScheduleNum;
		}

		///<summary>Inserts one OrthoSchedule into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(OrthoSchedule orthoSchedule) {
			return InsertNoCache(orthoSchedule,false);
		}

		///<summary>Inserts one OrthoSchedule into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(OrthoSchedule orthoSchedule,bool useExistingPK) {
			
			string command="INSERT INTO orthoschedule (";
			if(!useExistingPK) {
				orthoSchedule.OrthoScheduleNum=ReplicationServers.GetKeyNoCache("orthoschedule","OrthoScheduleNum");
			}
			if(useExistingPK) {
				command+="OrthoScheduleNum,";
			}
			command+="BandingDateOverride,DebondDateOverride,BandingAmount,VisitAmount,DebondAmount,IsActive) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(orthoSchedule.OrthoScheduleNum)+",";
			}
			command+=
				     POut.Date  (orthoSchedule.BandingDateOverride)+","
				+    POut.Date  (orthoSchedule.DebondDateOverride)+","
				+"'"+POut.Double(orthoSchedule.BandingAmount)+"',"
				+"'"+POut.Double(orthoSchedule.VisitAmount)+"',"
				+"'"+POut.Double(orthoSchedule.DebondAmount)+"',"
				+    POut.Bool  (orthoSchedule.IsActive)+")";
				//SecDateTEdit can only be set by MySQL
			if(useExistingPK) {
				Db.NonQ(command);
			}
			else {
				orthoSchedule.OrthoScheduleNum=Db.NonQ(command,true,"OrthoScheduleNum","orthoSchedule");
			}
			return orthoSchedule.OrthoScheduleNum;
		}

		///<summary>Updates one OrthoSchedule in the database.</summary>
		public static void Update(OrthoSchedule orthoSchedule) {
			string command="UPDATE orthoschedule SET "
				+"BandingDateOverride=  "+POut.Date  (orthoSchedule.BandingDateOverride)+", "
				+"DebondDateOverride =  "+POut.Date  (orthoSchedule.DebondDateOverride)+", "
				+"BandingAmount      = '"+POut.Double(orthoSchedule.BandingAmount)+"', "
				+"VisitAmount        = '"+POut.Double(orthoSchedule.VisitAmount)+"', "
				+"DebondAmount       = '"+POut.Double(orthoSchedule.DebondAmount)+"', "
				+"IsActive           =  "+POut.Bool  (orthoSchedule.IsActive)+" "
				//SecDateTEdit can only be set by MySQL
				+"WHERE OrthoScheduleNum = "+POut.Long(orthoSchedule.OrthoScheduleNum);
			Db.NonQ(command);
		}

		///<summary>Updates one OrthoSchedule in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(OrthoSchedule orthoSchedule,OrthoSchedule oldOrthoSchedule) {
			string command="";
			if(orthoSchedule.BandingDateOverride.Date != oldOrthoSchedule.BandingDateOverride.Date) {
				if(command!="") { command+=",";}
				command+="BandingDateOverride = "+POut.Date(orthoSchedule.BandingDateOverride)+"";
			}
			if(orthoSchedule.DebondDateOverride.Date != oldOrthoSchedule.DebondDateOverride.Date) {
				if(command!="") { command+=",";}
				command+="DebondDateOverride = "+POut.Date(orthoSchedule.DebondDateOverride)+"";
			}
			if(orthoSchedule.BandingAmount != oldOrthoSchedule.BandingAmount) {
				if(command!="") { command+=",";}
				command+="BandingAmount = '"+POut.Double(orthoSchedule.BandingAmount)+"'";
			}
			if(orthoSchedule.VisitAmount != oldOrthoSchedule.VisitAmount) {
				if(command!="") { command+=",";}
				command+="VisitAmount = '"+POut.Double(orthoSchedule.VisitAmount)+"'";
			}
			if(orthoSchedule.DebondAmount != oldOrthoSchedule.DebondAmount) {
				if(command!="") { command+=",";}
				command+="DebondAmount = '"+POut.Double(orthoSchedule.DebondAmount)+"'";
			}
			if(orthoSchedule.IsActive != oldOrthoSchedule.IsActive) {
				if(command!="") { command+=",";}
				command+="IsActive = "+POut.Bool(orthoSchedule.IsActive)+"";
			}
			//SecDateTEdit can only be set by MySQL
			if(command=="") {
				return false;
			}
			command="UPDATE orthoschedule SET "+command
				+" WHERE OrthoScheduleNum = "+POut.Long(orthoSchedule.OrthoScheduleNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(OrthoSchedule,OrthoSchedule) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(OrthoSchedule orthoSchedule,OrthoSchedule oldOrthoSchedule) {
			if(orthoSchedule.BandingDateOverride.Date != oldOrthoSchedule.BandingDateOverride.Date) {
				return true;
			}
			if(orthoSchedule.DebondDateOverride.Date != oldOrthoSchedule.DebondDateOverride.Date) {
				return true;
			}
			if(orthoSchedule.BandingAmount != oldOrthoSchedule.BandingAmount) {
				return true;
			}
			if(orthoSchedule.VisitAmount != oldOrthoSchedule.VisitAmount) {
				return true;
			}
			if(orthoSchedule.DebondAmount != oldOrthoSchedule.DebondAmount) {
				return true;
			}
			if(orthoSchedule.IsActive != oldOrthoSchedule.IsActive) {
				return true;
			}
			//SecDateTEdit can only be set by MySQL
			return false;
		}

		///<summary>Deletes one OrthoSchedule from the database.</summary>
		public static void Delete(long orthoScheduleNum) {
			string command="DELETE FROM orthoschedule "
				+"WHERE OrthoScheduleNum = "+POut.Long(orthoScheduleNum);
			Db.NonQ(command);
		}

	}
}