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
using System.Collections.Generic;

namespace Imedisoft.Data
{
    public partial class EvaluationCriterions
	{
		public static EvaluationCriterion FromReader(MySqlDataReader dataReader)
		{
			return new EvaluationCriterion
			{
				Id = (long)dataReader["id"],
				EvaluationId = (long)dataReader["evaluation_id"],
				Description = (string)dataReader["description"],
				IsCategory = (Convert.ToInt32(dataReader["is_category"]) == 1),
				GradingScaleId = (long)dataReader["grading_scale_id"],
				GradeShowing = (string)dataReader["grade_showing"],
				GradeNumber = (float)dataReader["grade_number"],
				Notes = (string)dataReader["notes"],
				SortOrder = (int)dataReader["sort_order"],
				MaxPointsAllowed = (float)dataReader["max_points_allowed"]
			};
		}

		/// <summary>
		/// Selects a single EvaluationCriterion object from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static EvaluationCriterion SelectOne(string command, params MySqlParameter[] parameters)
			=> Database.SelectOne(command, FromReader, parameters);

		/// <summary>
		/// Selects the <see cref="EvaluationCriterion"/> object with the specified key from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="EvaluationCriterion"/> to select.</param>
		public static EvaluationCriterion SelectOne(long id)
			=> SelectOne("SELECT * FROM `evaluation_criterions` WHERE `id` = " + id);

		/// <summary>
		/// Selects multiple <see cref="EvaluationCriterion"/> objects from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static IEnumerable<EvaluationCriterion> SelectMany(string command, params MySqlParameter[] parameters)
			=> Database.SelectMany(command, FromReader, parameters);

		/// <summary>
		/// Inserts the specified <see cref="EvaluationCriterion"/> into the database.
		/// </summary>
		/// <param name="evaluationCriterion">The <see cref="EvaluationCriterion"/> to insert into the database.</param>
		private static long ExecuteInsert(EvaluationCriterion evaluationCriterion)
			=> evaluationCriterion.Id = Database.ExecuteInsert(
				"INSERT INTO `evaluation_criterions` " +
				"(`evaluation_id`, `description`, `is_category`, `grading_scale_id`, `grade_showing`, `grade_number`, `notes`, `sort_order`, `max_points_allowed`) " +
				"VALUES (" +
					"@evaluation_id, @description, @is_category, @grading_scale_id, @grade_showing, @grade_number, @notes, @sort_order, @max_points_allowed" +
				")",
					new MySqlParameter("evaluation_id", evaluationCriterion.EvaluationId),
					new MySqlParameter("description", evaluationCriterion.Description ?? ""),
					new MySqlParameter("is_category", (evaluationCriterion.IsCategory ? 1 : 0)),
					new MySqlParameter("grading_scale_id", evaluationCriterion.GradingScaleId),
					new MySqlParameter("grade_showing", evaluationCriterion.GradeShowing ?? ""),
					new MySqlParameter("grade_number", evaluationCriterion.GradeNumber),
					new MySqlParameter("notes", evaluationCriterion.Notes ?? ""),
					new MySqlParameter("sort_order", evaluationCriterion.SortOrder),
					new MySqlParameter("max_points_allowed", evaluationCriterion.MaxPointsAllowed));

		/// <summary>
		/// Updates the specified <see cref="EvaluationCriterion"/> in the database.
		/// </summary>
		/// <param name="evaluationCriterion">The <see cref="EvaluationCriterion"/> to update.</param>
		private static void ExecuteUpdate(EvaluationCriterion evaluationCriterion)
			=> Database.ExecuteNonQuery(
				"UPDATE `evaluation_criterions` SET " +
					"`evaluation_id` = @evaluation_id, " +
					"`description` = @description, " +
					"`is_category` = @is_category, " +
					"`grading_scale_id` = @grading_scale_id, " +
					"`grade_showing` = @grade_showing, " +
					"`grade_number` = @grade_number, " +
					"`notes` = @notes, " +
					"`sort_order` = @sort_order, " +
					"`max_points_allowed` = @max_points_allowed " +
				"WHERE `id` = @id",
					new MySqlParameter("id", evaluationCriterion.Id),
					new MySqlParameter("evaluation_id", evaluationCriterion.EvaluationId),
					new MySqlParameter("description", evaluationCriterion.Description ?? ""),
					new MySqlParameter("is_category", (evaluationCriterion.IsCategory ? 1 : 0)),
					new MySqlParameter("grading_scale_id", evaluationCriterion.GradingScaleId),
					new MySqlParameter("grade_showing", evaluationCriterion.GradeShowing ?? ""),
					new MySqlParameter("grade_number", evaluationCriterion.GradeNumber),
					new MySqlParameter("notes", evaluationCriterion.Notes ?? ""),
					new MySqlParameter("sort_order", evaluationCriterion.SortOrder),
					new MySqlParameter("max_points_allowed", evaluationCriterion.MaxPointsAllowed));

		/// <summary>
		/// Deletes a single <see cref="EvaluationCriterion"/> object from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="EvaluationCriterion"/> to delete.</param>
		private static void ExecuteDelete(long id)
			 => Database.ExecuteNonQuery("DELETE FROM `evaluation_criterions` WHERE `id` = " + id);

		/// <summary>
		/// Deletes the specified <see cref="EvaluationCriterion"/> object from the database.
		/// </summary>
		/// <param name="evaluationCriterion">The <see cref="EvaluationCriterion"/> to delete.</param>
		private static void ExecuteDelete(EvaluationCriterion evaluationCriterion)
			=> ExecuteDelete(evaluationCriterion.Id);
	}
}