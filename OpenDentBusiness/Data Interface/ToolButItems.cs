using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace OpenDentBusiness{
  ///<summary></summary>
	public class ToolButItems{

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

		#region CachePattern

		private class ToolButItemCache : CacheListAbs<ToolButItem> {
			protected override List<ToolButItem> GetCacheFromDb() {
				string command="SELECT * from toolbutitem";
				return Crud.ToolButItemCrud.SelectMany(command);
			}
			protected override List<ToolButItem> TableToList(DataTable table) {
				return Crud.ToolButItemCrud.TableToList(table);
			}
			protected override ToolButItem Copy(ToolButItem ToolButItem) {
				return ToolButItem.Copy();
			}
			protected override DataTable ListToTable(List<ToolButItem> listToolButItems) {
				return Crud.ToolButItemCrud.ListToTable(listToolButItems,"ToolButItem");
			}
			protected override void FillCacheIfNeeded() {
				ToolButItems.GetTableFromCache(false);
			}
		}
		
		///<summary>The object that accesses the cache in a thread-safe manner.</summary>
		private static ToolButItemCache _ToolButItemCache=new ToolButItemCache();

		public static bool GetCacheIsNull() {
			return _ToolButItemCache.ListIsNull();
		}

		public static List<ToolButItem> GetWhere(Predicate<ToolButItem> match,bool isShort=false) {
			return _ToolButItemCache.GetWhere(match,isShort);
		}

		///<summary>Refreshes the cache and returns it as a DataTable. This will refresh the ClientWeb's cache and the ServerWeb's cache.</summary>
		public static DataTable RefreshCache() {
			return GetTableFromCache(true);
		}

		///<summary>Fills the local cache with the passed in DataTable.</summary>
		public static void FillCacheFromTable(DataTable table) {
			_ToolButItemCache.FillCacheFromTable(table);
		}

		///<summary>Always refreshes the ClientWeb's cache.</summary>
		public static DataTable GetTableFromCache(bool doRefreshCache) {
			return _ToolButItemCache.GetTableFromCache(doRefreshCache);
		}

		#endregion

		///<summary></summary>
		public static long Insert(ToolButItem Cur){
			
			return Crud.ToolButItemCrud.Insert(Cur);
		}

		///<summary>This in not currently being used.</summary>
		public static void Update(ToolButItem Cur){
			
			Crud.ToolButItemCrud.Update(Cur);
		}

		///<summary>This is not currently being used.</summary>
		public static void Delete(ToolButItem Cur){
			
			string command = "DELETE from toolbutitem WHERE ToolButItemNum = '"
				+POut.Long(Cur.ToolButItemNum)+"'";
			Database.ExecuteNonQuery(command);
		}

		///<summary>Deletes all ToolButItems for the Programs.Cur.  This is used regularly when saving a Program link because of the way the user interface works.</summary>
		public static void DeleteAllForProgram(long programNum) {
			
			string command = "DELETE from toolbutitem WHERE ProgramNum = '"
				+POut.Long(programNum)+"'";
			Database.ExecuteNonQuery(command);
		}

		///<summary>Fills ForProgram with toolbutitems attached to the Programs.Cur</summary>
		public static List<ToolButItem> GetForProgram(long programNum) {
			//No need to check RemotingRole; no call to db.
			return GetWhere(x => x.ProgramNum==programNum);
		}

		///<summary>Returns a list of toolbutitems for the specified toolbar. Used when laying out toolbars.</summary>
		public static List<ToolButItem> GetForToolBar(ToolBarsAvail toolbar) {
			//No need to check RemotingRole; no call to db.
			return GetWhere(x => x.ToolBar==toolbar && (Programs.IsEnabled(x.ProgramNum) || ProgramProperties.IsAdvertisingBridge(x.ProgramNum)));
		}
	}

	

}













