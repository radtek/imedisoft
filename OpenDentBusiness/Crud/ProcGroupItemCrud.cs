//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace OpenDentBusiness.Crud{
	public class ProcGroupItemCrud {
		///<summary>Gets one ProcGroupItem object from the database using the primary key.  Returns null if not found.</summary>
		public static ProcGroupItem SelectOne(long procGroupItemNum) {
			string command="SELECT * FROM procgroupitem "
				+"WHERE ProcGroupItemNum = "+POut.Long(procGroupItemNum);
			List<ProcGroupItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ProcGroupItem object from the database using a query.</summary>
		public static ProcGroupItem SelectOne(string command) {

			List<ProcGroupItem> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ProcGroupItem objects from the database using a query.</summary>
		public static List<ProcGroupItem> SelectMany(string command) {

			List<ProcGroupItem> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ProcGroupItem> TableToList(DataTable table) {
			List<ProcGroupItem> retVal=new List<ProcGroupItem>();
			ProcGroupItem procGroupItem;
			foreach(DataRow row in table.Rows) {
				procGroupItem=new ProcGroupItem();
				procGroupItem.ProcGroupItemNum= PIn.Long  (row["ProcGroupItemNum"].ToString());
				procGroupItem.ProcNum         = PIn.Long  (row["ProcNum"].ToString());
				procGroupItem.GroupNum        = PIn.Long  (row["GroupNum"].ToString());
				retVal.Add(procGroupItem);
			}
			return retVal;
		}

		///<summary>Converts a list of ProcGroupItem into a DataTable.</summary>
		public static DataTable ListToTable(List<ProcGroupItem> listProcGroupItems,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ProcGroupItem";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ProcGroupItemNum");
			table.Columns.Add("ProcNum");
			table.Columns.Add("GroupNum");
			foreach(ProcGroupItem procGroupItem in listProcGroupItems) {
				table.Rows.Add(new object[] {
					POut.Long  (procGroupItem.ProcGroupItemNum),
					POut.Long  (procGroupItem.ProcNum),
					POut.Long  (procGroupItem.GroupNum),
				});
			}
			return table;
		}

		///<summary>Inserts one ProcGroupItem into the database.  Returns the new priKey.</summary>
		public static long Insert(ProcGroupItem procGroupItem) {
			return Insert(procGroupItem,false);
		}

		///<summary>Inserts one ProcGroupItem into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ProcGroupItem procGroupItem,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				procGroupItem.ProcGroupItemNum=ReplicationServers.GetKey("procgroupitem","ProcGroupItemNum");
			}
			string command="INSERT INTO procgroupitem (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ProcGroupItemNum,";
			}
			command+="ProcNum,GroupNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(procGroupItem.ProcGroupItemNum)+",";
			}
			command+=
				     POut.Long  (procGroupItem.ProcNum)+","
				+    POut.Long  (procGroupItem.GroupNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				procGroupItem.ProcGroupItemNum=Db.NonQ(command,true,"ProcGroupItemNum","procGroupItem");
			}
			return procGroupItem.ProcGroupItemNum;
		}

		///<summary>Inserts many ProcGroupItems into the database.</summary>
		public static void InsertMany(List<ProcGroupItem> listProcGroupItems) {
			InsertMany(listProcGroupItems,false);
		}

		///<summary>Inserts many ProcGroupItems into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<ProcGroupItem> listProcGroupItems,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(ProcGroupItem procGroupItem in listProcGroupItems) {
					Insert(procGroupItem);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listProcGroupItems.Count) {
					ProcGroupItem procGroupItem=listProcGroupItems[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO procgroupitem (");
						if(useExistingPK) {
							sbCommands.Append("ProcGroupItemNum,");
						}
						sbCommands.Append("ProcNum,GroupNum) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(procGroupItem.ProcGroupItemNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Long(procGroupItem.ProcNum)); sbRow.Append(",");
					sbRow.Append(POut.Long(procGroupItem.GroupNum)); sbRow.Append(")");
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
						if(index==listProcGroupItems.Count-1) {
							Db.NonQ(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one ProcGroupItem into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ProcGroupItem procGroupItem) {
			return InsertNoCache(procGroupItem,false);
		}

		///<summary>Inserts one ProcGroupItem into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ProcGroupItem procGroupItem,bool useExistingPK) {
			
			string command="INSERT INTO procgroupitem (";
			if(!useExistingPK) {
				procGroupItem.ProcGroupItemNum=ReplicationServers.GetKeyNoCache("procgroupitem","ProcGroupItemNum");
			}
			if(useExistingPK) {
				command+="ProcGroupItemNum,";
			}
			command+="ProcNum,GroupNum) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(procGroupItem.ProcGroupItemNum)+",";
			}
			command+=
				     POut.Long  (procGroupItem.ProcNum)+","
				+    POut.Long  (procGroupItem.GroupNum)+")";
			if(useExistingPK) {
				Db.NonQ(command);
			}
			else {
				procGroupItem.ProcGroupItemNum=Db.NonQ(command,true,"ProcGroupItemNum","procGroupItem");
			}
			return procGroupItem.ProcGroupItemNum;
		}

		///<summary>Updates one ProcGroupItem in the database.</summary>
		public static void Update(ProcGroupItem procGroupItem) {
			string command="UPDATE procgroupitem SET "
				+"ProcNum         =  "+POut.Long  (procGroupItem.ProcNum)+", "
				+"GroupNum        =  "+POut.Long  (procGroupItem.GroupNum)+" "
				+"WHERE ProcGroupItemNum = "+POut.Long(procGroupItem.ProcGroupItemNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ProcGroupItem in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ProcGroupItem procGroupItem,ProcGroupItem oldProcGroupItem) {
			string command="";
			if(procGroupItem.ProcNum != oldProcGroupItem.ProcNum) {
				if(command!="") { command+=",";}
				command+="ProcNum = "+POut.Long(procGroupItem.ProcNum)+"";
			}
			if(procGroupItem.GroupNum != oldProcGroupItem.GroupNum) {
				if(command!="") { command+=",";}
				command+="GroupNum = "+POut.Long(procGroupItem.GroupNum)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE procgroupitem SET "+command
				+" WHERE ProcGroupItemNum = "+POut.Long(procGroupItem.ProcGroupItemNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(ProcGroupItem,ProcGroupItem) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ProcGroupItem procGroupItem,ProcGroupItem oldProcGroupItem) {
			if(procGroupItem.ProcNum != oldProcGroupItem.ProcNum) {
				return true;
			}
			if(procGroupItem.GroupNum != oldProcGroupItem.GroupNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ProcGroupItem from the database.</summary>
		public static void Delete(long procGroupItemNum) {
			string command="DELETE FROM procgroupitem "
				+"WHERE ProcGroupItemNum = "+POut.Long(procGroupItemNum);
			Db.NonQ(command);
		}

	}
}