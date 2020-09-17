using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using OpenDental.UI;
using OpenDentBusiness;
using System.Linq;
using CodeBase;

namespace OpenDental{
	/// <summary>
	/// Summary description for FormBasicTemplate.
	/// </summary>
	public class FormFeeScheds:ODForm {
		private OpenDental.UI.Button butAdd;
		private OpenDental.UI.Button butClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private OpenDental.UI.ODGrid gridMain;
		private ListBox listType;
		private OpenDental.UI.Button butDown;
		private OpenDental.UI.Button butUp;
		private FeeSchedule _feeSchedToMove;
		private GroupBox groupBox7;
		private OpenDental.UI.Button butIns;
		private Label label6;
		private Label label1;
		private OpenDental.UI.Button butSort;
		private Label labelSort;
		private Label labelCleanUp;
		private UI.Button butCleanUp;
		private List<FeeSchedule> _listFeeSchedsForType;
		private bool _hasChanged=false;
		private bool _isSelectionMode;
		private UI.Button butOK;
		public long SelectedFeeSchedNum;
		private Label labelHideUnused;
		private UI.Button butHideUnused;
		private System.Windows.Forms.Button butSetOrder;
		private Label labelSetOrder;
		///<summary>Is in middle of moving a row to a new Order, and the second click in the grid will finish the job.</summary>
		private bool _IsMovingToOrder=false;

		///<summary>If IsSelectionMode then is a list of all non-hidden fee schedules.  Otherwise, uses the cache deep copy.</summary>
		private List<FeeSchedule> _listFeeScheds;

		///<summary></summary>
		public FormFeeScheds(bool isSelectionMode=true)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			_isSelectionMode=isSelectionMode;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFeeScheds));
			this.butOK = new OpenDental.UI.Button();
			this.labelCleanUp = new System.Windows.Forms.Label();
			this.butCleanUp = new OpenDental.UI.Button();
			this.labelSort = new System.Windows.Forms.Label();
			this.butSort = new OpenDental.UI.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.butIns = new OpenDental.UI.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.butDown = new OpenDental.UI.Button();
			this.butUp = new OpenDental.UI.Button();
			this.listType = new System.Windows.Forms.ListBox();
			this.gridMain = new OpenDental.UI.ODGrid();
			this.butAdd = new OpenDental.UI.Button();
			this.butClose = new OpenDental.UI.Button();
			this.labelHideUnused = new System.Windows.Forms.Label();
			this.butHideUnused = new OpenDental.UI.Button();
			this.butSetOrder = new System.Windows.Forms.Button();
			this.labelSetOrder = new System.Windows.Forms.Label();
			this.groupBox7.SuspendLayout();
			this.SuspendLayout();
			// 
			// butOK
			// 
			this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butOK.Location = new System.Drawing.Point(412, 570);
			this.butOK.Name = "butOK";
			this.butOK.Size = new System.Drawing.Size(75, 24);
			this.butOK.TabIndex = 23;
			this.butOK.Text = "&OK";
			this.butOK.Visible = false;
			this.butOK.Click += new System.EventHandler(this.butOK_Click);
			// 
			// labelCleanUp
			// 
			this.labelCleanUp.Location = new System.Drawing.Point(315, 455);
			this.labelCleanUp.Name = "labelCleanUp";
			this.labelCleanUp.Size = new System.Drawing.Size(161, 36);
			this.labelCleanUp.TabIndex = 22;
			this.labelCleanUp.Text = "Deletes any allowed fee schedules that are not in use.";
			// 
			// butCleanUp
			// 
			this.butCleanUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butCleanUp.Location = new System.Drawing.Point(318, 428);
			this.butCleanUp.Name = "butCleanUp";
			this.butCleanUp.Size = new System.Drawing.Size(99, 24);
			this.butCleanUp.TabIndex = 21;
			this.butCleanUp.Text = "Clean Up Allowed";
			this.butCleanUp.Click += new System.EventHandler(this.butCleanUp_Click);
			// 
			// labelSort
			// 
			this.labelSort.Location = new System.Drawing.Point(315, 321);
			this.labelSort.Name = "labelSort";
			this.labelSort.Size = new System.Drawing.Size(123, 44);
			this.labelSort.TabIndex = 20;
			this.labelSort.Text = "Sorts by type and alphabetically";
			// 
			// butSort
			// 
			this.butSort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSort.Location = new System.Drawing.Point(318, 294);
			this.butSort.Name = "butSort";
			this.butSort.Size = new System.Drawing.Size(75, 24);
			this.butSort.TabIndex = 19;
			this.butSort.Text = "Sort";
			this.butSort.Click += new System.EventHandler(this.butSort_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(315, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 18);
			this.label1.TabIndex = 18;
			this.label1.Text = "Type";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.butIns);
			this.groupBox7.Controls.Add(this.label6);
			this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox7.Location = new System.Drawing.Point(17, 570);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(340, 58);
			this.groupBox7.TabIndex = 17;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Check Ins Plan Fee Schedules";
			// 
			// butIns
			// 
			this.butIns.Location = new System.Drawing.Point(248, 19);
			this.butIns.Name = "butIns";
			this.butIns.Size = new System.Drawing.Size(75, 24);
			this.butIns.TabIndex = 4;
			this.butIns.Text = "Go";
			this.butIns.Click += new System.EventHandler(this.butIns_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(229, 39);
			this.label6.TabIndex = 5;
			this.label6.Text = "This tool will help make sure your insurance plans have the right fee schedules s" +
    "et.";
			// 
			// butDown
			// 
			this.butDown.Image = global::Imedisoft.Properties.Resources.down;
			this.butDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butDown.Location = new System.Drawing.Point(318, 157);
			this.butDown.Name = "butDown";
			this.butDown.Size = new System.Drawing.Size(75, 24);
			this.butDown.TabIndex = 16;
			this.butDown.Text = "&Down";
			this.butDown.Click += new System.EventHandler(this.butDown_Click);
			// 
			// butUp
			// 
			
			this.butUp.Image = global::Imedisoft.Properties.Resources.up;
			this.butUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butUp.Location = new System.Drawing.Point(318, 125);
			this.butUp.Name = "butUp";
			this.butUp.Size = new System.Drawing.Size(75, 24);
			this.butUp.TabIndex = 15;
			this.butUp.Text = "&Up";
			this.butUp.Click += new System.EventHandler(this.butUp_Click);
			// 
			// listType
			// 
			this.listType.FormattingEnabled = true;
			this.listType.Location = new System.Drawing.Point(318, 26);
			this.listType.Name = "listType";
			this.listType.Size = new System.Drawing.Size(120, 69);
			this.listType.TabIndex = 12;
			this.listType.Click += new System.EventHandler(this.listType_Click);
			// 
			// gridMain
			// 
			this.gridMain.Location = new System.Drawing.Point(17, 12);
			this.gridMain.Name = "gridMain";
			this.gridMain.Size = new System.Drawing.Size(278, 552);
			this.gridMain.TabIndex = 11;
			this.gridMain.Title = "FeeSchedules";
			this.gridMain.TranslationName = "TableFeeScheds";
			this.gridMain.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridMain_CellDoubleClick);
			this.gridMain.CellClick += new OpenDental.UI.ODGridClickEventHandler(this.gridMain_CellClick);
			// 
			// butAdd
			// 
			this.butAdd.Image = global::Imedisoft.Properties.Resources.Add;
			this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butAdd.Location = new System.Drawing.Point(318, 381);
			this.butAdd.Name = "butAdd";
			this.butAdd.Size = new System.Drawing.Size(75, 24);
			this.butAdd.TabIndex = 10;
			this.butAdd.Text = "&Add";
			this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
			// 
			// butClose
			// 
			this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butClose.Location = new System.Drawing.Point(412, 604);
			this.butClose.Name = "butClose";
			this.butClose.Size = new System.Drawing.Size(75, 24);
			this.butClose.TabIndex = 0;
			this.butClose.Text = "&Close";
			this.butClose.Click += new System.EventHandler(this.butClose_Click);
			// 
			// labelHideUnused
			// 
			this.labelHideUnused.Location = new System.Drawing.Point(315, 521);
			this.labelHideUnused.Name = "labelHideUnused";
			this.labelHideUnused.Size = new System.Drawing.Size(161, 36);
			this.labelHideUnused.TabIndex = 25;
			this.labelHideUnused.Text = "Hides any fee schedules that are not in use";
			// 
			// butHideUnused
			// 
			this.butHideUnused.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHideUnused.Location = new System.Drawing.Point(318, 494);
			this.butHideUnused.Name = "butHideUnused";
			this.butHideUnused.Size = new System.Drawing.Size(99, 24);
			this.butHideUnused.TabIndex = 22;
			this.butHideUnused.Text = "Hide Unused";
			this.butHideUnused.Click += new System.EventHandler(this.butHideUnused_Click);
			// 
			// butSetOrder
			// 
			this.butSetOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSetOrder.Location = new System.Drawing.Point(318, 205);
			this.butSetOrder.Name = "butSetOrder";
			this.butSetOrder.Size = new System.Drawing.Size(75, 24);
			this.butSetOrder.TabIndex = 26;
			this.butSetOrder.Text = "Set Order";
			this.butSetOrder.Click += new System.EventHandler(this.butSetOrder_Click);
			// 
			// labelSetOrder
			// 
			this.labelSetOrder.Location = new System.Drawing.Point(394, 198);
			this.labelSetOrder.Name = "labelSetOrder";
			this.labelSetOrder.Size = new System.Drawing.Size(123, 44);
			this.labelSetOrder.TabIndex = 27;
			this.labelSetOrder.Text = "1. Select row to move.\r\n2. Toggle this button.\r\n3. Click new position.";
			// 
			// FormFeeScheds
			// 
			this.ClientSize = new System.Drawing.Size(515, 644);
			this.Controls.Add(this.labelSetOrder);
			this.Controls.Add(this.butSetOrder);
			this.Controls.Add(this.labelHideUnused);
			this.Controls.Add(this.butHideUnused);
			this.Controls.Add(this.butOK);
			this.Controls.Add(this.labelCleanUp);
			this.Controls.Add(this.butCleanUp);
			this.Controls.Add(this.labelSort);
			this.Controls.Add(this.butSort);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.butDown);
			this.Controls.Add(this.butUp);
			this.Controls.Add(this.listType);
			this.Controls.Add(this.gridMain);
			this.Controls.Add(this.butAdd);
			this.Controls.Add(this.butClose);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormFeeScheds";
			this.ShowInTaskbar = false;
			this.Text = "Fee Schedules";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFeeSchedules_FormClosing);
			this.Load += new System.EventHandler(this.FormFeeSchedules_Load);
			this.groupBox7.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormFeeSchedules_Load(object sender, System.EventArgs e) {
			_listFeeScheds=FeeScheds.GetDeepCopy(_isSelectionMode);
			CheckItemOrders();
			listType.Items.Add("All");
			Array arrayValues=Enum.GetValues(typeof(FeeScheduleType));
			for(int i=0;i<arrayValues.Length;i++) {
				FeeScheduleType feeSchedType=((FeeScheduleType)arrayValues.GetValue(i));
				if(feeSchedType==FeeScheduleType.OutNetwork) {
					listType.Items.Add("Out of Network");
				}
				else {
					listType.Items.Add(arrayValues.GetValue(i).ToString());
				}
			}
			listType.SelectedIndex=0;
			if(!Security.IsAuthorized(Permissions.SecurityAdmin,true)){
				butCleanUp.Visible=false;
				labelCleanUp.Visible=false;
				butHideUnused.Visible=false;
				labelHideUnused.Visible=false;
			}
			if(_isSelectionMode) {
				butOK.Visible=true;
				butClose.Text="Cancel";
				butUp.Visible=false;
				butDown.Visible=false;
				butSort.Visible=false;
				labelSort.Visible=false;
				butAdd.Visible=false;
				butCleanUp.Visible=false;
				labelCleanUp.Visible=false;
				butHideUnused.Visible=false;
				labelHideUnused.Visible=false;
				groupBox7.Visible=false;
				butSetOrder.Visible=false;
				labelSetOrder.Visible=false;
			}
			FillGrid();
		}

		///<summary>Also fixes if any errors found.</summary>
		private void CheckItemOrders() {
			Cursor=Cursors.WaitCursor;
			bool ordersChanges=false;
			_listFeeScheds.Sort(CompareItemOrder);
			for(int i=0;i<_listFeeScheds.Count;i++) {
				if(_listFeeScheds[i].SortOrder==i) {
					continue;
				}
				ordersChanges=true;
				_hasChanged=true;
				break;
			}
			if(ordersChanges) {
				FeeScheds.CorrectFeeSchedOrder();
				FeeScheds.RefreshCache();
				_listFeeScheds=FeeScheds.GetDeepCopy(_isSelectionMode);
			}
			Cursor=Cursors.Default;
		}

		private void FillGrid(){
			if(listType.SelectedIndex==0){ //All option
				_listFeeSchedsForType=_listFeeScheds;
			}
			else{
				_listFeeSchedsForType=FeeScheds.GetListForType((FeeScheduleType)(listType.SelectedIndex-1),true,_listFeeScheds);
			}
			_listFeeSchedsForType.Sort(CompareItemOrder);
			gridMain.BeginUpdate();
			gridMain.Columns.Clear();
			GridColumn col=new GridColumn("Description",145);
			gridMain.Columns.Add(col);
			col=new GridColumn("Type",70);
			gridMain.Columns.Add(col);
			col=new GridColumn("Hidden",60,HorizontalAlignment.Center);
			gridMain.Columns.Add(col);
			gridMain.Rows.Clear();
			GridRow row;
			for(int i=0;i<_listFeeSchedsForType.Count;i++){
				if(_isSelectionMode && _listFeeSchedsForType[i].IsHidden) {
					continue;
				}
				row=new GridRow();
				row.Tag=_listFeeSchedsForType[i];
				row.Cells.Add(_listFeeSchedsForType[i].Description);
				row.Cells.Add(_listFeeSchedsForType[i].Type.ToString());
				if(_listFeeSchedsForType[i].IsHidden){
					row.Cells.Add("X");
				}
				else{
					row.Cells.Add("");
				}
				gridMain.Rows.Add(row);
			}
			gridMain.EndUpdate();
		}

		private void butAdd_Click(object sender, System.EventArgs e) {
			FormFeeSchedEdit FormF=new FormFeeSchedEdit();
			FormF.FeeSchedCur=new FeeSchedule();
			FormF.FeeSchedCur.IsNew=true;
			FormF.FeeSchedCur.SortOrder=_listFeeScheds.Count;
			FormF.ListFeeScheds=_listFeeScheds;
			if(listType.SelectedIndex>0){
				FormF.FeeSchedCur.Type=(FeeScheduleType)(listType.SelectedIndex-1);
			}
			FormF.ShowDialog();
			if(FormF.DialogResult!=DialogResult.OK) {
				return;
			}
			FeeScheds.Insert(FormF.FeeSchedCur);
			FillGrid();
			_hasChanged=true;
			for(int i=0;i<_listFeeSchedsForType.Count;i++){
				if(FormF.FeeSchedCur.Id==_listFeeSchedsForType[i].Id){
					gridMain.SetSelected(i,true);
				}
			}
		}

		private void gridMain_CellClick(object sender,ODGridClickEventArgs e) {
			int idx=e.Row;
			if(!_IsMovingToOrder) {
				return;
			}
			FeeScheds.RepositionFeeSched(_feeSchedToMove,_listFeeSchedsForType[idx].SortOrder);
			FeeScheds.RefreshCache();
			_listFeeScheds=FeeScheds.GetDeepCopy();
			FillGrid();
			gridMain.SetSelected(idx,true);
			_IsMovingToOrder=false;
			_hasChanged=true;
			butSetOrder.BackColor=SystemColors.Control;
		}

		private void gridMain_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			if(_isSelectionMode) {
				SelectedFeeSchedNum=((FeeSchedule)gridMain.Rows[e.Row].Tag).Id;
				DialogResult=DialogResult.OK;
				Close();
				return;
			}
			FeeSchedule feeSchedOld;
			FormFeeSchedEdit FormF=new FormFeeSchedEdit();
			FormF.FeeSchedCur=_listFeeSchedsForType[e.Row];
			FormF.ListFeeScheds=_listFeeScheds;
			feeSchedOld=FormF.FeeSchedCur.Copy();//Copy to compare for changes once FormFeeSchedEdit has closed
			FormF.ShowDialog();
			if(FormF.DialogResult!=DialogResult.OK || feeSchedOld.Description==FormF.FeeSchedCur.Description
				&& feeSchedOld.Type==FormF.FeeSchedCur.Type
				&& feeSchedOld.IsHidden==FormF.FeeSchedCur.IsHidden
				&& feeSchedOld.IsGlobal==FormF.FeeSchedCur.IsGlobal)
			{
				return;
			}
			FeeScheds.Update(FormF.FeeSchedCur);
			FeeScheds.RefreshCache();
			_listFeeScheds=FeeScheds.GetDeepCopy();
			_hasChanged=true;
			FillGrid();
			for(int i=0;i<_listFeeSchedsForType.Count;i++){
				if(FormF.FeeSchedCur.Id==_listFeeSchedsForType[i].Id){
					gridMain.SetSelected(i,true);
				}
			}
		}

		private void listType_Click(object sender,EventArgs e) {
			if(listType.SelectedIndex==0){
				butSort.Enabled=true;
			}
			else{
				butSort.Enabled=false;
			}
			FillGrid();
		}

		private void butUp_Click(object sender,EventArgs e) {
			int idx=gridMain.GetSelectedIndex();
			if(idx==-1){
				MessageBox.Show("Please select a fee schedule first.");
				return;
			}
			if(idx==0){
				return;
			}
			//swap the orders.  This makes it work no matter which types are being viewed.
			_hasChanged=true;
			int oldItemOrder=_listFeeSchedsForType[idx].SortOrder;
			_listFeeSchedsForType[idx].SortOrder=_listFeeSchedsForType[idx-1].SortOrder;
			FeeScheds.Update(_listFeeSchedsForType[idx]);
			_listFeeSchedsForType[idx-1].SortOrder=oldItemOrder;
			FeeScheds.Update(_listFeeSchedsForType[idx-1]);
			FillGrid();
			gridMain.SetSelected(idx-1,true);
		}

		private void butDown_Click(object sender,EventArgs e) {
			int idx=gridMain.GetSelectedIndex();
			if(idx==-1){
				MessageBox.Show("Please select a fee schedule first.");
				return;
			}
			if(idx==_listFeeSchedsForType.Count-1){
				return;
			}
			_hasChanged=true;
			int oldItemOrder=_listFeeSchedsForType[idx].SortOrder;
			_listFeeSchedsForType[idx].SortOrder=_listFeeSchedsForType[idx+1].SortOrder;
			FeeScheds.Update(_listFeeSchedsForType[idx]);
			_listFeeSchedsForType[idx+1].SortOrder=oldItemOrder;
			FeeScheds.Update(_listFeeSchedsForType[idx+1]);
			FillGrid();
			gridMain.SetSelected(idx+1,true);
		}

		private void butSetOrder_Click(object sender,EventArgs e) {
			int idx=gridMain.GetSelectedIndex();
			if(idx==-1) {
				MessageBox.Show("Please select a fee schedule first.");
				return;
			}
			butSetOrder.BackColor=Color.Red;
			_feeSchedToMove=_listFeeSchedsForType[idx];
			_IsMovingToOrder=true;
		}

		private void butSort_Click(object sender,EventArgs e) {
			//only enabled if viewing all types
			FeeScheds.SortFeeSched();
			FeeScheds.RefreshCache();
			_listFeeScheds=FeeScheds.GetDeepCopy();
			FillGrid();
		}

		///<summary>This sorts feescheds by their item order.</summary>
		private static int CompareItemOrder(FeeSchedule feeSched1,FeeSchedule feeSched2) {
			return feeSched1.SortOrder.CompareTo(feeSched2.SortOrder);
		}

		///<summary>This sorts feescheds by type and alphabetically.</summary>
		private static int CompareFeeScheds(FeeSchedule feeSched1,FeeSchedule feeSched2) {
			if(feeSched1==null){
				if(feeSched2==null){
					return 0;//both null, so equal
				}
				else{
					return -1;
				}
			}
			if(feeSched2==null){
				return 1;
			}
			if(feeSched1.Type!=feeSched2.Type){
				return feeSched1.Type.CompareTo(feeSched2.Type);
			}
			return feeSched1.Description.CompareTo(feeSched2.Description);
		}

		private void butIns_Click(object sender,EventArgs e) {
			FormFeesForIns FormF=new FormFeesForIns();
			FormF.ShowDialog();
			//DialogResult=DialogResult.OK;
		}

		private void butCleanUp_Click(object sender,EventArgs e) {
			if(!MsgBox.Show(MsgBoxButtons.OKCancel,"Delete allowed fee schedules that are not in use or that are attached to hidden insurance plans?")) {
				return;
			}
			long changed=FeeScheds.CleanupAllowedScheds();
			MessageBox.Show(changed.ToString()+" "+"unused fee schedules deleted.");
			if(changed==0) {
				return;
			}
			_hasChanged=true;
			FeeScheds.RefreshCache();
			_listFeeScheds=FeeScheds.GetDeepCopy(_isSelectionMode);  //After deletion, refresh in-memory copy to continue editing.
			CheckItemOrders();
			FillGrid();
		}

		private void butHideUnused_Click(object sender,EventArgs e) {
			if(!MsgBox.Show(MsgBoxButtons.OKCancel,"Hide fee schedules that are not in use by insurance plans, patients, or providers?\r\n"
				+"A backup of the database will be made first.")) 
			{
				return;
			}
			Action actionProgress=ODProgress.Show(EventCategory.HideUnusedFeeSchedules,startingMessage:"Backing up database...");
			try {
				MiscData.MakeABackup();
			} 
			catch(Exception ex) {
				actionProgress?.Invoke();
				FriendlyException.Show("Unable to make a backup. No fee schedules have been altered.",ex);
				return;
			}
			ODEvent.Fire(EventCategory.HideUnusedFeeSchedules,"Hiding unused fee schedules...");
			long countChanged=FeeScheds.HideUnusedScheds();
			actionProgress?.Invoke();
			MessageBox.Show(countChanged.ToString()+" "+"unused fee schedules hidden.");
			if(countChanged==0) {
				return;
			}
			_hasChanged=true;
			FeeScheds.RefreshCache();
			_listFeeScheds=FeeScheds.GetDeepCopy(_isSelectionMode);
			FillGrid();
		}

		private void butOK_Click(object sender,EventArgs e) {
			//only visible in selection mode
			if(gridMain.SelectedIndices.Length==0) {
				MessageBox.Show("Please select a row first.");
				return;
			}
			SelectedFeeSchedNum=((FeeSchedule)gridMain.Rows[gridMain.GetSelectedIndex()].Tag).Id;
			DialogResult=DialogResult.OK;
		}

		private void butClose_Click(object sender, System.EventArgs e) {
			//also cancel button
			SelectedFeeSchedNum=0;
			DialogResult=DialogResult.Cancel;
		}

		private void FormFeeSchedules_FormClosing(object sender,FormClosingEventArgs e) {
			if(_hasChanged){
				DataValid.SetInvalid(InvalidType.FeeScheds);
			}
		}
	}

	
		

	
}





















