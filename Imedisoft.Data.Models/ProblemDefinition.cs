using Imedisoft.Data.Annotations;
using System;

namespace Imedisoft.Data.Models
{
	[Table("problem_definitions")]
	public class ProblemDefinition
	{
		[PrimaryKey]
		public long Id;

		/// <summary>
		/// A description of the disease.
		/// </summary>
		public string Description;

		/// <summary>
		/// Example: 250.00 for diabetes. 
		/// </summary>
		[ForeignKey(typeof(Icd9), nameof(Icd9.Code)), Nullable]
		public string CodeIcd9;

		/// <summary>
		/// Example: E10.1 for 'Type 1 diabetes mellitus with ketoacidosis'.
		/// </summary>
		[ForeignKey(typeof(Icd10), nameof(Icd10.Code)), Nullable]
		public string CodeIcd10;

		/// <summary>
		/// Example: 230572002 for diabetic neuropathy.
		/// </summary>
		[ForeignKey(typeof(Snomed), nameof(Snomed.Code)), Nullable]
		public string CodeSnomed;

		/// <summary>
		///		<para>
		///			A value indicating whether the disease definition has been hidden.
		///		</para>
		///		<para>
		///			If hidden, the disease will still show on any patient that it was previously 
		///			attached to, but it will not be available for future patients.
		///		</para>
		/// </summary>
		public bool IsHidden;

		/// <summary>
		/// The date and time on which the disease definition was last modified.
		/// </summary>
		[Column(AutoGenerated = true)]
		public DateTime LastModifiedDate;

		public ProblemDefinition Copy() => (ProblemDefinition)MemberwiseClone();
	}
}
