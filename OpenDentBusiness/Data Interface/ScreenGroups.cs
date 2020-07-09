using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace OpenDentBusiness{
  ///<summary></summary>
	public class ScreenGroups{
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


		///<summary></summary>
		public static List<ScreenGroup> Refresh(DateTime fromDate,DateTime toDate){
			
			string command =
				"SELECT * from screengroup "
				+"WHERE SGDate >= "+POut.DateT(fromDate)+" "
				+"AND SGDate < "+POut.DateT(toDate.AddDays(1))+" "//Was including entries form the next day. Changed from <= to <.
				//added one day since it's calculated based on midnight.
				+"ORDER BY SGDate,ScreenGroupNum";
			return Crud.ScreenGroupCrud.SelectMany(command);
		}

		public static ScreenGroup GetScreenGroup(long screenGroupNum) {
			
			string command=
				"SELECT * FROM screengroup WHERE ScreenGroupNum="+POut.Long(screenGroupNum);
			return Crud.ScreenGroupCrud.SelectOne(command);
		}

		///<summary></summary>
		public static long Insert(ScreenGroup Cur) {
			
			return Crud.ScreenGroupCrud.Insert(Cur);
		}

		///<summary></summary>
		public static void Update(ScreenGroup Cur){
			
			Crud.ScreenGroupCrud.Update(Cur);
		}

		///<summary>This will also delete all screen items, so may need to ask user first.</summary>
		public static void Delete(ScreenGroup Cur){
			
			string command="SELECT SheetNum FROM screen WHERE ScreenGroupNum="+POut.Long(Cur.ScreenGroupNum)+" AND SheetNum!=0";
			DataTable table=Db.GetTable(command);
			foreach(DataRow row in table.Rows) {//Delete any attached sheets if the screen gets deleted.
				Sheets.Delete(PIn.Long(row["SheetNum"].ToString()));
			}
			command="DELETE FROM screen WHERE ScreenGroupNum ='"+POut.Long(Cur.ScreenGroupNum)+"'";
			Db.NonQ(command);
			command="DELETE FROM screengroup WHERE ScreenGroupNum ='"+POut.Long(Cur.ScreenGroupNum)+"'";
			Db.NonQ(command);
		}



	}

	

}













