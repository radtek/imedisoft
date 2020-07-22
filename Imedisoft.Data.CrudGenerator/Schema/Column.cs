﻿using Imedisoft.Data.Annotations;
using System;
using System.Reflection;

namespace Imedisoft.Data.CrudGenerator.Schema
{
    public class Column
    {
        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        public string FieldName { get; }

        /// <summary>
        /// Gets the name of the column.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a value indicating whether the column is part of the primary key.
        /// </summary>
        public bool IsPrimaryKey { get; }

        /// <summary>
        /// Gets the column data type.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Gets a value indicating whether the column is read only.
        /// </summary>
        public bool ReadOnly { get; }

        /// <summary>
        /// Determines whether the column represents a numeric type.
        /// </summary>
        public bool IsNumeric => 
            Type == typeof(byte) || 
            Type == typeof(short) || Type == typeof(int) || Type == typeof(long) ||
            Type == typeof(ushort) || Type == typeof(uint) || Type == typeof(ulong);

        /// <summary>
        /// Gets a value indicating whether the column is nullable.
        /// </summary>
        public bool Nullable { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Column"/> class.
        /// </summary>
        /// <param name="fieldInfo">The field that represents the column.</param>
        internal Column(FieldInfo fieldInfo)
        {
            var columnAttribute = fieldInfo.GetCustomAttribute<ColumnAttribute>();

            FieldName = fieldInfo.Name;
            Name = columnAttribute?.Name ?? FieldName;
            ReadOnly = columnAttribute?.ReadOnly ?? false;

            IsPrimaryKey = fieldInfo.GetCustomAttribute<PrimaryKeyAttribute>() != null;

            Type = fieldInfo.FieldType;
        }

        /// <summary>
        /// Returns a string representation of the column.
        /// </summary>
        public override string ToString() => $"{Name} ({Type.FullName})";
    }
}
