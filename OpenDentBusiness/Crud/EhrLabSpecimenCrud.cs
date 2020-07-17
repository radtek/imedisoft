//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using EhrLaboratories;

namespace OpenDentBusiness.Crud{
	public class EhrLabSpecimenCrud {
		///<summary>Gets one EhrLabSpecimen object from the database using the primary key.  Returns null if not found.</summary>
		public static EhrLabSpecimen SelectOne(long ehrLabSpecimenNum) {
			string command="SELECT * FROM ehrlabspecimen "
				+"WHERE EhrLabSpecimenNum = "+POut.Long(ehrLabSpecimenNum);
			List<EhrLabSpecimen> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EhrLabSpecimen object from the database using a query.</summary>
		public static EhrLabSpecimen SelectOne(string command) {

			List<EhrLabSpecimen> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EhrLabSpecimen objects from the database using a query.</summary>
		public static List<EhrLabSpecimen> SelectMany(string command) {

			List<EhrLabSpecimen> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EhrLabSpecimen> TableToList(DataTable table) {
			List<EhrLabSpecimen> retVal=new List<EhrLabSpecimen>();
			EhrLabSpecimen ehrLabSpecimen;
			foreach(DataRow row in table.Rows) {
				ehrLabSpecimen=new EhrLabSpecimen();
				ehrLabSpecimen.EhrLabSpecimenNum            = PIn.Long  (row["EhrLabSpecimenNum"].ToString());
				ehrLabSpecimen.EhrLabNum                    = PIn.Long  (row["EhrLabNum"].ToString());
				ehrLabSpecimen.SetIdSPM                     = PIn.Long  (row["SetIdSPM"].ToString());
				ehrLabSpecimen.SpecimenTypeID               = PIn.String(row["SpecimenTypeID"].ToString());
				ehrLabSpecimen.SpecimenTypeText             = PIn.String(row["SpecimenTypeText"].ToString());
				ehrLabSpecimen.SpecimenTypeCodeSystemName   = PIn.String(row["SpecimenTypeCodeSystemName"].ToString());
				ehrLabSpecimen.SpecimenTypeIDAlt            = PIn.String(row["SpecimenTypeIDAlt"].ToString());
				ehrLabSpecimen.SpecimenTypeTextAlt          = PIn.String(row["SpecimenTypeTextAlt"].ToString());
				ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt= PIn.String(row["SpecimenTypeCodeSystemNameAlt"].ToString());
				ehrLabSpecimen.SpecimenTypeTextOriginal     = PIn.String(row["SpecimenTypeTextOriginal"].ToString());
				ehrLabSpecimen.CollectionDateTimeStart      = PIn.String(row["CollectionDateTimeStart"].ToString());
				ehrLabSpecimen.CollectionDateTimeEnd        = PIn.String(row["CollectionDateTimeEnd"].ToString());
				retVal.Add(ehrLabSpecimen);
			}
			return retVal;
		}

		///<summary>Converts a list of EhrLabSpecimen into a DataTable.</summary>
		public static DataTable ListToTable(List<EhrLabSpecimen> listEhrLabSpecimens,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="EhrLabSpecimen";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("EhrLabSpecimenNum");
			table.Columns.Add("EhrLabNum");
			table.Columns.Add("SetIdSPM");
			table.Columns.Add("SpecimenTypeID");
			table.Columns.Add("SpecimenTypeText");
			table.Columns.Add("SpecimenTypeCodeSystemName");
			table.Columns.Add("SpecimenTypeIDAlt");
			table.Columns.Add("SpecimenTypeTextAlt");
			table.Columns.Add("SpecimenTypeCodeSystemNameAlt");
			table.Columns.Add("SpecimenTypeTextOriginal");
			table.Columns.Add("CollectionDateTimeStart");
			table.Columns.Add("CollectionDateTimeEnd");
			foreach(EhrLabSpecimen ehrLabSpecimen in listEhrLabSpecimens) {
				table.Rows.Add(new object[] {
					POut.Long  (ehrLabSpecimen.EhrLabSpecimenNum),
					POut.Long  (ehrLabSpecimen.EhrLabNum),
					POut.Long  (ehrLabSpecimen.SetIdSPM),
					            ehrLabSpecimen.SpecimenTypeID,
					            ehrLabSpecimen.SpecimenTypeText,
					            ehrLabSpecimen.SpecimenTypeCodeSystemName,
					            ehrLabSpecimen.SpecimenTypeIDAlt,
					            ehrLabSpecimen.SpecimenTypeTextAlt,
					            ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt,
					            ehrLabSpecimen.SpecimenTypeTextOriginal,
					            ehrLabSpecimen.CollectionDateTimeStart,
					            ehrLabSpecimen.CollectionDateTimeEnd,
				});
			}
			return table;
		}

		///<summary>Inserts one EhrLabSpecimen into the database.  Returns the new priKey.</summary>
		public static long Insert(EhrLabSpecimen ehrLabSpecimen) {
			return Insert(ehrLabSpecimen,false);
		}

		///<summary>Inserts one EhrLabSpecimen into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EhrLabSpecimen ehrLabSpecimen,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				ehrLabSpecimen.EhrLabSpecimenNum=ReplicationServers.GetKey("ehrlabspecimen","EhrLabSpecimenNum");
			}
			string command="INSERT INTO ehrlabspecimen (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EhrLabSpecimenNum,";
			}
			command+="EhrLabNum,SetIdSPM,SpecimenTypeID,SpecimenTypeText,SpecimenTypeCodeSystemName,SpecimenTypeIDAlt,SpecimenTypeTextAlt,SpecimenTypeCodeSystemNameAlt,SpecimenTypeTextOriginal,CollectionDateTimeStart,CollectionDateTimeEnd) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(ehrLabSpecimen.EhrLabSpecimenNum)+",";
			}
			command+=
				     POut.Long  (ehrLabSpecimen.EhrLabNum)+","
				+    POut.Long  (ehrLabSpecimen.SetIdSPM)+","
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeID)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeText)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemName)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeIDAlt)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeTextAlt)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeTextOriginal)+"',"
				+"'"+POut.String(ehrLabSpecimen.CollectionDateTimeStart)+"',"
				+"'"+POut.String(ehrLabSpecimen.CollectionDateTimeEnd)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				ehrLabSpecimen.EhrLabSpecimenNum=Database.ExecuteInsert(command);
			}
			return ehrLabSpecimen.EhrLabSpecimenNum;
		}

		///<summary>Inserts one EhrLabSpecimen into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EhrLabSpecimen ehrLabSpecimen) {
			return InsertNoCache(ehrLabSpecimen,false);
		}

		///<summary>Inserts one EhrLabSpecimen into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EhrLabSpecimen ehrLabSpecimen,bool useExistingPK) {
			
			string command="INSERT INTO ehrlabspecimen (";
			if(!useExistingPK) {
				ehrLabSpecimen.EhrLabSpecimenNum=ReplicationServers.GetKeyNoCache("ehrlabspecimen","EhrLabSpecimenNum");
			}
			if(useExistingPK) {
				command+="EhrLabSpecimenNum,";
			}
			command+="EhrLabNum,SetIdSPM,SpecimenTypeID,SpecimenTypeText,SpecimenTypeCodeSystemName,SpecimenTypeIDAlt,SpecimenTypeTextAlt,SpecimenTypeCodeSystemNameAlt,SpecimenTypeTextOriginal,CollectionDateTimeStart,CollectionDateTimeEnd) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(ehrLabSpecimen.EhrLabSpecimenNum)+",";
			}
			command+=
				     POut.Long  (ehrLabSpecimen.EhrLabNum)+","
				+    POut.Long  (ehrLabSpecimen.SetIdSPM)+","
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeID)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeText)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemName)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeIDAlt)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeTextAlt)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt)+"',"
				+"'"+POut.String(ehrLabSpecimen.SpecimenTypeTextOriginal)+"',"
				+"'"+POut.String(ehrLabSpecimen.CollectionDateTimeStart)+"',"
				+"'"+POut.String(ehrLabSpecimen.CollectionDateTimeEnd)+"')";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				ehrLabSpecimen.EhrLabSpecimenNum=Database.ExecuteInsert(command);
			}
			return ehrLabSpecimen.EhrLabSpecimenNum;
		}

		///<summary>Updates one EhrLabSpecimen in the database.</summary>
		public static void Update(EhrLabSpecimen ehrLabSpecimen) {
			string command="UPDATE ehrlabspecimen SET "
				+"EhrLabNum                    =  "+POut.Long  (ehrLabSpecimen.EhrLabNum)+", "
				+"SetIdSPM                     =  "+POut.Long  (ehrLabSpecimen.SetIdSPM)+", "
				+"SpecimenTypeID               = '"+POut.String(ehrLabSpecimen.SpecimenTypeID)+"', "
				+"SpecimenTypeText             = '"+POut.String(ehrLabSpecimen.SpecimenTypeText)+"', "
				+"SpecimenTypeCodeSystemName   = '"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemName)+"', "
				+"SpecimenTypeIDAlt            = '"+POut.String(ehrLabSpecimen.SpecimenTypeIDAlt)+"', "
				+"SpecimenTypeTextAlt          = '"+POut.String(ehrLabSpecimen.SpecimenTypeTextAlt)+"', "
				+"SpecimenTypeCodeSystemNameAlt= '"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt)+"', "
				+"SpecimenTypeTextOriginal     = '"+POut.String(ehrLabSpecimen.SpecimenTypeTextOriginal)+"', "
				+"CollectionDateTimeStart      = '"+POut.String(ehrLabSpecimen.CollectionDateTimeStart)+"', "
				+"CollectionDateTimeEnd        = '"+POut.String(ehrLabSpecimen.CollectionDateTimeEnd)+"' "
				+"WHERE EhrLabSpecimenNum = "+POut.Long(ehrLabSpecimen.EhrLabSpecimenNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one EhrLabSpecimen in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EhrLabSpecimen ehrLabSpecimen,EhrLabSpecimen oldEhrLabSpecimen) {
			string command="";
			if(ehrLabSpecimen.EhrLabNum != oldEhrLabSpecimen.EhrLabNum) {
				if(command!="") { command+=",";}
				command+="EhrLabNum = "+POut.Long(ehrLabSpecimen.EhrLabNum)+"";
			}
			if(ehrLabSpecimen.SetIdSPM != oldEhrLabSpecimen.SetIdSPM) {
				if(command!="") { command+=",";}
				command+="SetIdSPM = "+POut.Long(ehrLabSpecimen.SetIdSPM)+"";
			}
			if(ehrLabSpecimen.SpecimenTypeID != oldEhrLabSpecimen.SpecimenTypeID) {
				if(command!="") { command+=",";}
				command+="SpecimenTypeID = '"+POut.String(ehrLabSpecimen.SpecimenTypeID)+"'";
			}
			if(ehrLabSpecimen.SpecimenTypeText != oldEhrLabSpecimen.SpecimenTypeText) {
				if(command!="") { command+=",";}
				command+="SpecimenTypeText = '"+POut.String(ehrLabSpecimen.SpecimenTypeText)+"'";
			}
			if(ehrLabSpecimen.SpecimenTypeCodeSystemName != oldEhrLabSpecimen.SpecimenTypeCodeSystemName) {
				if(command!="") { command+=",";}
				command+="SpecimenTypeCodeSystemName = '"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemName)+"'";
			}
			if(ehrLabSpecimen.SpecimenTypeIDAlt != oldEhrLabSpecimen.SpecimenTypeIDAlt) {
				if(command!="") { command+=",";}
				command+="SpecimenTypeIDAlt = '"+POut.String(ehrLabSpecimen.SpecimenTypeIDAlt)+"'";
			}
			if(ehrLabSpecimen.SpecimenTypeTextAlt != oldEhrLabSpecimen.SpecimenTypeTextAlt) {
				if(command!="") { command+=",";}
				command+="SpecimenTypeTextAlt = '"+POut.String(ehrLabSpecimen.SpecimenTypeTextAlt)+"'";
			}
			if(ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt != oldEhrLabSpecimen.SpecimenTypeCodeSystemNameAlt) {
				if(command!="") { command+=",";}
				command+="SpecimenTypeCodeSystemNameAlt = '"+POut.String(ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt)+"'";
			}
			if(ehrLabSpecimen.SpecimenTypeTextOriginal != oldEhrLabSpecimen.SpecimenTypeTextOriginal) {
				if(command!="") { command+=",";}
				command+="SpecimenTypeTextOriginal = '"+POut.String(ehrLabSpecimen.SpecimenTypeTextOriginal)+"'";
			}
			if(ehrLabSpecimen.CollectionDateTimeStart != oldEhrLabSpecimen.CollectionDateTimeStart) {
				if(command!="") { command+=",";}
				command+="CollectionDateTimeStart = '"+POut.String(ehrLabSpecimen.CollectionDateTimeStart)+"'";
			}
			if(ehrLabSpecimen.CollectionDateTimeEnd != oldEhrLabSpecimen.CollectionDateTimeEnd) {
				if(command!="") { command+=",";}
				command+="CollectionDateTimeEnd = '"+POut.String(ehrLabSpecimen.CollectionDateTimeEnd)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE ehrlabspecimen SET "+command
				+" WHERE EhrLabSpecimenNum = "+POut.Long(ehrLabSpecimen.EhrLabSpecimenNum);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(EhrLabSpecimen,EhrLabSpecimen) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(EhrLabSpecimen ehrLabSpecimen,EhrLabSpecimen oldEhrLabSpecimen) {
			if(ehrLabSpecimen.EhrLabNum != oldEhrLabSpecimen.EhrLabNum) {
				return true;
			}
			if(ehrLabSpecimen.SetIdSPM != oldEhrLabSpecimen.SetIdSPM) {
				return true;
			}
			if(ehrLabSpecimen.SpecimenTypeID != oldEhrLabSpecimen.SpecimenTypeID) {
				return true;
			}
			if(ehrLabSpecimen.SpecimenTypeText != oldEhrLabSpecimen.SpecimenTypeText) {
				return true;
			}
			if(ehrLabSpecimen.SpecimenTypeCodeSystemName != oldEhrLabSpecimen.SpecimenTypeCodeSystemName) {
				return true;
			}
			if(ehrLabSpecimen.SpecimenTypeIDAlt != oldEhrLabSpecimen.SpecimenTypeIDAlt) {
				return true;
			}
			if(ehrLabSpecimen.SpecimenTypeTextAlt != oldEhrLabSpecimen.SpecimenTypeTextAlt) {
				return true;
			}
			if(ehrLabSpecimen.SpecimenTypeCodeSystemNameAlt != oldEhrLabSpecimen.SpecimenTypeCodeSystemNameAlt) {
				return true;
			}
			if(ehrLabSpecimen.SpecimenTypeTextOriginal != oldEhrLabSpecimen.SpecimenTypeTextOriginal) {
				return true;
			}
			if(ehrLabSpecimen.CollectionDateTimeStart != oldEhrLabSpecimen.CollectionDateTimeStart) {
				return true;
			}
			if(ehrLabSpecimen.CollectionDateTimeEnd != oldEhrLabSpecimen.CollectionDateTimeEnd) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one EhrLabSpecimen from the database.</summary>
		public static void Delete(long ehrLabSpecimenNum) {
			string command="DELETE FROM ehrlabspecimen "
				+"WHERE EhrLabSpecimenNum = "+POut.Long(ehrLabSpecimenNum);
			Database.ExecuteNonQuery(command);
		}

	}
}