﻿using Imedisoft.Data;
using OpenDentBusiness;
using System;

namespace UnitTestsCore
{
    ///<summary>Has methods for both SheetDef and SheetFieldDef. Use SheetT for sheets.</summary>
    public class SheetDefT
	{
		///<summary>Deletes everything from the sheetdef and sheetfielddef table.  Does not truncate the table so that PKs are not reused on accident.</summary>
		public static void ClearSheetDefAndSheetFieldDefTable()
		{
			string command = "DELETE FROM sheetdef WHERE sheetdefnum > 0";
			Database.ExecuteNonQuery(command);
			command = "DELETE FROM sheetfielddef WHERE sheetfielddefnum > 0";
			Database.ExecuteNonQuery(command);
			command = "DELETE FROM eclipboardsheetdef WHERE eclipboardsheetdefnum > 0";
			Database.ExecuteNonQuery(command);
		}

		///<summary>ClinicNum of 0 creates a default rule for all clinics.</summary>
		public static long CreateCustomSheet(SheetInternalType sheetInternalType, bool createEClipboardRule = true, long clinicNum = 0, int days = 30)
		{
			var sheetDef = SheetDefs.GetInternalOrCustom(sheetInternalType);
			sheetDef.IsNew = true;
			SheetDefs.InsertOrUpdate(sheetDef);
			if (!createEClipboardRule)
			{
				return sheetDef.SheetDefNum;
			}
			var existingAll = EClipboardSheetDefs.Refresh();
			var existingClinic = existingAll.FindAll(x => x.ClinicNum == clinicNum);
			int items = 0;
			existingClinic.ForEach(x => { x.ItemOrder = ++items; });
			existingAll.Add(new EClipboardSheetDef()
			{
				ClinicNum = clinicNum,
				ResubmitInterval = TimeSpan.FromDays(days),
				SheetDefNum = sheetDef.SheetDefNum,
				ItemOrder = ++items,
			});
			EClipboardSheetDefs.Sync(existingAll, EClipboardSheetDefs.Refresh());
			SheetDefs.RefreshCache();
			SheetFieldDefs.RefreshCache();
			return sheetDef.SheetDefNum;
		}
	}
}
