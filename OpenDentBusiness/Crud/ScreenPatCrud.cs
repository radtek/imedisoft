//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ScreenPatCrud {
		///<summary>Gets one ScreenPat object from the database using the primary key.  Returns null if not found.</summary>
		public static ScreenPat SelectOne(long screenPatNum) {
			string command="SELECT * FROM screenpat "
				+"WHERE ScreenPatNum = "+POut.Long(screenPatNum);
			List<ScreenPat> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ScreenPat object from the database using a query.</summary>
		public static ScreenPat SelectOne(string command) {

			List<ScreenPat> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ScreenPat objects from the database using a query.</summary>
		public static List<ScreenPat> SelectMany(string command) {

			List<ScreenPat> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ScreenPat> TableToList(DataTable table) {
			List<ScreenPat> retVal=new List<ScreenPat>();
			ScreenPat screenPat;
			foreach(DataRow row in table.Rows) {
				screenPat=new ScreenPat();
				screenPat.ScreenPatNum  = PIn.Long  (row["ScreenPatNum"].ToString());
				screenPat.PatNum        = PIn.Long  (row["PatNum"].ToString());
				screenPat.ScreenGroupNum= PIn.Long  (row["ScreenGroupNum"].ToString());
				screenPat.SheetNum      = PIn.Long  (row["SheetNum"].ToString());
				screenPat.PatScreenPerm = (OpenDentBusiness.PatScreenPerm)PIn.Int(row["PatScreenPerm"].ToString());
				retVal.Add(screenPat);
			}
			return retVal;
		}

		///<summary>Converts a list of ScreenPat into a DataTable.</summary>
		public static DataTable ListToTable(List<ScreenPat> listScreenPats,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ScreenPat";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ScreenPatNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("ScreenGroupNum");
			table.Columns.Add("SheetNum");
			table.Columns.Add("PatScreenPerm");
			foreach(ScreenPat screenPat in listScreenPats) {
				table.Rows.Add(new object[] {
					POut.Long  (screenPat.ScreenPatNum),
					POut.Long  (screenPat.PatNum),
					POut.Long  (screenPat.ScreenGroupNum),
					POut.Long  (screenPat.SheetNum),
					POut.Int   ((int)screenPat.PatScreenPerm),
				});
			}
			return table;
		}

		///<summary>Inserts one ScreenPat into the database.  Returns the new priKey.</summary>
		public static long Insert(ScreenPat screenPat) {
			return Insert(screenPat,false);
		}

		///<summary>Inserts one ScreenPat into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ScreenPat screenPat,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				screenPat.ScreenPatNum=ReplicationServers.GetKey("screenpat","ScreenPatNum");
			}
			string command="INSERT INTO screenpat (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ScreenPatNum,";
			}
			command+="PatNum,ScreenGroupNum,SheetNum,PatScreenPerm) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(screenPat.ScreenPatNum)+",";
			}
			command+=
				     POut.Long  (screenPat.PatNum)+","
				+    POut.Long  (screenPat.ScreenGroupNum)+","
				+    POut.Long  (screenPat.SheetNum)+","
				+    POut.Int   ((int)screenPat.PatScreenPerm)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				screenPat.ScreenPatNum=Database.ExecuteInsert(command);
			}
			return screenPat.ScreenPatNum;
		}

		///<summary>Inserts one ScreenPat into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ScreenPat screenPat) {
			return InsertNoCache(screenPat,false);
		}

		///<summary>Inserts one ScreenPat into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ScreenPat screenPat,bool useExistingPK) {
			
			string command="INSERT INTO screenpat (";
			if(!useExistingPK) {
				screenPat.ScreenPatNum=ReplicationServers.GetKeyNoCache("screenpat","ScreenPatNum");
			}
			if(useExistingPK) {
				command+="ScreenPatNum,";
			}
			command+="PatNum,ScreenGroupNum,SheetNum,PatScreenPerm) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(screenPat.ScreenPatNum)+",";
			}
			command+=
				     POut.Long  (screenPat.PatNum)+","
				+    POut.Long  (screenPat.ScreenGroupNum)+","
				+    POut.Long  (screenPat.SheetNum)+","
				+    POut.Int   ((int)screenPat.PatScreenPerm)+")";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				screenPat.ScreenPatNum=Database.ExecuteInsert(command);
			}
			return screenPat.ScreenPatNum;
		}

		///<summary>Updates one ScreenPat in the database.</summary>
		public static void Update(ScreenPat screenPat) {
			string command="UPDATE screenpat SET "
				+"PatNum        =  "+POut.Long  (screenPat.PatNum)+", "
				+"ScreenGroupNum=  "+POut.Long  (screenPat.ScreenGroupNum)+", "
				+"SheetNum      =  "+POut.Long  (screenPat.SheetNum)+", "
				+"PatScreenPerm =  "+POut.Int   ((int)screenPat.PatScreenPerm)+" "
				+"WHERE ScreenPatNum = "+POut.Long(screenPat.ScreenPatNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one ScreenPat in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ScreenPat screenPat,ScreenPat oldScreenPat) {
			string command="";
			if(screenPat.PatNum != oldScreenPat.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(screenPat.PatNum)+"";
			}
			if(screenPat.ScreenGroupNum != oldScreenPat.ScreenGroupNum) {
				if(command!="") { command+=",";}
				command+="ScreenGroupNum = "+POut.Long(screenPat.ScreenGroupNum)+"";
			}
			if(screenPat.SheetNum != oldScreenPat.SheetNum) {
				if(command!="") { command+=",";}
				command+="SheetNum = "+POut.Long(screenPat.SheetNum)+"";
			}
			if(screenPat.PatScreenPerm != oldScreenPat.PatScreenPerm) {
				if(command!="") { command+=",";}
				command+="PatScreenPerm = "+POut.Int   ((int)screenPat.PatScreenPerm)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE screenpat SET "+command
				+" WHERE ScreenPatNum = "+POut.Long(screenPat.ScreenPatNum);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(ScreenPat,ScreenPat) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ScreenPat screenPat,ScreenPat oldScreenPat) {
			if(screenPat.PatNum != oldScreenPat.PatNum) {
				return true;
			}
			if(screenPat.ScreenGroupNum != oldScreenPat.ScreenGroupNum) {
				return true;
			}
			if(screenPat.SheetNum != oldScreenPat.SheetNum) {
				return true;
			}
			if(screenPat.PatScreenPerm != oldScreenPat.PatScreenPerm) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ScreenPat from the database.</summary>
		public static void Delete(long screenPatNum) {
			string command="DELETE FROM screenpat "
				+"WHERE ScreenPatNum = "+POut.Long(screenPatNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<ScreenPat> listNew,List<ScreenPat> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<ScreenPat> listIns    =new List<ScreenPat>();
			List<ScreenPat> listUpdNew =new List<ScreenPat>();
			List<ScreenPat> listUpdDB  =new List<ScreenPat>();
			List<ScreenPat> listDel    =new List<ScreenPat>();
			listNew.Sort((ScreenPat x,ScreenPat y) => { return x.ScreenPatNum.CompareTo(y.ScreenPatNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((ScreenPat x,ScreenPat y) => { return x.ScreenPatNum.CompareTo(y.ScreenPatNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			ScreenPat fieldNew;
			ScreenPat fieldDB;
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
				else if(fieldNew.ScreenPatNum<fieldDB.ScreenPatNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.ScreenPatNum>fieldDB.ScreenPatNum) {//dbPK less than newPK, dbItem is 'next'
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
				Delete(listDel[i].ScreenPatNum);
			}
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}