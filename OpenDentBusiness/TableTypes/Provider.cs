using Imedisoft.Data.Annotations;
using Imedisoft.Data.Models;
using System;
using System.Collections;
using System.Drawing;

namespace OpenDentBusiness
{
	/// <summary>
	/// A provider is usually a dentist or a hygienist.
	/// But a provider might also be a denturist, a dental student, or a dental hygiene student.
	/// A provider might also be a 'dummy', used only for billing purposes or for notes in the Appointments module.
	/// There is no limit to the number of providers that can be added.
	/// </summary>
	[Table("providers")]
	public class Provider : TableBase
	{
		[PrimaryKey]
		public long Id;

		/// <summary>
		/// Abbreviation. 
		/// There was a limit of 5 char before version 5.4. 
		/// The new limit is 255 char. 
		/// This will allow more elegant solutions to various problems. 
		/// Providers will no longer be referred to by FName and LName. 
		/// Abbr is used as a human readable primary key.
		/// </summary>
		public string Abbr;

		/// <summary>
		/// Order that provider will show in lists.
		/// </summary>
		public int ItemOrder;

		public string LastName;
		public string FirstName;
		public string Initials;

		/// <summary>
		/// e.g. DMD or DDS. Was 'title' in previous versions.
		/// </summary>
		public string Suffix;

		[ForeignKey(typeof(FeeSched), nameof(FeeSched.FeeSchedNum))]
		public long FeeScheduleId;

		[ForeignKey(typeof(Definition), nameof(Definition.Id))]
		public long Specialty;

		/// <summary>
		/// or TIN.
		/// </summary>
		public string SSN;

		/// <summary>
		/// True if the SSN field is actually a Tax ID Num
		/// </summary>
		public bool UsingTIN;

		/// <summary>
		/// The DEA number for this provider and clinic.
		/// </summary>
		public string DeaNumber;

		/// <summary>
		/// License number corresponding to the StateWhereLicensed. Can include punctuation.
		/// </summary>
		public string StateLicense;

		/// <summary>
		/// Provider medical State ID.
		/// </summary>
		public string StateRxId;

		/// <summary>
		/// The state abbreviation where the state license number in the StateLicense field is legally registered.
		/// </summary>
		public string StateWhereLicensed;

		/// <summary>
		/// The color of the provider.
		/// </summary>
		public Color Color;

		/// <summary>
		/// The outline color of the provider.
		/// </summary>
		public Color ColorOutline;

		/// <summary>
		/// A value indicating whether there is a signature on file for this provider.
		/// </summary>
		public bool HasSignature;




		[Column("medicaid_id")]
		public string MedicaidID;



		/// <summary>
		/// Each student is a provider. This keeps track of which class they are in.
		/// </summary>
		[ForeignKey(typeof(SchoolClass), nameof(SchoolClass.Id))]
		public long SchoolClassId;

		/// <summary>
		/// US NPI, and Canadian CDA provider number.
		/// </summary>
		[Column("national_provider_id")]
		public string NationalProviderID;



		/// <summary>
		/// Canadian field required for e-claims. Assigned by CDA. 
		/// It's OK to have multiple providers with the same OfficeNum. 
		/// Max length should be 4.
		/// </summary>
		public string CanadianOfficeNum;


		/// <summary>
		/// The date and time on which the provider was last modified.
		/// </summary>
		[Column(AutoGenerated = true)]
		public DateTime LastModifiedDate;



		/// <summary> FK to ??. Field used to set the Anesthesia Provider type. Used to filter the provider dropdowns on FormAnestheticRecord</summary>
		public long AnesthProvType;


		/// <summary>
		/// If none of the supplied taxonomies works. This will show on claims.
		/// </summary>
		public string TaxonomyCodeOverride;








		/// <summary>
		/// The name of this field is bad and will soon be changed to MedicalSoftID. 
		/// This allows an ID field that can be used for HL7 synch with other software. 
		/// Before this field was added, we were using prov abbreviation, which did not work well.
		/// </summary>
		public string EcwID;






		[ForeignKey(typeof(EmailAddress), nameof(EmailAddress.EmailAddressNum))]
		public long? EmailAddressNum;

		///<summary>Used to determine which stage of MU the provider is shown. 0=Global preference(Default), 1=Stage 1, 2=Stage 2, 3=Modified Stage 2.</summary>
		public int EhrMuStage;

		///<summary>FK to provider.ProvNum</summary>
		public long ProvNumBillingOverride;

		/// <summary>
		/// Custom ID used for reports or bridges only.
		/// </summary>
		public string CustomID;









		/// <summary>
		/// Indicates if the provider should only be scheduled in a certain way (e.g. Root canals only).
		/// </summary>
		public string SchedNote;

		/// <summary>The birthdate of the provider.</summary>
		public DateTime Birthdate;

		///<summary>The description of the provider that is displayed to patients in Web Sched.</summary>
		public string WebSchedDescript;

		///<summary>The image of the provider that is displayed to patients in Web Sched. File name only (path not included).
		///This should be a file name in the A to Z folder.</summary>
		public string WebSchedImageLocation;

		/// <summary>
		/// The hourly production goal amount of the provider.
		/// </summary>
		public double HourlyProductionGoal;

		/// <summary>
		/// The date that the provider's term ends. 
		/// This can be used to prevent appointments from being scheduled, appointments from being marked complete, prescriptions from being prescribed, and claims from being sent.
		/// </summary>
		public DateTime DateTerm;






		public ProviderStatus Status;

		/// <summary>
		/// True if hygienist.
		/// </summary>
		public bool IsSecondary;

		/// <summary>
		/// Default is false because most providers are persons. 
		/// But some dummy providers used for practices or billing entities are not persons. 
		/// This is needed on 837s.
		/// </summary>
		public bool IsNotPerson;

		/// <summary>
		/// Default is false because most providers will not be instructors. Used in Dental Schools.
		/// </summary>
		public bool IsInstructor;

		/// <summary>
		/// For Canada. Set to true if CDA Net provider.
		/// </summary>
		[Column("is_cda_net")]
		public bool IsCDAnet;

		/// <summary>
		/// Indicates whether or not the provider has individually agreed to accept eRx charges. Defaults to Disabled for new providers.
		/// </summary>
		public ErxEnabledStatus IsErxEnabled;

		/// <summary>
		/// Determines whether the provider will show on standard reports.
		/// </summary>
		public bool IsHiddenReport;

		/// <summary>
		/// If true, provider will not show on any lists.
		/// </summary>
		public bool IsHidden;

		public Provider Copy()
		{
			return (Provider)MemberwiseClone();
		}

		public Provider()
		{
		}

		public override string ToString() => GetLongDesc();


		/// <summary>
		/// For use in areas of the program where we have more room than just simple abbr. 
		/// Such as pick boxes in reports. This will give Abbr - LName, FName (hidden). 
		/// If dental schools is turned on then the Abbr will be replaced with the ProvNum.
		/// </summary>
		public string GetLongDesc()
		{
			var name = Prefs.GetBool(PrefName.EasyHideDentalSchools) ?
				$"[{Id}] {LastName}, {FirstName}" : 
				$"[{Abbr}] {LastName}, {FirstName}";

			if (IsHidden)
			{
				name += " " + "(hidden)";
			}

			return name;
		}



		///<Summary>For use in areas of the program where we have only have room for the simple abbr.  Such as pick boxes in the claim edit window.  This will give Abbr (hidden).</Summary>
		public string GetAbbr()
		{
			string retval = Abbr;
			if (IsHidden)
			{
				retval += " " + "(hidden)";
			}
			return retval;
		}

		///<summary>FName MI. LName, Suffix</summary>
		public string GetFormalName()
		{
			string retVal = FirstName + " " + Initials;
			if (Initials.Length == 1)
			{
				retVal += ".";
			}
			if (Initials != "")
			{
				retVal += " ";
			}
			retVal += LastName;
			if (Suffix != "")
			{
				retVal += ", " + Suffix;
			}
			return retVal;
		}
	}

	public enum ProviderStatus
	{
		Active,
		Deleted
	}

	public enum ErxEnabledStatus
	{
		Disabled,
		Enabled,
		EnabledWithLegacy,
	}
}
