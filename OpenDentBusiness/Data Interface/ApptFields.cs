using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace OpenDentBusiness {
	///<summary></summary>
	public class ApptFields {
		#region Get Methods

		///<summary>Gets one ApptField from the db.</summary>
		public static ApptField GetOne(long apptFieldNum) {
			
			return Crud.ApptFieldCrud.SelectOne(apptFieldNum);
		}

		public static List<ApptField> GetForAppt(long aptNum) {
			
			string command="SELECT * FROM apptfield WHERE AptNum = "+POut.Long(aptNum);
			return Crud.ApptFieldCrud.SelectMany(command);
		}

		#endregion

		#region Modification Methods

		#region Insert

		///<summary></summary>
		public static long Insert(ApptField apptField) {
			
			return Crud.ApptFieldCrud.Insert(apptField);
		}

		#endregion

		#region Update

		///<summary></summary>
		public static void Update(ApptField apptField) {
			
			Crud.ApptFieldCrud.Update(apptField);
		}

		///<summary>Deletes any pre-existing appt fields for the AptNum and FieldName combo and then inserts the apptField passed in.</summary>
		public static long Upsert(ApptField apptField) {
			
			//There could already be an appt field in the database due to concurrency.  Delete all entries prior to inserting the new one.
			DeleteFieldForAppt(apptField.FieldName,apptField.AptNum);//Last in wins.
			return Insert(apptField);
		}

		#endregion

		#region Delete

		///<summary></summary>
		public static void Delete(long apptFieldNum) {
			
			string command="DELETE FROM apptfield WHERE ApptFieldNum = "+POut.Long(apptFieldNum);
			Db.NonQ(command);
		}

		///<summary>Deletes all fields for the appointment and field name passed in.</summary>
		public static void DeleteFieldForAppt(string fieldName,long aptNum) {
			
			string command=$@"DELETE FROM apptfield 
				WHERE AptNum = {POut.Long(aptNum)}
				AND FieldName ='{POut.String(fieldName)}'";
			Db.NonQ(command);
		}

		#endregion

		#endregion

		#region Misc Methods
		#endregion

	}
}