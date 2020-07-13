using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CodeBase;

namespace OpenDental{
	/// <summary></summary>
	public class FormLicense : ODForm {
		private OpenDental.UI.Button butClose;
		private ListBox listBoxLicense;
		private RichTextBox textLicense;
		private Label labelLicense;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		///<summary></summary>
		public FormLicense()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLicense));
			this.butClose = new OpenDental.UI.Button();
			this.listBoxLicense = new System.Windows.Forms.ListBox();
			this.textLicense = new System.Windows.Forms.RichTextBox();
			this.labelLicense = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// butClose
			// 
			this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butClose.Location = new System.Drawing.Point(764, 482);
			this.butClose.Name = "butClose";
			this.butClose.Size = new System.Drawing.Size(75, 26);
			this.butClose.TabIndex = 0;
			this.butClose.Text = "&Close";
			this.butClose.Click += new System.EventHandler(this.butClose_Click);
			// 
			// listBoxLicense
			// 
			this.listBoxLicense.Location = new System.Drawing.Point(12, 55);
			this.listBoxLicense.Name = "listBoxLicense";
			this.listBoxLicense.Size = new System.Drawing.Size(144, 316);
			this.listBoxLicense.TabIndex = 20;
			this.listBoxLicense.SelectedIndexChanged += new System.EventHandler(this.listLicense_SelectedIndexChanged);
			// 
			// textLicense
			// 
			this.textLicense.Location = new System.Drawing.Point(162, 35);
			this.textLicense.Name = "textLicense";
			this.textLicense.Size = new System.Drawing.Size(662, 425);
			this.textLicense.TabIndex = 21;
			this.textLicense.Text = "";
			// 
			// labelLicense
			// 
			this.labelLicense.Location = new System.Drawing.Point(10, 35);
			this.labelLicense.Name = "labelLicense";
			this.labelLicense.Size = new System.Drawing.Size(147, 17);
			this.labelLicense.TabIndex = 22;
			this.labelLicense.Text = "Select License:";
			this.labelLicense.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// FormLicense
			// 
			this.ClientSize = new System.Drawing.Size(851, 520);
			this.Controls.Add(this.labelLicense);
			this.Controls.Add(this.textLicense);
			this.Controls.Add(this.listBoxLicense);
			this.Controls.Add(this.butClose);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormLicense";
			this.ShowInTaskbar = false;
			this.Text = "Licenses";
			this.Load += new System.EventHandler(this.FormLicense_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormLicense_Load(object sender,EventArgs e) {
			FillListBoxLicense();
			listBoxLicense.SetSelectedItem<string>(x => x== Imedisoft.Properties.Resources.OpenDentalLicense);
		}

		///<summary>Fills the listbox with licenses and the license text as a tag.</summary>
		private void FillListBoxLicense() {
			listBoxLicense.Items.Add(new ODBoxItem<string>("OpenDental", Imedisoft.Properties.Resources.OpenDentalLicense));
			listBoxLicense.Items.Add(new ODBoxItem<string>("AForge", Imedisoft.Properties.Resources.AForge));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Bouncy Castle", Imedisoft.Properties.Resources.BouncyCastle));
			listBoxLicense.Items.Add(new ODBoxItem<string>("BSD", Imedisoft.Properties.Resources.Bsd));
			listBoxLicense.Items.Add(new ODBoxItem<string>("CDT", Imedisoft.Properties.Resources.CDT_Content_End_User_License1));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Dropbox", Imedisoft.Properties.Resources.Dropbox_Api));
			listBoxLicense.Items.Add(new ODBoxItem<string>("GPL", Imedisoft.Properties.Resources.GPL));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Drifty", Imedisoft.Properties.Resources.Ionic));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Mentalis", Imedisoft.Properties.Resources.Mentalis));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Microsoft", Imedisoft.Properties.Resources.Microsoft));
			listBoxLicense.Items.Add(new ODBoxItem<string>("MigraDoc", Imedisoft.Properties.Resources.MigraDoc));
			listBoxLicense.Items.Add(new ODBoxItem<string>("NDde", Imedisoft.Properties.Resources.NDde));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Newton Soft", Imedisoft.Properties.Resources.NewtonSoft_Json));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Oracle", Imedisoft.Properties.Resources.Oracle));
			listBoxLicense.Items.Add(new ODBoxItem<string>("PDFSharp", Imedisoft.Properties.Resources.PdfSharp));
			listBoxLicense.Items.Add(new ODBoxItem<string>("SharpDX", Imedisoft.Properties.Resources.SharpDX));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Sparks3D", Imedisoft.Properties.Resources.Sparks3D));
			listBoxLicense.Items.Add(new ODBoxItem<string>("SSHNet", Imedisoft.Properties.Resources.SshNet));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Stdole", Imedisoft.Properties.Resources.stdole));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Tamir", Imedisoft.Properties.Resources.Tamir));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Tao_Freeglut", Imedisoft.Properties.Resources.Tao_Freeglut));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Tao_OpenGL", Imedisoft.Properties.Resources.Tao_OpenGL));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Twain Group", Imedisoft.Properties.Resources.Twain));
			listBoxLicense.Items.Add(new ODBoxItem<string>("Zxing", Imedisoft.Properties.Resources.Zxing));
		}

		private void listLicense_SelectedIndexChanged(object sender,EventArgs e) {
			textLicense.Text=listBoxLicense.GetSelected<string>();
		}

		private void butClose_Click(object sender,EventArgs e) {
			Close();
		}
	}
}





















