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

namespace OpenDentBusiness.Crud
{
	public class AutoCodeCrud
	{
		public static AutoCode FromReader(MySqlDataReader dataReader)
		{
			return new AutoCode
			{
				AutoCodeNum = (long)dataReader["AutoCodeNum"],
				Description = (string)dataReader["Description"],
				IsHidden = (Convert.ToInt32(dataReader["IsHidden"]) == 1),
				LessIntrusive = (Convert.ToInt32(dataReader["LessIntrusive"]) == 1)
			};
		}

		/// <summary>
		/// Selects a single AutoCode object from the database using the specified SQL command.
		/// </summary>
		public static AutoCode SelectOne(string command)
			=> Database.SelectOne(command, FromReader);

		/// <summary>
		/// Selects a single <see cref="AutoCode"/> object from the database using the specified SQL command.
		/// </summary>
		public static AutoCode SelectOne(Int64 autoCodeNum)
			=> SelectOne("SELECT * FROM `AutoCode` WHERE `AutoCodeNum` = " + autoCodeNum);

		/// <summary>
		/// Selects multiple <see cref="AutoCode"/> objects from the database using the specified SQL command.
		/// </summary>
		public static IEnumerable<AutoCode> SelectMany(string command)
			=> Database.SelectMany(command, FromReader);

		/// <summary>
		/// Inserts the specified <see cref="AutoCode"/> into the database.
		/// </summary>
		public static long Insert(AutoCode autoCode)
			=> autoCode.AutoCodeNum = Database.ExecuteInsert(
				"INSERT INTO `AutoCode` " + 
				"(`Description`, `IsHidden`, `LessIntrusive`) " + 
				"VALUES (" + 
					"@Description, @IsHidden, @LessIntrusive" + 
				")");

		/// <summary>
		/// Updates the specified <see cref="AutoCode"/> in the database.
		/// </summary>
		public static void Update(AutoCode autoCode)
			=> Database.ExecuteNonQuery(
				"UPDATE `AutoCode` SET " + 
					"`Description` = @Description, " + 
					"`IsHidden` = @IsHidden, " + 
					"`LessIntrusive` = @LessIntrusive " + 
				"WHERE `AutoCodeNum` = @AutoCodeNum",
					new MySqlParameter("AutoCodeNum", autoCode.AutoCodeNum),
					new MySqlParameter("Description", autoCode.Description ?? ""),
					new MySqlParameter("IsHidden", (autoCode.IsHidden ? 1 : 0)),
					new MySqlParameter("LessIntrusive", (autoCode.LessIntrusive ? 1 : 0)));

		/// <summary>
		/// Updates the specified <see cref="AutoCode"/> in the database.
		/// </summary>
		public static void Update(AutoCode autoCodeNew, AutoCode autoCodeOld)
		{
			var updates = new List<string>();
			var parameters = new List<MySqlParameter>();

			if (autoCodeNew.Description != autoCodeOld.Description)
			{
				updates.Add("`Description` = @Description");
				parameters.Add(new MySqlParameter("Description", autoCodeNew.Description ?? ""));
			}

			if (autoCodeNew.IsHidden != autoCodeOld.IsHidden)
			{
				updates.Add("`IsHidden` = @IsHidden");
				parameters.Add(new MySqlParameter("IsHidden", (autoCodeNew.IsHidden ? 1 : 0)));
			}

			if (autoCodeNew.LessIntrusive != autoCodeOld.LessIntrusive)
			{
				updates.Add("`LessIntrusive` = @LessIntrusive");
				parameters.Add(new MySqlParameter("LessIntrusive", (autoCodeNew.LessIntrusive ? 1 : 0)));
			}

			if (updates.Count == 0) return;

			parameters.Add(new MySqlParameter("AutoCodeNum", autoCodeNew.AutoCodeNum));

			Database.ExecuteNonQuery("UPDATE `AutoCode` " + 
				"SET " + string.Join(", ", updates) + " " + 
				"WHERE `AutoCodeNum` = @AutoCodeNum",
					parameters.ToArray());
		}

		/// <summary>
		/// Deletes a single <see cref="AutoCode"/> object from the database.
		/// </summary>
		public static void Delete(Int64 autoCodeNum)
			 => Database.ExecuteNonQuery("DELETE FROM `AutoCode` WHERE `AutoCodeNum` = " + autoCodeNum);

		/// <summary>
		/// Deletes the specified <see cref="AutoCode"/> object from the database.
		/// </summary>
		public static void Delete(AutoCode autoCode)
			=> Delete(autoCode.AutoCodeNum);
	}
}
