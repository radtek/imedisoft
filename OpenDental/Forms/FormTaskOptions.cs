using System;
using System.Windows.Forms;
using OpenDentBusiness;
using System.Collections.Generic;
using CodeBase;

namespace OpenDental {
	public partial class FormTaskOptions:ODForm {
		public bool IsShowFinishedTasks;
		public bool IsShowArchivedTaskLists;
		public DateTime DateTimeStartShowFinished;
		public bool IsSortApptDateTime;

		public FormTaskOptions(bool isShowFinishedTasks,DateTime dateTimeStartShowFinished,bool isAptDateTimeSort,bool isShowArchivedTaskLists) {
			InitializeComponent();
			Lan.F(this);
			checkShowFinished.Checked=isShowFinishedTasks;
			checkShowArchivedTaskLists.Checked=isShowArchivedTaskLists;
			textStartDate.Text=dateTimeStartShowFinished.ToShortDateString();
			checkTaskSortApptDateTime.Checked=isAptDateTimeSort;

			checkCollapsed.Checked = UserPreference.GetBool(UserPreferenceName.TaskCollapse);

			if(!isShowFinishedTasks) {
				labelStartDate.Enabled=false;
				textStartDate.Enabled=false;
			}
		}

		private void checkShowFinished_Click(object sender,EventArgs e) {
			if(checkShowFinished.Checked) {
				labelStartDate.Enabled=true;
				textStartDate.Enabled=true;
			}
			else {
				labelStartDate.Enabled=false;
				textStartDate.Enabled=false;
			}
		}

		private void butOK_Click(object sender,EventArgs e) {
			if(!(textStartDate.errorProvider1.GetError(textStartDate)=="")) {
				if(checkShowFinished.Checked) {
					MessageBox.Show("Invalid finished task start date");
					return;
				}
				else {
					//We are not going to be using the textStartDate so not reason to warn the user, just reset it back to the default value.
					textStartDate.Text=DateTimeOD.Today.AddDays(-7).ToShortDateString();
				}
			}

			UserPreference.Set(UserPreferenceName.TaskCollapse, checkCollapsed.Checked);

			IsShowFinishedTasks=checkShowFinished.Checked;
			IsShowArchivedTaskLists=checkShowArchivedTaskLists.Checked;
			DateTimeStartShowFinished=PIn.Date(textStartDate.Text);//Note that this may have not been enabled but we'll pass it back anyway, won't be used.
			IsSortApptDateTime=checkTaskSortApptDateTime.Checked;
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}
	}
}