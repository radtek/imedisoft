using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using OpenDentBusiness;
using Imedisoft.Data;

namespace OpenDental{
///<summary></summary>
	public class FormGroupPermEdit : ODForm {
		private OpenDental.UI.Button butCancel;
		private OpenDental.UI.Button butOK;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private OpenDental.ValidDate textDate;
		private System.Windows.Forms.Label label3;
		private ValidNumber textDays;
		private GroupPermission Cur;
		private System.Windows.Forms.GroupBox groupBox1;
		///<summary></summary>
		public bool IsNew;

		private System.ComponentModel.Container components = null;

		///<summary></summary>
		public FormGroupPermEdit(GroupPermission cur){
			InitializeComponent();
			
			Cur=cur.Copy();
		}

		///<summary></summary>
		protected override void Dispose( bool disposing ){
			if( disposing ){
				if(components != null){
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		private void InitializeComponent(){
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGroupPermEdit));
			this.butCancel = new OpenDental.UI.Button();
			this.butOK = new OpenDental.UI.Button();
			this.textName = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textDate = new OpenDental.ValidDate();
			this.label3 = new System.Windows.Forms.Label();
			this.textDays = new OpenDental.ValidNumber();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// butCancel
			// 
			this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butCancel.Location = new System.Drawing.Point(510,214);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(75,26);
			this.butCancel.TabIndex = 37;
			this.butCancel.Text = "&Cancel";
			this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
			// 
			// butOK
			// 
			this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butOK.Location = new System.Drawing.Point(510,182);
			this.butOK.Name = "butOK";
			this.butOK.Size = new System.Drawing.Size(75,26);
			this.butOK.TabIndex = 36;
			this.butOK.Text = "&OK";
			this.butOK.Click += new System.EventHandler(this.butOK_Click);
			// 
			// textName
			// 
			this.textName.Location = new System.Drawing.Point(151,12);
			this.textName.MaxLength = 100;
			this.textName.Name = "textName";
			this.textName.ReadOnly = true;
			this.textName.Size = new System.Drawing.Size(260,20);
			this.textName.TabIndex = 38;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(54,15);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(95,14);
			this.label10.TabIndex = 43;
			this.label10.Text = "Type";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7,19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(121,18);
			this.label1.TabIndex = 46;
			this.label1.Text = "Date";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3,46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126,16);
			this.label2.TabIndex = 47;
			this.label2.Text = "Days";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textDate
			// 
			this.textDate.Location = new System.Drawing.Point(130,19);
			this.textDate.Name = "textDate";
			this.textDate.Size = new System.Drawing.Size(100,20);
			this.textDate.TabIndex = 50;
			this.textDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textDate_KeyDown);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(87,77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(320,40);
			this.label3.TabIndex = 52;
			this.label3.Text = "For instance, if you set days to 1, then user will only have permission if the da" +
    "te of the item is today";
			// 
			// textDays
			// 
			this.textDays.Location = new System.Drawing.Point(130, 45);
			this.textDays.MaxVal = 3000;
			this.textDays.MinVal = 0;
			this.textDays.Name = "textDays";
			this.textDays.Size = new System.Drawing.Size(46, 20);
			this.textDays.TabIndex = 0;
			this.textDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textDays_KeyDown);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textDate);
			this.groupBox1.Controls.Add(this.textDays);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(21,45);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(443,126);
			this.groupBox1.TabIndex = 53;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Only if newer than";
			// 
			// FormGroupPermEdit
			// 
			this.AcceptButton = this.butOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5,13);
			this.CancelButton = this.butCancel;
			this.ClientSize = new System.Drawing.Size(600,250);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textName);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.butCancel);
			this.Controls.Add(this.butOK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormGroupPermEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit Group Permission";
			this.Load += new System.EventHandler(this.FormGroupPermEdit_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void FormGroupPermEdit_Load(object sender, System.EventArgs e) {
			textName.Text=GroupPermissions.GetDesc(Cur.Permission);
			if(!Cur.NewerDate.HasValue){
				textDate.Text="";
			}
			else{
				textDate.Text=Cur.NewerDate.Value.ToShortDateString();
			}
			if(Cur.NewerDays==0){
				textDays.Text="";
			}
			else{
				textDays.Text=Cur.NewerDays.ToString();
			}
		}

		/*private void textDays_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
			if(textDays.Text==""){
				textDays.Text="0";
				return;
			}
			try{
				if(Convert.ToInt32(textDays.Text)<0){
					MessageBox.Show("Value cannot be less than 0");
					e.Cancel=true;
					return;
				}
			}
			catch{
				MessageBox.Show("Cannot contain letters or symbols");
				e.Cancel=true;
				return;
			}
		}*/

		private void textDate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
			textDays.Text="";
		}

		private void textDays_KeyDown(object sender,KeyEventArgs e) {
			textDate.Text="";
			textDate.errorProvider1.SetError(textDate,"");
		}

		private void butOK_Click(object sender, System.EventArgs e) {
			if(textDate.errorProvider1.GetError(textDate)!="" || textDays.errorProvider1.GetError(textDays)!=""){
				MessageBox.Show("Please fix data entry errors first.");
				return;
			}
			int newerDays=PIn.Int(textDays.Text);
			if(newerDays>GroupPermissions.NewerDaysMax) {
				MessageBox.Show($"Days must be less than {GroupPermissions.NewerDaysMax.ToString()}.");
				return;
			}
			Cur.NewerDays=newerDays;
			Cur.NewerDate=PIn.Date(textDate.Text);
			try{
				if(Cur.IsNew) {
					GroupPermissions.Insert(Cur);
				}
				else {
					GroupPermissions.Update(Cur);
				}
				SecurityLogs.MakeLogEntry(Permissions.SecurityAdmin,0,$"Permission '{Cur.Permission}' granted to " +
					$"'{UserGroups.GetGroup(Cur.UserGroupId).Description}'");
			}
			catch(Exception ex){
				MessageBox.Show(ex.Message);
				return;
			}
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender, System.EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}

		

		



	}
}








