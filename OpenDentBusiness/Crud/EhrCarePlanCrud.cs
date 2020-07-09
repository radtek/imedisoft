//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class EhrCarePlanCrud {
		///<summary>Gets one EhrCarePlan object from the database using the primary key.  Returns null if not found.</summary>
		public static EhrCarePlan SelectOne(long ehrCarePlanNum) {
			string command="SELECT * FROM ehrcareplan "
				+"WHERE EhrCarePlanNum = "+POut.Long(ehrCarePlanNum);
			List<EhrCarePlan> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EhrCarePlan object from the database using a query.</summary>
		public static EhrCarePlan SelectOne(string command) {

			List<EhrCarePlan> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EhrCarePlan objects from the database using a query.</summary>
		public static List<EhrCarePlan> SelectMany(string command) {

			List<EhrCarePlan> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EhrCarePlan> TableToList(DataTable table) {
			List<EhrCarePlan> retVal=new List<EhrCarePlan>();
			EhrCarePlan ehrCarePlan;
			foreach(DataRow row in table.Rows) {
				ehrCarePlan=new EhrCarePlan();
				ehrCarePlan.EhrCarePlanNum = PIn.Long  (row["EhrCarePlanNum"].ToString());
				ehrCarePlan.PatNum         = PIn.Long  (row["PatNum"].ToString());
				ehrCarePlan.SnomedEducation= PIn.String(row["SnomedEducation"].ToString());
				ehrCarePlan.Instructions   = PIn.String(row["Instructions"].ToString());
				ehrCarePlan.DatePlanned    = PIn.Date  (row["DatePlanned"].ToString());
				retVal.Add(ehrCarePlan);
			}
			return retVal;
		}

		///<summary>Converts a list of EhrCarePlan into a DataTable.</summary>
		public static DataTable ListToTable(List<EhrCarePlan> listEhrCarePlans,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="EhrCarePlan";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("EhrCarePlanNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("SnomedEducation");
			table.Columns.Add("Instructions");
			table.Columns.Add("DatePlanned");
			foreach(EhrCarePlan ehrCarePlan in listEhrCarePlans) {
				table.Rows.Add(new object[] {
					POut.Long  (ehrCarePlan.EhrCarePlanNum),
					POut.Long  (ehrCarePlan.PatNum),
					            ehrCarePlan.SnomedEducation,
					            ehrCarePlan.Instructions,
					POut.DateT (ehrCarePlan.DatePlanned,false),
				});
			}
			return table;
		}

		///<summary>Inserts one EhrCarePlan into the database.  Returns the new priKey.</summary>
		public static long Insert(EhrCarePlan ehrCarePlan) {
			return Insert(ehrCarePlan,false);
		}

		///<summary>Inserts one EhrCarePlan into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EhrCarePlan ehrCarePlan,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				ehrCarePlan.EhrCarePlanNum=ReplicationServers.GetKey("ehrcareplan","EhrCarePlanNum");
			}
			string command="INSERT INTO ehrcareplan (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EhrCarePlanNum,";
			}
			command+="PatNum,SnomedEducation,Instructions,DatePlanned) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(ehrCarePlan.EhrCarePlanNum)+",";
			}
			command+=
				     POut.Long  (ehrCarePlan.PatNum)+","
				+"'"+POut.String(ehrCarePlan.SnomedEducation)+"',"
				+"'"+POut.String(ehrCarePlan.Instructions)+"',"
				+    POut.Date  (ehrCarePlan.DatePlanned)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				ehrCarePlan.EhrCarePlanNum=Db.NonQ(command,true,"EhrCarePlanNum","ehrCarePlan");
			}
			return ehrCarePlan.EhrCarePlanNum;
		}

		///<summary>Inserts one EhrCarePlan into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EhrCarePlan ehrCarePlan) {
			return InsertNoCache(ehrCarePlan,false);
		}

		///<summary>Inserts one EhrCarePlan into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EhrCarePlan ehrCarePlan,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO ehrcareplan (";
			if(!useExistingPK && isRandomKeys) {
				ehrCarePlan.EhrCarePlanNum=ReplicationServers.GetKeyNoCache("ehrcareplan","EhrCarePlanNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="EhrCarePlanNum,";
			}
			command+="PatNum,SnomedEducation,Instructions,DatePlanned) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(ehrCarePlan.EhrCarePlanNum)+",";
			}
			command+=
				     POut.Long  (ehrCarePlan.PatNum)+","
				+"'"+POut.String(ehrCarePlan.SnomedEducation)+"',"
				+"'"+POut.String(ehrCarePlan.Instructions)+"',"
				+    POut.Date  (ehrCarePlan.DatePlanned)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				ehrCarePlan.EhrCarePlanNum=Db.NonQ(command,true,"EhrCarePlanNum","ehrCarePlan");
			}
			return ehrCarePlan.EhrCarePlanNum;
		}

		///<summary>Updates one EhrCarePlan in the database.</summary>
		public static void Update(EhrCarePlan ehrCarePlan) {
			string command="UPDATE ehrcareplan SET "
				+"PatNum         =  "+POut.Long  (ehrCarePlan.PatNum)+", "
				+"SnomedEducation= '"+POut.String(ehrCarePlan.SnomedEducation)+"', "
				+"Instructions   = '"+POut.String(ehrCarePlan.Instructions)+"', "
				+"DatePlanned    =  "+POut.Date  (ehrCarePlan.DatePlanned)+" "
				+"WHERE EhrCarePlanNum = "+POut.Long(ehrCarePlan.EhrCarePlanNum);
			Db.NonQ(command);
		}

		///<summary>Updates one EhrCarePlan in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EhrCarePlan ehrCarePlan,EhrCarePlan oldEhrCarePlan) {
			string command="";
			if(ehrCarePlan.PatNum != oldEhrCarePlan.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(ehrCarePlan.PatNum)+"";
			}
			if(ehrCarePlan.SnomedEducation != oldEhrCarePlan.SnomedEducation) {
				if(command!="") { command+=",";}
				command+="SnomedEducation = '"+POut.String(ehrCarePlan.SnomedEducation)+"'";
			}
			if(ehrCarePlan.Instructions != oldEhrCarePlan.Instructions) {
				if(command!="") { command+=",";}
				command+="Instructions = '"+POut.String(ehrCarePlan.Instructions)+"'";
			}
			if(ehrCarePlan.DatePlanned.Date != oldEhrCarePlan.DatePlanned.Date) {
				if(command!="") { command+=",";}
				command+="DatePlanned = "+POut.Date(ehrCarePlan.DatePlanned)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE ehrcareplan SET "+command
				+" WHERE EhrCarePlanNum = "+POut.Long(ehrCarePlan.EhrCarePlanNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(EhrCarePlan,EhrCarePlan) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(EhrCarePlan ehrCarePlan,EhrCarePlan oldEhrCarePlan) {
			if(ehrCarePlan.PatNum != oldEhrCarePlan.PatNum) {
				return true;
			}
			if(ehrCarePlan.SnomedEducation != oldEhrCarePlan.SnomedEducation) {
				return true;
			}
			if(ehrCarePlan.Instructions != oldEhrCarePlan.Instructions) {
				return true;
			}
			if(ehrCarePlan.DatePlanned.Date != oldEhrCarePlan.DatePlanned.Date) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one EhrCarePlan from the database.</summary>
		public static void Delete(long ehrCarePlanNum) {
			string command="DELETE FROM ehrcareplan "
				+"WHERE EhrCarePlanNum = "+POut.Long(ehrCarePlanNum);
			Db.NonQ(command);
		}

	}
}