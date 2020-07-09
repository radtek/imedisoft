using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using CodeBase;
using OpenDentBusiness.Crud;

namespace OpenDentBusiness{
	///<summary></summary>
	public class PromotionLogs {

		///<summary>Returns one promotion log for the given email hosting fk.</summary>
		public static PromotionLog GetOneByEmailHostingFK(long emailHostingFK) {
			
			return PromotionLogCrud.SelectOne($"SELECT * FROM promotionlog WHERE EmailHostingFK = {POut.Long(emailHostingFK)}");
		}

		///<summary>For the given email hosting fk, will update the status and any associated properties. If log is not found for this fk, will do nothing.</summary>
		public static void UpdatePromotionLogStatus(long emailHostingFK,PromotionLogStatus status) {
			
			PromotionLog log=GetOneByEmailHostingFK(emailHostingFK);
			//Can't do anything here.
			if(log==null) {
				return;
			}
			PromotionLog logOld=log.Clone();
			log.PromotionStatus=status;
			//Only if they are going from pending to sent or complaint will we update the date time.
			if(logOld.PromotionStatus==PromotionLogStatus.Pending && status.In(PromotionLogStatus.Delivered,PromotionLogStatus.Complaint)) {
				log.DateTimeSent=DateTime.Now;
			}
			if(status.In(PromotionLogStatus.Failed,PromotionLogStatus.Bounced,PromotionLogStatus.Unsubscribed)) {
				EmailMessage message=EmailMessages.GetOne(log.EmailMessageNum);
				if(message!=null) {
					EmailMessage messageOld=message.Copy();
					message.BodyText+=status.GetDescription().ToUpper()+"\r\n"+message.BodyText;
					EmailMessages.Update(message,messageOld);
				}
			}
			PromotionLogCrud.Update(log,logOld);
		}

		#region Modification Methods
		///<summary></summary>
		public static long Insert(PromotionLog promotionLog){
			
			return Crud.PromotionLogCrud.Insert(promotionLog);
		}

		///<summary>Inserts all given promotion logs. Will not return primary keys.</summary>
		public static void InsertMany(List<PromotionLog> listLogs) {
			if(listLogs.IsNullOrEmpty()) {
				return;
			}
			
			PromotionLogCrud.InsertMany(listLogs);
		}

		#endregion Modification Methods

	}
}