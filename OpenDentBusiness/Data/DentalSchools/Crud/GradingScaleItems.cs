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
	public partial class GradingScaleItems
	{
		public static GradingScaleItem FromReader(MySqlDataReader dataReader)
		{
			return new GradingScaleItem
			{
				Id = (long)dataReader["id"],
				GradingScaleId = (long)dataReader["grading_scale_id"],
				Text = (string)dataReader["text"],
				Value = (float)dataReader["value"],
				Description = (string)dataReader["description"]
			};
		}

		/// <summary>
		/// Selects a single GradingScaleItem object from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static GradingScaleItem SelectOne(string command, params MySqlParameter[] parameters)
			=> Database.SelectOne(command, FromReader, parameters);

		/// <summary>
		/// Selects the <see cref="GradingScaleItem"/> object with the specified key from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="GradingScaleItem"/> to select.</param>
		public static GradingScaleItem SelectOne(long id)
			=> SelectOne("SELECT * FROM `grading_scale_items` WHERE `id` = " + id);

		/// <summary>
		/// Selects multiple <see cref="GradingScaleItem"/> objects from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static IEnumerable<GradingScaleItem> SelectMany(string command, params MySqlParameter[] parameters)
			=> Database.SelectMany(command, FromReader, parameters);

		/// <summary>
		/// Inserts the specified <see cref="GradingScaleItem"/> into the database.
		/// </summary>
		/// <param name="gradingScaleItem">The <see cref="GradingScaleItem"/> to insert into the database.</param>
		private static long ExecuteInsert(GradingScaleItem gradingScaleItem)
			=> gradingScaleItem.Id = Database.ExecuteInsert(
				"INSERT INTO `grading_scale_items` " +
				"(`grading_scale_id`, `text`, `value`, `description`) " +
				"VALUES (" +
					"@grading_scale_id, @text, @value, @description" +
				")",
					new MySqlParameter("grading_scale_id", gradingScaleItem.GradingScaleId),
					new MySqlParameter("text", gradingScaleItem.Text ?? ""),
					new MySqlParameter("value", gradingScaleItem.Value),
					new MySqlParameter("description", gradingScaleItem.Description ?? ""));

		/// <summary>
		/// Updates the specified <see cref="GradingScaleItem"/> in the database.
		/// </summary>
		/// <param name="gradingScaleItem">The <see cref="GradingScaleItem"/> to update.</param>
		private static void ExecuteUpdate(GradingScaleItem gradingScaleItem)
			=> Database.ExecuteNonQuery(
				"UPDATE `grading_scale_items` SET " +
					"`grading_scale_id` = @grading_scale_id, " +
					"`text` = @text, " +
					"`value` = @value, " +
					"`description` = @description " +
				"WHERE `id` = @id",
					new MySqlParameter("id", gradingScaleItem.Id),
					new MySqlParameter("grading_scale_id", gradingScaleItem.GradingScaleId),
					new MySqlParameter("text", gradingScaleItem.Text ?? ""),
					new MySqlParameter("value", gradingScaleItem.Value),
					new MySqlParameter("description", gradingScaleItem.Description ?? ""));

		/// <summary>
		/// Deletes a single <see cref="GradingScaleItem"/> object from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="GradingScaleItem"/> to delete.</param>
		private static void ExecuteDelete(long id)
			 => Database.ExecuteNonQuery("DELETE FROM `grading_scale_items` WHERE `id` = " + id);

		/// <summary>
		/// Deletes the specified <see cref="GradingScaleItem"/> object from the database.
		/// </summary>
		/// <param name="gradingScaleItem">The <see cref="GradingScaleItem"/> to delete.</param>
		private static void ExecuteDelete(GradingScaleItem gradingScaleItem)
			=> ExecuteDelete(gradingScaleItem.Id);
	}
}
