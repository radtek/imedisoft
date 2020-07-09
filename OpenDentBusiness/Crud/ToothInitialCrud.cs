//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ToothInitialCrud {
		///<summary>Gets one ToothInitial object from the database using the primary key.  Returns null if not found.</summary>
		public static ToothInitial SelectOne(long toothInitialNum) {
			string command="SELECT * FROM toothinitial "
				+"WHERE ToothInitialNum = "+POut.Long(toothInitialNum);
			List<ToothInitial> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ToothInitial object from the database using a query.</summary>
		public static ToothInitial SelectOne(string command) {

			List<ToothInitial> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ToothInitial objects from the database using a query.</summary>
		public static List<ToothInitial> SelectMany(string command) {

			List<ToothInitial> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ToothInitial> TableToList(DataTable table) {
			List<ToothInitial> retVal=new List<ToothInitial>();
			ToothInitial toothInitial;
			foreach(DataRow row in table.Rows) {
				toothInitial=new ToothInitial();
				toothInitial.ToothInitialNum= PIn.Long  (row["ToothInitialNum"].ToString());
				toothInitial.PatNum         = PIn.Long  (row["PatNum"].ToString());
				toothInitial.ToothNum       = PIn.String(row["ToothNum"].ToString());
				toothInitial.InitialType    = (OpenDentBusiness.ToothInitialType)PIn.Int(row["InitialType"].ToString());
				toothInitial.Movement       = PIn.Float (row["Movement"].ToString());
				toothInitial.DrawingSegment = PIn.String(row["DrawingSegment"].ToString());
				toothInitial.ColorDraw      = Color.FromArgb(PIn.Int(row["ColorDraw"].ToString()));
				toothInitial.SecDateTEntry  = PIn.DateT (row["SecDateTEntry"].ToString());
				toothInitial.SecDateTEdit   = PIn.DateT (row["SecDateTEdit"].ToString());
				retVal.Add(toothInitial);
			}
			return retVal;
		}

		///<summary>Converts a list of ToothInitial into a DataTable.</summary>
		public static DataTable ListToTable(List<ToothInitial> listToothInitials,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ToothInitial";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ToothInitialNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("ToothNum");
			table.Columns.Add("InitialType");
			table.Columns.Add("Movement");
			table.Columns.Add("DrawingSegment");
			table.Columns.Add("ColorDraw");
			table.Columns.Add("SecDateTEntry");
			table.Columns.Add("SecDateTEdit");
			foreach(ToothInitial toothInitial in listToothInitials) {
				table.Rows.Add(new object[] {
					POut.Long  (toothInitial.ToothInitialNum),
					POut.Long  (toothInitial.PatNum),
					            toothInitial.ToothNum,
					POut.Int   ((int)toothInitial.InitialType),
					POut.Float (toothInitial.Movement),
					            toothInitial.DrawingSegment,
					POut.Int   (toothInitial.ColorDraw.ToArgb()),
					POut.DateT (toothInitial.SecDateTEntry,false),
					POut.DateT (toothInitial.SecDateTEdit,false),
				});
			}
			return table;
		}

		///<summary>Inserts one ToothInitial into the database.  Returns the new priKey.</summary>
		public static long Insert(ToothInitial toothInitial) {
			return Insert(toothInitial,false);
		}

		///<summary>Inserts one ToothInitial into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ToothInitial toothInitial,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				toothInitial.ToothInitialNum=ReplicationServers.GetKey("toothinitial","ToothInitialNum");
			}
			string command="INSERT INTO toothinitial (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ToothInitialNum,";
			}
			command+="PatNum,ToothNum,InitialType,Movement,DrawingSegment,ColorDraw,SecDateTEntry) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(toothInitial.ToothInitialNum)+",";
			}
			command+=
				     POut.Long  (toothInitial.PatNum)+","
				+"'"+POut.String(toothInitial.ToothNum)+"',"
				+    POut.Int   ((int)toothInitial.InitialType)+","
				+    POut.Float (toothInitial.Movement)+","
				+    DbHelper.ParamChar+"paramDrawingSegment,"
				+    POut.Int   (toothInitial.ColorDraw.ToArgb())+","
				+    DbHelper.Now()+")";
				//SecDateTEdit can only be set by MySQL
			if(toothInitial.DrawingSegment==null) {
				toothInitial.DrawingSegment="";
			}
			OdSqlParameter paramDrawingSegment=new OdSqlParameter("paramDrawingSegment",OdDbType.Text,POut.StringParam(toothInitial.DrawingSegment));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramDrawingSegment);
			}
			else {
				toothInitial.ToothInitialNum=Db.NonQ(command,true,"ToothInitialNum","toothInitial",paramDrawingSegment);
			}
			return toothInitial.ToothInitialNum;
		}

		///<summary>Inserts one ToothInitial into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ToothInitial toothInitial) {
			return InsertNoCache(toothInitial,false);
		}

		///<summary>Inserts one ToothInitial into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ToothInitial toothInitial,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO toothinitial (";
			if(!useExistingPK && isRandomKeys) {
				toothInitial.ToothInitialNum=ReplicationServers.GetKeyNoCache("toothinitial","ToothInitialNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ToothInitialNum,";
			}
			command+="PatNum,ToothNum,InitialType,Movement,DrawingSegment,ColorDraw,SecDateTEntry) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(toothInitial.ToothInitialNum)+",";
			}
			command+=
				     POut.Long  (toothInitial.PatNum)+","
				+"'"+POut.String(toothInitial.ToothNum)+"',"
				+    POut.Int   ((int)toothInitial.InitialType)+","
				+    POut.Float (toothInitial.Movement)+","
				+    DbHelper.ParamChar+"paramDrawingSegment,"
				+    POut.Int   (toothInitial.ColorDraw.ToArgb())+","
				+    DbHelper.Now()+")";
				//SecDateTEdit can only be set by MySQL
			if(toothInitial.DrawingSegment==null) {
				toothInitial.DrawingSegment="";
			}
			OdSqlParameter paramDrawingSegment=new OdSqlParameter("paramDrawingSegment",OdDbType.Text,POut.StringParam(toothInitial.DrawingSegment));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramDrawingSegment);
			}
			else {
				toothInitial.ToothInitialNum=Db.NonQ(command,true,"ToothInitialNum","toothInitial",paramDrawingSegment);
			}
			return toothInitial.ToothInitialNum;
		}

		///<summary>Updates one ToothInitial in the database.</summary>
		public static void Update(ToothInitial toothInitial) {
			string command="UPDATE toothinitial SET "
				+"PatNum         =  "+POut.Long  (toothInitial.PatNum)+", "
				+"ToothNum       = '"+POut.String(toothInitial.ToothNum)+"', "
				+"InitialType    =  "+POut.Int   ((int)toothInitial.InitialType)+", "
				+"Movement       =  "+POut.Float (toothInitial.Movement)+", "
				+"DrawingSegment =  "+DbHelper.ParamChar+"paramDrawingSegment, "
				+"ColorDraw      =  "+POut.Int   (toothInitial.ColorDraw.ToArgb())+" "
				//SecDateTEntry not allowed to change
				//SecDateTEdit can only be set by MySQL
				+"WHERE ToothInitialNum = "+POut.Long(toothInitial.ToothInitialNum);
			if(toothInitial.DrawingSegment==null) {
				toothInitial.DrawingSegment="";
			}
			OdSqlParameter paramDrawingSegment=new OdSqlParameter("paramDrawingSegment",OdDbType.Text,POut.StringParam(toothInitial.DrawingSegment));
			Db.NonQ(command,paramDrawingSegment);
		}

		///<summary>Updates one ToothInitial in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ToothInitial toothInitial,ToothInitial oldToothInitial) {
			string command="";
			if(toothInitial.PatNum != oldToothInitial.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(toothInitial.PatNum)+"";
			}
			if(toothInitial.ToothNum != oldToothInitial.ToothNum) {
				if(command!="") { command+=",";}
				command+="ToothNum = '"+POut.String(toothInitial.ToothNum)+"'";
			}
			if(toothInitial.InitialType != oldToothInitial.InitialType) {
				if(command!="") { command+=",";}
				command+="InitialType = "+POut.Int   ((int)toothInitial.InitialType)+"";
			}
			if(toothInitial.Movement != oldToothInitial.Movement) {
				if(command!="") { command+=",";}
				command+="Movement = "+POut.Float(toothInitial.Movement)+"";
			}
			if(toothInitial.DrawingSegment != oldToothInitial.DrawingSegment) {
				if(command!="") { command+=",";}
				command+="DrawingSegment = "+DbHelper.ParamChar+"paramDrawingSegment";
			}
			if(toothInitial.ColorDraw != oldToothInitial.ColorDraw) {
				if(command!="") { command+=",";}
				command+="ColorDraw = "+POut.Int(toothInitial.ColorDraw.ToArgb())+"";
			}
			//SecDateTEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			if(command=="") {
				return false;
			}
			if(toothInitial.DrawingSegment==null) {
				toothInitial.DrawingSegment="";
			}
			OdSqlParameter paramDrawingSegment=new OdSqlParameter("paramDrawingSegment",OdDbType.Text,POut.StringParam(toothInitial.DrawingSegment));
			command="UPDATE toothinitial SET "+command
				+" WHERE ToothInitialNum = "+POut.Long(toothInitial.ToothInitialNum);
			Db.NonQ(command,paramDrawingSegment);
			return true;
		}

		///<summary>Returns true if Update(ToothInitial,ToothInitial) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ToothInitial toothInitial,ToothInitial oldToothInitial) {
			if(toothInitial.PatNum != oldToothInitial.PatNum) {
				return true;
			}
			if(toothInitial.ToothNum != oldToothInitial.ToothNum) {
				return true;
			}
			if(toothInitial.InitialType != oldToothInitial.InitialType) {
				return true;
			}
			if(toothInitial.Movement != oldToothInitial.Movement) {
				return true;
			}
			if(toothInitial.DrawingSegment != oldToothInitial.DrawingSegment) {
				return true;
			}
			if(toothInitial.ColorDraw != oldToothInitial.ColorDraw) {
				return true;
			}
			//SecDateTEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			return false;
		}

		///<summary>Deletes one ToothInitial from the database.</summary>
		public static void Delete(long toothInitialNum) {
			string command="DELETE FROM toothinitial "
				+"WHERE ToothInitialNum = "+POut.Long(toothInitialNum);
			Db.NonQ(command);
		}

	}
}