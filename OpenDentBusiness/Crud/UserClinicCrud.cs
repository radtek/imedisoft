//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class UserClinicCrud {
		///<summary>Gets one UserClinic object from the database using the primary key.  Returns null if not found.</summary>
		public static UserClinic SelectOne(long userClinicNum) {
			string command="SELECT * FROM userclinic "
				+"WHERE UserClinicNum = "+POut.Long(userClinicNum);
			List<UserClinic> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one UserClinic object from the database using a query.</summary>
		public static UserClinic SelectOne(string command) {

			List<UserClinic> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of UserClinic objects from the database using a query.</summary>
		public static List<UserClinic> SelectMany(string command) {

			List<UserClinic> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<UserClinic> TableToList(DataTable table) {
			List<UserClinic> retVal=new List<UserClinic>();
			UserClinic userClinic;
			foreach(DataRow row in table.Rows) {
				userClinic=new UserClinic();
				userClinic.UserClinicNum= PIn.Long  (row["UserClinicNum"].ToString());
				userClinic.UserNum      = PIn.Long  (row["UserNum"].ToString());
				userClinic.ClinicNum    = PIn.Long  (row["ClinicNum"].ToString());
				retVal.Add(userClinic);
			}
			return retVal;
		}

		///<summary>Converts a list of UserClinic into a DataTable.</summary>
		public static DataTable ListToTable(List<UserClinic> listUserClinics,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="UserClinic";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("UserClinicNum");
			table.Columns.Add("UserNum");
			table.Columns.Add("ClinicNum");
			foreach(UserClinic userClinic in listUserClinics) {
				table.Rows.Add(new object[] {
					POut.Long  (userClinic.UserClinicNum),
					POut.Long  (userClinic.UserNum),
					POut.Long  (userClinic.ClinicNum),
				});
			}
			return table;
		}

		///<summary>Inserts one UserClinic into the database.  Returns the new priKey.</summary>
		public static long Insert(UserClinic userClinic) {
			return Insert(userClinic,false);
		}

		///<summary>Inserts one UserClinic into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(UserClinic userClinic,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				userClinic.UserClinicNum=ReplicationServers.GetKey("userclinic","UserClinicNum");
			}
			string command="INSERT INTO userclinic (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="UserClinicNum,";
			}
			command+="UserNum,ClinicNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(userClinic.UserClinicNum)+",";
			}
			command+=
				     POut.Long  (userClinic.UserNum)+","
				+    POut.Long  (userClinic.ClinicNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				userClinic.UserClinicNum=Database.ExecuteInsert(command);
			}
			return userClinic.UserClinicNum;
		}

		///<summary>Inserts one UserClinic into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(UserClinic userClinic) {
			return InsertNoCache(userClinic,false);
		}

		///<summary>Inserts one UserClinic into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(UserClinic userClinic,bool useExistingPK) {
			
			string command="INSERT INTO userclinic (";
			if(!useExistingPK) {
				userClinic.UserClinicNum=ReplicationServers.GetKeyNoCache("userclinic","UserClinicNum");
			}
			if(useExistingPK) {
				command+="UserClinicNum,";
			}
			command+="UserNum,ClinicNum) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(userClinic.UserClinicNum)+",";
			}
			command+=
				     POut.Long  (userClinic.UserNum)+","
				+    POut.Long  (userClinic.ClinicNum)+")";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				userClinic.UserClinicNum=Database.ExecuteInsert(command);
			}
			return userClinic.UserClinicNum;
		}

		///<summary>Updates one UserClinic in the database.</summary>
		public static void Update(UserClinic userClinic) {
			string command="UPDATE userclinic SET "
				+"UserNum      =  "+POut.Long  (userClinic.UserNum)+", "
				+"ClinicNum    =  "+POut.Long  (userClinic.ClinicNum)+" "
				+"WHERE UserClinicNum = "+POut.Long(userClinic.UserClinicNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one UserClinic in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(UserClinic userClinic,UserClinic oldUserClinic) {
			string command="";
			if(userClinic.UserNum != oldUserClinic.UserNum) {
				if(command!="") { command+=",";}
				command+="UserNum = "+POut.Long(userClinic.UserNum)+"";
			}
			if(userClinic.ClinicNum != oldUserClinic.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(userClinic.ClinicNum)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE userclinic SET "+command
				+" WHERE UserClinicNum = "+POut.Long(userClinic.UserClinicNum);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(UserClinic,UserClinic) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(UserClinic userClinic,UserClinic oldUserClinic) {
			if(userClinic.UserNum != oldUserClinic.UserNum) {
				return true;
			}
			if(userClinic.ClinicNum != oldUserClinic.ClinicNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one UserClinic from the database.</summary>
		public static void Delete(long userClinicNum) {
			string command="DELETE FROM userclinic "
				+"WHERE UserClinicNum = "+POut.Long(userClinicNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<UserClinic> listNew,List<UserClinic> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<UserClinic> listIns    =new List<UserClinic>();
			List<UserClinic> listUpdNew =new List<UserClinic>();
			List<UserClinic> listUpdDB  =new List<UserClinic>();
			List<UserClinic> listDel    =new List<UserClinic>();
			listNew.Sort((UserClinic x,UserClinic y) => { return x.UserClinicNum.CompareTo(y.UserClinicNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((UserClinic x,UserClinic y) => { return x.UserClinicNum.CompareTo(y.UserClinicNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			UserClinic fieldNew;
			UserClinic fieldDB;
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
				else if(fieldNew.UserClinicNum<fieldDB.UserClinicNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.UserClinicNum>fieldDB.UserClinicNum) {//dbPK less than newPK, dbItem is 'next'
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
				Delete(listDel[i].UserClinicNum);
			}
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}