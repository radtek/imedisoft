﻿using System;
using Imedisoft.Data.CrudGenerator.Schema;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Imedisoft.Data.CrudGenerator.Generator
{
    public static class EntityClassGenerator
    {
		private static readonly List<string> namespaces = new List<string>();

		private static void AddNamespace(string ns)
        {
			foreach (var item in namespaces)
            {
				if (item == ns) return;
            }

			namespaces.Add(ns);
        }

		/// <summary>
		/// Generates the entity class for the specified table.
		/// </summary>
		/// <param name="table">The table.</param>
		/// <returns>The code that defines the entity class.</returns>
		public static string Generate(Table table)
        {
			var stringBuilder = new StringBuilder();

			namespaces.Clear();
			AddNamespace("Imedisoft.Data");
			AddNamespace("System");
			AddNamespace("System.Collections");
			AddNamespace("System.Collections.Generic");
			AddNamespace("MySql.Data.MySqlClient");

			foreach (var column in table.Columns)
            {
				AddNamespace(column.Type.Namespace);
            }

			namespaces.Sort();

			stringBuilder.AppendLine("//------------------------------------------------------------------------------");
			stringBuilder.AppendLine("// <auto-generated>");
			stringBuilder.AppendLine("//     This code was generated by a tool.");
			stringBuilder.AppendLine($"//     Runtime Version: {Assembly.GetExecutingAssembly().ImageRuntimeVersion}");
			stringBuilder.AppendLine("//");
			stringBuilder.AppendLine("//     Changes to this file may cause incorrect behavior and will be lost if");
			stringBuilder.AppendLine("//     the code is regenerated.");
			stringBuilder.AppendLine("// </auto-generated>");
			stringBuilder.AppendLine("//------------------------------------------------------------------------------");

			foreach (var ns in namespaces)
            {
				stringBuilder.AppendLine($"using {ns};");
            }
			stringBuilder.AppendLine();

			GenerateHeader(stringBuilder, table);
			GenerateBuilder(stringBuilder, table);
			GenerateSelectOne(stringBuilder, table);
			GenerateSelectMany(stringBuilder, table);
			GenerateCrud(stringBuilder, table);
			GenerateFooter(stringBuilder);

			return stringBuilder.ToString();
        }

		private static void GenerateHeader(StringBuilder stringBuilder, Table table)
        {
			stringBuilder.AppendLine("namespace OpenDentBusiness.Crud");
			stringBuilder.AppendLine("{");
			stringBuilder.AppendLine($"	public class {table.Type.Name}Crud");
			stringBuilder.AppendLine("	{");
		}

		private static void GenerateFooter(StringBuilder stringBuilder)
        {
			stringBuilder.AppendLine("	}");
			stringBuilder.AppendLine("}");
        }

		private static void GenerateSelectOne(StringBuilder stringBuilder, Table table)
        {
			stringBuilder.AppendLine(@"		/// <summary>");
			stringBuilder.AppendLine(@"		/// Selects a single " + table.Type.Name + " object from the database using the specified SQL command.");
			stringBuilder.AppendLine(@"		/// </summary>");
			stringBuilder.AppendLine($"		public static {table.Type.Name} SelectOne(string command)");
			stringBuilder.AppendLine("			=> Database.SelectOne(command, FromReader);");
			stringBuilder.AppendLine("");

			if (table.PrimaryKey != null) GenerateSelectOnePK(stringBuilder, table);
		}

		private static string ParamName(string name) => name.Substring(0, 1).ToLower() + name.Substring(1);

		private static void GenerateSelectOnePK(StringBuilder stringBuilder, Table table)
        {
			var param = ParamName(table.PrimaryKey.Name);

            stringBuilder.AppendLine(@"		/// <summary>");
            stringBuilder.AppendLine(@"		/// Selects a single <see cref=""" + table.Type.Name + @"""/> object from the database using the specified SQL command.");
            stringBuilder.AppendLine(@"		/// </summary>");
            stringBuilder.AppendLine($"		public static {table.Type.Name} SelectOne({table.PrimaryKey.Type.Name} {param})");

			if (table.PrimaryKey.Type == typeof(long) || table.PrimaryKey.Type == typeof(int))
            {
                var command = $"\"SELECT * FROM `{table.Name}` WHERE `{table.PrimaryKey.Name}` = \" + {param}";
                
                stringBuilder.AppendLine($"			=> SelectOne({command});");
			}
			else // If the table uses a non numeric primary key use a parameterized query...
            {
                var command = $"\"SELECT * FROM `{table.Name}` WHERE `{table.PrimaryKey.Name}` = {ParameterName(table.PrimaryKey)}\"";

                stringBuilder.AppendLine($"			=> SelectOne({command},");
                stringBuilder.AppendLine($"				{GenerateParameter(table.PrimaryKey, param)});");
            }

            stringBuilder.AppendLine("");
		}

		public static void GenerateSelectMany(StringBuilder stringBuilder, Table table)
		{
			stringBuilder.AppendLine(@"		/// <summary>");
			stringBuilder.AppendLine(@"		/// Selects multiple <see cref=""" + table.Type.Name + @"""/> objects from the database using the specified SQL command.");
			stringBuilder.AppendLine(@"		/// </summary>");
			stringBuilder.AppendLine($"		public static IEnumerable<{table.Type.Name}> SelectMany(string command)");
			stringBuilder.AppendLine("			=> Database.SelectMany(command, FromReader);");
			stringBuilder.AppendLine("");
		}

		private static void GenerateBuilder(StringBuilder stringBuilder, Table table)
        {
			stringBuilder.AppendLine($"		public static {table.Type.Name} FromReader(MySqlDataReader dataReader)");
			stringBuilder.AppendLine("		{");
			stringBuilder.AppendLine($"			return new {table.Type.Name}");
			stringBuilder.AppendLine("			{");

			for (int i = 0; i < table.Columns.Count; i++)
            {
				var column = table.Columns[i];
				var value = $"dataReader[\"{column.Name}\"]";

				stringBuilder.Append($"				{column.FieldName} = {Unpack(value, column)}");
				if (i <= (table.Columns.Count - 2))
                {
					stringBuilder.Append(',');
                }
				stringBuilder.AppendLine();
            }

			stringBuilder.AppendLine("			};");
			stringBuilder.AppendLine("		}");
			stringBuilder.AppendLine();
        }

		private static string Unpack(string value, Column column)
        {
			if (column.Type.IsEnum)
            {
				return $"({column.Type.Name})Convert.ToInt32({value})";
            }

			if (column.Type == typeof(bool)) return $"(Convert.ToInt32({value}) == 1)";
			if (column.Type == typeof(byte)) return $"(byte){value}";
			if (column.Type == typeof(sbyte)) return $"(sbyte){value}";
			if (column.Type == typeof(char)) return $"(char){value}";
			if (column.Type == typeof(double)) return $"(double){value}";
			if (column.Type == typeof(float)) return $"(float){value}";
			if (column.Type == typeof(int)) return $"(int){value}";
			if (column.Type == typeof(uint)) return $"(uint){value}";
			if (column.Type == typeof(long)) return $"(long){value}";
			if (column.Type == typeof(ulong)) return $"(ulong){value}";
			if (column.Type == typeof(short)) return $"(short){value}";
			if (column.Type == typeof(ushort)) return $"(ushort){value}";

            if (column.Type == typeof(string))
            {
                if (column.Nullable)
                {
                    return $"{value} as string";
                }

                return "(string)" + value;
            }

            if (column.Type == typeof(Color)) return $"Color.FromArgb((int){value})";
            if (column.Type == typeof(DateTime)) return $"(DateTime){value}";

            return value;
        }

        private static string Pack(string value, Column column)
        {
			if (column.Type.IsEnum) return $"(int){value}";
			if (column.Type == typeof(bool)) return $"({value} ? 1 : 0)";
			if (column.Type == typeof(byte)) return value;
			if (column.Type == typeof(sbyte)) return value;
			if (column.Type == typeof(char)) return value;
			if (column.Type == typeof(double)) return value;
			if (column.Type == typeof(float)) return value;
			if (column.Type == typeof(int)) return value;
			if (column.Type == typeof(uint)) return value;
			if (column.Type == typeof(long)) return value;
			if (column.Type == typeof(ulong)) return value;
			if (column.Type == typeof(short)) return value;
			if (column.Type == typeof(ushort)) return value;

            if (column.Type == typeof(string))
            {
                if (column.Nullable)
                {
                    return value;
                }

                return $"{value} ?? \"\"";
            }

			if (column.Type == typeof(Color)) return $"{value}.ToArgb()";

			return value;
		}

		private static void GenerateCrud(StringBuilder stringBuilder, Table table)
        {
			GenerateInsert(stringBuilder, table);
			GenerateUpdate(stringBuilder, table);
			GenerateUpdateCompare(stringBuilder, table);
			GenerateDelete(stringBuilder, table);
		}

		private static void GenerateInsert(StringBuilder stringBuilder, Table table)
        {
			var param = ParamName(table.Type.Name);

			var columns = new List<string>();
			var values = new List<string>();
			foreach (var column in table.Columns)
			{
				if (column.IsPrimaryKey)
                {
					continue;
                }
				columns.Add($"`{column.Name}`");
				
				values.Add(ParameterName(column));
			}

			var queryBuilder = new StringBuilder();
			queryBuilder.AppendLine($"\"INSERT INTO `{table.Name}` \" + ");
			queryBuilder.AppendLine($"				\"({string.Join(", ", columns)}) \" + ");
			queryBuilder.AppendLine( "				\"VALUES (\" + ");
			queryBuilder.AppendLine($"					\"{string.Join(", ", values)}\" + ");
			queryBuilder.Append(     "				\")\"");

            if (table.PrimaryKey == null) return;

			stringBuilder.AppendLine(@"		/// <summary>");
			stringBuilder.AppendLine(@"		/// Inserts the specified <see cref=""" + table.Type.Name + @"""/> into the database.");
			stringBuilder.AppendLine(@"		/// </summary>");
            if (table.PrimaryKey.Type == typeof(long) || table.PrimaryKey.Type == typeof(int))
            {
                stringBuilder.AppendLine($"		public static long Insert({table.Type.Name} {param})");
                stringBuilder.AppendLine($"			=> {param}.{table.PrimaryKey.Name} = Database.ExecuteInsert(");
                stringBuilder.AppendLine($"				{queryBuilder});");
                stringBuilder.AppendLine();
            }
            else
            {
                stringBuilder.AppendLine($"		public static void Insert({table.Type.Name} {param})");
                stringBuilder.AppendLine( "			=> Database.ExecuteNonQuery(");
                stringBuilder.AppendLine($"				{queryBuilder})");
                stringBuilder.AppendLine();
            }
        }

		private static void GenerateUpdate(StringBuilder stringBuilder, Table table)
        {
			if (table.PrimaryKey == null) return;

			var param = ParamName(table.Type.Name);

			var updates = new List<string>();
			foreach (var column in table.Columns)
			{
				if (column.IsPrimaryKey)
				{
					continue;
				}

				updates.Add($"\"`{column.Name}` = {ParameterName(column)}");
			}

            var queryBuilder = new StringBuilder();
			queryBuilder.AppendLine($"\"UPDATE `{table.Name}` SET \" + ");
			queryBuilder.AppendLine($"					{string.Join(", \" + \r\n					", updates)}\" + ");
			queryBuilder.Append($"				\"WHERE `{table.PrimaryKey.Name}` = {ParameterName(table.PrimaryKey)}\"");

			stringBuilder.AppendLine(@"		/// <summary>");
			stringBuilder.AppendLine(@"		/// Updates the specified <see cref=""" + table.Type.Name + @"""/> in the database.");
			stringBuilder.AppendLine(@"		/// </summary>");
			stringBuilder.AppendLine($"		public static void Update({table.Type.Name} {param})");
			stringBuilder.AppendLine("			=> Database.ExecuteNonQuery(");
			stringBuilder.AppendLine($"				{queryBuilder},");

            GenerateParameters(stringBuilder, table, param, true);
            stringBuilder.AppendLine(");");

			stringBuilder.AppendLine();
		}

        private static string ParameterName(Column column) => '@' + column.Name;

        private static string GenerateParameter(Column column, string paramName) 
            => $"new MySqlParameter(\"{column.Name}\", {Pack($"{paramName}.{column.FieldName}", column)})";

        private static void GenerateParameters(StringBuilder stringBuilder, Table table, string paramName, bool includePrimaryKeys = false)
        {
            for (int i = 0; i < table.Columns.Count;i++)
            {
                var column = table.Columns[i];
                if (column.IsPrimaryKey && !includePrimaryKeys)
                {
                    continue;
                }

                stringBuilder.Append($"					{GenerateParameter(column, paramName)}");
                if (i < table.Columns.Count - 1)
                {
                    stringBuilder.AppendLine(",");
                }
            }
        }

        private static void GenerateUpdateCompare(StringBuilder stringBuilder, Table table)
        {
            if (table.PrimaryKey == null) return;

			var param = ParamName(table.Name);
			var paramNew = param + "New";
			var paramOld = param + "Old";

			stringBuilder.AppendLine(@"		/// <summary>");
			stringBuilder.AppendLine(@"		/// Updates the specified <see cref=""" + table.Type.Name + @"""/> in the database.");
			stringBuilder.AppendLine(@"		/// </summary>");
			stringBuilder.AppendLine($"		public static void Update({table.Type.Name} {paramNew}, {table.Type.Name} {paramOld})");
			stringBuilder.AppendLine(@"		{");
            stringBuilder.AppendLine(@"			var updates = new List<string>();");
            stringBuilder.AppendLine(@"			var parameters = new List<MySqlParameter>();");

			foreach (var column in table.Columns)
            {
				if (column.IsPrimaryKey)
                {
					continue;
                }

                stringBuilder.AppendLine();
				stringBuilder.AppendLine($"			if ({paramNew}.{column.FieldName} != {paramOld}.{column.FieldName})");
                stringBuilder.AppendLine($"			{{");
                stringBuilder.AppendLine($"				updates.Add(\"`{column.Name}` = {ParameterName(column)}\");");
                stringBuilder.AppendLine($"				parameters.Add({GenerateParameter(column, paramNew)});");
				stringBuilder.AppendLine($"			}}");
			}

			stringBuilder.AppendLine();
			stringBuilder.AppendLine("			if (updates.Count == 0) return;");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"			parameters.Add({GenerateParameter(table.PrimaryKey, paramNew)});");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine($"			Database.ExecuteNonQuery(\"UPDATE `{table.Name}` \" + ");
			stringBuilder.AppendLine( "				\"SET \" + string.Join(\", \", updates) + \" \" + ");
			stringBuilder.AppendLine($"				\"WHERE `{table.PrimaryKey.Name}` = {ParameterName(table.PrimaryKey)}\",");
            stringBuilder.AppendLine($"					parameters.ToArray());");
			stringBuilder.AppendLine(@"		}");
            stringBuilder.AppendLine();
        }

		private static void GenerateDelete(StringBuilder stringBuilder, Table table)
        {
			if (table.PrimaryKey == null) return;

			var param = ParamName(table.PrimaryKey.Name);

			stringBuilder.AppendLine(@"		/// <summary>");
			stringBuilder.AppendLine(@"		/// Deletes a single <see cref=""" + table.Type.Name + @"""/> object from the database.");
			stringBuilder.AppendLine(@"		/// </summary>");
			stringBuilder.AppendLine($"		public static void Delete({table.PrimaryKey.Type.Name} {param})");
            if (table.PrimaryKey.Type == typeof(long) || table.PrimaryKey.Type == typeof(int))
            {
                var command = $"\"DELETE FROM `{table.Name}` WHERE `{table.PrimaryKey.Name}` = \" + {param}";

                stringBuilder.AppendLine($"			 => Database.ExecuteNonQuery({command});");
            }
            else
            {
                var command = $"\"DELETE FROM `{table.Name}` WHERE `{table.PrimaryKey.Name}` = {ParameterName(table.PrimaryKey)}\"";


				stringBuilder.AppendLine($"			 => Database.ExecuteNonQuery({command},");
                stringBuilder.AppendLine($"					{GenerateParameter(table.PrimaryKey, param)});");
            }

            stringBuilder.AppendLine();

			param = ParamName(table.Type.Name);

			stringBuilder.AppendLine(@"		/// <summary>");
			stringBuilder.AppendLine(@"		/// Deletes the specified <see cref=""" + table.Type.Name + @"""/> object from the database.");
			stringBuilder.AppendLine(@"		/// </summary>");
			stringBuilder.AppendLine($"		public static void Delete({table.Type.Name} {param})");
            stringBuilder.AppendLine($"			=> Delete({param}.{table.PrimaryKey.FieldName});");
        }
	}
}
