//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class MedLabCrud {
		///<summary>Gets one MedLab object from the database using the primary key.  Returns null if not found.</summary>
		public static MedLab SelectOne(long medLabNum) {
			string command="SELECT * FROM medlab "
				+"WHERE MedLabNum = "+POut.Long(medLabNum);
			List<MedLab> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one MedLab object from the database using a query.</summary>
		public static MedLab SelectOne(string command) {

			List<MedLab> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of MedLab objects from the database using a query.</summary>
		public static List<MedLab> SelectMany(string command) {

			List<MedLab> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<MedLab> TableToList(DataTable table) {
			List<MedLab> retVal=new List<MedLab>();
			MedLab medLab;
			foreach(DataRow row in table.Rows) {
				medLab=new MedLab();
				medLab.MedLabNum          = PIn.Long  (row["MedLabNum"].ToString());
				medLab.ProvNum            = PIn.Long  (row["ProvNum"].ToString());
				medLab.SendingApp         = PIn.String(row["SendingApp"].ToString());
				medLab.SendingFacility    = PIn.String(row["SendingFacility"].ToString());
				medLab.PatNum             = PIn.Long  (row["PatNum"].ToString());
				medLab.PatIDLab           = PIn.String(row["PatIDLab"].ToString());
				medLab.PatIDAlt           = PIn.String(row["PatIDAlt"].ToString());
				medLab.PatAge             = PIn.String(row["PatAge"].ToString());
				medLab.PatAccountNum      = PIn.String(row["PatAccountNum"].ToString());
				medLab.PatFasting         = (OpenDentBusiness.YN)PIn.Int(row["PatFasting"].ToString());
				medLab.SpecimenID         = PIn.String(row["SpecimenID"].ToString());
				medLab.SpecimenIDFiller   = PIn.String(row["SpecimenIDFiller"].ToString());
				medLab.ObsTestID          = PIn.String(row["ObsTestID"].ToString());
				medLab.ObsTestDescript    = PIn.String(row["ObsTestDescript"].ToString());
				medLab.ObsTestLoinc       = PIn.String(row["ObsTestLoinc"].ToString());
				medLab.ObsTestLoincText   = PIn.String(row["ObsTestLoincText"].ToString());
				medLab.DateTimeCollected  = PIn.DateT (row["DateTimeCollected"].ToString());
				medLab.TotalVolume        = PIn.String(row["TotalVolume"].ToString());
				string actionCode=row["ActionCode"].ToString();
				if(actionCode=="") {
					medLab.ActionCode       =(OpenDentBusiness.ResultAction)0;
				}
				else try{
					medLab.ActionCode       =(OpenDentBusiness.ResultAction)Enum.Parse(typeof(OpenDentBusiness.ResultAction),actionCode);
				}
				catch{
					medLab.ActionCode       =(OpenDentBusiness.ResultAction)0;
				}
				medLab.ClinicalInfo       = PIn.String(row["ClinicalInfo"].ToString());
				medLab.DateTimeEntered    = PIn.DateT (row["DateTimeEntered"].ToString());
				medLab.OrderingProvNPI    = PIn.String(row["OrderingProvNPI"].ToString());
				medLab.OrderingProvLocalID= PIn.String(row["OrderingProvLocalID"].ToString());
				medLab.OrderingProvLName  = PIn.String(row["OrderingProvLName"].ToString());
				medLab.OrderingProvFName  = PIn.String(row["OrderingProvFName"].ToString());
				medLab.SpecimenIDAlt      = PIn.String(row["SpecimenIDAlt"].ToString());
				medLab.DateTimeReported   = PIn.DateT (row["DateTimeReported"].ToString());
				string resultStatus=row["ResultStatus"].ToString();
				if(resultStatus=="") {
					medLab.ResultStatus     =(OpenDentBusiness.ResultStatus)0;
				}
				else try{
					medLab.ResultStatus     =(OpenDentBusiness.ResultStatus)Enum.Parse(typeof(OpenDentBusiness.ResultStatus),resultStatus);
				}
				catch{
					medLab.ResultStatus     =(OpenDentBusiness.ResultStatus)0;
				}
				medLab.ParentObsID        = PIn.String(row["ParentObsID"].ToString());
				medLab.ParentObsTestID    = PIn.String(row["ParentObsTestID"].ToString());
				medLab.NotePat            = PIn.String(row["NotePat"].ToString());
				medLab.NoteLab            = PIn.String(row["NoteLab"].ToString());
				medLab.FileName           = PIn.String(row["FileName"].ToString());
				medLab.OriginalPIDSegment = PIn.String(row["OriginalPIDSegment"].ToString());
				retVal.Add(medLab);
			}
			return retVal;
		}

		///<summary>Converts a list of MedLab into a DataTable.</summary>
		public static DataTable ListToTable(List<MedLab> listMedLabs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="MedLab";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("MedLabNum");
			table.Columns.Add("ProvNum");
			table.Columns.Add("SendingApp");
			table.Columns.Add("SendingFacility");
			table.Columns.Add("PatNum");
			table.Columns.Add("PatIDLab");
			table.Columns.Add("PatIDAlt");
			table.Columns.Add("PatAge");
			table.Columns.Add("PatAccountNum");
			table.Columns.Add("PatFasting");
			table.Columns.Add("SpecimenID");
			table.Columns.Add("SpecimenIDFiller");
			table.Columns.Add("ObsTestID");
			table.Columns.Add("ObsTestDescript");
			table.Columns.Add("ObsTestLoinc");
			table.Columns.Add("ObsTestLoincText");
			table.Columns.Add("DateTimeCollected");
			table.Columns.Add("TotalVolume");
			table.Columns.Add("ActionCode");
			table.Columns.Add("ClinicalInfo");
			table.Columns.Add("DateTimeEntered");
			table.Columns.Add("OrderingProvNPI");
			table.Columns.Add("OrderingProvLocalID");
			table.Columns.Add("OrderingProvLName");
			table.Columns.Add("OrderingProvFName");
			table.Columns.Add("SpecimenIDAlt");
			table.Columns.Add("DateTimeReported");
			table.Columns.Add("ResultStatus");
			table.Columns.Add("ParentObsID");
			table.Columns.Add("ParentObsTestID");
			table.Columns.Add("NotePat");
			table.Columns.Add("NoteLab");
			table.Columns.Add("FileName");
			table.Columns.Add("OriginalPIDSegment");
			foreach(MedLab medLab in listMedLabs) {
				table.Rows.Add(new object[] {
					POut.Long  (medLab.MedLabNum),
					POut.Long  (medLab.ProvNum),
					            medLab.SendingApp,
					            medLab.SendingFacility,
					POut.Long  (medLab.PatNum),
					            medLab.PatIDLab,
					            medLab.PatIDAlt,
					            medLab.PatAge,
					            medLab.PatAccountNum,
					POut.Int   ((int)medLab.PatFasting),
					            medLab.SpecimenID,
					            medLab.SpecimenIDFiller,
					            medLab.ObsTestID,
					            medLab.ObsTestDescript,
					            medLab.ObsTestLoinc,
					            medLab.ObsTestLoincText,
					POut.DateT (medLab.DateTimeCollected,false),
					            medLab.TotalVolume,
					POut.Int   ((int)medLab.ActionCode),
					            medLab.ClinicalInfo,
					POut.DateT (medLab.DateTimeEntered,false),
					            medLab.OrderingProvNPI,
					            medLab.OrderingProvLocalID,
					            medLab.OrderingProvLName,
					            medLab.OrderingProvFName,
					            medLab.SpecimenIDAlt,
					POut.DateT (medLab.DateTimeReported,false),
					POut.Int   ((int)medLab.ResultStatus),
					            medLab.ParentObsID,
					            medLab.ParentObsTestID,
					            medLab.NotePat,
					            medLab.NoteLab,
					            medLab.FileName,
					            medLab.OriginalPIDSegment,
				});
			}
			return table;
		}

		///<summary>Inserts one MedLab into the database.  Returns the new priKey.</summary>
		public static long Insert(MedLab medLab) {
			return Insert(medLab,false);
		}

		///<summary>Inserts one MedLab into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(MedLab medLab,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				medLab.MedLabNum=ReplicationServers.GetKey("medlab","MedLabNum");
			}
			string command="INSERT INTO medlab (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="MedLabNum,";
			}
			command+="ProvNum,SendingApp,SendingFacility,PatNum,PatIDLab,PatIDAlt,PatAge,PatAccountNum,PatFasting,SpecimenID,SpecimenIDFiller,ObsTestID,ObsTestDescript,ObsTestLoinc,ObsTestLoincText,DateTimeCollected,TotalVolume,ActionCode,ClinicalInfo,DateTimeEntered,OrderingProvNPI,OrderingProvLocalID,OrderingProvLName,OrderingProvFName,SpecimenIDAlt,DateTimeReported,ResultStatus,ParentObsID,ParentObsTestID,NotePat,NoteLab,FileName,OriginalPIDSegment) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(medLab.MedLabNum)+",";
			}
			command+=
				     POut.Long  (medLab.ProvNum)+","
				+"'"+POut.String(medLab.SendingApp)+"',"
				+"'"+POut.String(medLab.SendingFacility)+"',"
				+    POut.Long  (medLab.PatNum)+","
				+"'"+POut.String(medLab.PatIDLab)+"',"
				+"'"+POut.String(medLab.PatIDAlt)+"',"
				+"'"+POut.String(medLab.PatAge)+"',"
				+"'"+POut.String(medLab.PatAccountNum)+"',"
				+    POut.Int   ((int)medLab.PatFasting)+","
				+"'"+POut.String(medLab.SpecimenID)+"',"
				+"'"+POut.String(medLab.SpecimenIDFiller)+"',"
				+"'"+POut.String(medLab.ObsTestID)+"',"
				+"'"+POut.String(medLab.ObsTestDescript)+"',"
				+"'"+POut.String(medLab.ObsTestLoinc)+"',"
				+"'"+POut.String(medLab.ObsTestLoincText)+"',"
				+    POut.DateT (medLab.DateTimeCollected)+","
				+"'"+POut.String(medLab.TotalVolume)+"',"
				+"'"+POut.String(medLab.ActionCode.ToString())+"',"
				+"'"+POut.String(medLab.ClinicalInfo)+"',"
				+    POut.DateT (medLab.DateTimeEntered)+","
				+"'"+POut.String(medLab.OrderingProvNPI)+"',"
				+"'"+POut.String(medLab.OrderingProvLocalID)+"',"
				+"'"+POut.String(medLab.OrderingProvLName)+"',"
				+"'"+POut.String(medLab.OrderingProvFName)+"',"
				+"'"+POut.String(medLab.SpecimenIDAlt)+"',"
				+    POut.DateT (medLab.DateTimeReported)+","
				+"'"+POut.String(medLab.ResultStatus.ToString())+"',"
				+"'"+POut.String(medLab.ParentObsID)+"',"
				+"'"+POut.String(medLab.ParentObsTestID)+"',"
				+    DbHelper.ParamChar+"paramNotePat,"
				+    DbHelper.ParamChar+"paramNoteLab,"
				+"'"+POut.String(medLab.FileName)+"',"
				+    DbHelper.ParamChar+"paramOriginalPIDSegment)";
			if(medLab.NotePat==null) {
				medLab.NotePat="";
			}
			OdSqlParameter paramNotePat=new OdSqlParameter("paramNotePat",OdDbType.Text,POut.StringParam(medLab.NotePat));
			if(medLab.NoteLab==null) {
				medLab.NoteLab="";
			}
			OdSqlParameter paramNoteLab=new OdSqlParameter("paramNoteLab",OdDbType.Text,POut.StringParam(medLab.NoteLab));
			if(medLab.OriginalPIDSegment==null) {
				medLab.OriginalPIDSegment="";
			}
			OdSqlParameter paramOriginalPIDSegment=new OdSqlParameter("paramOriginalPIDSegment",OdDbType.Text,POut.StringParam(medLab.OriginalPIDSegment));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramNotePat,paramNoteLab,paramOriginalPIDSegment);
			}
			else {
				medLab.MedLabNum=Db.NonQ(command,true,"MedLabNum","medLab",paramNotePat,paramNoteLab,paramOriginalPIDSegment);
			}
			return medLab.MedLabNum;
		}

		///<summary>Inserts one MedLab into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(MedLab medLab) {
			return InsertNoCache(medLab,false);
		}

		///<summary>Inserts one MedLab into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(MedLab medLab,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO medlab (";
			if(!useExistingPK && isRandomKeys) {
				medLab.MedLabNum=ReplicationServers.GetKeyNoCache("medlab","MedLabNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="MedLabNum,";
			}
			command+="ProvNum,SendingApp,SendingFacility,PatNum,PatIDLab,PatIDAlt,PatAge,PatAccountNum,PatFasting,SpecimenID,SpecimenIDFiller,ObsTestID,ObsTestDescript,ObsTestLoinc,ObsTestLoincText,DateTimeCollected,TotalVolume,ActionCode,ClinicalInfo,DateTimeEntered,OrderingProvNPI,OrderingProvLocalID,OrderingProvLName,OrderingProvFName,SpecimenIDAlt,DateTimeReported,ResultStatus,ParentObsID,ParentObsTestID,NotePat,NoteLab,FileName,OriginalPIDSegment) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(medLab.MedLabNum)+",";
			}
			command+=
				     POut.Long  (medLab.ProvNum)+","
				+"'"+POut.String(medLab.SendingApp)+"',"
				+"'"+POut.String(medLab.SendingFacility)+"',"
				+    POut.Long  (medLab.PatNum)+","
				+"'"+POut.String(medLab.PatIDLab)+"',"
				+"'"+POut.String(medLab.PatIDAlt)+"',"
				+"'"+POut.String(medLab.PatAge)+"',"
				+"'"+POut.String(medLab.PatAccountNum)+"',"
				+    POut.Int   ((int)medLab.PatFasting)+","
				+"'"+POut.String(medLab.SpecimenID)+"',"
				+"'"+POut.String(medLab.SpecimenIDFiller)+"',"
				+"'"+POut.String(medLab.ObsTestID)+"',"
				+"'"+POut.String(medLab.ObsTestDescript)+"',"
				+"'"+POut.String(medLab.ObsTestLoinc)+"',"
				+"'"+POut.String(medLab.ObsTestLoincText)+"',"
				+    POut.DateT (medLab.DateTimeCollected)+","
				+"'"+POut.String(medLab.TotalVolume)+"',"
				+"'"+POut.String(medLab.ActionCode.ToString())+"',"
				+"'"+POut.String(medLab.ClinicalInfo)+"',"
				+    POut.DateT (medLab.DateTimeEntered)+","
				+"'"+POut.String(medLab.OrderingProvNPI)+"',"
				+"'"+POut.String(medLab.OrderingProvLocalID)+"',"
				+"'"+POut.String(medLab.OrderingProvLName)+"',"
				+"'"+POut.String(medLab.OrderingProvFName)+"',"
				+"'"+POut.String(medLab.SpecimenIDAlt)+"',"
				+    POut.DateT (medLab.DateTimeReported)+","
				+"'"+POut.String(medLab.ResultStatus.ToString())+"',"
				+"'"+POut.String(medLab.ParentObsID)+"',"
				+"'"+POut.String(medLab.ParentObsTestID)+"',"
				+    DbHelper.ParamChar+"paramNotePat,"
				+    DbHelper.ParamChar+"paramNoteLab,"
				+"'"+POut.String(medLab.FileName)+"',"
				+    DbHelper.ParamChar+"paramOriginalPIDSegment)";
			if(medLab.NotePat==null) {
				medLab.NotePat="";
			}
			OdSqlParameter paramNotePat=new OdSqlParameter("paramNotePat",OdDbType.Text,POut.StringParam(medLab.NotePat));
			if(medLab.NoteLab==null) {
				medLab.NoteLab="";
			}
			OdSqlParameter paramNoteLab=new OdSqlParameter("paramNoteLab",OdDbType.Text,POut.StringParam(medLab.NoteLab));
			if(medLab.OriginalPIDSegment==null) {
				medLab.OriginalPIDSegment="";
			}
			OdSqlParameter paramOriginalPIDSegment=new OdSqlParameter("paramOriginalPIDSegment",OdDbType.Text,POut.StringParam(medLab.OriginalPIDSegment));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramNotePat,paramNoteLab,paramOriginalPIDSegment);
			}
			else {
				medLab.MedLabNum=Db.NonQ(command,true,"MedLabNum","medLab",paramNotePat,paramNoteLab,paramOriginalPIDSegment);
			}
			return medLab.MedLabNum;
		}

		///<summary>Updates one MedLab in the database.</summary>
		public static void Update(MedLab medLab) {
			string command="UPDATE medlab SET "
				+"ProvNum            =  "+POut.Long  (medLab.ProvNum)+", "
				+"SendingApp         = '"+POut.String(medLab.SendingApp)+"', "
				+"SendingFacility    = '"+POut.String(medLab.SendingFacility)+"', "
				+"PatNum             =  "+POut.Long  (medLab.PatNum)+", "
				+"PatIDLab           = '"+POut.String(medLab.PatIDLab)+"', "
				+"PatIDAlt           = '"+POut.String(medLab.PatIDAlt)+"', "
				+"PatAge             = '"+POut.String(medLab.PatAge)+"', "
				+"PatAccountNum      = '"+POut.String(medLab.PatAccountNum)+"', "
				+"PatFasting         =  "+POut.Int   ((int)medLab.PatFasting)+", "
				+"SpecimenID         = '"+POut.String(medLab.SpecimenID)+"', "
				+"SpecimenIDFiller   = '"+POut.String(medLab.SpecimenIDFiller)+"', "
				+"ObsTestID          = '"+POut.String(medLab.ObsTestID)+"', "
				+"ObsTestDescript    = '"+POut.String(medLab.ObsTestDescript)+"', "
				+"ObsTestLoinc       = '"+POut.String(medLab.ObsTestLoinc)+"', "
				+"ObsTestLoincText   = '"+POut.String(medLab.ObsTestLoincText)+"', "
				+"DateTimeCollected  =  "+POut.DateT (medLab.DateTimeCollected)+", "
				+"TotalVolume        = '"+POut.String(medLab.TotalVolume)+"', "
				+"ActionCode         = '"+POut.String(medLab.ActionCode.ToString())+"', "
				+"ClinicalInfo       = '"+POut.String(medLab.ClinicalInfo)+"', "
				+"DateTimeEntered    =  "+POut.DateT (medLab.DateTimeEntered)+", "
				+"OrderingProvNPI    = '"+POut.String(medLab.OrderingProvNPI)+"', "
				+"OrderingProvLocalID= '"+POut.String(medLab.OrderingProvLocalID)+"', "
				+"OrderingProvLName  = '"+POut.String(medLab.OrderingProvLName)+"', "
				+"OrderingProvFName  = '"+POut.String(medLab.OrderingProvFName)+"', "
				+"SpecimenIDAlt      = '"+POut.String(medLab.SpecimenIDAlt)+"', "
				+"DateTimeReported   =  "+POut.DateT (medLab.DateTimeReported)+", "
				+"ResultStatus       = '"+POut.String(medLab.ResultStatus.ToString())+"', "
				+"ParentObsID        = '"+POut.String(medLab.ParentObsID)+"', "
				+"ParentObsTestID    = '"+POut.String(medLab.ParentObsTestID)+"', "
				+"NotePat            =  "+DbHelper.ParamChar+"paramNotePat, "
				+"NoteLab            =  "+DbHelper.ParamChar+"paramNoteLab, "
				+"FileName           = '"+POut.String(medLab.FileName)+"', "
				+"OriginalPIDSegment =  "+DbHelper.ParamChar+"paramOriginalPIDSegment "
				+"WHERE MedLabNum = "+POut.Long(medLab.MedLabNum);
			if(medLab.NotePat==null) {
				medLab.NotePat="";
			}
			OdSqlParameter paramNotePat=new OdSqlParameter("paramNotePat",OdDbType.Text,POut.StringParam(medLab.NotePat));
			if(medLab.NoteLab==null) {
				medLab.NoteLab="";
			}
			OdSqlParameter paramNoteLab=new OdSqlParameter("paramNoteLab",OdDbType.Text,POut.StringParam(medLab.NoteLab));
			if(medLab.OriginalPIDSegment==null) {
				medLab.OriginalPIDSegment="";
			}
			OdSqlParameter paramOriginalPIDSegment=new OdSqlParameter("paramOriginalPIDSegment",OdDbType.Text,POut.StringParam(medLab.OriginalPIDSegment));
			Db.NonQ(command,paramNotePat,paramNoteLab,paramOriginalPIDSegment);
		}

		///<summary>Updates one MedLab in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(MedLab medLab,MedLab oldMedLab) {
			string command="";
			if(medLab.ProvNum != oldMedLab.ProvNum) {
				if(command!="") { command+=",";}
				command+="ProvNum = "+POut.Long(medLab.ProvNum)+"";
			}
			if(medLab.SendingApp != oldMedLab.SendingApp) {
				if(command!="") { command+=",";}
				command+="SendingApp = '"+POut.String(medLab.SendingApp)+"'";
			}
			if(medLab.SendingFacility != oldMedLab.SendingFacility) {
				if(command!="") { command+=",";}
				command+="SendingFacility = '"+POut.String(medLab.SendingFacility)+"'";
			}
			if(medLab.PatNum != oldMedLab.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(medLab.PatNum)+"";
			}
			if(medLab.PatIDLab != oldMedLab.PatIDLab) {
				if(command!="") { command+=",";}
				command+="PatIDLab = '"+POut.String(medLab.PatIDLab)+"'";
			}
			if(medLab.PatIDAlt != oldMedLab.PatIDAlt) {
				if(command!="") { command+=",";}
				command+="PatIDAlt = '"+POut.String(medLab.PatIDAlt)+"'";
			}
			if(medLab.PatAge != oldMedLab.PatAge) {
				if(command!="") { command+=",";}
				command+="PatAge = '"+POut.String(medLab.PatAge)+"'";
			}
			if(medLab.PatAccountNum != oldMedLab.PatAccountNum) {
				if(command!="") { command+=",";}
				command+="PatAccountNum = '"+POut.String(medLab.PatAccountNum)+"'";
			}
			if(medLab.PatFasting != oldMedLab.PatFasting) {
				if(command!="") { command+=",";}
				command+="PatFasting = "+POut.Int   ((int)medLab.PatFasting)+"";
			}
			if(medLab.SpecimenID != oldMedLab.SpecimenID) {
				if(command!="") { command+=",";}
				command+="SpecimenID = '"+POut.String(medLab.SpecimenID)+"'";
			}
			if(medLab.SpecimenIDFiller != oldMedLab.SpecimenIDFiller) {
				if(command!="") { command+=",";}
				command+="SpecimenIDFiller = '"+POut.String(medLab.SpecimenIDFiller)+"'";
			}
			if(medLab.ObsTestID != oldMedLab.ObsTestID) {
				if(command!="") { command+=",";}
				command+="ObsTestID = '"+POut.String(medLab.ObsTestID)+"'";
			}
			if(medLab.ObsTestDescript != oldMedLab.ObsTestDescript) {
				if(command!="") { command+=",";}
				command+="ObsTestDescript = '"+POut.String(medLab.ObsTestDescript)+"'";
			}
			if(medLab.ObsTestLoinc != oldMedLab.ObsTestLoinc) {
				if(command!="") { command+=",";}
				command+="ObsTestLoinc = '"+POut.String(medLab.ObsTestLoinc)+"'";
			}
			if(medLab.ObsTestLoincText != oldMedLab.ObsTestLoincText) {
				if(command!="") { command+=",";}
				command+="ObsTestLoincText = '"+POut.String(medLab.ObsTestLoincText)+"'";
			}
			if(medLab.DateTimeCollected != oldMedLab.DateTimeCollected) {
				if(command!="") { command+=",";}
				command+="DateTimeCollected = "+POut.DateT(medLab.DateTimeCollected)+"";
			}
			if(medLab.TotalVolume != oldMedLab.TotalVolume) {
				if(command!="") { command+=",";}
				command+="TotalVolume = '"+POut.String(medLab.TotalVolume)+"'";
			}
			if(medLab.ActionCode != oldMedLab.ActionCode) {
				if(command!="") { command+=",";}
				command+="ActionCode = '"+POut.String(medLab.ActionCode.ToString())+"'";
			}
			if(medLab.ClinicalInfo != oldMedLab.ClinicalInfo) {
				if(command!="") { command+=",";}
				command+="ClinicalInfo = '"+POut.String(medLab.ClinicalInfo)+"'";
			}
			if(medLab.DateTimeEntered != oldMedLab.DateTimeEntered) {
				if(command!="") { command+=",";}
				command+="DateTimeEntered = "+POut.DateT(medLab.DateTimeEntered)+"";
			}
			if(medLab.OrderingProvNPI != oldMedLab.OrderingProvNPI) {
				if(command!="") { command+=",";}
				command+="OrderingProvNPI = '"+POut.String(medLab.OrderingProvNPI)+"'";
			}
			if(medLab.OrderingProvLocalID != oldMedLab.OrderingProvLocalID) {
				if(command!="") { command+=",";}
				command+="OrderingProvLocalID = '"+POut.String(medLab.OrderingProvLocalID)+"'";
			}
			if(medLab.OrderingProvLName != oldMedLab.OrderingProvLName) {
				if(command!="") { command+=",";}
				command+="OrderingProvLName = '"+POut.String(medLab.OrderingProvLName)+"'";
			}
			if(medLab.OrderingProvFName != oldMedLab.OrderingProvFName) {
				if(command!="") { command+=",";}
				command+="OrderingProvFName = '"+POut.String(medLab.OrderingProvFName)+"'";
			}
			if(medLab.SpecimenIDAlt != oldMedLab.SpecimenIDAlt) {
				if(command!="") { command+=",";}
				command+="SpecimenIDAlt = '"+POut.String(medLab.SpecimenIDAlt)+"'";
			}
			if(medLab.DateTimeReported != oldMedLab.DateTimeReported) {
				if(command!="") { command+=",";}
				command+="DateTimeReported = "+POut.DateT(medLab.DateTimeReported)+"";
			}
			if(medLab.ResultStatus != oldMedLab.ResultStatus) {
				if(command!="") { command+=",";}
				command+="ResultStatus = '"+POut.String(medLab.ResultStatus.ToString())+"'";
			}
			if(medLab.ParentObsID != oldMedLab.ParentObsID) {
				if(command!="") { command+=",";}
				command+="ParentObsID = '"+POut.String(medLab.ParentObsID)+"'";
			}
			if(medLab.ParentObsTestID != oldMedLab.ParentObsTestID) {
				if(command!="") { command+=",";}
				command+="ParentObsTestID = '"+POut.String(medLab.ParentObsTestID)+"'";
			}
			if(medLab.NotePat != oldMedLab.NotePat) {
				if(command!="") { command+=",";}
				command+="NotePat = "+DbHelper.ParamChar+"paramNotePat";
			}
			if(medLab.NoteLab != oldMedLab.NoteLab) {
				if(command!="") { command+=",";}
				command+="NoteLab = "+DbHelper.ParamChar+"paramNoteLab";
			}
			if(medLab.FileName != oldMedLab.FileName) {
				if(command!="") { command+=",";}
				command+="FileName = '"+POut.String(medLab.FileName)+"'";
			}
			if(medLab.OriginalPIDSegment != oldMedLab.OriginalPIDSegment) {
				if(command!="") { command+=",";}
				command+="OriginalPIDSegment = "+DbHelper.ParamChar+"paramOriginalPIDSegment";
			}
			if(command=="") {
				return false;
			}
			if(medLab.NotePat==null) {
				medLab.NotePat="";
			}
			OdSqlParameter paramNotePat=new OdSqlParameter("paramNotePat",OdDbType.Text,POut.StringParam(medLab.NotePat));
			if(medLab.NoteLab==null) {
				medLab.NoteLab="";
			}
			OdSqlParameter paramNoteLab=new OdSqlParameter("paramNoteLab",OdDbType.Text,POut.StringParam(medLab.NoteLab));
			if(medLab.OriginalPIDSegment==null) {
				medLab.OriginalPIDSegment="";
			}
			OdSqlParameter paramOriginalPIDSegment=new OdSqlParameter("paramOriginalPIDSegment",OdDbType.Text,POut.StringParam(medLab.OriginalPIDSegment));
			command="UPDATE medlab SET "+command
				+" WHERE MedLabNum = "+POut.Long(medLab.MedLabNum);
			Db.NonQ(command,paramNotePat,paramNoteLab,paramOriginalPIDSegment);
			return true;
		}

		///<summary>Returns true if Update(MedLab,MedLab) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(MedLab medLab,MedLab oldMedLab) {
			if(medLab.ProvNum != oldMedLab.ProvNum) {
				return true;
			}
			if(medLab.SendingApp != oldMedLab.SendingApp) {
				return true;
			}
			if(medLab.SendingFacility != oldMedLab.SendingFacility) {
				return true;
			}
			if(medLab.PatNum != oldMedLab.PatNum) {
				return true;
			}
			if(medLab.PatIDLab != oldMedLab.PatIDLab) {
				return true;
			}
			if(medLab.PatIDAlt != oldMedLab.PatIDAlt) {
				return true;
			}
			if(medLab.PatAge != oldMedLab.PatAge) {
				return true;
			}
			if(medLab.PatAccountNum != oldMedLab.PatAccountNum) {
				return true;
			}
			if(medLab.PatFasting != oldMedLab.PatFasting) {
				return true;
			}
			if(medLab.SpecimenID != oldMedLab.SpecimenID) {
				return true;
			}
			if(medLab.SpecimenIDFiller != oldMedLab.SpecimenIDFiller) {
				return true;
			}
			if(medLab.ObsTestID != oldMedLab.ObsTestID) {
				return true;
			}
			if(medLab.ObsTestDescript != oldMedLab.ObsTestDescript) {
				return true;
			}
			if(medLab.ObsTestLoinc != oldMedLab.ObsTestLoinc) {
				return true;
			}
			if(medLab.ObsTestLoincText != oldMedLab.ObsTestLoincText) {
				return true;
			}
			if(medLab.DateTimeCollected != oldMedLab.DateTimeCollected) {
				return true;
			}
			if(medLab.TotalVolume != oldMedLab.TotalVolume) {
				return true;
			}
			if(medLab.ActionCode != oldMedLab.ActionCode) {
				return true;
			}
			if(medLab.ClinicalInfo != oldMedLab.ClinicalInfo) {
				return true;
			}
			if(medLab.DateTimeEntered != oldMedLab.DateTimeEntered) {
				return true;
			}
			if(medLab.OrderingProvNPI != oldMedLab.OrderingProvNPI) {
				return true;
			}
			if(medLab.OrderingProvLocalID != oldMedLab.OrderingProvLocalID) {
				return true;
			}
			if(medLab.OrderingProvLName != oldMedLab.OrderingProvLName) {
				return true;
			}
			if(medLab.OrderingProvFName != oldMedLab.OrderingProvFName) {
				return true;
			}
			if(medLab.SpecimenIDAlt != oldMedLab.SpecimenIDAlt) {
				return true;
			}
			if(medLab.DateTimeReported != oldMedLab.DateTimeReported) {
				return true;
			}
			if(medLab.ResultStatus != oldMedLab.ResultStatus) {
				return true;
			}
			if(medLab.ParentObsID != oldMedLab.ParentObsID) {
				return true;
			}
			if(medLab.ParentObsTestID != oldMedLab.ParentObsTestID) {
				return true;
			}
			if(medLab.NotePat != oldMedLab.NotePat) {
				return true;
			}
			if(medLab.NoteLab != oldMedLab.NoteLab) {
				return true;
			}
			if(medLab.FileName != oldMedLab.FileName) {
				return true;
			}
			if(medLab.OriginalPIDSegment != oldMedLab.OriginalPIDSegment) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one MedLab from the database.</summary>
		public static void Delete(long medLabNum) {
			string command="DELETE FROM medlab "
				+"WHERE MedLabNum = "+POut.Long(medLabNum);
			Db.NonQ(command);
		}

	}
}