//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace OpenDentBusiness.Crud{
	public class ScheduleCrud {
		///<summary>Gets one Schedule object from the database using the primary key.  Returns null if not found.</summary>
		public static Schedule SelectOne(long scheduleNum) {
			string command="SELECT * FROM schedule "
				+"WHERE ScheduleNum = "+POut.Long(scheduleNum);
			List<Schedule> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Schedule object from the database using a query.</summary>
		public static Schedule SelectOne(string command) {

			List<Schedule> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Schedule objects from the database using a query.</summary>
		public static List<Schedule> SelectMany(string command) {

			List<Schedule> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Schedule> TableToList(DataTable table) {
			List<Schedule> retVal=new List<Schedule>();
			Schedule schedule;
			foreach(DataRow row in table.Rows) {
				schedule=new Schedule();
				schedule.ScheduleNum = PIn.Long  (row["ScheduleNum"].ToString());
				schedule.SchedDate   = PIn.Date  (row["SchedDate"].ToString());
				schedule.StartTime   = PIn.Time(row["StartTime"].ToString());
				schedule.StopTime    = PIn.Time(row["StopTime"].ToString());
				schedule.SchedType   = (OpenDentBusiness.ScheduleType)PIn.Int(row["SchedType"].ToString());
				schedule.ProvNum     = PIn.Long  (row["ProvNum"].ToString());
				schedule.BlockoutType= PIn.Long  (row["BlockoutType"].ToString());
				schedule.Note        = PIn.String(row["Note"].ToString());
				schedule.Status      = (OpenDentBusiness.SchedStatus)PIn.Int(row["Status"].ToString());
				schedule.EmployeeNum = PIn.Long  (row["EmployeeNum"].ToString());
				schedule.DateTStamp  = PIn.Date (row["DateTStamp"].ToString());
				schedule.ClinicNum   = PIn.Long  (row["ClinicNum"].ToString());
				retVal.Add(schedule);
			}
			return retVal;
		}

		///<summary>Converts a list of Schedule into a DataTable.</summary>
		public static DataTable ListToTable(List<Schedule> listSchedules,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Schedule";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ScheduleNum");
			table.Columns.Add("SchedDate");
			table.Columns.Add("StartTime");
			table.Columns.Add("StopTime");
			table.Columns.Add("SchedType");
			table.Columns.Add("ProvNum");
			table.Columns.Add("BlockoutType");
			table.Columns.Add("Note");
			table.Columns.Add("Status");
			table.Columns.Add("EmployeeNum");
			table.Columns.Add("DateTStamp");
			table.Columns.Add("ClinicNum");
			foreach(Schedule schedule in listSchedules) {
				table.Rows.Add(new object[] {
					POut.Long  (schedule.ScheduleNum),
					POut.DateT (schedule.SchedDate,false),
					POut.Time  (schedule.StartTime,false),
					POut.Time  (schedule.StopTime,false),
					POut.Int   ((int)schedule.SchedType),
					POut.Long  (schedule.ProvNum),
					POut.Long  (schedule.BlockoutType),
					            schedule.Note,
					POut.Int   ((int)schedule.Status),
					POut.Long  (schedule.EmployeeNum),
					POut.DateT (schedule.DateTStamp,false),
					POut.Long  (schedule.ClinicNum),
				});
			}
			return table;
		}

		///<summary>Inserts one Schedule into the database.  Returns the new priKey.</summary>
		public static long Insert(Schedule schedule) {
			return Insert(schedule,false);
		}

		///<summary>Inserts one Schedule into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Schedule schedule,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				schedule.ScheduleNum=ReplicationServers.GetKey("schedule","ScheduleNum");
			}
			string command="INSERT INTO schedule (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ScheduleNum,";
			}
			command+="SchedDate,StartTime,StopTime,SchedType,ProvNum,BlockoutType,Note,Status,EmployeeNum,ClinicNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(schedule.ScheduleNum)+",";
			}
			command+=
				     POut.Date  (schedule.SchedDate)+","
				+    POut.Time  (schedule.StartTime)+","
				+    POut.Time  (schedule.StopTime)+","
				+    POut.Int   ((int)schedule.SchedType)+","
				+    POut.Long  (schedule.ProvNum)+","
				+    POut.Long  (schedule.BlockoutType)+","
				+    DbHelper.ParamChar+"paramNote,"
				+    POut.Int   ((int)schedule.Status)+","
				+    POut.Long  (schedule.EmployeeNum)+","
				//DateTStamp can only be set by MySQL
				+    POut.Long  (schedule.ClinicNum)+")";
			if(schedule.Note==null) {
				schedule.Note="";
			}
			var paramNote = new MySqlParameter("paramNote", POut.StringParam(schedule.Note));
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command,paramNote);
			}
			else {
				schedule.ScheduleNum=Database.ExecuteInsert(command,paramNote);
			}
			return schedule.ScheduleNum;
		}

		///<summary>Inserts many Schedules into the database.</summary>
		public static void InsertMany(List<Schedule> listSchedules) {
			InsertMany(listSchedules,false);
		}

		///<summary>Inserts many Schedules into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<Schedule> listSchedules,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(Schedule schedule in listSchedules) {
					Insert(schedule);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listSchedules.Count) {
					Schedule schedule=listSchedules[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO schedule (");
						if(useExistingPK) {
							sbCommands.Append("ScheduleNum,");
						}
						sbCommands.Append("SchedDate,StartTime,StopTime,SchedType,ProvNum,BlockoutType,Note,Status,EmployeeNum,ClinicNum) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(schedule.ScheduleNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Date(schedule.SchedDate)); sbRow.Append(",");
					sbRow.Append(POut.Time(schedule.StartTime)); sbRow.Append(",");
					sbRow.Append(POut.Time(schedule.StopTime)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)schedule.SchedType)); sbRow.Append(",");
					sbRow.Append(POut.Long(schedule.ProvNum)); sbRow.Append(",");
					sbRow.Append(POut.Long(schedule.BlockoutType)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(schedule.Note)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Int((int)schedule.Status)); sbRow.Append(",");
					sbRow.Append(POut.Long(schedule.EmployeeNum)); sbRow.Append(",");
					//DateTStamp can only be set by MySQL
					sbRow.Append(POut.Long(schedule.ClinicNum)); sbRow.Append(")");
					if(sbCommands.Length+sbRow.Length+1 > TableBase.MaxAllowedPacketCount && countRows > 0) {
						Database.ExecuteNonQuery(sbCommands.ToString());
						sbCommands=null;
					}
					else {
						if(hasComma) {
							sbCommands.Append(",");
						}
						sbCommands.Append(sbRow.ToString());
						countRows++;
						if(index==listSchedules.Count-1) {
							Database.ExecuteNonQuery(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one Schedule into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Schedule schedule) {
			return InsertNoCache(schedule,false);
		}

		///<summary>Inserts one Schedule into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Schedule schedule,bool useExistingPK) {
			
			string command="INSERT INTO schedule (";
			if(!useExistingPK) {
				schedule.ScheduleNum=ReplicationServers.GetKeyNoCache("schedule","ScheduleNum");
			}
			if(useExistingPK) {
				command+="ScheduleNum,";
			}
			command+="SchedDate,StartTime,StopTime,SchedType,ProvNum,BlockoutType,Note,Status,EmployeeNum,ClinicNum) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(schedule.ScheduleNum)+",";
			}
			command+=
				     POut.Date  (schedule.SchedDate)+","
				+    POut.Time  (schedule.StartTime)+","
				+    POut.Time  (schedule.StopTime)+","
				+    POut.Int   ((int)schedule.SchedType)+","
				+    POut.Long  (schedule.ProvNum)+","
				+    POut.Long  (schedule.BlockoutType)+","
				+    DbHelper.ParamChar+"paramNote,"
				+    POut.Int   ((int)schedule.Status)+","
				+    POut.Long  (schedule.EmployeeNum)+","
				//DateTStamp can only be set by MySQL
				+    POut.Long  (schedule.ClinicNum)+")";
			if(schedule.Note==null) {
				schedule.Note="";
			}
			var paramNote = new MySqlParameter("paramNote", POut.StringParam(schedule.Note));
			if(useExistingPK) {
				Database.ExecuteNonQuery(command,paramNote);
			}
			else {
				schedule.ScheduleNum=Database.ExecuteInsert(command,paramNote);
			}
			return schedule.ScheduleNum;
		}

		///<summary>Updates one Schedule in the database.</summary>
		public static void Update(Schedule schedule) {
			string command="UPDATE schedule SET "
				+"SchedDate   =  "+POut.Date  (schedule.SchedDate)+", "
				+"StartTime   =  "+POut.Time  (schedule.StartTime)+", "
				+"StopTime    =  "+POut.Time  (schedule.StopTime)+", "
				+"SchedType   =  "+POut.Int   ((int)schedule.SchedType)+", "
				+"ProvNum     =  "+POut.Long  (schedule.ProvNum)+", "
				+"BlockoutType=  "+POut.Long  (schedule.BlockoutType)+", "
				+"Note        =  "+DbHelper.ParamChar+"paramNote, "
				+"Status      =  "+POut.Int   ((int)schedule.Status)+", "
				+"EmployeeNum =  "+POut.Long  (schedule.EmployeeNum)+", "
				//DateTStamp can only be set by MySQL
				+"ClinicNum   =  "+POut.Long  (schedule.ClinicNum)+" "
				+"WHERE ScheduleNum = "+POut.Long(schedule.ScheduleNum);
			if(schedule.Note==null) {
				schedule.Note="";
			}
			var paramNote = new MySqlParameter("paramNote", POut.StringParam(schedule.Note));
			Database.ExecuteNonQuery(command,paramNote);
		}

		///<summary>Updates one Schedule in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Schedule schedule,Schedule oldSchedule) {
			string command="";
			if(schedule.SchedDate.Date != oldSchedule.SchedDate.Date) {
				if(command!="") { command+=",";}
				command+="SchedDate = "+POut.Date(schedule.SchedDate)+"";
			}
			if(schedule.StartTime != oldSchedule.StartTime) {
				if(command!="") { command+=",";}
				command+="StartTime = "+POut.Time  (schedule.StartTime)+"";
			}
			if(schedule.StopTime != oldSchedule.StopTime) {
				if(command!="") { command+=",";}
				command+="StopTime = "+POut.Time  (schedule.StopTime)+"";
			}
			if(schedule.SchedType != oldSchedule.SchedType) {
				if(command!="") { command+=",";}
				command+="SchedType = "+POut.Int   ((int)schedule.SchedType)+"";
			}
			if(schedule.ProvNum != oldSchedule.ProvNum) {
				if(command!="") { command+=",";}
				command+="ProvNum = "+POut.Long(schedule.ProvNum)+"";
			}
			if(schedule.BlockoutType != oldSchedule.BlockoutType) {
				if(command!="") { command+=",";}
				command+="BlockoutType = "+POut.Long(schedule.BlockoutType)+"";
			}
			if(schedule.Note != oldSchedule.Note) {
				if(command!="") { command+=",";}
				command+="Note = "+DbHelper.ParamChar+"paramNote";
			}
			if(schedule.Status != oldSchedule.Status) {
				if(command!="") { command+=",";}
				command+="Status = "+POut.Int   ((int)schedule.Status)+"";
			}
			if(schedule.EmployeeNum != oldSchedule.EmployeeNum) {
				if(command!="") { command+=",";}
				command+="EmployeeNum = "+POut.Long(schedule.EmployeeNum)+"";
			}
			//DateTStamp can only be set by MySQL
			if(schedule.ClinicNum != oldSchedule.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(schedule.ClinicNum)+"";
			}
			if(command=="") {
				return false;
			}
			if(schedule.Note==null) {
				schedule.Note="";
			}
			var paramNote = new MySqlParameter("paramNote", POut.StringParam(schedule.Note));
			command="UPDATE schedule SET "+command
				+" WHERE ScheduleNum = "+POut.Long(schedule.ScheduleNum);
			Database.ExecuteNonQuery(command,paramNote);
			return true;
		}

		///<summary>Returns true if Update(Schedule,Schedule) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Schedule schedule,Schedule oldSchedule) {
			if(schedule.SchedDate.Date != oldSchedule.SchedDate.Date) {
				return true;
			}
			if(schedule.StartTime != oldSchedule.StartTime) {
				return true;
			}
			if(schedule.StopTime != oldSchedule.StopTime) {
				return true;
			}
			if(schedule.SchedType != oldSchedule.SchedType) {
				return true;
			}
			if(schedule.ProvNum != oldSchedule.ProvNum) {
				return true;
			}
			if(schedule.BlockoutType != oldSchedule.BlockoutType) {
				return true;
			}
			if(schedule.Note != oldSchedule.Note) {
				return true;
			}
			if(schedule.Status != oldSchedule.Status) {
				return true;
			}
			if(schedule.EmployeeNum != oldSchedule.EmployeeNum) {
				return true;
			}
			//DateTStamp can only be set by MySQL
			if(schedule.ClinicNum != oldSchedule.ClinicNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one Schedule from the database.</summary>
		public static void Delete(long scheduleNum) {
			string command="DELETE FROM schedule "
				+"WHERE ScheduleNum = "+POut.Long(scheduleNum);
			Database.ExecuteNonQuery(command);
		}

	}
}