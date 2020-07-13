using System;
using System.Windows.Forms;
using OpenDentBusiness;
using System.Net;
using System.Collections.Generic;
using OpenDental.UI;
using System.Globalization;

namespace OpenDental{
	/// <summary>
	/// Summary description for FormBasicTemplate.
	/// </summary>
	public class FormClearinghouses:ODForm {
		private OpenDental.UI.Button butClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private OpenDental.UI.Button butAdd;
		private GroupBox groupBox1;
		private UI.Button butDefaultMedical;
		private UI.Button butDefaultDental;
		private TextBox textReportCheckInterval;
		private Label labelReportheckUnits;
		private bool listHasChanged;
		private UI.ODGrid gridMain;
		private List<Clearinghouse> _listClearinghousesHq;
		private ComboBoxClinicPicker comboClinic;
		/// <summary>List of all clinic-level clearinghouses for the current clinic.</summary>
		private List<Clearinghouse> _listClearinghousesClinicCur;
		///<summary>List of all clinic-level clearinghouses.</summary>
		private List<Clearinghouse> _listClearinghousesClinicAll;
		private Label labelGuide;
		private UI.Button butEligibility;
		private RadioButton radioInterval;
		private RadioButton radioTime;
		private ValidTime textReportCheckTime;
		private GroupBox groupRecieveSettings;
		private CheckBox checkReceiveReportsService;
		private TextBox textReportComputerName;
		private UI.Button butThisComputer;
		private Label labelReportComputerName;

		///<summary></summary>
		public FormClearinghouses()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			Lan.C(this, new System.Windows.Forms.Control[]
			{
				labelGuide
			});
			Lan.F(this);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClearinghouses));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.butEligibility = new OpenDental.UI.Button();
			this.butDefaultMedical = new OpenDental.UI.Button();
			this.butDefaultDental = new OpenDental.UI.Button();
			this.textReportCheckInterval = new System.Windows.Forms.TextBox();
			this.labelReportheckUnits = new System.Windows.Forms.Label();
			this.butAdd = new OpenDental.UI.Button();
			this.butClose = new OpenDental.UI.Button();
			this.comboClinic = new OpenDental.UI.ComboBoxClinicPicker();
			this.labelGuide = new System.Windows.Forms.Label();
			this.gridMain = new OpenDental.UI.ODGrid();
			this.radioInterval = new System.Windows.Forms.RadioButton();
			this.radioTime = new System.Windows.Forms.RadioButton();
			this.textReportCheckTime = new OpenDental.ValidTime();
			this.groupRecieveSettings = new System.Windows.Forms.GroupBox();
			this.checkReceiveReportsService = new System.Windows.Forms.CheckBox();
			this.textReportComputerName = new System.Windows.Forms.TextBox();
			this.butThisComputer = new OpenDental.UI.Button();
			this.labelReportComputerName = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupRecieveSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.butEligibility);
			this.groupBox1.Controls.Add(this.butDefaultMedical);
			this.groupBox1.Controls.Add(this.butDefaultDental);
			this.groupBox1.Location = new System.Drawing.Point(6, 387);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(97, 112);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Set Default";
			// 
			// butEligibility
			// 
			this.butEligibility.Location = new System.Drawing.Point(15, 79);
			this.butEligibility.Name = "butEligibility";
			this.butEligibility.Size = new System.Drawing.Size(75, 24);
			this.butEligibility.TabIndex = 3;
			this.butEligibility.Text = "Eligibility";
			this.butEligibility.Click += new System.EventHandler(this.butEligibility_Click);
			// 
			// butDefaultMedical
			// 
			this.butDefaultMedical.Location = new System.Drawing.Point(15, 49);
			this.butDefaultMedical.Name = "butDefaultMedical";
			this.butDefaultMedical.Size = new System.Drawing.Size(75, 24);
			this.butDefaultMedical.TabIndex = 2;
			this.butDefaultMedical.Text = "Medical";
			this.butDefaultMedical.Click += new System.EventHandler(this.butDefaultMedical_Click);
			// 
			// butDefaultDental
			// 
			this.butDefaultDental.Location = new System.Drawing.Point(15, 19);
			this.butDefaultDental.Name = "butDefaultDental";
			this.butDefaultDental.Size = new System.Drawing.Size(75, 24);
			this.butDefaultDental.TabIndex = 1;
			this.butDefaultDental.Text = "Dental";
			this.butDefaultDental.Click += new System.EventHandler(this.butDefaultDental_Click);
			// 
			// textReportCheckInterval
			// 
			this.textReportCheckInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textReportCheckInterval.Location = new System.Drawing.Point(237, 66);
			this.textReportCheckInterval.MaxLength = 2147483647;
			this.textReportCheckInterval.Multiline = true;
			this.textReportCheckInterval.Name = "textReportCheckInterval";
			this.textReportCheckInterval.Size = new System.Drawing.Size(29, 20);
			this.textReportCheckInterval.TabIndex = 14;
			// 
			// labelReportheckUnits
			// 
			this.labelReportheckUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelReportheckUnits.Location = new System.Drawing.Point(273, 66);
			this.labelReportheckUnits.Name = "labelReportheckUnits";
			this.labelReportheckUnits.Size = new System.Drawing.Size(128, 20);
			this.labelReportheckUnits.TabIndex = 15;
			this.labelReportheckUnits.Text = "minutes (5 to 60)";
			this.labelReportheckUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// butAdd
			// 
			this.butAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butAdd.Image = global::Imedisoft.Properties.Resources.Add;
			this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAdd.Location = new System.Drawing.Point(805, 385);
			this.butAdd.Name = "butAdd";
			this.butAdd.Size = new System.Drawing.Size(80, 24);
			this.butAdd.TabIndex = 8;
			this.butAdd.Text = "&Add";
			this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
			// 
			// butClose
			// 
			this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butClose.Location = new System.Drawing.Point(805, 466);
			this.butClose.Name = "butClose";
			this.butClose.Size = new System.Drawing.Size(75, 24);
			this.butClose.TabIndex = 0;
			this.butClose.Text = "&Close";
			this.butClose.Click += new System.EventHandler(this.butClose_Click);
			// 
			// comboClinic
			// 
			this.comboClinic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboClinic.HqDescription = "Unassigned/Default";
			this.comboClinic.IncludeUnassigned = true;
			this.comboClinic.Location = new System.Drawing.Point(675, 17);
			this.comboClinic.Name = "comboClinic";
			this.comboClinic.Size = new System.Drawing.Size(210, 21);
			this.comboClinic.TabIndex = 20;
			this.comboClinic.SelectionChangeCommitted += new System.EventHandler(this.comboClinic_SelectionChangeCommitted);
			// 
			// labelGuide
			// 
			this.labelGuide.Location = new System.Drawing.Point(6, -1);
			this.labelGuide.Name = "labelGuide";
			this.labelGuide.Size = new System.Drawing.Size(595, 36);
			this.labelGuide.TabIndex = 22;
			this.labelGuide.Text = resources.GetString("labelGuide.Text");
			this.labelGuide.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// gridMain
			// 
			this.gridMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridMain.Location = new System.Drawing.Point(6, 39);
			this.gridMain.Name = "gridMain";
			this.gridMain.Size = new System.Drawing.Size(879, 340);
			this.gridMain.TabIndex = 17;
			this.gridMain.Title = "Clearinghouses";
			this.gridMain.TranslationName = "TableClearinghouses";
			this.gridMain.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridMain_CellDoubleClick);
			// 
			// radioInterval
			// 
			this.radioInterval.Checked = true;
			this.radioInterval.Location = new System.Drawing.Point(102, 68);
			this.radioInterval.Name = "radioInterval";
			this.radioInterval.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioInterval.Size = new System.Drawing.Size(134, 17);
			this.radioInterval.TabIndex = 25;
			this.radioInterval.TabStop = true;
			this.radioInterval.Text = "Receive at an interval";
			this.radioInterval.UseVisualStyleBackColor = true;
			this.radioInterval.CheckedChanged += new System.EventHandler(this.radioInterval_CheckedChanged);
			// 
			// radioTime
			// 
			this.radioTime.Location = new System.Drawing.Point(102, 90);
			this.radioTime.Name = "radioTime";
			this.radioTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioTime.Size = new System.Drawing.Size(134, 17);
			this.radioTime.TabIndex = 26;
			this.radioTime.Text = "Receive at a set time";
			this.radioTime.UseVisualStyleBackColor = true;
			// 
			// textReportCheckTime
			// 
			this.textReportCheckTime.Enabled = false;
			this.textReportCheckTime.Location = new System.Drawing.Point(237, 89);
			this.textReportCheckTime.Name = "textReportCheckTime";
			this.textReportCheckTime.Size = new System.Drawing.Size(119, 20);
			this.textReportCheckTime.TabIndex = 28;
			// 
			// groupRecieveSettings
			// 
			this.groupRecieveSettings.Controls.Add(this.checkReceiveReportsService);
			this.groupRecieveSettings.Controls.Add(this.textReportComputerName);
			this.groupRecieveSettings.Controls.Add(this.butThisComputer);
			this.groupRecieveSettings.Controls.Add(this.labelReportComputerName);
			this.groupRecieveSettings.Controls.Add(this.radioInterval);
			this.groupRecieveSettings.Controls.Add(this.textReportCheckTime);
			this.groupRecieveSettings.Controls.Add(this.radioTime);
			this.groupRecieveSettings.Controls.Add(this.textReportCheckInterval);
			this.groupRecieveSettings.Controls.Add(this.labelReportheckUnits);
			this.groupRecieveSettings.Location = new System.Drawing.Point(162, 385);
			this.groupRecieveSettings.Name = "groupRecieveSettings";
			this.groupRecieveSettings.Size = new System.Drawing.Size(571, 115);
			this.groupRecieveSettings.TabIndex = 29;
			this.groupRecieveSettings.TabStop = false;
			this.groupRecieveSettings.Text = "Automatic Report Settings";
			// 
			// checkReceiveReportsService
			// 
			this.checkReceiveReportsService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkReceiveReportsService.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkReceiveReportsService.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkReceiveReportsService.Location = new System.Drawing.Point(22, 17);
			this.checkReceiveReportsService.Name = "checkReceiveReportsService";
			this.checkReceiveReportsService.Size = new System.Drawing.Size(227, 17);
			this.checkReceiveReportsService.TabIndex = 32;
			this.checkReceiveReportsService.TabStop = false;
			this.checkReceiveReportsService.Text = "Receive Reports by Service";
			this.checkReceiveReportsService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkReceiveReportsService.CheckedChanged += new System.EventHandler(this.checkReceiveReportsService_CheckedChanged);
			// 
			// textReportComputerName
			// 
			this.textReportComputerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textReportComputerName.Location = new System.Drawing.Point(237, 39);
			this.textReportComputerName.MaxLength = 2147483647;
			this.textReportComputerName.Multiline = true;
			this.textReportComputerName.Name = "textReportComputerName";
			this.textReportComputerName.Size = new System.Drawing.Size(239, 20);
			this.textReportComputerName.TabIndex = 29;
			// 
			// butThisComputer
			// 
			this.butThisComputer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butThisComputer.Location = new System.Drawing.Point(479, 37);
			this.butThisComputer.Name = "butThisComputer";
			this.butThisComputer.Size = new System.Drawing.Size(86, 24);
			this.butThisComputer.TabIndex = 31;
			this.butThisComputer.Text = "This Computer";
			this.butThisComputer.Click += new System.EventHandler(this.butThisComputer_Click);
			// 
			// labelReportComputerName
			// 
			this.labelReportComputerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelReportComputerName.Location = new System.Drawing.Point(6, 39);
			this.labelReportComputerName.Name = "labelReportComputerName";
			this.labelReportComputerName.Size = new System.Drawing.Size(228, 20);
			this.labelReportComputerName.TabIndex = 30;
			this.labelReportComputerName.Text = "Computer To Receive Reports Automatically";
			this.labelReportComputerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FormClearinghouses
			// 
			this.ClientSize = new System.Drawing.Size(891, 503);
			this.Controls.Add(this.groupRecieveSettings);
			this.Controls.Add(this.labelGuide);
			this.Controls.Add(this.comboClinic);
			this.Controls.Add(this.gridMain);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.butAdd);
			this.Controls.Add(this.butClose);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(850, 500);
			this.Name = "FormClearinghouses";
			this.ShowInTaskbar = false;
			this.Text = "Clearinghouses";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormClearinghouses_Closing);
			this.Load += new System.EventHandler(this.FormClearinghouses_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupRecieveSettings.ResumeLayout(false);
			this.groupRecieveSettings.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		private void FormClearinghouses_Load(object sender, System.EventArgs e) {
			textReportComputerName.Text=PrefC.GetString(PrefName.ClaimReportComputerName);
			int claimReportReceiveInterval=PrefC.GetInt(PrefName.ClaimReportReceiveInterval);
			checkReceiveReportsService.Checked=PrefC.GetBool(PrefName.ClaimReportReceivedByService);
			_listClearinghousesHq=Clearinghouses.GetDeepCopy(true);
			_listClearinghousesClinicAll=Clearinghouses.GetAllNonHq();
			_listClearinghousesClinicCur=new List<Clearinghouse>();
			comboClinic.SelectedClinicNum=Clinics.ClinicNum;
			if(CultureInfo.CurrentCulture.Name.EndsWith("CA")) {
				butEligibility.Visible=false;
			}
			FillGrid();
			if(claimReportReceiveInterval==0) {
				radioTime.Checked=true;
				DateTime fullDateTime=PrefC.GetDateT(PrefName.ClaimReportReceiveTime);
				textReportCheckTime.Text=fullDateTime.ToShortTimeString();
			}
			else {
				textReportCheckInterval.Text=POut.Int(claimReportReceiveInterval);
				radioInterval.Checked=true;
			}
		}

		private void FillGrid(){
			_listClearinghousesClinicCur.Clear();
			for(int i=0;i<_listClearinghousesClinicAll.Count;i++) {
				if(_listClearinghousesClinicAll[i].ClinicNum==comboClinic.SelectedClinicNum) {
					_listClearinghousesClinicCur.Add(_listClearinghousesClinicAll[i]);
				}
			}
			gridMain.BeginUpdate();
			gridMain.ListGridColumns.Clear();
			GridColumn col=new GridColumn(Lan.G(this,"Description"),150);
			gridMain.ListGridColumns.Add(col);
			col=new GridColumn(Lan.G(this,"Export Path"),230);
			gridMain.ListGridColumns.Add(col);
			col=new GridColumn(Lan.G(this,"Format"),110);
			gridMain.ListGridColumns.Add(col);
			col=new GridColumn(Lan.G(this,"Is Default"),60);
			gridMain.ListGridColumns.Add(col);
			col=new GridColumn(Lan.G(this,"Payors"),80){ IsWidthDynamic=true };//310
			gridMain.ListGridColumns.Add(col);
			gridMain.ListGridRows.Clear();
			GridRow row;
			for(int i=0;i<_listClearinghousesHq.Count;i++) {
				Clearinghouse[] listClearinghouseTag=new Clearinghouse[3];//[0]=clearinghouseHq, [1]=clearinghouseClinic, [2]=clearinghouseCur per ODGridRow
				listClearinghouseTag[0]=_listClearinghousesHq[i].Copy(); //clearinghousehq.
				listClearinghouseTag[2]=_listClearinghousesHq[i].Copy();//clearinghouseCur. will be clearinghouseHq if clearinghouseClinic doesn't exist.
				for(int j=0;j<_listClearinghousesClinicCur.Count;j++) {
					if(_listClearinghousesClinicCur[j].HqClearinghouseNum==_listClearinghousesHq[i].ClearinghouseNum) {
						listClearinghouseTag[1]=_listClearinghousesClinicCur[j];//clearinghouseClin
						listClearinghouseTag[2]=Clearinghouses.OverrideFields(_listClearinghousesHq[i],_listClearinghousesClinicCur[j]);
						break;
					}
				}
				Clearinghouse clearinghouseCur=listClearinghouseTag[2];
				row=new GridRow();
				row.Tag=listClearinghouseTag;
				row.Cells.Add(clearinghouseCur.Description);
				row.Cells.Add(clearinghouseCur.ExportPath);
				row.Cells.Add(clearinghouseCur.Eformat.ToString());
				string s="";
				if(PrefC.GetLong(PrefName.ClearinghouseDefaultDent)==_listClearinghousesHq[i].ClearinghouseNum) {
					s+="Dent";
				}
				if(PrefC.GetLong(PrefName.ClearinghouseDefaultMed)==_listClearinghousesHq[i].ClearinghouseNum) {
					if(s!="") {
						s+=",";
					}
					s+="Med";
				}
				if(PrefC.GetLong(PrefName.ClearinghouseDefaultEligibility)==_listClearinghousesHq[i].ClearinghouseNum 
					&& !CultureInfo.CurrentCulture.Name.EndsWith("CA")) //Canadian. en-CA or fr-CA
				{
					if(s!="") {
						s+=",";
					}
					s+="Elig";
				}
				row.Cells.Add(s);
				row.Cells.Add(clearinghouseCur.Payors);
				gridMain.ListGridRows.Add(row);
			}
			gridMain.EndUpdate();
		}

		private void gridMain_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			Clearinghouse clearinghouseHq=((Clearinghouse[])(gridMain.ListGridRows[e.Row].Tag))[0].Copy();//cannot be null
			FormClearinghouseEdit FormCE=new FormClearinghouseEdit();
			FormCE.ClearinghouseHq=clearinghouseHq;
			FormCE.ClearinghouseHqOld=clearinghouseHq.Copy(); //cannot be null
			FormCE.ClinicNum=comboClinic.SelectedClinicNum;//_selectedClinicNum;
			FormCE.ListClearinghousesClinCur=new List<Clearinghouse>();
			FormCE.ListClearinghousesClinOld=new List<Clearinghouse>();
			for(int i=0;i<_listClearinghousesClinicAll.Count;i++) {
				if(_listClearinghousesClinicAll[i].HqClearinghouseNum==clearinghouseHq.ClearinghouseNum) {
					FormCE.ListClearinghousesClinCur.Add(_listClearinghousesClinicAll[i].Copy());
					FormCE.ListClearinghousesClinOld.Add(_listClearinghousesClinicAll[i].Copy());
				}
			}
			FormCE.ShowDialog();
			if(FormCE.DialogResult!=DialogResult.OK) {
				return;
			}
			if(FormCE.ClearinghouseCur==null) {//Clearinghouse was deleted.  Can only be deleted when HQ selected.
				_listClearinghousesHq.RemoveAt(e.Row); //no need to update the nonHq list.
			}
			else { //Not deleted.  Both the non-HQ and HQ lists need to be updated.
				_listClearinghousesHq[e.Row]=FormCE.ClearinghouseHq; //update Hq Clearinghouse.
				//Update the clinical clearinghouse list by deleting all of the entries for the selected clearinghouse,
				_listClearinghousesClinicAll.RemoveAll(x => x.HqClearinghouseNum==clearinghouseHq.ClearinghouseNum);
				//then adding the updated versions back to the list.
				_listClearinghousesClinicAll.AddRange(FormCE.ListClearinghousesClinCur);
			}
			listHasChanged=true;
			FillGrid();
		}

		private void butAdd_Click(object sender, System.EventArgs e) {
			FormClearinghouseEdit FormCE=new FormClearinghouseEdit();
			FormCE.ClearinghouseHq=new Clearinghouse();
			FormCE.ClearinghouseHqOld=new Clearinghouse();
			FormCE.ClinicNum=0;
			FormCE.ListClearinghousesClinCur=new List<Clearinghouse>();
			FormCE.ListClearinghousesClinOld=new List<Clearinghouse>();
			FormCE.IsNew=true;
			FormCE.ShowDialog();
			if(FormCE.DialogResult!=DialogResult.OK) {
				return;
			}
			if(FormCE.ClearinghouseCur!=null) { //clearinghouse was not deleted
				_listClearinghousesHq.Add(FormCE.ClearinghouseHq.Copy());
				_listClearinghousesClinicAll.AddRange(FormCE.ListClearinghousesClinCur);
			}
			listHasChanged=true;
			FillGrid();
		}

		private void butDefaultDental_Click(object sender,EventArgs e) {
			if(gridMain.GetSelectedIndex()==-1){
				MessageBox.Show("Please select a row first.");
				return;
			}
			Clearinghouse ch=_listClearinghousesHq[gridMain.GetSelectedIndex()];
			if(ch.Eformat==ElectronicClaimFormat.x837_5010_med_inst){//med/inst clearinghouse
				MessageBox.Show("The selected clearinghouse must first be set to a dental e-claim format.");
				return;
			}
			bool isInvalid=false;
			if(!CultureInfo.CurrentCulture.Name.EndsWith("CA") 
				&& PrefC.GetLong(PrefName.ClearinghouseDefaultEligibility)==0
				&& Prefs.UpdateLong(PrefName.ClearinghouseDefaultEligibility,ch.ClearinghouseNum)) 
			{
				isInvalid=true;
			}
			if(Prefs.UpdateLong(PrefName.ClearinghouseDefaultDent,ch.ClearinghouseNum)) {
				isInvalid=true;
			}
			if(isInvalid) {
				DataValid.SetInvalid(InvalidType.Prefs);
			}
			FillGrid();
		}

		private void butDefaultMedical_Click(object sender,EventArgs e) {
			if(gridMain.GetSelectedIndex()==-1) {
				MessageBox.Show("Please select a row first.");
				return;
			}
			Clearinghouse ch=_listClearinghousesHq[gridMain.GetSelectedIndex()];
			if(ch.Eformat!=ElectronicClaimFormat.x837_5010_med_inst){//anything except the med/inst format
				MessageBox.Show("The selected clearinghouse must first be set to the med/inst e-claim format.");
				return;
			}
			bool isInvalid=false;
			if(!CultureInfo.CurrentCulture.Name.EndsWith("CA") 
				&& PrefC.GetLong(PrefName.ClearinghouseDefaultEligibility)==0
				&& Prefs.UpdateLong(PrefName.ClearinghouseDefaultEligibility,ch.ClearinghouseNum)) 
			{
				isInvalid=true;
			}
			if(Prefs.UpdateLong(PrefName.ClearinghouseDefaultMed,ch.ClearinghouseNum)) {
				isInvalid=true;
			}
			if(isInvalid) {
				DataValid.SetInvalid(InvalidType.Prefs);
			}
			FillGrid();
		}

		private void butEligibility_Click(object sender,EventArgs e) {
			if(gridMain.GetSelectedIndex()==-1){
					MessageBox.Show("Please select a row first.");
					return;
			}
			Clearinghouse ch=_listClearinghousesHq[gridMain.GetSelectedIndex()];
			if(Prefs.UpdateLong(PrefName.ClearinghouseDefaultEligibility,ch.ClearinghouseNum)) {
				DataValid.SetInvalid(InvalidType.Prefs);
			}
			FillGrid();
		}

		private void checkReceiveReportsService_CheckedChanged(object sender,EventArgs e) {
			if(checkReceiveReportsService.Checked) {
				textReportComputerName.Enabled=false;
				butThisComputer.Enabled=false;
			}
			else {
				textReportComputerName.Enabled=true;
				butThisComputer.Enabled=true;
			}
		}

		private void radioInterval_CheckedChanged(object sender,EventArgs e) {
			if(radioInterval.Checked) {
				labelReportheckUnits.Enabled=true;
				textReportCheckInterval.Enabled=true;
				textReportCheckTime.Text="";
				textReportCheckTime.Enabled=false;
				textReportCheckTime.ClearError();
			}
			else {
				labelReportheckUnits.Enabled=false;
				textReportCheckInterval.Text="";
				textReportCheckInterval.Enabled=false;
				textReportCheckTime.Enabled=true;
			}
		}

		private void butThisComputer_Click(object sender,EventArgs e) {
			textReportComputerName.Text=Dns.GetHostName();
		}

		private void butClose_Click(object sender, System.EventArgs e) {
			if(textReportComputerName.Text.Trim().ToLower()=="localhost" || textReportComputerName.Text.Trim()=="127.0.0.1") {
				MessageBox.Show("Computer name to fetch new reports from cannot be localhost or 127.0.0.1 or any other loopback address.");
				return;
			}
			int reportCheckIntervalMinuteCount=0;
			try {
				reportCheckIntervalMinuteCount=PIn.Int(textReportCheckInterval.Text);
				if(textReportCheckInterval.Enabled && (reportCheckIntervalMinuteCount<5 || reportCheckIntervalMinuteCount>60)) {
					throw new ApplicationException("Invalid value.");//User never sees this message.
				}
			}
			catch {
				MessageBox.Show("Report check interval must be between 5 and 60 inclusive.");
				return;
			}
			if(radioTime.Checked && (textReportCheckTime.Text=="" || !textReportCheckTime.IsValid)) {
				MessageBox.Show("Please enter a time to receive reports.");
				return;
			}
			bool doRestartToShowChanges=false;
			bool doInvalidateCache=false;
			if(Prefs.UpdateString(PrefName.ClaimReportComputerName,textReportComputerName.Text)) {
				doRestartToShowChanges=true;
				//No point in invalidating prefs since this only affects a workstation on startup.
			}
			if(Prefs.UpdateInt(PrefName.ClaimReportReceiveInterval,reportCheckIntervalMinuteCount)) {
				doInvalidateCache=true;
			}
			if(radioTime.Checked) {
				if(Prefs.UpdateDateT(PrefName.ClaimReportReceiveTime,PIn.DateT(textReportCheckTime.Text))) {
					doInvalidateCache=true;
				}
			}
			else if(textReportCheckTime.Text=="" && Prefs.UpdateDateT(PrefName.ClaimReportReceiveTime,DateTime.MinValue)) {
				doInvalidateCache=true;
			}
			if(Prefs.UpdateBool(PrefName.ClaimReportReceivedByService,checkReceiveReportsService.Checked)) {
				if(checkReceiveReportsService.Checked) {
					doInvalidateCache=true;
				}
				else {
					doRestartToShowChanges=true;
				}
			}
			if(doRestartToShowChanges) {
				MessageBox.Show("You will need to restart the program for changes to take effect.");
			}
			if(doInvalidateCache) {
				DataValid.SetInvalid(InvalidType.Prefs);
			}
			Close();
		}

		private void FormClearinghouses_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			if(PrefC.GetLong(PrefName.ClearinghouseDefaultDent)==0){
				if(!MsgBox.Show(MsgBoxButtons.OKCancel,"A default clearinghouse should be set. Continue anyway?")){
					e.Cancel=true;
					return;
				}
			}
			if(listHasChanged) {
				//update all computers including this one:
				DataValid.SetInvalid(InvalidType.ClearHouses);  //This needs to be done before the cache calls below.
			}
			//validate that the default dental clearinghouse is not type mismatched.
			Clearinghouse chDent=Clearinghouses.GetClearinghouse(PrefC.GetLong(PrefName.ClearinghouseDefaultDent));
			if(chDent!=null) {
				if(chDent.Eformat==ElectronicClaimFormat.x837_5010_med_inst) {//mismatch
					if(!MsgBox.Show(MsgBoxButtons.OKCancel,"The default dental clearinghouse should be set to a dental e-claim format.  Continue anyway?")) {
						e.Cancel=true;
						return;
					}
				}
			}
			//validate medical clearinghouse
			Clearinghouse chMed=Clearinghouses.GetClearinghouse(PrefC.GetLong(PrefName.ClearinghouseDefaultMed));
			if(chMed!=null) {
				if(chMed.Eformat!=ElectronicClaimFormat.x837_5010_med_inst) {//mismatch
					if(!MsgBox.Show(MsgBoxButtons.OKCancel,"The default medical clearinghouse should be set to a med/inst e-claim format.  Continue anyway?")) {
						e.Cancel=true;
						return;
					}
				}
			}
		}

		private void comboClinic_SelectionChangeCommitted(object sender,EventArgs e) {
			FillGrid();
		}

	}
}





















