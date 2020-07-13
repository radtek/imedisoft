//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class MedLabFacAttachCrud {
		///<summary>Gets one MedLabFacAttach object from the database using the primary key.  Returns null if not found.</summary>
		public static MedLabFacAttach SelectOne(long medLabFacAttachNum) {
			string command="SELECT * FROM medlabfacattach "
				+"WHERE MedLabFacAttachNum = "+POut.Long(medLabFacAttachNum);
			List<MedLabFacAttach> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one MedLabFacAttach object from the database using a query.</summary>
		public static MedLabFacAttach SelectOne(string command) {

			List<MedLabFacAttach> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of MedLabFacAttach objects from the database using a query.</summary>
		public static List<MedLabFacAttach> SelectMany(string command) {

			List<MedLabFacAttach> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<MedLabFacAttach> TableToList(DataTable table) {
			List<MedLabFacAttach> retVal=new List<MedLabFacAttach>();
			MedLabFacAttach medLabFacAttach;
			foreach(DataRow row in table.Rows) {
				medLabFacAttach=new MedLabFacAttach();
				medLabFacAttach.MedLabFacAttachNum= PIn.Long  (row["MedLabFacAttachNum"].ToString());
				medLabFacAttach.MedLabNum         = PIn.Long  (row["MedLabNum"].ToString());
				medLabFacAttach.MedLabResultNum   = PIn.Long  (row["MedLabResultNum"].ToString());
				medLabFacAttach.MedLabFacilityNum = PIn.Long  (row["MedLabFacilityNum"].ToString());
				retVal.Add(medLabFacAttach);
			}
			return retVal;
		}

		///<summary>Converts a list of MedLabFacAttach into a DataTable.</summary>
		public static DataTable ListToTable(List<MedLabFacAttach> listMedLabFacAttachs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="MedLabFacAttach";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("MedLabFacAttachNum");
			table.Columns.Add("MedLabNum");
			table.Columns.Add("MedLabResultNum");
			table.Columns.Add("MedLabFacilityNum");
			foreach(MedLabFacAttach medLabFacAttach in listMedLabFacAttachs) {
				table.Rows.Add(new object[] {
					POut.Long  (medLabFacAttach.MedLabFacAttachNum),
					POut.Long  (medLabFacAttach.MedLabNum),
					POut.Long  (medLabFacAttach.MedLabResultNum),
					POut.Long  (medLabFacAttach.MedLabFacilityNum),
				});
			}
			return table;
		}

		///<summary>Inserts one MedLabFacAttach into the database.  Returns the new priKey.</summary>
		public static long Insert(MedLabFacAttach medLabFacAttach) {
			return Insert(medLabFacAttach,false);
		}

		///<summary>Inserts one MedLabFacAttach into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(MedLabFacAttach medLabFacAttach,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				medLabFacAttach.MedLabFacAttachNum=ReplicationServers.GetKey("medlabfacattach","MedLabFacAttachNum");
			}
			string command="INSERT INTO medlabfacattach (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="MedLabFacAttachNum,";
			}
			command+="MedLabNum,MedLabResultNum,MedLabFacilityNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(medLabFacAttach.MedLabFacAttachNum)+",";
			}
			command+=
				     POut.Long  (medLabFacAttach.MedLabNum)+","
				+    POut.Long  (medLabFacAttach.MedLabResultNum)+","
				+    POut.Long  (medLabFacAttach.MedLabFacilityNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				medLabFacAttach.MedLabFacAttachNum=Db.NonQ(command,true,"MedLabFacAttachNum","medLabFacAttach");
			}
			return medLabFacAttach.MedLabFacAttachNum;
		}

		///<summary>Inserts one MedLabFacAttach into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(MedLabFacAttach medLabFacAttach) {
			return InsertNoCache(medLabFacAttach,false);
		}

		///<summary>Inserts one MedLabFacAttach into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(MedLabFacAttach medLabFacAttach,bool useExistingPK) {
			
			string command="INSERT INTO medlabfacattach (";
			if(!useExistingPK) {
				medLabFacAttach.MedLabFacAttachNum=ReplicationServers.GetKeyNoCache("medlabfacattach","MedLabFacAttachNum");
			}
			if(useExistingPK) {
				command+="MedLabFacAttachNum,";
			}
			command+="MedLabNum,MedLabResultNum,MedLabFacilityNum) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(medLabFacAttach.MedLabFacAttachNum)+",";
			}
			command+=
				     POut.Long  (medLabFacAttach.MedLabNum)+","
				+    POut.Long  (medLabFacAttach.MedLabResultNum)+","
				+    POut.Long  (medLabFacAttach.MedLabFacilityNum)+")";
			if(useExistingPK) {
				Db.NonQ(command);
			}
			else {
				medLabFacAttach.MedLabFacAttachNum=Db.NonQ(command,true,"MedLabFacAttachNum","medLabFacAttach");
			}
			return medLabFacAttach.MedLabFacAttachNum;
		}

		///<summary>Updates one MedLabFacAttach in the database.</summary>
		public static void Update(MedLabFacAttach medLabFacAttach) {
			string command="UPDATE medlabfacattach SET "
				+"MedLabNum         =  "+POut.Long  (medLabFacAttach.MedLabNum)+", "
				+"MedLabResultNum   =  "+POut.Long  (medLabFacAttach.MedLabResultNum)+", "
				+"MedLabFacilityNum =  "+POut.Long  (medLabFacAttach.MedLabFacilityNum)+" "
				+"WHERE MedLabFacAttachNum = "+POut.Long(medLabFacAttach.MedLabFacAttachNum);
			Db.NonQ(command);
		}

		///<summary>Updates one MedLabFacAttach in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(MedLabFacAttach medLabFacAttach,MedLabFacAttach oldMedLabFacAttach) {
			string command="";
			if(medLabFacAttach.MedLabNum != oldMedLabFacAttach.MedLabNum) {
				if(command!="") { command+=",";}
				command+="MedLabNum = "+POut.Long(medLabFacAttach.MedLabNum)+"";
			}
			if(medLabFacAttach.MedLabResultNum != oldMedLabFacAttach.MedLabResultNum) {
				if(command!="") { command+=",";}
				command+="MedLabResultNum = "+POut.Long(medLabFacAttach.MedLabResultNum)+"";
			}
			if(medLabFacAttach.MedLabFacilityNum != oldMedLabFacAttach.MedLabFacilityNum) {
				if(command!="") { command+=",";}
				command+="MedLabFacilityNum = "+POut.Long(medLabFacAttach.MedLabFacilityNum)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE medlabfacattach SET "+command
				+" WHERE MedLabFacAttachNum = "+POut.Long(medLabFacAttach.MedLabFacAttachNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(MedLabFacAttach,MedLabFacAttach) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(MedLabFacAttach medLabFacAttach,MedLabFacAttach oldMedLabFacAttach) {
			if(medLabFacAttach.MedLabNum != oldMedLabFacAttach.MedLabNum) {
				return true;
			}
			if(medLabFacAttach.MedLabResultNum != oldMedLabFacAttach.MedLabResultNum) {
				return true;
			}
			if(medLabFacAttach.MedLabFacilityNum != oldMedLabFacAttach.MedLabFacilityNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one MedLabFacAttach from the database.</summary>
		public static void Delete(long medLabFacAttachNum) {
			string command="DELETE FROM medlabfacattach "
				+"WHERE MedLabFacAttachNum = "+POut.Long(medLabFacAttachNum);
			Db.NonQ(command);
		}

	}
}