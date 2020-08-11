using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenDental.UI;
using OpenDentBusiness;

namespace OpenDental {
	public partial class FormPendingPayments:ODForm {
		private List<Payment> _listPayments;
		private List<Clinic> _listClinics;
		private Patient[] _arrayPats;

		public FormPendingPayments() {
			InitializeComponent();
			Lan.F(this);
		}

		private void FormPendingOnlinePayments_Load(object sender,EventArgs e) {
			if(PrefC.HasClinicsEnabled) {
				FillClinics();
			}
			else {
				comboClinic.Visible=false;
				labelClinic.Visible=false;
			}
			RefreshPayments();
		}

		private void butRefresh_Click(object sender,EventArgs e) {
			RefreshPayments();
		}

		private void RefreshPayments() {			
			if(PrefC.HasClinicsEnabled && Security.CurrentUser.ClinicIsRestricted) {				
				_listPayments=Payments.GetNeedingProcessed(_listClinics.Select(x => x.ClinicNum).ToList());
			}
			else {
				_listPayments=Payments.GetNeedingProcessed(new List<long>());
			}
			_arrayPats=Patients.GetMultPats(_listPayments.Select(x => x.PatNum).ToList());
			FillGrid();
		}

		private void FillGrid() {
			List<Payment> listPaymentsClinic=new List<Payment>();
			if(PrefC.HasClinicsEnabled && comboClinic.SelectedIndex!=0) {//Not 'All' selected
				if(Security.CurrentUser.ClinicIsRestricted) {
					long clinicNum=_listClinics[comboClinic.SelectedIndex-1].ClinicNum;//Minus 1 for 'All'
					listPaymentsClinic=_listPayments.FindAll(x => x.ClinicNum==clinicNum);
				}
				else {
					if(comboClinic.SelectedIndex==1) {//'Unassigned' selected
						listPaymentsClinic=_listPayments.FindAll(x => x.ClinicNum==0);
					}
					else if(comboClinic.SelectedIndex>1) {
						long clinicNum=_listClinics[comboClinic.SelectedIndex-2].ClinicNum;//Minus 2 for 'All' and 'Unassigned'
						listPaymentsClinic=_listPayments.FindAll(x => x.ClinicNum==clinicNum);
					}
				}
			}
			else {
				listPaymentsClinic=_listPayments;//Use all clinics
			}
			listPaymentsClinic=listPaymentsClinic.OrderBy(x => Clinics.GetAbbr(x.ClinicNum))
				.ThenBy(x => x.PayDate)
				.ThenBy(x => Patients.GetOnePat(_arrayPats,x.PatNum).GetNameLFnoPref()).ToList();
			gridMain.BeginUpdate();
			gridMain.ListGridColumns.Clear();
			GridColumn col;
			if(PrefC.HasClinicsEnabled) {
				col=new GridColumn(Lan.G(this,"Clinic"),100);
				gridMain.ListGridColumns.Add(col);
			}			
			col=new GridColumn(Lan.G(this,"Patient"),110);
			gridMain.ListGridColumns.Add(col);
			col=new GridColumn(Lan.G(this,"Date"),70);
			gridMain.ListGridColumns.Add(col);
			col=new GridColumn(Lan.G(this,"Amount"),70,HorizontalAlignment.Right);
			gridMain.ListGridColumns.Add(col);
			col=new GridColumn(Lan.G(this,"Note"),200);
			gridMain.ListGridColumns.Add(col);
			gridMain.ListGridRows.Clear();
			GridRow row;
			foreach(Payment pay in listPaymentsClinic) {
				row=new GridRow();
				if(PrefC.HasClinicsEnabled) {
					string clinicAbbr=Clinics.GetAbbr(pay.ClinicNum);
					row.Cells.Add(clinicAbbr=="" ? Lan.G(this,"Unassigned") : clinicAbbr );
				}
				row.Cells.Add(Patients.GetOnePat(_arrayPats,pay.PatNum).GetNameLFnoPref());
				row.Cells.Add(pay.PayDate.ToShortDateString());
				row.Cells.Add(pay.PayAmt.ToString("F"));
				row.Cells.Add(pay.PayNote);
				row.Tag=pay;
				gridMain.ListGridRows.Add(row);
			}
			gridMain.EndUpdate();
		}

		public void FillClinics() {
			_listClinics=Clinics.GetForUserod(Security.CurrentUser);
			comboClinic.Items.Add(Lan.G(this,"All"));
			comboClinic.SelectedIndex=0;
			int offset=1;
			if(!Security.CurrentUser.ClinicIsRestricted) {
				comboClinic.Items.Add(Lan.G(this,"Unassigned"));
				offset++;
			}
			_listClinics.ForEach(x => comboClinic.Items.Add(x.Abbr));
			comboClinic.SelectedIndex=_listClinics.FindIndex(x => x.ClinicNum==Clinics.ClinicNum)+offset;
			if(comboClinic.SelectedIndex-offset==-1) {
				comboClinic.SelectedIndex=0;
			}
		}

		private void comboClinic_SelectionChangeCommitted(object sender,EventArgs e) {
			FillGrid();
		}

		private void gridMain_MouseDown(object sender,MouseEventArgs e) {
			if(e.Button==MouseButtons.Right) {
				gridMain.SetSelected(false);
			}
		}

		private void gridMain_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			Payment pay=(Payment)gridMain.ListGridRows[e.Row].Tag;
			Patient pat=Patients.GetOnePat(_arrayPats,pay.PatNum);
			Family fam=Patients.GetFamily(pat.PatNum);
			FormPayment FormP=new FormPayment(pat,fam,pay,false);
			FormP.ShowDialog();
			RefreshPayments();
		}

		private void menuItemGoTo_Click(object sender,EventArgs e) {
			if(gridMain.SelectedIndices.Length==0) {
				MessageBox.Show("Please select one payment first.");
				return;
			}
			long patNum=((Payment)gridMain.ListGridRows[gridMain.SelectedIndices[0]].Tag).PatNum;
			FormOpenDental.S_Contr_PatientSelected(Patients.GetPat(patNum),false);
			GotoModule.GotoAccount(0);
		}

		private void butClose_Click(object sender,EventArgs e) {
			Close();
		}		

		
	}
}