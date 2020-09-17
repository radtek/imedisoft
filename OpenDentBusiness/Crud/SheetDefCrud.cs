//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using Imedisoft.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class SheetDefCrud {
		///<summary>Gets one SheetDef object from the database using the primary key.  Returns null if not found.</summary>
		public static SheetDef SelectOne(long sheetDefNum) {
			string command="SELECT * FROM sheetdef "
				+"WHERE SheetDefNum = "+POut.Long(sheetDefNum);
			List<SheetDef> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one SheetDef object from the database using a query.</summary>
		public static SheetDef SelectOne(string command) {

			List<SheetDef> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of SheetDef objects from the database using a query.</summary>
		public static List<SheetDef> SelectMany(string command) {

			List<SheetDef> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<SheetDef> TableToList(DataTable table) {
			List<SheetDef> retVal=new List<SheetDef>();
			SheetDef sheetDef;
			foreach(DataRow row in table.Rows) {
				sheetDef=new SheetDef();
				sheetDef.SheetDefNum     = PIn.Long  (row["SheetDefNum"].ToString());
				sheetDef.Description     = PIn.String(row["Description"].ToString());
				sheetDef.SheetType       = (OpenDentBusiness.SheetTypeEnum)PIn.Int(row["SheetType"].ToString());
				sheetDef.FontSize        = PIn.Float (row["FontSize"].ToString());
				sheetDef.FontName        = PIn.String(row["FontName"].ToString());
				sheetDef.Width           = PIn.Int   (row["Width"].ToString());
				sheetDef.Height          = PIn.Int   (row["Height"].ToString());
				sheetDef.IsLandscape     = PIn.Bool  (row["IsLandscape"].ToString());
				sheetDef.PageCount       = PIn.Int   (row["PageCount"].ToString());
				sheetDef.IsMultiPage     = PIn.Bool  (row["IsMultiPage"].ToString());
				sheetDef.BypassGlobalLock= (BypassLockStatus)PIn.Int(row["BypassGlobalLock"].ToString());
				sheetDef.HasMobileLayout = PIn.Bool  (row["HasMobileLayout"].ToString());
				sheetDef.DateTCreated    = PIn.Date (row["DateTCreated"].ToString());
				retVal.Add(sheetDef);
			}
			return retVal;
		}

		///<summary>Converts a list of SheetDef into a DataTable.</summary>
		public static DataTable ListToTable(List<SheetDef> listSheetDefs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="SheetDef";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("SheetDefNum");
			table.Columns.Add("Description");
			table.Columns.Add("SheetType");
			table.Columns.Add("FontSize");
			table.Columns.Add("FontName");
			table.Columns.Add("Width");
			table.Columns.Add("Height");
			table.Columns.Add("IsLandscape");
			table.Columns.Add("PageCount");
			table.Columns.Add("IsMultiPage");
			table.Columns.Add("BypassGlobalLock");
			table.Columns.Add("HasMobileLayout");
			table.Columns.Add("DateTCreated");
			foreach(SheetDef sheetDef in listSheetDefs) {
				table.Rows.Add(new object[] {
					POut.Long  (sheetDef.SheetDefNum),
					            sheetDef.Description,
					POut.Int   ((int)sheetDef.SheetType),
					POut.Float (sheetDef.FontSize),
					            sheetDef.FontName,
					POut.Int   (sheetDef.Width),
					POut.Int   (sheetDef.Height),
					POut.Bool  (sheetDef.IsLandscape),
					POut.Int   (sheetDef.PageCount),
					POut.Bool  (sheetDef.IsMultiPage),
					POut.Int   ((int)sheetDef.BypassGlobalLock),
					POut.Bool  (sheetDef.HasMobileLayout),
					POut.DateT (sheetDef.DateTCreated,false),
				});
			}
			return table;
		}

		///<summary>Inserts one SheetDef into the database.  Returns the new priKey.</summary>
		public static long Insert(SheetDef sheetDef) {
			return Insert(sheetDef,false);
		}

		///<summary>Inserts one SheetDef into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(SheetDef sheetDef,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				sheetDef.SheetDefNum=ReplicationServers.GetKey("sheetdef","SheetDefNum");
			}
			string command="INSERT INTO sheetdef (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SheetDefNum,";
			}
			command+="Description,SheetType,FontSize,FontName,Width,Height,IsLandscape,PageCount,IsMultiPage,BypassGlobalLock,HasMobileLayout,DateTCreated) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(sheetDef.SheetDefNum)+",";
			}
			command+=
				 "'"+POut.String(sheetDef.Description)+"',"
				+    POut.Int   ((int)sheetDef.SheetType)+","
				+    POut.Float (sheetDef.FontSize)+","
				+"'"+POut.String(sheetDef.FontName)+"',"
				+    POut.Int   (sheetDef.Width)+","
				+    POut.Int   (sheetDef.Height)+","
				+    POut.Bool  (sheetDef.IsLandscape)+","
				+    POut.Int   (sheetDef.PageCount)+","
				+    POut.Bool  (sheetDef.IsMultiPage)+","
				+    POut.Int   ((int)sheetDef.BypassGlobalLock)+","
				+    POut.Bool  (sheetDef.HasMobileLayout)+","
				+    POut.DateT (sheetDef.DateTCreated)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				sheetDef.SheetDefNum=Database.ExecuteInsert(command);
			}
			return sheetDef.SheetDefNum;
		}

		///<summary>Inserts one SheetDef into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SheetDef sheetDef) {
			return InsertNoCache(sheetDef,false);
		}

		///<summary>Inserts one SheetDef into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SheetDef sheetDef,bool useExistingPK) {
			
			string command="INSERT INTO sheetdef (";
			if(!useExistingPK) {
				sheetDef.SheetDefNum=ReplicationServers.GetKeyNoCache("sheetdef","SheetDefNum");
			}
			if(useExistingPK) {
				command+="SheetDefNum,";
			}
			command+="Description,SheetType,FontSize,FontName,Width,Height,IsLandscape,PageCount,IsMultiPage,BypassGlobalLock,HasMobileLayout,DateTCreated) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(sheetDef.SheetDefNum)+",";
			}
			command+=
				 "'"+POut.String(sheetDef.Description)+"',"
				+    POut.Int   ((int)sheetDef.SheetType)+","
				+    POut.Float (sheetDef.FontSize)+","
				+"'"+POut.String(sheetDef.FontName)+"',"
				+    POut.Int   (sheetDef.Width)+","
				+    POut.Int   (sheetDef.Height)+","
				+    POut.Bool  (sheetDef.IsLandscape)+","
				+    POut.Int   (sheetDef.PageCount)+","
				+    POut.Bool  (sheetDef.IsMultiPage)+","
				+    POut.Int   ((int)sheetDef.BypassGlobalLock)+","
				+    POut.Bool  (sheetDef.HasMobileLayout)+","
				+    POut.DateT (sheetDef.DateTCreated)+")";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				sheetDef.SheetDefNum=Database.ExecuteInsert(command);
			}
			return sheetDef.SheetDefNum;
		}

		///<summary>Updates one SheetDef in the database.</summary>
		public static void Update(SheetDef sheetDef) {
			string command="UPDATE sheetdef SET "
				+"Description     = '"+POut.String(sheetDef.Description)+"', "
				+"SheetType       =  "+POut.Int   ((int)sheetDef.SheetType)+", "
				+"FontSize        =  "+POut.Float (sheetDef.FontSize)+", "
				+"FontName        = '"+POut.String(sheetDef.FontName)+"', "
				+"Width           =  "+POut.Int   (sheetDef.Width)+", "
				+"Height          =  "+POut.Int   (sheetDef.Height)+", "
				+"IsLandscape     =  "+POut.Bool  (sheetDef.IsLandscape)+", "
				+"PageCount       =  "+POut.Int   (sheetDef.PageCount)+", "
				+"IsMultiPage     =  "+POut.Bool  (sheetDef.IsMultiPage)+", "
				+"BypassGlobalLock=  "+POut.Int   ((int)sheetDef.BypassGlobalLock)+", "
				+"HasMobileLayout =  "+POut.Bool  (sheetDef.HasMobileLayout)+", "
				+"DateTCreated    =  "+POut.DateT (sheetDef.DateTCreated)+" "
				+"WHERE SheetDefNum = "+POut.Long(sheetDef.SheetDefNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one SheetDef in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(SheetDef sheetDef,SheetDef oldSheetDef) {
			string command="";
			if(sheetDef.Description != oldSheetDef.Description) {
				if(command!="") { command+=",";}
				command+="Description = '"+POut.String(sheetDef.Description)+"'";
			}
			if(sheetDef.SheetType != oldSheetDef.SheetType) {
				if(command!="") { command+=",";}
				command+="SheetType = "+POut.Int   ((int)sheetDef.SheetType)+"";
			}
			if(sheetDef.FontSize != oldSheetDef.FontSize) {
				if(command!="") { command+=",";}
				command+="FontSize = "+POut.Float(sheetDef.FontSize)+"";
			}
			if(sheetDef.FontName != oldSheetDef.FontName) {
				if(command!="") { command+=",";}
				command+="FontName = '"+POut.String(sheetDef.FontName)+"'";
			}
			if(sheetDef.Width != oldSheetDef.Width) {
				if(command!="") { command+=",";}
				command+="Width = "+POut.Int(sheetDef.Width)+"";
			}
			if(sheetDef.Height != oldSheetDef.Height) {
				if(command!="") { command+=",";}
				command+="Height = "+POut.Int(sheetDef.Height)+"";
			}
			if(sheetDef.IsLandscape != oldSheetDef.IsLandscape) {
				if(command!="") { command+=",";}
				command+="IsLandscape = "+POut.Bool(sheetDef.IsLandscape)+"";
			}
			if(sheetDef.PageCount != oldSheetDef.PageCount) {
				if(command!="") { command+=",";}
				command+="PageCount = "+POut.Int(sheetDef.PageCount)+"";
			}
			if(sheetDef.IsMultiPage != oldSheetDef.IsMultiPage) {
				if(command!="") { command+=",";}
				command+="IsMultiPage = "+POut.Bool(sheetDef.IsMultiPage)+"";
			}
			if(sheetDef.BypassGlobalLock != oldSheetDef.BypassGlobalLock) {
				if(command!="") { command+=",";}
				command+="BypassGlobalLock = "+POut.Int   ((int)sheetDef.BypassGlobalLock)+"";
			}
			if(sheetDef.HasMobileLayout != oldSheetDef.HasMobileLayout) {
				if(command!="") { command+=",";}
				command+="HasMobileLayout = "+POut.Bool(sheetDef.HasMobileLayout)+"";
			}
			if(sheetDef.DateTCreated != oldSheetDef.DateTCreated) {
				if(command!="") { command+=",";}
				command+="DateTCreated = "+POut.DateT(sheetDef.DateTCreated)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE sheetdef SET "+command
				+" WHERE SheetDefNum = "+POut.Long(sheetDef.SheetDefNum);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(SheetDef,SheetDef) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(SheetDef sheetDef,SheetDef oldSheetDef) {
			if(sheetDef.Description != oldSheetDef.Description) {
				return true;
			}
			if(sheetDef.SheetType != oldSheetDef.SheetType) {
				return true;
			}
			if(sheetDef.FontSize != oldSheetDef.FontSize) {
				return true;
			}
			if(sheetDef.FontName != oldSheetDef.FontName) {
				return true;
			}
			if(sheetDef.Width != oldSheetDef.Width) {
				return true;
			}
			if(sheetDef.Height != oldSheetDef.Height) {
				return true;
			}
			if(sheetDef.IsLandscape != oldSheetDef.IsLandscape) {
				return true;
			}
			if(sheetDef.PageCount != oldSheetDef.PageCount) {
				return true;
			}
			if(sheetDef.IsMultiPage != oldSheetDef.IsMultiPage) {
				return true;
			}
			if(sheetDef.BypassGlobalLock != oldSheetDef.BypassGlobalLock) {
				return true;
			}
			if(sheetDef.HasMobileLayout != oldSheetDef.HasMobileLayout) {
				return true;
			}
			if(sheetDef.DateTCreated != oldSheetDef.DateTCreated) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one SheetDef from the database.</summary>
		public static void Delete(long sheetDefNum) {
			string command="DELETE FROM sheetdef "
				+"WHERE SheetDefNum = "+POut.Long(sheetDefNum);
			Database.ExecuteNonQuery(command);
		}

	}
}