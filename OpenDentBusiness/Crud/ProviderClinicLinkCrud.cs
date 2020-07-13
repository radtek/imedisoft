//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ProviderClinicLinkCrud {
		///<summary>Gets one ProviderClinicLink object from the database using the primary key.  Returns null if not found.</summary>
		public static ProviderClinicLink SelectOne(long providerClinicLinkNum) {
			string command="SELECT * FROM providercliniclink "
				+"WHERE ProviderClinicLinkNum = "+POut.Long(providerClinicLinkNum);
			List<ProviderClinicLink> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ProviderClinicLink object from the database using a query.</summary>
		public static ProviderClinicLink SelectOne(string command) {

			List<ProviderClinicLink> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ProviderClinicLink objects from the database using a query.</summary>
		public static List<ProviderClinicLink> SelectMany(string command) {

			List<ProviderClinicLink> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ProviderClinicLink> TableToList(DataTable table) {
			List<ProviderClinicLink> retVal=new List<ProviderClinicLink>();
			ProviderClinicLink providerClinicLink;
			foreach(DataRow row in table.Rows) {
				providerClinicLink=new ProviderClinicLink();
				providerClinicLink.ProviderClinicLinkNum= PIn.Long  (row["ProviderClinicLinkNum"].ToString());
				providerClinicLink.ProvNum              = PIn.Long  (row["ProvNum"].ToString());
				providerClinicLink.ClinicNum            = PIn.Long  (row["ClinicNum"].ToString());
				retVal.Add(providerClinicLink);
			}
			return retVal;
		}

		///<summary>Converts a list of ProviderClinicLink into a DataTable.</summary>
		public static DataTable ListToTable(List<ProviderClinicLink> listProviderClinicLinks,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ProviderClinicLink";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ProviderClinicLinkNum");
			table.Columns.Add("ProvNum");
			table.Columns.Add("ClinicNum");
			foreach(ProviderClinicLink providerClinicLink in listProviderClinicLinks) {
				table.Rows.Add(new object[] {
					POut.Long  (providerClinicLink.ProviderClinicLinkNum),
					POut.Long  (providerClinicLink.ProvNum),
					POut.Long  (providerClinicLink.ClinicNum),
				});
			}
			return table;
		}

		///<summary>Inserts one ProviderClinicLink into the database.  Returns the new priKey.</summary>
		public static long Insert(ProviderClinicLink providerClinicLink) {
			return Insert(providerClinicLink,false);
		}

		///<summary>Inserts one ProviderClinicLink into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ProviderClinicLink providerClinicLink,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				providerClinicLink.ProviderClinicLinkNum=ReplicationServers.GetKey("providercliniclink","ProviderClinicLinkNum");
			}
			string command="INSERT INTO providercliniclink (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ProviderClinicLinkNum,";
			}
			command+="ProvNum,ClinicNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(providerClinicLink.ProviderClinicLinkNum)+",";
			}
			command+=
				     POut.Long  (providerClinicLink.ProvNum)+","
				+    POut.Long  (providerClinicLink.ClinicNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				providerClinicLink.ProviderClinicLinkNum=Db.NonQ(command,true,"ProviderClinicLinkNum","providerClinicLink");
			}
			return providerClinicLink.ProviderClinicLinkNum;
		}

		///<summary>Inserts one ProviderClinicLink into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ProviderClinicLink providerClinicLink) {
			return InsertNoCache(providerClinicLink,false);
		}

		///<summary>Inserts one ProviderClinicLink into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ProviderClinicLink providerClinicLink,bool useExistingPK) {
			
			string command="INSERT INTO providercliniclink (";
			if(!useExistingPK) {
				providerClinicLink.ProviderClinicLinkNum=ReplicationServers.GetKeyNoCache("providercliniclink","ProviderClinicLinkNum");
			}
			if(useExistingPK) {
				command+="ProviderClinicLinkNum,";
			}
			command+="ProvNum,ClinicNum) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(providerClinicLink.ProviderClinicLinkNum)+",";
			}
			command+=
				     POut.Long  (providerClinicLink.ProvNum)+","
				+    POut.Long  (providerClinicLink.ClinicNum)+")";
			if(useExistingPK) {
				Db.NonQ(command);
			}
			else {
				providerClinicLink.ProviderClinicLinkNum=Db.NonQ(command,true,"ProviderClinicLinkNum","providerClinicLink");
			}
			return providerClinicLink.ProviderClinicLinkNum;
		}

		///<summary>Updates one ProviderClinicLink in the database.</summary>
		public static void Update(ProviderClinicLink providerClinicLink) {
			string command="UPDATE providercliniclink SET "
				+"ProvNum              =  "+POut.Long  (providerClinicLink.ProvNum)+", "
				+"ClinicNum            =  "+POut.Long  (providerClinicLink.ClinicNum)+" "
				+"WHERE ProviderClinicLinkNum = "+POut.Long(providerClinicLink.ProviderClinicLinkNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ProviderClinicLink in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ProviderClinicLink providerClinicLink,ProviderClinicLink oldProviderClinicLink) {
			string command="";
			if(providerClinicLink.ProvNum != oldProviderClinicLink.ProvNum) {
				if(command!="") { command+=",";}
				command+="ProvNum = "+POut.Long(providerClinicLink.ProvNum)+"";
			}
			if(providerClinicLink.ClinicNum != oldProviderClinicLink.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(providerClinicLink.ClinicNum)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE providercliniclink SET "+command
				+" WHERE ProviderClinicLinkNum = "+POut.Long(providerClinicLink.ProviderClinicLinkNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(ProviderClinicLink,ProviderClinicLink) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ProviderClinicLink providerClinicLink,ProviderClinicLink oldProviderClinicLink) {
			if(providerClinicLink.ProvNum != oldProviderClinicLink.ProvNum) {
				return true;
			}
			if(providerClinicLink.ClinicNum != oldProviderClinicLink.ClinicNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ProviderClinicLink from the database.</summary>
		public static void Delete(long providerClinicLinkNum) {
			string command="DELETE FROM providercliniclink "
				+"WHERE ProviderClinicLinkNum = "+POut.Long(providerClinicLinkNum);
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<ProviderClinicLink> listNew,List<ProviderClinicLink> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<ProviderClinicLink> listIns    =new List<ProviderClinicLink>();
			List<ProviderClinicLink> listUpdNew =new List<ProviderClinicLink>();
			List<ProviderClinicLink> listUpdDB  =new List<ProviderClinicLink>();
			List<ProviderClinicLink> listDel    =new List<ProviderClinicLink>();
			listNew.Sort((ProviderClinicLink x,ProviderClinicLink y) => { return x.ProviderClinicLinkNum.CompareTo(y.ProviderClinicLinkNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((ProviderClinicLink x,ProviderClinicLink y) => { return x.ProviderClinicLinkNum.CompareTo(y.ProviderClinicLinkNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			ProviderClinicLink fieldNew;
			ProviderClinicLink fieldDB;
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
				else if(fieldNew.ProviderClinicLinkNum<fieldDB.ProviderClinicLinkNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.ProviderClinicLinkNum>fieldDB.ProviderClinicLinkNum) {//dbPK less than newPK, dbItem is 'next'
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
				Delete(listDel[i].ProviderClinicLinkNum);
			}
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}