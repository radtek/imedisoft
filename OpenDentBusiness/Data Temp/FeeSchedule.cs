using Imedisoft.Data.Annotations;
using Imedisoft.Data.Models;
using System;

namespace OpenDentBusiness
{
    /// <summary>
    /// Fee schedule names used to be in the definition table, but now they have their own table. 
    /// We are about to have many many more fee schedules as we start automating allowed fees.
    /// </summary>
    [Table("fee_schedules")]
	public class FeeSchedule : TableBase
	{
		[PrimaryKey]
		public long Id;

		public string Description;

		public FeeScheduleType Type;

		public int SortOrder;

		public bool IsHidden;

		/// <summary>
		/// True if the fee schedule is used globally and linked to the HQ (Localization of the fees are not allowed).
		/// </summary>
		public bool IsGlobal;

		[ForeignKey(typeof(User), nameof(User.Id))]
		public long AddedBy;

		[Column(AutoGenerated = true)]
		public DateTime AddedOn;

		[Column(AutoGenerated = true)]
		public DateTime LastModified;

		public FeeSchedule Copy()
		{
			return (FeeSchedule)MemberwiseClone();
		}
	}

	public enum FeeScheduleType
	{
		Normal,
		CoPay,
		/// <summary>2, Formerly named "Allowed"</summary>
		OutNetwork,
		FixedBenefit,
	}
}
