using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;
using OpenDental.UI;
using CodeBase;
using System.IO;
using OpenDentBusiness.IO;
using Imedisoft.Data.Models;
using Imedisoft.Data;

namespace OpenDental {
	public partial class FormEhrLabImageEdit:ODForm {
		private long _ehrLabNum;
		private long _patNum;
		///<summary>List of EHR Lab Images attached to this EhrLabNum. This list will be retrieved from the database on init and then modified while dialog is up. Final list will be inserted into database if user clicks OK.</summary>
		private List<EhrLabImage> _listAttached=new List<EhrLabImage>();
		///<summary>List of Documents (images) attached to this patient. This list is not modified by this form.</summary>
		private List<Document> _listPatientDocuments=new List<Document>();
		///<summary>Directory which hold's the Patient's documents.</summary>
		private string _patFolder;

		public FormEhrLabImageEdit(long patNum,long ehrLabNum) {
			InitializeComponent();
			
			_patNum=patNum;
			_ehrLabNum=ehrLabNum;
		}

		private void FormEhrLabeImageEdit_Load(object sender,EventArgs e) {
			Height=System.Windows.Forms.Screen.GetWorkingArea(this).Height;
			this.SetDesktopLocation(DesktopLocation.X,0);			
			checkWaitingForImages.Checked=EhrLabImages.IsWaitingForImages(_ehrLabNum);
			_listPatientDocuments=new List<Document>(Documents.GetAllWithPat(_patNum));
			_patFolder=ImageStore.GetPatientFolder(Patients.GetPat(_patNum), OpenDentBusiness.FileIO.FileAtoZ.GetPreferredAtoZpath());//This is where the pat folder gets created if it does not yet exist.			
			_listAttached=EhrLabImages.Refresh(_ehrLabNum);
			FillGrid();
		}

		private void FillGrid() {
			int curSelection=gridMain.GetSelectedIndex();
			gridMain.BeginUpdate();
			gridMain.Columns.Clear();
			gridMain.Columns.Add(new GridColumn("Attached",60,HorizontalAlignment.Center));
			gridMain.Columns.Add(new GridColumn("Date",80,HorizontalAlignment.Center));
			gridMain.Columns.Add(new GridColumn("Category",80,HorizontalAlignment.Center));
			gridMain.Columns.Add(new GridColumn("Desc",180,HorizontalAlignment.Left));
			gridMain.Rows.Clear();
			GridRow row;
			for(int i=0;i<_listPatientDocuments.Count;i++) {
				if(_listPatientDocuments[i].Id<=0) { //Invalid doc num indicates 'Waiting for images'. This flag is set in the Load event.
					continue;
				}
				//Test if this is a valid image.
				Bitmap bmp=ImageStore.OpenImage(_listPatientDocuments[i],_patFolder);
				if(bmp==null) {
					continue;
				}
				bmp.Dispose();
				bmp=null;
				bool isAttached=EhrLabImages.GetDocNumExistsInList(_ehrLabNum,_listPatientDocuments[i].Id,_listAttached);
				row=new GridRow();
				row.Cells.Add(isAttached?"X":"");
				row.Cells.Add(_listPatientDocuments[i].AddedOnDate.ToString());
				row.Cells.Add(Definitions.GetName(DefinitionCategory.ImageCats,_listPatientDocuments[i].Category));			  
				row.Cells.Add(_listPatientDocuments[i].Description);
				row.Tag=_listPatientDocuments[i];
				gridMain.Rows.Add(row);
			}			
			gridMain.EndUpdate();
			if(curSelection>=0) {
				gridMain.SetSelected(curSelection,true);
			}
		}

		///<summary>Throws exception if current grid selection is invalid</summary>
		private Document GetSelectedDocument() {
			if(gridMain.GetSelectedIndex()==-1
				|| gridMain.Rows[gridMain.GetSelectedIndex()].Tag==null
				|| !(gridMain.Rows[gridMain.GetSelectedIndex()].Tag is Document)) {
				throw new Exception("Invalid selection");
			}
			Document doc=(Document)gridMain.Rows[gridMain.GetSelectedIndex()].Tag;
			return doc; 			
		}

		private void PaintPreviewPicture() {
			try {
				Document doc=GetSelectedDocument();
				string imagePath= Storage.CombinePaths(_patFolder,doc.FileName);
				if(!Storage.FileExists(imagePath)) {
					throw new Exception("File not found");
				}
				Image tmpImg= Storage.GetImage(imagePath);
				float imgScale=1;//will be between 0 and 1
				if(tmpImg.PhysicalDimension.Height>picturePreview.Height || tmpImg.PhysicalDimension.Width>picturePreview.Width) {//image is too large
					//Image is larger than PictureBox, resize to fit.
					if(tmpImg.PhysicalDimension.Width/picturePreview.Width>tmpImg.PhysicalDimension.Height/picturePreview.Height) {//resize image based on width
						imgScale=picturePreview.Width/tmpImg.PhysicalDimension.Width;
					}
					else {//resize image based on height
						imgScale=picturePreview.Height/tmpImg.PhysicalDimension.Height;
					}
				}
				if(picturePreview.Image!=null) {
					picturePreview.Image.Dispose();
					picturePreview.Image=null;
				}
				picturePreview.Image=new Bitmap(tmpImg,(int)(tmpImg.PhysicalDimension.Width*imgScale),(int)(tmpImg.PhysicalDimension.Height*imgScale));
				//labelDescription.Text="Description"+": "+doc.Description;
				picturePreview.Invalidate();
				if(tmpImg!=null) {
					tmpImg.Dispose();
				}
				tmpImg=null;
			}
			catch {
				picturePreview.Image=null;
				picturePreview.Invalidate();				
			}
		}

		private void splitContainer_Resize(object sender,EventArgs e) {
			PaintPreviewPicture();
		}

		private void splitContainer_SplitterMoved(object sender,SplitterEventArgs e) {
			PaintPreviewPicture();
		}
		
		private void gridMain_CellClick(object sender,UI.ODGridClickEventArgs e) {
			try {
				PaintPreviewPicture();
				if(e.Col!=0) {
					return;
				}
				Document doc=GetSelectedDocument();
				int existingIndex=-1;
				for(int i=0;i<_listAttached.Count;i++) {
					if(_listAttached[i].EhrLabNum==_ehrLabNum && _listAttached[i].DocNum==doc.Id) {
						//found it, mark it for delete
						existingIndex=i;
						break;
					}
				}
				if(existingIndex>=0) { //it exists so delete it
					_listAttached.RemoveAt(existingIndex);
				}
				else { //it doesn't exist so add it
					EhrLabImage labImage=new EhrLabImage();
					labImage.EhrLabNum=_ehrLabNum;
					labImage.DocNum=doc.Id;
					_listAttached.Add(labImage);
				}
				FillGrid();	
			}
			catch { }
		}
				
		private void butOK_Click(object sender,EventArgs e) {
			//Uncheck the waiting check box if any images are attached. User only has the option of setting the 'Waiting' flag if there are no images attached.
			List<long> docNums=new List<long>();
			for(int i=0;i<_listAttached.Count;i++) {
				if(!docNums.Contains(_listAttached[i].DocNum)) {
					docNums.Add(_listAttached[i].DocNum);
				}
			}
			if(checkWaitingForImages.Checked && docNums.Count>0) {
				MessageBox.Show("'Waiting for Images' is only allowed if there are no images currently attached. Detach all images or uncheck 'Waiting for Images'.");
				return;
			}
			EhrLabImages.InsertAllForLabNum(_ehrLabNum,checkWaitingForImages.Checked,docNums);
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}
	}
}