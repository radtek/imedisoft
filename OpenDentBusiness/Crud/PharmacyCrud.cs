//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class PharmacyCrud {
		///<summary>Gets one Pharmacy object from the database using the primary key.  Returns null if not found.</summary>
		public static Pharmacy SelectOne(long pharmacyNum) {
			string command="SELECT * FROM pharmacy "
				+"WHERE PharmacyNum = "+POut.Long(pharmacyNum);
			List<Pharmacy> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Pharmacy object from the database using a query.</summary>
		public static Pharmacy SelectOne(string command) {

			List<Pharmacy> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Pharmacy objects from the database using a query.</summary>
		public static List<Pharmacy> SelectMany(string command) {

			List<Pharmacy> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Pharmacy> TableToList(DataTable table) {
			List<Pharmacy> retVal=new List<Pharmacy>();
			Pharmacy pharmacy;
			foreach(DataRow row in table.Rows) {
				pharmacy=new Pharmacy();
				pharmacy.PharmacyNum= PIn.Long  (row["PharmacyNum"].ToString());
				pharmacy.PharmID    = PIn.String(row["PharmID"].ToString());
				pharmacy.StoreName  = PIn.String(row["StoreName"].ToString());
				pharmacy.Phone      = PIn.String(row["Phone"].ToString());
				pharmacy.Fax        = PIn.String(row["Fax"].ToString());
				pharmacy.Address    = PIn.String(row["Address"].ToString());
				pharmacy.Address2   = PIn.String(row["Address2"].ToString());
				pharmacy.City       = PIn.String(row["City"].ToString());
				pharmacy.State      = PIn.String(row["State"].ToString());
				pharmacy.Zip        = PIn.String(row["Zip"].ToString());
				pharmacy.Note       = PIn.String(row["Note"].ToString());
				pharmacy.DateTStamp = PIn.Date (row["DateTStamp"].ToString());
				retVal.Add(pharmacy);
			}
			return retVal;
		}

		///<summary>Converts a list of Pharmacy into a DataTable.</summary>
		public static DataTable ListToTable(List<Pharmacy> listPharmacys,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Pharmacy";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("PharmacyNum");
			table.Columns.Add("PharmID");
			table.Columns.Add("StoreName");
			table.Columns.Add("Phone");
			table.Columns.Add("Fax");
			table.Columns.Add("Address");
			table.Columns.Add("Address2");
			table.Columns.Add("City");
			table.Columns.Add("State");
			table.Columns.Add("Zip");
			table.Columns.Add("Note");
			table.Columns.Add("DateTStamp");
			foreach(Pharmacy pharmacy in listPharmacys) {
				table.Rows.Add(new object[] {
					POut.Long  (pharmacy.PharmacyNum),
					            pharmacy.PharmID,
					            pharmacy.StoreName,
					            pharmacy.Phone,
					            pharmacy.Fax,
					            pharmacy.Address,
					            pharmacy.Address2,
					            pharmacy.City,
					            pharmacy.State,
					            pharmacy.Zip,
					            pharmacy.Note,
					POut.DateT (pharmacy.DateTStamp,false),
				});
			}
			return table;
		}

		///<summary>Inserts one Pharmacy into the database.  Returns the new priKey.</summary>
		public static long Insert(Pharmacy pharmacy) {
			return Insert(pharmacy,false);
		}

		///<summary>Inserts one Pharmacy into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Pharmacy pharmacy,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				pharmacy.PharmacyNum=ReplicationServers.GetKey("pharmacy","PharmacyNum");
			}
			string command="INSERT INTO pharmacy (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="PharmacyNum,";
			}
			command+="PharmID,StoreName,Phone,Fax,Address,Address2,City,State,Zip,Note) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(pharmacy.PharmacyNum)+",";
			}
			command+=
				 "'"+POut.String(pharmacy.PharmID)+"',"
				+"'"+POut.String(pharmacy.StoreName)+"',"
				+"'"+POut.String(pharmacy.Phone)+"',"
				+"'"+POut.String(pharmacy.Fax)+"',"
				+"'"+POut.String(pharmacy.Address)+"',"
				+"'"+POut.String(pharmacy.Address2)+"',"
				+"'"+POut.String(pharmacy.City)+"',"
				+"'"+POut.String(pharmacy.State)+"',"
				+"'"+POut.String(pharmacy.Zip)+"',"
				+    DbHelper.ParamChar+"paramNote)";
				//DateTStamp can only be set by MySQL
			if(pharmacy.Note==null) {
				pharmacy.Note="";
			}
			var paramNote = new MySqlParameter("paramNote", POut.StringParam(pharmacy.Note));
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command,paramNote);
			}
			else {
				pharmacy.PharmacyNum=Database.ExecuteInsert(command,paramNote);
			}
			return pharmacy.PharmacyNum;
		}

		///<summary>Inserts one Pharmacy into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Pharmacy pharmacy) {
			return InsertNoCache(pharmacy,false);
		}

		///<summary>Inserts one Pharmacy into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Pharmacy pharmacy,bool useExistingPK) {
			
			string command="INSERT INTO pharmacy (";
			if(!useExistingPK) {
				pharmacy.PharmacyNum=ReplicationServers.GetKeyNoCache("pharmacy","PharmacyNum");
			}
			if(useExistingPK) {
				command+="PharmacyNum,";
			}
			command+="PharmID,StoreName,Phone,Fax,Address,Address2,City,State,Zip,Note) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(pharmacy.PharmacyNum)+",";
			}
			command+=
				 "'"+POut.String(pharmacy.PharmID)+"',"
				+"'"+POut.String(pharmacy.StoreName)+"',"
				+"'"+POut.String(pharmacy.Phone)+"',"
				+"'"+POut.String(pharmacy.Fax)+"',"
				+"'"+POut.String(pharmacy.Address)+"',"
				+"'"+POut.String(pharmacy.Address2)+"',"
				+"'"+POut.String(pharmacy.City)+"',"
				+"'"+POut.String(pharmacy.State)+"',"
				+"'"+POut.String(pharmacy.Zip)+"',"
				+    DbHelper.ParamChar+"paramNote)";
				//DateTStamp can only be set by MySQL
			if(pharmacy.Note==null) {
				pharmacy.Note="";
			}
			var paramNote = new MySqlParameter("paramNote", POut.StringParam(pharmacy.Note));
			if(useExistingPK) {
				Database.ExecuteNonQuery(command,paramNote);
			}
			else {
				pharmacy.PharmacyNum=Database.ExecuteInsert(command,paramNote);
			}
			return pharmacy.PharmacyNum;
		}

		///<summary>Updates one Pharmacy in the database.</summary>
		public static void Update(Pharmacy pharmacy) {
			string command="UPDATE pharmacy SET "
				+"PharmID    = '"+POut.String(pharmacy.PharmID)+"', "
				+"StoreName  = '"+POut.String(pharmacy.StoreName)+"', "
				+"Phone      = '"+POut.String(pharmacy.Phone)+"', "
				+"Fax        = '"+POut.String(pharmacy.Fax)+"', "
				+"Address    = '"+POut.String(pharmacy.Address)+"', "
				+"Address2   = '"+POut.String(pharmacy.Address2)+"', "
				+"City       = '"+POut.String(pharmacy.City)+"', "
				+"State      = '"+POut.String(pharmacy.State)+"', "
				+"Zip        = '"+POut.String(pharmacy.Zip)+"', "
				+"Note       =  "+DbHelper.ParamChar+"paramNote "
				//DateTStamp can only be set by MySQL
				+"WHERE PharmacyNum = "+POut.Long(pharmacy.PharmacyNum);
			if(pharmacy.Note==null) {
				pharmacy.Note="";
			}
			var paramNote = new MySqlParameter("paramNote", POut.StringParam(pharmacy.Note));
			Database.ExecuteNonQuery(command,paramNote);
		}

		///<summary>Updates one Pharmacy in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Pharmacy pharmacy,Pharmacy oldPharmacy) {
			string command="";
			if(pharmacy.PharmID != oldPharmacy.PharmID) {
				if(command!="") { command+=",";}
				command+="PharmID = '"+POut.String(pharmacy.PharmID)+"'";
			}
			if(pharmacy.StoreName != oldPharmacy.StoreName) {
				if(command!="") { command+=",";}
				command+="StoreName = '"+POut.String(pharmacy.StoreName)+"'";
			}
			if(pharmacy.Phone != oldPharmacy.Phone) {
				if(command!="") { command+=",";}
				command+="Phone = '"+POut.String(pharmacy.Phone)+"'";
			}
			if(pharmacy.Fax != oldPharmacy.Fax) {
				if(command!="") { command+=",";}
				command+="Fax = '"+POut.String(pharmacy.Fax)+"'";
			}
			if(pharmacy.Address != oldPharmacy.Address) {
				if(command!="") { command+=",";}
				command+="Address = '"+POut.String(pharmacy.Address)+"'";
			}
			if(pharmacy.Address2 != oldPharmacy.Address2) {
				if(command!="") { command+=",";}
				command+="Address2 = '"+POut.String(pharmacy.Address2)+"'";
			}
			if(pharmacy.City != oldPharmacy.City) {
				if(command!="") { command+=",";}
				command+="City = '"+POut.String(pharmacy.City)+"'";
			}
			if(pharmacy.State != oldPharmacy.State) {
				if(command!="") { command+=",";}
				command+="State = '"+POut.String(pharmacy.State)+"'";
			}
			if(pharmacy.Zip != oldPharmacy.Zip) {
				if(command!="") { command+=",";}
				command+="Zip = '"+POut.String(pharmacy.Zip)+"'";
			}
			if(pharmacy.Note != oldPharmacy.Note) {
				if(command!="") { command+=",";}
				command+="Note = "+DbHelper.ParamChar+"paramNote";
			}
			//DateTStamp can only be set by MySQL
			if(command=="") {
				return false;
			}
			if(pharmacy.Note==null) {
				pharmacy.Note="";
			}
			var paramNote = new MySqlParameter("paramNote", POut.StringParam(pharmacy.Note));
			command="UPDATE pharmacy SET "+command
				+" WHERE PharmacyNum = "+POut.Long(pharmacy.PharmacyNum);
			Database.ExecuteNonQuery(command,paramNote);
			return true;
		}

		///<summary>Returns true if Update(Pharmacy,Pharmacy) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Pharmacy pharmacy,Pharmacy oldPharmacy) {
			if(pharmacy.PharmID != oldPharmacy.PharmID) {
				return true;
			}
			if(pharmacy.StoreName != oldPharmacy.StoreName) {
				return true;
			}
			if(pharmacy.Phone != oldPharmacy.Phone) {
				return true;
			}
			if(pharmacy.Fax != oldPharmacy.Fax) {
				return true;
			}
			if(pharmacy.Address != oldPharmacy.Address) {
				return true;
			}
			if(pharmacy.Address2 != oldPharmacy.Address2) {
				return true;
			}
			if(pharmacy.City != oldPharmacy.City) {
				return true;
			}
			if(pharmacy.State != oldPharmacy.State) {
				return true;
			}
			if(pharmacy.Zip != oldPharmacy.Zip) {
				return true;
			}
			if(pharmacy.Note != oldPharmacy.Note) {
				return true;
			}
			//DateTStamp can only be set by MySQL
			return false;
		}

		///<summary>Deletes one Pharmacy from the database.</summary>
		public static void Delete(long pharmacyNum) {
			string command="DELETE FROM pharmacy "
				+"WHERE PharmacyNum = "+POut.Long(pharmacyNum);
			Database.ExecuteNonQuery(command);
		}

	}
}