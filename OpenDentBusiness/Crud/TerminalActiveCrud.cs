//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class TerminalActiveCrud {
		///<summary>Gets one TerminalActive object from the database using the primary key.  Returns null if not found.</summary>
		public static TerminalActive SelectOne(long terminalActiveNum) {
			string command="SELECT * FROM terminalactive "
				+"WHERE TerminalActiveNum = "+POut.Long(terminalActiveNum);
			List<TerminalActive> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one TerminalActive object from the database using a query.</summary>
		public static TerminalActive SelectOne(string command) {

			List<TerminalActive> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of TerminalActive objects from the database using a query.</summary>
		public static List<TerminalActive> SelectMany(string command) {

			List<TerminalActive> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<TerminalActive> TableToList(DataTable table) {
			List<TerminalActive> retVal=new List<TerminalActive>();
			TerminalActive terminalActive;
			foreach(DataRow row in table.Rows) {
				terminalActive=new TerminalActive();
				terminalActive.TerminalActiveNum= PIn.Long  (row["TerminalActiveNum"].ToString());
				terminalActive.ComputerName     = PIn.String(row["ComputerName"].ToString());
				terminalActive.TerminalStatus   = (OpenDentBusiness.TerminalStatusEnum)PIn.Int(row["TerminalStatus"].ToString());
				terminalActive.PatNum           = PIn.Long  (row["PatNum"].ToString());
				terminalActive.SessionId        = PIn.Int   (row["SessionId"].ToString());
				terminalActive.ProcessId        = PIn.Int   (row["ProcessId"].ToString());
				terminalActive.SessionName      = PIn.String(row["SessionName"].ToString());
				retVal.Add(terminalActive);
			}
			return retVal;
		}

		///<summary>Converts a list of TerminalActive into a DataTable.</summary>
		public static DataTable ListToTable(List<TerminalActive> listTerminalActives,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="TerminalActive";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("TerminalActiveNum");
			table.Columns.Add("ComputerName");
			table.Columns.Add("TerminalStatus");
			table.Columns.Add("PatNum");
			table.Columns.Add("SessionId");
			table.Columns.Add("ProcessId");
			table.Columns.Add("SessionName");
			foreach(TerminalActive terminalActive in listTerminalActives) {
				table.Rows.Add(new object[] {
					POut.Long  (terminalActive.TerminalActiveNum),
					            terminalActive.ComputerName,
					POut.Int   ((int)terminalActive.TerminalStatus),
					POut.Long  (terminalActive.PatNum),
					POut.Int   (terminalActive.SessionId),
					POut.Int   (terminalActive.ProcessId),
					            terminalActive.SessionName,
				});
			}
			return table;
		}

		///<summary>Inserts one TerminalActive into the database.  Returns the new priKey.</summary>
		public static long Insert(TerminalActive terminalActive) {
			return Insert(terminalActive,false);
		}

		///<summary>Inserts one TerminalActive into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(TerminalActive terminalActive,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				terminalActive.TerminalActiveNum=ReplicationServers.GetKey("terminalactive","TerminalActiveNum");
			}
			string command="INSERT INTO terminalactive (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="TerminalActiveNum,";
			}
			command+="ComputerName,TerminalStatus,PatNum,SessionId,ProcessId,SessionName) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(terminalActive.TerminalActiveNum)+",";
			}
			command+=
				 "'"+POut.String(terminalActive.ComputerName)+"',"
				+    POut.Int   ((int)terminalActive.TerminalStatus)+","
				+    POut.Long  (terminalActive.PatNum)+","
				+    POut.Int   (terminalActive.SessionId)+","
				+    POut.Int   (terminalActive.ProcessId)+","
				+"'"+POut.String(terminalActive.SessionName)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				terminalActive.TerminalActiveNum=Database.ExecuteInsert(command);
			}
			return terminalActive.TerminalActiveNum;
		}

		///<summary>Inserts one TerminalActive into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(TerminalActive terminalActive) {
			return InsertNoCache(terminalActive,false);
		}

		///<summary>Inserts one TerminalActive into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(TerminalActive terminalActive,bool useExistingPK) {
			
			string command="INSERT INTO terminalactive (";
			if(!useExistingPK) {
				terminalActive.TerminalActiveNum=ReplicationServers.GetKeyNoCache("terminalactive","TerminalActiveNum");
			}
			if(useExistingPK) {
				command+="TerminalActiveNum,";
			}
			command+="ComputerName,TerminalStatus,PatNum,SessionId,ProcessId,SessionName) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(terminalActive.TerminalActiveNum)+",";
			}
			command+=
				 "'"+POut.String(terminalActive.ComputerName)+"',"
				+    POut.Int   ((int)terminalActive.TerminalStatus)+","
				+    POut.Long  (terminalActive.PatNum)+","
				+    POut.Int   (terminalActive.SessionId)+","
				+    POut.Int   (terminalActive.ProcessId)+","
				+"'"+POut.String(terminalActive.SessionName)+"')";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				terminalActive.TerminalActiveNum=Database.ExecuteInsert(command);
			}
			return terminalActive.TerminalActiveNum;
		}

		///<summary>Updates one TerminalActive in the database.</summary>
		public static void Update(TerminalActive terminalActive) {
			string command="UPDATE terminalactive SET "
				+"ComputerName     = '"+POut.String(terminalActive.ComputerName)+"', "
				+"TerminalStatus   =  "+POut.Int   ((int)terminalActive.TerminalStatus)+", "
				+"PatNum           =  "+POut.Long  (terminalActive.PatNum)+", "
				+"SessionId        =  "+POut.Int   (terminalActive.SessionId)+", "
				+"ProcessId        =  "+POut.Int   (terminalActive.ProcessId)+", "
				+"SessionName      = '"+POut.String(terminalActive.SessionName)+"' "
				+"WHERE TerminalActiveNum = "+POut.Long(terminalActive.TerminalActiveNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one TerminalActive in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(TerminalActive terminalActive,TerminalActive oldTerminalActive) {
			string command="";
			if(terminalActive.ComputerName != oldTerminalActive.ComputerName) {
				if(command!="") { command+=",";}
				command+="ComputerName = '"+POut.String(terminalActive.ComputerName)+"'";
			}
			if(terminalActive.TerminalStatus != oldTerminalActive.TerminalStatus) {
				if(command!="") { command+=",";}
				command+="TerminalStatus = "+POut.Int   ((int)terminalActive.TerminalStatus)+"";
			}
			if(terminalActive.PatNum != oldTerminalActive.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(terminalActive.PatNum)+"";
			}
			if(terminalActive.SessionId != oldTerminalActive.SessionId) {
				if(command!="") { command+=",";}
				command+="SessionId = "+POut.Int(terminalActive.SessionId)+"";
			}
			if(terminalActive.ProcessId != oldTerminalActive.ProcessId) {
				if(command!="") { command+=",";}
				command+="ProcessId = "+POut.Int(terminalActive.ProcessId)+"";
			}
			if(terminalActive.SessionName != oldTerminalActive.SessionName) {
				if(command!="") { command+=",";}
				command+="SessionName = '"+POut.String(terminalActive.SessionName)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE terminalactive SET "+command
				+" WHERE TerminalActiveNum = "+POut.Long(terminalActive.TerminalActiveNum);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(TerminalActive,TerminalActive) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(TerminalActive terminalActive,TerminalActive oldTerminalActive) {
			if(terminalActive.ComputerName != oldTerminalActive.ComputerName) {
				return true;
			}
			if(terminalActive.TerminalStatus != oldTerminalActive.TerminalStatus) {
				return true;
			}
			if(terminalActive.PatNum != oldTerminalActive.PatNum) {
				return true;
			}
			if(terminalActive.SessionId != oldTerminalActive.SessionId) {
				return true;
			}
			if(terminalActive.ProcessId != oldTerminalActive.ProcessId) {
				return true;
			}
			if(terminalActive.SessionName != oldTerminalActive.SessionName) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one TerminalActive from the database.</summary>
		public static void Delete(long terminalActiveNum) {
			string command="DELETE FROM terminalactive "
				+"WHERE TerminalActiveNum = "+POut.Long(terminalActiveNum);
			Database.ExecuteNonQuery(command);
		}

	}
}