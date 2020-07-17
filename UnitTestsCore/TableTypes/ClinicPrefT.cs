﻿using System;
using System.Collections.Generic;
using System.Text;
using Imedisoft.Data;
using OpenDentBusiness;

namespace UnitTestsCore {
	public class ClinicPrefT {

		///<summary>Deletes everything from the clinic table.  Does not truncate the table so that PKs are not reused on accident.</summary>
		public static void ClearClinicPrefTable() {
			string command="DELETE FROM clinicPref WHERE ClinicNum > 0";
			Database.ExecuteNonQuery(command);
			ClinicPrefs.RefreshCache();
		}
	}
}
