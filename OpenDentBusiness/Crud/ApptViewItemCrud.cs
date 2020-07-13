//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ApptViewItemCrud {
		///<summary>Gets one ApptViewItem object from the database using the primary key.  Returns null if not found.</summary>
		public static ApptViewItem SelectOne(long apptViewItemNum) {
			string command="SELECT * FROM apptviewitem "
				+"WHERE ApptViewItemNum = "+POut.Long(apptViewItemNum);
			List<ApptViewItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ApptViewItem object from the database using a query.</summary>
		public static ApptViewItem SelectOne(string command) {
			List<ApptViewItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ApptViewItem objects from the database using a query.</summary>
		public static List<ApptViewItem> SelectMany(string command) {
			List<ApptViewItem> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ApptViewItem> TableToList(DataTable table) {
			List<ApptViewItem> retVal=new List<ApptViewItem>();
			ApptViewItem apptViewItem;
			foreach(DataRow row in table.Rows) {
				apptViewItem=new ApptViewItem();
				apptViewItem.ApptViewItemNum = PIn.Long  (row["ApptViewItemNum"].ToString());
				apptViewItem.ApptViewNum     = PIn.Long  (row["ApptViewNum"].ToString());
				apptViewItem.OpNum           = PIn.Long  (row["OpNum"].ToString());
				apptViewItem.ProvNum         = PIn.Long  (row["ProvNum"].ToString());
				apptViewItem.ElementDesc     = PIn.String(row["ElementDesc"].ToString());
				apptViewItem.ElementOrder    = PIn.Byte  (row["ElementOrder"].ToString());
				apptViewItem.ElementColor    = Color.FromArgb(PIn.Int(row["ElementColor"].ToString()));
				apptViewItem.ElementAlignment= (OpenDentBusiness.ApptViewAlignment)PIn.Int(row["ElementAlignment"].ToString());
				apptViewItem.ApptFieldDefNum = PIn.Long  (row["ApptFieldDefNum"].ToString());
				apptViewItem.PatFieldDefNum  = PIn.Long  (row["PatFieldDefNum"].ToString());
				retVal.Add(apptViewItem);
			}
			return retVal;
		}

		///<summary>Converts a list of ApptViewItem into a DataTable.</summary>
		public static DataTable ListToTable(List<ApptViewItem> listApptViewItems,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ApptViewItem";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ApptViewItemNum");
			table.Columns.Add("ApptViewNum");
			table.Columns.Add("OpNum");
			table.Columns.Add("ProvNum");
			table.Columns.Add("ElementDesc");
			table.Columns.Add("ElementOrder");
			table.Columns.Add("ElementColor");
			table.Columns.Add("ElementAlignment");
			table.Columns.Add("ApptFieldDefNum");
			table.Columns.Add("PatFieldDefNum");
			foreach(ApptViewItem apptViewItem in listApptViewItems) {
				table.Rows.Add(new object[] {
					POut.Long  (apptViewItem.ApptViewItemNum),
					POut.Long  (apptViewItem.ApptViewNum),
					POut.Long  (apptViewItem.OpNum),
					POut.Long  (apptViewItem.ProvNum),
					            apptViewItem.ElementDesc,
					POut.Byte  (apptViewItem.ElementOrder),
					POut.Int   (apptViewItem.ElementColor.ToArgb()),
					POut.Int   ((int)apptViewItem.ElementAlignment),
					POut.Long  (apptViewItem.ApptFieldDefNum),
					POut.Long  (apptViewItem.PatFieldDefNum),
				});
			}
			return table;
		}

		///<summary>Inserts one ApptViewItem into the database.  Returns the new priKey.</summary>
		public static long Insert(ApptViewItem apptViewItem) {
			return Insert(apptViewItem,false);
		}

		///<summary>Inserts one ApptViewItem into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ApptViewItem apptViewItem,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				apptViewItem.ApptViewItemNum=ReplicationServers.GetKey("apptviewitem","ApptViewItemNum");
			}
			string command="INSERT INTO apptviewitem (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ApptViewItemNum,";
			}
			command+="ApptViewNum,OpNum,ProvNum,ElementDesc,ElementOrder,ElementColor,ElementAlignment,ApptFieldDefNum,PatFieldDefNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(apptViewItem.ApptViewItemNum)+",";
			}
			command+=
				     POut.Long  (apptViewItem.ApptViewNum)+","
				+    POut.Long  (apptViewItem.OpNum)+","
				+    POut.Long  (apptViewItem.ProvNum)+","
				+"'"+POut.String(apptViewItem.ElementDesc)+"',"
				+    POut.Byte  (apptViewItem.ElementOrder)+","
				+    POut.Int   (apptViewItem.ElementColor.ToArgb())+","
				+    POut.Int   ((int)apptViewItem.ElementAlignment)+","
				+    POut.Long  (apptViewItem.ApptFieldDefNum)+","
				+    POut.Long  (apptViewItem.PatFieldDefNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				apptViewItem.ApptViewItemNum=Db.NonQ(command,true,"ApptViewItemNum","apptViewItem");
			}
			return apptViewItem.ApptViewItemNum;
		}

		///<summary>Inserts one ApptViewItem into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptViewItem apptViewItem) {
			return InsertNoCache(apptViewItem,false);
		}

		///<summary>Inserts one ApptViewItem into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptViewItem apptViewItem,bool useExistingPK) {
			
			string command="INSERT INTO apptviewitem (";
			if(!useExistingPK) {
				apptViewItem.ApptViewItemNum=ReplicationServers.GetKeyNoCache("apptviewitem","ApptViewItemNum");
			}
			if(useExistingPK) {
				command+="ApptViewItemNum,";
			}
			command+="ApptViewNum,OpNum,ProvNum,ElementDesc,ElementOrder,ElementColor,ElementAlignment,ApptFieldDefNum,PatFieldDefNum) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(apptViewItem.ApptViewItemNum)+",";
			}
			command+=
				     POut.Long  (apptViewItem.ApptViewNum)+","
				+    POut.Long  (apptViewItem.OpNum)+","
				+    POut.Long  (apptViewItem.ProvNum)+","
				+"'"+POut.String(apptViewItem.ElementDesc)+"',"
				+    POut.Byte  (apptViewItem.ElementOrder)+","
				+    POut.Int   (apptViewItem.ElementColor.ToArgb())+","
				+    POut.Int   ((int)apptViewItem.ElementAlignment)+","
				+    POut.Long  (apptViewItem.ApptFieldDefNum)+","
				+    POut.Long  (apptViewItem.PatFieldDefNum)+")";
			if(useExistingPK) {
				Db.NonQ(command);
			}
			else {
				apptViewItem.ApptViewItemNum=Db.NonQ(command,true,"ApptViewItemNum","apptViewItem");
			}
			return apptViewItem.ApptViewItemNum;
		}

		///<summary>Updates one ApptViewItem in the database.</summary>
		public static void Update(ApptViewItem apptViewItem) {
			string command="UPDATE apptviewitem SET "
				+"ApptViewNum     =  "+POut.Long  (apptViewItem.ApptViewNum)+", "
				+"OpNum           =  "+POut.Long  (apptViewItem.OpNum)+", "
				+"ProvNum         =  "+POut.Long  (apptViewItem.ProvNum)+", "
				+"ElementDesc     = '"+POut.String(apptViewItem.ElementDesc)+"', "
				+"ElementOrder    =  "+POut.Byte  (apptViewItem.ElementOrder)+", "
				+"ElementColor    =  "+POut.Int   (apptViewItem.ElementColor.ToArgb())+", "
				+"ElementAlignment=  "+POut.Int   ((int)apptViewItem.ElementAlignment)+", "
				+"ApptFieldDefNum =  "+POut.Long  (apptViewItem.ApptFieldDefNum)+", "
				+"PatFieldDefNum  =  "+POut.Long  (apptViewItem.PatFieldDefNum)+" "
				+"WHERE ApptViewItemNum = "+POut.Long(apptViewItem.ApptViewItemNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ApptViewItem in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ApptViewItem apptViewItem,ApptViewItem oldApptViewItem) {
			string command="";
			if(apptViewItem.ApptViewNum != oldApptViewItem.ApptViewNum) {
				if(command!="") { command+=",";}
				command+="ApptViewNum = "+POut.Long(apptViewItem.ApptViewNum)+"";
			}
			if(apptViewItem.OpNum != oldApptViewItem.OpNum) {
				if(command!="") { command+=",";}
				command+="OpNum = "+POut.Long(apptViewItem.OpNum)+"";
			}
			if(apptViewItem.ProvNum != oldApptViewItem.ProvNum) {
				if(command!="") { command+=",";}
				command+="ProvNum = "+POut.Long(apptViewItem.ProvNum)+"";
			}
			if(apptViewItem.ElementDesc != oldApptViewItem.ElementDesc) {
				if(command!="") { command+=",";}
				command+="ElementDesc = '"+POut.String(apptViewItem.ElementDesc)+"'";
			}
			if(apptViewItem.ElementOrder != oldApptViewItem.ElementOrder) {
				if(command!="") { command+=",";}
				command+="ElementOrder = "+POut.Byte(apptViewItem.ElementOrder)+"";
			}
			if(apptViewItem.ElementColor != oldApptViewItem.ElementColor) {
				if(command!="") { command+=",";}
				command+="ElementColor = "+POut.Int(apptViewItem.ElementColor.ToArgb())+"";
			}
			if(apptViewItem.ElementAlignment != oldApptViewItem.ElementAlignment) {
				if(command!="") { command+=",";}
				command+="ElementAlignment = "+POut.Int   ((int)apptViewItem.ElementAlignment)+"";
			}
			if(apptViewItem.ApptFieldDefNum != oldApptViewItem.ApptFieldDefNum) {
				if(command!="") { command+=",";}
				command+="ApptFieldDefNum = "+POut.Long(apptViewItem.ApptFieldDefNum)+"";
			}
			if(apptViewItem.PatFieldDefNum != oldApptViewItem.PatFieldDefNum) {
				if(command!="") { command+=",";}
				command+="PatFieldDefNum = "+POut.Long(apptViewItem.PatFieldDefNum)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE apptviewitem SET "+command
				+" WHERE ApptViewItemNum = "+POut.Long(apptViewItem.ApptViewItemNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(ApptViewItem,ApptViewItem) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ApptViewItem apptViewItem,ApptViewItem oldApptViewItem) {
			if(apptViewItem.ApptViewNum != oldApptViewItem.ApptViewNum) {
				return true;
			}
			if(apptViewItem.OpNum != oldApptViewItem.OpNum) {
				return true;
			}
			if(apptViewItem.ProvNum != oldApptViewItem.ProvNum) {
				return true;
			}
			if(apptViewItem.ElementDesc != oldApptViewItem.ElementDesc) {
				return true;
			}
			if(apptViewItem.ElementOrder != oldApptViewItem.ElementOrder) {
				return true;
			}
			if(apptViewItem.ElementColor != oldApptViewItem.ElementColor) {
				return true;
			}
			if(apptViewItem.ElementAlignment != oldApptViewItem.ElementAlignment) {
				return true;
			}
			if(apptViewItem.ApptFieldDefNum != oldApptViewItem.ApptFieldDefNum) {
				return true;
			}
			if(apptViewItem.PatFieldDefNum != oldApptViewItem.PatFieldDefNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ApptViewItem from the database.</summary>
		public static void Delete(long apptViewItemNum) {
			string command="DELETE FROM apptviewitem "
				+"WHERE ApptViewItemNum = "+POut.Long(apptViewItemNum);
			Db.NonQ(command);
		}

	}
}