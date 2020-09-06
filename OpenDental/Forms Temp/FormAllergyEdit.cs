using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Imedisoft.Data;
using Imedisoft.Data.Models;
using OpenDentBusiness;

namespace OpenDental {
	public partial class FormAllergyEdit:ODForm {
		public Allergy AllergyCur;
		private List<AllergyDef> allergyDefList;
		private Snomed snomedReaction;

		public FormAllergyEdit() {
			InitializeComponent();
			
		}

		private void FormAllergyEdit_Load(object sender,EventArgs e) {
			int allergyIndex=0;
			allergyDefList=AllergyDefs.GetAll(false);
			if(allergyDefList.Count<1) {
				MessageBox.Show("Need to set up at least one Allergy from EHR setup window.");
				DialogResult=DialogResult.Cancel;
				return;
			}
			for(int i=0;i<allergyDefList.Count;i++) {
				comboAllergies.Items.Add(allergyDefList[i].Description);
				if(!AllergyCur.IsNew && allergyDefList[i].Id==AllergyCur.AllergyDefId) {
					allergyIndex=i;
				}
			}
			snomedReaction=Snomeds.GetByCode(AllergyCur.SnomedReaction);
			if(snomedReaction!=null) {
				textSnomedReaction.Text=snomedReaction.Description;
			}
			if(!AllergyCur.IsNew) {
				if(AllergyCur.DateAdverseReaction<DateTime.Parse("01-01-1880")) {
					textDate.Text="";
				}
				else {
					textDate.Text=AllergyCur.DateAdverseReaction.ToShortDateString();
				}
				comboAllergies.SelectedIndex=allergyIndex;
				textReaction.Text=AllergyCur.Reaction;
				checkActive.Checked=AllergyCur.StatusIsActive;
			}
			else {
				comboAllergies.SelectedIndex=0;
			}
		}

		private void butSnomedReactionSelect_Click(object sender,EventArgs e) {
			FormSnomeds formS=new FormSnomeds();
			formS.IsSelectionMode=true;
			if(formS.ShowDialog()==DialogResult.OK) {
				snomedReaction=formS.SelectedSnomed;
				textSnomedReaction.Text=snomedReaction.Description;
			}
		}

		private void butNoneSnomedReaction_Click(object sender,EventArgs e) {
			snomedReaction=null;
			textSnomedReaction.Text="";
		}

		private void butDelete_Click(object sender,EventArgs e) {
			if(AllergyCur.IsNew) {
				DialogResult=DialogResult.Cancel;
				return;
			}
			if(!MsgBox.Show(MsgBoxButtons.OKCancel,"Delete?")){
				return;
			}
			Allergies.Delete(AllergyCur.Id);
			SecurityLogs.MakeLogEntry(Permissions.PatAllergyListEdit,AllergyCur.PatientId,AllergyDefs.GetDescription(AllergyCur.AllergyDefId)+" deleted");
			DialogResult=DialogResult.OK;
		}

		private void butOK_Click(object sender,EventArgs e) {
			//Validate
			if(textDate.Text!="") {
				try {
					DateTime.Parse(textDate.Text);
				}
				catch {
					MessageBox.Show("Please input a valid date.");
					return;
				}
			}
			//Save
			if(textDate.Text!="") {
				AllergyCur.DateAdverseReaction=DateTime.Parse(textDate.Text);
			}
			else {
				AllergyCur.DateAdverseReaction=DateTime.MinValue;
			}
			AllergyCur.AllergyDefId=allergyDefList[comboAllergies.SelectedIndex].Id;
			AllergyCur.Reaction=textReaction.Text;
			AllergyCur.SnomedReaction="";
			if(snomedReaction!=null) {
				AllergyCur.SnomedReaction=snomedReaction.Code;
			}
			AllergyCur.StatusIsActive=checkActive.Checked;
			if(AllergyCur.IsNew) {
				Allergies.Insert(AllergyCur);
				SecurityLogs.MakeLogEntry(Permissions.PatAllergyListEdit,AllergyCur.PatientId,AllergyDefs.GetDescription(AllergyCur.AllergyDefId)+" added");
			}
			else {
				Allergies.Update(AllergyCur);
				SecurityLogs.MakeLogEntry(Permissions.PatAllergyListEdit,AllergyCur.PatientId,AllergyDefs.GetDescription(AllergyCur.AllergyDefId)+" edited");
			}
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}

	}
}