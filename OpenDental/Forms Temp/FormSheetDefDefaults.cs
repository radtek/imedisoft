using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;
using System.Linq;
using CodeBase;

namespace OpenDental {
	public partial class FormSheetDefDefaults:ODForm {
		
		///<summary>This dictionary contains all values as of initially opening the form.
		///ClinicNum is the key, and the value of Dictionary is each SheetDef by their type.</summary>
		private Dictionary<long,Dictionary<SheetTypeEnum,SheetDef>> _dictSheetsOld;
		///<summary>This dictionary contains all values as they change before saving.
		///ClinicNum is the key, and the value of Dictionary is each SheetDef by their type.</summary>
		private Dictionary<long,Dictionary<SheetTypeEnum,SheetDef>> _dictSheetsCur;
		///<summary>This is used to save the changes made for one clinic when the user changes to a different clinic.</summary>
		private long _clinicNumCur;
		///<summary>A list of ComboBoxes for this form, which are visible and have a tag who's type is SheetTypeEnum.</summary>
		private List<ComboBox> _listSheetTypeComboBoxes {
			get {
				return this.GetAllControls().OfType<ComboBox>().Where(x => x.Visible && x.Tag is SheetTypeEnum).ToList();
			}
		}
		///<summary>An extension of _listSheetTypeComboBoxes, which returns only the tags of type SheetTypeEnum to the user. 
		///It will "inherit" the visible restriction from _listSheetTypeComboBoxes.</summary>
		private List<SheetTypeEnum> _listSheetTypes {
			get {
				return _listSheetTypeComboBoxes.Select(x => (SheetTypeEnum)x.Tag).ToList();
			}
		}

		public FormSheetDefDefaults() {
			InitializeComponent();
			
		}

		private void FormSheetDefDefaults_Load(object sender,EventArgs e) {
			List<long> listClinicNums=new List<long>();
			if(PrefC.HasClinicsEnabled) {
				listClinicNums=Clinics.GetByUser(Security.CurrentUser).Select(x => x.Id).ToList();
				_clinicNumCur=0;
			}
			comboClinicDefault.SelectedClinicNum=0;
			FillSheetDefComboBoxes();//Must be called prior to below logic.
			_dictSheetsOld=SheetDefs.GetSheetDefDefaults(listClinicNums,_listSheetTypes.ToArray());
			_dictSheetsCur=SheetDefs.GetSheetDefDefaults(listClinicNums,_listSheetTypes.ToArray());//Call GetAllSheetDefDefaults a second time to avoid shallow copies.
		}

		///<summary>Saves any changes to the sheets dictionary.  Mainly used when switching between clinics or when leaving this form.
		///Currently only supports saving SheetTypeEnum.Rx changes.</summary>
		private void UpdateDictSheetsCur() {
			//UpdateSheetDefForDictSheetsCur(comboConsent,SheetTypeEnum.Consent);
			//UpdateSheetDefForDictSheetsCur(comboDepositSlip,SheetTypeEnum.DepositSlip);
			//UpdateSheetDefForDictSheetsCur(comboExamSheet,SheetTypeEnum.ExamSheet);
			//UpdateSheetDefForDictSheetsCur(comboLabelAppointment,SheetTypeEnum.LabelAppointment);
			//UpdateSheetDefForDictSheetsCur(comboLabelCarrier,SheetTypeEnum.LabelCarrier);
			//UpdateSheetDefForDictSheetsCur(comboLabelPatient,SheetTypeEnum.LabelPatient);
			//UpdateSheetDefForDictSheetsCur(comboLabelReferral,SheetTypeEnum.LabelReferral);
			//UpdateSheetDefForDictSheetsCur(comboLabSlip,SheetTypeEnum.LabSlip);
			//UpdateSheetDefForDictSheetsCur(comboMedicalHistory,SheetTypeEnum.MedicalHistory);
			//UpdateSheetDefForDictSheetsCur(comboMedLabResults,SheetTypeEnum.MedLabResults);
			//UpdateSheetDefForDictSheetsCur(comboPatientForm,SheetTypeEnum.PatientForm);
			//UpdateSheetDefForDictSheetsCur(comboPatientLetter,SheetTypeEnum.PatientLetter);
			//UpdateSheetDefForDictSheetsCur(comboPaymentPlan,SheetTypeEnum.PaymentPlan);
			//UpdateSheetDefForDictSheetsCur(comboReferralLetter,SheetTypeEnum.ReferralLetter);
			//UpdateSheetDefForDictSheetsCur(comboReferralSlip,SheetTypeEnum.ReferralSlip);
			//UpdateSheetDefForDictSheetsCur(comboRoutingSlip,SheetTypeEnum.RoutingSlip);
			UpdateSheetDefForDictSheetsCur(comboRx,SheetTypeEnum.Rx);
			UpdateSheetDefForDictSheetsCur(comboBoxChartLayout,SheetTypeEnum.ChartModule);
			//UpdateSheetDefForDictSheetsCur(comboRxMulti,SheetTypeEnum.RxMulti);
			//UpdateSheetDefForDictSheetsCur(comboScreening,SheetTypeEnum.Screening);
			//UpdateSheetDefForDictSheetsCur(comboStatement,SheetTypeEnum.Statement);
			//UpdateSheetDefForDictSheetsCur(comboTreatmentPlan,SheetTypeEnum.TreatmentPlan);
		}

		private void UpdateSheetDefForDictSheetsCur(ComboBox comboBox,SheetTypeEnum sheetType) {
			if(_dictSheetsCur.ContainsKey(_clinicNumCur)) {
				if(_dictSheetsCur[_clinicNumCur].ContainsKey(sheetType)) {
					_dictSheetsCur[_clinicNumCur][sheetType]=((SheetDefWrapper)comboBox.SelectedItem).SheetDef;
				}
				else {
					_dictSheetsCur[_clinicNumCur].Add(sheetType,((SheetDefWrapper)comboBox.SelectedItem).SheetDef);
				}
			}
			else {//There are no overrides for the current clinic.
				  //Only add to the dictionary if the user selected a combobox that wasn't "default" which is defined by SheetDef being null.
				if(((SheetDefWrapper)comboBox.SelectedItem).SheetDef!=null) {
					_dictSheetsCur.Add(_clinicNumCur,new Dictionary<SheetTypeEnum,SheetDef>());
					_dictSheetsCur[_clinicNumCur].Add(sheetType,((SheetDefWrapper)comboBox.SelectedItem).SheetDef);
				}
			}
		}

		private void FillSheetDefComboBoxes() {
			//FillSheetDefComboBox(comboConsent,SheetTypeEnum.Consent);
			//FillSheetDefComboBox(comboDepositSlip,SheetTypeEnum.DepositSlip);
			//FillSheetDefComboBox(comboExamSheet,SheetTypeEnum.ExamSheet);
			//FillSheetDefComboBox(comboLabelAppointment,SheetTypeEnum.LabelAppointment);
			//FillSheetDefComboBox(comboLabelCarrier,SheetTypeEnum.LabelCarrier);
			//FillSheetDefComboBox(comboLabelPatient,SheetTypeEnum.LabelPatient);
			//FillSheetDefComboBox(comboLabelReferral,SheetTypeEnum.LabelReferral);
			//FillSheetDefComboBox(comboLabSlip,SheetTypeEnum.LabSlip);
			//FillSheetDefComboBox(comboMedicalHistory,SheetTypeEnum.MedicalHistory);
			//FillSheetDefComboBox(comboMedLabResults,SheetTypeEnum.MedLabResults);
			//FillSheetDefComboBox(comboPatientForm,SheetTypeEnum.PatientForm);
			//FillSheetDefComboBox(comboPatientLetter,SheetTypeEnum.PatientLetter);
			//FillSheetDefComboBox(comboPaymentPlan,SheetTypeEnum.PaymentPlan);
			//FillSheetDefComboBox(comboReferralLetter,SheetTypeEnum.ReferralLetter);
			//FillSheetDefComboBox(comboReferralSlip,SheetTypeEnum.ReferralSlip);
			//FillSheetDefComboBox(comboRoutingSlip,SheetTypeEnum.RoutingSlip);
			FillSheetDefComboBox(comboRx,SheetTypeEnum.Rx);
			FillSheetDefComboBox(comboBoxChartLayout,SheetTypeEnum.ChartModule);
			//FillSheetDefComboBox(comboRxMulti,SheetTypeEnum.RxMulti);
			//FillSheetDefComboBox(comboScreening,SheetTypeEnum.Screening);
			//FillSheetDefComboBox(comboStatement,SheetTypeEnum.Statement);
			//FillSheetDefComboBox(comboTreatmentPlan,SheetTypeEnum.TreatmentPlan);
		}
			
		///<summary>Fills the combo box passed in with all of the sheet defs available for the passed in sheet type.</summary>
		private void FillSheetDefComboBox(ComboBox comboBox,SheetTypeEnum sheetType) {
			List<SheetDef> listSheetDefs=new List<SheetDef>();
			//Some sheet types have multiple "internal" examples for user convenience. 
			//We need to make sure that we give ALL internal types as options for defaults.
			switch(sheetType) {
				case SheetTypeEnum.LabelPatient:
					//TODO: When there are multiple "internal" sheet defs available for the user to pick,
					//	we need to store the selection made as a string within the clinicpref tables "ValueString" column.
					listSheetDefs.Add(SheetsInternal.GetSheetDef(SheetInternalType.LabelPatientMail));
					listSheetDefs.Add(SheetsInternal.GetSheetDef(SheetInternalType.LabelPatientLFAddress));
					listSheetDefs.Add(SheetsInternal.GetSheetDef(SheetInternalType.LabelPatientLFChartNumber));
					listSheetDefs.Add(SheetsInternal.GetSheetDef(SheetInternalType.LabelPatientLFPatNum));
					listSheetDefs.Add(SheetsInternal.GetSheetDef(SheetInternalType.LabelPatientRadiograph));
					listSheetDefs.Add(SheetsInternal.GetSheetDef(SheetInternalType.LabelText));
					break;
				case SheetTypeEnum.PatientForm:
					//TODO: When there are multiple "internal" sheet defs available for the user to pick,
					//	we need to store the selection made as a string within the clinicpref tables "ValueString" column.
					listSheetDefs.Add(SheetsInternal.GetSheetDef(SheetInternalType.PatientRegistration));
					listSheetDefs.Add(SheetsInternal.GetSheetDef(SheetInternalType.FinancialAgreement));
					listSheetDefs.Add(SheetsInternal.GetSheetDef(SheetInternalType.HIPAA));
					break;
				case SheetTypeEnum.MedicalHistory:
					//TODO: When there are multiple "internal" sheet defs available for the user to pick,
					//	we need to store the selection made as a string within the clinicpref tables "ValueString" column.
					listSheetDefs.Add(SheetsInternal.GetSheetDef(SheetInternalType.MedicalHistNewPat));
					listSheetDefs.Add(SheetsInternal.GetSheetDef(SheetInternalType.MedicalHistSimple));
					listSheetDefs.Add(SheetsInternal.GetSheetDef(SheetInternalType.MedicalHistUpdate));
					break;
				case SheetTypeEnum.ChartModule:
				case SheetTypeEnum.Consent:
				case SheetTypeEnum.DepositSlip:
				case SheetTypeEnum.ExamSheet:
				case SheetTypeEnum.LabelAppointment:
				case SheetTypeEnum.LabelCarrier:
				case SheetTypeEnum.LabelReferral:
				case SheetTypeEnum.LabSlip:
				case SheetTypeEnum.MedLabResults:
				case SheetTypeEnum.PatientLetter:
				case SheetTypeEnum.PaymentPlan:
				case SheetTypeEnum.ReferralLetter:
				case SheetTypeEnum.ReferralSlip:
				case SheetTypeEnum.RoutingSlip:
				case SheetTypeEnum.Rx:
				case SheetTypeEnum.RxMulti:
				case SheetTypeEnum.Screening:
				case SheetTypeEnum.Statement:
				case SheetTypeEnum.TreatmentPlan:
				default:
					//Sheet types will typically only have one internal example for the user to copy from.
					listSheetDefs.Add(SheetsInternal.GetSheetDef(sheetType));
					break;
			}
			listSheetDefs.AddRange(SheetDefs.GetCustomForType(sheetType));
			comboBox.Items.Clear();
			comboBox.DisplayMember="Description";
			comboBox.ValueMember="SheetDef";
			comboBox.Tag=sheetType;
			if(PrefC.HasClinicsEnabled && comboClinicDefault.SelectedClinicNum!=0) {
				comboBox.Items.Add(new SheetDefWrapper("Default"));
			}
			foreach(SheetDef defCur in listSheetDefs) {
				SheetDefWrapper defNew=new SheetDefWrapper(defCur);
				comboBox.Items.Add(defNew);
				if(defCur.SheetDefNum==PrefC.GetDefaultSheetDefNum(sheetType)) {
					comboBox.SelectedItem=defNew;
				}
			}
			if(comboBox.SelectedIndex==-1 && comboBox.Items.Count>0) {
				comboBox.SelectedIndex=0;
			}
		}

		private void comboClinicDefault_SelectionChangeCommitted(object sender,EventArgs e) {
			UpdateDictSheetsCur();
			_clinicNumCur=comboClinicDefault.SelectedClinicNum;
			FillSheetDefComboBoxes();
			SelectComboBoxes();
		}

		///<summary>Helper to do selection on comboboxes in FormSheetDefDefaults, abstracted to work with any Combobox in the form and any SheetTypeEnum.</summary>
		private void SelectComboBoxes() {
			foreach(ComboBox comboBox in _listSheetTypeComboBoxes) {
				SheetTypeEnum sheetType=(SheetTypeEnum)comboBox.Tag;
				if(_dictSheetsCur.ContainsKey(_clinicNumCur) && _dictSheetsCur[_clinicNumCur].ContainsKey(sheetType)) {
					comboBox.SelectedItem=comboBox.Items.Cast<SheetDefWrapper>()
						.FirstOrDefault(x => (_dictSheetsCur[_clinicNumCur][sheetType]==null ? x.SheetDef==null :
							x.SheetDef!=null && x.SheetDef.SheetDefNum==_dictSheetsCur[_clinicNumCur][sheetType].SheetDefNum));
				}
				else {//Set this combobox value to the base default so that it doesn't default to another clinic's value.
					comboBox.SelectedItem=comboBox.Items.Cast<SheetDefWrapper>()
						.FirstOrDefault(x => x.SheetDef==null);
				}
			}
		}

		private void SyncSheetDefDicts() {
			//bool hasChanged=false;
			//foreach(KeyValuePair<long,Dictionary<SheetTypeEnum,SheetDef>> dictSheetsCurForClinic in _dictSheetsCur) {
			//	if(dictSheetsCurForClinic.Key==0) {//Defaults
			//		Dictionary<SheetTypeEnum,SheetDef> defaultDefNumsOld=_dictSheetsCur[0];//Guaranteed to have the key of 0
			//		foreach(KeyValuePair<SheetTypeEnum,SheetDef> sheetDef in dictSheetsCurForClinic.Value) {
			//			if(defaultDefNumsOld.ContainsKey(sheetDef.Key)) {//Should always happen for defaults
			//				if(Prefs.Set(Prefs.GetSheetDefPref(sheetDef.Key),sheetDef.Value.SheetDefNum)) {
			//					hasChanged=true;
			//				}
			//			}
			//		}
			//	}
			//	else {//Clinic specific
			//		//If this clinic had overrides when this window loaded, check to see if any changes were made.
			//		if(_dictSheetsOld.ContainsKey(dictSheetsCurForClinic.Key)) {
			//			foreach(KeyValuePair<SheetTypeEnum,SheetDef> sheetDef in dictSheetsCurForClinic.Value) {
			//				//If current sheetdef already exists in the db, update
			//				if(_dictSheetsOld[dictSheetsCurForClinic.Key].ContainsKey(sheetDef.Key)) {
			//					//Delete the clinic override if the current Clinic value same as base default
			//					if(sheetDef.Value==null) {
			//						//We know we want to delete because we found this value from _dictSheetsOld which was filled from the database
			//						ClinicPrefs.Delete(ClinicPrefs.GetPref(Prefs.GetSheetDefPref(sheetDef.Key),dictSheetsCurForClinic.Key).ClinicPrefNum);
			//						hasChanged=true;
			//					}
			//					else if(ClinicPrefs.Set(dictSheetsCurForClinic.Key, Prefs.GetSheetDefPref(sheetDef.Key),sheetDef.Value.SheetDefNum)) {
			//						hasChanged=true;
			//					}
			//				}
			//				else {//Current sheetdef doesn't exist in db, insert
			//					if(sheetDef.Value!=null) {//Clinic value different than base default
			//						ClinicPrefs.InsertPref(Prefs.GetSheetDefPref(sheetDef.Key),dictSheetsCurForClinic.Key,POut.Long(sheetDef.Value.SheetDefNum));
			//						hasChanged=true;
			//					}
			//				}
			//			}
			//		}
			//		else {//No clinicprefs exist for the clinic
			//			foreach(KeyValuePair<SheetTypeEnum,SheetDef> sheetDef in dictSheetsCurForClinic.Value) {
			//				//No preferences exist for this clinic, so add all that we have stored from being on on this form.
			//				if(sheetDef.Value!=null) {//Clinic value set to use a specific sheet def instead of default
			//					ClinicPrefs.InsertPref(Prefs.GetSheetDefPref(sheetDef.Key),dictSheetsCurForClinic.Key,POut.Long(sheetDef.Value.SheetDefNum));
			//					hasChanged=true;
			//				}
			//			}
			//		}
			//	}
			//}
			//if(hasChanged) {
			//	DataValid.SetInvalid(InvalidType.Prefs);
			//	DataValid.SetInvalid(InvalidType.ClinicPrefs);
			//}
		}

		private void butOK_Click(object sender,EventArgs e) {
			UpdateDictSheetsCur();
			SyncSheetDefDicts();
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}

		private class SheetDefWrapper {
			public SheetDef SheetDef;
			public string Description { get; private set; }

			public SheetDefWrapper(SheetDef sheetDef) {
				SheetDef=sheetDef;
				Description=SheetDef.Description;
				if(SheetDef.SheetDefNum==0) {
					Description="Internal - "+SheetDef.Description;
				}
			}

			public SheetDefWrapper(string description) {
				SheetDef=null;
				Description=description;
			}

		}

		/*private class ClinicWrapper {
			public Clinic Clinic;
			public string Abbr { get { return Clinic.Abbr; } }

			public ClinicWrapper(Clinic clinic) {
				Clinic=clinic;
			}

			public ClinicWrapper(string abbr) {
				Clinic=new Clinic();
				Clinic.Abbr=abbr;
			}

		}*/
	}
}