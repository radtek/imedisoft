//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ToolButItemCrud {
		///<summary>Gets one ToolButItem object from the database using the primary key.  Returns null if not found.</summary>
		public static ToolButItem SelectOne(long toolButItemNum) {
			string command="SELECT * FROM toolbutitem "
				+"WHERE ToolButItemNum = "+POut.Long(toolButItemNum);
			List<ToolButItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ToolButItem object from the database using a query.</summary>
		public static ToolButItem SelectOne(string command) {

			List<ToolButItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ToolButItem objects from the database using a query.</summary>
		public static List<ToolButItem> SelectMany(string command) {

			List<ToolButItem> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ToolButItem> TableToList(DataTable table) {
			List<ToolButItem> retVal=new List<ToolButItem>();
			ToolButItem toolButItem;
			foreach(DataRow row in table.Rows) {
				toolButItem=new ToolButItem();
				toolButItem.ToolButItemNum= PIn.Long  (row["ToolButItemNum"].ToString());
				toolButItem.ProgramNum    = PIn.Long  (row["ProgramNum"].ToString());
				toolButItem.ToolBar       = (OpenDentBusiness.ToolBarsAvail)PIn.Int(row["ToolBar"].ToString());
				toolButItem.ButtonText    = PIn.String(row["ButtonText"].ToString());
				retVal.Add(toolButItem);
			}
			return retVal;
		}

		///<summary>Converts a list of ToolButItem into a DataTable.</summary>
		public static DataTable ListToTable(List<ToolButItem> listToolButItems,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ToolButItem";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ToolButItemNum");
			table.Columns.Add("ProgramNum");
			table.Columns.Add("ToolBar");
			table.Columns.Add("ButtonText");
			foreach(ToolButItem toolButItem in listToolButItems) {
				table.Rows.Add(new object[] {
					POut.Long  (toolButItem.ToolButItemNum),
					POut.Long  (toolButItem.ProgramNum),
					POut.Int   ((int)toolButItem.ToolBar),
					            toolButItem.ButtonText,
				});
			}
			return table;
		}

		///<summary>Inserts one ToolButItem into the database.  Returns the new priKey.</summary>
		public static long Insert(ToolButItem toolButItem) {
			return Insert(toolButItem,false);
		}

		///<summary>Inserts one ToolButItem into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ToolButItem toolButItem,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				toolButItem.ToolButItemNum=ReplicationServers.GetKey("toolbutitem","ToolButItemNum");
			}
			string command="INSERT INTO toolbutitem (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ToolButItemNum,";
			}
			command+="ProgramNum,ToolBar,ButtonText) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(toolButItem.ToolButItemNum)+",";
			}
			command+=
				     POut.Long  (toolButItem.ProgramNum)+","
				+    POut.Int   ((int)toolButItem.ToolBar)+","
				+"'"+POut.String(toolButItem.ButtonText)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				toolButItem.ToolButItemNum=Db.NonQ(command,true,"ToolButItemNum","toolButItem");
			}
			return toolButItem.ToolButItemNum;
		}

		///<summary>Inserts one ToolButItem into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ToolButItem toolButItem) {
			return InsertNoCache(toolButItem,false);
		}

		///<summary>Inserts one ToolButItem into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ToolButItem toolButItem,bool useExistingPK) {
			
			string command="INSERT INTO toolbutitem (";
			if(!useExistingPK) {
				toolButItem.ToolButItemNum=ReplicationServers.GetKeyNoCache("toolbutitem","ToolButItemNum");
			}
			if(useExistingPK) {
				command+="ToolButItemNum,";
			}
			command+="ProgramNum,ToolBar,ButtonText) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(toolButItem.ToolButItemNum)+",";
			}
			command+=
				     POut.Long  (toolButItem.ProgramNum)+","
				+    POut.Int   ((int)toolButItem.ToolBar)+","
				+"'"+POut.String(toolButItem.ButtonText)+"')";
			if(useExistingPK) {
				Db.NonQ(command);
			}
			else {
				toolButItem.ToolButItemNum=Db.NonQ(command,true,"ToolButItemNum","toolButItem");
			}
			return toolButItem.ToolButItemNum;
		}

		///<summary>Updates one ToolButItem in the database.</summary>
		public static void Update(ToolButItem toolButItem) {
			string command="UPDATE toolbutitem SET "
				+"ProgramNum    =  "+POut.Long  (toolButItem.ProgramNum)+", "
				+"ToolBar       =  "+POut.Int   ((int)toolButItem.ToolBar)+", "
				+"ButtonText    = '"+POut.String(toolButItem.ButtonText)+"' "
				+"WHERE ToolButItemNum = "+POut.Long(toolButItem.ToolButItemNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ToolButItem in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ToolButItem toolButItem,ToolButItem oldToolButItem) {
			string command="";
			if(toolButItem.ProgramNum != oldToolButItem.ProgramNum) {
				if(command!="") { command+=",";}
				command+="ProgramNum = "+POut.Long(toolButItem.ProgramNum)+"";
			}
			if(toolButItem.ToolBar != oldToolButItem.ToolBar) {
				if(command!="") { command+=",";}
				command+="ToolBar = "+POut.Int   ((int)toolButItem.ToolBar)+"";
			}
			if(toolButItem.ButtonText != oldToolButItem.ButtonText) {
				if(command!="") { command+=",";}
				command+="ButtonText = '"+POut.String(toolButItem.ButtonText)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE toolbutitem SET "+command
				+" WHERE ToolButItemNum = "+POut.Long(toolButItem.ToolButItemNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(ToolButItem,ToolButItem) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ToolButItem toolButItem,ToolButItem oldToolButItem) {
			if(toolButItem.ProgramNum != oldToolButItem.ProgramNum) {
				return true;
			}
			if(toolButItem.ToolBar != oldToolButItem.ToolBar) {
				return true;
			}
			if(toolButItem.ButtonText != oldToolButItem.ButtonText) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ToolButItem from the database.</summary>
		public static void Delete(long toolButItemNum) {
			string command="DELETE FROM toolbutitem "
				+"WHERE ToolButItemNum = "+POut.Long(toolButItemNum);
			Db.NonQ(command);
		}

	}
}