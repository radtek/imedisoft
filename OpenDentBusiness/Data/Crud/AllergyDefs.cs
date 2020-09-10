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
	public partial class AllergyDefs
	{
		public static AllergyDef FromReader(MySqlDataReader dataReader)
		{
			return new AllergyDef
			{
				Id = (long)dataReader["id"],
				Description = (string)dataReader["description"],
				IsHidden = (Convert.ToInt32(dataReader["is_hidden"]) == 1),
				LastModifiedDate = (DateTime)dataReader["last_modified_date"],
				SnomedCode = dataReader["snomed_code"] as string,
				MedicationId = dataReader["medication_id"] as long?,
				UniiCode = (string)dataReader["unii_code"]
			};
		}

		/// <summary>
		/// Selects a single AllergyDef object from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static AllergyDef SelectOne(string command, params MySqlParameter[] parameters)
			=> Database.SelectOne(command, FromReader, parameters);

		/// <summary>
		/// Selects the <see cref="AllergyDef"/> object with the specified key from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="AllergyDef"/> to select.</param>
		public static AllergyDef SelectOne(long id)
			=> SelectOne("SELECT * FROM `allergy_defs` WHERE `id` = " + id);

		/// <summary>
		/// Selects multiple <see cref="AllergyDef"/> objects from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static IEnumerable<AllergyDef> SelectMany(string command, params MySqlParameter[] parameters)
			=> Database.SelectMany(command, FromReader, parameters);

		/// <summary>
		/// Inserts the specified <see cref="AllergyDef"/> into the database.
		/// </summary>
		/// <param name="allergyDef">The <see cref="AllergyDef"/> to insert into the database.</param>
		private static long ExecuteInsert(AllergyDef allergyDef)
			=> allergyDef.Id = Database.ExecuteInsert(
				"INSERT INTO `allergy_defs` " +
				"(`description`, `is_hidden`, `last_modified_date`, `snomed_code`, `medication_id`, `unii_code`) " +
				"VALUES (" +
					"@description, @is_hidden, @last_modified_date, @snomed_code, @medication_id, @unii_code" +
				")",
					new MySqlParameter("description", allergyDef.Description ?? ""),
					new MySqlParameter("is_hidden", (allergyDef.IsHidden ? 1 : 0)),
					new MySqlParameter("last_modified_date", allergyDef.LastModifiedDate),
					new MySqlParameter("snomed_code", (object)allergyDef.SnomedCode ?? DBNull.Value),
					new MySqlParameter("medication_id", (allergyDef.MedicationId.HasValue ? (object)allergyDef.MedicationId.Value : DBNull.Value)),
					new MySqlParameter("unii_code", allergyDef.UniiCode ?? ""));

		/// <summary>
		/// Updates the specified <see cref="AllergyDef"/> in the database.
		/// </summary>
		/// <param name="allergyDef">The <see cref="AllergyDef"/> to update.</param>
		private static void ExecuteUpdate(AllergyDef allergyDef)
			=> Database.ExecuteNonQuery(
				"UPDATE `allergy_defs` SET " +
					"`description` = @description, " +
					"`is_hidden` = @is_hidden, " +
					"`last_modified_date` = @last_modified_date, " +
					"`snomed_code` = @snomed_code, " +
					"`medication_id` = @medication_id, " +
					"`unii_code` = @unii_code " +
				"WHERE `id` = @id",
					new MySqlParameter("id", allergyDef.Id),
					new MySqlParameter("description", allergyDef.Description ?? ""),
					new MySqlParameter("is_hidden", (allergyDef.IsHidden ? 1 : 0)),
					new MySqlParameter("last_modified_date", allergyDef.LastModifiedDate),
					new MySqlParameter("snomed_code", (object)allergyDef.SnomedCode ?? DBNull.Value),
					new MySqlParameter("medication_id", (allergyDef.MedicationId.HasValue ? (object)allergyDef.MedicationId.Value : DBNull.Value)),
					new MySqlParameter("unii_code", allergyDef.UniiCode ?? ""));

		/// <summary>
		/// Deletes a single <see cref="AllergyDef"/> object from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="AllergyDef"/> to delete.</param>
		private static void ExecuteDelete(long id)
			 => Database.ExecuteNonQuery("DELETE FROM `allergy_defs` WHERE `id` = " + id);

		/// <summary>
		/// Deletes the specified <see cref="AllergyDef"/> object from the database.
		/// </summary>
		/// <param name="allergyDef">The <see cref="AllergyDef"/> to delete.</param>
		private static void ExecuteDelete(AllergyDef allergyDef)
			=> ExecuteDelete(allergyDef.Id);
	}
}
