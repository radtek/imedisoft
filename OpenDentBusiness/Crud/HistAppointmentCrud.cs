//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class HistAppointmentCrud {
		///<summary>Gets one HistAppointment object from the database using the primary key.  Returns null if not found.</summary>
		public static HistAppointment SelectOne(long histApptNum) {
			string command="SELECT * FROM histappointment "
				+"WHERE HistApptNum = "+POut.Long(histApptNum);
			List<HistAppointment> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one HistAppointment object from the database using a query.</summary>
		public static HistAppointment SelectOne(string command) {

			List<HistAppointment> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of HistAppointment objects from the database using a query.</summary>
		public static List<HistAppointment> SelectMany(string command) {

			List<HistAppointment> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<HistAppointment> TableToList(DataTable table) {
			List<HistAppointment> retVal=new List<HistAppointment>();
			HistAppointment histAppointment;
			foreach(DataRow row in table.Rows) {
				histAppointment=new HistAppointment();
				histAppointment.HistApptNum          = PIn.Long  (row["HistApptNum"].ToString());
				histAppointment.HistUserNum          = PIn.Long  (row["HistUserNum"].ToString());
				histAppointment.HistDateTStamp       = PIn.Date (row["HistDateTStamp"].ToString());
				histAppointment.HistApptAction       = (OpenDentBusiness.HistAppointmentAction)PIn.Int(row["HistApptAction"].ToString());
				histAppointment.ApptSource           = PIn.Int(row["ApptSource"].ToString());
				histAppointment.AptNum               = PIn.Long  (row["AptNum"].ToString());
				histAppointment.PatNum               = PIn.Long  (row["PatNum"].ToString());
				histAppointment.AptStatus            = (OpenDentBusiness.ApptStatus)PIn.Int(row["AptStatus"].ToString());
				histAppointment.Pattern              = PIn.String(row["Pattern"].ToString());
				histAppointment.Confirmed            = PIn.Long  (row["Confirmed"].ToString());
				histAppointment.TimeLocked           = PIn.Bool  (row["TimeLocked"].ToString());
				histAppointment.Op                   = PIn.Long  (row["Op"].ToString());
				histAppointment.Note                 = PIn.String(row["Note"].ToString());
				histAppointment.ProvNum              = PIn.Long  (row["ProvNum"].ToString());
				histAppointment.ProvHyg              = PIn.Long  (row["ProvHyg"].ToString());
				histAppointment.AptDateTime          = PIn.Date (row["AptDateTime"].ToString());
				histAppointment.NextAptNum           = PIn.Long  (row["NextAptNum"].ToString());
				histAppointment.UnschedStatus        = PIn.Long  (row["UnschedStatus"].ToString());
				histAppointment.IsNewPatient         = PIn.Bool  (row["IsNewPatient"].ToString());
				histAppointment.ProcDescript         = PIn.String(row["ProcDescript"].ToString());
				histAppointment.Assistant            = PIn.Long  (row["Assistant"].ToString());
				histAppointment.ClinicNum            = PIn.Long  (row["ClinicNum"].ToString());
				histAppointment.IsHygiene            = PIn.Bool  (row["IsHygiene"].ToString());
				histAppointment.DateTStamp           = PIn.Date (row["DateTStamp"].ToString());
				histAppointment.DateTimeArrived      = PIn.Date (row["DateTimeArrived"].ToString());
				histAppointment.DateTimeSeated       = PIn.Date (row["DateTimeSeated"].ToString());
				histAppointment.DateTimeDismissed    = PIn.Date (row["DateTimeDismissed"].ToString());
				histAppointment.InsPlan1             = PIn.Long  (row["InsPlan1"].ToString());
				histAppointment.InsPlan2             = PIn.Long  (row["InsPlan2"].ToString());
				histAppointment.DateTimeAskedToArrive= PIn.Date (row["DateTimeAskedToArrive"].ToString());
				histAppointment.ProcsColored         = PIn.String(row["ProcsColored"].ToString());
				histAppointment.ColorOverride        = Color.FromArgb(PIn.Int(row["ColorOverride"].ToString()));
				histAppointment.AppointmentTypeNum   = PIn.Long  (row["AppointmentTypeNum"].ToString());
				histAppointment.SecUserNumEntry      = PIn.Long  (row["SecUserNumEntry"].ToString());
				histAppointment.SecDateTEntry        = PIn.Date (row["SecDateTEntry"].ToString());
				histAppointment.Priority             = (OpenDentBusiness.ApptPriority)PIn.Int(row["Priority"].ToString());
				histAppointment.ProvBarText          = PIn.String(row["ProvBarText"].ToString());
				histAppointment.PatternSecondary     = PIn.String(row["PatternSecondary"].ToString());
				retVal.Add(histAppointment);
			}
			return retVal;
		}

		///<summary>Converts a list of HistAppointment into a DataTable.</summary>
		public static DataTable ListToTable(List<HistAppointment> listHistAppointments,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="HistAppointment";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("HistApptNum");
			table.Columns.Add("HistUserNum");
			table.Columns.Add("HistDateTStamp");
			table.Columns.Add("HistApptAction");
			table.Columns.Add("ApptSource");
			table.Columns.Add("AptNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("AptStatus");
			table.Columns.Add("Pattern");
			table.Columns.Add("Confirmed");
			table.Columns.Add("TimeLocked");
			table.Columns.Add("Op");
			table.Columns.Add("Note");
			table.Columns.Add("ProvNum");
			table.Columns.Add("ProvHyg");
			table.Columns.Add("AptDateTime");
			table.Columns.Add("NextAptNum");
			table.Columns.Add("UnschedStatus");
			table.Columns.Add("IsNewPatient");
			table.Columns.Add("ProcDescript");
			table.Columns.Add("Assistant");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("IsHygiene");
			table.Columns.Add("DateTStamp");
			table.Columns.Add("DateTimeArrived");
			table.Columns.Add("DateTimeSeated");
			table.Columns.Add("DateTimeDismissed");
			table.Columns.Add("InsPlan1");
			table.Columns.Add("InsPlan2");
			table.Columns.Add("DateTimeAskedToArrive");
			table.Columns.Add("ProcsColored");
			table.Columns.Add("ColorOverride");
			table.Columns.Add("AppointmentTypeNum");
			table.Columns.Add("SecUserNumEntry");
			table.Columns.Add("SecDateTEntry");
			table.Columns.Add("Priority");
			table.Columns.Add("ProvBarText");
			table.Columns.Add("PatternSecondary");
			foreach(HistAppointment histAppointment in listHistAppointments) {
				table.Rows.Add(new object[] {
					POut.Long  (histAppointment.HistApptNum),
					POut.Long  (histAppointment.HistUserNum),
					POut.DateT (histAppointment.HistDateTStamp,false),
					POut.Int   ((int)histAppointment.HistApptAction),
					POut.Int   ((int)histAppointment.ApptSource),
					POut.Long  (histAppointment.AptNum),
					POut.Long  (histAppointment.PatNum),
					POut.Int   ((int)histAppointment.AptStatus),
					            histAppointment.Pattern,
					POut.Long  (histAppointment.Confirmed),
					POut.Bool  (histAppointment.TimeLocked),
					POut.Long  (histAppointment.Op),
					            histAppointment.Note,
					POut.Long  (histAppointment.ProvNum),
					POut.Long  (histAppointment.ProvHyg),
					POut.DateT (histAppointment.AptDateTime,false),
					POut.Long  (histAppointment.NextAptNum),
					POut.Long  (histAppointment.UnschedStatus),
					POut.Bool  (histAppointment.IsNewPatient),
					            histAppointment.ProcDescript,
					POut.Long  (histAppointment.Assistant),
					POut.Long  (histAppointment.ClinicNum),
					POut.Bool  (histAppointment.IsHygiene),
					POut.DateT (histAppointment.DateTStamp,false),
					POut.DateT (histAppointment.DateTimeArrived,false),
					POut.DateT (histAppointment.DateTimeSeated,false),
					POut.DateT (histAppointment.DateTimeDismissed,false),
					POut.Long  (histAppointment.InsPlan1),
					POut.Long  (histAppointment.InsPlan2),
					POut.DateT (histAppointment.DateTimeAskedToArrive,false),
					            histAppointment.ProcsColored,
					POut.Int   (histAppointment.ColorOverride.ToArgb()),
					POut.Long  (histAppointment.AppointmentTypeNum),
					POut.Long  (histAppointment.SecUserNumEntry),
					POut.DateT (histAppointment.SecDateTEntry,false),
					POut.Int   ((int)histAppointment.Priority),
					            histAppointment.ProvBarText,
					            histAppointment.PatternSecondary,
				});
			}
			return table;
		}

		///<summary>Inserts one HistAppointment into the database.  Returns the new priKey.</summary>
		public static long Insert(HistAppointment histAppointment) {
			return Insert(histAppointment,false);
		}

		///<summary>Inserts one HistAppointment into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(HistAppointment histAppointment,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				histAppointment.HistApptNum=ReplicationServers.GetKey("histappointment","HistApptNum");
			}
			string command="INSERT INTO histappointment (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="HistApptNum,";
			}
			command+="HistUserNum,HistDateTStamp,HistApptAction,ApptSource,AptNum,PatNum,AptStatus,Pattern,Confirmed,TimeLocked,Op,Note,ProvNum,ProvHyg,AptDateTime,NextAptNum,UnschedStatus,IsNewPatient,ProcDescript,Assistant,ClinicNum,IsHygiene,DateTStamp,DateTimeArrived,DateTimeSeated,DateTimeDismissed,InsPlan1,InsPlan2,DateTimeAskedToArrive,ProcsColored,ColorOverride,AppointmentTypeNum,SecUserNumEntry,SecDateTEntry,Priority,ProvBarText,PatternSecondary) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(histAppointment.HistApptNum)+",";
			}
			command+=
				     POut.Long  (histAppointment.HistUserNum)+","
				+    DbHelper.Now()+","
				+    POut.Int   ((int)histAppointment.HistApptAction)+","
				+    POut.Int   ((int)histAppointment.ApptSource)+","
				+    POut.Long  (histAppointment.AptNum)+","
				+    POut.Long  (histAppointment.PatNum)+","
				+    POut.Int   ((int)histAppointment.AptStatus)+","
				+"'"+POut.String(histAppointment.Pattern)+"',"
				+    POut.Long  (histAppointment.Confirmed)+","
				+    POut.Bool  (histAppointment.TimeLocked)+","
				+    POut.Long  (histAppointment.Op)+","
				+    DbHelper.ParamChar+"paramNote,"
				+    POut.Long  (histAppointment.ProvNum)+","
				+    POut.Long  (histAppointment.ProvHyg)+","
				+    POut.DateT (histAppointment.AptDateTime)+","
				+    POut.Long  (histAppointment.NextAptNum)+","
				+    POut.Long  (histAppointment.UnschedStatus)+","
				+    POut.Bool  (histAppointment.IsNewPatient)+","
				+"'"+POut.String(histAppointment.ProcDescript)+"',"
				+    POut.Long  (histAppointment.Assistant)+","
				+    POut.Long  (histAppointment.ClinicNum)+","
				+    POut.Bool  (histAppointment.IsHygiene)+","
				+    POut.DateT (histAppointment.DateTStamp)+","
				+    POut.DateT (histAppointment.DateTimeArrived)+","
				+    POut.DateT (histAppointment.DateTimeSeated)+","
				+    POut.DateT (histAppointment.DateTimeDismissed)+","
				+    POut.Long  (histAppointment.InsPlan1)+","
				+    POut.Long  (histAppointment.InsPlan2)+","
				+    POut.DateT (histAppointment.DateTimeAskedToArrive)+","
				+    DbHelper.ParamChar+"paramProcsColored,"
				+    POut.Int   (histAppointment.ColorOverride.ToArgb())+","
				+    POut.Long  (histAppointment.AppointmentTypeNum)+","
				+    POut.Long  (histAppointment.SecUserNumEntry)+","
				+    POut.DateT (histAppointment.SecDateTEntry)+","
				+    POut.Int   ((int)histAppointment.Priority)+","
				+"'"+POut.String(histAppointment.ProvBarText)+"',"
				+"'"+POut.String(histAppointment.PatternSecondary)+"')";
			if(histAppointment.Note==null) {
				histAppointment.Note="";
			}
			var paramNote = new MySqlParameter("paramNote", POut.StringNote(histAppointment.Note));
			if(histAppointment.ProcsColored==null) {
				histAppointment.ProcsColored="";
			}
			var paramProcsColored = new MySqlParameter("paramProcsColored", POut.StringParam(histAppointment.ProcsColored));
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command,paramNote,paramProcsColored);
			}
			else {
				histAppointment.HistApptNum=Database.ExecuteInsert(command,paramNote,paramProcsColored);
			}
			return histAppointment.HistApptNum;
		}

		///<summary>Inserts one HistAppointment into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(HistAppointment histAppointment) {
			return InsertNoCache(histAppointment,false);
		}

		///<summary>Inserts one HistAppointment into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(HistAppointment histAppointment,bool useExistingPK) {
			
			string command="INSERT INTO histappointment (";
			if(!useExistingPK) {
				histAppointment.HistApptNum=ReplicationServers.GetKeyNoCache("histappointment","HistApptNum");
			}
			if(useExistingPK) {
				command+="HistApptNum,";
			}
			command+="HistUserNum,HistDateTStamp,HistApptAction,ApptSource,AptNum,PatNum,AptStatus,Pattern,Confirmed,TimeLocked,Op,Note,ProvNum,ProvHyg,AptDateTime,NextAptNum,UnschedStatus,IsNewPatient,ProcDescript,Assistant,ClinicNum,IsHygiene,DateTStamp,DateTimeArrived,DateTimeSeated,DateTimeDismissed,InsPlan1,InsPlan2,DateTimeAskedToArrive,ProcsColored,ColorOverride,AppointmentTypeNum,SecUserNumEntry,SecDateTEntry,Priority,ProvBarText,PatternSecondary) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(histAppointment.HistApptNum)+",";
			}
			command+=
				     POut.Long  (histAppointment.HistUserNum)+","
				+    DbHelper.Now()+","
				+    POut.Int   ((int)histAppointment.HistApptAction)+","
				+    POut.Int   ((int)histAppointment.ApptSource)+","
				+    POut.Long  (histAppointment.AptNum)+","
				+    POut.Long  (histAppointment.PatNum)+","
				+    POut.Int   ((int)histAppointment.AptStatus)+","
				+"'"+POut.String(histAppointment.Pattern)+"',"
				+    POut.Long  (histAppointment.Confirmed)+","
				+    POut.Bool  (histAppointment.TimeLocked)+","
				+    POut.Long  (histAppointment.Op)+","
				+    DbHelper.ParamChar+"paramNote,"
				+    POut.Long  (histAppointment.ProvNum)+","
				+    POut.Long  (histAppointment.ProvHyg)+","
				+    POut.DateT (histAppointment.AptDateTime)+","
				+    POut.Long  (histAppointment.NextAptNum)+","
				+    POut.Long  (histAppointment.UnschedStatus)+","
				+    POut.Bool  (histAppointment.IsNewPatient)+","
				+"'"+POut.String(histAppointment.ProcDescript)+"',"
				+    POut.Long  (histAppointment.Assistant)+","
				+    POut.Long  (histAppointment.ClinicNum)+","
				+    POut.Bool  (histAppointment.IsHygiene)+","
				+    POut.DateT (histAppointment.DateTStamp)+","
				+    POut.DateT (histAppointment.DateTimeArrived)+","
				+    POut.DateT (histAppointment.DateTimeSeated)+","
				+    POut.DateT (histAppointment.DateTimeDismissed)+","
				+    POut.Long  (histAppointment.InsPlan1)+","
				+    POut.Long  (histAppointment.InsPlan2)+","
				+    POut.DateT (histAppointment.DateTimeAskedToArrive)+","
				+    DbHelper.ParamChar+"paramProcsColored,"
				+    POut.Int   (histAppointment.ColorOverride.ToArgb())+","
				+    POut.Long  (histAppointment.AppointmentTypeNum)+","
				+    POut.Long  (histAppointment.SecUserNumEntry)+","
				+    POut.DateT (histAppointment.SecDateTEntry)+","
				+    POut.Int   ((int)histAppointment.Priority)+","
				+"'"+POut.String(histAppointment.ProvBarText)+"',"
				+"'"+POut.String(histAppointment.PatternSecondary)+"')";
			if(histAppointment.Note==null) {
				histAppointment.Note="";
			}
			var paramNote = new MySqlParameter("paramNote", POut.StringNote(histAppointment.Note));
			if(histAppointment.ProcsColored==null) {
				histAppointment.ProcsColored="";
			}
			var paramProcsColored = new MySqlParameter("paramProcsColored", POut.StringParam(histAppointment.ProcsColored));
			if(useExistingPK) {
				Database.ExecuteNonQuery(command,paramNote,paramProcsColored);
			}
			else {
				histAppointment.HistApptNum=Database.ExecuteInsert(command,paramNote,paramProcsColored);
			}
			return histAppointment.HistApptNum;
		}

		///<summary>Deletes one HistAppointment from the database.</summary>
		public static void Delete(long histApptNum) {
			string command="DELETE FROM histappointment "
				+"WHERE HistApptNum = "+POut.Long(histApptNum);
			Database.ExecuteNonQuery(command);
		}

	}
}