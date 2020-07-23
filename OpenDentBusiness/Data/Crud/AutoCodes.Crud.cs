//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: v4.0.30319
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Imedisoft.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;

namespace OpenDentBusiness
{
	public partial class AutoCodes
	{
		public static AutoCode FromReader(MySqlDataReader dataReader)
		{
			return new AutoCode
			{
				Id = (long)dataReader["id"],
				Description = (string)dataReader["description"],
				IsHidden = (Convert.ToInt32(dataReader["is_hidden"]) == 1),
				LessIntrusive = (Convert.ToInt32(dataReader["less_intrusive"]) == 1)
			};
		}

		/// <summary>
		/// Selects a single AutoCode object from the database using the specified SQL command.
		/// </summary>
		public static AutoCode SelectOne(string command, params MySqlParameter[] parameters)
			=> Database.SelectOne(command, FromReader, parameters);

		/// <summary>
		/// Selects the <see cref="AutoCode"/> object with the specified key from the database.
		/// </summary>
		public static AutoCode SelectOne(Int64 id)
			=> SelectOne("SELECT * FROM `auto_codes` WHERE `id` = " + id);

		/// <summary>
		/// Selects multiple <see cref="AutoCode"/> objects from the database using the specified SQL command.
		/// </summary>
		public static IEnumerable<AutoCode> SelectMany(string command, params MySqlParameter[] parameters)
			=> Database.SelectMany(command, FromReader, parameters);

		/// <summary>
		/// Inserts the specified <see cref="AutoCode"/> into the database.
		/// </summary>
		public static long Insert(AutoCode autoCode)
			=> autoCode.Id = Database.ExecuteInsert(
				"INSERT INTO `auto_codes` " +
				"(`description`, `is_hidden`, `less_intrusive`) " +
				"VALUES (" +
					"@description, @is_hidden, @less_intrusive" +
				")");

		/// <summary>
		/// Updates the specified <see cref="AutoCode"/> in the database.
		/// </summary>
		public static void Update(AutoCode autoCode)
			=> Database.ExecuteNonQuery(
				"UPDATE `auto_codes` SET " +
					"`description` = @description, " +
					"`is_hidden` = @is_hidden, " +
					"`less_intrusive` = @less_intrusive " +
				"WHERE `id` = @id",
					new MySqlParameter("id", autoCode.Id),
					new MySqlParameter("description", autoCode.Description ?? ""),
					new MySqlParameter("is_hidden", (autoCode.IsHidden ? 1 : 0)),
					new MySqlParameter("less_intrusive", (autoCode.LessIntrusive ? 1 : 0)));

		/// <summary>
		/// Updates the specified <see cref="AutoCode"/> in the database.
		/// </summary>
		public static bool Update(AutoCode auto_codesNew, AutoCode auto_codesOld)
		{
			var updates = new List<string>();
			var parameters = new List<MySqlParameter>();

			if (auto_codesNew.Description != auto_codesOld.Description)
			{
				updates.Add("`description` = @description");
				parameters.Add(new MySqlParameter("description", auto_codesNew.Description ?? ""));
			}

			if (auto_codesNew.IsHidden != auto_codesOld.IsHidden)
			{
				updates.Add("`is_hidden` = @is_hidden");
				parameters.Add(new MySqlParameter("is_hidden", (auto_codesNew.IsHidden ? 1 : 0)));
			}

			if (auto_codesNew.LessIntrusive != auto_codesOld.LessIntrusive)
			{
				updates.Add("`less_intrusive` = @less_intrusive");
				parameters.Add(new MySqlParameter("less_intrusive", (auto_codesNew.LessIntrusive ? 1 : 0)));
			}

			if (updates.Count == 0) return false;

			parameters.Add(new MySqlParameter("id", auto_codesNew.Id));

			Database.ExecuteNonQuery("UPDATE `auto_codes` " +
				"SET " + string.Join(", ", updates) + " " +
				"WHERE `id` = @id",
					parameters.ToArray());

			return true;
		}

		/// <summary>
		/// Deletes a single <see cref="AutoCode"/> object from the database.
		/// </summary>
		public static void Delete(Int64 id)
			 => Database.ExecuteNonQuery("DELETE FROM `auto_codes` WHERE `id` = " + id);

		/// <summary>
		/// Deletes the specified <see cref="AutoCode"/> object from the database.
		/// </summary>
		public static void Delete(AutoCode autoCode)
			=> Delete(autoCode.Id);
	}
}