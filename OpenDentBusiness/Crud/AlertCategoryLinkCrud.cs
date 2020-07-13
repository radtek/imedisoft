//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class AlertCategoryLinkCrud {
		///<summary>Gets one AlertCategoryLink object from the database using the primary key.  Returns null if not found.</summary>
		public static AlertCategoryLink SelectOne(long alertCategoryLinkNum) {
			string command="SELECT * FROM alertcategorylink "
				+"WHERE AlertCategoryLinkNum = "+POut.Long(alertCategoryLinkNum);
			List<AlertCategoryLink> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one AlertCategoryLink object from the database using a query.</summary>
		public static AlertCategoryLink SelectOne(string command) {
			List<AlertCategoryLink> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of AlertCategoryLink objects from the database using a query.</summary>
		public static List<AlertCategoryLink> SelectMany(string command) {
			List<AlertCategoryLink> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<AlertCategoryLink> TableToList(DataTable table) {
			List<AlertCategoryLink> retVal=new List<AlertCategoryLink>();
			AlertCategoryLink alertCategoryLink;
			foreach(DataRow row in table.Rows) {
				alertCategoryLink=new AlertCategoryLink();
				alertCategoryLink.AlertCategoryLinkNum= PIn.Long  (row["AlertCategoryLinkNum"].ToString());
				alertCategoryLink.AlertCategoryNum    = PIn.Long  (row["AlertCategoryNum"].ToString());
				alertCategoryLink.AlertType           = (OpenDentBusiness.AlertType)PIn.Int(row["AlertType"].ToString());
				retVal.Add(alertCategoryLink);
			}
			return retVal;
		}

		///<summary>Converts a list of AlertCategoryLink into a DataTable.</summary>
		public static DataTable ListToTable(List<AlertCategoryLink> listAlertCategoryLinks,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="AlertCategoryLink";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("AlertCategoryLinkNum");
			table.Columns.Add("AlertCategoryNum");
			table.Columns.Add("AlertType");
			foreach(AlertCategoryLink alertCategoryLink in listAlertCategoryLinks) {
				table.Rows.Add(new object[] {
					POut.Long  (alertCategoryLink.AlertCategoryLinkNum),
					POut.Long  (alertCategoryLink.AlertCategoryNum),
					POut.Int   ((int)alertCategoryLink.AlertType),
				});
			}
			return table;
		}

		///<summary>Inserts one AlertCategoryLink into the database.  Returns the new priKey.</summary>
		public static long Insert(AlertCategoryLink alertCategoryLink) {
			return Insert(alertCategoryLink,false);
		}

		///<summary>Inserts one AlertCategoryLink into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(AlertCategoryLink alertCategoryLink,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				alertCategoryLink.AlertCategoryLinkNum=ReplicationServers.GetKey("alertcategorylink","AlertCategoryLinkNum");
			}
			string command="INSERT INTO alertcategorylink (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="AlertCategoryLinkNum,";
			}
			command+="AlertCategoryNum,AlertType) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(alertCategoryLink.AlertCategoryLinkNum)+",";
			}
			command+=
				     POut.Long  (alertCategoryLink.AlertCategoryNum)+","
				+    POut.Int   ((int)alertCategoryLink.AlertType)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				alertCategoryLink.AlertCategoryLinkNum=Db.NonQ(command,true,"AlertCategoryLinkNum","alertCategoryLink");
			}
			return alertCategoryLink.AlertCategoryLinkNum;
		}

		///<summary>Inserts one AlertCategoryLink into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(AlertCategoryLink alertCategoryLink) {
			return InsertNoCache(alertCategoryLink,false);
		}

		///<summary>Inserts one AlertCategoryLink into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(AlertCategoryLink alertCategoryLink,bool useExistingPK) {
			
			string command="INSERT INTO alertcategorylink (";
			if(!useExistingPK) {
				alertCategoryLink.AlertCategoryLinkNum=ReplicationServers.GetKeyNoCache("alertcategorylink","AlertCategoryLinkNum");
			}
			if(useExistingPK) {
				command+="AlertCategoryLinkNum,";
			}
			command+="AlertCategoryNum,AlertType) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(alertCategoryLink.AlertCategoryLinkNum)+",";
			}
			command+=
				     POut.Long  (alertCategoryLink.AlertCategoryNum)+","
				+    POut.Int   ((int)alertCategoryLink.AlertType)+")";
			if(useExistingPK) {
				Db.NonQ(command);
			}
			else {
				alertCategoryLink.AlertCategoryLinkNum=Db.NonQ(command,true,"AlertCategoryLinkNum","alertCategoryLink");
			}
			return alertCategoryLink.AlertCategoryLinkNum;
		}

		///<summary>Updates one AlertCategoryLink in the database.</summary>
		public static void Update(AlertCategoryLink alertCategoryLink) {
			string command="UPDATE alertcategorylink SET "
				+"AlertCategoryNum    =  "+POut.Long  (alertCategoryLink.AlertCategoryNum)+", "
				+"AlertType           =  "+POut.Int   ((int)alertCategoryLink.AlertType)+" "
				+"WHERE AlertCategoryLinkNum = "+POut.Long(alertCategoryLink.AlertCategoryLinkNum);
			Db.NonQ(command);
		}

		///<summary>Updates one AlertCategoryLink in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(AlertCategoryLink alertCategoryLink,AlertCategoryLink oldAlertCategoryLink) {
			string command="";
			if(alertCategoryLink.AlertCategoryNum != oldAlertCategoryLink.AlertCategoryNum) {
				if(command!="") { command+=",";}
				command+="AlertCategoryNum = "+POut.Long(alertCategoryLink.AlertCategoryNum)+"";
			}
			if(alertCategoryLink.AlertType != oldAlertCategoryLink.AlertType) {
				if(command!="") { command+=",";}
				command+="AlertType = "+POut.Int   ((int)alertCategoryLink.AlertType)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE alertcategorylink SET "+command
				+" WHERE AlertCategoryLinkNum = "+POut.Long(alertCategoryLink.AlertCategoryLinkNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(AlertCategoryLink,AlertCategoryLink) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(AlertCategoryLink alertCategoryLink,AlertCategoryLink oldAlertCategoryLink) {
			if(alertCategoryLink.AlertCategoryNum != oldAlertCategoryLink.AlertCategoryNum) {
				return true;
			}
			if(alertCategoryLink.AlertType != oldAlertCategoryLink.AlertType) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one AlertCategoryLink from the database.</summary>
		public static void Delete(long alertCategoryLinkNum) {
			string command="DELETE FROM alertcategorylink "
				+"WHERE AlertCategoryLinkNum = "+POut.Long(alertCategoryLinkNum);
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<AlertCategoryLink> listNew,List<AlertCategoryLink> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<AlertCategoryLink> listIns    =new List<AlertCategoryLink>();
			List<AlertCategoryLink> listUpdNew =new List<AlertCategoryLink>();
			List<AlertCategoryLink> listUpdDB  =new List<AlertCategoryLink>();
			List<AlertCategoryLink> listDel    =new List<AlertCategoryLink>();
			listNew.Sort((AlertCategoryLink x,AlertCategoryLink y) => { return x.AlertCategoryLinkNum.CompareTo(y.AlertCategoryLinkNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((AlertCategoryLink x,AlertCategoryLink y) => { return x.AlertCategoryLinkNum.CompareTo(y.AlertCategoryLinkNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			AlertCategoryLink fieldNew;
			AlertCategoryLink fieldDB;
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
				else if(fieldNew.AlertCategoryLinkNum<fieldDB.AlertCategoryLinkNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.AlertCategoryLinkNum>fieldDB.AlertCategoryLinkNum) {//dbPK less than newPK, dbItem is 'next'
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
				Delete(listDel[i].AlertCategoryLinkNum);
			}
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}