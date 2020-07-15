//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class PerioMeasureCrud {
		///<summary>Gets one PerioMeasure object from the database using the primary key.  Returns null if not found.</summary>
		public static PerioMeasure SelectOne(long perioMeasureNum) {
			string command="SELECT * FROM periomeasure "
				+"WHERE PerioMeasureNum = "+POut.Long(perioMeasureNum);
			List<PerioMeasure> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one PerioMeasure object from the database using a query.</summary>
		public static PerioMeasure SelectOne(string command) {

			List<PerioMeasure> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of PerioMeasure objects from the database using a query.</summary>
		public static List<PerioMeasure> SelectMany(string command) {

			List<PerioMeasure> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<PerioMeasure> TableToList(DataTable table) {
			List<PerioMeasure> retVal=new List<PerioMeasure>();
			PerioMeasure perioMeasure;
			foreach(DataRow row in table.Rows) {
				perioMeasure=new PerioMeasure();
				perioMeasure.PerioMeasureNum= PIn.Long  (row["PerioMeasureNum"].ToString());
				perioMeasure.PerioExamNum   = PIn.Long  (row["PerioExamNum"].ToString());
				perioMeasure.SequenceType   = (OpenDentBusiness.PerioSequenceType)PIn.Int(row["SequenceType"].ToString());
				perioMeasure.IntTooth       = PIn.Int   (row["IntTooth"].ToString());
				perioMeasure.ToothValue     = PIn.Int   (row["ToothValue"].ToString());
				perioMeasure.MBvalue        = PIn.Int   (row["MBvalue"].ToString());
				perioMeasure.Bvalue         = PIn.Int   (row["Bvalue"].ToString());
				perioMeasure.DBvalue        = PIn.Int   (row["DBvalue"].ToString());
				perioMeasure.MLvalue        = PIn.Int   (row["MLvalue"].ToString());
				perioMeasure.Lvalue         = PIn.Int   (row["Lvalue"].ToString());
				perioMeasure.DLvalue        = PIn.Int   (row["DLvalue"].ToString());
				perioMeasure.SecDateTEntry  = PIn.Date (row["SecDateTEntry"].ToString());
				perioMeasure.SecDateTEdit   = PIn.Date (row["SecDateTEdit"].ToString());
				retVal.Add(perioMeasure);
			}
			return retVal;
		}

		///<summary>Converts a list of PerioMeasure into a DataTable.</summary>
		public static DataTable ListToTable(List<PerioMeasure> listPerioMeasures,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="PerioMeasure";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("PerioMeasureNum");
			table.Columns.Add("PerioExamNum");
			table.Columns.Add("SequenceType");
			table.Columns.Add("IntTooth");
			table.Columns.Add("ToothValue");
			table.Columns.Add("MBvalue");
			table.Columns.Add("Bvalue");
			table.Columns.Add("DBvalue");
			table.Columns.Add("MLvalue");
			table.Columns.Add("Lvalue");
			table.Columns.Add("DLvalue");
			table.Columns.Add("SecDateTEntry");
			table.Columns.Add("SecDateTEdit");
			foreach(PerioMeasure perioMeasure in listPerioMeasures) {
				table.Rows.Add(new object[] {
					POut.Long  (perioMeasure.PerioMeasureNum),
					POut.Long  (perioMeasure.PerioExamNum),
					POut.Int   ((int)perioMeasure.SequenceType),
					POut.Int   (perioMeasure.IntTooth),
					POut.Int   (perioMeasure.ToothValue),
					POut.Int   (perioMeasure.MBvalue),
					POut.Int   (perioMeasure.Bvalue),
					POut.Int   (perioMeasure.DBvalue),
					POut.Int   (perioMeasure.MLvalue),
					POut.Int   (perioMeasure.Lvalue),
					POut.Int   (perioMeasure.DLvalue),
					POut.DateT (perioMeasure.SecDateTEntry,false),
					POut.DateT (perioMeasure.SecDateTEdit,false),
				});
			}
			return table;
		}

		///<summary>Inserts one PerioMeasure into the database.  Returns the new priKey.</summary>
		public static long Insert(PerioMeasure perioMeasure) {
			return Insert(perioMeasure,false);
		}

		///<summary>Inserts one PerioMeasure into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(PerioMeasure perioMeasure,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				perioMeasure.PerioMeasureNum=ReplicationServers.GetKey("periomeasure","PerioMeasureNum");
			}
			string command="INSERT INTO periomeasure (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="PerioMeasureNum,";
			}
			command+="PerioExamNum,SequenceType,IntTooth,ToothValue,MBvalue,Bvalue,DBvalue,MLvalue,Lvalue,DLvalue,SecDateTEntry) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(perioMeasure.PerioMeasureNum)+",";
			}
			command+=
				     POut.Long  (perioMeasure.PerioExamNum)+","
				+    POut.Int   ((int)perioMeasure.SequenceType)+","
				+    POut.Int   (perioMeasure.IntTooth)+","
				+    POut.Int   (perioMeasure.ToothValue)+","
				+    POut.Int   (perioMeasure.MBvalue)+","
				+    POut.Int   (perioMeasure.Bvalue)+","
				+    POut.Int   (perioMeasure.DBvalue)+","
				+    POut.Int   (perioMeasure.MLvalue)+","
				+    POut.Int   (perioMeasure.Lvalue)+","
				+    POut.Int   (perioMeasure.DLvalue)+","
				+    DbHelper.Now()+")";
				//SecDateTEdit can only be set by MySQL
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				perioMeasure.PerioMeasureNum=Db.NonQ(command,true,"PerioMeasureNum","perioMeasure");
			}
			return perioMeasure.PerioMeasureNum;
		}

		///<summary>Inserts one PerioMeasure into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(PerioMeasure perioMeasure) {
			return InsertNoCache(perioMeasure,false);
		}

		///<summary>Inserts one PerioMeasure into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(PerioMeasure perioMeasure,bool useExistingPK) {
			
			string command="INSERT INTO periomeasure (";
			if(!useExistingPK) {
				perioMeasure.PerioMeasureNum=ReplicationServers.GetKeyNoCache("periomeasure","PerioMeasureNum");
			}
			if(useExistingPK) {
				command+="PerioMeasureNum,";
			}
			command+="PerioExamNum,SequenceType,IntTooth,ToothValue,MBvalue,Bvalue,DBvalue,MLvalue,Lvalue,DLvalue,SecDateTEntry) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(perioMeasure.PerioMeasureNum)+",";
			}
			command+=
				     POut.Long  (perioMeasure.PerioExamNum)+","
				+    POut.Int   ((int)perioMeasure.SequenceType)+","
				+    POut.Int   (perioMeasure.IntTooth)+","
				+    POut.Int   (perioMeasure.ToothValue)+","
				+    POut.Int   (perioMeasure.MBvalue)+","
				+    POut.Int   (perioMeasure.Bvalue)+","
				+    POut.Int   (perioMeasure.DBvalue)+","
				+    POut.Int   (perioMeasure.MLvalue)+","
				+    POut.Int   (perioMeasure.Lvalue)+","
				+    POut.Int   (perioMeasure.DLvalue)+","
				+    DbHelper.Now()+")";
				//SecDateTEdit can only be set by MySQL
			if(useExistingPK) {
				Db.NonQ(command);
			}
			else {
				perioMeasure.PerioMeasureNum=Db.NonQ(command,true,"PerioMeasureNum","perioMeasure");
			}
			return perioMeasure.PerioMeasureNum;
		}

		///<summary>Updates one PerioMeasure in the database.</summary>
		public static void Update(PerioMeasure perioMeasure) {
			string command="UPDATE periomeasure SET "
				+"PerioExamNum   =  "+POut.Long  (perioMeasure.PerioExamNum)+", "
				+"SequenceType   =  "+POut.Int   ((int)perioMeasure.SequenceType)+", "
				+"IntTooth       =  "+POut.Int   (perioMeasure.IntTooth)+", "
				+"ToothValue     =  "+POut.Int   (perioMeasure.ToothValue)+", "
				+"MBvalue        =  "+POut.Int   (perioMeasure.MBvalue)+", "
				+"Bvalue         =  "+POut.Int   (perioMeasure.Bvalue)+", "
				+"DBvalue        =  "+POut.Int   (perioMeasure.DBvalue)+", "
				+"MLvalue        =  "+POut.Int   (perioMeasure.MLvalue)+", "
				+"Lvalue         =  "+POut.Int   (perioMeasure.Lvalue)+", "
				+"DLvalue        =  "+POut.Int   (perioMeasure.DLvalue)+" "
				//SecDateTEntry not allowed to change
				//SecDateTEdit can only be set by MySQL
				+"WHERE PerioMeasureNum = "+POut.Long(perioMeasure.PerioMeasureNum);
			Db.NonQ(command);
		}

		///<summary>Updates one PerioMeasure in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(PerioMeasure perioMeasure,PerioMeasure oldPerioMeasure) {
			string command="";
			if(perioMeasure.PerioExamNum != oldPerioMeasure.PerioExamNum) {
				if(command!="") { command+=",";}
				command+="PerioExamNum = "+POut.Long(perioMeasure.PerioExamNum)+"";
			}
			if(perioMeasure.SequenceType != oldPerioMeasure.SequenceType) {
				if(command!="") { command+=",";}
				command+="SequenceType = "+POut.Int   ((int)perioMeasure.SequenceType)+"";
			}
			if(perioMeasure.IntTooth != oldPerioMeasure.IntTooth) {
				if(command!="") { command+=",";}
				command+="IntTooth = "+POut.Int(perioMeasure.IntTooth)+"";
			}
			if(perioMeasure.ToothValue != oldPerioMeasure.ToothValue) {
				if(command!="") { command+=",";}
				command+="ToothValue = "+POut.Int(perioMeasure.ToothValue)+"";
			}
			if(perioMeasure.MBvalue != oldPerioMeasure.MBvalue) {
				if(command!="") { command+=",";}
				command+="MBvalue = "+POut.Int(perioMeasure.MBvalue)+"";
			}
			if(perioMeasure.Bvalue != oldPerioMeasure.Bvalue) {
				if(command!="") { command+=",";}
				command+="Bvalue = "+POut.Int(perioMeasure.Bvalue)+"";
			}
			if(perioMeasure.DBvalue != oldPerioMeasure.DBvalue) {
				if(command!="") { command+=",";}
				command+="DBvalue = "+POut.Int(perioMeasure.DBvalue)+"";
			}
			if(perioMeasure.MLvalue != oldPerioMeasure.MLvalue) {
				if(command!="") { command+=",";}
				command+="MLvalue = "+POut.Int(perioMeasure.MLvalue)+"";
			}
			if(perioMeasure.Lvalue != oldPerioMeasure.Lvalue) {
				if(command!="") { command+=",";}
				command+="Lvalue = "+POut.Int(perioMeasure.Lvalue)+"";
			}
			if(perioMeasure.DLvalue != oldPerioMeasure.DLvalue) {
				if(command!="") { command+=",";}
				command+="DLvalue = "+POut.Int(perioMeasure.DLvalue)+"";
			}
			//SecDateTEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			if(command=="") {
				return false;
			}
			command="UPDATE periomeasure SET "+command
				+" WHERE PerioMeasureNum = "+POut.Long(perioMeasure.PerioMeasureNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(PerioMeasure,PerioMeasure) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(PerioMeasure perioMeasure,PerioMeasure oldPerioMeasure) {
			if(perioMeasure.PerioExamNum != oldPerioMeasure.PerioExamNum) {
				return true;
			}
			if(perioMeasure.SequenceType != oldPerioMeasure.SequenceType) {
				return true;
			}
			if(perioMeasure.IntTooth != oldPerioMeasure.IntTooth) {
				return true;
			}
			if(perioMeasure.ToothValue != oldPerioMeasure.ToothValue) {
				return true;
			}
			if(perioMeasure.MBvalue != oldPerioMeasure.MBvalue) {
				return true;
			}
			if(perioMeasure.Bvalue != oldPerioMeasure.Bvalue) {
				return true;
			}
			if(perioMeasure.DBvalue != oldPerioMeasure.DBvalue) {
				return true;
			}
			if(perioMeasure.MLvalue != oldPerioMeasure.MLvalue) {
				return true;
			}
			if(perioMeasure.Lvalue != oldPerioMeasure.Lvalue) {
				return true;
			}
			if(perioMeasure.DLvalue != oldPerioMeasure.DLvalue) {
				return true;
			}
			//SecDateTEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			return false;
		}

		///<summary>Deletes one PerioMeasure from the database.</summary>
		public static void Delete(long perioMeasureNum) {
			string command="DELETE FROM periomeasure "
				+"WHERE PerioMeasureNum = "+POut.Long(perioMeasureNum);
			Db.NonQ(command);
		}

	}
}