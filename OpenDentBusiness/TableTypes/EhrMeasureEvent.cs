﻿using Imedisoft.Data.Annotations;
using System;

namespace OpenDentBusiness
{
    /// <summary>
	/// Represents events for EHR that are needed for reporting purposes.
	/// </summary>
    [Table("ehr_measure_events")]
	public class EhrMeasureEvent
	{
		[PrimaryKey]
		public long Id;

		/// <summary>
		/// The date and time the event ocurred.
		/// </summary>
		[Column(AutoGenerated = true)]
		public DateTime Date;

		public EhrMeasureEventType Type;

		public long PatientId;

		/// <summary>
		/// More information about the event. Not typically used.
		/// </summary>
		public string MoreInfo;

		/// <summary>
		/// The code for this event. Example: TobaccoUseAssessed can be one of three LOINC codes: 11366-2 History of tobacco use Narrative,
		/// 68535-4 Have you used tobacco in the last 30 days, and 68536-2 Have you used smokeless tobacco product in the last 30 days.
		/// </summary>
		public string CodeValueEvent;

		/// <summary>
		/// The code system name for the event code.  Examples: LOINC, SNOMEDCT.
		/// </summary>
		public string CodeSystemEvent;

		/// <summary>
		/// The code for this event result.  
		/// Example: A TobaccoUseAssessed event type could result in a finding of SNOMED code 8517006 - Ex-smoker (finding).  
		/// There are 54 allowed tobacco user/non-user codes, and the user is allowed to select from any SNOMED code if they wish, for a TobaccoUseAssessed event.
		/// </summary>
		public string CodeValueResult;

		/// <summary>
		/// The code system for this event result.  
		/// Example: SNOMEDCT
		/// </summary>
		public string CodeSystemResult;

		/// <summary>
		/// A foreign key to a table associated with the EventType. null indicates not in use. 
		/// Used to properly count denominators for specific measure types.
		/// </summary>
		public long? ObjectId;

		/// <summary>
		/// The date the patient started using tobacco.
		/// </summary>
		public DateTime? TobaccoStartDate;

		/// <summary>
		/// How eager a tobacco user is to quit using tobacco. Scale of 1-10.
		/// </summary>
		public byte TobaccoCessationDesire;
	}


	public enum EhrMeasureEventType
	{
		EducationProvided,
		OnlineAccessProvided,
		ElectronicCopyRequested,
		ElectronicCopyProvidedToPt,
		ClinicalSummaryProvidedToPt,
		ReminderSent,
		MedicationReconcile,

		/// <summary>
		/// When Summary of Care is provided in one of the following ways: Printed, exported, or sent to the patient portal (for referrals To doctors).
		/// </summary>
		SummaryOfCareProvidedToDr,

		TobaccoUseAssessed,
		TobaccoCessation,
		CurrentMedsDocumented,
		CPOE_MedOrdered,
		CPOE_LabOrdered,
		CPOE_RadOrdered,

		/// <summary>
		/// When a Summary of Care is provided to a doctor electronically in one of the following ways: Exported (we assume they send another way), or a Direct message is sent with Summary of Care attached.
		/// </summary>
		SummaryOfCareProvidedToDrElectronic,
		
		SecureMessageFromPat,
		DrugDrugInteractChecking,
		DrugFormularyChecking,
		ProtectElectHealthInfo,
		ImmunizationRegistries,
		SyndromicSurveillance,
		PatientList,
		ClinicalInterventionRules
	}

}