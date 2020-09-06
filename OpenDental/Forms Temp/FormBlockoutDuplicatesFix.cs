using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Imedisoft.Data;
using OpenDentBusiness;

namespace OpenDental {
	public partial class FormBlockoutDuplicatesFix:ODForm {
		public FormBlockoutDuplicatesFix() {
			InitializeComponent();
			
		}

		private void FormBlockoutDuplicatesFix_Load(object sender,EventArgs e) {
			FillLabels();
			Cursor=Cursors.Default;
		}

		private void FillLabels() {
			labelCount.Text=Schedules.GetDuplicateBlockoutCount().ToString();
			if(labelCount.Text=="0") {
				labelInstructions.Text="";
			}
			else {
				labelInstructions.Text="Click the Clear button to fix the duplicates.";
			}
		}

		private void butOK_Click(object sender,EventArgs e) {
			if(labelCount.Text=="0") {
				MessageBox.Show("There are no duplicates to clear.");
				return;
			}
			if(!MsgBox.Show(MsgBoxButtons.OKCancel,"Clear all duplicates?")){
				return;
			}
			Cursor=Cursors.WaitCursor;
			Schedules.ClearDuplicates();
			SecurityLogs.MakeLogEntry(Permissions.Setup,0,"Clear duplicate blockouts.");
			Cursor=Cursors.Default;
			MessageBox.Show("Done.");
			FillLabels();
		}

		private void butCancel_Click(object sender,EventArgs e) {
			Close();
		}

		
	}
}