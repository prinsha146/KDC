using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxZKFPEngXControl;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using AForge.Video.DirectShow;
using AForge.Video;
using KDC.DL.ViewModel;
using KDC.DL.DapperObjects;
using KDC.DESKTOP.DO;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;

namespace KDC.DESKTOP
{
	public partial class FrmCandidateVerify : Form
	{
		private int _engineNo;
		private bool _fAutoIdentify;
		private int _fMatchType;
		private int _fpcHandle;
		private bool _isVerify;
		private string _fingerPrintHash;
		int ppId;
		private bool DeviceExist = false;
		//private FilterInfoCollection videoDevices;
		//private VideoCaptureDevice videoSource = null;
		//int _candid;
		string _tempFingerHash;
		public string formMode = "";
		public FrmCandidateVerify()
		{
			InitializeComponent();
			PopulateGridView("", "");
			labelStatus.Text = "";
		}

		private void FrmCandidateVerify_Load(object sender, EventArgs e)
		{

		}
		private void btnRefreshList_Click(object sender, EventArgs e)
		{

			DateTime fromdate = Convert.ToDateTime(dtpFrom.Value.ToShortDateString());
			DateTime to = Convert.ToDateTime(dtpTo.Value.ToShortDateString());
			//DateTime todate = Convert.ToDateTime(to.AddDays(1).ToShortDateString());

			PopulateGridView(fromdate.ToString("yyyy-MM-dd"), to.ToString("yyyy-MM-dd"));
		}
		private void PopulateGridView(string from = "", string to = "")
		{
			dgvFP.DataSource = DA.CandidateDA.GetCandidateList(from, to);
			dgvFP.Columns[0].Visible = false;
			dgvFP.Columns[1].HeaderText = "Candidate Name";
			dgvFP.Columns[2].HeaderText = "Passport No";
			dgvFP.Columns[3].HeaderText = "Finger Remarks";
			dgvFP.Columns[4].Visible = false;
			dgvFP.Columns[5].Visible = false;
			dgvFP.Columns[4].HeaderText = "Photo";
			dgvFP.Columns[1].Width = 200;
			dgvFP.Columns[2].Width = 80;
			dgvFP.Columns[3].Width = 80;
			dgvFP.AllowUserToAddRows = false;
			dgvFP.ClearSelection();
		}
		private void btnEnroll_Click(object sender, EventArgs e)
		{
			_fingerPrintHash = null;
			fingerScanner.BeginEnroll();
			FpSensorStatus("Place 3 times same finger");
			picStatusImageVarified.Visible = false;
		}
		private void btnConnect_Click(object sender, EventArgs e)
		{
			fingerScanner.SensorIndex = 0;
			_engineNo = fingerScanner.InitEngine();
			if (_engineNo == 0)
			{
				btnConnect.Enabled = false;
				btnDisconnect.Enabled = true;
				btnEnroll.Enabled = true;
				//panEnrollVarify.Enabled = true;
				fingerScanner.FPEngineVersion = "9";
				_fpcHandle = fingerScanner.CreateFPCacheDB();
				//MessageBox.Show("Connected to finger print scanner : " + fingerScanner.SensorSN);
				//btnInit.Enabled = false;

				lblStatus.Text = @"Connected";// + fingerScanner.SensorSN;

				FpSensorStatus("Connection Successfull "); //+ fingerScanner.SensorSN
				_fAutoIdentify = false;
				_isVerify = true;
				//panEnrollVarify.Enabled = false;
				fingerScanner.SetAutoIdentifyPara(_fAutoIdentify, _fpcHandle, 8);
				_fMatchType = 2;
				//ShowFP();
				fingerScanner.BeginCapture();
				if (_isVerify)
				{
					FpSensorStatus("Begin Verification");
				}
			}
			else
			{
				//panEnrollVarify.Enabled = false;
				btnDisconnect.Enabled = false;
				btnEnroll.Enabled = false;
				//panEnrollVarify.Enabled = false;
				//MessageBox.Show("Failed to connect to a finger print scanner !");
				lblStatus.Text = @"Failed to connect to a finger print scanner !";
				FpSensorStatus("Failed to connect to a finger print scanner !");
			}
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{
			ClearAll();
			fingerScanner.EndEngine();
			btnConnect.Enabled = true;
			btnDisconnect.Enabled = false;
			btnEnroll.Enabled = false;
			//panEnrollVarify.Enabled = false;
			lblStatus.Text = @"Disconnected...";
			FpSensorStatus("Disconnected...");
		}

		private void FpSensorStatus(string paramStatusText)
		{
			lstCurrentStatus.Items.Add(paramStatusText);
			lstCurrentStatus.SelectedIndex = lstCurrentStatus.Items.Count - 1;
		}

		private void ClearAll()
		{
			ppId = 0;
			labelStatus.Text = "";
			txtCandidatePassport.Text = string.Empty;
			txtCandidateName.Text = string.Empty;
			lstCurrentStatus.Items.Clear();
			//txtCandidateId.Text = "0";
			//imgCandidatePhoto.Image = null;
			_fingerPrintHash = string.Empty;
			//chkPhoto.Checked = true;
			//chkThumb.Checked = true;
			//chkThumbNotTaken.Checked = false;
			/* txtCandidate.Text = "";
            
            txtCountry.Text = "";
            rdbFamily.Checked = false;
            rdbIndividual.Checked = false;
            picFingerPrint.Image = null;
            thumbimg.Image = null;
            
            pctCandidate.Image = null;
            btnVerified.Enabled = false; */

		}
		private void fingerScanner_OnCapture(object sender, IZKFPEngXEvents_OnCaptureEvent e)
		{

			//load Reg Template from Grid

			var template = fingerScanner.GetTemplateAsString();
			//
			//fingerScanner.enc
			//if success to capture
			var isMatched = false;
			if (e.actionResult)
			{
				if (_fMatchType == 2) // 1:N 
				{
					if (!_fAutoIdentify)
					{
						fingerScanner.FPEngineVersion = "9";
						//ID = fingerScanner.IdentificationFromFileInFPCacheDB(fpcHandle, fingerScanner.GetTemplateAsStringEx("9"), ref Score, ref ProcessNum);
						//ID = fingerScanner.IdentificationInFPCacheDB(fpcHandle, VerTemplate, ref Score, ref ProcessNum);
						// ID = fingerScanner.IdentificationFromStrInFPCacheDB(fpcHandle, fingerScanner.GetTemplateAsString(), ref Score, ref ProcessNum);
						//ID = fingerScanner.IdentificationFromStrInFPCacheDB(fpcHandle, Template, ref Score, ref ProcessNum);
						bool isFeatureChanged = true;
						string pname = "";

						string pId = "";
						string pcountry = "";
						string ptype = "";
						string ppassport = "";
						byte[] photo = null;
						string rmark = "";
						//match for all
						//if (txtSearch.Text!=string.Empty)
						//{
						//	if (txtSearch.Text == string.Empty)
						//	{
						//		MessageBox.Show("Passport Number Must be Entered", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						//		//txtSearch.Focus();
						//		//return;
						//	}
						//	else
						//	{

						//		if (fingerScanner.VerFingerFromStr(ref template, _tempFingerHash, false, ref isFeatureChanged))
						//		{
						//			//MessageBox.Show("Success   " + IsFeatureChanged.ToString());
						//			isMatched = true;
						//			//pname = name;
						//			//ppassport = passport;
						//			//ptype = type;
						//			//pcountry = country;
						//			//ppId = ;//Convert.ToInt32(id);
						//			//photo = Encoding.ASCII.GetBytes(dgvFP.Rows[i].Cells[6].Value.ToString());
						//			//fingerId = fid;
						//			//MessageBox.Show("Match Found:" + pname, "Match", MessageBoxButtons.OK, MessageBoxIcon.Information);
						//			//break;
						//		}
						//		//for (int i = 0; i < dgvFP.Rows.Count; i++)
						//		// {
						//		//    if ((dgvFP.Rows[i].Cells[2].Value.ToString()).Trim() == txtSearch.Text.Trim())
						//		//    {
						//		//        string id = dgvFP.Rows[i].Cells[0].Value.ToString();
						//		//        string name = dgvFP.Rows[i].Cells[1].Value.ToString();
						//		//        string passport = dgvFP.Rows[i].Cells[2].Value.ToString();
						//		//        string type = dgvFP.Rows[i].Cells[3].Value.ToString();
						//		//        string country = dgvFP.Rows[i].Cells[4].Value.ToString();
						//		//        string temp = dgvFP.Rows[i].Cells[5].Value.ToString();
						//		//        //if (fingerScanner.VerFingerFromStr(ref Template, Reg_TemplateStr_Pawan_5, false, ref IsFeatureChanged))
						//		//        if (fingerScanner.VerFingerFromStr(ref template, temp, false, ref isFeatureChanged))
						//		//        {
						//		//            //MessageBox.Show("Success   " + IsFeatureChanged.ToString());
						//		//            isMatched = true;
						//		//            pname = name;
						//		//            ppassport = passport;
						//		//            ptype = type;
						//		//            pcountry = country;
						//		//            ppId = Convert.ToInt32(id);
						//		//            //photo = Encoding.ASCII.GetBytes(dgvFP.Rows[i].Cells[6].Value.ToString());
						//		//            //fingerId = fid;
						//		//            //MessageBox.Show("Match Found:" + pname, "Match", MessageBoxButtons.OK, MessageBoxIcon.Information);
						//		//            break;
						//		//        }
						//		//    }
						//		//}_tempFingerHash

						//	}
						//}
						//else
						//{
							for (int i = 0; i < dgvFP.Rows.Count; i++)
							{
								string id = dgvFP.Rows[i].Cells[0].Value.ToString();
								string name = dgvFP.Rows[i].Cells[1].Value.ToString();
								string passport = dgvFP.Rows[i].Cells[2].Value.ToString();
								//string type = dgvFP.Rows[i].Cells[3].Value.ToString();
								//string country = dgvFP.Rows[i].Cells[5].Value.ToString();
								string temp = dgvFP.Rows[i].Cells[5].Value.ToString();
								//dgvFP.Columns[1].HeaderText = "Candidate Name";
								//dgvFP.Columns[2].HeaderText = "Passport No";
								//dgvFP.Columns[3].HeaderText = "Barcode";
								//dgvFP.Columns[4].Visible = false;
								//dgvFP.Columns[4].HeaderText = "Photo"; 
								if (fingerScanner.VerFingerFromStr(ref template, temp, false, ref isFeatureChanged))
								{
									//MessageBox.Show("Success   " + IsFeatureChanged.ToString());
									isMatched = true;
									pname = name;
									ppassport = passport;
									//ptype = type;
									//pcountry = country;
									ppId = Convert.ToInt32(id);
									//rmark = remarks;
									//photo = Encoding.ASCII.GetBytes(dgvFP.Rows[i].Cells[6].Value.ToString());

									//fingerId = fid;
									//MessageBox.Show("Match Found" + pname, "Match", MessageBoxButtons.OK, MessageBoxIcon.Information);
									break;
								}
								//MessageBox.Show("Failed   " + IsFeatureChanged.ToString()); 
								//pname = name;
								//pId = id;
								isMatched = false;
								//fingerId = fid;
							}
						//}

						if (isMatched == false)
						{
							picStatusImageVarified.Visible = true;
							//picStatusImageVarified.Image = (Image)DOLIA.Properties.Resources.delete;
							if (_isVerify)
							{
								FpSensorStatus("Verification failed : Fingerprint doesn't match.");
								labelStatus.Text = "Failed";
							}
						}
						else
						{
							//save to database the matched Details
							if (_isVerify)
							{
								FpSensorStatus("Verified Successfully : " + pname);// " [" + pId + "]finger Id " +
																				   //fingerId);
								labelStatus.Text = "Verified";
								MessageBox.Show("Match Found" + Environment.NewLine + "Candidate: " + pname + Environment.NewLine + "Passport Number: " + ppassport, "Match", MessageBoxButtons.OK, MessageBoxIcon.Information);
								//Candidate candidate = CandidateDA.SearchCandidateByPassportNo(ppassport);
								txtCandidateName.Text = pname;
								txtCandidatePassport.Text = ppassport;
								//txtCountry.Text = pcountry;
								//lblthumbremarks.Visible = true;
								//lblthumbremarks.Text = rmark;
								//byte[] photos = candidate.Photo;//(from candidate in db.Gamca_CandidateDetail.Where(a => a.GamcaCandidateID == ppId) select candidate.Photo).First();
								//MemoryStream ms = new MemoryStream(photos);
								try
								{
									//string ip = LocalIPAddress();
									//MessageBox.Show(ip);
									/*if (ip.Contains("192.168.0."))
                                        pctCandidate.ImageLocation = (new Uri("http://" + "192.168.0.250/gamcaimages/" + candidate.PassportNo + ".JPG")).ToString();

                                    else
                                    {*/
									//if (ip.Contains("49.236.212.102"))
									//pctCandidate.ImageLocation = (candidate.Photo).ToString();
									//string pcname = GetPCName();
									ReadImage(ppId);
									Random rnd = new Random();
									int imgname = rnd.Next(1, 10);
									//thumbimg.ImageLocation = (("\\\\" + pcname + "\\candidateimg\\" + imgname)).ToString();
									ReadRandomThumb(imgname);
									//pctCandidate.ImageLocation = (("\\\\" + pcname + "\\candidateimg\\" + candidate.Photo)).ToString();
									//thumbimg.Image = bmp;
									//else
									//    pctCandidate.Image = null;
									//}
								}
								catch
								{
								}
								
								//ppId = null;
								//pctCandidate.Image = null;  
							}
							picStatusImageVarified.Visible = true;
							//picStatusImageVarified.Image = (Image)DOLIA.Properties.Resources.success;
						}

					}
				}
			}
		}

		private void fingerScanner_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
		{
			var template = fingerScanner.GetTemplateAsString();
			//
			//fingerScanner.enc
			//if success to capture
			var isMatched = false;

			if (e.actionResult)
			{
				//MessageBox.Show("FP Register Success");

				fingerScanner.FPEngineVersion = "9";

				bool isFeatureChanged = true;
				string pname = "";
				string pId = "";
				string pcountry = "";
				string ptype = "";
				string ppassport = "";
				//match for all
				//for (var i = 0; i < dgvFP.Rows.Count; i++)
				//{
				//    string id = dgvFP.Rows[i].Cells[0].Value.ToString();
				//    string name = dgvFP.Rows[i].Cells[1].Value.ToString();
				//    string passport = dgvFP.Rows[i].Cells[2].Value.ToString();
				//    string type = dgvFP.Rows[i].Cells[3].Value.ToString();
				//    string country = dgvFP.Rows[i].Cells[4].Value.ToString();
				//    string temp = dgvFP.Rows[i].Cells[5].Value.ToString();
				//    //if (fingerScanner.VerFingerFromStr(ref Template, Reg_TemplateStr_Pawan_5, false, ref IsFeatureChanged))
				//    if (fingerScanner.VerFingerFromStr(ref template, temp, false, ref isFeatureChanged))
				//    {
				//        // MessageBox.Show("Success   " + IsFeatureChanged.ToString());
				//        isMatched = true;
				//        pname = name;
				//        ppassport = passport;
				//        ptype = type;
				//        pcountry = country;
				//        pId = id;
				//        //fingerId = fid;
				//        break;
				//    }
				//    // MessageBox.Show("Failed   " + IsFeatureChanged.ToString()); 
				//    pname = name;
				//    pId = id;
				//    //find = fid;
				//}

				var strTemplate = fingerScanner.GetTemplateAsString();


				//var rows = 0;
				// var ntemplate = str_template.Cast(SqlDbType.NText)();
				try
				{
					if (isMatched)
					{
						MessageBox.Show(@"Registration Failed : Duplicate Finger " + pname + " Passport:" + ppassport);
						return;
					}
					FpSensorStatus("Finger Registration Successful");

					_fingerPrintHash = strTemplate;
					var g = picFingerPrint.CreateGraphics();
					var bmp = new Bitmap(picFingerPrint.Width, picFingerPrint.Height);
					g = Graphics.FromImage(bmp);
					var hdc = g.GetHdc().ToInt32();
					fingerScanner.PrintImageAt(hdc, 0, 0, bmp.Width, bmp.Height);
					g.Dispose();

				}
				catch (Exception exx)
				{
					MessageBox.Show(exx.Message);
				}


				//btnEnroll_Click(new object(), new EventArgs());

			}
			else
			{
				_fingerPrintHash = string.Empty;
				FpSensorStatus("FP Register Failed");
				MessageBox.Show(@"Finger Print Registration Failed : Please place same finger 3 times correctly", "",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				btnEnroll_Click(new object(), new EventArgs());
			}
		}

		private void fingerScanner_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
		{
			var g = picFingerPrint.CreateGraphics();
			var bmp = new Bitmap(picFingerPrint.Width, picFingerPrint.Height);
			g = Graphics.FromImage(bmp);
			var hdc = g.GetHdc().ToInt32();
			fingerScanner.PrintImageAt(hdc, 0, 0, bmp.Width, bmp.Height);
			g.Dispose();
			picFingerPrint.Image = bmp;
		}

		
		private void fingerScanner_OnFingerLeaving(object sender, EventArgs e)
		{
			FpSensorStatus("Leaving Finger.....");
		}

		private void fingerScanner_OnFingerTouching(object sender, EventArgs e)
		{
			FpSensorStatus("Touching Finger.....");
		}



		public string GetPCName()
		{
			String filepath = Environment.CurrentDirectory + @"\Amsoft.txt";

			string filecontent = File.ReadAllText(filepath);
			return filecontent;
		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			// getCamList();
		}
		//private void getCamList()
		//{
		//    try
		//    {
		//        videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
		//        //ddlCameraList.Items.Clear();
		//        if (videoDevices.Count == 0)
		//            throw new ApplicationException();

		//        DeviceExist = true;
		//        foreach (FilterInfo device in videoDevices)
		//        {
		//            if (!device.Name.Contains("ZK"))
		//                ddlCameraList.Items.Add(device.Name);
		//        }
		//        ddlCameraList.SelectedIndex = 0; //make dafault to first cam
		//    }
		//    catch (ApplicationException)
		//    {
		//        DeviceExist = false;
		//        ddlCameraList.Items.Add("No capture device on your system");
		//    }
		//}
		//private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
		//{
		//    Bitmap img = (Bitmap)eventArgs.Frame.Clone();
		//    //do processing here

		//    //imgCandidateVideo.Image = img;
		//}
		//private void btnCameraConnect_Click(object sender, EventArgs e)
		//{
		//    if (btnCameraConnect.Text == "&Camera Ready")
		//    {
		//        if (DeviceExist)
		//        {
		//            videoSource = new VideoCaptureDevice(videoDevices[ddlCameraList.SelectedIndex].MonikerString);
		//            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
		//            CloseVideoSource();
		//            //videoSource.DesiredFrameSize = new Size(160, 120);
		//            videoSource.VideoResolution = videoSource.VideoCapabilities[2];
		//            //videoSource.DesiredFrameSize = new System.Drawing.Size(160, 120);
		//            //videoSource.DesiredFrameRate = 10;
		//            // videoSource.
		//            videoSource.Start();
		//            lblCameraStatus.Text = "Running...";
		//            btnCameraConnect.Text = "&Stop";
		//            //timer1.Enabled = true;
		//        }
		//        else
		//        {
		//            lblCameraStatus.Text = "No Device";
		//        }
		//    }
		//    else
		//    {
		//        if (videoSource.IsRunning)
		//        {
		//            //timer1.Enabled = false;
		//            CloseVideoSource();
		//            lblCameraStatus.Text = "Stopped.";
		//            btnCameraConnect.Text = "&Camera Ready";
		//        }
		//    }
		//}

		//private void CloseVideoSource()
		//{
		//    if (!(videoSource == null))
		//        if (videoSource.IsRunning)
		//        {
		//            videoSource.SignalToStop();
		//            videoSource = null;
		//        }
		//}

		//private void btnCapture_Click(object sender, EventArgs e)
		//{
		//    imgCandidatePhoto.Image = imgCandidateVideo.Image;
		//}

		

		private void dgvFP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				int candidateid = Convert.ToInt32(dgvFP.Rows[e.RowIndex].Cells[0].Value.ToString());//Gets CandidateId
																									//MessageBox.Show(drow);
																									//Get respective Candidate Details and Populate input box in form
				var candidate = DA.CandidateDA.GetCandidateDetailById(candidateid);
				//txtCandidateId.Text = (candidate.CandidateID).ToString();
				txtCandidateName.Text = (candidate.CandidateName).ToString();
				txtCandidatePassport.Text = (candidate.PassportNo).ToString();
				this.Cursor = Cursors.Default;
				//imgCandidatePhoto.Image = null;
				ReadImage(candidateid);
				return;
			}
			catch
			{
				this.Cursor = Cursors.Default;
				MessageBox.Show("Invalid Selection");
			}
			return;
		}
		private void ReadImage(int id)
		{
			var imgname = DA.CandidateDA.GetCandidateImageById(id);
			string url = ConfigurationManager.AppSettings["ImageView"].ToString();
			
			if(imgname!=string.Empty)
			try
			{
				var request = WebRequest.Create(url + imgname);

				using (var response = request.GetResponse())
				using (var stream = response.GetResponseStream())
				{
					//if()
					imgCandidatePhoto.Image = Bitmap.FromStream(stream);
				}
			}
			catch (Exception ex)
			{
				//imgCandidatePhoto.Image = null;// Bitmap.FromStream(stream);
				ex.Message.ToString();
			}
		}
		
		

		//private void chkThumbNotTaken_CheckedChanged(object sender, EventArgs e)
		//{
		//	if (chkThumbNotTaken.Checked == true)
		//		chkThumb.Checked = false;
		//	else
		//		chkThumb.Checked = true;
		//}

		//private void FrmCandidateAdd_FormClosing(object sender, FormClosingEventArgs e)
		//{
		//	CloseVideoSource();
		//}

		private void FrmCandidateAdd_Load(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			ClearAll();
			if (txtSearch.Text == string.Empty)
			{
				MessageBox.Show("Passport Number Must be Entered", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtSearch.Focus();
				return;
			}
			string passportNumber = txtSearch.Text;
			Candidate candidate = DA.CandidateDA.SearchCandidateByPassportNo(passportNumber);
			if (candidate != null)
			{
				//btnVerified.Enabled = true;

				ppId = candidate.CandidateID;
				txtCandidateName.Text = candidate.CandidateName;
				txtCandidatePassport.Text = candidate.PassportNo;
				string pcname = GetPCName();
				//lblthumbremarks.Text = candidate.ThumbRemarks;
				
				try
				{
					ReadImage(candidate.CandidateID);
					// string ip = LocalIPAddress();
					//MessageBox.Show(ip);
					//if (ip.Contains("192.168.0."))
					Random rnd = new Random();
					int imgname = rnd.Next(1, 10);
					//thumbimg.ImageLocation = (("\\\\" + pcname + "\\candidateimg\\" + imgname)).ToString();
					ReadRandomThumb(imgname);
				}
				catch (Exception ex)
				{
				}
				// pctCandidate.Image = Image.FromFile(candidate.Photo);//Utilities.ByteArrayToImage(candidate.Photo);
			}
			else
			{
				MessageBox.Show("Entered Candidate Not Found");
			}

		}
		private void ReadRandomThumb(int id)
		{
			var imgname = id.ToString() + ".jpg";
			string url = ConfigurationManager.AppSettings["ImageThumb"].ToString();

			if (imgname != string.Empty)
				try
				{
					var request = WebRequest.Create(url + imgname);

					using (var response = request.GetResponse())
					using (var stream = response.GetResponseStream())
					{
						//if()
						picThumb.Image = Bitmap.FromStream(stream);
					}
				}
				catch (Exception ex)
				{
					//imgCandidatePhoto.Image = null;// Bitmap.FromStream(stream);
					ex.Message.ToString();
				}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			ClearAll();
		}
	}
}
