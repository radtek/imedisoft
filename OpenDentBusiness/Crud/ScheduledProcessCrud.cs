//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ScheduledProcessCrud {
		///<summary>Gets one ScheduledProcess object from the database using the primary key.  Returns null if not found.</summary>
		public static ScheduledProcess SelectOne(long scheduledProcessNum) {
			string command="SELECT * FROM scheduledprocess "
				+"WHERE ScheduledProcessNum = "+POut.Long(scheduledProcessNum);
			List<ScheduledProcess> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ScheduledProcess object from the database using a query.</summary>
		public static ScheduledProcess SelectOne(string command) {

			List<ScheduledProcess> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ScheduledProcess objects from the database using a query.</summary>
		public static List<ScheduledProcess> SelectMany(string command) {

			List<ScheduledProcess> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ScheduledProcess> TableToList(DataTable table) {
			List<ScheduledProcess> retVal=new List<ScheduledProcess>();
			ScheduledProcess scheduledProcess;
			foreach(DataRow row in table.Rows) {
				scheduledProcess=new ScheduledProcess();
				scheduledProcess.ScheduledProcessNum= PIn.Long  (row["ScheduledProcessNum"].ToString());
				string scheduledAction=row["ScheduledAction"].ToString();
				if(scheduledAction=="") {
					scheduledProcess.ScheduledAction  =(OpenDentBusiness.ScheduledActionEnum)0;
				}
				else try{
					scheduledProcess.ScheduledAction  =(OpenDentBusiness.ScheduledActionEnum)Enum.Parse(typeof(OpenDentBusiness.ScheduledActionEnum),scheduledAction);
				}
				catch{
					scheduledProcess.ScheduledAction  =(OpenDentBusiness.ScheduledActionEnum)0;
				}
				scheduledProcess.TimeToRun          = PIn.DateT (row["TimeToRun"].ToString());
				string frequencyToRun=row["FrequencyToRun"].ToString();
				if(frequencyToRun=="") {
					scheduledProcess.FrequencyToRun   =(OpenDentBusiness.FrequencyToRunEnum)0;
				}
				else try{
					scheduledProcess.FrequencyToRun   =(OpenDentBusiness.FrequencyToRunEnum)Enum.Parse(typeof(OpenDentBusiness.FrequencyToRunEnum),frequencyToRun);
				}
				catch{
					scheduledProcess.FrequencyToRun   =(OpenDentBusiness.FrequencyToRunEnum)0;
				}
				scheduledProcess.LastRanDateTime    = PIn.DateT (row["LastRanDateTime"].ToString());
				retVal.Add(scheduledProcess);
			}
			return retVal;
		}

		///<summary>Converts a list of ScheduledProcess into a DataTable.</summary>
		public static DataTable ListToTable(List<ScheduledProcess> listScheduledProcesss,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ScheduledProcess";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ScheduledProcessNum");
			table.Columns.Add("ScheduledAction");
			table.Columns.Add("TimeToRun");
			table.Columns.Add("FrequencyToRun");
			table.Columns.Add("LastRanDateTime");
			foreach(ScheduledProcess scheduledProcess in listScheduledProcesss) {
				table.Rows.Add(new object[] {
					POut.Long  (scheduledProcess.ScheduledProcessNum),
					POut.Int   ((int)scheduledProcess.ScheduledAction),
					POut.DateT (scheduledProcess.TimeToRun,false),
					POut.Int   ((int)scheduledProcess.FrequencyToRun),
					POut.DateT (scheduledProcess.LastRanDateTime,false),
				});
			}
			return table;
		}

		///<summary>Inserts one ScheduledProcess into the database.  Returns the new priKey.</summary>
		public static long Insert(ScheduledProcess scheduledProcess) {
			return Insert(scheduledProcess,false);
		}

		///<summary>Inserts one ScheduledProcess into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ScheduledProcess scheduledProcess,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				scheduledProcess.ScheduledProcessNum=ReplicationServers.GetKey("scheduledprocess","ScheduledProcessNum");
			}
			string command="INSERT INTO scheduledprocess (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ScheduledProcessNum,";
			}
			command+="ScheduledAction,TimeToRun,FrequencyToRun,LastRanDateTime) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(scheduledProcess.ScheduledProcessNum)+",";
			}
			command+=
				 "'"+POut.String(scheduledProcess.ScheduledAction.ToString())+"',"
				+    POut.DateT (scheduledProcess.TimeToRun)+","
				+"'"+POut.String(scheduledProcess.FrequencyToRun.ToString())+"',"
				+    POut.DateT (scheduledProcess.LastRanDateTime)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				scheduledProcess.ScheduledProcessNum=Db.NonQ(command,true,"ScheduledProcessNum","scheduledProcess");
			}
			return scheduledProcess.ScheduledProcessNum;
		}

		///<summary>Inserts one ScheduledProcess into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ScheduledProcess scheduledProcess) {
			return InsertNoCache(scheduledProcess,false);
		}

		///<summary>Inserts one ScheduledProcess into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ScheduledProcess scheduledProcess,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO scheduledprocess (";
			if(!useExistingPK && isRandomKeys) {
				scheduledProcess.ScheduledProcessNum=ReplicationServers.GetKeyNoCache("scheduledprocess","ScheduledProcessNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ScheduledProcessNum,";
			}
			command+="ScheduledAction,TimeToRun,FrequencyToRun,LastRanDateTime) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(scheduledProcess.ScheduledProcessNum)+",";
			}
			command+=
				 "'"+POut.String(scheduledProcess.ScheduledAction.ToString())+"',"
				+    POut.DateT (scheduledProcess.TimeToRun)+","
				+"'"+POut.String(scheduledProcess.FrequencyToRun.ToString())+"',"
				+    POut.DateT (scheduledProcess.LastRanDateTime)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				scheduledProcess.ScheduledProcessNum=Db.NonQ(command,true,"ScheduledProcessNum","scheduledProcess");
			}
			return scheduledProcess.ScheduledProcessNum;
		}

		///<summary>Updates one ScheduledProcess in the database.</summary>
		public static void Update(ScheduledProcess scheduledProcess) {
			string command="UPDATE scheduledprocess SET "
				+"ScheduledAction    = '"+POut.String(scheduledProcess.ScheduledAction.ToString())+"', "
				+"TimeToRun          =  "+POut.DateT (scheduledProcess.TimeToRun)+", "
				+"FrequencyToRun     = '"+POut.String(scheduledProcess.FrequencyToRun.ToString())+"', "
				+"LastRanDateTime    =  "+POut.DateT (scheduledProcess.LastRanDateTime)+" "
				+"WHERE ScheduledProcessNum = "+POut.Long(scheduledProcess.ScheduledProcessNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ScheduledProcess in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ScheduledProcess scheduledProcess,ScheduledProcess oldScheduledProcess) {
			string command="";
			if(scheduledProcess.ScheduledAction != oldScheduledProcess.ScheduledAction) {
				if(command!="") { command+=",";}
				command+="ScheduledAction = '"+POut.String(scheduledProcess.ScheduledAction.ToString())+"'";
			}
			if(scheduledProcess.TimeToRun != oldScheduledProcess.TimeToRun) {
				if(command!="") { command+=",";}
				command+="TimeToRun = "+POut.DateT(scheduledProcess.TimeToRun)+"";
			}
			if(scheduledProcess.FrequencyToRun != oldScheduledProcess.FrequencyToRun) {
				if(command!="") { command+=",";}
				command+="FrequencyToRun = '"+POut.String(scheduledProcess.FrequencyToRun.ToString())+"'";
			}
			if(scheduledProcess.LastRanDateTime != oldScheduledProcess.LastRanDateTime) {
				if(command!="") { command+=",";}
				command+="LastRanDateTime = "+POut.DateT(scheduledProcess.LastRanDateTime)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE scheduledprocess SET "+command
				+" WHERE ScheduledProcessNum = "+POut.Long(scheduledProcess.ScheduledProcessNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(ScheduledProcess,ScheduledProcess) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ScheduledProcess scheduledProcess,ScheduledProcess oldScheduledProcess) {
			if(scheduledProcess.ScheduledAction != oldScheduledProcess.ScheduledAction) {
				return true;
			}
			if(scheduledProcess.TimeToRun != oldScheduledProcess.TimeToRun) {
				return true;
			}
			if(scheduledProcess.FrequencyToRun != oldScheduledProcess.FrequencyToRun) {
				return true;
			}
			if(scheduledProcess.LastRanDateTime != oldScheduledProcess.LastRanDateTime) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ScheduledProcess from the database.</summary>
		public static void Delete(long scheduledProcessNum) {
			string command="DELETE FROM scheduledprocess "
				+"WHERE ScheduledProcessNum = "+POut.Long(scheduledProcessNum);
			Db.NonQ(command);
		}

	}
}