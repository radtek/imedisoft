//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ProviderClinicCrud {
		///<summary>Gets one ProviderClinic object from the database using the primary key.  Returns null if not found.</summary>
		public static ProviderClinic SelectOne(long providerClinicNum) {
			string command="SELECT * FROM providerclinic "
				+"WHERE ProviderClinicNum = "+POut.Long(providerClinicNum);
			List<ProviderClinic> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ProviderClinic object from the database using a query.</summary>
		public static ProviderClinic SelectOne(string command) {

			List<ProviderClinic> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ProviderClinic objects from the database using a query.</summary>
		public static List<ProviderClinic> SelectMany(string command) {

			List<ProviderClinic> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ProviderClinic> TableToList(DataTable table) {
			List<ProviderClinic> retVal=new List<ProviderClinic>();
			ProviderClinic providerClinic;
			foreach(DataRow row in table.Rows) {
				providerClinic=new ProviderClinic();
				providerClinic.ProviderClinicNum = PIn.Long  (row["ProviderClinicNum"].ToString());
				providerClinic.ProvNum           = PIn.Long  (row["ProvNum"].ToString());
				providerClinic.ClinicNum         = PIn.Long  (row["ClinicNum"].ToString());
				providerClinic.DEANum            = PIn.String(row["DEANum"].ToString());
				providerClinic.StateLicense      = PIn.String(row["StateLicense"].ToString());
				providerClinic.StateRxID         = PIn.String(row["StateRxID"].ToString());
				providerClinic.StateWhereLicensed= PIn.String(row["StateWhereLicensed"].ToString());
				retVal.Add(providerClinic);
			}
			return retVal;
		}

		///<summary>Converts a list of ProviderClinic into a DataTable.</summary>
		public static DataTable ListToTable(List<ProviderClinic> listProviderClinics,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ProviderClinic";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ProviderClinicNum");
			table.Columns.Add("ProvNum");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("DEANum");
			table.Columns.Add("StateLicense");
			table.Columns.Add("StateRxID");
			table.Columns.Add("StateWhereLicensed");
			foreach(ProviderClinic providerClinic in listProviderClinics) {
				table.Rows.Add(new object[] {
					POut.Long  (providerClinic.ProviderClinicNum),
					POut.Long  (providerClinic.ProvNum),
					POut.Long  (providerClinic.ClinicNum),
					            providerClinic.DEANum,
					            providerClinic.StateLicense,
					            providerClinic.StateRxID,
					            providerClinic.StateWhereLicensed,
				});
			}
			return table;
		}

		///<summary>Inserts one ProviderClinic into the database.  Returns the new priKey.</summary>
		public static long Insert(ProviderClinic providerClinic) {
			return Insert(providerClinic,false);
		}

		///<summary>Inserts one ProviderClinic into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ProviderClinic providerClinic,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				providerClinic.ProviderClinicNum=ReplicationServers.GetKey("providerclinic","ProviderClinicNum");
			}
			string command="INSERT INTO providerclinic (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ProviderClinicNum,";
			}
			command+="ProvNum,ClinicNum,DEANum,StateLicense,StateRxID,StateWhereLicensed) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(providerClinic.ProviderClinicNum)+",";
			}
			command+=
				     POut.Long  (providerClinic.ProvNum)+","
				+    POut.Long  (providerClinic.ClinicNum)+","
				+"'"+POut.String(providerClinic.DEANum)+"',"
				+"'"+POut.String(providerClinic.StateLicense)+"',"
				+"'"+POut.String(providerClinic.StateRxID)+"',"
				+"'"+POut.String(providerClinic.StateWhereLicensed)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				providerClinic.ProviderClinicNum=Db.NonQ(command,true,"ProviderClinicNum","providerClinic");
			}
			return providerClinic.ProviderClinicNum;
		}

		///<summary>Inserts one ProviderClinic into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ProviderClinic providerClinic) {
			return InsertNoCache(providerClinic,false);
		}

		///<summary>Inserts one ProviderClinic into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ProviderClinic providerClinic,bool useExistingPK) {
			
			string command="INSERT INTO providerclinic (";
			if(!useExistingPK) {
				providerClinic.ProviderClinicNum=ReplicationServers.GetKeyNoCache("providerclinic","ProviderClinicNum");
			}
			if(useExistingPK) {
				command+="ProviderClinicNum,";
			}
			command+="ProvNum,ClinicNum,DEANum,StateLicense,StateRxID,StateWhereLicensed) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(providerClinic.ProviderClinicNum)+",";
			}
			command+=
				     POut.Long  (providerClinic.ProvNum)+","
				+    POut.Long  (providerClinic.ClinicNum)+","
				+"'"+POut.String(providerClinic.DEANum)+"',"
				+"'"+POut.String(providerClinic.StateLicense)+"',"
				+"'"+POut.String(providerClinic.StateRxID)+"',"
				+"'"+POut.String(providerClinic.StateWhereLicensed)+"')";
			if(useExistingPK) {
				Db.NonQ(command);
			}
			else {
				providerClinic.ProviderClinicNum=Db.NonQ(command,true,"ProviderClinicNum","providerClinic");
			}
			return providerClinic.ProviderClinicNum;
		}

		///<summary>Updates one ProviderClinic in the database.</summary>
		public static void Update(ProviderClinic providerClinic) {
			string command="UPDATE providerclinic SET "
				+"ProvNum           =  "+POut.Long  (providerClinic.ProvNum)+", "
				+"ClinicNum         =  "+POut.Long  (providerClinic.ClinicNum)+", "
				+"DEANum            = '"+POut.String(providerClinic.DEANum)+"', "
				+"StateLicense      = '"+POut.String(providerClinic.StateLicense)+"', "
				+"StateRxID         = '"+POut.String(providerClinic.StateRxID)+"', "
				+"StateWhereLicensed= '"+POut.String(providerClinic.StateWhereLicensed)+"' "
				+"WHERE ProviderClinicNum = "+POut.Long(providerClinic.ProviderClinicNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ProviderClinic in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ProviderClinic providerClinic,ProviderClinic oldProviderClinic) {
			string command="";
			if(providerClinic.ProvNum != oldProviderClinic.ProvNum) {
				if(command!="") { command+=",";}
				command+="ProvNum = "+POut.Long(providerClinic.ProvNum)+"";
			}
			if(providerClinic.ClinicNum != oldProviderClinic.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(providerClinic.ClinicNum)+"";
			}
			if(providerClinic.DEANum != oldProviderClinic.DEANum) {
				if(command!="") { command+=",";}
				command+="DEANum = '"+POut.String(providerClinic.DEANum)+"'";
			}
			if(providerClinic.StateLicense != oldProviderClinic.StateLicense) {
				if(command!="") { command+=",";}
				command+="StateLicense = '"+POut.String(providerClinic.StateLicense)+"'";
			}
			if(providerClinic.StateRxID != oldProviderClinic.StateRxID) {
				if(command!="") { command+=",";}
				command+="StateRxID = '"+POut.String(providerClinic.StateRxID)+"'";
			}
			if(providerClinic.StateWhereLicensed != oldProviderClinic.StateWhereLicensed) {
				if(command!="") { command+=",";}
				command+="StateWhereLicensed = '"+POut.String(providerClinic.StateWhereLicensed)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE providerclinic SET "+command
				+" WHERE ProviderClinicNum = "+POut.Long(providerClinic.ProviderClinicNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(ProviderClinic,ProviderClinic) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ProviderClinic providerClinic,ProviderClinic oldProviderClinic) {
			if(providerClinic.ProvNum != oldProviderClinic.ProvNum) {
				return true;
			}
			if(providerClinic.ClinicNum != oldProviderClinic.ClinicNum) {
				return true;
			}
			if(providerClinic.DEANum != oldProviderClinic.DEANum) {
				return true;
			}
			if(providerClinic.StateLicense != oldProviderClinic.StateLicense) {
				return true;
			}
			if(providerClinic.StateRxID != oldProviderClinic.StateRxID) {
				return true;
			}
			if(providerClinic.StateWhereLicensed != oldProviderClinic.StateWhereLicensed) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ProviderClinic from the database.</summary>
		public static void Delete(long providerClinicNum) {
			string command="DELETE FROM providerclinic "
				+"WHERE ProviderClinicNum = "+POut.Long(providerClinicNum);
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<ProviderClinic> listNew,List<ProviderClinic> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<ProviderClinic> listIns    =new List<ProviderClinic>();
			List<ProviderClinic> listUpdNew =new List<ProviderClinic>();
			List<ProviderClinic> listUpdDB  =new List<ProviderClinic>();
			List<ProviderClinic> listDel    =new List<ProviderClinic>();
			listNew.Sort((ProviderClinic x,ProviderClinic y) => { return x.ProviderClinicNum.CompareTo(y.ProviderClinicNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((ProviderClinic x,ProviderClinic y) => { return x.ProviderClinicNum.CompareTo(y.ProviderClinicNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			ProviderClinic fieldNew;
			ProviderClinic fieldDB;
			//Because both lists have been sorted using the same criteria, we can now walk each list to determine which list contians the next element.  The next element is determined by Primary Key.
			//If the New list contains the next item it will be inserted.  If the DB contains the next item, it will be deleted.  If both lists contain the next item, the item will be updated.
			while(idxNew<listNew.Count || idxDB<listDB.Count) {
				fieldNew=null;
				if(idxNew<listNew.Count) {
					fieldNew=listNew[idxNew];
				}
				fieldDB=null;
				if(idxDB<listDB.Count) {
					fieldDB=listDB[idxDB];
				}
				//begin compare
				if(fieldNew!=null && fieldDB==null) {//listNew has more items, listDB does not.
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew==null && fieldDB!=null) {//listDB has more items, listNew does not.
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				else if(fieldNew.ProviderClinicNum<fieldDB.ProviderClinicNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.ProviderClinicNum>fieldDB.ProviderClinicNum) {//dbPK less than newPK, dbItem is 'next'
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				//Both lists contain the 'next' item, update required
				listUpdNew.Add(fieldNew);
				listUpdDB.Add(fieldDB);
				idxNew++;
				idxDB++;
			}
			//Commit changes to DB
			for(int i=0;i<listIns.Count;i++) {
				Insert(listIns[i]);
			}
			for(int i=0;i<listUpdNew.Count;i++) {
				if(Update(listUpdNew[i],listUpdDB[i])) {
					rowsUpdatedCount++;
				}
			}
			for(int i=0;i<listDel.Count;i++) {
				Delete(listDel[i].ProviderClinicNum);
			}
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}