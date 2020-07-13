//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class OIDExternalCrud {
		///<summary>Gets one OIDExternal object from the database using the primary key.  Returns null if not found.</summary>
		public static OIDExternal SelectOne(long oIDExternalNum) {
			string command="SELECT * FROM oidexternal "
				+"WHERE OIDExternalNum = "+POut.Long(oIDExternalNum);
			List<OIDExternal> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one OIDExternal object from the database using a query.</summary>
		public static OIDExternal SelectOne(string command) {

			List<OIDExternal> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of OIDExternal objects from the database using a query.</summary>
		public static List<OIDExternal> SelectMany(string command) {

			List<OIDExternal> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<OIDExternal> TableToList(DataTable table) {
			List<OIDExternal> retVal=new List<OIDExternal>();
			OIDExternal oIDExternal;
			foreach(DataRow row in table.Rows) {
				oIDExternal=new OIDExternal();
				oIDExternal.OIDExternalNum= PIn.Long  (row["OIDExternalNum"].ToString());
				string iDType=row["IDType"].ToString();
				if(iDType=="") {
					oIDExternal.IDType      =(OpenDentBusiness.IdentifierType)0;
				}
				else try{
					oIDExternal.IDType      =(OpenDentBusiness.IdentifierType)Enum.Parse(typeof(OpenDentBusiness.IdentifierType),iDType);
				}
				catch{
					oIDExternal.IDType      =(OpenDentBusiness.IdentifierType)0;
				}
				oIDExternal.IDInternal    = PIn.Long  (row["IDInternal"].ToString());
				oIDExternal.IDExternal    = PIn.String(row["IDExternal"].ToString());
				oIDExternal.rootExternal  = PIn.String(row["rootExternal"].ToString());
				retVal.Add(oIDExternal);
			}
			return retVal;
		}

		///<summary>Converts a list of OIDExternal into a DataTable.</summary>
		public static DataTable ListToTable(List<OIDExternal> listOIDExternals,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="OIDExternal";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("OIDExternalNum");
			table.Columns.Add("IDType");
			table.Columns.Add("IDInternal");
			table.Columns.Add("IDExternal");
			table.Columns.Add("rootExternal");
			foreach(OIDExternal oIDExternal in listOIDExternals) {
				table.Rows.Add(new object[] {
					POut.Long  (oIDExternal.OIDExternalNum),
					POut.Int   ((int)oIDExternal.IDType),
					POut.Long  (oIDExternal.IDInternal),
					            oIDExternal.IDExternal,
					            oIDExternal.rootExternal,
				});
			}
			return table;
		}

		///<summary>Inserts one OIDExternal into the database.  Returns the new priKey.</summary>
		public static long Insert(OIDExternal oIDExternal) {
			return Insert(oIDExternal,false);
		}

		///<summary>Inserts one OIDExternal into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(OIDExternal oIDExternal,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				oIDExternal.OIDExternalNum=ReplicationServers.GetKey("oidexternal","OIDExternalNum");
			}
			string command="INSERT INTO oidexternal (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="OIDExternalNum,";
			}
			command+="IDType,IDInternal,IDExternal,rootExternal) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(oIDExternal.OIDExternalNum)+",";
			}
			command+=
				 "'"+POut.String(oIDExternal.IDType.ToString())+"',"
				+    POut.Long  (oIDExternal.IDInternal)+","
				+"'"+POut.String(oIDExternal.IDExternal)+"',"
				+"'"+POut.String(oIDExternal.rootExternal)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				oIDExternal.OIDExternalNum=Db.NonQ(command,true,"OIDExternalNum","oIDExternal");
			}
			return oIDExternal.OIDExternalNum;
		}

		///<summary>Inserts one OIDExternal into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(OIDExternal oIDExternal) {
			return InsertNoCache(oIDExternal,false);
		}

		///<summary>Inserts one OIDExternal into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(OIDExternal oIDExternal,bool useExistingPK) {
			
			string command="INSERT INTO oidexternal (";
			if(!useExistingPK) {
				oIDExternal.OIDExternalNum=ReplicationServers.GetKeyNoCache("oidexternal","OIDExternalNum");
			}
			if(useExistingPK) {
				command+="OIDExternalNum,";
			}
			command+="IDType,IDInternal,IDExternal,rootExternal) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(oIDExternal.OIDExternalNum)+",";
			}
			command+=
				 "'"+POut.String(oIDExternal.IDType.ToString())+"',"
				+    POut.Long  (oIDExternal.IDInternal)+","
				+"'"+POut.String(oIDExternal.IDExternal)+"',"
				+"'"+POut.String(oIDExternal.rootExternal)+"')";
			if(useExistingPK) {
				Db.NonQ(command);
			}
			else {
				oIDExternal.OIDExternalNum=Db.NonQ(command,true,"OIDExternalNum","oIDExternal");
			}
			return oIDExternal.OIDExternalNum;
		}

		///<summary>Updates one OIDExternal in the database.</summary>
		public static void Update(OIDExternal oIDExternal) {
			string command="UPDATE oidexternal SET "
				+"IDType        = '"+POut.String(oIDExternal.IDType.ToString())+"', "
				+"IDInternal    =  "+POut.Long  (oIDExternal.IDInternal)+", "
				+"IDExternal    = '"+POut.String(oIDExternal.IDExternal)+"', "
				+"rootExternal  = '"+POut.String(oIDExternal.rootExternal)+"' "
				+"WHERE OIDExternalNum = "+POut.Long(oIDExternal.OIDExternalNum);
			Db.NonQ(command);
		}

		///<summary>Updates one OIDExternal in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(OIDExternal oIDExternal,OIDExternal oldOIDExternal) {
			string command="";
			if(oIDExternal.IDType != oldOIDExternal.IDType) {
				if(command!="") { command+=",";}
				command+="IDType = '"+POut.String(oIDExternal.IDType.ToString())+"'";
			}
			if(oIDExternal.IDInternal != oldOIDExternal.IDInternal) {
				if(command!="") { command+=",";}
				command+="IDInternal = "+POut.Long(oIDExternal.IDInternal)+"";
			}
			if(oIDExternal.IDExternal != oldOIDExternal.IDExternal) {
				if(command!="") { command+=",";}
				command+="IDExternal = '"+POut.String(oIDExternal.IDExternal)+"'";
			}
			if(oIDExternal.rootExternal != oldOIDExternal.rootExternal) {
				if(command!="") { command+=",";}
				command+="rootExternal = '"+POut.String(oIDExternal.rootExternal)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE oidexternal SET "+command
				+" WHERE OIDExternalNum = "+POut.Long(oIDExternal.OIDExternalNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(OIDExternal,OIDExternal) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(OIDExternal oIDExternal,OIDExternal oldOIDExternal) {
			if(oIDExternal.IDType != oldOIDExternal.IDType) {
				return true;
			}
			if(oIDExternal.IDInternal != oldOIDExternal.IDInternal) {
				return true;
			}
			if(oIDExternal.IDExternal != oldOIDExternal.IDExternal) {
				return true;
			}
			if(oIDExternal.rootExternal != oldOIDExternal.rootExternal) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one OIDExternal from the database.</summary>
		public static void Delete(long oIDExternalNum) {
			string command="DELETE FROM oidexternal "
				+"WHERE OIDExternalNum = "+POut.Long(oIDExternalNum);
			Db.NonQ(command);
		}

	}
}