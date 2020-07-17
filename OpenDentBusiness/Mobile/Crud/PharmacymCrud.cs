//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Mobile.Crud{
	internal class PharmacymCrud {
		///<summary>Gets one Pharmacym object from the database using primaryKey1(CustomerNum) and primaryKey2.  Returns null if not found.</summary>
		internal static Pharmacym SelectOne(long customerNum,long pharmacyNum){
			string command="SELECT * FROM pharmacym "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND PharmacyNum = "+POut.Long(pharmacyNum);
			List<Pharmacym> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Pharmacym object from the database using a query.</summary>
		internal static Pharmacym SelectOne(string command){

			List<Pharmacym> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Pharmacym objects from the database using a query.</summary>
		internal static List<Pharmacym> SelectMany(string command){

			List<Pharmacym> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<Pharmacym> TableToList(DataTable table){
			List<Pharmacym> retVal=new List<Pharmacym>();
			Pharmacym pharmacym;
			for(int i=0;i<table.Rows.Count;i++) {
				pharmacym=new Pharmacym();
				pharmacym.CustomerNum= PIn.Long  (table.Rows[i]["CustomerNum"].ToString());
				pharmacym.PharmacyNum= PIn.Long  (table.Rows[i]["PharmacyNum"].ToString());
				pharmacym.StoreName  = PIn.String(table.Rows[i]["StoreName"].ToString());
				pharmacym.Phone      = PIn.String(table.Rows[i]["Phone"].ToString());
				pharmacym.Fax        = PIn.String(table.Rows[i]["Fax"].ToString());
				pharmacym.Address    = PIn.String(table.Rows[i]["Address"].ToString());
				pharmacym.Address2   = PIn.String(table.Rows[i]["Address2"].ToString());
				pharmacym.City       = PIn.String(table.Rows[i]["City"].ToString());
				pharmacym.State      = PIn.String(table.Rows[i]["State"].ToString());
				pharmacym.Zip        = PIn.String(table.Rows[i]["Zip"].ToString());
				pharmacym.Note       = PIn.String(table.Rows[i]["Note"].ToString());
				retVal.Add(pharmacym);
			}
			return retVal;
		}

		///<summary>Usually set useExistingPK=true.  Inserts one Pharmacym into the database.</summary>
		internal static long Insert(Pharmacym pharmacym,bool useExistingPK){
			if(!useExistingPK) {
				pharmacym.PharmacyNum=ReplicationServers.GetKey("pharmacym","PharmacyNum");
			}
			string command="INSERT INTO pharmacym (";
			command+="PharmacyNum,";
			command+="CustomerNum,StoreName,Phone,Fax,Address,Address2,City,State,Zip,Note) VALUES(";
			command+=POut.Long(pharmacym.PharmacyNum)+",";
			command+=
				     POut.Long  (pharmacym.CustomerNum)+","
				+"'"+POut.String(pharmacym.StoreName)+"',"
				+"'"+POut.String(pharmacym.Phone)+"',"
				+"'"+POut.String(pharmacym.Fax)+"',"
				+"'"+POut.String(pharmacym.Address)+"',"
				+"'"+POut.String(pharmacym.Address2)+"',"
				+"'"+POut.String(pharmacym.City)+"',"
				+"'"+POut.String(pharmacym.State)+"',"
				+"'"+POut.String(pharmacym.Zip)+"',"
				+"'"+POut.String(pharmacym.Note)+"')";
			Database.ExecuteNonQuery(command);//There is no autoincrement in the mobile server.
			return pharmacym.PharmacyNum;
		}

		///<summary>Updates one Pharmacym in the database.</summary>
		internal static void Update(Pharmacym pharmacym){
			string command="UPDATE pharmacym SET "
				+"StoreName  = '"+POut.String(pharmacym.StoreName)+"', "
				+"Phone      = '"+POut.String(pharmacym.Phone)+"', "
				+"Fax        = '"+POut.String(pharmacym.Fax)+"', "
				+"Address    = '"+POut.String(pharmacym.Address)+"', "
				+"Address2   = '"+POut.String(pharmacym.Address2)+"', "
				+"City       = '"+POut.String(pharmacym.City)+"', "
				+"State      = '"+POut.String(pharmacym.State)+"', "
				+"Zip        = '"+POut.String(pharmacym.Zip)+"', "
				+"Note       = '"+POut.String(pharmacym.Note)+"' "
				+"WHERE CustomerNum = "+POut.Long(pharmacym.CustomerNum)+" AND PharmacyNum = "+POut.Long(pharmacym.PharmacyNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Deletes one Pharmacym from the database.</summary>
		internal static void Delete(long customerNum,long pharmacyNum){
			string command="DELETE FROM pharmacym "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND PharmacyNum = "+POut.Long(pharmacyNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Converts one Pharmacy object to its mobile equivalent.  Warning! CustomerNum will always be 0.</summary>
		internal static Pharmacym ConvertToM(Pharmacy pharmacy){
			Pharmacym pharmacym=new Pharmacym();
			//CustomerNum cannot be set.  Remains 0.
			pharmacym.PharmacyNum=pharmacy.PharmacyNum;
			pharmacym.StoreName  =pharmacy.StoreName;
			pharmacym.Phone      =pharmacy.Phone;
			pharmacym.Fax        =pharmacy.Fax;
			pharmacym.Address    =pharmacy.Address;
			pharmacym.Address2   =pharmacy.Address2;
			pharmacym.City       =pharmacy.City;
			pharmacym.State      =pharmacy.State;
			pharmacym.Zip        =pharmacy.Zip;
			pharmacym.Note       =pharmacy.Note;
			return pharmacym;
		}

	}
}