//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class ReplicationServerCrud {
		///<summary>Gets one ReplicationServer object from the database using the primary key.  Returns null if not found.</summary>
		public static ReplicationServer SelectOne(long replicationServerNum) {
			string command="SELECT * FROM replicationserver "
				+"WHERE ReplicationServerNum = "+POut.Long(replicationServerNum);
			List<ReplicationServer> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ReplicationServer object from the database using a query.</summary>
		public static ReplicationServer SelectOne(string command) {

			List<ReplicationServer> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ReplicationServer objects from the database using a query.</summary>
		public static List<ReplicationServer> SelectMany(string command) {

			List<ReplicationServer> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ReplicationServer> TableToList(DataTable table) {
			List<ReplicationServer> retVal=new List<ReplicationServer>();
			ReplicationServer replicationServer;
			foreach(DataRow row in table.Rows) {
				replicationServer=new ReplicationServer();
				replicationServer.ReplicationServerNum= PIn.Long  (row["ReplicationServerNum"].ToString());
				replicationServer.Descript            = PIn.String(row["Descript"].ToString());
				replicationServer.ServerId            = PIn.Int   (row["ServerId"].ToString());
				replicationServer.RangeStart          = PIn.Long  (row["RangeStart"].ToString());
				replicationServer.RangeEnd            = PIn.Long  (row["RangeEnd"].ToString());
				replicationServer.AtoZpath            = PIn.String(row["AtoZpath"].ToString());
				replicationServer.UpdateBlocked       = PIn.Bool  (row["UpdateBlocked"].ToString());
				replicationServer.SlaveMonitor        = PIn.String(row["SlaveMonitor"].ToString());
				retVal.Add(replicationServer);
			}
			return retVal;
		}

		///<summary>Converts a list of ReplicationServer into a DataTable.</summary>
		public static DataTable ListToTable(List<ReplicationServer> listReplicationServers,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ReplicationServer";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ReplicationServerNum");
			table.Columns.Add("Descript");
			table.Columns.Add("ServerId");
			table.Columns.Add("RangeStart");
			table.Columns.Add("RangeEnd");
			table.Columns.Add("AtoZpath");
			table.Columns.Add("UpdateBlocked");
			table.Columns.Add("SlaveMonitor");
			foreach(ReplicationServer replicationServer in listReplicationServers) {
				table.Rows.Add(new object[] {
					POut.Long  (replicationServer.ReplicationServerNum),
					            replicationServer.Descript,
					POut.Int   (replicationServer.ServerId),
					POut.Long  (replicationServer.RangeStart),
					POut.Long  (replicationServer.RangeEnd),
					            replicationServer.AtoZpath,
					POut.Bool  (replicationServer.UpdateBlocked),
					            replicationServer.SlaveMonitor,
				});
			}
			return table;
		}

		///<summary>Inserts one ReplicationServer into the database.  Returns the new priKey.</summary>
		public static long Insert(ReplicationServer replicationServer) {
			return Insert(replicationServer,false);
		}

		///<summary>Inserts one ReplicationServer into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ReplicationServer replicationServer,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				replicationServer.ReplicationServerNum=ReplicationServers.GetKey("replicationserver","ReplicationServerNum");
			}
			string command="INSERT INTO replicationserver (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ReplicationServerNum,";
			}
			command+="Descript,ServerId,RangeStart,RangeEnd,AtoZpath,UpdateBlocked,SlaveMonitor) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(replicationServer.ReplicationServerNum)+",";
			}
			command+=
				     DbHelper.ParamChar+"paramDescript,"
				+    POut.Int   (replicationServer.ServerId)+","
				+    POut.Long  (replicationServer.RangeStart)+","
				+    POut.Long  (replicationServer.RangeEnd)+","
				+"'"+POut.String(replicationServer.AtoZpath)+"',"
				+    POut.Bool  (replicationServer.UpdateBlocked)+","
				+"'"+POut.String(replicationServer.SlaveMonitor)+"')";
			if(replicationServer.Descript==null) {
				replicationServer.Descript="";
			}
			OdSqlParameter paramDescript=new OdSqlParameter("paramDescript",OdDbType.Text,POut.StringParam(replicationServer.Descript));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramDescript);
			}
			else {
				replicationServer.ReplicationServerNum=Db.NonQ(command,true,"ReplicationServerNum","replicationServer",paramDescript);
			}
			return replicationServer.ReplicationServerNum;
		}

		///<summary>Inserts one ReplicationServer into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ReplicationServer replicationServer) {
			return InsertNoCache(replicationServer,false);
		}

		///<summary>Inserts one ReplicationServer into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ReplicationServer replicationServer,bool useExistingPK) {
			
			string command="INSERT INTO replicationserver (";
			if(!useExistingPK) {
				replicationServer.ReplicationServerNum=ReplicationServers.GetKeyNoCache("replicationserver","ReplicationServerNum");
			}
			if(useExistingPK) {
				command+="ReplicationServerNum,";
			}
			command+="Descript,ServerId,RangeStart,RangeEnd,AtoZpath,UpdateBlocked,SlaveMonitor) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(replicationServer.ReplicationServerNum)+",";
			}
			command+=
				     DbHelper.ParamChar+"paramDescript,"
				+    POut.Int   (replicationServer.ServerId)+","
				+    POut.Long  (replicationServer.RangeStart)+","
				+    POut.Long  (replicationServer.RangeEnd)+","
				+"'"+POut.String(replicationServer.AtoZpath)+"',"
				+    POut.Bool  (replicationServer.UpdateBlocked)+","
				+"'"+POut.String(replicationServer.SlaveMonitor)+"')";
			if(replicationServer.Descript==null) {
				replicationServer.Descript="";
			}
			OdSqlParameter paramDescript=new OdSqlParameter("paramDescript",OdDbType.Text,POut.StringParam(replicationServer.Descript));
			if(useExistingPK) {
				Db.NonQ(command,paramDescript);
			}
			else {
				replicationServer.ReplicationServerNum=Db.NonQ(command,true,"ReplicationServerNum","replicationServer",paramDescript);
			}
			return replicationServer.ReplicationServerNum;
		}

		///<summary>Updates one ReplicationServer in the database.</summary>
		public static void Update(ReplicationServer replicationServer) {
			string command="UPDATE replicationserver SET "
				+"Descript            =  "+DbHelper.ParamChar+"paramDescript, "
				+"ServerId            =  "+POut.Int   (replicationServer.ServerId)+", "
				+"RangeStart          =  "+POut.Long  (replicationServer.RangeStart)+", "
				+"RangeEnd            =  "+POut.Long  (replicationServer.RangeEnd)+", "
				+"AtoZpath            = '"+POut.String(replicationServer.AtoZpath)+"', "
				+"UpdateBlocked       =  "+POut.Bool  (replicationServer.UpdateBlocked)+", "
				+"SlaveMonitor        = '"+POut.String(replicationServer.SlaveMonitor)+"' "
				+"WHERE ReplicationServerNum = "+POut.Long(replicationServer.ReplicationServerNum);
			if(replicationServer.Descript==null) {
				replicationServer.Descript="";
			}
			OdSqlParameter paramDescript=new OdSqlParameter("paramDescript",OdDbType.Text,POut.StringParam(replicationServer.Descript));
			Db.NonQ(command,paramDescript);
		}

		///<summary>Updates one ReplicationServer in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ReplicationServer replicationServer,ReplicationServer oldReplicationServer) {
			string command="";
			if(replicationServer.Descript != oldReplicationServer.Descript) {
				if(command!="") { command+=",";}
				command+="Descript = "+DbHelper.ParamChar+"paramDescript";
			}
			if(replicationServer.ServerId != oldReplicationServer.ServerId) {
				if(command!="") { command+=",";}
				command+="ServerId = "+POut.Int(replicationServer.ServerId)+"";
			}
			if(replicationServer.RangeStart != oldReplicationServer.RangeStart) {
				if(command!="") { command+=",";}
				command+="RangeStart = "+POut.Long(replicationServer.RangeStart)+"";
			}
			if(replicationServer.RangeEnd != oldReplicationServer.RangeEnd) {
				if(command!="") { command+=",";}
				command+="RangeEnd = "+POut.Long(replicationServer.RangeEnd)+"";
			}
			if(replicationServer.AtoZpath != oldReplicationServer.AtoZpath) {
				if(command!="") { command+=",";}
				command+="AtoZpath = '"+POut.String(replicationServer.AtoZpath)+"'";
			}
			if(replicationServer.UpdateBlocked != oldReplicationServer.UpdateBlocked) {
				if(command!="") { command+=",";}
				command+="UpdateBlocked = "+POut.Bool(replicationServer.UpdateBlocked)+"";
			}
			if(replicationServer.SlaveMonitor != oldReplicationServer.SlaveMonitor) {
				if(command!="") { command+=",";}
				command+="SlaveMonitor = '"+POut.String(replicationServer.SlaveMonitor)+"'";
			}
			if(command=="") {
				return false;
			}
			if(replicationServer.Descript==null) {
				replicationServer.Descript="";
			}
			OdSqlParameter paramDescript=new OdSqlParameter("paramDescript",OdDbType.Text,POut.StringParam(replicationServer.Descript));
			command="UPDATE replicationserver SET "+command
				+" WHERE ReplicationServerNum = "+POut.Long(replicationServer.ReplicationServerNum);
			Db.NonQ(command,paramDescript);
			return true;
		}

		///<summary>Returns true if Update(ReplicationServer,ReplicationServer) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ReplicationServer replicationServer,ReplicationServer oldReplicationServer) {
			if(replicationServer.Descript != oldReplicationServer.Descript) {
				return true;
			}
			if(replicationServer.ServerId != oldReplicationServer.ServerId) {
				return true;
			}
			if(replicationServer.RangeStart != oldReplicationServer.RangeStart) {
				return true;
			}
			if(replicationServer.RangeEnd != oldReplicationServer.RangeEnd) {
				return true;
			}
			if(replicationServer.AtoZpath != oldReplicationServer.AtoZpath) {
				return true;
			}
			if(replicationServer.UpdateBlocked != oldReplicationServer.UpdateBlocked) {
				return true;
			}
			if(replicationServer.SlaveMonitor != oldReplicationServer.SlaveMonitor) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ReplicationServer from the database.</summary>
		public static void Delete(long replicationServerNum) {
			string command="DELETE FROM replicationserver "
				+"WHERE ReplicationServerNum = "+POut.Long(replicationServerNum);
			Db.NonQ(command);
		}

	}
}