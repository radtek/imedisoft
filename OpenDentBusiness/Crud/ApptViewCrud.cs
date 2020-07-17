//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ApptViewCrud {
		///<summary>Gets one ApptView object from the database using the primary key.  Returns null if not found.</summary>
		public static ApptView SelectOne(long apptViewNum) {
			string command="SELECT * FROM apptview "
				+"WHERE ApptViewNum = "+POut.Long(apptViewNum);
			List<ApptView> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ApptView object from the database using a query.</summary>
		public static ApptView SelectOne(string command) {
			List<ApptView> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ApptView objects from the database using a query.</summary>
		public static List<ApptView> SelectMany(string command) {
			List<ApptView> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ApptView> TableToList(DataTable table) {
			List<ApptView> retVal=new List<ApptView>();
			ApptView apptView;
			foreach(DataRow row in table.Rows) {
				apptView=new ApptView();
				apptView.ApptViewNum          = PIn.Long  (row["ApptViewNum"].ToString());
				apptView.Description          = PIn.String(row["Description"].ToString());
				apptView.ItemOrder            = PIn.Int   (row["ItemOrder"].ToString());
				apptView.RowsPerIncr          = PIn.Byte  (row["RowsPerIncr"].ToString());
				apptView.OnlyScheduledProvs   = PIn.Bool  (row["OnlyScheduledProvs"].ToString());
				apptView.OnlySchedBeforeTime  = PIn.Time(row["OnlySchedBeforeTime"].ToString());
				apptView.OnlySchedAfterTime   = PIn.Time(row["OnlySchedAfterTime"].ToString());
				apptView.StackBehavUR         = (OpenDentBusiness.ApptViewStackBehavior)PIn.Int(row["StackBehavUR"].ToString());
				apptView.StackBehavLR         = (OpenDentBusiness.ApptViewStackBehavior)PIn.Int(row["StackBehavLR"].ToString());
				apptView.ClinicNum            = PIn.Long  (row["ClinicNum"].ToString());
				apptView.ApptTimeScrollStart  = PIn.Time(row["ApptTimeScrollStart"].ToString());
				apptView.IsScrollStartDynamic = PIn.Bool  (row["IsScrollStartDynamic"].ToString());
				apptView.IsApptBubblesDisabled= PIn.Bool  (row["IsApptBubblesDisabled"].ToString());
				apptView.WidthOpMinimum       = PIn.Int   (row["WidthOpMinimum"].ToString());
				retVal.Add(apptView);
			}
			return retVal;
		}

		///<summary>Converts a list of ApptView into a DataTable.</summary>
		public static DataTable ListToTable(List<ApptView> listApptViews,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ApptView";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ApptViewNum");
			table.Columns.Add("Description");
			table.Columns.Add("ItemOrder");
			table.Columns.Add("RowsPerIncr");
			table.Columns.Add("OnlyScheduledProvs");
			table.Columns.Add("OnlySchedBeforeTime");
			table.Columns.Add("OnlySchedAfterTime");
			table.Columns.Add("StackBehavUR");
			table.Columns.Add("StackBehavLR");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("ApptTimeScrollStart");
			table.Columns.Add("IsScrollStartDynamic");
			table.Columns.Add("IsApptBubblesDisabled");
			table.Columns.Add("WidthOpMinimum");
			foreach(ApptView apptView in listApptViews) {
				table.Rows.Add(new object[] {
					POut.Long  (apptView.ApptViewNum),
					            apptView.Description,
					POut.Int   (apptView.ItemOrder),
					POut.Byte  (apptView.RowsPerIncr),
					POut.Bool  (apptView.OnlyScheduledProvs),
					POut.Time  (apptView.OnlySchedBeforeTime,false),
					POut.Time  (apptView.OnlySchedAfterTime,false),
					POut.Int   ((int)apptView.StackBehavUR),
					POut.Int   ((int)apptView.StackBehavLR),
					POut.Long  (apptView.ClinicNum),
					POut.Time  (apptView.ApptTimeScrollStart,false),
					POut.Bool  (apptView.IsScrollStartDynamic),
					POut.Bool  (apptView.IsApptBubblesDisabled),
					POut.Int   (apptView.WidthOpMinimum),
				});
			}
			return table;
		}

		///<summary>Inserts one ApptView into the database.  Returns the new priKey.</summary>
		public static long Insert(ApptView apptView) {
			return Insert(apptView,false);
		}

		///<summary>Inserts one ApptView into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ApptView apptView,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				apptView.ApptViewNum=ReplicationServers.GetKey("apptview","ApptViewNum");
			}
			string command="INSERT INTO apptview (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ApptViewNum,";
			}
			command+="Description,ItemOrder,RowsPerIncr,OnlyScheduledProvs,OnlySchedBeforeTime,OnlySchedAfterTime,StackBehavUR,StackBehavLR,ClinicNum,ApptTimeScrollStart,IsScrollStartDynamic,IsApptBubblesDisabled,WidthOpMinimum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(apptView.ApptViewNum)+",";
			}
			command+=
				 "'"+POut.String(apptView.Description)+"',"
				+    POut.Int   (apptView.ItemOrder)+","
				+    POut.Byte  (apptView.RowsPerIncr)+","
				+    POut.Bool  (apptView.OnlyScheduledProvs)+","
				+    POut.Time  (apptView.OnlySchedBeforeTime)+","
				+    POut.Time  (apptView.OnlySchedAfterTime)+","
				+    POut.Int   ((int)apptView.StackBehavUR)+","
				+    POut.Int   ((int)apptView.StackBehavLR)+","
				+    POut.Long  (apptView.ClinicNum)+","
				+    POut.Time  (apptView.ApptTimeScrollStart)+","
				+    POut.Bool  (apptView.IsScrollStartDynamic)+","
				+    POut.Bool  (apptView.IsApptBubblesDisabled)+","
				+    POut.Int   (apptView.WidthOpMinimum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				apptView.ApptViewNum=Database.ExecuteInsert(command);
			}
			return apptView.ApptViewNum;
		}

		///<summary>Inserts one ApptView into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptView apptView) {
			return InsertNoCache(apptView,false);
		}

		///<summary>Inserts one ApptView into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptView apptView,bool useExistingPK) {
			
			string command="INSERT INTO apptview (";
			if(!useExistingPK) {
				apptView.ApptViewNum=ReplicationServers.GetKeyNoCache("apptview","ApptViewNum");
			}
			if(useExistingPK) {
				command+="ApptViewNum,";
			}
			command+="Description,ItemOrder,RowsPerIncr,OnlyScheduledProvs,OnlySchedBeforeTime,OnlySchedAfterTime,StackBehavUR,StackBehavLR,ClinicNum,ApptTimeScrollStart,IsScrollStartDynamic,IsApptBubblesDisabled,WidthOpMinimum) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(apptView.ApptViewNum)+",";
			}
			command+=
				 "'"+POut.String(apptView.Description)+"',"
				+    POut.Int   (apptView.ItemOrder)+","
				+    POut.Byte  (apptView.RowsPerIncr)+","
				+    POut.Bool  (apptView.OnlyScheduledProvs)+","
				+    POut.Time  (apptView.OnlySchedBeforeTime)+","
				+    POut.Time  (apptView.OnlySchedAfterTime)+","
				+    POut.Int   ((int)apptView.StackBehavUR)+","
				+    POut.Int   ((int)apptView.StackBehavLR)+","
				+    POut.Long  (apptView.ClinicNum)+","
				+    POut.Time  (apptView.ApptTimeScrollStart)+","
				+    POut.Bool  (apptView.IsScrollStartDynamic)+","
				+    POut.Bool  (apptView.IsApptBubblesDisabled)+","
				+    POut.Int   (apptView.WidthOpMinimum)+")";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				apptView.ApptViewNum=Database.ExecuteInsert(command);
			}
			return apptView.ApptViewNum;
		}

		///<summary>Updates one ApptView in the database.</summary>
		public static void Update(ApptView apptView) {
			string command="UPDATE apptview SET "
				+"Description          = '"+POut.String(apptView.Description)+"', "
				+"ItemOrder            =  "+POut.Int   (apptView.ItemOrder)+", "
				+"RowsPerIncr          =  "+POut.Byte  (apptView.RowsPerIncr)+", "
				+"OnlyScheduledProvs   =  "+POut.Bool  (apptView.OnlyScheduledProvs)+", "
				+"OnlySchedBeforeTime  =  "+POut.Time  (apptView.OnlySchedBeforeTime)+", "
				+"OnlySchedAfterTime   =  "+POut.Time  (apptView.OnlySchedAfterTime)+", "
				+"StackBehavUR         =  "+POut.Int   ((int)apptView.StackBehavUR)+", "
				+"StackBehavLR         =  "+POut.Int   ((int)apptView.StackBehavLR)+", "
				+"ClinicNum            =  "+POut.Long  (apptView.ClinicNum)+", "
				+"ApptTimeScrollStart  =  "+POut.Time  (apptView.ApptTimeScrollStart)+", "
				+"IsScrollStartDynamic =  "+POut.Bool  (apptView.IsScrollStartDynamic)+", "
				+"IsApptBubblesDisabled=  "+POut.Bool  (apptView.IsApptBubblesDisabled)+", "
				+"WidthOpMinimum       =  "+POut.Int   (apptView.WidthOpMinimum)+" "
				+"WHERE ApptViewNum = "+POut.Long(apptView.ApptViewNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one ApptView in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ApptView apptView,ApptView oldApptView) {
			string command="";
			if(apptView.Description != oldApptView.Description) {
				if(command!="") { command+=",";}
				command+="Description = '"+POut.String(apptView.Description)+"'";
			}
			if(apptView.ItemOrder != oldApptView.ItemOrder) {
				if(command!="") { command+=",";}
				command+="ItemOrder = "+POut.Int(apptView.ItemOrder)+"";
			}
			if(apptView.RowsPerIncr != oldApptView.RowsPerIncr) {
				if(command!="") { command+=",";}
				command+="RowsPerIncr = "+POut.Byte(apptView.RowsPerIncr)+"";
			}
			if(apptView.OnlyScheduledProvs != oldApptView.OnlyScheduledProvs) {
				if(command!="") { command+=",";}
				command+="OnlyScheduledProvs = "+POut.Bool(apptView.OnlyScheduledProvs)+"";
			}
			if(apptView.OnlySchedBeforeTime != oldApptView.OnlySchedBeforeTime) {
				if(command!="") { command+=",";}
				command+="OnlySchedBeforeTime = "+POut.Time  (apptView.OnlySchedBeforeTime)+"";
			}
			if(apptView.OnlySchedAfterTime != oldApptView.OnlySchedAfterTime) {
				if(command!="") { command+=",";}
				command+="OnlySchedAfterTime = "+POut.Time  (apptView.OnlySchedAfterTime)+"";
			}
			if(apptView.StackBehavUR != oldApptView.StackBehavUR) {
				if(command!="") { command+=",";}
				command+="StackBehavUR = "+POut.Int   ((int)apptView.StackBehavUR)+"";
			}
			if(apptView.StackBehavLR != oldApptView.StackBehavLR) {
				if(command!="") { command+=",";}
				command+="StackBehavLR = "+POut.Int   ((int)apptView.StackBehavLR)+"";
			}
			if(apptView.ClinicNum != oldApptView.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(apptView.ClinicNum)+"";
			}
			if(apptView.ApptTimeScrollStart != oldApptView.ApptTimeScrollStart) {
				if(command!="") { command+=",";}
				command+="ApptTimeScrollStart = "+POut.Time  (apptView.ApptTimeScrollStart)+"";
			}
			if(apptView.IsScrollStartDynamic != oldApptView.IsScrollStartDynamic) {
				if(command!="") { command+=",";}
				command+="IsScrollStartDynamic = "+POut.Bool(apptView.IsScrollStartDynamic)+"";
			}
			if(apptView.IsApptBubblesDisabled != oldApptView.IsApptBubblesDisabled) {
				if(command!="") { command+=",";}
				command+="IsApptBubblesDisabled = "+POut.Bool(apptView.IsApptBubblesDisabled)+"";
			}
			if(apptView.WidthOpMinimum != oldApptView.WidthOpMinimum) {
				if(command!="") { command+=",";}
				command+="WidthOpMinimum = "+POut.Int(apptView.WidthOpMinimum)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE apptview SET "+command
				+" WHERE ApptViewNum = "+POut.Long(apptView.ApptViewNum);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(ApptView,ApptView) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ApptView apptView,ApptView oldApptView) {
			if(apptView.Description != oldApptView.Description) {
				return true;
			}
			if(apptView.ItemOrder != oldApptView.ItemOrder) {
				return true;
			}
			if(apptView.RowsPerIncr != oldApptView.RowsPerIncr) {
				return true;
			}
			if(apptView.OnlyScheduledProvs != oldApptView.OnlyScheduledProvs) {
				return true;
			}
			if(apptView.OnlySchedBeforeTime != oldApptView.OnlySchedBeforeTime) {
				return true;
			}
			if(apptView.OnlySchedAfterTime != oldApptView.OnlySchedAfterTime) {
				return true;
			}
			if(apptView.StackBehavUR != oldApptView.StackBehavUR) {
				return true;
			}
			if(apptView.StackBehavLR != oldApptView.StackBehavLR) {
				return true;
			}
			if(apptView.ClinicNum != oldApptView.ClinicNum) {
				return true;
			}
			if(apptView.ApptTimeScrollStart != oldApptView.ApptTimeScrollStart) {
				return true;
			}
			if(apptView.IsScrollStartDynamic != oldApptView.IsScrollStartDynamic) {
				return true;
			}
			if(apptView.IsApptBubblesDisabled != oldApptView.IsApptBubblesDisabled) {
				return true;
			}
			if(apptView.WidthOpMinimum != oldApptView.WidthOpMinimum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ApptView from the database.</summary>
		public static void Delete(long apptViewNum) {
			string command="DELETE FROM apptview "
				+"WHERE ApptViewNum = "+POut.Long(apptViewNum);
			Database.ExecuteNonQuery(command);
		}

	}
}