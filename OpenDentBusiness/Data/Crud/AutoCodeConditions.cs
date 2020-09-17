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
	public partial class AutoCodeConditions
	{
		public static AutoCodeCondition FromReader(MySqlDataReader dataReader)
		{
			return new AutoCodeCondition
			{
				Id = (long)dataReader["id"],
				AutoCodeItemId = (long)dataReader["auto_code_item_id"],
				Type = (AutoCodeConditionType)Convert.ToInt32(dataReader["type"])
			};
		}

		/// <summary>
		/// Selects a single AutoCodeCondition object from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static AutoCodeCondition SelectOne(string command, params MySqlParameter[] parameters)
			=> Database.SelectOne(command, FromReader, parameters);

		/// <summary>
		/// Selects the <see cref="AutoCodeCondition"/> object with the specified key from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="AutoCodeCondition"/> to select.</param>
		public static AutoCodeCondition SelectOne(long id)
			=> SelectOne("SELECT * FROM `auto_code_conditions` WHERE `id` = " + id);

		/// <summary>
		/// Selects multiple <see cref="AutoCodeCondition"/> objects from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static IEnumerable<AutoCodeCondition> SelectMany(string command, params MySqlParameter[] parameters)
			=> Database.SelectMany(command, FromReader, parameters);

		/// <summary>
		/// Inserts the specified <see cref="AutoCodeCondition"/> into the database.
		/// </summary>
		/// <param name="autoCodeCondition">The <see cref="AutoCodeCondition"/> to insert into the database.</param>
		private static long ExecuteInsert(AutoCodeCondition autoCodeCondition)
			=> autoCodeCondition.Id = Database.ExecuteInsert(
				"INSERT INTO `auto_code_conditions` " +
				"(`auto_code_item_id`, `type`) " +
				"VALUES (" +
					"@auto_code_item_id, @type" +
				")",
					new MySqlParameter("auto_code_item_id", autoCodeCondition.AutoCodeItemId),
					new MySqlParameter("type", (int)autoCodeCondition.Type));

		/// <summary>
		/// Updates the specified <see cref="AutoCodeCondition"/> in the database.
		/// </summary>
		/// <param name="autoCodeCondition">The <see cref="AutoCodeCondition"/> to update.</param>
		private static void ExecuteUpdate(AutoCodeCondition autoCodeCondition)
			=> Database.ExecuteNonQuery(
				"UPDATE `auto_code_conditions` SET " +
					"`auto_code_item_id` = @auto_code_item_id, " +
					"`type` = @type " +
				"WHERE `id` = @id",
					new MySqlParameter("id", autoCodeCondition.Id),
					new MySqlParameter("auto_code_item_id", autoCodeCondition.AutoCodeItemId),
					new MySqlParameter("type", (int)autoCodeCondition.Type));

		/// <summary>
		/// Deletes a single <see cref="AutoCodeCondition"/> object from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="AutoCodeCondition"/> to delete.</param>
		private static void ExecuteDelete(long id)
			 => Database.ExecuteNonQuery("DELETE FROM `auto_code_conditions` WHERE `id` = " + id);

		/// <summary>
		/// Deletes the specified <see cref="AutoCodeCondition"/> object from the database.
		/// </summary>
		/// <param name="autoCodeCondition">The <see cref="AutoCodeCondition"/> to delete.</param>
		private static void ExecuteDelete(AutoCodeCondition autoCodeCondition)
			=> ExecuteDelete(autoCodeCondition.Id);
	}
}