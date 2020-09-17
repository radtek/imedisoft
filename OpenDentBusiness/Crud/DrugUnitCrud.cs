//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class DrugUnitCrud {
		///<summary>Gets one DrugUnit object from the database using the primary key.  Returns null if not found.</summary>
		public static DrugUnit SelectOne(long drugUnitNum) {
			string command="SELECT * FROM drugunit "
				+"WHERE DrugUnitNum = "+POut.Long(drugUnitNum);
			List<DrugUnit> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one DrugUnit object from the database using a query.</summary>
		public static DrugUnit SelectOne(string command) {

			List<DrugUnit> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of DrugUnit objects from the database using a query.</summary>
		public static List<DrugUnit> SelectMany(string command) {

			List<DrugUnit> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<DrugUnit> TableToList(DataTable table) {
			List<DrugUnit> retVal=new List<DrugUnit>();
			DrugUnit drugUnit;
			foreach(DataRow row in table.Rows) {
				drugUnit=new DrugUnit();
				drugUnit.Id   = PIn.Long  (row["DrugUnitNum"].ToString());
				drugUnit.UnitIdentifier= PIn.String(row["UnitIdentifier"].ToString());
				drugUnit.UnitText      = PIn.String(row["UnitText"].ToString());
				retVal.Add(drugUnit);
			}
			return retVal;
		}

		///<summary>Converts a list of DrugUnit into a DataTable.</summary>
		public static DataTable ListToTable(List<DrugUnit> listDrugUnits,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="DrugUnit";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("DrugUnitNum");
			table.Columns.Add("UnitIdentifier");
			table.Columns.Add("UnitText");
			foreach(DrugUnit drugUnit in listDrugUnits) {
				table.Rows.Add(new object[] {
					POut.Long  (drugUnit.Id),
					            drugUnit.UnitIdentifier,
					            drugUnit.UnitText,
				});
			}
			return table;
		}

		///<summary>Inserts one DrugUnit into the database.  Returns the new priKey.</summary>
		public static long Insert(DrugUnit drugUnit) {
			return Insert(drugUnit,false);
		}

		///<summary>Inserts one DrugUnit into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(DrugUnit drugUnit,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				drugUnit.Id=ReplicationServers.GetKey("drugunit","DrugUnitNum");
			}
			string command="INSERT INTO drugunit (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="DrugUnitNum,";
			}
			command+="UnitIdentifier,UnitText) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(drugUnit.Id)+",";
			}
			command+=
				 "'"+POut.String(drugUnit.UnitIdentifier)+"',"
				+"'"+POut.String(drugUnit.UnitText)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				drugUnit.Id=Database.ExecuteInsert(command);
			}
			return drugUnit.Id;
		}

		///<summary>Inserts one DrugUnit into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(DrugUnit drugUnit) {
			return InsertNoCache(drugUnit,false);
		}

		///<summary>Inserts one DrugUnit into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(DrugUnit drugUnit,bool useExistingPK) {
			
			string command="INSERT INTO drugunit (";
			if(!useExistingPK) {
				drugUnit.Id=ReplicationServers.GetKeyNoCache("drugunit","DrugUnitNum");
			}
			if(useExistingPK) {
				command+="DrugUnitNum,";
			}
			command+="UnitIdentifier,UnitText) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(drugUnit.Id)+",";
			}
			command+=
				 "'"+POut.String(drugUnit.UnitIdentifier)+"',"
				+"'"+POut.String(drugUnit.UnitText)+"')";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				drugUnit.Id=Database.ExecuteInsert(command);
			}
			return drugUnit.Id;
		}

		///<summary>Updates one DrugUnit in the database.</summary>
		public static void Update(DrugUnit drugUnit) {
			string command="UPDATE drugunit SET "
				+"UnitIdentifier= '"+POut.String(drugUnit.UnitIdentifier)+"', "
				+"UnitText      = '"+POut.String(drugUnit.UnitText)+"' "
				+"WHERE DrugUnitNum = "+POut.Long(drugUnit.Id);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one DrugUnit in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(DrugUnit drugUnit,DrugUnit oldDrugUnit) {
			string command="";
			if(drugUnit.UnitIdentifier != oldDrugUnit.UnitIdentifier) {
				if(command!="") { command+=",";}
				command+="UnitIdentifier = '"+POut.String(drugUnit.UnitIdentifier)+"'";
			}
			if(drugUnit.UnitText != oldDrugUnit.UnitText) {
				if(command!="") { command+=",";}
				command+="UnitText = '"+POut.String(drugUnit.UnitText)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE drugunit SET "+command
				+" WHERE DrugUnitNum = "+POut.Long(drugUnit.Id);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(DrugUnit,DrugUnit) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(DrugUnit drugUnit,DrugUnit oldDrugUnit) {
			if(drugUnit.UnitIdentifier != oldDrugUnit.UnitIdentifier) {
				return true;
			}
			if(drugUnit.UnitText != oldDrugUnit.UnitText) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one DrugUnit from the database.</summary>
		public static void Delete(long drugUnitNum) {
			string command="DELETE FROM drugunit "
				+"WHERE DrugUnitNum = "+POut.Long(drugUnitNum);
			Database.ExecuteNonQuery(command);
		}

	}
}