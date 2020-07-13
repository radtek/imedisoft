//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class LoincCrud {
		///<summary>Gets one Loinc object from the database using the primary key.  Returns null if not found.</summary>
		public static Loinc SelectOne(long loincNum) {
			string command="SELECT * FROM loinc "
				+"WHERE LoincNum = "+POut.Long(loincNum);
			List<Loinc> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Loinc object from the database using a query.</summary>
		public static Loinc SelectOne(string command) {

			List<Loinc> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Loinc objects from the database using a query.</summary>
		public static List<Loinc> SelectMany(string command) {

			List<Loinc> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Loinc> TableToList(DataTable table) {
			List<Loinc> retVal=new List<Loinc>();
			Loinc loinc;
			foreach(DataRow row in table.Rows) {
				loinc=new Loinc();
				loinc.LoincNum               = PIn.Long  (row["LoincNum"].ToString());
				loinc.LoincCode              = PIn.String(row["LoincCode"].ToString());
				loinc.Component              = PIn.String(row["Component"].ToString());
				loinc.PropertyObserved       = PIn.String(row["PropertyObserved"].ToString());
				loinc.TimeAspct              = PIn.String(row["TimeAspct"].ToString());
				loinc.SystemMeasured         = PIn.String(row["SystemMeasured"].ToString());
				loinc.ScaleType              = PIn.String(row["ScaleType"].ToString());
				loinc.MethodType             = PIn.String(row["MethodType"].ToString());
				loinc.StatusOfCode           = PIn.String(row["StatusOfCode"].ToString());
				loinc.NameShort              = PIn.String(row["NameShort"].ToString());
				loinc.ClassType              = PIn.String(row["ClassType"].ToString());
				loinc.UnitsRequired          = PIn.Bool  (row["UnitsRequired"].ToString());
				loinc.OrderObs               = PIn.String(row["OrderObs"].ToString());
				loinc.HL7FieldSubfieldID     = PIn.String(row["HL7FieldSubfieldID"].ToString());
				loinc.ExternalCopyrightNotice= PIn.String(row["ExternalCopyrightNotice"].ToString());
				loinc.NameLongCommon         = PIn.String(row["NameLongCommon"].ToString());
				loinc.UnitsUCUM              = PIn.String(row["UnitsUCUM"].ToString());
				loinc.RankCommonTests        = PIn.Int   (row["RankCommonTests"].ToString());
				loinc.RankCommonOrders       = PIn.Int   (row["RankCommonOrders"].ToString());
				retVal.Add(loinc);
			}
			return retVal;
		}

		///<summary>Converts a list of Loinc into a DataTable.</summary>
		public static DataTable ListToTable(List<Loinc> listLoincs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Loinc";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("LoincNum");
			table.Columns.Add("LoincCode");
			table.Columns.Add("Component");
			table.Columns.Add("PropertyObserved");
			table.Columns.Add("TimeAspct");
			table.Columns.Add("SystemMeasured");
			table.Columns.Add("ScaleType");
			table.Columns.Add("MethodType");
			table.Columns.Add("StatusOfCode");
			table.Columns.Add("NameShort");
			table.Columns.Add("ClassType");
			table.Columns.Add("UnitsRequired");
			table.Columns.Add("OrderObs");
			table.Columns.Add("HL7FieldSubfieldID");
			table.Columns.Add("ExternalCopyrightNotice");
			table.Columns.Add("NameLongCommon");
			table.Columns.Add("UnitsUCUM");
			table.Columns.Add("RankCommonTests");
			table.Columns.Add("RankCommonOrders");
			foreach(Loinc loinc in listLoincs) {
				table.Rows.Add(new object[] {
					POut.Long  (loinc.LoincNum),
					            loinc.LoincCode,
					            loinc.Component,
					            loinc.PropertyObserved,
					            loinc.TimeAspct,
					            loinc.SystemMeasured,
					            loinc.ScaleType,
					            loinc.MethodType,
					            loinc.StatusOfCode,
					            loinc.NameShort,
					            loinc.ClassType,
					POut.Bool  (loinc.UnitsRequired),
					            loinc.OrderObs,
					            loinc.HL7FieldSubfieldID,
					            loinc.ExternalCopyrightNotice,
					            loinc.NameLongCommon,
					            loinc.UnitsUCUM,
					POut.Int   (loinc.RankCommonTests),
					POut.Int   (loinc.RankCommonOrders),
				});
			}
			return table;
		}

		///<summary>Inserts one Loinc into the database.  Returns the new priKey.</summary>
		public static long Insert(Loinc loinc) {
			return Insert(loinc,false);
		}

		///<summary>Inserts one Loinc into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Loinc loinc,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				loinc.LoincNum=ReplicationServers.GetKey("loinc","LoincNum");
			}
			string command="INSERT INTO loinc (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="LoincNum,";
			}
			command+="LoincCode,Component,PropertyObserved,TimeAspct,SystemMeasured,ScaleType,MethodType,StatusOfCode,NameShort,ClassType,UnitsRequired,OrderObs,HL7FieldSubfieldID,ExternalCopyrightNotice,NameLongCommon,UnitsUCUM,RankCommonTests,RankCommonOrders) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(loinc.LoincNum)+",";
			}
			command+=
				 "'"+POut.String(loinc.LoincCode)+"',"
				+"'"+POut.String(loinc.Component)+"',"
				+"'"+POut.String(loinc.PropertyObserved)+"',"
				+"'"+POut.String(loinc.TimeAspct)+"',"
				+"'"+POut.String(loinc.SystemMeasured)+"',"
				+"'"+POut.String(loinc.ScaleType)+"',"
				+"'"+POut.String(loinc.MethodType)+"',"
				+"'"+POut.String(loinc.StatusOfCode)+"',"
				+"'"+POut.String(loinc.NameShort)+"',"
				+"'"+POut.String(loinc.ClassType)+"',"
				+    POut.Bool  (loinc.UnitsRequired)+","
				+"'"+POut.String(loinc.OrderObs)+"',"
				+"'"+POut.String(loinc.HL7FieldSubfieldID)+"',"
				+    DbHelper.ParamChar+"paramExternalCopyrightNotice,"
				+"'"+POut.String(loinc.NameLongCommon)+"',"
				+"'"+POut.String(loinc.UnitsUCUM)+"',"
				+    POut.Int   (loinc.RankCommonTests)+","
				+    POut.Int   (loinc.RankCommonOrders)+")";
			if(loinc.ExternalCopyrightNotice==null) {
				loinc.ExternalCopyrightNotice="";
			}
			OdSqlParameter paramExternalCopyrightNotice=new OdSqlParameter("paramExternalCopyrightNotice",OdDbType.Text,POut.StringParam(loinc.ExternalCopyrightNotice));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramExternalCopyrightNotice);
			}
			else {
				loinc.LoincNum=Db.NonQ(command,true,"LoincNum","loinc",paramExternalCopyrightNotice);
			}
			return loinc.LoincNum;
		}

		///<summary>Inserts one Loinc into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Loinc loinc) {
			return InsertNoCache(loinc,false);
		}

		///<summary>Inserts one Loinc into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Loinc loinc,bool useExistingPK) {
			
			string command="INSERT INTO loinc (";
			if(!useExistingPK) {
				loinc.LoincNum=ReplicationServers.GetKeyNoCache("loinc","LoincNum");
			}
			if(useExistingPK) {
				command+="LoincNum,";
			}
			command+="LoincCode,Component,PropertyObserved,TimeAspct,SystemMeasured,ScaleType,MethodType,StatusOfCode,NameShort,ClassType,UnitsRequired,OrderObs,HL7FieldSubfieldID,ExternalCopyrightNotice,NameLongCommon,UnitsUCUM,RankCommonTests,RankCommonOrders) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(loinc.LoincNum)+",";
			}
			command+=
				 "'"+POut.String(loinc.LoincCode)+"',"
				+"'"+POut.String(loinc.Component)+"',"
				+"'"+POut.String(loinc.PropertyObserved)+"',"
				+"'"+POut.String(loinc.TimeAspct)+"',"
				+"'"+POut.String(loinc.SystemMeasured)+"',"
				+"'"+POut.String(loinc.ScaleType)+"',"
				+"'"+POut.String(loinc.MethodType)+"',"
				+"'"+POut.String(loinc.StatusOfCode)+"',"
				+"'"+POut.String(loinc.NameShort)+"',"
				+"'"+POut.String(loinc.ClassType)+"',"
				+    POut.Bool  (loinc.UnitsRequired)+","
				+"'"+POut.String(loinc.OrderObs)+"',"
				+"'"+POut.String(loinc.HL7FieldSubfieldID)+"',"
				+    DbHelper.ParamChar+"paramExternalCopyrightNotice,"
				+"'"+POut.String(loinc.NameLongCommon)+"',"
				+"'"+POut.String(loinc.UnitsUCUM)+"',"
				+    POut.Int   (loinc.RankCommonTests)+","
				+    POut.Int   (loinc.RankCommonOrders)+")";
			if(loinc.ExternalCopyrightNotice==null) {
				loinc.ExternalCopyrightNotice="";
			}
			OdSqlParameter paramExternalCopyrightNotice=new OdSqlParameter("paramExternalCopyrightNotice",OdDbType.Text,POut.StringParam(loinc.ExternalCopyrightNotice));
			if(useExistingPK) {
				Db.NonQ(command,paramExternalCopyrightNotice);
			}
			else {
				loinc.LoincNum=Db.NonQ(command,true,"LoincNum","loinc",paramExternalCopyrightNotice);
			}
			return loinc.LoincNum;
		}

		///<summary>Updates one Loinc in the database.</summary>
		public static void Update(Loinc loinc) {
			string command="UPDATE loinc SET "
				+"LoincCode              = '"+POut.String(loinc.LoincCode)+"', "
				+"Component              = '"+POut.String(loinc.Component)+"', "
				+"PropertyObserved       = '"+POut.String(loinc.PropertyObserved)+"', "
				+"TimeAspct              = '"+POut.String(loinc.TimeAspct)+"', "
				+"SystemMeasured         = '"+POut.String(loinc.SystemMeasured)+"', "
				+"ScaleType              = '"+POut.String(loinc.ScaleType)+"', "
				+"MethodType             = '"+POut.String(loinc.MethodType)+"', "
				+"StatusOfCode           = '"+POut.String(loinc.StatusOfCode)+"', "
				+"NameShort              = '"+POut.String(loinc.NameShort)+"', "
				+"ClassType              = '"+POut.String(loinc.ClassType)+"', "
				+"UnitsRequired          =  "+POut.Bool  (loinc.UnitsRequired)+", "
				+"OrderObs               = '"+POut.String(loinc.OrderObs)+"', "
				+"HL7FieldSubfieldID     = '"+POut.String(loinc.HL7FieldSubfieldID)+"', "
				+"ExternalCopyrightNotice=  "+DbHelper.ParamChar+"paramExternalCopyrightNotice, "
				+"NameLongCommon         = '"+POut.String(loinc.NameLongCommon)+"', "
				+"UnitsUCUM              = '"+POut.String(loinc.UnitsUCUM)+"', "
				+"RankCommonTests        =  "+POut.Int   (loinc.RankCommonTests)+", "
				+"RankCommonOrders       =  "+POut.Int   (loinc.RankCommonOrders)+" "
				+"WHERE LoincNum = "+POut.Long(loinc.LoincNum);
			if(loinc.ExternalCopyrightNotice==null) {
				loinc.ExternalCopyrightNotice="";
			}
			OdSqlParameter paramExternalCopyrightNotice=new OdSqlParameter("paramExternalCopyrightNotice",OdDbType.Text,POut.StringParam(loinc.ExternalCopyrightNotice));
			Db.NonQ(command,paramExternalCopyrightNotice);
		}

		///<summary>Updates one Loinc in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Loinc loinc,Loinc oldLoinc) {
			string command="";
			if(loinc.LoincCode != oldLoinc.LoincCode) {
				if(command!="") { command+=",";}
				command+="LoincCode = '"+POut.String(loinc.LoincCode)+"'";
			}
			if(loinc.Component != oldLoinc.Component) {
				if(command!="") { command+=",";}
				command+="Component = '"+POut.String(loinc.Component)+"'";
			}
			if(loinc.PropertyObserved != oldLoinc.PropertyObserved) {
				if(command!="") { command+=",";}
				command+="PropertyObserved = '"+POut.String(loinc.PropertyObserved)+"'";
			}
			if(loinc.TimeAspct != oldLoinc.TimeAspct) {
				if(command!="") { command+=",";}
				command+="TimeAspct = '"+POut.String(loinc.TimeAspct)+"'";
			}
			if(loinc.SystemMeasured != oldLoinc.SystemMeasured) {
				if(command!="") { command+=",";}
				command+="SystemMeasured = '"+POut.String(loinc.SystemMeasured)+"'";
			}
			if(loinc.ScaleType != oldLoinc.ScaleType) {
				if(command!="") { command+=",";}
				command+="ScaleType = '"+POut.String(loinc.ScaleType)+"'";
			}
			if(loinc.MethodType != oldLoinc.MethodType) {
				if(command!="") { command+=",";}
				command+="MethodType = '"+POut.String(loinc.MethodType)+"'";
			}
			if(loinc.StatusOfCode != oldLoinc.StatusOfCode) {
				if(command!="") { command+=",";}
				command+="StatusOfCode = '"+POut.String(loinc.StatusOfCode)+"'";
			}
			if(loinc.NameShort != oldLoinc.NameShort) {
				if(command!="") { command+=",";}
				command+="NameShort = '"+POut.String(loinc.NameShort)+"'";
			}
			if(loinc.ClassType != oldLoinc.ClassType) {
				if(command!="") { command+=",";}
				command+="ClassType = '"+POut.String(loinc.ClassType)+"'";
			}
			if(loinc.UnitsRequired != oldLoinc.UnitsRequired) {
				if(command!="") { command+=",";}
				command+="UnitsRequired = "+POut.Bool(loinc.UnitsRequired)+"";
			}
			if(loinc.OrderObs != oldLoinc.OrderObs) {
				if(command!="") { command+=",";}
				command+="OrderObs = '"+POut.String(loinc.OrderObs)+"'";
			}
			if(loinc.HL7FieldSubfieldID != oldLoinc.HL7FieldSubfieldID) {
				if(command!="") { command+=",";}
				command+="HL7FieldSubfieldID = '"+POut.String(loinc.HL7FieldSubfieldID)+"'";
			}
			if(loinc.ExternalCopyrightNotice != oldLoinc.ExternalCopyrightNotice) {
				if(command!="") { command+=",";}
				command+="ExternalCopyrightNotice = "+DbHelper.ParamChar+"paramExternalCopyrightNotice";
			}
			if(loinc.NameLongCommon != oldLoinc.NameLongCommon) {
				if(command!="") { command+=",";}
				command+="NameLongCommon = '"+POut.String(loinc.NameLongCommon)+"'";
			}
			if(loinc.UnitsUCUM != oldLoinc.UnitsUCUM) {
				if(command!="") { command+=",";}
				command+="UnitsUCUM = '"+POut.String(loinc.UnitsUCUM)+"'";
			}
			if(loinc.RankCommonTests != oldLoinc.RankCommonTests) {
				if(command!="") { command+=",";}
				command+="RankCommonTests = "+POut.Int(loinc.RankCommonTests)+"";
			}
			if(loinc.RankCommonOrders != oldLoinc.RankCommonOrders) {
				if(command!="") { command+=",";}
				command+="RankCommonOrders = "+POut.Int(loinc.RankCommonOrders)+"";
			}
			if(command=="") {
				return false;
			}
			if(loinc.ExternalCopyrightNotice==null) {
				loinc.ExternalCopyrightNotice="";
			}
			OdSqlParameter paramExternalCopyrightNotice=new OdSqlParameter("paramExternalCopyrightNotice",OdDbType.Text,POut.StringParam(loinc.ExternalCopyrightNotice));
			command="UPDATE loinc SET "+command
				+" WHERE LoincNum = "+POut.Long(loinc.LoincNum);
			Db.NonQ(command,paramExternalCopyrightNotice);
			return true;
		}

		///<summary>Returns true if Update(Loinc,Loinc) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Loinc loinc,Loinc oldLoinc) {
			if(loinc.LoincCode != oldLoinc.LoincCode) {
				return true;
			}
			if(loinc.Component != oldLoinc.Component) {
				return true;
			}
			if(loinc.PropertyObserved != oldLoinc.PropertyObserved) {
				return true;
			}
			if(loinc.TimeAspct != oldLoinc.TimeAspct) {
				return true;
			}
			if(loinc.SystemMeasured != oldLoinc.SystemMeasured) {
				return true;
			}
			if(loinc.ScaleType != oldLoinc.ScaleType) {
				return true;
			}
			if(loinc.MethodType != oldLoinc.MethodType) {
				return true;
			}
			if(loinc.StatusOfCode != oldLoinc.StatusOfCode) {
				return true;
			}
			if(loinc.NameShort != oldLoinc.NameShort) {
				return true;
			}
			if(loinc.ClassType != oldLoinc.ClassType) {
				return true;
			}
			if(loinc.UnitsRequired != oldLoinc.UnitsRequired) {
				return true;
			}
			if(loinc.OrderObs != oldLoinc.OrderObs) {
				return true;
			}
			if(loinc.HL7FieldSubfieldID != oldLoinc.HL7FieldSubfieldID) {
				return true;
			}
			if(loinc.ExternalCopyrightNotice != oldLoinc.ExternalCopyrightNotice) {
				return true;
			}
			if(loinc.NameLongCommon != oldLoinc.NameLongCommon) {
				return true;
			}
			if(loinc.UnitsUCUM != oldLoinc.UnitsUCUM) {
				return true;
			}
			if(loinc.RankCommonTests != oldLoinc.RankCommonTests) {
				return true;
			}
			if(loinc.RankCommonOrders != oldLoinc.RankCommonOrders) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one Loinc from the database.</summary>
		public static void Delete(long loincNum) {
			string command="DELETE FROM loinc "
				+"WHERE LoincNum = "+POut.Long(loincNum);
			Db.NonQ(command);
		}

	}
}