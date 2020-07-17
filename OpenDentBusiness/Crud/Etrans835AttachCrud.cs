//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class Etrans835AttachCrud {
		///<summary>Gets one Etrans835Attach object from the database using the primary key.  Returns null if not found.</summary>
		public static Etrans835Attach SelectOne(long etrans835AttachNum) {
			string command="SELECT * FROM etrans835attach "
				+"WHERE Etrans835AttachNum = "+POut.Long(etrans835AttachNum);
			List<Etrans835Attach> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Etrans835Attach object from the database using a query.</summary>
		public static Etrans835Attach SelectOne(string command) {

			List<Etrans835Attach> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Etrans835Attach objects from the database using a query.</summary>
		public static List<Etrans835Attach> SelectMany(string command) {

			List<Etrans835Attach> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Etrans835Attach> TableToList(DataTable table) {
			List<Etrans835Attach> retVal=new List<Etrans835Attach>();
			Etrans835Attach etrans835Attach;
			foreach(DataRow row in table.Rows) {
				etrans835Attach=new Etrans835Attach();
				etrans835Attach.Etrans835AttachNum= PIn.Long  (row["Etrans835AttachNum"].ToString());
				etrans835Attach.EtransNum         = PIn.Long  (row["EtransNum"].ToString());
				etrans835Attach.ClaimNum          = PIn.Long  (row["ClaimNum"].ToString());
				etrans835Attach.ClpSegmentIndex   = PIn.Int   (row["ClpSegmentIndex"].ToString());
				etrans835Attach.DateTimeEntry     = PIn.Date (row["DateTimeEntry"].ToString());
				retVal.Add(etrans835Attach);
			}
			return retVal;
		}

		///<summary>Converts a list of Etrans835Attach into a DataTable.</summary>
		public static DataTable ListToTable(List<Etrans835Attach> listEtrans835Attachs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Etrans835Attach";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("Etrans835AttachNum");
			table.Columns.Add("EtransNum");
			table.Columns.Add("ClaimNum");
			table.Columns.Add("ClpSegmentIndex");
			table.Columns.Add("DateTimeEntry");
			foreach(Etrans835Attach etrans835Attach in listEtrans835Attachs) {
				table.Rows.Add(new object[] {
					POut.Long  (etrans835Attach.Etrans835AttachNum),
					POut.Long  (etrans835Attach.EtransNum),
					POut.Long  (etrans835Attach.ClaimNum),
					POut.Int   (etrans835Attach.ClpSegmentIndex),
					POut.DateT (etrans835Attach.DateTimeEntry,false),
				});
			}
			return table;
		}

		///<summary>Inserts one Etrans835Attach into the database.  Returns the new priKey.</summary>
		public static long Insert(Etrans835Attach etrans835Attach) {
			return Insert(etrans835Attach,false);
		}

		///<summary>Inserts one Etrans835Attach into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Etrans835Attach etrans835Attach,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				etrans835Attach.Etrans835AttachNum=ReplicationServers.GetKey("etrans835attach","Etrans835AttachNum");
			}
			string command="INSERT INTO etrans835attach (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="Etrans835AttachNum,";
			}
			command+="EtransNum,ClaimNum,ClpSegmentIndex,DateTimeEntry) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(etrans835Attach.Etrans835AttachNum)+",";
			}
			command+=
				     POut.Long  (etrans835Attach.EtransNum)+","
				+    POut.Long  (etrans835Attach.ClaimNum)+","
				+    POut.Int   (etrans835Attach.ClpSegmentIndex)+","
				+    DbHelper.Now()+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command);
			}
			else {
				etrans835Attach.Etrans835AttachNum=Database.ExecuteInsert(command);
			}
			return etrans835Attach.Etrans835AttachNum;
		}

		///<summary>Inserts one Etrans835Attach into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Etrans835Attach etrans835Attach) {
			return InsertNoCache(etrans835Attach,false);
		}

		///<summary>Inserts one Etrans835Attach into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Etrans835Attach etrans835Attach,bool useExistingPK) {
			
			string command="INSERT INTO etrans835attach (";
			if(!useExistingPK) {
				etrans835Attach.Etrans835AttachNum=ReplicationServers.GetKeyNoCache("etrans835attach","Etrans835AttachNum");
			}
			if(useExistingPK) {
				command+="Etrans835AttachNum,";
			}
			command+="EtransNum,ClaimNum,ClpSegmentIndex,DateTimeEntry) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(etrans835Attach.Etrans835AttachNum)+",";
			}
			command+=
				     POut.Long  (etrans835Attach.EtransNum)+","
				+    POut.Long  (etrans835Attach.ClaimNum)+","
				+    POut.Int   (etrans835Attach.ClpSegmentIndex)+","
				+    DbHelper.Now()+")";
			if(useExistingPK) {
				Database.ExecuteNonQuery(command);
			}
			else {
				etrans835Attach.Etrans835AttachNum=Database.ExecuteInsert(command);
			}
			return etrans835Attach.Etrans835AttachNum;
		}

		///<summary>Updates one Etrans835Attach in the database.</summary>
		public static void Update(Etrans835Attach etrans835Attach) {
			string command="UPDATE etrans835attach SET "
				+"EtransNum         =  "+POut.Long  (etrans835Attach.EtransNum)+", "
				+"ClaimNum          =  "+POut.Long  (etrans835Attach.ClaimNum)+", "
				+"ClpSegmentIndex   =  "+POut.Int   (etrans835Attach.ClpSegmentIndex)+" "
				//DateTimeEntry not allowed to change
				+"WHERE Etrans835AttachNum = "+POut.Long(etrans835Attach.Etrans835AttachNum);
			Database.ExecuteNonQuery(command);
		}

		///<summary>Updates one Etrans835Attach in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Etrans835Attach etrans835Attach,Etrans835Attach oldEtrans835Attach) {
			string command="";
			if(etrans835Attach.EtransNum != oldEtrans835Attach.EtransNum) {
				if(command!="") { command+=",";}
				command+="EtransNum = "+POut.Long(etrans835Attach.EtransNum)+"";
			}
			if(etrans835Attach.ClaimNum != oldEtrans835Attach.ClaimNum) {
				if(command!="") { command+=",";}
				command+="ClaimNum = "+POut.Long(etrans835Attach.ClaimNum)+"";
			}
			if(etrans835Attach.ClpSegmentIndex != oldEtrans835Attach.ClpSegmentIndex) {
				if(command!="") { command+=",";}
				command+="ClpSegmentIndex = "+POut.Int(etrans835Attach.ClpSegmentIndex)+"";
			}
			//DateTimeEntry not allowed to change
			if(command=="") {
				return false;
			}
			command="UPDATE etrans835attach SET "+command
				+" WHERE Etrans835AttachNum = "+POut.Long(etrans835Attach.Etrans835AttachNum);
			Database.ExecuteNonQuery(command);
			return true;
		}

		///<summary>Returns true if Update(Etrans835Attach,Etrans835Attach) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Etrans835Attach etrans835Attach,Etrans835Attach oldEtrans835Attach) {
			if(etrans835Attach.EtransNum != oldEtrans835Attach.EtransNum) {
				return true;
			}
			if(etrans835Attach.ClaimNum != oldEtrans835Attach.ClaimNum) {
				return true;
			}
			if(etrans835Attach.ClpSegmentIndex != oldEtrans835Attach.ClpSegmentIndex) {
				return true;
			}
			//DateTimeEntry not allowed to change
			return false;
		}

		///<summary>Deletes one Etrans835Attach from the database.</summary>
		public static void Delete(long etrans835AttachNum) {
			string command="DELETE FROM etrans835attach "
				+"WHERE Etrans835AttachNum = "+POut.Long(etrans835AttachNum);
			Database.ExecuteNonQuery(command);
		}

	}
}