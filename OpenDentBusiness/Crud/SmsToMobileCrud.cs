//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace OpenDentBusiness.Crud{
	public class SmsToMobileCrud {
		///<summary>Gets one SmsToMobile object from the database using the primary key.  Returns null if not found.</summary>
		public static SmsToMobile SelectOne(long smsToMobileNum) {
			string command="SELECT * FROM smstomobile "
				+"WHERE SmsToMobileNum = "+POut.Long(smsToMobileNum);
			List<SmsToMobile> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one SmsToMobile object from the database using a query.</summary>
		public static SmsToMobile SelectOne(string command) {

			List<SmsToMobile> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of SmsToMobile objects from the database using a query.</summary>
		public static List<SmsToMobile> SelectMany(string command) {

			List<SmsToMobile> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<SmsToMobile> TableToList(DataTable table) {
			List<SmsToMobile> retVal=new List<SmsToMobile>();
			SmsToMobile smsToMobile;
			foreach(DataRow row in table.Rows) {
				smsToMobile=new SmsToMobile();
				smsToMobile.SmsToMobileNum    = PIn.Long  (row["SmsToMobileNum"].ToString());
				smsToMobile.PatNum            = PIn.Long  (row["PatNum"].ToString());
				smsToMobile.GuidMessage       = PIn.String(row["GuidMessage"].ToString());
				smsToMobile.GuidBatch         = PIn.String(row["GuidBatch"].ToString());
				smsToMobile.SmsPhoneNumber    = PIn.String(row["SmsPhoneNumber"].ToString());
				smsToMobile.MobilePhoneNumber = PIn.String(row["MobilePhoneNumber"].ToString());
				smsToMobile.IsTimeSensitive   = PIn.Bool  (row["IsTimeSensitive"].ToString());
				smsToMobile.MsgType           = (OpenDentBusiness.SmsMessageSource)PIn.Int(row["MsgType"].ToString());
				smsToMobile.MsgText           = PIn.String(row["MsgText"].ToString());
				smsToMobile.SmsStatus         = (OpenDentBusiness.SmsDeliveryStatus)PIn.Int(row["SmsStatus"].ToString());
				smsToMobile.MsgParts          = PIn.Int   (row["MsgParts"].ToString());
				smsToMobile.MsgChargeUSD      = PIn.Float (row["MsgChargeUSD"].ToString());
				smsToMobile.ClinicNum         = PIn.Long  (row["ClinicNum"].ToString());
				smsToMobile.CustErrorText     = PIn.String(row["CustErrorText"].ToString());
				smsToMobile.DateTimeSent      = PIn.DateT (row["DateTimeSent"].ToString());
				smsToMobile.DateTimeTerminated= PIn.DateT (row["DateTimeTerminated"].ToString());
				smsToMobile.IsHidden          = PIn.Bool  (row["IsHidden"].ToString());
				smsToMobile.MsgDiscountUSD    = PIn.Float (row["MsgDiscountUSD"].ToString());
				smsToMobile.SecDateTEdit      = PIn.DateT (row["SecDateTEdit"].ToString());
				retVal.Add(smsToMobile);
			}
			return retVal;
		}

		///<summary>Converts a list of SmsToMobile into a DataTable.</summary>
		public static DataTable ListToTable(List<SmsToMobile> listSmsToMobiles,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="SmsToMobile";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("SmsToMobileNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("GuidMessage");
			table.Columns.Add("GuidBatch");
			table.Columns.Add("SmsPhoneNumber");
			table.Columns.Add("MobilePhoneNumber");
			table.Columns.Add("IsTimeSensitive");
			table.Columns.Add("MsgType");
			table.Columns.Add("MsgText");
			table.Columns.Add("SmsStatus");
			table.Columns.Add("MsgParts");
			table.Columns.Add("MsgChargeUSD");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("CustErrorText");
			table.Columns.Add("DateTimeSent");
			table.Columns.Add("DateTimeTerminated");
			table.Columns.Add("IsHidden");
			table.Columns.Add("MsgDiscountUSD");
			table.Columns.Add("SecDateTEdit");
			foreach(SmsToMobile smsToMobile in listSmsToMobiles) {
				table.Rows.Add(new object[] {
					POut.Long  (smsToMobile.SmsToMobileNum),
					POut.Long  (smsToMobile.PatNum),
					            smsToMobile.GuidMessage,
					            smsToMobile.GuidBatch,
					            smsToMobile.SmsPhoneNumber,
					            smsToMobile.MobilePhoneNumber,
					POut.Bool  (smsToMobile.IsTimeSensitive),
					POut.Int   ((int)smsToMobile.MsgType),
					            smsToMobile.MsgText,
					POut.Int   ((int)smsToMobile.SmsStatus),
					POut.Int   (smsToMobile.MsgParts),
					POut.Float (smsToMobile.MsgChargeUSD),
					POut.Long  (smsToMobile.ClinicNum),
					            smsToMobile.CustErrorText,
					POut.DateT (smsToMobile.DateTimeSent,false),
					POut.DateT (smsToMobile.DateTimeTerminated,false),
					POut.Bool  (smsToMobile.IsHidden),
					POut.Float (smsToMobile.MsgDiscountUSD),
					POut.DateT (smsToMobile.SecDateTEdit,false),
				});
			}
			return table;
		}

		///<summary>Inserts one SmsToMobile into the database.  Returns the new priKey.</summary>
		public static long Insert(SmsToMobile smsToMobile) {
			return Insert(smsToMobile,false);
		}

		///<summary>Inserts one SmsToMobile into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(SmsToMobile smsToMobile,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				smsToMobile.SmsToMobileNum=ReplicationServers.GetKey("smstomobile","SmsToMobileNum");
			}
			string command="INSERT INTO smstomobile (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SmsToMobileNum,";
			}
			command+="PatNum,GuidMessage,GuidBatch,SmsPhoneNumber,MobilePhoneNumber,IsTimeSensitive,MsgType,MsgText,SmsStatus,MsgParts,MsgChargeUSD,ClinicNum,CustErrorText,DateTimeSent,DateTimeTerminated,IsHidden,MsgDiscountUSD) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(smsToMobile.SmsToMobileNum)+",";
			}
			command+=
				     POut.Long  (smsToMobile.PatNum)+","
				+"'"+POut.String(smsToMobile.GuidMessage)+"',"
				+"'"+POut.String(smsToMobile.GuidBatch)+"',"
				+"'"+POut.String(smsToMobile.SmsPhoneNumber)+"',"
				+"'"+POut.String(smsToMobile.MobilePhoneNumber)+"',"
				+    POut.Bool  (smsToMobile.IsTimeSensitive)+","
				+    POut.Int   ((int)smsToMobile.MsgType)+","
				+    DbHelper.ParamChar+"paramMsgText,"
				+    POut.Int   ((int)smsToMobile.SmsStatus)+","
				+    POut.Int   (smsToMobile.MsgParts)+","
				+    POut.Float (smsToMobile.MsgChargeUSD)+","
				+    POut.Long  (smsToMobile.ClinicNum)+","
				+"'"+POut.String(smsToMobile.CustErrorText)+"',"
				+    POut.DateT (smsToMobile.DateTimeSent)+","
				+    POut.DateT (smsToMobile.DateTimeTerminated)+","
				+    POut.Bool  (smsToMobile.IsHidden)+","
				+    POut.Float (smsToMobile.MsgDiscountUSD)+")";
				//SecDateTEdit can only be set by MySQL
			if(smsToMobile.MsgText==null) {
				smsToMobile.MsgText="";
			}
			OdSqlParameter paramMsgText=new OdSqlParameter("paramMsgText",OdDbType.Text,POut.StringNote(smsToMobile.MsgText));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramMsgText);
			}
			else {
				smsToMobile.SmsToMobileNum=Db.NonQ(command,true,"SmsToMobileNum","smsToMobile",paramMsgText);
			}
			return smsToMobile.SmsToMobileNum;
		}

		///<summary>Inserts many SmsToMobiles into the database.</summary>
		public static void InsertMany(List<SmsToMobile> listSmsToMobiles) {
			InsertMany(listSmsToMobiles,false);
		}

		///<summary>Inserts many SmsToMobiles into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<SmsToMobile> listSmsToMobiles,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(SmsToMobile smsToMobile in listSmsToMobiles) {
					Insert(smsToMobile);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listSmsToMobiles.Count) {
					SmsToMobile smsToMobile=listSmsToMobiles[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO smstomobile (");
						if(useExistingPK) {
							sbCommands.Append("SmsToMobileNum,");
						}
						sbCommands.Append("PatNum,GuidMessage,GuidBatch,SmsPhoneNumber,MobilePhoneNumber,IsTimeSensitive,MsgType,MsgText,SmsStatus,MsgParts,MsgChargeUSD,ClinicNum,CustErrorText,DateTimeSent,DateTimeTerminated,IsHidden,MsgDiscountUSD) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(smsToMobile.SmsToMobileNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Long(smsToMobile.PatNum)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(smsToMobile.GuidMessage)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(smsToMobile.GuidBatch)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(smsToMobile.SmsPhoneNumber)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(smsToMobile.MobilePhoneNumber)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Bool(smsToMobile.IsTimeSensitive)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)smsToMobile.MsgType)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(smsToMobile.MsgText)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Int((int)smsToMobile.SmsStatus)); sbRow.Append(",");
					sbRow.Append(POut.Int(smsToMobile.MsgParts)); sbRow.Append(",");
					sbRow.Append(POut.Float(smsToMobile.MsgChargeUSD)); sbRow.Append(",");
					sbRow.Append(POut.Long(smsToMobile.ClinicNum)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(smsToMobile.CustErrorText)+"'"); sbRow.Append(",");
					sbRow.Append(POut.DateT(smsToMobile.DateTimeSent)); sbRow.Append(",");
					sbRow.Append(POut.DateT(smsToMobile.DateTimeTerminated)); sbRow.Append(",");
					sbRow.Append(POut.Bool(smsToMobile.IsHidden)); sbRow.Append(",");
					sbRow.Append(POut.Float(smsToMobile.MsgDiscountUSD)); sbRow.Append(")");
					//SecDateTEdit can only be set by MySQL
					if(sbCommands.Length+sbRow.Length+1 > TableBase.MaxAllowedPacketCount && countRows > 0) {
						Db.NonQ(sbCommands.ToString());
						sbCommands=null;
					}
					else {
						if(hasComma) {
							sbCommands.Append(",");
						}
						sbCommands.Append(sbRow.ToString());
						countRows++;
						if(index==listSmsToMobiles.Count-1) {
							Db.NonQ(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one SmsToMobile into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SmsToMobile smsToMobile) {
			return InsertNoCache(smsToMobile,false);
		}

		///<summary>Inserts one SmsToMobile into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SmsToMobile smsToMobile,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO smstomobile (";
			if(!useExistingPK && isRandomKeys) {
				smsToMobile.SmsToMobileNum=ReplicationServers.GetKeyNoCache("smstomobile","SmsToMobileNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="SmsToMobileNum,";
			}
			command+="PatNum,GuidMessage,GuidBatch,SmsPhoneNumber,MobilePhoneNumber,IsTimeSensitive,MsgType,MsgText,SmsStatus,MsgParts,MsgChargeUSD,ClinicNum,CustErrorText,DateTimeSent,DateTimeTerminated,IsHidden,MsgDiscountUSD) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(smsToMobile.SmsToMobileNum)+",";
			}
			command+=
				     POut.Long  (smsToMobile.PatNum)+","
				+"'"+POut.String(smsToMobile.GuidMessage)+"',"
				+"'"+POut.String(smsToMobile.GuidBatch)+"',"
				+"'"+POut.String(smsToMobile.SmsPhoneNumber)+"',"
				+"'"+POut.String(smsToMobile.MobilePhoneNumber)+"',"
				+    POut.Bool  (smsToMobile.IsTimeSensitive)+","
				+    POut.Int   ((int)smsToMobile.MsgType)+","
				+    DbHelper.ParamChar+"paramMsgText,"
				+    POut.Int   ((int)smsToMobile.SmsStatus)+","
				+    POut.Int   (smsToMobile.MsgParts)+","
				+    POut.Float (smsToMobile.MsgChargeUSD)+","
				+    POut.Long  (smsToMobile.ClinicNum)+","
				+"'"+POut.String(smsToMobile.CustErrorText)+"',"
				+    POut.DateT (smsToMobile.DateTimeSent)+","
				+    POut.DateT (smsToMobile.DateTimeTerminated)+","
				+    POut.Bool  (smsToMobile.IsHidden)+","
				+    POut.Float (smsToMobile.MsgDiscountUSD)+")";
				//SecDateTEdit can only be set by MySQL
			if(smsToMobile.MsgText==null) {
				smsToMobile.MsgText="";
			}
			OdSqlParameter paramMsgText=new OdSqlParameter("paramMsgText",OdDbType.Text,POut.StringNote(smsToMobile.MsgText));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramMsgText);
			}
			else {
				smsToMobile.SmsToMobileNum=Db.NonQ(command,true,"SmsToMobileNum","smsToMobile",paramMsgText);
			}
			return smsToMobile.SmsToMobileNum;
		}

		///<summary>Updates one SmsToMobile in the database.</summary>
		public static void Update(SmsToMobile smsToMobile) {
			string command="UPDATE smstomobile SET "
				+"PatNum            =  "+POut.Long  (smsToMobile.PatNum)+", "
				+"GuidMessage       = '"+POut.String(smsToMobile.GuidMessage)+"', "
				+"GuidBatch         = '"+POut.String(smsToMobile.GuidBatch)+"', "
				+"SmsPhoneNumber    = '"+POut.String(smsToMobile.SmsPhoneNumber)+"', "
				+"MobilePhoneNumber = '"+POut.String(smsToMobile.MobilePhoneNumber)+"', "
				+"IsTimeSensitive   =  "+POut.Bool  (smsToMobile.IsTimeSensitive)+", "
				+"MsgType           =  "+POut.Int   ((int)smsToMobile.MsgType)+", "
				+"MsgText           =  "+DbHelper.ParamChar+"paramMsgText, "
				+"SmsStatus         =  "+POut.Int   ((int)smsToMobile.SmsStatus)+", "
				+"MsgParts          =  "+POut.Int   (smsToMobile.MsgParts)+", "
				+"MsgChargeUSD      =  "+POut.Float (smsToMobile.MsgChargeUSD)+", "
				+"ClinicNum         =  "+POut.Long  (smsToMobile.ClinicNum)+", "
				+"CustErrorText     = '"+POut.String(smsToMobile.CustErrorText)+"', "
				+"DateTimeSent      =  "+POut.DateT (smsToMobile.DateTimeSent)+", "
				+"DateTimeTerminated=  "+POut.DateT (smsToMobile.DateTimeTerminated)+", "
				+"IsHidden          =  "+POut.Bool  (smsToMobile.IsHidden)+", "
				+"MsgDiscountUSD    =  "+POut.Float (smsToMobile.MsgDiscountUSD)+" "
				//SecDateTEdit can only be set by MySQL
				+"WHERE SmsToMobileNum = "+POut.Long(smsToMobile.SmsToMobileNum);
			if(smsToMobile.MsgText==null) {
				smsToMobile.MsgText="";
			}
			OdSqlParameter paramMsgText=new OdSqlParameter("paramMsgText",OdDbType.Text,POut.StringNote(smsToMobile.MsgText));
			Db.NonQ(command,paramMsgText);
		}

		///<summary>Updates one SmsToMobile in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(SmsToMobile smsToMobile,SmsToMobile oldSmsToMobile) {
			string command="";
			if(smsToMobile.PatNum != oldSmsToMobile.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(smsToMobile.PatNum)+"";
			}
			if(smsToMobile.GuidMessage != oldSmsToMobile.GuidMessage) {
				if(command!="") { command+=",";}
				command+="GuidMessage = '"+POut.String(smsToMobile.GuidMessage)+"'";
			}
			if(smsToMobile.GuidBatch != oldSmsToMobile.GuidBatch) {
				if(command!="") { command+=",";}
				command+="GuidBatch = '"+POut.String(smsToMobile.GuidBatch)+"'";
			}
			if(smsToMobile.SmsPhoneNumber != oldSmsToMobile.SmsPhoneNumber) {
				if(command!="") { command+=",";}
				command+="SmsPhoneNumber = '"+POut.String(smsToMobile.SmsPhoneNumber)+"'";
			}
			if(smsToMobile.MobilePhoneNumber != oldSmsToMobile.MobilePhoneNumber) {
				if(command!="") { command+=",";}
				command+="MobilePhoneNumber = '"+POut.String(smsToMobile.MobilePhoneNumber)+"'";
			}
			if(smsToMobile.IsTimeSensitive != oldSmsToMobile.IsTimeSensitive) {
				if(command!="") { command+=",";}
				command+="IsTimeSensitive = "+POut.Bool(smsToMobile.IsTimeSensitive)+"";
			}
			if(smsToMobile.MsgType != oldSmsToMobile.MsgType) {
				if(command!="") { command+=",";}
				command+="MsgType = "+POut.Int   ((int)smsToMobile.MsgType)+"";
			}
			if(smsToMobile.MsgText != oldSmsToMobile.MsgText) {
				if(command!="") { command+=",";}
				command+="MsgText = "+DbHelper.ParamChar+"paramMsgText";
			}
			if(smsToMobile.SmsStatus != oldSmsToMobile.SmsStatus) {
				if(command!="") { command+=",";}
				command+="SmsStatus = "+POut.Int   ((int)smsToMobile.SmsStatus)+"";
			}
			if(smsToMobile.MsgParts != oldSmsToMobile.MsgParts) {
				if(command!="") { command+=",";}
				command+="MsgParts = "+POut.Int(smsToMobile.MsgParts)+"";
			}
			if(smsToMobile.MsgChargeUSD != oldSmsToMobile.MsgChargeUSD) {
				if(command!="") { command+=",";}
				command+="MsgChargeUSD = "+POut.Float(smsToMobile.MsgChargeUSD)+"";
			}
			if(smsToMobile.ClinicNum != oldSmsToMobile.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(smsToMobile.ClinicNum)+"";
			}
			if(smsToMobile.CustErrorText != oldSmsToMobile.CustErrorText) {
				if(command!="") { command+=",";}
				command+="CustErrorText = '"+POut.String(smsToMobile.CustErrorText)+"'";
			}
			if(smsToMobile.DateTimeSent != oldSmsToMobile.DateTimeSent) {
				if(command!="") { command+=",";}
				command+="DateTimeSent = "+POut.DateT(smsToMobile.DateTimeSent)+"";
			}
			if(smsToMobile.DateTimeTerminated != oldSmsToMobile.DateTimeTerminated) {
				if(command!="") { command+=",";}
				command+="DateTimeTerminated = "+POut.DateT(smsToMobile.DateTimeTerminated)+"";
			}
			if(smsToMobile.IsHidden != oldSmsToMobile.IsHidden) {
				if(command!="") { command+=",";}
				command+="IsHidden = "+POut.Bool(smsToMobile.IsHidden)+"";
			}
			if(smsToMobile.MsgDiscountUSD != oldSmsToMobile.MsgDiscountUSD) {
				if(command!="") { command+=",";}
				command+="MsgDiscountUSD = "+POut.Float(smsToMobile.MsgDiscountUSD)+"";
			}
			//SecDateTEdit can only be set by MySQL
			if(command=="") {
				return false;
			}
			if(smsToMobile.MsgText==null) {
				smsToMobile.MsgText="";
			}
			OdSqlParameter paramMsgText=new OdSqlParameter("paramMsgText",OdDbType.Text,POut.StringNote(smsToMobile.MsgText));
			command="UPDATE smstomobile SET "+command
				+" WHERE SmsToMobileNum = "+POut.Long(smsToMobile.SmsToMobileNum);
			Db.NonQ(command,paramMsgText);
			return true;
		}

		///<summary>Returns true if Update(SmsToMobile,SmsToMobile) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(SmsToMobile smsToMobile,SmsToMobile oldSmsToMobile) {
			if(smsToMobile.PatNum != oldSmsToMobile.PatNum) {
				return true;
			}
			if(smsToMobile.GuidMessage != oldSmsToMobile.GuidMessage) {
				return true;
			}
			if(smsToMobile.GuidBatch != oldSmsToMobile.GuidBatch) {
				return true;
			}
			if(smsToMobile.SmsPhoneNumber != oldSmsToMobile.SmsPhoneNumber) {
				return true;
			}
			if(smsToMobile.MobilePhoneNumber != oldSmsToMobile.MobilePhoneNumber) {
				return true;
			}
			if(smsToMobile.IsTimeSensitive != oldSmsToMobile.IsTimeSensitive) {
				return true;
			}
			if(smsToMobile.MsgType != oldSmsToMobile.MsgType) {
				return true;
			}
			if(smsToMobile.MsgText != oldSmsToMobile.MsgText) {
				return true;
			}
			if(smsToMobile.SmsStatus != oldSmsToMobile.SmsStatus) {
				return true;
			}
			if(smsToMobile.MsgParts != oldSmsToMobile.MsgParts) {
				return true;
			}
			if(smsToMobile.MsgChargeUSD != oldSmsToMobile.MsgChargeUSD) {
				return true;
			}
			if(smsToMobile.ClinicNum != oldSmsToMobile.ClinicNum) {
				return true;
			}
			if(smsToMobile.CustErrorText != oldSmsToMobile.CustErrorText) {
				return true;
			}
			if(smsToMobile.DateTimeSent != oldSmsToMobile.DateTimeSent) {
				return true;
			}
			if(smsToMobile.DateTimeTerminated != oldSmsToMobile.DateTimeTerminated) {
				return true;
			}
			if(smsToMobile.IsHidden != oldSmsToMobile.IsHidden) {
				return true;
			}
			if(smsToMobile.MsgDiscountUSD != oldSmsToMobile.MsgDiscountUSD) {
				return true;
			}
			//SecDateTEdit can only be set by MySQL
			return false;
		}

		///<summary>Deletes one SmsToMobile from the database.</summary>
		public static void Delete(long smsToMobileNum) {
			string command="DELETE FROM smstomobile "
				+"WHERE SmsToMobileNum = "+POut.Long(smsToMobileNum);
			Db.NonQ(command);
		}

	}
}