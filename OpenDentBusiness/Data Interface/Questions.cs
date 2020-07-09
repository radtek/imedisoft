using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace OpenDentBusiness {
	///<summary></summary>
	public class Questions {
		#region Get Methods
		#endregion

		#region Modification Methods
		
		#region Insert
		#endregion

		#region Update
		#endregion

		#region Delete
		#endregion

		#endregion

		#region Misc Methods
		#endregion

		///<summary>Gets a list of all Questions for a given patient.  Sorted by ItemOrder.</summary>
		public static Question[] Refresh(long patNum) {
			
			string command="SELECT * FROM question WHERE PatNum="+POut.Long(patNum)
				+" ORDER BY ItemOrder";
			return Crud.QuestionCrud.SelectMany(command).ToArray();
		}	

		///<summary></summary>
		public static void Update(Question quest) {
			
			Crud.QuestionCrud.Update(quest);
		}

		///<summary></summary>
		public static long Insert(Question quest) {
			
			return Crud.QuestionCrud.Insert(quest);
		}

	
		
		
	}

		



		
	

	

	


}










