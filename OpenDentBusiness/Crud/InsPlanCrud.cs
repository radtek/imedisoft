//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class InsPlanCrud {
		///<summary>Gets one InsPlan object from the database using the primary key.  Returns null if not found.</summary>
		public static InsPlan SelectOne(long planNum) {
			string command="SELECT * FROM insplan "
				+"WHERE PlanNum = "+POut.Long(planNum);
			List<InsPlan> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one InsPlan object from the database using a query.</summary>
		public static InsPlan SelectOne(string command) {

			List<InsPlan> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of InsPlan objects from the database using a query.</summary>
		public static List<InsPlan> SelectMany(string command) {

			List<InsPlan> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<InsPlan> TableToList(DataTable table) {
			List<InsPlan> retVal=new List<InsPlan>();
			InsPlan insPlan;
			foreach(DataRow row in table.Rows) {
				insPlan=new InsPlan();
				insPlan.PlanNum                     = PIn.Long  (row["PlanNum"].ToString());
				insPlan.GroupName                   = PIn.String(row["GroupName"].ToString());
				insPlan.GroupNum                    = PIn.String(row["GroupNum"].ToString());
				insPlan.PlanNote                    = PIn.String(row["PlanNote"].ToString());
				insPlan.FeeSched                    = PIn.Long  (row["FeeSched"].ToString());
				insPlan.PlanType                    = PIn.String(row["PlanType"].ToString());
				insPlan.ClaimFormNum                = PIn.Long  (row["ClaimFormNum"].ToString());
				insPlan.UseAltCode                  = PIn.Bool  (row["UseAltCode"].ToString());
				insPlan.ClaimsUseUCR                = PIn.Bool  (row["ClaimsUseUCR"].ToString());
				insPlan.CopayFeeSched               = PIn.Long  (row["CopayFeeSched"].ToString());
				insPlan.EmployerNum                 = PIn.Long  (row["EmployerNum"].ToString());
				insPlan.CarrierNum                  = PIn.Long  (row["CarrierNum"].ToString());
				insPlan.AllowedFeeSched             = PIn.Long  (row["AllowedFeeSched"].ToString());
				insPlan.TrojanID                    = PIn.String(row["TrojanID"].ToString());
				insPlan.DivisionNo                  = PIn.String(row["DivisionNo"].ToString());
				insPlan.IsMedical                   = PIn.Bool  (row["IsMedical"].ToString());
				insPlan.FilingCode                  = PIn.Long  (row["FilingCode"].ToString());
				insPlan.DentaideCardSequence        = PIn.Byte  (row["DentaideCardSequence"].ToString());
				insPlan.ShowBaseUnits               = PIn.Bool  (row["ShowBaseUnits"].ToString());
				insPlan.CodeSubstNone               = PIn.Bool  (row["CodeSubstNone"].ToString());
				insPlan.IsHidden                    = PIn.Bool  (row["IsHidden"].ToString());
				insPlan.MonthRenew                  = PIn.Byte  (row["MonthRenew"].ToString());
				insPlan.FilingCodeSubtype           = PIn.Long  (row["FilingCodeSubtype"].ToString());
				insPlan.CanadianPlanFlag            = PIn.String(row["CanadianPlanFlag"].ToString());
				insPlan.CanadianDiagnosticCode      = PIn.String(row["CanadianDiagnosticCode"].ToString());
				insPlan.CanadianInstitutionCode     = PIn.String(row["CanadianInstitutionCode"].ToString());
				insPlan.RxBIN                       = PIn.String(row["RxBIN"].ToString());
				insPlan.CobRule                     = (OpenDentBusiness.EnumCobRule)PIn.Int(row["CobRule"].ToString());
				insPlan.SopCode                     = PIn.String(row["SopCode"].ToString());
				insPlan.SecUserNumEntry             = PIn.Long  (row["SecUserNumEntry"].ToString());
				insPlan.SecDateEntry                = PIn.Date  (row["SecDateEntry"].ToString());
				insPlan.SecDateTEdit                = PIn.Date (row["SecDateTEdit"].ToString());
				insPlan.HideFromVerifyList          = PIn.Bool  (row["HideFromVerifyList"].ToString());
				insPlan.OrthoType                   = (OpenDentBusiness.OrthoClaimType)PIn.Int(row["OrthoType"].ToString());
				insPlan.OrthoAutoProcFreq           = (OpenDentBusiness.OrthoAutoProcFrequency)PIn.Int(row["OrthoAutoProcFreq"].ToString());
				insPlan.OrthoAutoProcCodeNumOverride= PIn.Long  (row["OrthoAutoProcCodeNumOverride"].ToString());
				insPlan.OrthoAutoFeeBilled          = PIn.Double(row["OrthoAutoFeeBilled"].ToString());
				insPlan.OrthoAutoClaimDaysWait      = PIn.Int   (row["OrthoAutoClaimDaysWait"].ToString());
				insPlan.BillingType                 = PIn.Long  (row["BillingType"].ToString());
				insPlan.HasPpoSubstWriteoffs        = PIn.Bool  (row["HasPpoSubstWriteoffs"].ToString());
				insPlan.ExclusionFeeRule            = (OpenDentBusiness.ExclusionRule)PIn.Int(row["ExclusionFeeRule"].ToString());
				retVal.Add(insPlan);
			}
			return retVal;
		}

		///<summary>Converts a list of InsPlan into a DataTable.</summary>
		public static DataTable ListToTable(List<InsPlan> listInsPlans,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="InsPlan";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("PlanNum");
			table.Columns.Add("GroupName");
			table.Columns.Add("GroupNum");
			table.Columns.Add("PlanNote");
			table.Columns.Add("FeeSched");
			table.Columns.Add("PlanType");
			table.Columns.Add("ClaimFormNum");
			table.Columns.Add("UseAltCode");
			table.Columns.Add("ClaimsUseUCR");
			table.Columns.Add("CopayFeeSched");
			table.Columns.Add("EmployerNum");
			table.Columns.Add("CarrierNum");
			table.Columns.Add("AllowedFeeSched");
			table.Columns.Add("TrojanID");
			table.Columns.Add("DivisionNo");
			table.Columns.Add("IsMedical");
			table.Columns.Add("FilingCode");
			table.Columns.Add("DentaideCardSequence");
			table.Columns.Add("ShowBaseUnits");
			table.Columns.Add("CodeSubstNone");
			table.Columns.Add("IsHidden");
			table.Columns.Add("MonthRenew");
			table.Columns.Add("FilingCodeSubtype");
			table.Columns.Add("CanadianPlanFlag");
			table.Columns.Add("CanadianDiagnosticCode");
			table.Columns.Add("CanadianInstitutionCode");
			table.Columns.Add("RxBIN");
			table.Columns.Add("CobRule");
			table.Columns.Add("SopCode");
			table.Columns.Add("SecUserNumEntry");
			table.Columns.Add("SecDateEntry");
			table.Columns.Add("SecDateTEdit");
			table.Columns.Add("HideFromVerifyList");
			table.Columns.Add("OrthoType");
			table.Columns.Add("OrthoAutoProcFreq");
			table.Columns.Add("OrthoAutoProcCodeNumOverride");
			table.Columns.Add("OrthoAutoFeeBilled");
			table.Columns.Add("OrthoAutoClaimDaysWait");
			table.Columns.Add("BillingType");
			table.Columns.Add("HasPpoSubstWriteoffs");
			table.Columns.Add("ExclusionFeeRule");
			foreach(InsPlan insPlan in listInsPlans) {
				table.Rows.Add(new object[] {
					POut.Long  (insPlan.PlanNum),
					            insPlan.GroupName,
					            insPlan.GroupNum,
					            insPlan.PlanNote,
					POut.Long  (insPlan.FeeSched),
					            insPlan.PlanType,
					POut.Long  (insPlan.ClaimFormNum),
					POut.Bool  (insPlan.UseAltCode),
					POut.Bool  (insPlan.ClaimsUseUCR),
					POut.Long  (insPlan.CopayFeeSched),
					POut.Long  (insPlan.EmployerNum),
					POut.Long  (insPlan.CarrierNum),
					POut.Long  (insPlan.AllowedFeeSched),
					            insPlan.TrojanID,
					            insPlan.DivisionNo,
					POut.Bool  (insPlan.IsMedical),
					POut.Long  (insPlan.FilingCode),
					POut.Byte  (insPlan.DentaideCardSequence),
					POut.Bool  (insPlan.ShowBaseUnits),
					POut.Bool  (insPlan.CodeSubstNone),
					POut.Bool  (insPlan.IsHidden),
					POut.Byte  (insPlan.MonthRenew),
					POut.Long  (insPlan.FilingCodeSubtype),
					            insPlan.CanadianPlanFlag,
					            insPlan.CanadianDiagnosticCode,
					            insPlan.CanadianInstitutionCode,
					            insPlan.RxBIN,
					POut.Int   ((int)insPlan.CobRule),
					            insPlan.SopCode,
					POut.Long  (insPlan.SecUserNumEntry),
					POut.DateT (insPlan.SecDateEntry,false),
					POut.DateT (insPlan.SecDateTEdit,false),
					POut.Bool  (insPlan.HideFromVerifyList),
					POut.Int   ((int)insPlan.OrthoType),
					POut.Int   ((int)insPlan.OrthoAutoProcFreq),
					POut.Long  (insPlan.OrthoAutoProcCodeNumOverride),
					POut.Double(insPlan.OrthoAutoFeeBilled),
					POut.Int   (insPlan.OrthoAutoClaimDaysWait),
					POut.Long  (insPlan.BillingType),
					POut.Bool  (insPlan.HasPpoSubstWriteoffs),
					POut.Int   ((int)insPlan.ExclusionFeeRule),
				});
			}
			return table;
		}

		///<summary>Inserts one InsPlan into the database.  Returns the new priKey.</summary>
		public static long Insert(InsPlan insPlan) {
			return Insert(insPlan,false);
		}

		///<summary>Inserts one InsPlan into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(InsPlan insPlan,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				insPlan.PlanNum=ReplicationServers.GetKey("insplan","PlanNum");
			}
			string command="INSERT INTO insplan (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="PlanNum,";
			}
			command+="GroupName,GroupNum,PlanNote,FeeSched,PlanType,ClaimFormNum,UseAltCode,ClaimsUseUCR,CopayFeeSched,EmployerNum,CarrierNum,AllowedFeeSched,TrojanID,DivisionNo,IsMedical,FilingCode,DentaideCardSequence,ShowBaseUnits,CodeSubstNone,IsHidden,MonthRenew,FilingCodeSubtype,CanadianPlanFlag,CanadianDiagnosticCode,CanadianInstitutionCode,RxBIN,CobRule,SopCode,SecUserNumEntry,SecDateEntry,HideFromVerifyList,OrthoType,OrthoAutoProcFreq,OrthoAutoProcCodeNumOverride,OrthoAutoFeeBilled,OrthoAutoClaimDaysWait,BillingType,HasPpoSubstWriteoffs,ExclusionFeeRule) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(insPlan.PlanNum)+",";
			}
			command+=
				 "'"+POut.String(insPlan.GroupName)+"',"
				+"'"+POut.String(insPlan.GroupNum)+"',"
				+    DbHelper.ParamChar+"paramPlanNote,"
				+    POut.Long  (insPlan.FeeSched)+","
				+"'"+POut.String(insPlan.PlanType)+"',"
				+    POut.Long  (insPlan.ClaimFormNum)+","
				+    POut.Bool  (insPlan.UseAltCode)+","
				+    POut.Bool  (insPlan.ClaimsUseUCR)+","
				+    POut.Long  (insPlan.CopayFeeSched)+","
				+    POut.Long  (insPlan.EmployerNum)+","
				+    POut.Long  (insPlan.CarrierNum)+","
				+    POut.Long  (insPlan.AllowedFeeSched)+","
				+"'"+POut.String(insPlan.TrojanID)+"',"
				+"'"+POut.String(insPlan.DivisionNo)+"',"
				+    POut.Bool  (insPlan.IsMedical)+","
				+    POut.Long  (insPlan.FilingCode)+","
				+    POut.Byte  (insPlan.DentaideCardSequence)+","
				+    POut.Bool  (insPlan.ShowBaseUnits)+","
				+    POut.Bool  (insPlan.CodeSubstNone)+","
				+    POut.Bool  (insPlan.IsHidden)+","
				+    POut.Byte  (insPlan.MonthRenew)+","
				+    POut.Long  (insPlan.FilingCodeSubtype)+","
				+"'"+POut.String(insPlan.CanadianPlanFlag)+"',"
				+"'"+POut.String(insPlan.CanadianDiagnosticCode)+"',"
				+"'"+POut.String(insPlan.CanadianInstitutionCode)+"',"
				+"'"+POut.String(insPlan.RxBIN)+"',"
				+    POut.Int   ((int)insPlan.CobRule)+","
				+"'"+POut.String(insPlan.SopCode)+"',"
				+    POut.Long  (insPlan.SecUserNumEntry)+","
				+    DbHelper.Now()+","
				//SecDateTEdit can only be set by MySQL
				+    POut.Bool  (insPlan.HideFromVerifyList)+","
				+    POut.Int   ((int)insPlan.OrthoType)+","
				+    POut.Int   ((int)insPlan.OrthoAutoProcFreq)+","
				+    POut.Long  (insPlan.OrthoAutoProcCodeNumOverride)+","
				+"'"+POut.Double(insPlan.OrthoAutoFeeBilled)+"',"
				+    POut.Int   (insPlan.OrthoAutoClaimDaysWait)+","
				+    POut.Long  (insPlan.BillingType)+","
				+    POut.Bool  (insPlan.HasPpoSubstWriteoffs)+","
				+    POut.Int   ((int)insPlan.ExclusionFeeRule)+")";
			if(insPlan.PlanNote==null) {
				insPlan.PlanNote="";
			}
			OdSqlParameter paramPlanNote=new OdSqlParameter("paramPlanNote",OdDbType.Text,POut.StringParam(insPlan.PlanNote));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramPlanNote);
			}
			else {
				insPlan.PlanNum=Db.NonQ(command,true,"PlanNum","insPlan",paramPlanNote);
			}
			return insPlan.PlanNum;
		}

		///<summary>Inserts one InsPlan into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(InsPlan insPlan) {
			return InsertNoCache(insPlan,false);
		}

		///<summary>Inserts one InsPlan into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(InsPlan insPlan,bool useExistingPK) {
			
			string command="INSERT INTO insplan (";
			if(!useExistingPK) {
				insPlan.PlanNum=ReplicationServers.GetKeyNoCache("insplan","PlanNum");
			}
			if(useExistingPK) {
				command+="PlanNum,";
			}
			command+="GroupName,GroupNum,PlanNote,FeeSched,PlanType,ClaimFormNum,UseAltCode,ClaimsUseUCR,CopayFeeSched,EmployerNum,CarrierNum,AllowedFeeSched,TrojanID,DivisionNo,IsMedical,FilingCode,DentaideCardSequence,ShowBaseUnits,CodeSubstNone,IsHidden,MonthRenew,FilingCodeSubtype,CanadianPlanFlag,CanadianDiagnosticCode,CanadianInstitutionCode,RxBIN,CobRule,SopCode,SecUserNumEntry,SecDateEntry,HideFromVerifyList,OrthoType,OrthoAutoProcFreq,OrthoAutoProcCodeNumOverride,OrthoAutoFeeBilled,OrthoAutoClaimDaysWait,BillingType,HasPpoSubstWriteoffs,ExclusionFeeRule) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(insPlan.PlanNum)+",";
			}
			command+=
				 "'"+POut.String(insPlan.GroupName)+"',"
				+"'"+POut.String(insPlan.GroupNum)+"',"
				+    DbHelper.ParamChar+"paramPlanNote,"
				+    POut.Long  (insPlan.FeeSched)+","
				+"'"+POut.String(insPlan.PlanType)+"',"
				+    POut.Long  (insPlan.ClaimFormNum)+","
				+    POut.Bool  (insPlan.UseAltCode)+","
				+    POut.Bool  (insPlan.ClaimsUseUCR)+","
				+    POut.Long  (insPlan.CopayFeeSched)+","
				+    POut.Long  (insPlan.EmployerNum)+","
				+    POut.Long  (insPlan.CarrierNum)+","
				+    POut.Long  (insPlan.AllowedFeeSched)+","
				+"'"+POut.String(insPlan.TrojanID)+"',"
				+"'"+POut.String(insPlan.DivisionNo)+"',"
				+    POut.Bool  (insPlan.IsMedical)+","
				+    POut.Long  (insPlan.FilingCode)+","
				+    POut.Byte  (insPlan.DentaideCardSequence)+","
				+    POut.Bool  (insPlan.ShowBaseUnits)+","
				+    POut.Bool  (insPlan.CodeSubstNone)+","
				+    POut.Bool  (insPlan.IsHidden)+","
				+    POut.Byte  (insPlan.MonthRenew)+","
				+    POut.Long  (insPlan.FilingCodeSubtype)+","
				+"'"+POut.String(insPlan.CanadianPlanFlag)+"',"
				+"'"+POut.String(insPlan.CanadianDiagnosticCode)+"',"
				+"'"+POut.String(insPlan.CanadianInstitutionCode)+"',"
				+"'"+POut.String(insPlan.RxBIN)+"',"
				+    POut.Int   ((int)insPlan.CobRule)+","
				+"'"+POut.String(insPlan.SopCode)+"',"
				+    POut.Long  (insPlan.SecUserNumEntry)+","
				+    DbHelper.Now()+","
				//SecDateTEdit can only be set by MySQL
				+    POut.Bool  (insPlan.HideFromVerifyList)+","
				+    POut.Int   ((int)insPlan.OrthoType)+","
				+    POut.Int   ((int)insPlan.OrthoAutoProcFreq)+","
				+    POut.Long  (insPlan.OrthoAutoProcCodeNumOverride)+","
				+"'"+POut.Double(insPlan.OrthoAutoFeeBilled)+"',"
				+    POut.Int   (insPlan.OrthoAutoClaimDaysWait)+","
				+    POut.Long  (insPlan.BillingType)+","
				+    POut.Bool  (insPlan.HasPpoSubstWriteoffs)+","
				+    POut.Int   ((int)insPlan.ExclusionFeeRule)+")";
			if(insPlan.PlanNote==null) {
				insPlan.PlanNote="";
			}
			OdSqlParameter paramPlanNote=new OdSqlParameter("paramPlanNote",OdDbType.Text,POut.StringParam(insPlan.PlanNote));
			if(useExistingPK) {
				Db.NonQ(command,paramPlanNote);
			}
			else {
				insPlan.PlanNum=Db.NonQ(command,true,"PlanNum","insPlan",paramPlanNote);
			}
			return insPlan.PlanNum;
		}

		///<summary>Updates one InsPlan in the database.</summary>
		public static void Update(InsPlan insPlan) {
			string command="UPDATE insplan SET "
				+"GroupName                   = '"+POut.String(insPlan.GroupName)+"', "
				+"GroupNum                    = '"+POut.String(insPlan.GroupNum)+"', "
				+"PlanNote                    =  "+DbHelper.ParamChar+"paramPlanNote, "
				+"FeeSched                    =  "+POut.Long  (insPlan.FeeSched)+", "
				+"PlanType                    = '"+POut.String(insPlan.PlanType)+"', "
				+"ClaimFormNum                =  "+POut.Long  (insPlan.ClaimFormNum)+", "
				+"UseAltCode                  =  "+POut.Bool  (insPlan.UseAltCode)+", "
				+"ClaimsUseUCR                =  "+POut.Bool  (insPlan.ClaimsUseUCR)+", "
				+"CopayFeeSched               =  "+POut.Long  (insPlan.CopayFeeSched)+", "
				+"EmployerNum                 =  "+POut.Long  (insPlan.EmployerNum)+", "
				+"CarrierNum                  =  "+POut.Long  (insPlan.CarrierNum)+", "
				+"AllowedFeeSched             =  "+POut.Long  (insPlan.AllowedFeeSched)+", "
				+"TrojanID                    = '"+POut.String(insPlan.TrojanID)+"', "
				+"DivisionNo                  = '"+POut.String(insPlan.DivisionNo)+"', "
				+"IsMedical                   =  "+POut.Bool  (insPlan.IsMedical)+", "
				+"FilingCode                  =  "+POut.Long  (insPlan.FilingCode)+", "
				+"DentaideCardSequence        =  "+POut.Byte  (insPlan.DentaideCardSequence)+", "
				+"ShowBaseUnits               =  "+POut.Bool  (insPlan.ShowBaseUnits)+", "
				+"CodeSubstNone               =  "+POut.Bool  (insPlan.CodeSubstNone)+", "
				+"IsHidden                    =  "+POut.Bool  (insPlan.IsHidden)+", "
				+"MonthRenew                  =  "+POut.Byte  (insPlan.MonthRenew)+", "
				+"FilingCodeSubtype           =  "+POut.Long  (insPlan.FilingCodeSubtype)+", "
				+"CanadianPlanFlag            = '"+POut.String(insPlan.CanadianPlanFlag)+"', "
				+"CanadianDiagnosticCode      = '"+POut.String(insPlan.CanadianDiagnosticCode)+"', "
				+"CanadianInstitutionCode     = '"+POut.String(insPlan.CanadianInstitutionCode)+"', "
				+"RxBIN                       = '"+POut.String(insPlan.RxBIN)+"', "
				+"CobRule                     =  "+POut.Int   ((int)insPlan.CobRule)+", "
				+"SopCode                     = '"+POut.String(insPlan.SopCode)+"', "
				//SecUserNumEntry excluded from update
				//SecDateEntry not allowed to change
				//SecDateTEdit can only be set by MySQL
				+"HideFromVerifyList          =  "+POut.Bool  (insPlan.HideFromVerifyList)+", "
				+"OrthoType                   =  "+POut.Int   ((int)insPlan.OrthoType)+", "
				+"OrthoAutoProcFreq           =  "+POut.Int   ((int)insPlan.OrthoAutoProcFreq)+", "
				+"OrthoAutoProcCodeNumOverride=  "+POut.Long  (insPlan.OrthoAutoProcCodeNumOverride)+", "
				+"OrthoAutoFeeBilled          = '"+POut.Double(insPlan.OrthoAutoFeeBilled)+"', "
				+"OrthoAutoClaimDaysWait      =  "+POut.Int   (insPlan.OrthoAutoClaimDaysWait)+", "
				+"BillingType                 =  "+POut.Long  (insPlan.BillingType)+", "
				+"HasPpoSubstWriteoffs        =  "+POut.Bool  (insPlan.HasPpoSubstWriteoffs)+", "
				+"ExclusionFeeRule            =  "+POut.Int   ((int)insPlan.ExclusionFeeRule)+" "
				+"WHERE PlanNum = "+POut.Long(insPlan.PlanNum);
			if(insPlan.PlanNote==null) {
				insPlan.PlanNote="";
			}
			OdSqlParameter paramPlanNote=new OdSqlParameter("paramPlanNote",OdDbType.Text,POut.StringParam(insPlan.PlanNote));
			Db.NonQ(command,paramPlanNote);
		}

		///<summary>Updates one InsPlan in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(InsPlan insPlan,InsPlan oldInsPlan) {
			string command="";
			if(insPlan.GroupName != oldInsPlan.GroupName) {
				if(command!="") { command+=",";}
				command+="GroupName = '"+POut.String(insPlan.GroupName)+"'";
			}
			if(insPlan.GroupNum != oldInsPlan.GroupNum) {
				if(command!="") { command+=",";}
				command+="GroupNum = '"+POut.String(insPlan.GroupNum)+"'";
			}
			if(insPlan.PlanNote != oldInsPlan.PlanNote) {
				if(command!="") { command+=",";}
				command+="PlanNote = "+DbHelper.ParamChar+"paramPlanNote";
			}
			if(insPlan.FeeSched != oldInsPlan.FeeSched) {
				if(command!="") { command+=",";}
				command+="FeeSched = "+POut.Long(insPlan.FeeSched)+"";
			}
			if(insPlan.PlanType != oldInsPlan.PlanType) {
				if(command!="") { command+=",";}
				command+="PlanType = '"+POut.String(insPlan.PlanType)+"'";
			}
			if(insPlan.ClaimFormNum != oldInsPlan.ClaimFormNum) {
				if(command!="") { command+=",";}
				command+="ClaimFormNum = "+POut.Long(insPlan.ClaimFormNum)+"";
			}
			if(insPlan.UseAltCode != oldInsPlan.UseAltCode) {
				if(command!="") { command+=",";}
				command+="UseAltCode = "+POut.Bool(insPlan.UseAltCode)+"";
			}
			if(insPlan.ClaimsUseUCR != oldInsPlan.ClaimsUseUCR) {
				if(command!="") { command+=",";}
				command+="ClaimsUseUCR = "+POut.Bool(insPlan.ClaimsUseUCR)+"";
			}
			if(insPlan.CopayFeeSched != oldInsPlan.CopayFeeSched) {
				if(command!="") { command+=",";}
				command+="CopayFeeSched = "+POut.Long(insPlan.CopayFeeSched)+"";
			}
			if(insPlan.EmployerNum != oldInsPlan.EmployerNum) {
				if(command!="") { command+=",";}
				command+="EmployerNum = "+POut.Long(insPlan.EmployerNum)+"";
			}
			if(insPlan.CarrierNum != oldInsPlan.CarrierNum) {
				if(command!="") { command+=",";}
				command+="CarrierNum = "+POut.Long(insPlan.CarrierNum)+"";
			}
			if(insPlan.AllowedFeeSched != oldInsPlan.AllowedFeeSched) {
				if(command!="") { command+=",";}
				command+="AllowedFeeSched = "+POut.Long(insPlan.AllowedFeeSched)+"";
			}
			if(insPlan.TrojanID != oldInsPlan.TrojanID) {
				if(command!="") { command+=",";}
				command+="TrojanID = '"+POut.String(insPlan.TrojanID)+"'";
			}
			if(insPlan.DivisionNo != oldInsPlan.DivisionNo) {
				if(command!="") { command+=",";}
				command+="DivisionNo = '"+POut.String(insPlan.DivisionNo)+"'";
			}
			if(insPlan.IsMedical != oldInsPlan.IsMedical) {
				if(command!="") { command+=",";}
				command+="IsMedical = "+POut.Bool(insPlan.IsMedical)+"";
			}
			if(insPlan.FilingCode != oldInsPlan.FilingCode) {
				if(command!="") { command+=",";}
				command+="FilingCode = "+POut.Long(insPlan.FilingCode)+"";
			}
			if(insPlan.DentaideCardSequence != oldInsPlan.DentaideCardSequence) {
				if(command!="") { command+=",";}
				command+="DentaideCardSequence = "+POut.Byte(insPlan.DentaideCardSequence)+"";
			}
			if(insPlan.ShowBaseUnits != oldInsPlan.ShowBaseUnits) {
				if(command!="") { command+=",";}
				command+="ShowBaseUnits = "+POut.Bool(insPlan.ShowBaseUnits)+"";
			}
			if(insPlan.CodeSubstNone != oldInsPlan.CodeSubstNone) {
				if(command!="") { command+=",";}
				command+="CodeSubstNone = "+POut.Bool(insPlan.CodeSubstNone)+"";
			}
			if(insPlan.IsHidden != oldInsPlan.IsHidden) {
				if(command!="") { command+=",";}
				command+="IsHidden = "+POut.Bool(insPlan.IsHidden)+"";
			}
			if(insPlan.MonthRenew != oldInsPlan.MonthRenew) {
				if(command!="") { command+=",";}
				command+="MonthRenew = "+POut.Byte(insPlan.MonthRenew)+"";
			}
			if(insPlan.FilingCodeSubtype != oldInsPlan.FilingCodeSubtype) {
				if(command!="") { command+=",";}
				command+="FilingCodeSubtype = "+POut.Long(insPlan.FilingCodeSubtype)+"";
			}
			if(insPlan.CanadianPlanFlag != oldInsPlan.CanadianPlanFlag) {
				if(command!="") { command+=",";}
				command+="CanadianPlanFlag = '"+POut.String(insPlan.CanadianPlanFlag)+"'";
			}
			if(insPlan.CanadianDiagnosticCode != oldInsPlan.CanadianDiagnosticCode) {
				if(command!="") { command+=",";}
				command+="CanadianDiagnosticCode = '"+POut.String(insPlan.CanadianDiagnosticCode)+"'";
			}
			if(insPlan.CanadianInstitutionCode != oldInsPlan.CanadianInstitutionCode) {
				if(command!="") { command+=",";}
				command+="CanadianInstitutionCode = '"+POut.String(insPlan.CanadianInstitutionCode)+"'";
			}
			if(insPlan.RxBIN != oldInsPlan.RxBIN) {
				if(command!="") { command+=",";}
				command+="RxBIN = '"+POut.String(insPlan.RxBIN)+"'";
			}
			if(insPlan.CobRule != oldInsPlan.CobRule) {
				if(command!="") { command+=",";}
				command+="CobRule = "+POut.Int   ((int)insPlan.CobRule)+"";
			}
			if(insPlan.SopCode != oldInsPlan.SopCode) {
				if(command!="") { command+=",";}
				command+="SopCode = '"+POut.String(insPlan.SopCode)+"'";
			}
			//SecUserNumEntry excluded from update
			//SecDateEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			if(insPlan.HideFromVerifyList != oldInsPlan.HideFromVerifyList) {
				if(command!="") { command+=",";}
				command+="HideFromVerifyList = "+POut.Bool(insPlan.HideFromVerifyList)+"";
			}
			if(insPlan.OrthoType != oldInsPlan.OrthoType) {
				if(command!="") { command+=",";}
				command+="OrthoType = "+POut.Int   ((int)insPlan.OrthoType)+"";
			}
			if(insPlan.OrthoAutoProcFreq != oldInsPlan.OrthoAutoProcFreq) {
				if(command!="") { command+=",";}
				command+="OrthoAutoProcFreq = "+POut.Int   ((int)insPlan.OrthoAutoProcFreq)+"";
			}
			if(insPlan.OrthoAutoProcCodeNumOverride != oldInsPlan.OrthoAutoProcCodeNumOverride) {
				if(command!="") { command+=",";}
				command+="OrthoAutoProcCodeNumOverride = "+POut.Long(insPlan.OrthoAutoProcCodeNumOverride)+"";
			}
			if(insPlan.OrthoAutoFeeBilled != oldInsPlan.OrthoAutoFeeBilled) {
				if(command!="") { command+=",";}
				command+="OrthoAutoFeeBilled = '"+POut.Double(insPlan.OrthoAutoFeeBilled)+"'";
			}
			if(insPlan.OrthoAutoClaimDaysWait != oldInsPlan.OrthoAutoClaimDaysWait) {
				if(command!="") { command+=",";}
				command+="OrthoAutoClaimDaysWait = "+POut.Int(insPlan.OrthoAutoClaimDaysWait)+"";
			}
			if(insPlan.BillingType != oldInsPlan.BillingType) {
				if(command!="") { command+=",";}
				command+="BillingType = "+POut.Long(insPlan.BillingType)+"";
			}
			if(insPlan.HasPpoSubstWriteoffs != oldInsPlan.HasPpoSubstWriteoffs) {
				if(command!="") { command+=",";}
				command+="HasPpoSubstWriteoffs = "+POut.Bool(insPlan.HasPpoSubstWriteoffs)+"";
			}
			if(insPlan.ExclusionFeeRule != oldInsPlan.ExclusionFeeRule) {
				if(command!="") { command+=",";}
				command+="ExclusionFeeRule = "+POut.Int   ((int)insPlan.ExclusionFeeRule)+"";
			}
			if(command=="") {
				return false;
			}
			if(insPlan.PlanNote==null) {
				insPlan.PlanNote="";
			}
			OdSqlParameter paramPlanNote=new OdSqlParameter("paramPlanNote",OdDbType.Text,POut.StringParam(insPlan.PlanNote));
			command="UPDATE insplan SET "+command
				+" WHERE PlanNum = "+POut.Long(insPlan.PlanNum);
			Db.NonQ(command,paramPlanNote);
			return true;
		}

		///<summary>Returns true if Update(InsPlan,InsPlan) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(InsPlan insPlan,InsPlan oldInsPlan) {
			if(insPlan.GroupName != oldInsPlan.GroupName) {
				return true;
			}
			if(insPlan.GroupNum != oldInsPlan.GroupNum) {
				return true;
			}
			if(insPlan.PlanNote != oldInsPlan.PlanNote) {
				return true;
			}
			if(insPlan.FeeSched != oldInsPlan.FeeSched) {
				return true;
			}
			if(insPlan.PlanType != oldInsPlan.PlanType) {
				return true;
			}
			if(insPlan.ClaimFormNum != oldInsPlan.ClaimFormNum) {
				return true;
			}
			if(insPlan.UseAltCode != oldInsPlan.UseAltCode) {
				return true;
			}
			if(insPlan.ClaimsUseUCR != oldInsPlan.ClaimsUseUCR) {
				return true;
			}
			if(insPlan.CopayFeeSched != oldInsPlan.CopayFeeSched) {
				return true;
			}
			if(insPlan.EmployerNum != oldInsPlan.EmployerNum) {
				return true;
			}
			if(insPlan.CarrierNum != oldInsPlan.CarrierNum) {
				return true;
			}
			if(insPlan.AllowedFeeSched != oldInsPlan.AllowedFeeSched) {
				return true;
			}
			if(insPlan.TrojanID != oldInsPlan.TrojanID) {
				return true;
			}
			if(insPlan.DivisionNo != oldInsPlan.DivisionNo) {
				return true;
			}
			if(insPlan.IsMedical != oldInsPlan.IsMedical) {
				return true;
			}
			if(insPlan.FilingCode != oldInsPlan.FilingCode) {
				return true;
			}
			if(insPlan.DentaideCardSequence != oldInsPlan.DentaideCardSequence) {
				return true;
			}
			if(insPlan.ShowBaseUnits != oldInsPlan.ShowBaseUnits) {
				return true;
			}
			if(insPlan.CodeSubstNone != oldInsPlan.CodeSubstNone) {
				return true;
			}
			if(insPlan.IsHidden != oldInsPlan.IsHidden) {
				return true;
			}
			if(insPlan.MonthRenew != oldInsPlan.MonthRenew) {
				return true;
			}
			if(insPlan.FilingCodeSubtype != oldInsPlan.FilingCodeSubtype) {
				return true;
			}
			if(insPlan.CanadianPlanFlag != oldInsPlan.CanadianPlanFlag) {
				return true;
			}
			if(insPlan.CanadianDiagnosticCode != oldInsPlan.CanadianDiagnosticCode) {
				return true;
			}
			if(insPlan.CanadianInstitutionCode != oldInsPlan.CanadianInstitutionCode) {
				return true;
			}
			if(insPlan.RxBIN != oldInsPlan.RxBIN) {
				return true;
			}
			if(insPlan.CobRule != oldInsPlan.CobRule) {
				return true;
			}
			if(insPlan.SopCode != oldInsPlan.SopCode) {
				return true;
			}
			//SecUserNumEntry excluded from update
			//SecDateEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			if(insPlan.HideFromVerifyList != oldInsPlan.HideFromVerifyList) {
				return true;
			}
			if(insPlan.OrthoType != oldInsPlan.OrthoType) {
				return true;
			}
			if(insPlan.OrthoAutoProcFreq != oldInsPlan.OrthoAutoProcFreq) {
				return true;
			}
			if(insPlan.OrthoAutoProcCodeNumOverride != oldInsPlan.OrthoAutoProcCodeNumOverride) {
				return true;
			}
			if(insPlan.OrthoAutoFeeBilled != oldInsPlan.OrthoAutoFeeBilled) {
				return true;
			}
			if(insPlan.OrthoAutoClaimDaysWait != oldInsPlan.OrthoAutoClaimDaysWait) {
				return true;
			}
			if(insPlan.BillingType != oldInsPlan.BillingType) {
				return true;
			}
			if(insPlan.HasPpoSubstWriteoffs != oldInsPlan.HasPpoSubstWriteoffs) {
				return true;
			}
			if(insPlan.ExclusionFeeRule != oldInsPlan.ExclusionFeeRule) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one InsPlan from the database.</summary>
		public static void Delete(long planNum) {
			ClearFkey(planNum);
			string command="DELETE FROM insplan "
				+"WHERE PlanNum = "+POut.Long(planNum);
			Db.NonQ(command);
		}

		///<summary>Zeros securitylog FKey column for rows that are using the matching planNum as FKey and are related to InsPlan.
		///Permtypes are generated from the AuditPerms property of the CrudTableAttribute within the InsPlan table type.</summary>
		public static void ClearFkey(long planNum) {
			if(planNum==0) {
				return;
			}
			string command="UPDATE securitylog SET FKey=0 WHERE FKey="+POut.Long(planNum)+" AND PermType IN (65)";
			Db.NonQ(command);
		}

		///<summary>Zeros securitylog FKey column for rows that are using the matching planNums as FKey and are related to InsPlan.
		///Permtypes are generated from the AuditPerms property of the CrudTableAttribute within the InsPlan table type.</summary>
		public static void ClearFkey(List<long> listPlanNums) {
			if(listPlanNums==null || listPlanNums.FindAll(x => x != 0).Count==0) {
				return;
			}
			string command="UPDATE securitylog SET FKey=0 WHERE FKey IN("+String.Join(",",listPlanNums.FindAll(x => x != 0))+") AND PermType IN (65)";
			Db.NonQ(command);
		}

	}
}