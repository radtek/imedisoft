//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ClaimProcCrud {
		///<summary>Gets one ClaimProc object from the database using the primary key.  Returns null if not found.</summary>
		public static ClaimProc SelectOne(long claimProcNum) {
			string command="SELECT * FROM claimproc "
				+"WHERE ClaimProcNum = "+POut.Long(claimProcNum);
			List<ClaimProc> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ClaimProc object from the database using a query.</summary>
		public static ClaimProc SelectOne(string command) {
			List<ClaimProc> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ClaimProc objects from the database using a query.</summary>
		public static List<ClaimProc> SelectMany(string command) {
			List<ClaimProc> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ClaimProc> TableToList(DataTable table) {
			List<ClaimProc> retVal=new List<ClaimProc>();
			ClaimProc claimProc;
			foreach(DataRow row in table.Rows) {
				claimProc=new ClaimProc();
				claimProc.ClaimProcNum        = PIn.Long  (row["ClaimProcNum"].ToString());
				claimProc.ProcNum             = PIn.Long  (row["ProcNum"].ToString());
				claimProc.ClaimNum            = PIn.Long  (row["ClaimNum"].ToString());
				claimProc.PatNum              = PIn.Long  (row["PatNum"].ToString());
				claimProc.ProvNum             = PIn.Long  (row["ProvNum"].ToString());
				claimProc.FeeBilled           = PIn.Double(row["FeeBilled"].ToString());
				claimProc.InsPayEst           = PIn.Double(row["InsPayEst"].ToString());
				claimProc.DedApplied          = PIn.Double(row["DedApplied"].ToString());
				claimProc.Status              = (OpenDentBusiness.ClaimProcStatus)PIn.Int(row["Status"].ToString());
				claimProc.InsPayAmt           = PIn.Double(row["InsPayAmt"].ToString());
				claimProc.Remarks             = PIn.String(row["Remarks"].ToString());
				claimProc.ClaimPaymentNum     = PIn.Long  (row["ClaimPaymentNum"].ToString());
				claimProc.PlanNum             = PIn.Long  (row["PlanNum"].ToString());
				claimProc.DateCP              = PIn.Date  (row["DateCP"].ToString());
				claimProc.WriteOff            = PIn.Double(row["WriteOff"].ToString());
				claimProc.CodeSent            = PIn.String(row["CodeSent"].ToString());
				claimProc.AllowedOverride     = PIn.Double(row["AllowedOverride"].ToString());
				claimProc.Percentage          = PIn.Int   (row["Percentage"].ToString());
				claimProc.PercentOverride     = PIn.Int   (row["PercentOverride"].ToString());
				claimProc.CopayAmt            = PIn.Double(row["CopayAmt"].ToString());
				claimProc.NoBillIns           = PIn.Bool  (row["NoBillIns"].ToString());
				claimProc.PaidOtherIns        = PIn.Double(row["PaidOtherIns"].ToString());
				claimProc.BaseEst             = PIn.Double(row["BaseEst"].ToString());
				claimProc.CopayOverride       = PIn.Double(row["CopayOverride"].ToString());
				claimProc.ProcDate            = PIn.Date  (row["ProcDate"].ToString());
				claimProc.DateEntry           = PIn.Date  (row["DateEntry"].ToString());
				claimProc.LineNumber          = PIn.Byte  (row["LineNumber"].ToString());
				claimProc.DedEst              = PIn.Double(row["DedEst"].ToString());
				claimProc.DedEstOverride      = PIn.Double(row["DedEstOverride"].ToString());
				claimProc.InsEstTotal         = PIn.Double(row["InsEstTotal"].ToString());
				claimProc.InsEstTotalOverride = PIn.Double(row["InsEstTotalOverride"].ToString());
				claimProc.PaidOtherInsOverride= PIn.Double(row["PaidOtherInsOverride"].ToString());
				claimProc.EstimateNote        = PIn.String(row["EstimateNote"].ToString());
				claimProc.WriteOffEst         = PIn.Double(row["WriteOffEst"].ToString());
				claimProc.WriteOffEstOverride = PIn.Double(row["WriteOffEstOverride"].ToString());
				claimProc.ClinicNum           = PIn.Long  (row["ClinicNum"].ToString());
				claimProc.InsSubNum           = PIn.Long  (row["InsSubNum"].ToString());
				claimProc.PaymentRow          = PIn.Int   (row["PaymentRow"].ToString());
				claimProc.PayPlanNum          = PIn.Long  (row["PayPlanNum"].ToString());
				claimProc.ClaimPaymentTracking= PIn.Long  (row["ClaimPaymentTracking"].ToString());
				claimProc.SecUserNumEntry     = PIn.Long  (row["SecUserNumEntry"].ToString());
				claimProc.SecDateEntry        = PIn.Date  (row["SecDateEntry"].ToString());
				claimProc.SecDateTEdit        = PIn.Date (row["SecDateTEdit"].ToString());
				claimProc.DateSuppReceived    = PIn.Date  (row["DateSuppReceived"].ToString());
				claimProc.DateInsFinalized    = PIn.Date  (row["DateInsFinalized"].ToString());
				claimProc.IsTransfer          = PIn.Bool  (row["IsTransfer"].ToString());
				retVal.Add(claimProc);
			}
			return retVal;
		}

		///<summary>Converts an IDataRecord to a ClaimProc object.</summary>
		public static ClaimProc RowToObj(IDataRecord row) {
			return new ClaimProc {
				ClaimProcNum        = PIn.Long  (row["ClaimProcNum"].ToString()),
				ProcNum             = PIn.Long  (row["ProcNum"].ToString()),
				ClaimNum            = PIn.Long  (row["ClaimNum"].ToString()),
				PatNum              = PIn.Long  (row["PatNum"].ToString()),
				ProvNum             = PIn.Long  (row["ProvNum"].ToString()),
				FeeBilled           = PIn.Double(row["FeeBilled"].ToString()),
				InsPayEst           = PIn.Double(row["InsPayEst"].ToString()),
				DedApplied          = PIn.Double(row["DedApplied"].ToString()),
				Status              = (OpenDentBusiness.ClaimProcStatus)PIn.Int(row["Status"].ToString()),
				InsPayAmt           = PIn.Double(row["InsPayAmt"].ToString()),
				Remarks             = PIn.String(row["Remarks"].ToString()),
				ClaimPaymentNum     = PIn.Long  (row["ClaimPaymentNum"].ToString()),
				PlanNum             = PIn.Long  (row["PlanNum"].ToString()),
				DateCP              = PIn.Date  (row["DateCP"].ToString()),
				WriteOff            = PIn.Double(row["WriteOff"].ToString()),
				CodeSent            = PIn.String(row["CodeSent"].ToString()),
				AllowedOverride     = PIn.Double(row["AllowedOverride"].ToString()),
				Percentage          = PIn.Int   (row["Percentage"].ToString()),
				PercentOverride     = PIn.Int   (row["PercentOverride"].ToString()),
				CopayAmt            = PIn.Double(row["CopayAmt"].ToString()),
				NoBillIns           = PIn.Bool  (row["NoBillIns"].ToString()),
				PaidOtherIns        = PIn.Double(row["PaidOtherIns"].ToString()),
				BaseEst             = PIn.Double(row["BaseEst"].ToString()),
				CopayOverride       = PIn.Double(row["CopayOverride"].ToString()),
				ProcDate            = PIn.Date  (row["ProcDate"].ToString()),
				DateEntry           = PIn.Date  (row["DateEntry"].ToString()),
				LineNumber          = PIn.Byte  (row["LineNumber"].ToString()),
				DedEst              = PIn.Double(row["DedEst"].ToString()),
				DedEstOverride      = PIn.Double(row["DedEstOverride"].ToString()),
				InsEstTotal         = PIn.Double(row["InsEstTotal"].ToString()),
				InsEstTotalOverride = PIn.Double(row["InsEstTotalOverride"].ToString()),
				PaidOtherInsOverride= PIn.Double(row["PaidOtherInsOverride"].ToString()),
				EstimateNote        = PIn.String(row["EstimateNote"].ToString()),
				WriteOffEst         = PIn.Double(row["WriteOffEst"].ToString()),
				WriteOffEstOverride = PIn.Double(row["WriteOffEstOverride"].ToString()),
				ClinicNum           = PIn.Long  (row["ClinicNum"].ToString()),
				InsSubNum           = PIn.Long  (row["InsSubNum"].ToString()),
				PaymentRow          = PIn.Int   (row["PaymentRow"].ToString()),
				PayPlanNum          = PIn.Long  (row["PayPlanNum"].ToString()),
				ClaimPaymentTracking= PIn.Long  (row["ClaimPaymentTracking"].ToString()),
				SecUserNumEntry     = PIn.Long  (row["SecUserNumEntry"].ToString()),
				SecDateEntry        = PIn.Date  (row["SecDateEntry"].ToString()),
				SecDateTEdit        = PIn.Date (row["SecDateTEdit"].ToString()),
				DateSuppReceived    = PIn.Date  (row["DateSuppReceived"].ToString()),
				DateInsFinalized    = PIn.Date  (row["DateInsFinalized"].ToString()),
				IsTransfer          = PIn.Bool  (row["IsTransfer"].ToString()),
			};
		}

		///<summary>Converts a list of ClaimProc into a DataTable.</summary>
		public static DataTable ListToTable(List<ClaimProc> listClaimProcs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ClaimProc";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ClaimProcNum");
			table.Columns.Add("ProcNum");
			table.Columns.Add("ClaimNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("ProvNum");
			table.Columns.Add("FeeBilled");
			table.Columns.Add("InsPayEst");
			table.Columns.Add("DedApplied");
			table.Columns.Add("Status");
			table.Columns.Add("InsPayAmt");
			table.Columns.Add("Remarks");
			table.Columns.Add("ClaimPaymentNum");
			table.Columns.Add("PlanNum");
			table.Columns.Add("DateCP");
			table.Columns.Add("WriteOff");
			table.Columns.Add("CodeSent");
			table.Columns.Add("AllowedOverride");
			table.Columns.Add("Percentage");
			table.Columns.Add("PercentOverride");
			table.Columns.Add("CopayAmt");
			table.Columns.Add("NoBillIns");
			table.Columns.Add("PaidOtherIns");
			table.Columns.Add("BaseEst");
			table.Columns.Add("CopayOverride");
			table.Columns.Add("ProcDate");
			table.Columns.Add("DateEntry");
			table.Columns.Add("LineNumber");
			table.Columns.Add("DedEst");
			table.Columns.Add("DedEstOverride");
			table.Columns.Add("InsEstTotal");
			table.Columns.Add("InsEstTotalOverride");
			table.Columns.Add("PaidOtherInsOverride");
			table.Columns.Add("EstimateNote");
			table.Columns.Add("WriteOffEst");
			table.Columns.Add("WriteOffEstOverride");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("InsSubNum");
			table.Columns.Add("PaymentRow");
			table.Columns.Add("PayPlanNum");
			table.Columns.Add("ClaimPaymentTracking");
			table.Columns.Add("SecUserNumEntry");
			table.Columns.Add("SecDateEntry");
			table.Columns.Add("SecDateTEdit");
			table.Columns.Add("DateSuppReceived");
			table.Columns.Add("DateInsFinalized");
			table.Columns.Add("IsTransfer");
			foreach(ClaimProc claimProc in listClaimProcs) {
				table.Rows.Add(new object[] {
					POut.Long  (claimProc.ClaimProcNum),
					POut.Long  (claimProc.ProcNum),
					POut.Long  (claimProc.ClaimNum),
					POut.Long  (claimProc.PatNum),
					POut.Long  (claimProc.ProvNum),
					POut.Double(claimProc.FeeBilled),
					POut.Double(claimProc.InsPayEst),
					POut.Double(claimProc.DedApplied),
					POut.Int   ((int)claimProc.Status),
					POut.Double(claimProc.InsPayAmt),
					            claimProc.Remarks,
					POut.Long  (claimProc.ClaimPaymentNum),
					POut.Long  (claimProc.PlanNum),
					POut.DateT (claimProc.DateCP,false),
					POut.Double(claimProc.WriteOff),
					            claimProc.CodeSent,
					POut.Double(claimProc.AllowedOverride),
					POut.Int   (claimProc.Percentage),
					POut.Int   (claimProc.PercentOverride),
					POut.Double(claimProc.CopayAmt),
					POut.Bool  (claimProc.NoBillIns),
					POut.Double(claimProc.PaidOtherIns),
					POut.Double(claimProc.BaseEst),
					POut.Double(claimProc.CopayOverride),
					POut.DateT (claimProc.ProcDate,false),
					POut.DateT (claimProc.DateEntry,false),
					POut.Byte  (claimProc.LineNumber),
					POut.Double(claimProc.DedEst),
					POut.Double(claimProc.DedEstOverride),
					POut.Double(claimProc.InsEstTotal),
					POut.Double(claimProc.InsEstTotalOverride),
					POut.Double(claimProc.PaidOtherInsOverride),
					            claimProc.EstimateNote,
					POut.Double(claimProc.WriteOffEst),
					POut.Double(claimProc.WriteOffEstOverride),
					POut.Long  (claimProc.ClinicNum),
					POut.Long  (claimProc.InsSubNum),
					POut.Int   (claimProc.PaymentRow),
					POut.Long  (claimProc.PayPlanNum),
					POut.Long  (claimProc.ClaimPaymentTracking),
					POut.Long  (claimProc.SecUserNumEntry),
					POut.DateT (claimProc.SecDateEntry,false),
					POut.DateT (claimProc.SecDateTEdit,false),
					POut.DateT (claimProc.DateSuppReceived,false),
					POut.DateT (claimProc.DateInsFinalized,false),
					POut.Bool  (claimProc.IsTransfer),
				});
			}
			return table;
		}

		///<summary>Inserts one ClaimProc into the database.  Returns the new priKey.</summary>
		public static long Insert(ClaimProc claimProc) {
			return Insert(claimProc,false);
		}

		///<summary>Inserts one ClaimProc into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ClaimProc claimProc,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				claimProc.ClaimProcNum=ReplicationServers.GetKey("claimproc","ClaimProcNum");
			}
			string command="INSERT INTO claimproc (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ClaimProcNum,";
			}
			command+="ProcNum,ClaimNum,PatNum,ProvNum,FeeBilled,InsPayEst,DedApplied,Status,InsPayAmt,Remarks,ClaimPaymentNum,PlanNum,DateCP,WriteOff,CodeSent,AllowedOverride,Percentage,PercentOverride,CopayAmt,NoBillIns,PaidOtherIns,BaseEst,CopayOverride,ProcDate,DateEntry,LineNumber,DedEst,DedEstOverride,InsEstTotal,InsEstTotalOverride,PaidOtherInsOverride,EstimateNote,WriteOffEst,WriteOffEstOverride,ClinicNum,InsSubNum,PaymentRow,PayPlanNum,ClaimPaymentTracking,SecUserNumEntry,SecDateEntry,DateSuppReceived,DateInsFinalized,IsTransfer) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(claimProc.ClaimProcNum)+",";
			}
			command+=
				     POut.Long  (claimProc.ProcNum)+","
				+    POut.Long  (claimProc.ClaimNum)+","
				+    POut.Long  (claimProc.PatNum)+","
				+    POut.Long  (claimProc.ProvNum)+","
				+"'"+POut.Double(claimProc.FeeBilled)+"',"
				+"'"+POut.Double(claimProc.InsPayEst)+"',"
				+"'"+POut.Double(claimProc.DedApplied)+"',"
				+    POut.Int   ((int)claimProc.Status)+","
				+"'"+POut.Double(claimProc.InsPayAmt)+"',"
				+"'"+POut.String(claimProc.Remarks)+"',"
				+    POut.Long  (claimProc.ClaimPaymentNum)+","
				+    POut.Long  (claimProc.PlanNum)+","
				+    POut.Date  (claimProc.DateCP)+","
				+"'"+POut.Double(claimProc.WriteOff)+"',"
				+"'"+POut.String(claimProc.CodeSent)+"',"
				+"'"+POut.Double(claimProc.AllowedOverride)+"',"
				+    POut.Int   (claimProc.Percentage)+","
				+    POut.Int   (claimProc.PercentOverride)+","
				+"'"+POut.Double(claimProc.CopayAmt)+"',"
				+    POut.Bool  (claimProc.NoBillIns)+","
				+"'"+POut.Double(claimProc.PaidOtherIns)+"',"
				+"'"+POut.Double(claimProc.BaseEst)+"',"
				+"'"+POut.Double(claimProc.CopayOverride)+"',"
				+    POut.Date  (claimProc.ProcDate)+","
				+    POut.Date  (claimProc.DateEntry)+","
				+    POut.Byte  (claimProc.LineNumber)+","
				+"'"+POut.Double(claimProc.DedEst)+"',"
				+"'"+POut.Double(claimProc.DedEstOverride)+"',"
				+"'"+POut.Double(claimProc.InsEstTotal)+"',"
				+"'"+POut.Double(claimProc.InsEstTotalOverride)+"',"
				+"'"+POut.Double(claimProc.PaidOtherInsOverride)+"',"
				+"'"+POut.String(claimProc.EstimateNote)+"',"
				+"'"+POut.Double(claimProc.WriteOffEst)+"',"
				+"'"+POut.Double(claimProc.WriteOffEstOverride)+"',"
				+    POut.Long  (claimProc.ClinicNum)+","
				+    POut.Long  (claimProc.InsSubNum)+","
				+    POut.Int   (claimProc.PaymentRow)+","
				+    POut.Long  (claimProc.PayPlanNum)+","
				+    POut.Long  (claimProc.ClaimPaymentTracking)+","
				+    POut.Long  (claimProc.SecUserNumEntry)+","
				+    DbHelper.Now()+","
				//SecDateTEdit can only be set by MySQL
				+    POut.Date  (claimProc.DateSuppReceived)+","
				+    POut.Date  (claimProc.DateInsFinalized)+","
				+    POut.Bool  (claimProc.IsTransfer)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				claimProc.ClaimProcNum=Database.ExecuteInsert(command);
			}
			return claimProc.ClaimProcNum;
		}

		///<summary>Inserts one ClaimProc into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ClaimProc claimProc) {
			return InsertNoCache(claimProc,false);
		}

		///<summary>Inserts one ClaimProc into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ClaimProc claimProc,bool useExistingPK) {
			
			string command="INSERT INTO claimproc (";
			if(!useExistingPK) {
				claimProc.ClaimProcNum=ReplicationServers.GetKeyNoCache("claimproc","ClaimProcNum");
			}
			if(useExistingPK) {
				command+="ClaimProcNum,";
			}
			command+="ProcNum,ClaimNum,PatNum,ProvNum,FeeBilled,InsPayEst,DedApplied,Status,InsPayAmt,Remarks,ClaimPaymentNum,PlanNum,DateCP,WriteOff,CodeSent,AllowedOverride,Percentage,PercentOverride,CopayAmt,NoBillIns,PaidOtherIns,BaseEst,CopayOverride,ProcDate,DateEntry,LineNumber,DedEst,DedEstOverride,InsEstTotal,InsEstTotalOverride,PaidOtherInsOverride,EstimateNote,WriteOffEst,WriteOffEstOverride,ClinicNum,InsSubNum,PaymentRow,PayPlanNum,ClaimPaymentTracking,SecUserNumEntry,SecDateEntry,DateSuppReceived,DateInsFinalized,IsTransfer) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(claimProc.ClaimProcNum)+",";
			}
			command+=
				     POut.Long  (claimProc.ProcNum)+","
				+    POut.Long  (claimProc.ClaimNum)+","
				+    POut.Long  (claimProc.PatNum)+","
				+    POut.Long  (claimProc.ProvNum)+","
				+"'"+POut.Double(claimProc.FeeBilled)+"',"
				+"'"+POut.Double(claimProc.InsPayEst)+"',"
				+"'"+POut.Double(claimProc.DedApplied)+"',"
				+    POut.Int   ((int)claimProc.Status)+","
				+"'"+POut.Double(claimProc.InsPayAmt)+"',"
				+"'"+POut.String(claimProc.Remarks)+"',"
				+    POut.Long  (claimProc.ClaimPaymentNum)+","
				+    POut.Long  (claimProc.PlanNum)+","
				+    POut.Date  (claimProc.DateCP)+","
				+"'"+POut.Double(claimProc.WriteOff)+"',"
				+"'"+POut.String(claimProc.CodeSent)+"',"
				+"'"+POut.Double(claimProc.AllowedOverride)+"',"
				+    POut.Int   (claimProc.Percentage)+","
				+    POut.Int   (claimProc.PercentOverride)+","
				+"'"+POut.Double(claimProc.CopayAmt)+"',"
				+    POut.Bool  (claimProc.NoBillIns)+","
				+"'"+POut.Double(claimProc.PaidOtherIns)+"',"
				+"'"+POut.Double(claimProc.BaseEst)+"',"
				+"'"+POut.Double(claimProc.CopayOverride)+"',"
				+    POut.Date  (claimProc.ProcDate)+","
				+    POut.Date  (claimProc.DateEntry)+","
				+    POut.Byte  (claimProc.LineNumber)+","
				+"'"+POut.Double(claimProc.DedEst)+"',"
				+"'"+POut.Double(claimProc.DedEstOverride)+"',"
				+"'"+POut.Double(claimProc.InsEstTotal)+"',"
				+"'"+POut.Double(claimProc.InsEstTotalOverride)+"',"
				+"'"+POut.Double(claimProc.PaidOtherInsOverride)+"',"
				+"'"+POut.String(claimProc.EstimateNote)+"',"
				+"'"+POut.Double(claimProc.WriteOffEst)+"',"
				+"'"+POut.Double(claimProc.WriteOffEstOverride)+"',"
				+    POut.Long  (claimProc.ClinicNum)+","
				+    POut.Long  (claimProc.InsSubNum)+","
				+    POut.Int   (claimProc.PaymentRow)+","
				+    POut.Long  (claimProc.PayPlanNum)+","
				+    POut.Long  (claimProc.ClaimPaymentTracking)+","
				+    POut.Long  (claimProc.SecUserNumEntry)+","
				+    DbHelper.Now()+","
				//SecDateTEdit can only be set by MySQL
				+    POut.Date  (claimProc.DateSuppReceived)+","
				+    POut.Date  (claimProc.DateInsFinalized)+","
				+    POut.Bool  (claimProc.IsTransfer)+")";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				claimProc.ClaimProcNum=Database.ExecuteInsert(command);
			}
			return claimProc.ClaimProcNum;
		}

		///<summary>Updates one ClaimProc in the database.</summary>
		public static void Update(ClaimProc claimProc) {
			string command="UPDATE claimproc SET "
				+"ProcNum             =  "+POut.Long  (claimProc.ProcNum)+", "
				+"ClaimNum            =  "+POut.Long  (claimProc.ClaimNum)+", "
				+"PatNum              =  "+POut.Long  (claimProc.PatNum)+", "
				+"ProvNum             =  "+POut.Long  (claimProc.ProvNum)+", "
				+"FeeBilled           = '"+POut.Double(claimProc.FeeBilled)+"', "
				+"InsPayEst           = '"+POut.Double(claimProc.InsPayEst)+"', "
				+"DedApplied          = '"+POut.Double(claimProc.DedApplied)+"', "
				+"Status              =  "+POut.Int   ((int)claimProc.Status)+", "
				+"InsPayAmt           = '"+POut.Double(claimProc.InsPayAmt)+"', "
				+"Remarks             = '"+POut.String(claimProc.Remarks)+"', "
				+"ClaimPaymentNum     =  "+POut.Long  (claimProc.ClaimPaymentNum)+", "
				+"PlanNum             =  "+POut.Long  (claimProc.PlanNum)+", "
				+"DateCP              =  "+POut.Date  (claimProc.DateCP)+", "
				+"WriteOff            = '"+POut.Double(claimProc.WriteOff)+"', "
				+"CodeSent            = '"+POut.String(claimProc.CodeSent)+"', "
				+"AllowedOverride     = '"+POut.Double(claimProc.AllowedOverride)+"', "
				+"Percentage          =  "+POut.Int   (claimProc.Percentage)+", "
				+"PercentOverride     =  "+POut.Int   (claimProc.PercentOverride)+", "
				+"CopayAmt            = '"+POut.Double(claimProc.CopayAmt)+"', "
				+"NoBillIns           =  "+POut.Bool  (claimProc.NoBillIns)+", "
				+"PaidOtherIns        = '"+POut.Double(claimProc.PaidOtherIns)+"', "
				+"BaseEst             = '"+POut.Double(claimProc.BaseEst)+"', "
				+"CopayOverride       = '"+POut.Double(claimProc.CopayOverride)+"', "
				+"ProcDate            =  "+POut.Date  (claimProc.ProcDate)+", "
				+"DateEntry           =  "+POut.Date  (claimProc.DateEntry)+", "
				+"LineNumber          =  "+POut.Byte  (claimProc.LineNumber)+", "
				+"DedEst              = '"+POut.Double(claimProc.DedEst)+"', "
				+"DedEstOverride      = '"+POut.Double(claimProc.DedEstOverride)+"', "
				+"InsEstTotal         = '"+POut.Double(claimProc.InsEstTotal)+"', "
				+"InsEstTotalOverride = '"+POut.Double(claimProc.InsEstTotalOverride)+"', "
				+"PaidOtherInsOverride= '"+POut.Double(claimProc.PaidOtherInsOverride)+"', "
				+"EstimateNote        = '"+POut.String(claimProc.EstimateNote)+"', "
				+"WriteOffEst         = '"+POut.Double(claimProc.WriteOffEst)+"', "
				+"WriteOffEstOverride = '"+POut.Double(claimProc.WriteOffEstOverride)+"', "
				+"ClinicNum           =  "+POut.Long  (claimProc.ClinicNum)+", "
				+"InsSubNum           =  "+POut.Long  (claimProc.InsSubNum)+", "
				+"PaymentRow          =  "+POut.Int   (claimProc.PaymentRow)+", "
				+"PayPlanNum          =  "+POut.Long  (claimProc.PayPlanNum)+", "
				+"ClaimPaymentTracking=  "+POut.Long  (claimProc.ClaimPaymentTracking)+", "
				//SecUserNumEntry excluded from update
				//SecDateEntry not allowed to change
				//SecDateTEdit can only be set by MySQL
				+"DateSuppReceived    =  "+POut.Date  (claimProc.DateSuppReceived)+", "
				+"DateInsFinalized    =  "+POut.Date  (claimProc.DateInsFinalized)+", "
				+"IsTransfer          =  "+POut.Bool  (claimProc.IsTransfer)+" "
				+"WHERE ClaimProcNum = "+POut.Long(claimProc.ClaimProcNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one ClaimProc in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ClaimProc claimProc,ClaimProc oldClaimProc) {
			string command="";
			if(claimProc.ProcNum != oldClaimProc.ProcNum) {
				if(command!="") { command+=",";}
				command+="ProcNum = "+POut.Long(claimProc.ProcNum)+"";
			}
			if(claimProc.ClaimNum != oldClaimProc.ClaimNum) {
				if(command!="") { command+=",";}
				command+="ClaimNum = "+POut.Long(claimProc.ClaimNum)+"";
			}
			if(claimProc.PatNum != oldClaimProc.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(claimProc.PatNum)+"";
			}
			if(claimProc.ProvNum != oldClaimProc.ProvNum) {
				if(command!="") { command+=",";}
				command+="ProvNum = "+POut.Long(claimProc.ProvNum)+"";
			}
			if(claimProc.FeeBilled != oldClaimProc.FeeBilled) {
				if(command!="") { command+=",";}
				command+="FeeBilled = '"+POut.Double(claimProc.FeeBilled)+"'";
			}
			if(claimProc.InsPayEst != oldClaimProc.InsPayEst) {
				if(command!="") { command+=",";}
				command+="InsPayEst = '"+POut.Double(claimProc.InsPayEst)+"'";
			}
			if(claimProc.DedApplied != oldClaimProc.DedApplied) {
				if(command!="") { command+=",";}
				command+="DedApplied = '"+POut.Double(claimProc.DedApplied)+"'";
			}
			if(claimProc.Status != oldClaimProc.Status) {
				if(command!="") { command+=",";}
				command+="Status = "+POut.Int   ((int)claimProc.Status)+"";
			}
			if(claimProc.InsPayAmt != oldClaimProc.InsPayAmt) {
				if(command!="") { command+=",";}
				command+="InsPayAmt = '"+POut.Double(claimProc.InsPayAmt)+"'";
			}
			if(claimProc.Remarks != oldClaimProc.Remarks) {
				if(command!="") { command+=",";}
				command+="Remarks = '"+POut.String(claimProc.Remarks)+"'";
			}
			if(claimProc.ClaimPaymentNum != oldClaimProc.ClaimPaymentNum) {
				if(command!="") { command+=",";}
				command+="ClaimPaymentNum = "+POut.Long(claimProc.ClaimPaymentNum)+"";
			}
			if(claimProc.PlanNum != oldClaimProc.PlanNum) {
				if(command!="") { command+=",";}
				command+="PlanNum = "+POut.Long(claimProc.PlanNum)+"";
			}
			if(claimProc.DateCP.Date != oldClaimProc.DateCP.Date) {
				if(command!="") { command+=",";}
				command+="DateCP = "+POut.Date(claimProc.DateCP)+"";
			}
			if(claimProc.WriteOff != oldClaimProc.WriteOff) {
				if(command!="") { command+=",";}
				command+="WriteOff = '"+POut.Double(claimProc.WriteOff)+"'";
			}
			if(claimProc.CodeSent != oldClaimProc.CodeSent) {
				if(command!="") { command+=",";}
				command+="CodeSent = '"+POut.String(claimProc.CodeSent)+"'";
			}
			if(claimProc.AllowedOverride != oldClaimProc.AllowedOverride) {
				if(command!="") { command+=",";}
				command+="AllowedOverride = '"+POut.Double(claimProc.AllowedOverride)+"'";
			}
			if(claimProc.Percentage != oldClaimProc.Percentage) {
				if(command!="") { command+=",";}
				command+="Percentage = "+POut.Int(claimProc.Percentage)+"";
			}
			if(claimProc.PercentOverride != oldClaimProc.PercentOverride) {
				if(command!="") { command+=",";}
				command+="PercentOverride = "+POut.Int(claimProc.PercentOverride)+"";
			}
			if(claimProc.CopayAmt != oldClaimProc.CopayAmt) {
				if(command!="") { command+=",";}
				command+="CopayAmt = '"+POut.Double(claimProc.CopayAmt)+"'";
			}
			if(claimProc.NoBillIns != oldClaimProc.NoBillIns) {
				if(command!="") { command+=",";}
				command+="NoBillIns = "+POut.Bool(claimProc.NoBillIns)+"";
			}
			if(claimProc.PaidOtherIns != oldClaimProc.PaidOtherIns) {
				if(command!="") { command+=",";}
				command+="PaidOtherIns = '"+POut.Double(claimProc.PaidOtherIns)+"'";
			}
			if(claimProc.BaseEst != oldClaimProc.BaseEst) {
				if(command!="") { command+=",";}
				command+="BaseEst = '"+POut.Double(claimProc.BaseEst)+"'";
			}
			if(claimProc.CopayOverride != oldClaimProc.CopayOverride) {
				if(command!="") { command+=",";}
				command+="CopayOverride = '"+POut.Double(claimProc.CopayOverride)+"'";
			}
			if(claimProc.ProcDate.Date != oldClaimProc.ProcDate.Date) {
				if(command!="") { command+=",";}
				command+="ProcDate = "+POut.Date(claimProc.ProcDate)+"";
			}
			if(claimProc.DateEntry.Date != oldClaimProc.DateEntry.Date) {
				if(command!="") { command+=",";}
				command+="DateEntry = "+POut.Date(claimProc.DateEntry)+"";
			}
			if(claimProc.LineNumber != oldClaimProc.LineNumber) {
				if(command!="") { command+=",";}
				command+="LineNumber = "+POut.Byte(claimProc.LineNumber)+"";
			}
			if(claimProc.DedEst != oldClaimProc.DedEst) {
				if(command!="") { command+=",";}
				command+="DedEst = '"+POut.Double(claimProc.DedEst)+"'";
			}
			if(claimProc.DedEstOverride != oldClaimProc.DedEstOverride) {
				if(command!="") { command+=",";}
				command+="DedEstOverride = '"+POut.Double(claimProc.DedEstOverride)+"'";
			}
			if(claimProc.InsEstTotal != oldClaimProc.InsEstTotal) {
				if(command!="") { command+=",";}
				command+="InsEstTotal = '"+POut.Double(claimProc.InsEstTotal)+"'";
			}
			if(claimProc.InsEstTotalOverride != oldClaimProc.InsEstTotalOverride) {
				if(command!="") { command+=",";}
				command+="InsEstTotalOverride = '"+POut.Double(claimProc.InsEstTotalOverride)+"'";
			}
			if(claimProc.PaidOtherInsOverride != oldClaimProc.PaidOtherInsOverride) {
				if(command!="") { command+=",";}
				command+="PaidOtherInsOverride = '"+POut.Double(claimProc.PaidOtherInsOverride)+"'";
			}
			if(claimProc.EstimateNote != oldClaimProc.EstimateNote) {
				if(command!="") { command+=",";}
				command+="EstimateNote = '"+POut.String(claimProc.EstimateNote)+"'";
			}
			if(claimProc.WriteOffEst != oldClaimProc.WriteOffEst) {
				if(command!="") { command+=",";}
				command+="WriteOffEst = '"+POut.Double(claimProc.WriteOffEst)+"'";
			}
			if(claimProc.WriteOffEstOverride != oldClaimProc.WriteOffEstOverride) {
				if(command!="") { command+=",";}
				command+="WriteOffEstOverride = '"+POut.Double(claimProc.WriteOffEstOverride)+"'";
			}
			if(claimProc.ClinicNum != oldClaimProc.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(claimProc.ClinicNum)+"";
			}
			if(claimProc.InsSubNum != oldClaimProc.InsSubNum) {
				if(command!="") { command+=",";}
				command+="InsSubNum = "+POut.Long(claimProc.InsSubNum)+"";
			}
			if(claimProc.PaymentRow != oldClaimProc.PaymentRow) {
				if(command!="") { command+=",";}
				command+="PaymentRow = "+POut.Int(claimProc.PaymentRow)+"";
			}
			if(claimProc.PayPlanNum != oldClaimProc.PayPlanNum) {
				if(command!="") { command+=",";}
				command+="PayPlanNum = "+POut.Long(claimProc.PayPlanNum)+"";
			}
			if(claimProc.ClaimPaymentTracking != oldClaimProc.ClaimPaymentTracking) {
				if(command!="") { command+=",";}
				command+="ClaimPaymentTracking = "+POut.Long(claimProc.ClaimPaymentTracking)+"";
			}
			//SecUserNumEntry excluded from update
			//SecDateEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			if(claimProc.DateSuppReceived.Date != oldClaimProc.DateSuppReceived.Date) {
				if(command!="") { command+=",";}
				command+="DateSuppReceived = "+POut.Date(claimProc.DateSuppReceived)+"";
			}
			if(claimProc.DateInsFinalized.Date != oldClaimProc.DateInsFinalized.Date) {
				if(command!="") { command+=",";}
				command+="DateInsFinalized = "+POut.Date(claimProc.DateInsFinalized)+"";
			}
			if(claimProc.IsTransfer != oldClaimProc.IsTransfer) {
				if(command!="") { command+=",";}
				command+="IsTransfer = "+POut.Bool(claimProc.IsTransfer)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE claimproc SET "+command
				+" WHERE ClaimProcNum = "+POut.Long(claimProc.ClaimProcNum);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(ClaimProc,ClaimProc) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ClaimProc claimProc,ClaimProc oldClaimProc) {
			if(claimProc.ProcNum != oldClaimProc.ProcNum) {
				return true;
			}
			if(claimProc.ClaimNum != oldClaimProc.ClaimNum) {
				return true;
			}
			if(claimProc.PatNum != oldClaimProc.PatNum) {
				return true;
			}
			if(claimProc.ProvNum != oldClaimProc.ProvNum) {
				return true;
			}
			if(claimProc.FeeBilled != oldClaimProc.FeeBilled) {
				return true;
			}
			if(claimProc.InsPayEst != oldClaimProc.InsPayEst) {
				return true;
			}
			if(claimProc.DedApplied != oldClaimProc.DedApplied) {
				return true;
			}
			if(claimProc.Status != oldClaimProc.Status) {
				return true;
			}
			if(claimProc.InsPayAmt != oldClaimProc.InsPayAmt) {
				return true;
			}
			if(claimProc.Remarks != oldClaimProc.Remarks) {
				return true;
			}
			if(claimProc.ClaimPaymentNum != oldClaimProc.ClaimPaymentNum) {
				return true;
			}
			if(claimProc.PlanNum != oldClaimProc.PlanNum) {
				return true;
			}
			if(claimProc.DateCP.Date != oldClaimProc.DateCP.Date) {
				return true;
			}
			if(claimProc.WriteOff != oldClaimProc.WriteOff) {
				return true;
			}
			if(claimProc.CodeSent != oldClaimProc.CodeSent) {
				return true;
			}
			if(claimProc.AllowedOverride != oldClaimProc.AllowedOverride) {
				return true;
			}
			if(claimProc.Percentage != oldClaimProc.Percentage) {
				return true;
			}
			if(claimProc.PercentOverride != oldClaimProc.PercentOverride) {
				return true;
			}
			if(claimProc.CopayAmt != oldClaimProc.CopayAmt) {
				return true;
			}
			if(claimProc.NoBillIns != oldClaimProc.NoBillIns) {
				return true;
			}
			if(claimProc.PaidOtherIns != oldClaimProc.PaidOtherIns) {
				return true;
			}
			if(claimProc.BaseEst != oldClaimProc.BaseEst) {
				return true;
			}
			if(claimProc.CopayOverride != oldClaimProc.CopayOverride) {
				return true;
			}
			if(claimProc.ProcDate.Date != oldClaimProc.ProcDate.Date) {
				return true;
			}
			if(claimProc.DateEntry.Date != oldClaimProc.DateEntry.Date) {
				return true;
			}
			if(claimProc.LineNumber != oldClaimProc.LineNumber) {
				return true;
			}
			if(claimProc.DedEst != oldClaimProc.DedEst) {
				return true;
			}
			if(claimProc.DedEstOverride != oldClaimProc.DedEstOverride) {
				return true;
			}
			if(claimProc.InsEstTotal != oldClaimProc.InsEstTotal) {
				return true;
			}
			if(claimProc.InsEstTotalOverride != oldClaimProc.InsEstTotalOverride) {
				return true;
			}
			if(claimProc.PaidOtherInsOverride != oldClaimProc.PaidOtherInsOverride) {
				return true;
			}
			if(claimProc.EstimateNote != oldClaimProc.EstimateNote) {
				return true;
			}
			if(claimProc.WriteOffEst != oldClaimProc.WriteOffEst) {
				return true;
			}
			if(claimProc.WriteOffEstOverride != oldClaimProc.WriteOffEstOverride) {
				return true;
			}
			if(claimProc.ClinicNum != oldClaimProc.ClinicNum) {
				return true;
			}
			if(claimProc.InsSubNum != oldClaimProc.InsSubNum) {
				return true;
			}
			if(claimProc.PaymentRow != oldClaimProc.PaymentRow) {
				return true;
			}
			if(claimProc.PayPlanNum != oldClaimProc.PayPlanNum) {
				return true;
			}
			if(claimProc.ClaimPaymentTracking != oldClaimProc.ClaimPaymentTracking) {
				return true;
			}
			//SecUserNumEntry excluded from update
			//SecDateEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			if(claimProc.DateSuppReceived.Date != oldClaimProc.DateSuppReceived.Date) {
				return true;
			}
			if(claimProc.DateInsFinalized.Date != oldClaimProc.DateInsFinalized.Date) {
				return true;
			}
			if(claimProc.IsTransfer != oldClaimProc.IsTransfer) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ClaimProc from the database.</summary>
		public static void Delete(long claimProcNum) {
			string command="DELETE FROM claimproc "
				+"WHERE ClaimProcNum = "+POut.Long(claimProcNum);
			Database.ExecuteNonQuery(command);
		}

	}
}