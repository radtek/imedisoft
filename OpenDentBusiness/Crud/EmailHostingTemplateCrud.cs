//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class EmailHostingTemplateCrud {
		///<summary>Gets one EmailHostingTemplate object from the database using the primary key.  Returns null if not found.</summary>
		public static EmailHostingTemplate SelectOne(long emailHostingTemplateNum) {
			string command="SELECT * FROM emailhostingtemplate "
				+"WHERE EmailHostingTemplateNum = "+POut.Long(emailHostingTemplateNum);
			List<EmailHostingTemplate> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EmailHostingTemplate object from the database using a query.</summary>
		public static EmailHostingTemplate SelectOne(string command) {

			List<EmailHostingTemplate> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EmailHostingTemplate objects from the database using a query.</summary>
		public static List<EmailHostingTemplate> SelectMany(string command) {

			List<EmailHostingTemplate> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EmailHostingTemplate> TableToList(DataTable table) {
			List<EmailHostingTemplate> retVal=new List<EmailHostingTemplate>();
			EmailHostingTemplate emailHostingTemplate;
			foreach(DataRow row in table.Rows) {
				emailHostingTemplate=new EmailHostingTemplate();
				emailHostingTemplate.EmailHostingTemplateNum= PIn.Long  (row["EmailHostingTemplateNum"].ToString());
				emailHostingTemplate.TemplateName           = PIn.String(row["TemplateName"].ToString());
				emailHostingTemplate.Subject                = PIn.String(row["Subject"].ToString());
				emailHostingTemplate.BodyPlainText          = PIn.String(row["BodyPlainText"].ToString());
				emailHostingTemplate.BodyHTML               = PIn.String(row["BodyHTML"].ToString());
				emailHostingTemplate.TemplateId             = PIn.Long  (row["TemplateId"].ToString());
				emailHostingTemplate.ClinicNum              = PIn.Long  (row["ClinicNum"].ToString());
				string emailTemplateType=row["EmailTemplateType"].ToString();
				if(emailTemplateType=="") {
					emailHostingTemplate.EmailTemplateType    =(OpenDentBusiness.EmailType)0;
				}
				else try{
					emailHostingTemplate.EmailTemplateType    =(OpenDentBusiness.EmailType)Enum.Parse(typeof(OpenDentBusiness.EmailType),emailTemplateType);
				}
				catch{
					emailHostingTemplate.EmailTemplateType    =(OpenDentBusiness.EmailType)0;
				}
				retVal.Add(emailHostingTemplate);
			}
			return retVal;
		}

		///<summary>Converts a list of EmailHostingTemplate into a DataTable.</summary>
		public static DataTable ListToTable(List<EmailHostingTemplate> listEmailHostingTemplates,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="EmailHostingTemplate";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("EmailHostingTemplateNum");
			table.Columns.Add("TemplateName");
			table.Columns.Add("Subject");
			table.Columns.Add("BodyPlainText");
			table.Columns.Add("BodyHTML");
			table.Columns.Add("TemplateId");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("EmailTemplateType");
			foreach(EmailHostingTemplate emailHostingTemplate in listEmailHostingTemplates) {
				table.Rows.Add(new object[] {
					POut.Long  (emailHostingTemplate.EmailHostingTemplateNum),
					            emailHostingTemplate.TemplateName,
					            emailHostingTemplate.Subject,
					            emailHostingTemplate.BodyPlainText,
					            emailHostingTemplate.BodyHTML,
					POut.Long  (emailHostingTemplate.TemplateId),
					POut.Long  (emailHostingTemplate.ClinicNum),
					POut.Int   ((int)emailHostingTemplate.EmailTemplateType),
				});
			}
			return table;
		}

		///<summary>Inserts one EmailHostingTemplate into the database.  Returns the new priKey.</summary>
		public static long Insert(EmailHostingTemplate emailHostingTemplate) {
			return Insert(emailHostingTemplate,false);
		}

		///<summary>Inserts one EmailHostingTemplate into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EmailHostingTemplate emailHostingTemplate,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				emailHostingTemplate.EmailHostingTemplateNum=ReplicationServers.GetKey("emailhostingtemplate","EmailHostingTemplateNum");
			}
			string command="INSERT INTO emailhostingtemplate (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EmailHostingTemplateNum,";
			}
			command+="TemplateName,Subject,BodyPlainText,BodyHTML,TemplateId,ClinicNum,EmailTemplateType) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(emailHostingTemplate.EmailHostingTemplateNum)+",";
			}
			command+=
				 "'"+POut.String(emailHostingTemplate.TemplateName)+"',"
				+    DbHelper.ParamChar+"paramSubject,"
				+    DbHelper.ParamChar+"paramBodyPlainText,"
				+    DbHelper.ParamChar+"paramBodyHTML,"
				+    POut.Long  (emailHostingTemplate.TemplateId)+","
				+    POut.Long  (emailHostingTemplate.ClinicNum)+","
				+"'"+POut.String(emailHostingTemplate.EmailTemplateType.ToString())+"')";
			if(emailHostingTemplate.Subject==null) {
				emailHostingTemplate.Subject="";
			}
			OdSqlParameter paramSubject=new OdSqlParameter("paramSubject",OdDbType.Text,POut.StringParam(emailHostingTemplate.Subject));
			if(emailHostingTemplate.BodyPlainText==null) {
				emailHostingTemplate.BodyPlainText="";
			}
			OdSqlParameter paramBodyPlainText=new OdSqlParameter("paramBodyPlainText",OdDbType.Text,POut.StringParam(emailHostingTemplate.BodyPlainText));
			if(emailHostingTemplate.BodyHTML==null) {
				emailHostingTemplate.BodyHTML="";
			}
			OdSqlParameter paramBodyHTML=new OdSqlParameter("paramBodyHTML",OdDbType.Text,POut.StringParam(emailHostingTemplate.BodyHTML));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramSubject,paramBodyPlainText,paramBodyHTML);
			}
			else {
				emailHostingTemplate.EmailHostingTemplateNum=Db.NonQ(command,true,"EmailHostingTemplateNum","emailHostingTemplate",paramSubject,paramBodyPlainText,paramBodyHTML);
			}
			return emailHostingTemplate.EmailHostingTemplateNum;
		}

		///<summary>Inserts one EmailHostingTemplate into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EmailHostingTemplate emailHostingTemplate) {
			return InsertNoCache(emailHostingTemplate,false);
		}

		///<summary>Inserts one EmailHostingTemplate into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EmailHostingTemplate emailHostingTemplate,bool useExistingPK) {
			
			string command="INSERT INTO emailhostingtemplate (";
			if(!useExistingPK) {
				emailHostingTemplate.EmailHostingTemplateNum=ReplicationServers.GetKeyNoCache("emailhostingtemplate","EmailHostingTemplateNum");
			}
			if(useExistingPK) {
				command+="EmailHostingTemplateNum,";
			}
			command+="TemplateName,Subject,BodyPlainText,BodyHTML,TemplateId,ClinicNum,EmailTemplateType) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(emailHostingTemplate.EmailHostingTemplateNum)+",";
			}
			command+=
				 "'"+POut.String(emailHostingTemplate.TemplateName)+"',"
				+    DbHelper.ParamChar+"paramSubject,"
				+    DbHelper.ParamChar+"paramBodyPlainText,"
				+    DbHelper.ParamChar+"paramBodyHTML,"
				+    POut.Long  (emailHostingTemplate.TemplateId)+","
				+    POut.Long  (emailHostingTemplate.ClinicNum)+","
				+"'"+POut.String(emailHostingTemplate.EmailTemplateType.ToString())+"')";
			if(emailHostingTemplate.Subject==null) {
				emailHostingTemplate.Subject="";
			}
			OdSqlParameter paramSubject=new OdSqlParameter("paramSubject",OdDbType.Text,POut.StringParam(emailHostingTemplate.Subject));
			if(emailHostingTemplate.BodyPlainText==null) {
				emailHostingTemplate.BodyPlainText="";
			}
			OdSqlParameter paramBodyPlainText=new OdSqlParameter("paramBodyPlainText",OdDbType.Text,POut.StringParam(emailHostingTemplate.BodyPlainText));
			if(emailHostingTemplate.BodyHTML==null) {
				emailHostingTemplate.BodyHTML="";
			}
			OdSqlParameter paramBodyHTML=new OdSqlParameter("paramBodyHTML",OdDbType.Text,POut.StringParam(emailHostingTemplate.BodyHTML));
			if(useExistingPK) {
				Db.NonQ(command,paramSubject,paramBodyPlainText,paramBodyHTML);
			}
			else {
				emailHostingTemplate.EmailHostingTemplateNum=Db.NonQ(command,true,"EmailHostingTemplateNum","emailHostingTemplate",paramSubject,paramBodyPlainText,paramBodyHTML);
			}
			return emailHostingTemplate.EmailHostingTemplateNum;
		}

		///<summary>Updates one EmailHostingTemplate in the database.</summary>
		public static void Update(EmailHostingTemplate emailHostingTemplate) {
			string command="UPDATE emailhostingtemplate SET "
				+"TemplateName           = '"+POut.String(emailHostingTemplate.TemplateName)+"', "
				+"Subject                =  "+DbHelper.ParamChar+"paramSubject, "
				+"BodyPlainText          =  "+DbHelper.ParamChar+"paramBodyPlainText, "
				+"BodyHTML               =  "+DbHelper.ParamChar+"paramBodyHTML, "
				+"TemplateId             =  "+POut.Long  (emailHostingTemplate.TemplateId)+", "
				+"ClinicNum              =  "+POut.Long  (emailHostingTemplate.ClinicNum)+", "
				+"EmailTemplateType      = '"+POut.String(emailHostingTemplate.EmailTemplateType.ToString())+"' "
				+"WHERE EmailHostingTemplateNum = "+POut.Long(emailHostingTemplate.EmailHostingTemplateNum);
			if(emailHostingTemplate.Subject==null) {
				emailHostingTemplate.Subject="";
			}
			OdSqlParameter paramSubject=new OdSqlParameter("paramSubject",OdDbType.Text,POut.StringParam(emailHostingTemplate.Subject));
			if(emailHostingTemplate.BodyPlainText==null) {
				emailHostingTemplate.BodyPlainText="";
			}
			OdSqlParameter paramBodyPlainText=new OdSqlParameter("paramBodyPlainText",OdDbType.Text,POut.StringParam(emailHostingTemplate.BodyPlainText));
			if(emailHostingTemplate.BodyHTML==null) {
				emailHostingTemplate.BodyHTML="";
			}
			OdSqlParameter paramBodyHTML=new OdSqlParameter("paramBodyHTML",OdDbType.Text,POut.StringParam(emailHostingTemplate.BodyHTML));
			Db.NonQ(command,paramSubject,paramBodyPlainText,paramBodyHTML);
		}

		///<summary>Updates one EmailHostingTemplate in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EmailHostingTemplate emailHostingTemplate,EmailHostingTemplate oldEmailHostingTemplate) {
			string command="";
			if(emailHostingTemplate.TemplateName != oldEmailHostingTemplate.TemplateName) {
				if(command!="") { command+=",";}
				command+="TemplateName = '"+POut.String(emailHostingTemplate.TemplateName)+"'";
			}
			if(emailHostingTemplate.Subject != oldEmailHostingTemplate.Subject) {
				if(command!="") { command+=",";}
				command+="Subject = "+DbHelper.ParamChar+"paramSubject";
			}
			if(emailHostingTemplate.BodyPlainText != oldEmailHostingTemplate.BodyPlainText) {
				if(command!="") { command+=",";}
				command+="BodyPlainText = "+DbHelper.ParamChar+"paramBodyPlainText";
			}
			if(emailHostingTemplate.BodyHTML != oldEmailHostingTemplate.BodyHTML) {
				if(command!="") { command+=",";}
				command+="BodyHTML = "+DbHelper.ParamChar+"paramBodyHTML";
			}
			if(emailHostingTemplate.TemplateId != oldEmailHostingTemplate.TemplateId) {
				if(command!="") { command+=",";}
				command+="TemplateId = "+POut.Long(emailHostingTemplate.TemplateId)+"";
			}
			if(emailHostingTemplate.ClinicNum != oldEmailHostingTemplate.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(emailHostingTemplate.ClinicNum)+"";
			}
			if(emailHostingTemplate.EmailTemplateType != oldEmailHostingTemplate.EmailTemplateType) {
				if(command!="") { command+=",";}
				command+="EmailTemplateType = '"+POut.String(emailHostingTemplate.EmailTemplateType.ToString())+"'";
			}
			if(command=="") {
				return false;
			}
			if(emailHostingTemplate.Subject==null) {
				emailHostingTemplate.Subject="";
			}
			OdSqlParameter paramSubject=new OdSqlParameter("paramSubject",OdDbType.Text,POut.StringParam(emailHostingTemplate.Subject));
			if(emailHostingTemplate.BodyPlainText==null) {
				emailHostingTemplate.BodyPlainText="";
			}
			OdSqlParameter paramBodyPlainText=new OdSqlParameter("paramBodyPlainText",OdDbType.Text,POut.StringParam(emailHostingTemplate.BodyPlainText));
			if(emailHostingTemplate.BodyHTML==null) {
				emailHostingTemplate.BodyHTML="";
			}
			OdSqlParameter paramBodyHTML=new OdSqlParameter("paramBodyHTML",OdDbType.Text,POut.StringParam(emailHostingTemplate.BodyHTML));
			command="UPDATE emailhostingtemplate SET "+command
				+" WHERE EmailHostingTemplateNum = "+POut.Long(emailHostingTemplate.EmailHostingTemplateNum);
			Db.NonQ(command,paramSubject,paramBodyPlainText,paramBodyHTML);
			return true;
		}

		///<summary>Returns true if Update(EmailHostingTemplate,EmailHostingTemplate) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(EmailHostingTemplate emailHostingTemplate,EmailHostingTemplate oldEmailHostingTemplate) {
			if(emailHostingTemplate.TemplateName != oldEmailHostingTemplate.TemplateName) {
				return true;
			}
			if(emailHostingTemplate.Subject != oldEmailHostingTemplate.Subject) {
				return true;
			}
			if(emailHostingTemplate.BodyPlainText != oldEmailHostingTemplate.BodyPlainText) {
				return true;
			}
			if(emailHostingTemplate.BodyHTML != oldEmailHostingTemplate.BodyHTML) {
				return true;
			}
			if(emailHostingTemplate.TemplateId != oldEmailHostingTemplate.TemplateId) {
				return true;
			}
			if(emailHostingTemplate.ClinicNum != oldEmailHostingTemplate.ClinicNum) {
				return true;
			}
			if(emailHostingTemplate.EmailTemplateType != oldEmailHostingTemplate.EmailTemplateType) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one EmailHostingTemplate from the database.</summary>
		public static void Delete(long emailHostingTemplateNum) {
			string command="DELETE FROM emailhostingtemplate "
				+"WHERE EmailHostingTemplateNum = "+POut.Long(emailHostingTemplateNum);
			Db.NonQ(command);
		}

	}
}