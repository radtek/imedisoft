//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class AlertReadCrud {
		///<summary>Gets one AlertRead object from the database using the primary key.  Returns null if not found.</summary>
		public static AlertRead SelectOne(long alertReadNum) {
			string command="SELECT * FROM alertread "
				+"WHERE AlertReadNum = "+POut.Long(alertReadNum);
			List<AlertRead> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one AlertRead object from the database using a query.</summary>
		public static AlertRead SelectOne(string command) {
			List<AlertRead> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of AlertRead objects from the database using a query.</summary>
		public static List<AlertRead> SelectMany(string command) {
			List<AlertRead> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<AlertRead> TableToList(DataTable table) {
			List<AlertRead> retVal=new List<AlertRead>();
			AlertRead alertRead;
			foreach(DataRow row in table.Rows) {
				alertRead=new AlertRead();
				alertRead.AlertReadNum= PIn.Long  (row["AlertReadNum"].ToString());
				alertRead.AlertItemNum= PIn.Long  (row["AlertItemNum"].ToString());
				alertRead.UserNum     = PIn.Long  (row["UserNum"].ToString());
				retVal.Add(alertRead);
			}
			return retVal;
		}

		///<summary>Converts a list of AlertRead into a DataTable.</summary>
		public static DataTable ListToTable(List<AlertRead> listAlertReads,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="AlertRead";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("AlertReadNum");
			table.Columns.Add("AlertItemNum");
			table.Columns.Add("UserNum");
			foreach(AlertRead alertRead in listAlertReads) {
				table.Rows.Add(new object[] {
					POut.Long  (alertRead.AlertReadNum),
					POut.Long  (alertRead.AlertItemNum),
					POut.Long  (alertRead.UserNum),
				});
			}
			return table;
		}

		///<summary>Inserts one AlertRead into the database.  Returns the new priKey.</summary>
		public static long Insert(AlertRead alertRead) {
			return Insert(alertRead,false);
		}

		///<summary>Inserts one AlertRead into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(AlertRead alertRead,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				alertRead.AlertReadNum=ReplicationServers.GetKey("alertread","AlertReadNum");
			}
			string command="INSERT INTO alertread (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="AlertReadNum,";
			}
			command+="AlertItemNum,UserNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(alertRead.AlertReadNum)+",";
			}
			command+=
				     POut.Long  (alertRead.AlertItemNum)+","
				+    POut.Long  (alertRead.UserNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				alertRead.AlertReadNum=Database.ExecuteInsert(command);
			}
			return alertRead.AlertReadNum;
		}

		///<summary>Inserts one AlertRead into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(AlertRead alertRead) {
			return InsertNoCache(alertRead,false);
		}

		///<summary>Inserts one AlertRead into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(AlertRead alertRead,bool useExistingPK) {
			
			string command="INSERT INTO alertread (";
			if(!useExistingPK) {
				alertRead.AlertReadNum=ReplicationServers.GetKeyNoCache("alertread","AlertReadNum");
			}
			if(useExistingPK) {
				command+="AlertReadNum,";
			}
			command+="AlertItemNum,UserNum) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(alertRead.AlertReadNum)+",";
			}
			command+=
				     POut.Long  (alertRead.AlertItemNum)+","
				+    POut.Long  (alertRead.UserNum)+")";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				alertRead.AlertReadNum=Database.ExecuteInsert(command);
			}
			return alertRead.AlertReadNum;
		}

		///<summary>Updates one AlertRead in the database.</summary>
		public static void Update(AlertRead alertRead) {
			string command="UPDATE alertread SET "
				+"AlertItemNum=  "+POut.Long  (alertRead.AlertItemNum)+", "
				+"UserNum     =  "+POut.Long  (alertRead.UserNum)+" "
				+"WHERE AlertReadNum = "+POut.Long(alertRead.AlertReadNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one AlertRead in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(AlertRead alertRead,AlertRead oldAlertRead) {
			string command="";
			if(alertRead.AlertItemNum != oldAlertRead.AlertItemNum) {
				if(command!="") { command+=",";}
				command+="AlertItemNum = "+POut.Long(alertRead.AlertItemNum)+"";
			}
			if(alertRead.UserNum != oldAlertRead.UserNum) {
				if(command!="") { command+=",";}
				command+="UserNum = "+POut.Long(alertRead.UserNum)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE alertread SET "+command
				+" WHERE AlertReadNum = "+POut.Long(alertRead.AlertReadNum);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(AlertRead,AlertRead) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(AlertRead alertRead,AlertRead oldAlertRead) {
			if(alertRead.AlertItemNum != oldAlertRead.AlertItemNum) {
				return true;
			}
			if(alertRead.UserNum != oldAlertRead.UserNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one AlertRead from the database.</summary>
		public static void Delete(long alertReadNum) {
			string command="DELETE FROM alertread "
				+"WHERE AlertReadNum = "+POut.Long(alertReadNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<AlertRead> listNew,List<AlertRead> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<AlertRead> listIns    =new List<AlertRead>();
			List<AlertRead> listUpdNew =new List<AlertRead>();
			List<AlertRead> listUpdDB  =new List<AlertRead>();
			List<AlertRead> listDel    =new List<AlertRead>();
			listNew.Sort((AlertRead x,AlertRead y) => { return x.AlertReadNum.CompareTo(y.AlertReadNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((AlertRead x,AlertRead y) => { return x.AlertReadNum.CompareTo(y.AlertReadNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			AlertRead fieldNew;
			AlertRead fieldDB;
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
				else if(fieldNew.AlertReadNum<fieldDB.AlertReadNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.AlertReadNum>fieldDB.AlertReadNum) {//dbPK less than newPK, dbItem is 'next'
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
				Delete(listDel[i].AlertReadNum);
			}
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}