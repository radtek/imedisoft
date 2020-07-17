//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class InsFilingCodeSubtypeCrud {
		///<summary>Gets one InsFilingCodeSubtype object from the database using the primary key.  Returns null if not found.</summary>
		public static InsFilingCodeSubtype SelectOne(long insFilingCodeSubtypeNum) {
			string command="SELECT * FROM insfilingcodesubtype "
				+"WHERE InsFilingCodeSubtypeNum = "+POut.Long(insFilingCodeSubtypeNum);
			List<InsFilingCodeSubtype> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one InsFilingCodeSubtype object from the database using a query.</summary>
		public static InsFilingCodeSubtype SelectOne(string command) {

			List<InsFilingCodeSubtype> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of InsFilingCodeSubtype objects from the database using a query.</summary>
		public static List<InsFilingCodeSubtype> SelectMany(string command) {

			List<InsFilingCodeSubtype> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<InsFilingCodeSubtype> TableToList(DataTable table) {
			List<InsFilingCodeSubtype> retVal=new List<InsFilingCodeSubtype>();
			InsFilingCodeSubtype insFilingCodeSubtype;
			foreach(DataRow row in table.Rows) {
				insFilingCodeSubtype=new InsFilingCodeSubtype();
				insFilingCodeSubtype.InsFilingCodeSubtypeNum= PIn.Long  (row["InsFilingCodeSubtypeNum"].ToString());
				insFilingCodeSubtype.InsFilingCodeNum       = PIn.Long  (row["InsFilingCodeNum"].ToString());
				insFilingCodeSubtype.Descript               = PIn.String(row["Descript"].ToString());
				retVal.Add(insFilingCodeSubtype);
			}
			return retVal;
		}

		///<summary>Converts a list of InsFilingCodeSubtype into a DataTable.</summary>
		public static DataTable ListToTable(List<InsFilingCodeSubtype> listInsFilingCodeSubtypes,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="InsFilingCodeSubtype";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("InsFilingCodeSubtypeNum");
			table.Columns.Add("InsFilingCodeNum");
			table.Columns.Add("Descript");
			foreach(InsFilingCodeSubtype insFilingCodeSubtype in listInsFilingCodeSubtypes) {
				table.Rows.Add(new object[] {
					POut.Long  (insFilingCodeSubtype.InsFilingCodeSubtypeNum),
					POut.Long  (insFilingCodeSubtype.InsFilingCodeNum),
					            insFilingCodeSubtype.Descript,
				});
			}
			return table;
		}

		///<summary>Inserts one InsFilingCodeSubtype into the database.  Returns the new priKey.</summary>
		public static long Insert(InsFilingCodeSubtype insFilingCodeSubtype) {
			return Insert(insFilingCodeSubtype,false);
		}

		///<summary>Inserts one InsFilingCodeSubtype into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(InsFilingCodeSubtype insFilingCodeSubtype,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				insFilingCodeSubtype.InsFilingCodeSubtypeNum=ReplicationServers.GetKey("insfilingcodesubtype","InsFilingCodeSubtypeNum");
			}
			string command="INSERT INTO insfilingcodesubtype (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="InsFilingCodeSubtypeNum,";
			}
			command+="InsFilingCodeNum,Descript) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(insFilingCodeSubtype.InsFilingCodeSubtypeNum)+",";
			}
			command+=
				     POut.Long  (insFilingCodeSubtype.InsFilingCodeNum)+","
				+"'"+POut.String(insFilingCodeSubtype.Descript)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				insFilingCodeSubtype.InsFilingCodeSubtypeNum=Database.ExecuteInsert(command);
			}
			return insFilingCodeSubtype.InsFilingCodeSubtypeNum;
		}

		///<summary>Inserts one InsFilingCodeSubtype into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(InsFilingCodeSubtype insFilingCodeSubtype) {
			return InsertNoCache(insFilingCodeSubtype,false);
		}

		///<summary>Inserts one InsFilingCodeSubtype into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(InsFilingCodeSubtype insFilingCodeSubtype,bool useExistingPK) {
			
			string command="INSERT INTO insfilingcodesubtype (";
			if(!useExistingPK) {
				insFilingCodeSubtype.InsFilingCodeSubtypeNum=ReplicationServers.GetKeyNoCache("insfilingcodesubtype","InsFilingCodeSubtypeNum");
			}
			if(useExistingPK) {
				command+="InsFilingCodeSubtypeNum,";
			}
			command+="InsFilingCodeNum,Descript) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(insFilingCodeSubtype.InsFilingCodeSubtypeNum)+",";
			}
			command+=
				     POut.Long  (insFilingCodeSubtype.InsFilingCodeNum)+","
				+"'"+POut.String(insFilingCodeSubtype.Descript)+"')";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				insFilingCodeSubtype.InsFilingCodeSubtypeNum=Database.ExecuteInsert(command);
			}
			return insFilingCodeSubtype.InsFilingCodeSubtypeNum;
		}

		///<summary>Updates one InsFilingCodeSubtype in the database.</summary>
		public static void Update(InsFilingCodeSubtype insFilingCodeSubtype) {
			string command="UPDATE insfilingcodesubtype SET "
				+"InsFilingCodeNum       =  "+POut.Long  (insFilingCodeSubtype.InsFilingCodeNum)+", "
				+"Descript               = '"+POut.String(insFilingCodeSubtype.Descript)+"' "
				+"WHERE InsFilingCodeSubtypeNum = "+POut.Long(insFilingCodeSubtype.InsFilingCodeSubtypeNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one InsFilingCodeSubtype in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(InsFilingCodeSubtype insFilingCodeSubtype,InsFilingCodeSubtype oldInsFilingCodeSubtype) {
			string command="";
			if(insFilingCodeSubtype.InsFilingCodeNum != oldInsFilingCodeSubtype.InsFilingCodeNum) {
				if(command!="") { command+=",";}
				command+="InsFilingCodeNum = "+POut.Long(insFilingCodeSubtype.InsFilingCodeNum)+"";
			}
			if(insFilingCodeSubtype.Descript != oldInsFilingCodeSubtype.Descript) {
				if(command!="") { command+=",";}
				command+="Descript = '"+POut.String(insFilingCodeSubtype.Descript)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE insfilingcodesubtype SET "+command
				+" WHERE InsFilingCodeSubtypeNum = "+POut.Long(insFilingCodeSubtype.InsFilingCodeSubtypeNum);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(InsFilingCodeSubtype,InsFilingCodeSubtype) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(InsFilingCodeSubtype insFilingCodeSubtype,InsFilingCodeSubtype oldInsFilingCodeSubtype) {
			if(insFilingCodeSubtype.InsFilingCodeNum != oldInsFilingCodeSubtype.InsFilingCodeNum) {
				return true;
			}
			if(insFilingCodeSubtype.Descript != oldInsFilingCodeSubtype.Descript) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one InsFilingCodeSubtype from the database.</summary>
		public static void Delete(long insFilingCodeSubtypeNum) {
			string command="DELETE FROM insfilingcodesubtype "
				+"WHERE InsFilingCodeSubtypeNum = "+POut.Long(insFilingCodeSubtypeNum);
			Database.ExecuteNonQuery(command);
		}

	}
}