using Imedisoft.Data.Annotations;
using System;
using System.Collections;

namespace OpenDentBusiness
{
	/// <summary>
	/// Unified Code for Units of Measure. 
	/// UCUM is not a stricly defined list of codes but is instead a language definition that allows for all units and derived units to be named. 
	/// Examples: g (grams), g/L (grams per liter), g/L/s (grams per liter per second), g/L/s/s (grams per liter per second per second), etc... are all allowed units meaning there is an infinite number of units that can be defined using UCUM conventions.
	/// The codes stored in this table are merely a common subset that was readily available and premade.
	/// </summary>
	[Table("ucums")]
	public class Ucum : TableBase
	{
		[PrimaryKey]
		public long Id;

		/// <summary>
		/// Indexed. Also called concept code. Example: mol/mL
		/// </summary>
		public string Code;

		/// <summary>
		/// Also called Concept Name. 
		/// Human readable form of the UCUM code. Example: Moles Per MilliLiter [Substance Concentration Units]
		/// </summary>
		public string Description;

		/// <summary>
		/// True if this unit of measure is or has ever been in use. Useful for assisting users to select common units.
		/// </summary>
		public bool IsInUse;

		/// <summary>
		/// Returns a string representation of the code.
		/// </summary>
		public override string ToString() => Description;
    }
}
