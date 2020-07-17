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
	public class ApptThankYouSentCrud {
		///<summary>Gets one ApptThankYouSent object from the database using the primary key.  Returns null if not found.</summary>
		public static ApptThankYouSent SelectOne(long apptThankYouSentNum) {
			string command="SELECT * FROM apptthankyousent "
				+"WHERE ApptThankYouSentNum = "+POut.Long(apptThankYouSentNum);
			List<ApptThankYouSent> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ApptThankYouSent object from the database using a query.</summary>
		public static ApptThankYouSent SelectOne(string command) {
			List<ApptThankYouSent> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ApptThankYouSent objects from the database using a query.</summary>
		public static List<ApptThankYouSent> SelectMany(string command) {
			List<ApptThankYouSent> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ApptThankYouSent> TableToList(DataTable table) {
			List<ApptThankYouSent> retVal=new List<ApptThankYouSent>();
			ApptThankYouSent apptThankYouSent;
			foreach(DataRow row in table.Rows) {
				apptThankYouSent=new ApptThankYouSent();
				apptThankYouSent.ApptThankYouSentNum     = PIn.Long  (row["ApptThankYouSentNum"].ToString());
				apptThankYouSent.ApptNum                 = PIn.Long  (row["ApptNum"].ToString());
				apptThankYouSent.ApptDateTime            = PIn.Date (row["ApptDateTime"].ToString());
				apptThankYouSent.ApptSecDateTEntry       = PIn.Date (row["ApptSecDateTEntry"].ToString());
				apptThankYouSent.TSPrior                 = TimeSpan.FromTicks(PIn.Long(row["TSPrior"].ToString()));
				apptThankYouSent.ApptReminderRuleNum     = PIn.Long  (row["ApptReminderRuleNum"].ToString());
				apptThankYouSent.SmsSentStatus           = (OpenDentBusiness.AutoCommStatus)PIn.Int(row["SmsSentStatus"].ToString());
				apptThankYouSent.EmailSentStatus         = (OpenDentBusiness.AutoCommStatus)PIn.Int(row["EmailSentStatus"].ToString());
				apptThankYouSent.IsForSms                = PIn.Bool  (row["IsForSms"].ToString());
				apptThankYouSent.IsForEmail              = PIn.Bool  (row["IsForEmail"].ToString());
				apptThankYouSent.ClinicNum               = PIn.Long  (row["ClinicNum"].ToString());
				apptThankYouSent.PatNum                  = PIn.Long  (row["PatNum"].ToString());
				apptThankYouSent.PhonePat                = PIn.String(row["PhonePat"].ToString());
				apptThankYouSent.ResponseDescript        = PIn.String(row["ResponseDescript"].ToString());
				apptThankYouSent.GuidMessageToMobile     = PIn.String(row["GuidMessageToMobile"].ToString());
				apptThankYouSent.MsgTextToMobileTemplate = PIn.String(row["MsgTextToMobileTemplate"].ToString());
				apptThankYouSent.MsgTextToMobile         = PIn.String(row["MsgTextToMobile"].ToString());
				apptThankYouSent.EmailSubjTemplate       = PIn.String(row["EmailSubjTemplate"].ToString());
				apptThankYouSent.EmailSubj               = PIn.String(row["EmailSubj"].ToString());
				apptThankYouSent.EmailTextTemplate       = PIn.String(row["EmailTextTemplate"].ToString());
				apptThankYouSent.EmailText               = PIn.String(row["EmailText"].ToString());
				apptThankYouSent.DateTimeThankYouTransmit= PIn.Date (row["DateTimeThankYouTransmit"].ToString());
				apptThankYouSent.ShortGuidEmail          = PIn.String(row["ShortGuidEmail"].ToString());
				apptThankYouSent.ShortGUID               = PIn.String(row["ShortGUID"].ToString());
				apptThankYouSent.DoNotResend             = PIn.Bool  (row["DoNotResend"].ToString());
				retVal.Add(apptThankYouSent);
			}
			return retVal;
		}

		///<summary>Converts a list of ApptThankYouSent into a DataTable.</summary>
		public static DataTable ListToTable(List<ApptThankYouSent> listApptThankYouSents,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ApptThankYouSent";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ApptThankYouSentNum");
			table.Columns.Add("ApptNum");
			table.Columns.Add("ApptDateTime");
			table.Columns.Add("ApptSecDateTEntry");
			table.Columns.Add("TSPrior");
			table.Columns.Add("ApptReminderRuleNum");
			table.Columns.Add("SmsSentStatus");
			table.Columns.Add("EmailSentStatus");
			table.Columns.Add("IsForSms");
			table.Columns.Add("IsForEmail");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("PhonePat");
			table.Columns.Add("ResponseDescript");
			table.Columns.Add("GuidMessageToMobile");
			table.Columns.Add("MsgTextToMobileTemplate");
			table.Columns.Add("MsgTextToMobile");
			table.Columns.Add("EmailSubjTemplate");
			table.Columns.Add("EmailSubj");
			table.Columns.Add("EmailTextTemplate");
			table.Columns.Add("EmailText");
			table.Columns.Add("DateTimeThankYouTransmit");
			table.Columns.Add("ShortGuidEmail");
			table.Columns.Add("ShortGUID");
			table.Columns.Add("DoNotResend");
			foreach(ApptThankYouSent apptThankYouSent in listApptThankYouSents) {
				table.Rows.Add(new object[] {
					POut.Long  (apptThankYouSent.ApptThankYouSentNum),
					POut.Long  (apptThankYouSent.ApptNum),
					POut.DateT (apptThankYouSent.ApptDateTime,false),
					POut.DateT (apptThankYouSent.ApptSecDateTEntry,false),
					POut.Long (apptThankYouSent.TSPrior.Ticks),
					POut.Long  (apptThankYouSent.ApptReminderRuleNum),
					POut.Int   ((int)apptThankYouSent.SmsSentStatus),
					POut.Int   ((int)apptThankYouSent.EmailSentStatus),
					POut.Bool  (apptThankYouSent.IsForSms),
					POut.Bool  (apptThankYouSent.IsForEmail),
					POut.Long  (apptThankYouSent.ClinicNum),
					POut.Long  (apptThankYouSent.PatNum),
					            apptThankYouSent.PhonePat,
					            apptThankYouSent.ResponseDescript,
					            apptThankYouSent.GuidMessageToMobile,
					            apptThankYouSent.MsgTextToMobileTemplate,
					            apptThankYouSent.MsgTextToMobile,
					            apptThankYouSent.EmailSubjTemplate,
					            apptThankYouSent.EmailSubj,
					            apptThankYouSent.EmailTextTemplate,
					            apptThankYouSent.EmailText,
					POut.DateT (apptThankYouSent.DateTimeThankYouTransmit,false),
					            apptThankYouSent.ShortGuidEmail,
					            apptThankYouSent.ShortGUID,
					POut.Bool  (apptThankYouSent.DoNotResend),
				});
			}
			return table;
		}

		///<summary>Inserts one ApptThankYouSent into the database.  Returns the new priKey.</summary>
		public static long Insert(ApptThankYouSent apptThankYouSent) {
			return Insert(apptThankYouSent,false);
		}

		///<summary>Inserts one ApptThankYouSent into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ApptThankYouSent apptThankYouSent,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				apptThankYouSent.ApptThankYouSentNum=ReplicationServers.GetKey("apptthankyousent","ApptThankYouSentNum");
			}
			string command="INSERT INTO apptthankyousent (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ApptThankYouSentNum,";
			}
			command+="ApptNum,ApptDateTime,ApptSecDateTEntry,TSPrior,ApptReminderRuleNum,SmsSentStatus,EmailSentStatus,IsForSms,IsForEmail,ClinicNum,PatNum,PhonePat,ResponseDescript,GuidMessageToMobile,MsgTextToMobileTemplate,MsgTextToMobile,EmailSubjTemplate,EmailSubj,EmailTextTemplate,EmailText,DateTimeThankYouTransmit,ShortGuidEmail,ShortGUID,DoNotResend) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(apptThankYouSent.ApptThankYouSentNum)+",";
			}
			command+=
				     POut.Long  (apptThankYouSent.ApptNum)+","
				+    POut.DateT (apptThankYouSent.ApptDateTime)+","
				+    POut.DateT (apptThankYouSent.ApptSecDateTEntry)+","
				+"'"+POut.Long  (apptThankYouSent.TSPrior.Ticks)+"',"
				+    POut.Long  (apptThankYouSent.ApptReminderRuleNum)+","
				+    POut.Int   ((int)apptThankYouSent.SmsSentStatus)+","
				+    POut.Int   ((int)apptThankYouSent.EmailSentStatus)+","
				+    POut.Bool  (apptThankYouSent.IsForSms)+","
				+    POut.Bool  (apptThankYouSent.IsForEmail)+","
				+    POut.Long  (apptThankYouSent.ClinicNum)+","
				+    POut.Long  (apptThankYouSent.PatNum)+","
				+"'"+POut.String(apptThankYouSent.PhonePat)+"',"
				+    DbHelper.ParamChar+"paramResponseDescript,"
				+    DbHelper.ParamChar+"paramGuidMessageToMobile,"
				+    DbHelper.ParamChar+"paramMsgTextToMobileTemplate,"
				+    DbHelper.ParamChar+"paramMsgTextToMobile,"
				+    DbHelper.ParamChar+"paramEmailSubjTemplate,"
				+    DbHelper.ParamChar+"paramEmailSubj,"
				+    DbHelper.ParamChar+"paramEmailTextTemplate,"
				+    DbHelper.ParamChar+"paramEmailText,"
				+    POut.DateT (apptThankYouSent.DateTimeThankYouTransmit)+","
				+"'"+POut.String(apptThankYouSent.ShortGuidEmail)+"',"
				+"'"+POut.String(apptThankYouSent.ShortGUID)+"',"
				+    POut.Bool  (apptThankYouSent.DoNotResend)+")";
			if(apptThankYouSent.ResponseDescript==null) {
				apptThankYouSent.ResponseDescript="";
			}
			var paramResponseDescript = new MySqlParameter("paramResponseDescript", POut.StringParam(apptThankYouSent.ResponseDescript));
			if(apptThankYouSent.GuidMessageToMobile==null) {
				apptThankYouSent.GuidMessageToMobile="";
			}
			var paramGuidMessageToMobile = new MySqlParameter("paramGuidMessageToMobile", POut.StringParam(apptThankYouSent.GuidMessageToMobile));
			if(apptThankYouSent.MsgTextToMobileTemplate==null) {
				apptThankYouSent.MsgTextToMobileTemplate="";
			}
			var paramMsgTextToMobileTemplate = new MySqlParameter("paramMsgTextToMobileTemplate", POut.StringParam(apptThankYouSent.MsgTextToMobileTemplate));
			if(apptThankYouSent.MsgTextToMobile==null) {
				apptThankYouSent.MsgTextToMobile="";
			}
			var paramMsgTextToMobile = new MySqlParameter("paramMsgTextToMobile", POut.StringParam(apptThankYouSent.MsgTextToMobile));
			if(apptThankYouSent.EmailSubjTemplate==null) {
				apptThankYouSent.EmailSubjTemplate="";
			}
			var paramEmailSubjTemplate = new MySqlParameter("paramEmailSubjTemplate", POut.StringParam(apptThankYouSent.EmailSubjTemplate));
			if(apptThankYouSent.EmailSubj==null) {
				apptThankYouSent.EmailSubj="";
			}
			var paramEmailSubj = new MySqlParameter("paramEmailSubj", POut.StringParam(apptThankYouSent.EmailSubj));
			if(apptThankYouSent.EmailTextTemplate==null) {
				apptThankYouSent.EmailTextTemplate="";
			}
			var paramEmailTextTemplate = new MySqlParameter("paramEmailTextTemplate", POut.StringParam(apptThankYouSent.EmailTextTemplate));
			if(apptThankYouSent.EmailText==null) {
				apptThankYouSent.EmailText="";
			}
			var paramEmailText = new MySqlParameter("paramEmailText", POut.StringParam(apptThankYouSent.EmailText));
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command,paramResponseDescript,paramGuidMessageToMobile,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramEmailSubjTemplate,paramEmailSubj,paramEmailTextTemplate,paramEmailText);
			}
			else {
				apptThankYouSent.ApptThankYouSentNum=Database.ExecuteInsert(command,paramResponseDescript,paramGuidMessageToMobile,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramEmailSubjTemplate,paramEmailSubj,paramEmailTextTemplate,paramEmailText);
			}
			return apptThankYouSent.ApptThankYouSentNum;
		}

		///<summary>Inserts many ApptThankYouSents into the database.</summary>
		public static void InsertMany(List<ApptThankYouSent> listApptThankYouSents) {
			InsertMany(listApptThankYouSents,false);
		}

		///<summary>Inserts many ApptThankYouSents into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<ApptThankYouSent> listApptThankYouSents,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(ApptThankYouSent apptThankYouSent in listApptThankYouSents) {
					Insert(apptThankYouSent);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listApptThankYouSents.Count) {
					ApptThankYouSent apptThankYouSent=listApptThankYouSents[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO apptthankyousent (");
						if(useExistingPK) {
							sbCommands.Append("ApptThankYouSentNum,");
						}
						sbCommands.Append("ApptNum,ApptDateTime,ApptSecDateTEntry,TSPrior,ApptReminderRuleNum,SmsSentStatus,EmailSentStatus,IsForSms,IsForEmail,ClinicNum,PatNum,PhonePat,ResponseDescript,GuidMessageToMobile,MsgTextToMobileTemplate,MsgTextToMobile,EmailSubjTemplate,EmailSubj,EmailTextTemplate,EmailText,DateTimeThankYouTransmit,ShortGuidEmail,ShortGUID,DoNotResend) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(apptThankYouSent.ApptThankYouSentNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Long(apptThankYouSent.ApptNum)); sbRow.Append(",");
					sbRow.Append(POut.DateT(apptThankYouSent.ApptDateTime)); sbRow.Append(",");
					sbRow.Append(POut.DateT(apptThankYouSent.ApptSecDateTEntry)); sbRow.Append(",");
					sbRow.Append("'"+POut.Long  (apptThankYouSent.TSPrior.Ticks)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Long(apptThankYouSent.ApptReminderRuleNum)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)apptThankYouSent.SmsSentStatus)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)apptThankYouSent.EmailSentStatus)); sbRow.Append(",");
					sbRow.Append(POut.Bool(apptThankYouSent.IsForSms)); sbRow.Append(",");
					sbRow.Append(POut.Bool(apptThankYouSent.IsForEmail)); sbRow.Append(",");
					sbRow.Append(POut.Long(apptThankYouSent.ClinicNum)); sbRow.Append(",");
					sbRow.Append(POut.Long(apptThankYouSent.PatNum)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(apptThankYouSent.PhonePat)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(apptThankYouSent.ResponseDescript)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(apptThankYouSent.GuidMessageToMobile)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(apptThankYouSent.MsgTextToMobileTemplate)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(apptThankYouSent.MsgTextToMobile)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(apptThankYouSent.EmailSubjTemplate)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(apptThankYouSent.EmailSubj)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(apptThankYouSent.EmailTextTemplate)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(apptThankYouSent.EmailText)+"'"); sbRow.Append(",");
					sbRow.Append(POut.DateT(apptThankYouSent.DateTimeThankYouTransmit)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(apptThankYouSent.ShortGuidEmail)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(apptThankYouSent.ShortGUID)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Bool(apptThankYouSent.DoNotResend)); sbRow.Append(")");
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
						if(index==listApptThankYouSents.Count-1) {
							Database.ExecuteNonQuery(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one ApptThankYouSent into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptThankYouSent apptThankYouSent) {
			return InsertNoCache(apptThankYouSent,false);
		}

		///<summary>Inserts one ApptThankYouSent into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptThankYouSent apptThankYouSent,bool useExistingPK) {
			
			string command="INSERT INTO apptthankyousent (";
			if(!useExistingPK) {
				apptThankYouSent.ApptThankYouSentNum=ReplicationServers.GetKeyNoCache("apptthankyousent","ApptThankYouSentNum");
			}
			if(useExistingPK) {
				command+="ApptThankYouSentNum,";
			}
			command+="ApptNum,ApptDateTime,ApptSecDateTEntry,TSPrior,ApptReminderRuleNum,SmsSentStatus,EmailSentStatus,IsForSms,IsForEmail,ClinicNum,PatNum,PhonePat,ResponseDescript,GuidMessageToMobile,MsgTextToMobileTemplate,MsgTextToMobile,EmailSubjTemplate,EmailSubj,EmailTextTemplate,EmailText,DateTimeThankYouTransmit,ShortGuidEmail,ShortGUID,DoNotResend) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(apptThankYouSent.ApptThankYouSentNum)+",";
			}
			command+=
				     POut.Long  (apptThankYouSent.ApptNum)+","
				+    POut.DateT (apptThankYouSent.ApptDateTime)+","
				+    POut.DateT (apptThankYouSent.ApptSecDateTEntry)+","
				+"'"+POut.Long(apptThankYouSent.TSPrior.Ticks)+"',"
				+    POut.Long  (apptThankYouSent.ApptReminderRuleNum)+","
				+    POut.Int   ((int)apptThankYouSent.SmsSentStatus)+","
				+    POut.Int   ((int)apptThankYouSent.EmailSentStatus)+","
				+    POut.Bool  (apptThankYouSent.IsForSms)+","
				+    POut.Bool  (apptThankYouSent.IsForEmail)+","
				+    POut.Long  (apptThankYouSent.ClinicNum)+","
				+    POut.Long  (apptThankYouSent.PatNum)+","
				+"'"+POut.String(apptThankYouSent.PhonePat)+"',"
				+    DbHelper.ParamChar+"paramResponseDescript,"
				+    DbHelper.ParamChar+"paramGuidMessageToMobile,"
				+    DbHelper.ParamChar+"paramMsgTextToMobileTemplate,"
				+    DbHelper.ParamChar+"paramMsgTextToMobile,"
				+    DbHelper.ParamChar+"paramEmailSubjTemplate,"
				+    DbHelper.ParamChar+"paramEmailSubj,"
				+    DbHelper.ParamChar+"paramEmailTextTemplate,"
				+    DbHelper.ParamChar+"paramEmailText,"
				+    POut.DateT (apptThankYouSent.DateTimeThankYouTransmit)+","
				+"'"+POut.String(apptThankYouSent.ShortGuidEmail)+"',"
				+"'"+POut.String(apptThankYouSent.ShortGUID)+"',"
				+    POut.Bool  (apptThankYouSent.DoNotResend)+")";
			if(apptThankYouSent.ResponseDescript==null) {
				apptThankYouSent.ResponseDescript="";
			}
			var paramResponseDescript = new MySqlParameter("paramResponseDescript", POut.StringParam(apptThankYouSent.ResponseDescript));
			if(apptThankYouSent.GuidMessageToMobile==null) {
				apptThankYouSent.GuidMessageToMobile="";
			}
			var paramGuidMessageToMobile = new MySqlParameter("paramGuidMessageToMobile", POut.StringParam(apptThankYouSent.GuidMessageToMobile));
			if(apptThankYouSent.MsgTextToMobileTemplate==null) {
				apptThankYouSent.MsgTextToMobileTemplate="";
			}
			var paramMsgTextToMobileTemplate = new MySqlParameter("paramMsgTextToMobileTemplate", POut.StringParam(apptThankYouSent.MsgTextToMobileTemplate));
			if(apptThankYouSent.MsgTextToMobile==null) {
				apptThankYouSent.MsgTextToMobile="";
			}
			var paramMsgTextToMobile = new MySqlParameter("paramMsgTextToMobile", POut.StringParam(apptThankYouSent.MsgTextToMobile));
			if(apptThankYouSent.EmailSubjTemplate==null) {
				apptThankYouSent.EmailSubjTemplate="";
			}
			var paramEmailSubjTemplate = new MySqlParameter("paramEmailSubjTemplate", POut.StringParam(apptThankYouSent.EmailSubjTemplate));
			if(apptThankYouSent.EmailSubj==null) {
				apptThankYouSent.EmailSubj="";
			}
			var paramEmailSubj = new MySqlParameter("paramEmailSubj", POut.StringParam(apptThankYouSent.EmailSubj));
			if(apptThankYouSent.EmailTextTemplate==null) {
				apptThankYouSent.EmailTextTemplate="";
			}
			var paramEmailTextTemplate = new MySqlParameter("paramEmailTextTemplate", POut.StringParam(apptThankYouSent.EmailTextTemplate));
			if(apptThankYouSent.EmailText==null) {
				apptThankYouSent.EmailText="";
			}
			var paramEmailText = new MySqlParameter("paramEmailText", POut.StringParam(apptThankYouSent.EmailText));
			if(useExistingPK) {
				Database.ExecuteNonQuery(command,paramResponseDescript,paramGuidMessageToMobile,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramEmailSubjTemplate,paramEmailSubj,paramEmailTextTemplate,paramEmailText);
			}
			else {
				apptThankYouSent.ApptThankYouSentNum=Database.ExecuteInsert(command,paramResponseDescript,paramGuidMessageToMobile,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramEmailSubjTemplate,paramEmailSubj,paramEmailTextTemplate,paramEmailText);
			}
			return apptThankYouSent.ApptThankYouSentNum;
		}

		///<summary>Updates one ApptThankYouSent in the database.</summary>
		public static void Update(ApptThankYouSent apptThankYouSent) {
			string command="UPDATE apptthankyousent SET "
				+"ApptNum                 =  "+POut.Long  (apptThankYouSent.ApptNum)+", "
				+"ApptDateTime            =  "+POut.DateT (apptThankYouSent.ApptDateTime)+", "
				+"ApptSecDateTEntry       =  "+POut.DateT (apptThankYouSent.ApptSecDateTEntry)+", "
				+"TSPrior                 =  "+POut.Long  (apptThankYouSent.TSPrior.Ticks)+", "
				+"ApptReminderRuleNum     =  "+POut.Long  (apptThankYouSent.ApptReminderRuleNum)+", "
				+"SmsSentStatus           =  "+POut.Int   ((int)apptThankYouSent.SmsSentStatus)+", "
				+"EmailSentStatus         =  "+POut.Int   ((int)apptThankYouSent.EmailSentStatus)+", "
				+"IsForSms                =  "+POut.Bool  (apptThankYouSent.IsForSms)+", "
				+"IsForEmail              =  "+POut.Bool  (apptThankYouSent.IsForEmail)+", "
				+"ClinicNum               =  "+POut.Long  (apptThankYouSent.ClinicNum)+", "
				+"PatNum                  =  "+POut.Long  (apptThankYouSent.PatNum)+", "
				+"PhonePat                = '"+POut.String(apptThankYouSent.PhonePat)+"', "
				+"ResponseDescript        =  "+DbHelper.ParamChar+"paramResponseDescript, "
				+"GuidMessageToMobile     =  "+DbHelper.ParamChar+"paramGuidMessageToMobile, "
				+"MsgTextToMobileTemplate =  "+DbHelper.ParamChar+"paramMsgTextToMobileTemplate, "
				+"MsgTextToMobile         =  "+DbHelper.ParamChar+"paramMsgTextToMobile, "
				+"EmailSubjTemplate       =  "+DbHelper.ParamChar+"paramEmailSubjTemplate, "
				+"EmailSubj               =  "+DbHelper.ParamChar+"paramEmailSubj, "
				+"EmailTextTemplate       =  "+DbHelper.ParamChar+"paramEmailTextTemplate, "
				+"EmailText               =  "+DbHelper.ParamChar+"paramEmailText, "
				+"DateTimeThankYouTransmit=  "+POut.DateT (apptThankYouSent.DateTimeThankYouTransmit)+", "
				+"ShortGuidEmail          = '"+POut.String(apptThankYouSent.ShortGuidEmail)+"', "
				+"ShortGUID               = '"+POut.String(apptThankYouSent.ShortGUID)+"', "
				+"DoNotResend             =  "+POut.Bool  (apptThankYouSent.DoNotResend)+" "
				+"WHERE ApptThankYouSentNum = "+POut.Long(apptThankYouSent.ApptThankYouSentNum);
			if(apptThankYouSent.ResponseDescript==null) {
				apptThankYouSent.ResponseDescript="";
			}
			var paramResponseDescript = new MySqlParameter("paramResponseDescript", POut.StringParam(apptThankYouSent.ResponseDescript));
			if(apptThankYouSent.GuidMessageToMobile==null) {
				apptThankYouSent.GuidMessageToMobile="";
			}
			var paramGuidMessageToMobile = new MySqlParameter("paramGuidMessageToMobile", POut.StringParam(apptThankYouSent.GuidMessageToMobile));
			if(apptThankYouSent.MsgTextToMobileTemplate==null) {
				apptThankYouSent.MsgTextToMobileTemplate="";
			}
			var paramMsgTextToMobileTemplate = new MySqlParameter("paramMsgTextToMobileTemplate", POut.StringParam(apptThankYouSent.MsgTextToMobileTemplate));
			if(apptThankYouSent.MsgTextToMobile==null) {
				apptThankYouSent.MsgTextToMobile="";
			}
			var paramMsgTextToMobile = new MySqlParameter("paramMsgTextToMobile", POut.StringParam(apptThankYouSent.MsgTextToMobile));
			if(apptThankYouSent.EmailSubjTemplate==null) {
				apptThankYouSent.EmailSubjTemplate="";
			}
			var paramEmailSubjTemplate = new MySqlParameter("paramEmailSubjTemplate", POut.StringParam(apptThankYouSent.EmailSubjTemplate));
			if(apptThankYouSent.EmailSubj==null) {
				apptThankYouSent.EmailSubj="";
			}
			var paramEmailSubj = new MySqlParameter("paramEmailSubj", POut.StringParam(apptThankYouSent.EmailSubj));
			if(apptThankYouSent.EmailTextTemplate==null) {
				apptThankYouSent.EmailTextTemplate="";
			}
			var paramEmailTextTemplate = new MySqlParameter("paramEmailTextTemplate", POut.StringParam(apptThankYouSent.EmailTextTemplate));
			if(apptThankYouSent.EmailText==null) {
				apptThankYouSent.EmailText="";
			}
			var paramEmailText = new MySqlParameter("paramEmailText", POut.StringParam(apptThankYouSent.EmailText));
			Database.ExecuteNonQuery(command,paramResponseDescript,paramGuidMessageToMobile,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramEmailSubjTemplate,paramEmailSubj,paramEmailTextTemplate,paramEmailText);
		}

		///<summary>Updates one ApptThankYouSent in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ApptThankYouSent apptThankYouSent,ApptThankYouSent oldApptThankYouSent) {
			string command="";
			if(apptThankYouSent.ApptNum != oldApptThankYouSent.ApptNum) {
				if(command!="") { command+=",";}
				command+="ApptNum = "+POut.Long(apptThankYouSent.ApptNum)+"";
			}
			if(apptThankYouSent.ApptDateTime != oldApptThankYouSent.ApptDateTime) {
				if(command!="") { command+=",";}
				command+="ApptDateTime = "+POut.DateT(apptThankYouSent.ApptDateTime)+"";
			}
			if(apptThankYouSent.ApptSecDateTEntry != oldApptThankYouSent.ApptSecDateTEntry) {
				if(command!="") { command+=",";}
				command+="ApptSecDateTEntry = "+POut.DateT(apptThankYouSent.ApptSecDateTEntry)+"";
			}
			if(apptThankYouSent.TSPrior != oldApptThankYouSent.TSPrior) {
				if(command!="") { command+=",";}
				command+="TSPrior = '"+POut.Long  (apptThankYouSent.TSPrior.Ticks)+"'";
			}
			if(apptThankYouSent.ApptReminderRuleNum != oldApptThankYouSent.ApptReminderRuleNum) {
				if(command!="") { command+=",";}
				command+="ApptReminderRuleNum = "+POut.Long(apptThankYouSent.ApptReminderRuleNum)+"";
			}
			if(apptThankYouSent.SmsSentStatus != oldApptThankYouSent.SmsSentStatus) {
				if(command!="") { command+=",";}
				command+="SmsSentStatus = "+POut.Int   ((int)apptThankYouSent.SmsSentStatus)+"";
			}
			if(apptThankYouSent.EmailSentStatus != oldApptThankYouSent.EmailSentStatus) {
				if(command!="") { command+=",";}
				command+="EmailSentStatus = "+POut.Int   ((int)apptThankYouSent.EmailSentStatus)+"";
			}
			if(apptThankYouSent.IsForSms != oldApptThankYouSent.IsForSms) {
				if(command!="") { command+=",";}
				command+="IsForSms = "+POut.Bool(apptThankYouSent.IsForSms)+"";
			}
			if(apptThankYouSent.IsForEmail != oldApptThankYouSent.IsForEmail) {
				if(command!="") { command+=",";}
				command+="IsForEmail = "+POut.Bool(apptThankYouSent.IsForEmail)+"";
			}
			if(apptThankYouSent.ClinicNum != oldApptThankYouSent.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(apptThankYouSent.ClinicNum)+"";
			}
			if(apptThankYouSent.PatNum != oldApptThankYouSent.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(apptThankYouSent.PatNum)+"";
			}
			if(apptThankYouSent.PhonePat != oldApptThankYouSent.PhonePat) {
				if(command!="") { command+=",";}
				command+="PhonePat = '"+POut.String(apptThankYouSent.PhonePat)+"'";
			}
			if(apptThankYouSent.ResponseDescript != oldApptThankYouSent.ResponseDescript) {
				if(command!="") { command+=",";}
				command+="ResponseDescript = "+DbHelper.ParamChar+"paramResponseDescript";
			}
			if(apptThankYouSent.GuidMessageToMobile != oldApptThankYouSent.GuidMessageToMobile) {
				if(command!="") { command+=",";}
				command+="GuidMessageToMobile = "+DbHelper.ParamChar+"paramGuidMessageToMobile";
			}
			if(apptThankYouSent.MsgTextToMobileTemplate != oldApptThankYouSent.MsgTextToMobileTemplate) {
				if(command!="") { command+=",";}
				command+="MsgTextToMobileTemplate = "+DbHelper.ParamChar+"paramMsgTextToMobileTemplate";
			}
			if(apptThankYouSent.MsgTextToMobile != oldApptThankYouSent.MsgTextToMobile) {
				if(command!="") { command+=",";}
				command+="MsgTextToMobile = "+DbHelper.ParamChar+"paramMsgTextToMobile";
			}
			if(apptThankYouSent.EmailSubjTemplate != oldApptThankYouSent.EmailSubjTemplate) {
				if(command!="") { command+=",";}
				command+="EmailSubjTemplate = "+DbHelper.ParamChar+"paramEmailSubjTemplate";
			}
			if(apptThankYouSent.EmailSubj != oldApptThankYouSent.EmailSubj) {
				if(command!="") { command+=",";}
				command+="EmailSubj = "+DbHelper.ParamChar+"paramEmailSubj";
			}
			if(apptThankYouSent.EmailTextTemplate != oldApptThankYouSent.EmailTextTemplate) {
				if(command!="") { command+=",";}
				command+="EmailTextTemplate = "+DbHelper.ParamChar+"paramEmailTextTemplate";
			}
			if(apptThankYouSent.EmailText != oldApptThankYouSent.EmailText) {
				if(command!="") { command+=",";}
				command+="EmailText = "+DbHelper.ParamChar+"paramEmailText";
			}
			if(apptThankYouSent.DateTimeThankYouTransmit != oldApptThankYouSent.DateTimeThankYouTransmit) {
				if(command!="") { command+=",";}
				command+="DateTimeThankYouTransmit = "+POut.DateT(apptThankYouSent.DateTimeThankYouTransmit)+"";
			}
			if(apptThankYouSent.ShortGuidEmail != oldApptThankYouSent.ShortGuidEmail) {
				if(command!="") { command+=",";}
				command+="ShortGuidEmail = '"+POut.String(apptThankYouSent.ShortGuidEmail)+"'";
			}
			if(apptThankYouSent.ShortGUID != oldApptThankYouSent.ShortGUID) {
				if(command!="") { command+=",";}
				command+="ShortGUID = '"+POut.String(apptThankYouSent.ShortGUID)+"'";
			}
			if(apptThankYouSent.DoNotResend != oldApptThankYouSent.DoNotResend) {
				if(command!="") { command+=",";}
				command+="DoNotResend = "+POut.Bool(apptThankYouSent.DoNotResend)+"";
			}
			if(command=="") {
				return false;
			}
			if(apptThankYouSent.ResponseDescript==null) {
				apptThankYouSent.ResponseDescript="";
			}
			var paramResponseDescript = new MySqlParameter("paramResponseDescript", POut.StringParam(apptThankYouSent.ResponseDescript));
			if(apptThankYouSent.GuidMessageToMobile==null) {
				apptThankYouSent.GuidMessageToMobile="";
			}
			var paramGuidMessageToMobile = new MySqlParameter("paramGuidMessageToMobile", POut.StringParam(apptThankYouSent.GuidMessageToMobile));
			if(apptThankYouSent.MsgTextToMobileTemplate==null) {
				apptThankYouSent.MsgTextToMobileTemplate="";
			}
			var paramMsgTextToMobileTemplate = new MySqlParameter("paramMsgTextToMobileTemplate", POut.StringParam(apptThankYouSent.MsgTextToMobileTemplate));
			if(apptThankYouSent.MsgTextToMobile==null) {
				apptThankYouSent.MsgTextToMobile="";
			}
			var paramMsgTextToMobile = new MySqlParameter("paramMsgTextToMobile", POut.StringParam(apptThankYouSent.MsgTextToMobile));
			if(apptThankYouSent.EmailSubjTemplate==null) {
				apptThankYouSent.EmailSubjTemplate="";
			}
			var paramEmailSubjTemplate = new MySqlParameter("paramEmailSubjTemplate", POut.StringParam(apptThankYouSent.EmailSubjTemplate));
			if(apptThankYouSent.EmailSubj==null) {
				apptThankYouSent.EmailSubj="";
			}
			var paramEmailSubj = new MySqlParameter("paramEmailSubj", POut.StringParam(apptThankYouSent.EmailSubj));
			if(apptThankYouSent.EmailTextTemplate==null) {
				apptThankYouSent.EmailTextTemplate="";
			}
			var paramEmailTextTemplate = new MySqlParameter("paramEmailTextTemplate", POut.StringParam(apptThankYouSent.EmailTextTemplate));
			if(apptThankYouSent.EmailText==null) {
				apptThankYouSent.EmailText="";
			}
			var paramEmailText = new MySqlParameter("paramEmailText", POut.StringParam(apptThankYouSent.EmailText));
			command="UPDATE apptthankyousent SET "+command
				+" WHERE ApptThankYouSentNum = "+POut.Long(apptThankYouSent.ApptThankYouSentNum);
			Database.ExecuteNonQuery(command,paramResponseDescript,paramGuidMessageToMobile,paramMsgTextToMobileTemplate,paramMsgTextToMobile,paramEmailSubjTemplate,paramEmailSubj,paramEmailTextTemplate,paramEmailText);
			return true;
		}

		///<summary>Returns true if Update(ApptThankYouSent,ApptThankYouSent) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ApptThankYouSent apptThankYouSent,ApptThankYouSent oldApptThankYouSent) {
			if(apptThankYouSent.ApptNum != oldApptThankYouSent.ApptNum) {
				return true;
			}
			if(apptThankYouSent.ApptDateTime != oldApptThankYouSent.ApptDateTime) {
				return true;
			}
			if(apptThankYouSent.ApptSecDateTEntry != oldApptThankYouSent.ApptSecDateTEntry) {
				return true;
			}
			if(apptThankYouSent.TSPrior != oldApptThankYouSent.TSPrior) {
				return true;
			}
			if(apptThankYouSent.ApptReminderRuleNum != oldApptThankYouSent.ApptReminderRuleNum) {
				return true;
			}
			if(apptThankYouSent.SmsSentStatus != oldApptThankYouSent.SmsSentStatus) {
				return true;
			}
			if(apptThankYouSent.EmailSentStatus != oldApptThankYouSent.EmailSentStatus) {
				return true;
			}
			if(apptThankYouSent.IsForSms != oldApptThankYouSent.IsForSms) {
				return true;
			}
			if(apptThankYouSent.IsForEmail != oldApptThankYouSent.IsForEmail) {
				return true;
			}
			if(apptThankYouSent.ClinicNum != oldApptThankYouSent.ClinicNum) {
				return true;
			}
			if(apptThankYouSent.PatNum != oldApptThankYouSent.PatNum) {
				return true;
			}
			if(apptThankYouSent.PhonePat != oldApptThankYouSent.PhonePat) {
				return true;
			}
			if(apptThankYouSent.ResponseDescript != oldApptThankYouSent.ResponseDescript) {
				return true;
			}
			if(apptThankYouSent.GuidMessageToMobile != oldApptThankYouSent.GuidMessageToMobile) {
				return true;
			}
			if(apptThankYouSent.MsgTextToMobileTemplate != oldApptThankYouSent.MsgTextToMobileTemplate) {
				return true;
			}
			if(apptThankYouSent.MsgTextToMobile != oldApptThankYouSent.MsgTextToMobile) {
				return true;
			}
			if(apptThankYouSent.EmailSubjTemplate != oldApptThankYouSent.EmailSubjTemplate) {
				return true;
			}
			if(apptThankYouSent.EmailSubj != oldApptThankYouSent.EmailSubj) {
				return true;
			}
			if(apptThankYouSent.EmailTextTemplate != oldApptThankYouSent.EmailTextTemplate) {
				return true;
			}
			if(apptThankYouSent.EmailText != oldApptThankYouSent.EmailText) {
				return true;
			}
			if(apptThankYouSent.DateTimeThankYouTransmit != oldApptThankYouSent.DateTimeThankYouTransmit) {
				return true;
			}
			if(apptThankYouSent.ShortGuidEmail != oldApptThankYouSent.ShortGuidEmail) {
				return true;
			}
			if(apptThankYouSent.ShortGUID != oldApptThankYouSent.ShortGUID) {
				return true;
			}
			if(apptThankYouSent.DoNotResend != oldApptThankYouSent.DoNotResend) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ApptThankYouSent from the database.</summary>
		public static void Delete(long apptThankYouSentNum) {
			string command="DELETE FROM apptthankyousent "
				+"WHERE ApptThankYouSentNum = "+POut.Long(apptThankYouSentNum);
			Database.ExecuteNonQuery(command);
		}

	}
}