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
	public partial class ProblemDefinitions
	{
		public static ProblemDefinition FromReader(MySqlDataReader dataReader)
		{
			return new ProblemDefinition
			{
				Id = (long)dataReader["id"],
				Description = (string)dataReader["description"],
				CodeIcd9 = (string)dataReader["code_icd9"],
				CodeIcd10 = (string)dataReader["code_icd10"],
				CodeSnomed = (string)dataReader["code_snomed"],
				IsHidden = (Convert.ToInt32(dataReader["is_hidden"]) == 1),
				LastModifiedDate = (DateTime)dataReader["last_modified_date"]
			};
		}

		/// <summary>
		/// Selects a single DiseaseDef object from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static ProblemDefinition SelectOne(string command, params MySqlParameter[] parameters)
			=> Database.SelectOne(command, FromReader, parameters);

		/// <summary>
		/// Selects the <see cref="ProblemDefinition"/> object with the specified key from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="ProblemDefinition"/> to select.</param>
		public static ProblemDefinition SelectOne(long id)
			=> SelectOne("SELECT * FROM `problem_definitions` WHERE `id` = " + id);

		/// <summary>
		/// Selects multiple <see cref="ProblemDefinition"/> objects from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static IEnumerable<ProblemDefinition> SelectMany(string command, params MySqlParameter[] parameters)
			=> Database.SelectMany(command, FromReader, parameters);

		/// <summary>
		/// Inserts the specified <see cref="ProblemDefinition"/> into the database.
		/// </summary>
		/// <param name="diseaseDef">The <see cref="ProblemDefinition"/> to insert into the database.</param>
		private static long ExecuteInsert(ProblemDefinition diseaseDef)
			=> diseaseDef.Id = Database.ExecuteInsert(
				"INSERT INTO `problem_definitions` " +
				"(`description`, `code_icd9`, `code_icd10`, `code_snomed`, `is_hidden`) " +
				"VALUES (" +
					"@description, @code_icd9, @code_icd10, @code_snomed, @is_hidden" +
				")",
					new MySqlParameter("description", diseaseDef.Description ?? ""),
					new MySqlParameter("code_icd9", diseaseDef.CodeIcd9 ?? ""),
					new MySqlParameter("code_icd10", diseaseDef.CodeIcd10 ?? ""),
					new MySqlParameter("code_snomed", diseaseDef.CodeSnomed ?? ""),
					new MySqlParameter("is_hidden", (diseaseDef.IsHidden ? 1 : 0)),
					new MySqlParameter("last_modified_date", diseaseDef.LastModifiedDate));

		/// <summary>
		/// Updates the specified <see cref="ProblemDefinition"/> in the database.
		/// </summary>
		/// <param name="diseaseDef">The <see cref="ProblemDefinition"/> to update.</param>
		private static void ExecuteUpdate(ProblemDefinition diseaseDef)
			=> Database.ExecuteNonQuery(
				"UPDATE `problem_definitions` SET " +
					"`description` = @description, " +
					"`code_icd9` = @code_icd9, " +
					"`code_icd10` = @code_icd10, " +
					"`code_snomed` = @code_snomed, " +
					"`is_hidden` = @is_hidden " +
				"WHERE `id` = @id",
					new MySqlParameter("id", diseaseDef.Id),
					new MySqlParameter("description", diseaseDef.Description ?? ""),
					new MySqlParameter("code_icd9", diseaseDef.CodeIcd9 ?? ""),
					new MySqlParameter("code_icd10", diseaseDef.CodeIcd10 ?? ""),
					new MySqlParameter("code_snomed", diseaseDef.CodeSnomed ?? ""),
					new MySqlParameter("is_hidden", (diseaseDef.IsHidden ? 1 : 0)),
					new MySqlParameter("last_modified_date", diseaseDef.LastModifiedDate));

		/// <summary>
		/// Deletes a single <see cref="ProblemDefinition"/> object from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="ProblemDefinition"/> to delete.</param>
		private static void ExecuteDelete(long id)
			 => Database.ExecuteNonQuery("DELETE FROM `problem_definitions` WHERE `id` = " + id);

		/// <summary>
		/// Deletes the specified <see cref="ProblemDefinition"/> object from the database.
		/// </summary>
		/// <param name="diseaseDef">The <see cref="ProblemDefinition"/> to delete.</param>
		private static void ExecuteDelete(ProblemDefinition diseaseDef)
			=> ExecuteDelete(diseaseDef.Id);
	}
}
