//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: v4.0.30319
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Imedisoft.Data.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Imedisoft.Data
{
	public partial class EvaluationDefs
	{
		public static EvaluationDef FromReader(MySqlDataReader dataReader)
		{
			return new EvaluationDef
			{
				Id = (long)dataReader["id"],
				SchoolCourseId = (long)dataReader["school_course_id"],
				GradingScaleId = (long)dataReader["grading_scale_id"],
				Title = (string)dataReader["title"]
			};
		}

		/// <summary>
		/// Selects a single EvaluationDef object from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static EvaluationDef SelectOne(string command, params MySqlParameter[] parameters)
			=> Database.SelectOne(command, FromReader, parameters);

		/// <summary>
		/// Selects the <see cref="EvaluationDef"/> object with the specified key from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="EvaluationDef"/> to select.</param>
		public static EvaluationDef SelectOne(long id)
			=> SelectOne("SELECT * FROM `evaluation_defs` WHERE `id` = " + id);

		/// <summary>
		/// Selects multiple <see cref="EvaluationDef"/> objects from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static IEnumerable<EvaluationDef> SelectMany(string command, params MySqlParameter[] parameters)
			=> Database.SelectMany(command, FromReader, parameters);

		/// <summary>
		/// Inserts the specified <see cref="EvaluationDef"/> into the database.
		/// </summary>
		/// <param name="evaluationDef">The <see cref="EvaluationDef"/> to insert into the database.</param>
		private static long ExecuteInsert(EvaluationDef evaluationDef)
			=> evaluationDef.Id = Database.ExecuteInsert(
				"INSERT INTO `evaluation_defs` " +
				"(`school_course_id`, `grading_scale_id`, `title`) " +
				"VALUES (" +
					"@school_course_id, @grading_scale_id, @title" +
				")",
					new MySqlParameter("school_course_id", evaluationDef.SchoolCourseId),
					new MySqlParameter("grading_scale_id", evaluationDef.GradingScaleId),
					new MySqlParameter("title", evaluationDef.Title ?? ""));

		/// <summary>
		/// Updates the specified <see cref="EvaluationDef"/> in the database.
		/// </summary>
		/// <param name="evaluationDef">The <see cref="EvaluationDef"/> to update.</param>
		private static void ExecuteUpdate(EvaluationDef evaluationDef)
			=> Database.ExecuteNonQuery(
				"UPDATE `evaluation_defs` SET " +
					"`school_course_id` = @school_course_id, " +
					"`grading_scale_id` = @grading_scale_id, " +
					"`title` = @title " +
				"WHERE `id` = @id",
					new MySqlParameter("id", evaluationDef.Id),
					new MySqlParameter("school_course_id", evaluationDef.SchoolCourseId),
					new MySqlParameter("grading_scale_id", evaluationDef.GradingScaleId),
					new MySqlParameter("title", evaluationDef.Title ?? ""));

		/// <summary>
		/// Deletes a single <see cref="EvaluationDef"/> object from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="EvaluationDef"/> to delete.</param>
		private static void ExecuteDelete(long id)
			 => Database.ExecuteNonQuery("DELETE FROM `evaluation_defs` WHERE `id` = " + id);

		/// <summary>
		/// Deletes the specified <see cref="EvaluationDef"/> object from the database.
		/// </summary>
		/// <param name="evaluationDef">The <see cref="EvaluationDef"/> to delete.</param>
		private static void ExecuteDelete(EvaluationDef evaluationDef)
			=> ExecuteDelete(evaluationDef.Id);
	}
}
