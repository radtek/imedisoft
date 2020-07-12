﻿using System;
using System.Collections.Generic;
using System.Text;
using DataConnectionBase;

namespace OpenDentBusiness
{
	/// <summary>
	/// Please ignore this class.
	/// It's used only for testing.
	/// </summary>
	public class SchemaCrudProposedTest
	{
		///<summary>Example only</summary>
		public static void AddTableTempcore()
		{
			string command = "DROP TABLE IF EXISTS tempcore";
			Db.NonQ(command);
			command = @"CREATE TABLE tempcore (
					TempCoreNum bigint NOT NULL auto_increment PRIMARY KEY,
					TimeOfDayTest time NOT NULL DEFAULT '00:00:00',
					TimeStampTest timestamp,
					DateTest date NOT NULL DEFAULT '0001-01-01',
					DateTimeTest datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
					TimeSpanTest time NOT NULL DEFAULT '00:00:00',
					CurrencyTest double NOT NULL,
					BoolTest tinyint NOT NULL,
					TextSmallTest varchar(255) NOT NULL,
					TextMediumTest text NOT NULL,
					TextLargeTest text NOT NULL,
					VarCharTest varchar(255) NOT NULL
					) DEFAULT CHARSET=utf8";
			Db.NonQ(command);
		}

		///<summary>Example only</summary>
		public static void AddColumnEndClob()
		{
			string command = "ALTER TABLE tempcore ADD ColEndClob text NOT NULL";
			Db.NonQ(command);

		}

		///<summary>Example only</summary>
		public static void AddColumnEndInt()
		{
			string command = "ALTER TABLE tempcore ADD ColEndInt int NOT NULL";
			Db.NonQ(command);
		}

		///<summary>Example only</summary>
		public static void AddColumnEndTimeStamp()
		{
			string command = "ALTER TABLE tempcore ADD ColEndTimeStamp timestamp";
			Db.NonQ(command);
			command = "UPDATE tempcore SET ColEndTimeStamp = NOW()";
			Db.NonQ(command);
		}

		///<summary>Example only</summary>
		public static void AddIndex()
		{
			string command = "ALTER TABLE tempcore ADD INDEX(ColEndInt)";
			Db.NonQ(command);
		}

		///<summary>Example only</summary>
		public static void DropColumn()
		{
			string command = "ALTER TABLE tempcore DROP COLUMN TextLargeTest";
			Db.NonQ(command);
		}
	}
}
