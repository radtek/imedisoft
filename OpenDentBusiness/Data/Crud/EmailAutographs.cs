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
using System.Collections.Generic;

namespace Imedisoft.Data
{
    public partial class EmailAutographs
	{
		public static EmailAutograph FromReader(MySqlDataReader dataReader)
		{
			return new EmailAutograph
			{
				Id = (long)dataReader["id"],
				Description = (string)dataReader["description"],
				Autograph = (string)dataReader["autograph"]
			};
		}

		/// <summary>
		/// Selects a single EmailAutograph object from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static EmailAutograph SelectOne(string command, params MySqlParameter[] parameters)
			=> Database.SelectOne(command, FromReader, parameters);

		/// <summary>
		/// Selects the <see cref="EmailAutograph"/> object with the specified key from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="EmailAutograph"/> to select.</param>
		public static EmailAutograph SelectOne(long id)
			=> SelectOne("SELECT * FROM `email_autographs` WHERE `id` = " + id);

		/// <summary>
		/// Selects multiple <see cref="EmailAutograph"/> objects from the database using the specified SQL command.
		/// </summary>
		/// <param name="command">The SELECT command to execute.</param>
		/// <param name="parameters">The (optional) command parameters.</param>
		public static IEnumerable<EmailAutograph> SelectMany(string command, params MySqlParameter[] parameters)
			=> Database.SelectMany(command, FromReader, parameters);

		/// <summary>
		/// Inserts the specified <see cref="EmailAutograph"/> into the database.
		/// </summary>
		/// <param name="emailAutograph">The <see cref="EmailAutograph"/> to insert into the database.</param>
		private static long ExecuteInsert(EmailAutograph emailAutograph)
			=> emailAutograph.Id = Database.ExecuteInsert(
				"INSERT INTO `email_autographs` " +
				"(`description`, `autograph`) " +
				"VALUES (" +
					"@description, @autograph" +
				")",
					new MySqlParameter("description", emailAutograph.Description ?? ""),
					new MySqlParameter("autograph", emailAutograph.Autograph ?? ""));

		/// <summary>
		/// Updates the specified <see cref="EmailAutograph"/> in the database.
		/// </summary>
		/// <param name="emailAutograph">The <see cref="EmailAutograph"/> to update.</param>
		private static void ExecuteUpdate(EmailAutograph emailAutograph)
			=> Database.ExecuteNonQuery(
				"UPDATE `email_autographs` SET " +
					"`description` = @description, " +
					"`autograph` = @autograph " +
				"WHERE `id` = @id",
					new MySqlParameter("id", emailAutograph.Id),
					new MySqlParameter("description", emailAutograph.Description ?? ""),
					new MySqlParameter("autograph", emailAutograph.Autograph ?? ""));

		/// <summary>
		/// Deletes a single <see cref="EmailAutograph"/> object from the database.
		/// </summary>
		/// <param name="id">The primary key of the <see cref="EmailAutograph"/> to delete.</param>
		private static void ExecuteDelete(long id)
			 => Database.ExecuteNonQuery("DELETE FROM `email_autographs` WHERE `id` = " + id);

		/// <summary>
		/// Deletes the specified <see cref="EmailAutograph"/> object from the database.
		/// </summary>
		/// <param name="emailAutograph">The <see cref="EmailAutograph"/> to delete.</param>
		private static void ExecuteDelete(EmailAutograph emailAutograph)
			=> ExecuteDelete(emailAutograph.Id);
	}
}