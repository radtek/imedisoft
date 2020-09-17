//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class FeeSchedGroupCrud {
		///<summary>Gets one FeeSchedGroup object from the database using the primary key.  Returns null if not found.</summary>
		public static FeeScheduleGroup SelectOne(long feeSchedGroupNum) {
			string command="SELECT * FROM feeschedgroup "
				+"WHERE FeeSchedGroupNum = "+POut.Long(feeSchedGroupNum);
			List<FeeScheduleGroup> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one FeeSchedGroup object from the database using a query.</summary>
		public static FeeScheduleGroup SelectOne(string command) {

			List<FeeScheduleGroup> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of FeeSchedGroup objects from the database using a query.</summary>
		public static List<FeeScheduleGroup> SelectMany(string command) {

			List<FeeScheduleGroup> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<FeeScheduleGroup> TableToList(DataTable table) {
			List<FeeScheduleGroup> retVal=new List<FeeScheduleGroup>();
			FeeScheduleGroup feeSchedGroup;
			foreach(DataRow row in table.Rows) {
				feeSchedGroup=new FeeScheduleGroup();
				feeSchedGroup.Id= PIn.Long  (row["FeeSchedGroupNum"].ToString());
				feeSchedGroup.Description     = PIn.String(row["Description"].ToString());
				feeSchedGroup.FeeScheduleId     = PIn.Long  (row["FeeSchedNum"].ToString());
				feeSchedGroup.ClinicIds      = PIn.String(row["ClinicNums"].ToString());
				retVal.Add(feeSchedGroup);
			}
			return retVal;
		}

		///<summary>Converts a list of FeeSchedGroup into a DataTable.</summary>
		public static DataTable ListToTable(List<FeeScheduleGroup> listFeeSchedGroups,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="FeeSchedGroup";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("FeeSchedGroupNum");
			table.Columns.Add("Description");
			table.Columns.Add("FeeSchedNum");
			table.Columns.Add("ClinicNums");
			foreach(FeeScheduleGroup feeSchedGroup in listFeeSchedGroups) {
				table.Rows.Add(new object[] {
					POut.Long  (feeSchedGroup.Id),
					            feeSchedGroup.Description,
					POut.Long  (feeSchedGroup.FeeScheduleId),
					            feeSchedGroup.ClinicIds,
				});
			}
			return table;
		}

		///<summary>Inserts one FeeSchedGroup into the database.  Returns the new priKey.</summary>
		public static long Insert(FeeScheduleGroup feeSchedGroup) {
			return Insert(feeSchedGroup,false);
		}

		///<summary>Inserts one FeeSchedGroup into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(FeeScheduleGroup feeSchedGroup,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				feeSchedGroup.Id=ReplicationServers.GetKey("feeschedgroup","FeeSchedGroupNum");
			}
			string command="INSERT INTO feeschedgroup (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="FeeSchedGroupNum,";
			}
			command+="Description,FeeSchedNum,ClinicNums) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(feeSchedGroup.Id)+",";
			}
			command+=
				 "'"+POut.String(feeSchedGroup.Description)+"',"
				+    POut.Long  (feeSchedGroup.FeeScheduleId)+","
				+"'"+POut.String(feeSchedGroup.ClinicIds)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				feeSchedGroup.Id=Database.ExecuteInsert(command);
			}
			return feeSchedGroup.Id;
		}

		///<summary>Inserts one FeeSchedGroup into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(FeeScheduleGroup feeSchedGroup) {
			return InsertNoCache(feeSchedGroup,false);
		}

		///<summary>Inserts one FeeSchedGroup into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(FeeScheduleGroup feeSchedGroup,bool useExistingPK) {
			
			string command="INSERT INTO feeschedgroup (";
			if(!useExistingPK) {
				feeSchedGroup.Id=ReplicationServers.GetKeyNoCache("feeschedgroup","FeeSchedGroupNum");
			}
			if(useExistingPK) {
				command+="FeeSchedGroupNum,";
			}
			command+="Description,FeeSchedNum,ClinicNums) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(feeSchedGroup.Id)+",";
			}
			command+=
				 "'"+POut.String(feeSchedGroup.Description)+"',"
				+    POut.Long  (feeSchedGroup.FeeScheduleId)+","
				+"'"+POut.String(feeSchedGroup.ClinicIds)+"')";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				feeSchedGroup.Id=Database.ExecuteInsert(command);
			}
			return feeSchedGroup.Id;
		}

		///<summary>Updates one FeeSchedGroup in the database.</summary>
		public static void Update(FeeScheduleGroup feeSchedGroup) {
			string command="UPDATE feeschedgroup SET "
				+"Description     = '"+POut.String(feeSchedGroup.Description)+"', "
				+"FeeSchedNum     =  "+POut.Long  (feeSchedGroup.FeeScheduleId)+", "
				+"ClinicNums      = '"+POut.String(feeSchedGroup.ClinicIds)+"' "
				+"WHERE FeeSchedGroupNum = "+POut.Long(feeSchedGroup.Id);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one FeeSchedGroup in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(FeeScheduleGroup feeSchedGroup,FeeScheduleGroup oldFeeSchedGroup) {
			string command="";
			if(feeSchedGroup.Description != oldFeeSchedGroup.Description) {
				if(command!="") { command+=",";}
				command+="Description = '"+POut.String(feeSchedGroup.Description)+"'";
			}
			if(feeSchedGroup.FeeScheduleId != oldFeeSchedGroup.FeeScheduleId) {
				if(command!="") { command+=",";}
				command+="FeeSchedNum = "+POut.Long(feeSchedGroup.FeeScheduleId)+"";
			}
			if(feeSchedGroup.ClinicIds != oldFeeSchedGroup.ClinicIds) {
				if(command!="") { command+=",";}
				command+="ClinicNums = '"+POut.String(feeSchedGroup.ClinicIds)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE feeschedgroup SET "+command
				+" WHERE FeeSchedGroupNum = "+POut.Long(feeSchedGroup.Id);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(FeeSchedGroup,FeeSchedGroup) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(FeeScheduleGroup feeSchedGroup,FeeScheduleGroup oldFeeSchedGroup) {
			if(feeSchedGroup.Description != oldFeeSchedGroup.Description) {
				return true;
			}
			if(feeSchedGroup.FeeScheduleId != oldFeeSchedGroup.FeeScheduleId) {
				return true;
			}
			if(feeSchedGroup.ClinicIds != oldFeeSchedGroup.ClinicIds) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one FeeSchedGroup from the database.</summary>
		public static void Delete(long feeSchedGroupNum) {
			string command="DELETE FROM feeschedgroup "
				+"WHERE FeeSchedGroupNum = "+POut.Long(feeSchedGroupNum);
			Database.ExecuteNonQuery(command);
		}

	}
}