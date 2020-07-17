//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using Imedisoft.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Crud{
	public class EvaluationCrud {
		///<summary>Gets one Evaluation object from the database using the primary key.  Returns null if not found.</summary>
		public static Evaluation SelectOne(long evaluationNum) {
			string command="SELECT * FROM evaluation "
				+"WHERE EvaluationNum = "+POut.Long(evaluationNum);
			List<Evaluation> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Evaluation object from the database using a query.</summary>
		public static Evaluation SelectOne(string command) {

			List<Evaluation> list=TableToList(Database.ExecuteDataTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Evaluation objects from the database using a query.</summary>
		public static List<Evaluation> SelectMany(string command) {

			List<Evaluation> list=TableToList(Database.ExecuteDataTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Evaluation> TableToList(DataTable table) {
			List<Evaluation> retVal=new List<Evaluation>();
			Evaluation evaluation;
			foreach(DataRow row in table.Rows) {
				evaluation=new Evaluation();
				evaluation.EvaluationNum      = PIn.Long  (row["EvaluationNum"].ToString());
				evaluation.InstructNum        = PIn.Long  (row["InstructNum"].ToString());
				evaluation.StudentNum         = PIn.Long  (row["StudentNum"].ToString());
				evaluation.SchoolCourseNum    = PIn.Long  (row["SchoolCourseNum"].ToString());
				evaluation.EvalTitle          = PIn.String(row["EvalTitle"].ToString());
				evaluation.DateEval           = PIn.Date  (row["DateEval"].ToString());
				evaluation.GradingScaleNum    = PIn.Long  (row["GradingScaleNum"].ToString());
				evaluation.OverallGradeShowing= PIn.String(row["OverallGradeShowing"].ToString());
				evaluation.OverallGradeNumber = PIn.Float (row["OverallGradeNumber"].ToString());
				evaluation.Notes              = PIn.String(row["Notes"].ToString());
				retVal.Add(evaluation);
			}
			return retVal;
		}

		///<summary>Converts a list of Evaluation into a DataTable.</summary>
		public static DataTable ListToTable(List<Evaluation> listEvaluations,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Evaluation";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("EvaluationNum");
			table.Columns.Add("InstructNum");
			table.Columns.Add("StudentNum");
			table.Columns.Add("SchoolCourseNum");
			table.Columns.Add("EvalTitle");
			table.Columns.Add("DateEval");
			table.Columns.Add("GradingScaleNum");
			table.Columns.Add("OverallGradeShowing");
			table.Columns.Add("OverallGradeNumber");
			table.Columns.Add("Notes");
			foreach(Evaluation evaluation in listEvaluations) {
				table.Rows.Add(new object[] {
					POut.Long  (evaluation.EvaluationNum),
					POut.Long  (evaluation.InstructNum),
					POut.Long  (evaluation.StudentNum),
					POut.Long  (evaluation.SchoolCourseNum),
					            evaluation.EvalTitle,
					POut.DateT (evaluation.DateEval,false),
					POut.Long  (evaluation.GradingScaleNum),
					            evaluation.OverallGradeShowing,
					POut.Float (evaluation.OverallGradeNumber),
					            evaluation.Notes,
				});
			}
			return table;
		}

		///<summary>Inserts one Evaluation into the database.  Returns the new priKey.</summary>
		public static long Insert(Evaluation evaluation) {
			return Insert(evaluation,false);
		}

		///<summary>Inserts one Evaluation into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Evaluation evaluation,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				evaluation.EvaluationNum=ReplicationServers.GetKey("evaluation","EvaluationNum");
			}
			string command="INSERT INTO evaluation (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EvaluationNum,";
			}
			command+="InstructNum,StudentNum,SchoolCourseNum,EvalTitle,DateEval,GradingScaleNum,OverallGradeShowing,OverallGradeNumber,Notes) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(evaluation.EvaluationNum)+",";
			}
			command+=
				     POut.Long  (evaluation.InstructNum)+","
				+    POut.Long  (evaluation.StudentNum)+","
				+    POut.Long  (evaluation.SchoolCourseNum)+","
				+"'"+POut.String(evaluation.EvalTitle)+"',"
				+    POut.Date  (evaluation.DateEval)+","
				+    POut.Long  (evaluation.GradingScaleNum)+","
				+"'"+POut.String(evaluation.OverallGradeShowing)+"',"
				+    POut.Float (evaluation.OverallGradeNumber)+","
				+    DbHelper.ParamChar+"paramNotes)";
			if(evaluation.Notes==null) {
				evaluation.Notes="";
			}
			var paramNotes = new MySqlParameter("paramNotes", POut.StringParam(evaluation.Notes));
			if(useExistingPK || PrefC.RandomKeys) {
				Database.ExecuteNonQuery(command,paramNotes);
			}
			else {
				evaluation.EvaluationNum=Database.ExecuteInsert(command,paramNotes);
			}
			return evaluation.EvaluationNum;
		}

		///<summary>Inserts one Evaluation into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Evaluation evaluation) {
			return InsertNoCache(evaluation,false);
		}

		///<summary>Inserts one Evaluation into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Evaluation evaluation,bool useExistingPK) {
			
			string command="INSERT INTO evaluation (";
			if(!useExistingPK) {
				evaluation.EvaluationNum=ReplicationServers.GetKeyNoCache("evaluation","EvaluationNum");
			}
			if(useExistingPK) {
				command+="EvaluationNum,";
			}
			command+="InstructNum,StudentNum,SchoolCourseNum,EvalTitle,DateEval,GradingScaleNum,OverallGradeShowing,OverallGradeNumber,Notes) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(evaluation.EvaluationNum)+",";
			}
			command+=
				     POut.Long  (evaluation.InstructNum)+","
				+    POut.Long  (evaluation.StudentNum)+","
				+    POut.Long  (evaluation.SchoolCourseNum)+","
				+"'"+POut.String(evaluation.EvalTitle)+"',"
				+    POut.Date  (evaluation.DateEval)+","
				+    POut.Long  (evaluation.GradingScaleNum)+","
				+"'"+POut.String(evaluation.OverallGradeShowing)+"',"
				+    POut.Float (evaluation.OverallGradeNumber)+","
				+    DbHelper.ParamChar+"paramNotes)";
			if(evaluation.Notes==null) {
				evaluation.Notes="";
			}
			var paramNotes = new MySqlParameter("paramNotes", POut.StringParam(evaluation.Notes));
			if(useExistingPK) {
				Database.ExecuteNonQuery(command,paramNotes);
			}
			else {
				evaluation.EvaluationNum=Database.ExecuteInsert(command,paramNotes);
			}
			return evaluation.EvaluationNum;
		}

		///<summary>Updates one Evaluation in the database.</summary>
		public static void Update(Evaluation evaluation) {
			string command="UPDATE evaluation SET "
				+"InstructNum        =  "+POut.Long  (evaluation.InstructNum)+", "
				+"StudentNum         =  "+POut.Long  (evaluation.StudentNum)+", "
				+"SchoolCourseNum    =  "+POut.Long  (evaluation.SchoolCourseNum)+", "
				+"EvalTitle          = '"+POut.String(evaluation.EvalTitle)+"', "
				+"DateEval           =  "+POut.Date  (evaluation.DateEval)+", "
				+"GradingScaleNum    =  "+POut.Long  (evaluation.GradingScaleNum)+", "
				+"OverallGradeShowing= '"+POut.String(evaluation.OverallGradeShowing)+"', "
				+"OverallGradeNumber =  "+POut.Float (evaluation.OverallGradeNumber)+", "
				+"Notes              =  "+DbHelper.ParamChar+"paramNotes "
				+"WHERE EvaluationNum = "+POut.Long(evaluation.EvaluationNum);
			if(evaluation.Notes==null) {
				evaluation.Notes="";
			}
			var paramNotes = new MySqlParameter("paramNotes", POut.StringParam(evaluation.Notes));
			Database.ExecuteNonQuery(command,paramNotes);
		}

		///<summary>Updates one Evaluation in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Evaluation evaluation,Evaluation oldEvaluation) {
			string command="";
			if(evaluation.InstructNum != oldEvaluation.InstructNum) {
				if(command!="") { command+=",";}
				command+="InstructNum = "+POut.Long(evaluation.InstructNum)+"";
			}
			if(evaluation.StudentNum != oldEvaluation.StudentNum) {
				if(command!="") { command+=",";}
				command+="StudentNum = "+POut.Long(evaluation.StudentNum)+"";
			}
			if(evaluation.SchoolCourseNum != oldEvaluation.SchoolCourseNum) {
				if(command!="") { command+=",";}
				command+="SchoolCourseNum = "+POut.Long(evaluation.SchoolCourseNum)+"";
			}
			if(evaluation.EvalTitle != oldEvaluation.EvalTitle) {
				if(command!="") { command+=",";}
				command+="EvalTitle = '"+POut.String(evaluation.EvalTitle)+"'";
			}
			if(evaluation.DateEval.Date != oldEvaluation.DateEval.Date) {
				if(command!="") { command+=",";}
				command+="DateEval = "+POut.Date(evaluation.DateEval)+"";
			}
			if(evaluation.GradingScaleNum != oldEvaluation.GradingScaleNum) {
				if(command!="") { command+=",";}
				command+="GradingScaleNum = "+POut.Long(evaluation.GradingScaleNum)+"";
			}
			if(evaluation.OverallGradeShowing != oldEvaluation.OverallGradeShowing) {
				if(command!="") { command+=",";}
				command+="OverallGradeShowing = '"+POut.String(evaluation.OverallGradeShowing)+"'";
			}
			if(evaluation.OverallGradeNumber != oldEvaluation.OverallGradeNumber) {
				if(command!="") { command+=",";}
				command+="OverallGradeNumber = "+POut.Float(evaluation.OverallGradeNumber)+"";
			}
			if(evaluation.Notes != oldEvaluation.Notes) {
				if(command!="") { command+=",";}
				command+="Notes = "+DbHelper.ParamChar+"paramNotes";
			}
			if(command=="") {
				return false;
			}
			if(evaluation.Notes==null) {
				evaluation.Notes="";
			}
			var paramNotes = new MySqlParameter("paramNotes", POut.StringParam(evaluation.Notes));
			command="UPDATE evaluation SET "+command
				+" WHERE EvaluationNum = "+POut.Long(evaluation.EvaluationNum);
			Database.ExecuteNonQuery(command,paramNotes);
			return true;
		}

		///<summary>Returns true if Update(Evaluation,Evaluation) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Evaluation evaluation,Evaluation oldEvaluation) {
			if(evaluation.InstructNum != oldEvaluation.InstructNum) {
				return true;
			}
			if(evaluation.StudentNum != oldEvaluation.StudentNum) {
				return true;
			}
			if(evaluation.SchoolCourseNum != oldEvaluation.SchoolCourseNum) {
				return true;
			}
			if(evaluation.EvalTitle != oldEvaluation.EvalTitle) {
				return true;
			}
			if(evaluation.DateEval.Date != oldEvaluation.DateEval.Date) {
				return true;
			}
			if(evaluation.GradingScaleNum != oldEvaluation.GradingScaleNum) {
				return true;
			}
			if(evaluation.OverallGradeShowing != oldEvaluation.OverallGradeShowing) {
				return true;
			}
			if(evaluation.OverallGradeNumber != oldEvaluation.OverallGradeNumber) {
				return true;
			}
			if(evaluation.Notes != oldEvaluation.Notes) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one Evaluation from the database.</summary>
		public static void Delete(long evaluationNum) {
			string command="DELETE FROM evaluation "
				+"WHERE EvaluationNum = "+POut.Long(evaluationNum);
			Database.ExecuteNonQuery(command);
		}

	}
}