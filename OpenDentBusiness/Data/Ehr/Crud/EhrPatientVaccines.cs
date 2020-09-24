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
    public partial class EhrPatientVaccines
	{
		public static EhrPatientVaccine FromReader(MySqlDataReader dataReader)
		{
			return new EhrPatientVaccine
			{
				Id = (long)dataReader["id"],
				VaccineId = dataReader["vaccine_id"] as long?,
				DateStart = dataReader["date_start"] as DateTime?,
				DateEnd = dataReader["date_end"] as DateTime?,
				AdministeredAmount = (float)dataReader["administered_amount"],
				DrugUnitCode = dataReader["drug_unit_code"] as string,
				LotNumber = (string)dataReader["lot_number"],
				PatientId = (long)dataReader["patient_id"],
				Note = (string)dataReader["note"],
				FilledCity = (string)dataReader["filled_city"],
				FilledState = (string)dataReader["filled_state"],
				CompletionStatus = (string)dataReader["completion_status"],
				InformationSource = (string)dataReader["information_source"],
				UserId = (long)dataReader["user_id"],
				OrderedBy = dataReader["ordered_by"] as long?,
				AdministeredBy = dataReader["administered_by"] as long?,
				ExpirationDate = dataReader["expiration_date"] as DateTime?,
				RefusalReason = dataReader["refusal_reason"] as string,
				ActionCode = Convert.ToChar(dataReader["action_code"]),
				AdministrationRoute = dataReader["administration_route"] as string,
				AdministrationSite = dataReader["administration_site"] as string
			};
		}

		/// <summary>
		/// Selects a single EhrPatientVaccine object from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static EhrPatientVaccine SelectOne(string command, params MySqlParameter[] parameters)
			=> Database.SelectOne(command, FromReader, parameters);

		/// <summary>
		/// Selects the <see cref="EhrPatientVaccine"/> object with the specified key from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="EhrPatientVaccine"/> to select.</param>
		public static EhrPatientVaccine SelectOne(long id)
			=> SelectOne("SELECT * FROM `ehr_patient_vaccines` WHERE `id` = " + id);

		/// <summary>
		/// Selects multiple <see cref="EhrPatientVaccine"/> objects from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static IEnumerable<EhrPatientVaccine> SelectMany(string command, params MySqlParameter[] parameters)
			=> Database.SelectMany(command, FromReader, parameters);

		/// <summary>
		/// Inserts the specified <see cref="EhrPatientVaccine"/> into the database.
		/// </summary>
		/// <param name="ehrPatientVaccine">The <see cref="EhrPatientVaccine"/> to insert into the database.</param>
		private static long ExecuteInsert(EhrPatientVaccine ehrPatientVaccine)
			=> ehrPatientVaccine.Id = Database.ExecuteInsert(
				"INSERT INTO `ehr_patient_vaccines` " +
				"(`vaccine_id`, `date_start`, `date_end`, `administered_amount`, `drug_unit_code`, `lot_number`, `patient_id`, `note`, `filled_city`, `filled_state`, `completion_status`, `information_source`, `user_id`, `ordered_by`, `administered_by`, `expiration_date`, `refusal_reason`, `action_code`, `administration_route`, `administration_site`) " +
				"VALUES (" +
					"@vaccine_id, @date_start, @date_end, @administered_amount, @drug_unit_code, @lot_number, @patient_id, @note, @filled_city, @filled_state, @completion_status, @information_source, @user_id, @ordered_by, @administered_by, @expiration_date, @refusal_reason, @action_code, @administration_route, @administration_site" +
				")",
					new MySqlParameter("vaccine_id", (ehrPatientVaccine.VaccineId.HasValue ? (object)ehrPatientVaccine.VaccineId.Value : DBNull.Value)),
					new MySqlParameter("date_start", (ehrPatientVaccine.DateStart.HasValue ? (object)ehrPatientVaccine.DateStart.Value : DBNull.Value)),
					new MySqlParameter("date_end", (ehrPatientVaccine.DateEnd.HasValue ? (object)ehrPatientVaccine.DateEnd.Value : DBNull.Value)),
					new MySqlParameter("administered_amount", ehrPatientVaccine.AdministeredAmount),
					new MySqlParameter("drug_unit_code", (object)ehrPatientVaccine.DrugUnitCode ?? DBNull.Value),
					new MySqlParameter("lot_number", ehrPatientVaccine.LotNumber ?? ""),
					new MySqlParameter("patient_id", ehrPatientVaccine.PatientId),
					new MySqlParameter("note", ehrPatientVaccine.Note ?? ""),
					new MySqlParameter("filled_city", ehrPatientVaccine.FilledCity ?? ""),
					new MySqlParameter("filled_state", ehrPatientVaccine.FilledState ?? ""),
					new MySqlParameter("completion_status", ehrPatientVaccine.CompletionStatus ?? ""),
					new MySqlParameter("information_source", ehrPatientVaccine.InformationSource ?? ""),
					new MySqlParameter("user_id", ehrPatientVaccine.UserId),
					new MySqlParameter("ordered_by", (ehrPatientVaccine.OrderedBy.HasValue ? (object)ehrPatientVaccine.OrderedBy.Value : DBNull.Value)),
					new MySqlParameter("administered_by", (ehrPatientVaccine.AdministeredBy.HasValue ? (object)ehrPatientVaccine.AdministeredBy.Value : DBNull.Value)),
					new MySqlParameter("expiration_date", (ehrPatientVaccine.ExpirationDate.HasValue ? (object)ehrPatientVaccine.ExpirationDate.Value : DBNull.Value)),
					new MySqlParameter("refusal_reason", (object)ehrPatientVaccine.RefusalReason ?? DBNull.Value),
					new MySqlParameter("action_code", ehrPatientVaccine.ActionCode),
					new MySqlParameter("administration_route", (object)ehrPatientVaccine.AdministrationRoute ?? DBNull.Value),
					new MySqlParameter("administration_site", (object)ehrPatientVaccine.AdministrationSite ?? DBNull.Value));

		/// <summary>
		/// Updates the specified <see cref="EhrPatientVaccine"/> in the database.
		/// </summary>
		/// <param name="ehrPatientVaccine">The <see cref="EhrPatientVaccine"/> to update.</param>
		private static void ExecuteUpdate(EhrPatientVaccine ehrPatientVaccine)
			=> Database.ExecuteNonQuery(
				"UPDATE `ehr_patient_vaccines` SET " +
					"`vaccine_id` = @vaccine_id, " +
					"`date_start` = @date_start, " +
					"`date_end` = @date_end, " +
					"`administered_amount` = @administered_amount, " +
					"`drug_unit_code` = @drug_unit_code, " +
					"`lot_number` = @lot_number, " +
					"`patient_id` = @patient_id, " +
					"`note` = @note, " +
					"`filled_city` = @filled_city, " +
					"`filled_state` = @filled_state, " +
					"`completion_status` = @completion_status, " +
					"`information_source` = @information_source, " +
					"`user_id` = @user_id, " +
					"`ordered_by` = @ordered_by, " +
					"`administered_by` = @administered_by, " +
					"`expiration_date` = @expiration_date, " +
					"`refusal_reason` = @refusal_reason, " +
					"`action_code` = @action_code, " +
					"`administration_route` = @administration_route, " +
					"`administration_site` = @administration_site " +
				"WHERE `id` = @id",
					new MySqlParameter("id", ehrPatientVaccine.Id),
					new MySqlParameter("vaccine_id", (ehrPatientVaccine.VaccineId.HasValue ? (object)ehrPatientVaccine.VaccineId.Value : DBNull.Value)),
					new MySqlParameter("date_start", (ehrPatientVaccine.DateStart.HasValue ? (object)ehrPatientVaccine.DateStart.Value : DBNull.Value)),
					new MySqlParameter("date_end", (ehrPatientVaccine.DateEnd.HasValue ? (object)ehrPatientVaccine.DateEnd.Value : DBNull.Value)),
					new MySqlParameter("administered_amount", ehrPatientVaccine.AdministeredAmount),
					new MySqlParameter("drug_unit_code", (object)ehrPatientVaccine.DrugUnitCode ?? DBNull.Value),
					new MySqlParameter("lot_number", ehrPatientVaccine.LotNumber ?? ""),
					new MySqlParameter("patient_id", ehrPatientVaccine.PatientId),
					new MySqlParameter("note", ehrPatientVaccine.Note ?? ""),
					new MySqlParameter("filled_city", ehrPatientVaccine.FilledCity ?? ""),
					new MySqlParameter("filled_state", ehrPatientVaccine.FilledState ?? ""),
					new MySqlParameter("completion_status", ehrPatientVaccine.CompletionStatus ?? ""),
					new MySqlParameter("information_source", ehrPatientVaccine.InformationSource ?? ""),
					new MySqlParameter("user_id", ehrPatientVaccine.UserId),
					new MySqlParameter("ordered_by", (ehrPatientVaccine.OrderedBy.HasValue ? (object)ehrPatientVaccine.OrderedBy.Value : DBNull.Value)),
					new MySqlParameter("administered_by", (ehrPatientVaccine.AdministeredBy.HasValue ? (object)ehrPatientVaccine.AdministeredBy.Value : DBNull.Value)),
					new MySqlParameter("expiration_date", (ehrPatientVaccine.ExpirationDate.HasValue ? (object)ehrPatientVaccine.ExpirationDate.Value : DBNull.Value)),
					new MySqlParameter("refusal_reason", (object)ehrPatientVaccine.RefusalReason ?? DBNull.Value),
					new MySqlParameter("action_code", ehrPatientVaccine.ActionCode),
					new MySqlParameter("administration_route", (object)ehrPatientVaccine.AdministrationRoute ?? DBNull.Value),
					new MySqlParameter("administration_site", (object)ehrPatientVaccine.AdministrationSite ?? DBNull.Value));

		/// <summary>
		/// Deletes a single <see cref="EhrPatientVaccine"/> object from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="EhrPatientVaccine"/> to delete.</param>
		private static void ExecuteDelete(long id)
			 => Database.ExecuteNonQuery("DELETE FROM `ehr_patient_vaccines` WHERE `id` = " + id);

		/// <summary>
		/// Deletes the specified <see cref="EhrPatientVaccine"/> object from the database.
		/// </summary>
		/// <param name="ehrPatientVaccine">The <see cref="EhrPatientVaccine"/> to delete.</param>
		private static void ExecuteDelete(EhrPatientVaccine ehrPatientVaccine)
			=> ExecuteDelete(ehrPatientVaccine.Id);
	}
}