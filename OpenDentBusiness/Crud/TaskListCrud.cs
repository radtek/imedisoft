//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class TaskListCrud {
		///<summary>Gets one TaskList object from the database using the primary key.  Returns null if not found.</summary>
		public static TaskList SelectOne(long taskListNum) {
			string command="SELECT * FROM tasklist "
				+"WHERE TaskListNum = "+POut.Long(taskListNum);
			List<TaskList> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one TaskList object from the database using a query.</summary>
		public static TaskList SelectOne(string command) {

			List<TaskList> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of TaskList objects from the database using a query.</summary>
		public static List<TaskList> SelectMany(string command) {

			List<TaskList> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<TaskList> TableToList(DataTable table) {
			List<TaskList> retVal=new List<TaskList>();
			TaskList taskList;
			foreach(DataRow row in table.Rows) {
				taskList=new TaskList();
				taskList.TaskListNum         = PIn.Long  (row["TaskListNum"].ToString());
				taskList.Descript            = PIn.String(row["Descript"].ToString());
				taskList.Parent              = PIn.Long  (row["Parent"].ToString());
				taskList.DateTL              = PIn.Date  (row["DateTL"].ToString());
				taskList.IsRepeating         = PIn.Bool  (row["IsRepeating"].ToString());
				taskList.DateType            = (OpenDentBusiness.TaskDateType)PIn.Int(row["DateType"].ToString());
				taskList.FromNum             = PIn.Long  (row["FromNum"].ToString());
				taskList.ObjectType          = (OpenDentBusiness.TaskObjectType)PIn.Int(row["ObjectType"].ToString());
				taskList.DateTimeEntry       = PIn.DateT (row["DateTimeEntry"].ToString());
				taskList.GlobalTaskFilterType= (OpenDentBusiness.GlobalTaskFilterType)PIn.Int(row["GlobalTaskFilterType"].ToString());
				taskList.TaskListStatus      = (OpenDentBusiness.TaskListStatusEnum)PIn.Int(row["TaskListStatus"].ToString());
				retVal.Add(taskList);
			}
			return retVal;
		}

		///<summary>Converts a list of TaskList into a DataTable.</summary>
		public static DataTable ListToTable(List<TaskList> listTaskLists,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="TaskList";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("TaskListNum");
			table.Columns.Add("Descript");
			table.Columns.Add("Parent");
			table.Columns.Add("DateTL");
			table.Columns.Add("IsRepeating");
			table.Columns.Add("DateType");
			table.Columns.Add("FromNum");
			table.Columns.Add("ObjectType");
			table.Columns.Add("DateTimeEntry");
			table.Columns.Add("GlobalTaskFilterType");
			table.Columns.Add("TaskListStatus");
			foreach(TaskList taskList in listTaskLists) {
				table.Rows.Add(new object[] {
					POut.Long  (taskList.TaskListNum),
					            taskList.Descript,
					POut.Long  (taskList.Parent),
					POut.DateT (taskList.DateTL,false),
					POut.Bool  (taskList.IsRepeating),
					POut.Int   ((int)taskList.DateType),
					POut.Long  (taskList.FromNum),
					POut.Int   ((int)taskList.ObjectType),
					POut.DateT (taskList.DateTimeEntry,false),
					POut.Int   ((int)taskList.GlobalTaskFilterType),
					POut.Int   ((int)taskList.TaskListStatus),
				});
			}
			return table;
		}

		///<summary>Inserts one TaskList into the database.  Returns the new priKey.</summary>
		public static long Insert(TaskList taskList) {
			return Insert(taskList,false);
		}

		///<summary>Inserts one TaskList into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(TaskList taskList,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				taskList.TaskListNum=ReplicationServers.GetKey("tasklist","TaskListNum");
			}
			string command="INSERT INTO tasklist (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="TaskListNum,";
			}
			command+="Descript,Parent,DateTL,IsRepeating,DateType,FromNum,ObjectType,DateTimeEntry,GlobalTaskFilterType,TaskListStatus) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(taskList.TaskListNum)+",";
			}
			command+=
				 "'"+POut.String(taskList.Descript)+"',"
				+    POut.Long  (taskList.Parent)+","
				+    POut.Date  (taskList.DateTL)+","
				+    POut.Bool  (taskList.IsRepeating)+","
				+    POut.Int   ((int)taskList.DateType)+","
				+    POut.Long  (taskList.FromNum)+","
				+    POut.Int   ((int)taskList.ObjectType)+","
				+    DbHelper.Now()+","
				+    POut.Int   ((int)taskList.GlobalTaskFilterType)+","
				+    POut.Int   ((int)taskList.TaskListStatus)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				taskList.TaskListNum=Db.NonQ(command,true,"TaskListNum","taskList");
			}
			return taskList.TaskListNum;
		}

		///<summary>Inserts one TaskList into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(TaskList taskList) {
			return InsertNoCache(taskList,false);
		}

		///<summary>Inserts one TaskList into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(TaskList taskList,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO tasklist (";
			if(!useExistingPK && isRandomKeys) {
				taskList.TaskListNum=ReplicationServers.GetKeyNoCache("tasklist","TaskListNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="TaskListNum,";
			}
			command+="Descript,Parent,DateTL,IsRepeating,DateType,FromNum,ObjectType,DateTimeEntry,GlobalTaskFilterType,TaskListStatus) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(taskList.TaskListNum)+",";
			}
			command+=
				 "'"+POut.String(taskList.Descript)+"',"
				+    POut.Long  (taskList.Parent)+","
				+    POut.Date  (taskList.DateTL)+","
				+    POut.Bool  (taskList.IsRepeating)+","
				+    POut.Int   ((int)taskList.DateType)+","
				+    POut.Long  (taskList.FromNum)+","
				+    POut.Int   ((int)taskList.ObjectType)+","
				+    DbHelper.Now()+","
				+    POut.Int   ((int)taskList.GlobalTaskFilterType)+","
				+    POut.Int   ((int)taskList.TaskListStatus)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				taskList.TaskListNum=Db.NonQ(command,true,"TaskListNum","taskList");
			}
			return taskList.TaskListNum;
		}

		///<summary>Updates one TaskList in the database.</summary>
		public static void Update(TaskList taskList) {
			string command="UPDATE tasklist SET "
				+"Descript            = '"+POut.String(taskList.Descript)+"', "
				+"Parent              =  "+POut.Long  (taskList.Parent)+", "
				+"DateTL              =  "+POut.Date  (taskList.DateTL)+", "
				+"IsRepeating         =  "+POut.Bool  (taskList.IsRepeating)+", "
				+"DateType            =  "+POut.Int   ((int)taskList.DateType)+", "
				+"FromNum             =  "+POut.Long  (taskList.FromNum)+", "
				+"ObjectType          =  "+POut.Int   ((int)taskList.ObjectType)+", "
				+"DateTimeEntry       =  "+POut.DateT (taskList.DateTimeEntry)+", "
				+"GlobalTaskFilterType=  "+POut.Int   ((int)taskList.GlobalTaskFilterType)+", "
				+"TaskListStatus      =  "+POut.Int   ((int)taskList.TaskListStatus)+" "
				+"WHERE TaskListNum = "+POut.Long(taskList.TaskListNum);
			Db.NonQ(command);
		}

		///<summary>Updates one TaskList in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(TaskList taskList,TaskList oldTaskList) {
			string command="";
			if(taskList.Descript != oldTaskList.Descript) {
				if(command!="") { command+=",";}
				command+="Descript = '"+POut.String(taskList.Descript)+"'";
			}
			if(taskList.Parent != oldTaskList.Parent) {
				if(command!="") { command+=",";}
				command+="Parent = "+POut.Long(taskList.Parent)+"";
			}
			if(taskList.DateTL.Date != oldTaskList.DateTL.Date) {
				if(command!="") { command+=",";}
				command+="DateTL = "+POut.Date(taskList.DateTL)+"";
			}
			if(taskList.IsRepeating != oldTaskList.IsRepeating) {
				if(command!="") { command+=",";}
				command+="IsRepeating = "+POut.Bool(taskList.IsRepeating)+"";
			}
			if(taskList.DateType != oldTaskList.DateType) {
				if(command!="") { command+=",";}
				command+="DateType = "+POut.Int   ((int)taskList.DateType)+"";
			}
			if(taskList.FromNum != oldTaskList.FromNum) {
				if(command!="") { command+=",";}
				command+="FromNum = "+POut.Long(taskList.FromNum)+"";
			}
			if(taskList.ObjectType != oldTaskList.ObjectType) {
				if(command!="") { command+=",";}
				command+="ObjectType = "+POut.Int   ((int)taskList.ObjectType)+"";
			}
			if(taskList.DateTimeEntry != oldTaskList.DateTimeEntry) {
				if(command!="") { command+=",";}
				command+="DateTimeEntry = "+POut.DateT(taskList.DateTimeEntry)+"";
			}
			if(taskList.GlobalTaskFilterType != oldTaskList.GlobalTaskFilterType) {
				if(command!="") { command+=",";}
				command+="GlobalTaskFilterType = "+POut.Int   ((int)taskList.GlobalTaskFilterType)+"";
			}
			if(taskList.TaskListStatus != oldTaskList.TaskListStatus) {
				if(command!="") { command+=",";}
				command+="TaskListStatus = "+POut.Int   ((int)taskList.TaskListStatus)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE tasklist SET "+command
				+" WHERE TaskListNum = "+POut.Long(taskList.TaskListNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(TaskList,TaskList) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(TaskList taskList,TaskList oldTaskList) {
			if(taskList.Descript != oldTaskList.Descript) {
				return true;
			}
			if(taskList.Parent != oldTaskList.Parent) {
				return true;
			}
			if(taskList.DateTL.Date != oldTaskList.DateTL.Date) {
				return true;
			}
			if(taskList.IsRepeating != oldTaskList.IsRepeating) {
				return true;
			}
			if(taskList.DateType != oldTaskList.DateType) {
				return true;
			}
			if(taskList.FromNum != oldTaskList.FromNum) {
				return true;
			}
			if(taskList.ObjectType != oldTaskList.ObjectType) {
				return true;
			}
			if(taskList.DateTimeEntry != oldTaskList.DateTimeEntry) {
				return true;
			}
			if(taskList.GlobalTaskFilterType != oldTaskList.GlobalTaskFilterType) {
				return true;
			}
			if(taskList.TaskListStatus != oldTaskList.TaskListStatus) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one TaskList from the database.</summary>
		public static void Delete(long taskListNum) {
			string command="DELETE FROM tasklist "
				+"WHERE TaskListNum = "+POut.Long(taskListNum);
			Db.NonQ(command);
		}

	}
}