using Imedisoft.Data.Annotations;
using System;

namespace Imedisoft.Data.Models
{
	[Table("perio_measures")]
	public class PerioMeasure
	{
		[PrimaryKey]
		public long Id;

		public long PerioExamId;

		public PerioSequenceType SequenceType;

		/// <summary>
		/// Valid values are 1-32. Every measurement must be associated with a tooth.
		/// </summary>
		public int Tooth;

		/// <summary>
		/// This is used when the measurement does not apply to a surface (mobility and skiptooth). 
		/// Valid values for all surfaces are 0 through 19, or -1 to represent no measurement taken.
		/// </summary>
		public int ToothValue;

		/// <summary>
		/// -1 represents no measurement. Values of 100+ represent negative values (only used for Gingival Margins). e.g. To use a value of 105, subtract it from 100. (100 - 105 = -5)
		/// </summary>
		[Column("mb")]
		public int MB;

		[Column("b")]
		public int B;

		[Column("db")]
		public int DB;

		[Column("ml")]
		public int ML;

		[Column("l")]
		public int L;

		[Column("dl")]
		public int DL;

		/// <summary>
		/// The date and time on which the measure was added.
		/// </summary>
		[Column(AutoGenerated = true)]
		public DateTime AddedOnDate;

		/// <summary>
		/// The date and time on which the measure was last modified.
		/// </summary>
		[Column(AutoGenerated = true)]
		public DateTime LastModifiedDate;
	}

	/// <summary>
	/// In perio, the type of measurements for a given row.
	/// </summary>
	public enum PerioSequenceType
	{
		Mobility,
		Furcation,

		/// <summary>
		/// AKA recession.
		/// </summary>
		GingMargin,

		/// <summary>
		/// MucoGingivalJunction- the division between attached and unattached mucosa.
		/// </summary>
		MGJ,

		Probing,

		/// <summary>
		/// For the skiptooth type, set surf to none, and ToothValue to 1.
		/// </summary>
		SkipTooth,

		/// <summary>
		/// Sum of flags for bleeding(1), suppuration(2), plaque(4), and calculus(8).
		/// </summary>
		Bleeding,

		/// <summary>
		/// But this type is never saved to the db. It is always calculated on the fly.
		/// </summary>
		CAL
	}

	/// <summary>
	/// Blood, pus, plaque and calculus.
	/// </summary>
	[Flags]
	public enum BleedingFlags
	{
		None = 0,
		Blood = 1,
		Suppuration = 2,
		Plaque = 4,
		Calculus = 8
	}

	/// <summary>
	/// Currently, only six surfaces are supported, but more can always be added.
	/// </summary>
	public enum PerioSurf
	{
		/// <summary>
		/// Might be used for things such as mobility or missing tooth.
		/// </summary>
		None,

		MB,
		B,
		DB,
		ML,
		L,
		DL
	}
}
