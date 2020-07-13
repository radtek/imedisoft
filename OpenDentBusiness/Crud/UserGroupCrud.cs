//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class UserGroupCrud {
		///<summary>Gets one UserGroup object from the database using the primary key.  Returns null if not found.</summary>
		public static UserGroup SelectOne(long userGroupNum) {
			string command="SELECT * FROM usergroup "
				+"WHERE UserGroupNum = "+POut.Long(userGroupNum);
			List<UserGroup> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one UserGroup object from the database using a query.</summary>
		public static UserGroup SelectOne(string command) {

			List<UserGroup> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of UserGroup objects from the database using a query.</summary>
		public static List<UserGroup> SelectMany(string command) {

			List<UserGroup> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<UserGroup> TableToList(DataTable table) {
			List<UserGroup> retVal=new List<UserGroup>();
			UserGroup userGroup;
			foreach(DataRow row in table.Rows) {
				userGroup=new UserGroup();
				userGroup.UserGroupNum    = PIn.Long  (row["UserGroupNum"].ToString());
				userGroup.Description     = PIn.String(row["Description"].ToString());
				userGroup.UserGroupNumCEMT= PIn.Long  (row["UserGroupNumCEMT"].ToString());
				retVal.Add(userGroup);
			}
			return retVal;
		}

		///<summary>Converts a list of UserGroup into a DataTable.</summary>
		public static DataTable ListToTable(List<UserGroup> listUserGroups,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="UserGroup";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("UserGroupNum");
			table.Columns.Add("Description");
			table.Columns.Add("UserGroupNumCEMT");
			foreach(UserGroup userGroup in listUserGroups) {
				table.Rows.Add(new object[] {
					POut.Long  (userGroup.UserGroupNum),
					            userGroup.Description,
					POut.Long  (userGroup.UserGroupNumCEMT),
				});
			}
			return table;
		}

		///<summary>Inserts one UserGroup into the database.  Returns the new priKey.</summary>
		public static long Insert(UserGroup userGroup) {
			return Insert(userGroup,false);
		}

		///<summary>Inserts one UserGroup into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(UserGroup userGroup,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				userGroup.UserGroupNum=ReplicationServers.GetKey("usergroup","UserGroupNum");
			}
			string command="INSERT INTO usergroup (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="UserGroupNum,";
			}
			command+="Description,UserGroupNumCEMT) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(userGroup.UserGroupNum)+",";
			}
			command+=
				 "'"+POut.String(userGroup.Description)+"',"
				+    POut.Long  (userGroup.UserGroupNumCEMT)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				userGroup.UserGroupNum=Db.NonQ(command,true,"UserGroupNum","userGroup");
			}
			return userGroup.UserGroupNum;
		}

		///<summary>Inserts one UserGroup into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(UserGroup userGroup) {
			return InsertNoCache(userGroup,false);
		}

		///<summary>Inserts one UserGroup into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(UserGroup userGroup,bool useExistingPK) {
			
			string command="INSERT INTO usergroup (";
			if(!useExistingPK) {
				userGroup.UserGroupNum=ReplicationServers.GetKeyNoCache("usergroup","UserGroupNum");
			}
			if(useExistingPK) {
				command+="UserGroupNum,";
			}
			command+="Description,UserGroupNumCEMT) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(userGroup.UserGroupNum)+",";
			}
			command+=
				 "'"+POut.String(userGroup.Description)+"',"
				+    POut.Long  (userGroup.UserGroupNumCEMT)+")";
			if(useExistingPK) {
				Db.NonQ(command);
			}
			else {
				userGroup.UserGroupNum=Db.NonQ(command,true,"UserGroupNum","userGroup");
			}
			return userGroup.UserGroupNum;
		}

		///<summary>Updates one UserGroup in the database.</summary>
		public static void Update(UserGroup userGroup) {
			string command="UPDATE usergroup SET "
				+"Description     = '"+POut.String(userGroup.Description)+"', "
				+"UserGroupNumCEMT=  "+POut.Long  (userGroup.UserGroupNumCEMT)+" "
				+"WHERE UserGroupNum = "+POut.Long(userGroup.UserGroupNum);
			Db.NonQ(command);
		}

		///<summary>Updates one UserGroup in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(UserGroup userGroup,UserGroup oldUserGroup) {
			string command="";
			if(userGroup.Description != oldUserGroup.Description) {
				if(command!="") { command+=",";}
				command+="Description = '"+POut.String(userGroup.Description)+"'";
			}
			if(userGroup.UserGroupNumCEMT != oldUserGroup.UserGroupNumCEMT) {
				if(command!="") { command+=",";}
				command+="UserGroupNumCEMT = "+POut.Long(userGroup.UserGroupNumCEMT)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE usergroup SET "+command
				+" WHERE UserGroupNum = "+POut.Long(userGroup.UserGroupNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(UserGroup,UserGroup) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(UserGroup userGroup,UserGroup oldUserGroup) {
			if(userGroup.Description != oldUserGroup.Description) {
				return true;
			}
			if(userGroup.UserGroupNumCEMT != oldUserGroup.UserGroupNumCEMT) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one UserGroup from the database.</summary>
		public static void Delete(long userGroupNum) {
			string command="DELETE FROM usergroup "
				+"WHERE UserGroupNum = "+POut.Long(userGroupNum);
			Db.NonQ(command);
		}

	}
}