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
	public class UserodCrud
	{
		public static Userod FromReader(MySqlDataReader dataReader)
		{
			return new Userod
			{
				Id = (long)dataReader["UserNum"],
				UserName = (string)dataReader["UserName"],
				Password = (string)dataReader["Password"],
				UserGroupNum = (long)dataReader["UserGroupNum"],
				EmployeeNum = (long)dataReader["EmployeeNum"],
				ClinicNum = (long)dataReader["ClinicNum"],
				ProvNum = (long)dataReader["ProvNum"],
				IsHidden = (Convert.ToInt32(dataReader["IsHidden"]) == 1),
				TaskListInBox = (long)dataReader["TaskListInBox"],
				AnesthProvType = (int)dataReader["AnesthProvType"],
				DefaultHidePopups = (Convert.ToInt32(dataReader["DefaultHidePopups"]) == 1),
				PasswordIsStrong = (Convert.ToInt32(dataReader["PasswordIsStrong"]) == 1),
				ClinicIsRestricted = (Convert.ToInt32(dataReader["ClinicIsRestricted"]) == 1),
				InboxHidePopups = (Convert.ToInt32(dataReader["InboxHidePopups"]) == 1),
				UserNumCEMT = (long)dataReader["UserNumCEMT"],
				DateTFail = (DateTime)dataReader["DateTFail"],
				FailedAttempts = (byte)dataReader["FailedAttempts"],
				DomainUser = (string)dataReader["DomainUser"],
				IsPasswordResetRequired = (Convert.ToInt32(dataReader["IsPasswordResetRequired"]) == 1),
				MobileWebPin = (string)dataReader["MobileWebPin"],
				MobileWebPinFailedAttempts = (byte)dataReader["MobileWebPinFailedAttempts"],
				DateTLastLogin = (DateTime)dataReader["DateTLastLogin"]
			};
		}

		/// <summary>
		/// Selects a single Userod object from the database using the specified SQL command.
		/// </summary>
		public static Userod SelectOne(string command)
			=> Database.SelectOne(command, FromReader);

		/// <summary>
		/// Selects a single <see cref="Userod"/> object from the database using the specified SQL command.
		/// </summary>
		public static Userod SelectOne(Int64 userNum)
			=> SelectOne("SELECT * FROM `Userod` WHERE `UserNum` = " + userNum);

		/// <summary>
		/// Selects multiple <see cref="Userod"/> objects from the database using the specified SQL command.
		/// </summary>
		public static IEnumerable<Userod> SelectMany(string command)
			=> Database.SelectMany(command, FromReader);

		/// <summary>
		/// Inserts the specified <see cref="Userod"/> into the database.
		/// </summary>
		public static long Insert(Userod userod)
			=> userod.Id = Database.ExecuteInsert(
				"INSERT INTO `Userod` " + 
				"(`UserName`, `Password`, `UserGroupNum`, `EmployeeNum`, `ClinicNum`, `ProvNum`, `IsHidden`, `TaskListInBox`, `AnesthProvType`, `DefaultHidePopups`, `PasswordIsStrong`, `ClinicIsRestricted`, `InboxHidePopups`, `UserNumCEMT`, `DateTFail`, `FailedAttempts`, `DomainUser`, `IsPasswordResetRequired`, `MobileWebPin`, `MobileWebPinFailedAttempts`, `DateTLastLogin`) " + 
				"VALUES (" + 
					"@UserName, @Password, @UserGroupNum, @EmployeeNum, @ClinicNum, @ProvNum, @IsHidden, @TaskListInBox, @AnesthProvType, @DefaultHidePopups, @PasswordIsStrong, @ClinicIsRestricted, @InboxHidePopups, @UserNumCEMT, @DateTFail, @FailedAttempts, @DomainUser, @IsPasswordResetRequired, @MobileWebPin, @MobileWebPinFailedAttempts, @DateTLastLogin" + 
				")");

		/// <summary>
		/// Updates the specified <see cref="Userod"/> in the database.
		/// </summary>
		public static void Update(Userod userod)
			=> Database.ExecuteNonQuery(
				"UPDATE `Userod` SET " + 
					"`UserName` = @UserName, " + 
					"`Password` = @Password, " + 
					"`UserGroupNum` = @UserGroupNum, " + 
					"`EmployeeNum` = @EmployeeNum, " + 
					"`ClinicNum` = @ClinicNum, " + 
					"`ProvNum` = @ProvNum, " + 
					"`IsHidden` = @IsHidden, " + 
					"`TaskListInBox` = @TaskListInBox, " + 
					"`AnesthProvType` = @AnesthProvType, " + 
					"`DefaultHidePopups` = @DefaultHidePopups, " + 
					"`PasswordIsStrong` = @PasswordIsStrong, " + 
					"`ClinicIsRestricted` = @ClinicIsRestricted, " + 
					"`InboxHidePopups` = @InboxHidePopups, " + 
					"`UserNumCEMT` = @UserNumCEMT, " + 
					"`DateTFail` = @DateTFail, " + 
					"`FailedAttempts` = @FailedAttempts, " + 
					"`DomainUser` = @DomainUser, " + 
					"`IsPasswordResetRequired` = @IsPasswordResetRequired, " + 
					"`MobileWebPin` = @MobileWebPin, " + 
					"`MobileWebPinFailedAttempts` = @MobileWebPinFailedAttempts, " + 
					"`DateTLastLogin` = @DateTLastLogin " + 
				"WHERE `UserNum` = @UserNum",
					new MySqlParameter("UserNum", userod.Id),
					new MySqlParameter("UserName", userod.UserName ?? ""),
					new MySqlParameter("Password", userod.Password ?? ""),
					new MySqlParameter("UserGroupNum", userod.UserGroupNum),
					new MySqlParameter("EmployeeNum", userod.EmployeeNum),
					new MySqlParameter("ClinicNum", userod.ClinicNum),
					new MySqlParameter("ProvNum", userod.ProvNum),
					new MySqlParameter("IsHidden", (userod.IsHidden ? 1 : 0)),
					new MySqlParameter("TaskListInBox", userod.TaskListInBox),
					new MySqlParameter("AnesthProvType", userod.AnesthProvType),
					new MySqlParameter("DefaultHidePopups", (userod.DefaultHidePopups ? 1 : 0)),
					new MySqlParameter("PasswordIsStrong", (userod.PasswordIsStrong ? 1 : 0)),
					new MySqlParameter("ClinicIsRestricted", (userod.ClinicIsRestricted ? 1 : 0)),
					new MySqlParameter("InboxHidePopups", (userod.InboxHidePopups ? 1 : 0)),
					new MySqlParameter("UserNumCEMT", userod.UserNumCEMT),
					new MySqlParameter("DateTFail", userod.DateTFail),
					new MySqlParameter("FailedAttempts", userod.FailedAttempts),
					new MySqlParameter("DomainUser", userod.DomainUser ?? ""),
					new MySqlParameter("IsPasswordResetRequired", (userod.IsPasswordResetRequired ? 1 : 0)),
					new MySqlParameter("MobileWebPin", userod.MobileWebPin ?? ""),
					new MySqlParameter("MobileWebPinFailedAttempts", userod.MobileWebPinFailedAttempts),
					new MySqlParameter("DateTLastLogin", userod.DateTLastLogin));

		/// <summary>
		/// Updates the specified <see cref="Userod"/> in the database.
		/// </summary>
		public static void Update(Userod userodNew, Userod userodOld)
		{
			var updates = new List<string>();
			var parameters = new List<MySqlParameter>();

			if (userodNew.UserName != userodOld.UserName)
			{
				updates.Add("`UserName` = @UserName");
				parameters.Add(new MySqlParameter("UserName", userodNew.UserName ?? ""));
			}

			if (userodNew.Password != userodOld.Password)
			{
				updates.Add("`Password` = @Password");
				parameters.Add(new MySqlParameter("Password", userodNew.Password ?? ""));
			}

			if (userodNew.UserGroupNum != userodOld.UserGroupNum)
			{
				updates.Add("`UserGroupNum` = @UserGroupNum");
				parameters.Add(new MySqlParameter("UserGroupNum", userodNew.UserGroupNum));
			}

			if (userodNew.EmployeeNum != userodOld.EmployeeNum)
			{
				updates.Add("`EmployeeNum` = @EmployeeNum");
				parameters.Add(new MySqlParameter("EmployeeNum", userodNew.EmployeeNum));
			}

			if (userodNew.ClinicNum != userodOld.ClinicNum)
			{
				updates.Add("`ClinicNum` = @ClinicNum");
				parameters.Add(new MySqlParameter("ClinicNum", userodNew.ClinicNum));
			}

			if (userodNew.ProvNum != userodOld.ProvNum)
			{
				updates.Add("`ProvNum` = @ProvNum");
				parameters.Add(new MySqlParameter("ProvNum", userodNew.ProvNum));
			}

			if (userodNew.IsHidden != userodOld.IsHidden)
			{
				updates.Add("`IsHidden` = @IsHidden");
				parameters.Add(new MySqlParameter("IsHidden", (userodNew.IsHidden ? 1 : 0)));
			}

			if (userodNew.TaskListInBox != userodOld.TaskListInBox)
			{
				updates.Add("`TaskListInBox` = @TaskListInBox");
				parameters.Add(new MySqlParameter("TaskListInBox", userodNew.TaskListInBox));
			}

			if (userodNew.AnesthProvType != userodOld.AnesthProvType)
			{
				updates.Add("`AnesthProvType` = @AnesthProvType");
				parameters.Add(new MySqlParameter("AnesthProvType", userodNew.AnesthProvType));
			}

			if (userodNew.DefaultHidePopups != userodOld.DefaultHidePopups)
			{
				updates.Add("`DefaultHidePopups` = @DefaultHidePopups");
				parameters.Add(new MySqlParameter("DefaultHidePopups", (userodNew.DefaultHidePopups ? 1 : 0)));
			}

			if (userodNew.PasswordIsStrong != userodOld.PasswordIsStrong)
			{
				updates.Add("`PasswordIsStrong` = @PasswordIsStrong");
				parameters.Add(new MySqlParameter("PasswordIsStrong", (userodNew.PasswordIsStrong ? 1 : 0)));
			}

			if (userodNew.ClinicIsRestricted != userodOld.ClinicIsRestricted)
			{
				updates.Add("`ClinicIsRestricted` = @ClinicIsRestricted");
				parameters.Add(new MySqlParameter("ClinicIsRestricted", (userodNew.ClinicIsRestricted ? 1 : 0)));
			}

			if (userodNew.InboxHidePopups != userodOld.InboxHidePopups)
			{
				updates.Add("`InboxHidePopups` = @InboxHidePopups");
				parameters.Add(new MySqlParameter("InboxHidePopups", (userodNew.InboxHidePopups ? 1 : 0)));
			}

			if (userodNew.UserNumCEMT != userodOld.UserNumCEMT)
			{
				updates.Add("`UserNumCEMT` = @UserNumCEMT");
				parameters.Add(new MySqlParameter("UserNumCEMT", userodNew.UserNumCEMT));
			}

			if (userodNew.DateTFail != userodOld.DateTFail)
			{
				updates.Add("`DateTFail` = @DateTFail");
				parameters.Add(new MySqlParameter("DateTFail", userodNew.DateTFail));
			}

			if (userodNew.FailedAttempts != userodOld.FailedAttempts)
			{
				updates.Add("`FailedAttempts` = @FailedAttempts");
				parameters.Add(new MySqlParameter("FailedAttempts", userodNew.FailedAttempts));
			}

			if (userodNew.DomainUser != userodOld.DomainUser)
			{
				updates.Add("`DomainUser` = @DomainUser");
				parameters.Add(new MySqlParameter("DomainUser", userodNew.DomainUser ?? ""));
			}

			if (userodNew.IsPasswordResetRequired != userodOld.IsPasswordResetRequired)
			{
				updates.Add("`IsPasswordResetRequired` = @IsPasswordResetRequired");
				parameters.Add(new MySqlParameter("IsPasswordResetRequired", (userodNew.IsPasswordResetRequired ? 1 : 0)));
			}

			if (userodNew.MobileWebPin != userodOld.MobileWebPin)
			{
				updates.Add("`MobileWebPin` = @MobileWebPin");
				parameters.Add(new MySqlParameter("MobileWebPin", userodNew.MobileWebPin ?? ""));
			}

			if (userodNew.MobileWebPinFailedAttempts != userodOld.MobileWebPinFailedAttempts)
			{
				updates.Add("`MobileWebPinFailedAttempts` = @MobileWebPinFailedAttempts");
				parameters.Add(new MySqlParameter("MobileWebPinFailedAttempts", userodNew.MobileWebPinFailedAttempts));
			}

			if (userodNew.DateTLastLogin != userodOld.DateTLastLogin)
			{
				updates.Add("`DateTLastLogin` = @DateTLastLogin");
				parameters.Add(new MySqlParameter("DateTLastLogin", userodNew.DateTLastLogin));
			}

			if (updates.Count == 0) return;

			parameters.Add(new MySqlParameter("UserNum", userodNew.Id));

			Database.ExecuteNonQuery("UPDATE `Userod` " + 
				"SET " + string.Join(", ", updates) + " " + 
				"WHERE `UserNum` = @UserNum",
					parameters.ToArray());
		}

		/// <summary>
		/// Deletes a single <see cref="Userod"/> object from the database.
		/// </summary>
		public static void Delete(Int64 userNum)
			 => Database.ExecuteNonQuery("DELETE FROM `Userod` WHERE `UserNum` = " + userNum);

		/// <summary>
		/// Deletes the specified <see cref="Userod"/> object from the database.
		/// </summary>
		public static void Delete(Userod userod)
			=> Delete(userod.Id);
	}
}
