//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Mobile.Crud{
	internal class AppointmentmCrud {
		///<summary>Gets one Appointmentm object from the database using primaryKey1(CustomerNum) and primaryKey2.  Returns null if not found.</summary>
		internal static Appointmentm SelectOne(long customerNum,long aptNum){
			string command="SELECT * FROM appointmentm "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND AptNum = "+POut.Long(aptNum);
			List<Appointmentm> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Appointmentm object from the database using a query.</summary>
		internal static Appointmentm SelectOne(string command){

			List<Appointmentm> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Appointmentm objects from the database using a query.</summary>
		internal static List<Appointmentm> SelectMany(string command){

			List<Appointmentm> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<Appointmentm> TableToList(DataTable table){
			List<Appointmentm> retVal=new List<Appointmentm>();
			Appointmentm appointmentm;
			for(int i=0;i<table.Rows.Count;i++) {
				appointmentm=new Appointmentm();
				appointmentm.CustomerNum = PIn.Long  (table.Rows[i]["CustomerNum"].ToString());
				appointmentm.AptNum      = PIn.Long  (table.Rows[i]["AptNum"].ToString());
				appointmentm.PatNum      = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				appointmentm.AptStatus   = (ApptStatus)PIn.Int(table.Rows[i]["AptStatus"].ToString());
				appointmentm.Pattern     = PIn.String(table.Rows[i]["Pattern"].ToString());
				appointmentm.Confirmed   = PIn.Long  (table.Rows[i]["Confirmed"].ToString());
				appointmentm.Op          = PIn.Long  (table.Rows[i]["Op"].ToString());
				appointmentm.Note        = PIn.String(table.Rows[i]["Note"].ToString());
				appointmentm.ProvNum     = PIn.Long  (table.Rows[i]["ProvNum"].ToString());
				appointmentm.ProvHyg     = PIn.Long  (table.Rows[i]["ProvHyg"].ToString());
				appointmentm.AptDateTime = PIn.DateT (table.Rows[i]["AptDateTime"].ToString());
				appointmentm.IsNewPatient= PIn.Bool  (table.Rows[i]["IsNewPatient"].ToString());
				appointmentm.ProcDescript= PIn.String(table.Rows[i]["ProcDescript"].ToString());
				appointmentm.ClinicNum   = PIn.Long  (table.Rows[i]["ClinicNum"].ToString());
				appointmentm.IsHygiene   = PIn.Bool  (table.Rows[i]["IsHygiene"].ToString());
				retVal.Add(appointmentm);
			}
			return retVal;
		}

		///<summary>Usually set useExistingPK=true.  Inserts one Appointmentm into the database.</summary>
		internal static long Insert(Appointmentm appointmentm,bool useExistingPK){
			if(!useExistingPK) {
				appointmentm.AptNum=ReplicationServers.GetKey("appointmentm","AptNum");
			}
			string command="INSERT INTO appointmentm (";
			command+="AptNum,";
			command+="CustomerNum,PatNum,AptStatus,Pattern,Confirmed,Op,Note,ProvNum,ProvHyg,AptDateTime,IsNewPatient,ProcDescript,ClinicNum,IsHygiene) VALUES(";
			command+=POut.Long(appointmentm.AptNum)+",";
			command+=
				     POut.Long  (appointmentm.CustomerNum)+","
				+    POut.Long  (appointmentm.PatNum)+","
				+    POut.Int   ((int)appointmentm.AptStatus)+","
				+"'"+POut.String(appointmentm.Pattern)+"',"
				+    POut.Long  (appointmentm.Confirmed)+","
				+    POut.Long  (appointmentm.Op)+","
				+"'"+POut.String(appointmentm.Note)+"',"
				+    POut.Long  (appointmentm.ProvNum)+","
				+    POut.Long  (appointmentm.ProvHyg)+","
				+    POut.DateT (appointmentm.AptDateTime)+","
				+    POut.Bool  (appointmentm.IsNewPatient)+","
				+"'"+POut.String(appointmentm.ProcDescript)+"',"
				+    POut.Long  (appointmentm.ClinicNum)+","
				+    POut.Bool  (appointmentm.IsHygiene)+")";
			Db.NonQ(command);//There is no autoincrement in the mobile server.
			return appointmentm.AptNum;
		}

		///<summary>Updates one Appointmentm in the database.</summary>
		internal static void Update(Appointmentm appointmentm){
			string command="UPDATE appointmentm SET "
				+"PatNum      =  "+POut.Long  (appointmentm.PatNum)+", "
				+"AptStatus   =  "+POut.Int   ((int)appointmentm.AptStatus)+", "
				+"Pattern     = '"+POut.String(appointmentm.Pattern)+"', "
				+"Confirmed   =  "+POut.Long  (appointmentm.Confirmed)+", "
				+"Op          =  "+POut.Long  (appointmentm.Op)+", "
				+"Note        = '"+POut.String(appointmentm.Note)+"', "
				+"ProvNum     =  "+POut.Long  (appointmentm.ProvNum)+", "
				+"ProvHyg     =  "+POut.Long  (appointmentm.ProvHyg)+", "
				+"AptDateTime =  "+POut.DateT (appointmentm.AptDateTime)+", "
				+"IsNewPatient=  "+POut.Bool  (appointmentm.IsNewPatient)+", "
				+"ProcDescript= '"+POut.String(appointmentm.ProcDescript)+"', "
				+"ClinicNum   =  "+POut.Long  (appointmentm.ClinicNum)+", "
				+"IsHygiene   =  "+POut.Bool  (appointmentm.IsHygiene)+" "
				+"WHERE CustomerNum = "+POut.Long(appointmentm.CustomerNum)+" AND AptNum = "+POut.Long(appointmentm.AptNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one Appointmentm from the database.</summary>
		internal static void Delete(long customerNum,long aptNum){
			string command="DELETE FROM appointmentm "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND AptNum = "+POut.Long(aptNum);
			Db.NonQ(command);
		}

		///<summary>Converts one Appointment object to its mobile equivalent.  Warning! CustomerNum will always be 0.</summary>
		internal static Appointmentm ConvertToM(Appointment appointment){
			Appointmentm appointmentm=new Appointmentm();
			//CustomerNum cannot be set.  Remains 0.
			appointmentm.AptNum      =appointment.AptNum;
			appointmentm.PatNum      =appointment.PatNum;
			appointmentm.AptStatus   =appointment.AptStatus;
			appointmentm.Pattern     =appointment.Pattern;
			appointmentm.Confirmed   =appointment.Confirmed;
			appointmentm.Op          =appointment.Op;
			appointmentm.Note        =appointment.Note;
			appointmentm.ProvNum     =appointment.ProvNum;
			appointmentm.ProvHyg     =appointment.ProvHyg;
			appointmentm.AptDateTime =appointment.AptDateTime;
			appointmentm.IsNewPatient=appointment.IsNewPatient;
			appointmentm.ProcDescript=appointment.ProcDescript;
			appointmentm.ClinicNum   =appointment.ClinicNum;
			appointmentm.IsHygiene   =appointment.IsHygiene;
			return appointmentm;
		}

	}
}