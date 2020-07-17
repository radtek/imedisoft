//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class OrthoChartTabCrud {
		///<summary>Gets one OrthoChartTab object from the database using the primary key.  Returns null if not found.</summary>
		public static OrthoChartTab SelectOne(long orthoChartTabNum) {
			string command="SELECT * FROM orthocharttab "
				+"WHERE OrthoChartTabNum = "+POut.Long(orthoChartTabNum);
			List<OrthoChartTab> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one OrthoChartTab object from the database using a query.</summary>
		public static OrthoChartTab SelectOne(string command) {

			List<OrthoChartTab> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of OrthoChartTab objects from the database using a query.</summary>
		public static List<OrthoChartTab> SelectMany(string command) {

			List<OrthoChartTab> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<OrthoChartTab> TableToList(DataTable table) {
			List<OrthoChartTab> retVal=new List<OrthoChartTab>();
			OrthoChartTab orthoChartTab;
			foreach(DataRow row in table.Rows) {
				orthoChartTab=new OrthoChartTab();
				orthoChartTab.OrthoChartTabNum= PIn.Long  (row["OrthoChartTabNum"].ToString());
				orthoChartTab.TabName         = PIn.String(row["TabName"].ToString());
				orthoChartTab.ItemOrder       = PIn.Int   (row["ItemOrder"].ToString());
				orthoChartTab.IsHidden        = PIn.Bool  (row["IsHidden"].ToString());
				retVal.Add(orthoChartTab);
			}
			return retVal;
		}

		///<summary>Converts a list of OrthoChartTab into a DataTable.</summary>
		public static DataTable ListToTable(List<OrthoChartTab> listOrthoChartTabs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="OrthoChartTab";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("OrthoChartTabNum");
			table.Columns.Add("TabName");
			table.Columns.Add("ItemOrder");
			table.Columns.Add("IsHidden");
			foreach(OrthoChartTab orthoChartTab in listOrthoChartTabs) {
				table.Rows.Add(new object[] {
					POut.Long  (orthoChartTab.OrthoChartTabNum),
					            orthoChartTab.TabName,
					POut.Int   (orthoChartTab.ItemOrder),
					POut.Bool  (orthoChartTab.IsHidden),
				});
			}
			return table;
		}

		///<summary>Inserts one OrthoChartTab into the database.  Returns the new priKey.</summary>
		public static long Insert(OrthoChartTab orthoChartTab) {
			return Insert(orthoChartTab,false);
		}

		///<summary>Inserts one OrthoChartTab into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(OrthoChartTab orthoChartTab,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				orthoChartTab.OrthoChartTabNum=ReplicationServers.GetKey("orthocharttab","OrthoChartTabNum");
			}
			string command="INSERT INTO orthocharttab (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="OrthoChartTabNum,";
			}
			command+="TabName,ItemOrder,IsHidden) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(orthoChartTab.OrthoChartTabNum)+",";
			}
			command+=
				 "'"+POut.String(orthoChartTab.TabName)+"',"
				+    POut.Int   (orthoChartTab.ItemOrder)+","
				+    POut.Bool  (orthoChartTab.IsHidden)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				orthoChartTab.OrthoChartTabNum=Database.ExecuteInsert(command);
			}
			return orthoChartTab.OrthoChartTabNum;
		}

		///<summary>Inserts one OrthoChartTab into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(OrthoChartTab orthoChartTab) {
			return InsertNoCache(orthoChartTab,false);
		}

		///<summary>Inserts one OrthoChartTab into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(OrthoChartTab orthoChartTab,bool useExistingPK) {
			
			string command="INSERT INTO orthocharttab (";
			if(!useExistingPK) {
				orthoChartTab.OrthoChartTabNum=ReplicationServers.GetKeyNoCache("orthocharttab","OrthoChartTabNum");
			}
			if(useExistingPK) {
				command+="OrthoChartTabNum,";
			}
			command+="TabName,ItemOrder,IsHidden) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(orthoChartTab.OrthoChartTabNum)+",";
			}
			command+=
				 "'"+POut.String(orthoChartTab.TabName)+"',"
				+    POut.Int   (orthoChartTab.ItemOrder)+","
				+    POut.Bool  (orthoChartTab.IsHidden)+")";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				orthoChartTab.OrthoChartTabNum=Database.ExecuteInsert(command);
			}
			return orthoChartTab.OrthoChartTabNum;
		}

		///<summary>Updates one OrthoChartTab in the database.</summary>
		public static void Update(OrthoChartTab orthoChartTab) {
			string command="UPDATE orthocharttab SET "
				+"TabName         = '"+POut.String(orthoChartTab.TabName)+"', "
				+"ItemOrder       =  "+POut.Int   (orthoChartTab.ItemOrder)+", "
				+"IsHidden        =  "+POut.Bool  (orthoChartTab.IsHidden)+" "
				+"WHERE OrthoChartTabNum = "+POut.Long(orthoChartTab.OrthoChartTabNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one OrthoChartTab in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(OrthoChartTab orthoChartTab,OrthoChartTab oldOrthoChartTab) {
			string command="";
			if(orthoChartTab.TabName != oldOrthoChartTab.TabName) {
				if(command!="") { command+=",";}
				command+="TabName = '"+POut.String(orthoChartTab.TabName)+"'";
			}
			if(orthoChartTab.ItemOrder != oldOrthoChartTab.ItemOrder) {
				if(command!="") { command+=",";}
				command+="ItemOrder = "+POut.Int(orthoChartTab.ItemOrder)+"";
			}
			if(orthoChartTab.IsHidden != oldOrthoChartTab.IsHidden) {
				if(command!="") { command+=",";}
				command+="IsHidden = "+POut.Bool(orthoChartTab.IsHidden)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE orthocharttab SET "+command
				+" WHERE OrthoChartTabNum = "+POut.Long(orthoChartTab.OrthoChartTabNum);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(OrthoChartTab,OrthoChartTab) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(OrthoChartTab orthoChartTab,OrthoChartTab oldOrthoChartTab) {
			if(orthoChartTab.TabName != oldOrthoChartTab.TabName) {
				return true;
			}
			if(orthoChartTab.ItemOrder != oldOrthoChartTab.ItemOrder) {
				return true;
			}
			if(orthoChartTab.IsHidden != oldOrthoChartTab.IsHidden) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one OrthoChartTab from the database.</summary>
		public static void Delete(long orthoChartTabNum) {
			string command="DELETE FROM orthocharttab "
				+"WHERE OrthoChartTabNum = "+POut.Long(orthoChartTabNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<OrthoChartTab> listNew,List<OrthoChartTab> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<OrthoChartTab> listIns    =new List<OrthoChartTab>();
			List<OrthoChartTab> listUpdNew =new List<OrthoChartTab>();
			List<OrthoChartTab> listUpdDB  =new List<OrthoChartTab>();
			List<OrthoChartTab> listDel    =new List<OrthoChartTab>();
			listNew.Sort((OrthoChartTab x,OrthoChartTab y) => { return x.OrthoChartTabNum.CompareTo(y.OrthoChartTabNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((OrthoChartTab x,OrthoChartTab y) => { return x.OrthoChartTabNum.CompareTo(y.OrthoChartTabNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			OrthoChartTab fieldNew;
			OrthoChartTab fieldDB;
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
				else if(fieldNew.OrthoChartTabNum<fieldDB.OrthoChartTabNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.OrthoChartTabNum>fieldDB.OrthoChartTabNum) {//dbPK less than newPK, dbItem is 'next'
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
				Delete(listDel[i].OrthoChartTabNum);
			}
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}