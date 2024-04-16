namespace KDC.DESKTOP
{
	partial class FrmCandidateVerify
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCandidateVerify));
			this.btnEnroll = new System.Windows.Forms.Button();
			this.txtCandidateName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCandidatePassport = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.picFingerPrint = new System.Windows.Forms.PictureBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.picThumb = new System.Windows.Forms.PictureBox();
			this.labelStatus = new System.Windows.Forms.Label();
			this.imgCandidatePhoto = new System.Windows.Forms.PictureBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lstCurrentStatus = new System.Windows.Forms.ListBox();
			this.picStatusImageVarified = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dgvFP = new System.Windows.Forms.DataGridView();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.btnRefreshList = new System.Windows.Forms.Button();
			this.fingerScanner = new AxZKFPEngXControl.AxZKFPEngX();
			this.lblStatus = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.picFingerPrint)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picThumb)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgCandidatePhoto)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picStatusImageVarified)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvFP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fingerScanner)).BeginInit();
			this.SuspendLayout();
			// 
			// btnEnroll
			// 
			this.btnEnroll.Enabled = false;
			this.btnEnroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEnroll.Location = new System.Drawing.Point(293, 250);
			this.btnEnroll.Name = "btnEnroll";
			this.btnEnroll.Size = new System.Drawing.Size(85, 35);
			this.btnEnroll.TabIndex = 69;
			this.btnEnroll.Text = "Enroll";
			this.btnEnroll.UseVisualStyleBackColor = true;
			// 
			// txtCandidateName
			// 
			this.txtCandidateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCandidateName.Location = new System.Drawing.Point(16, 63);
			this.txtCandidateName.Name = "txtCandidateName";
			this.txtCandidateName.ReadOnly = true;
			this.txtCandidateName.Size = new System.Drawing.Size(254, 24);
			this.txtCandidateName.TabIndex = 27;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(10, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 16);
			this.label1.TabIndex = 26;
			this.label1.Text = "Candidate";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(13, 98);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 16);
			this.label2.TabIndex = 28;
			this.label2.Text = "Passport";
			// 
			// txtCandidatePassport
			// 
			this.txtCandidatePassport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCandidatePassport.Location = new System.Drawing.Point(16, 129);
			this.txtCandidatePassport.MaxLength = 8;
			this.txtCandidatePassport.Name = "txtCandidatePassport";
			this.txtCandidatePassport.ReadOnly = true;
			this.txtCandidatePassport.Size = new System.Drawing.Size(254, 24);
			this.txtCandidatePassport.TabIndex = 29;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(369, 301);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(87, 16);
			this.label6.TabIndex = 67;
			this.label6.Text = "Finger Image";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(5, 301);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 16);
			this.label5.TabIndex = 66;
			this.label5.Text = "Finger Scan Status";
			// 
			// picFingerPrint
			// 
			this.picFingerPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.picFingerPrint.Location = new System.Drawing.Point(372, 320);
			this.picFingerPrint.Name = "picFingerPrint";
			this.picFingerPrint.Size = new System.Drawing.Size(192, 186);
			this.picFingerPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picFingerPrint.TabIndex = 65;
			this.picFingerPrint.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtCandidateName);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.txtCandidatePassport);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(34, 307);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(294, 177);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Candidate Details";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.picThumb);
			this.panel1.Controls.Add(this.labelStatus);
			this.panel1.Controls.Add(this.imgCandidatePhoto);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Location = new System.Drawing.Point(575, 7);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(364, 499);
			this.panel1.TabIndex = 68;
			// 
			// picThumb
			// 
			this.picThumb.Location = new System.Drawing.Point(209, 143);
			this.picThumb.Name = "picThumb";
			this.picThumb.Size = new System.Drawing.Size(127, 145);
			this.picThumb.TabIndex = 32;
			this.picThumb.TabStop = false;
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStatus.Location = new System.Drawing.Point(94, 91);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(92, 31);
			this.labelStatus.TabIndex = 31;
			this.labelStatus.Text = "Status";
			// 
			// imgCandidatePhoto
			// 
			this.imgCandidatePhoto.Location = new System.Drawing.Point(27, 143);
			this.imgCandidatePhoto.Name = "imgCandidatePhoto";
			this.imgCandidatePhoto.Size = new System.Drawing.Size(156, 145);
			this.imgCandidatePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgCandidatePhoto.TabIndex = 30;
			this.imgCandidatePhoto.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnClear);
			this.groupBox3.Controls.Add(this.btnSearch);
			this.groupBox3.Controls.Add(this.txtSearch);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Location = new System.Drawing.Point(11, 14);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(335, 52);
			this.groupBox3.TabIndex = 29;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Search";
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(265, 19);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(70, 22);
			this.btnClear.TabIndex = 3;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(183, 19);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(70, 22);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(60, 19);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(115, 20);
			this.txtSearch.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Passport";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// lstCurrentStatus
			// 
			this.lstCurrentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstCurrentStatus.FormattingEnabled = true;
			this.lstCurrentStatus.ItemHeight = 16;
			this.lstCurrentStatus.Location = new System.Drawing.Point(8, 326);
			this.lstCurrentStatus.Name = "lstCurrentStatus";
			this.lstCurrentStatus.Size = new System.Drawing.Size(322, 180);
			this.lstCurrentStatus.TabIndex = 64;
			// 
			// picStatusImageVarified
			// 
			this.picStatusImageVarified.Location = new System.Drawing.Point(50, 255);
			this.picStatusImageVarified.Name = "picStatusImageVarified";
			this.picStatusImageVarified.Size = new System.Drawing.Size(31, 30);
			this.picStatusImageVarified.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picStatusImageVarified.TabIndex = 62;
			this.picStatusImageVarified.TabStop = false;
			this.picStatusImageVarified.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dgvFP);
			this.groupBox1.Controls.Add(this.dtpTo);
			this.groupBox1.Controls.Add(this.dtpFrom);
			this.groupBox1.Controls.Add(this.btnRefreshList);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(9, 11);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(560, 233);
			this.groupBox1.TabIndex = 61;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Candidate List";
			// 
			// dgvFP
			// 
			this.dgvFP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvFP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvFP.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dgvFP.Location = new System.Drawing.Point(3, 72);
			this.dgvFP.MultiSelect = false;
			this.dgvFP.Name = "dgvFP";
			this.dgvFP.ReadOnly = true;
			this.dgvFP.RowHeadersWidth = 25;
			this.dgvFP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvFP.Size = new System.Drawing.Size(554, 158);
			this.dgvFP.TabIndex = 42;
			// 
			// dtpTo
			// 
			this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpTo.Location = new System.Drawing.Point(137, 30);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(112, 22);
			this.dtpTo.TabIndex = 47;
			// 
			// dtpFrom
			// 
			this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFrom.Location = new System.Drawing.Point(19, 30);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(112, 22);
			this.dtpFrom.TabIndex = 46;
			// 
			// btnRefreshList
			// 
			this.btnRefreshList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRefreshList.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshList.Image")));
			this.btnRefreshList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRefreshList.Location = new System.Drawing.Point(264, 16);
			this.btnRefreshList.Name = "btnRefreshList";
			this.btnRefreshList.Size = new System.Drawing.Size(93, 36);
			this.btnRefreshList.TabIndex = 44;
			this.btnRefreshList.Text = "Load List";
			this.btnRefreshList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnRefreshList.UseVisualStyleBackColor = true;
			this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
			// 
			// fingerScanner
			// 
			this.fingerScanner.Enabled = true;
			this.fingerScanner.Location = new System.Drawing.Point(8, 261);
			this.fingerScanner.Name = "fingerScanner";
			this.fingerScanner.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("fingerScanner.OcxState")));
			this.fingerScanner.Size = new System.Drawing.Size(24, 24);
			this.fingerScanner.TabIndex = 63;
			this.fingerScanner.OnImageReceived += new AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEventHandler(this.fingerScanner_OnImageReceived);
			this.fingerScanner.OnEnroll += new AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEventHandler(this.fingerScanner_OnEnroll);
			this.fingerScanner.OnCapture += new AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEventHandler(this.fingerScanner_OnCapture);
			this.fingerScanner.OnFingerTouching += new System.EventHandler(this.fingerScanner_OnFingerTouching);
			this.fingerScanner.OnFingerLeaving += new System.EventHandler(this.fingerScanner_OnFingerLeaving);
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblStatus.AutoSize = true;
			this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatus.Location = new System.Drawing.Point(203, 263);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(15, 15);
			this.lblStatus.TabIndex = 60;
			this.lblStatus.Text = "--";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(106, 261);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 16);
			this.label4.TabIndex = 59;
			this.label4.Text = "Device Status";
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Enabled = false;
			this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDisconnect.Location = new System.Drawing.Point(482, 250);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(85, 35);
			this.btnDisconnect.TabIndex = 58;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnConnect.Location = new System.Drawing.Point(387, 250);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(85, 35);
			this.btnConnect.TabIndex = 57;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// FrmCandidateVerify
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(951, 521);
			this.Controls.Add(this.btnEnroll);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.picFingerPrint);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lstCurrentStatus);
			this.Controls.Add(this.picStatusImageVarified);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.fingerScanner);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnDisconnect);
			this.Controls.Add(this.btnConnect);
			this.Name = "FrmCandidateVerify";
			this.Text = "FrmCandidateVerify";
			this.Load += new System.EventHandler(this.FrmCandidateVerify_Load);
			((System.ComponentModel.ISupportInitialize)(this.picFingerPrint)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picThumb)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgCandidatePhoto)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picStatusImageVarified)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvFP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fingerScanner)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnEnroll;
		private System.Windows.Forms.TextBox txtCandidateName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCandidatePassport;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox picFingerPrint;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListBox lstCurrentStatus;
		private System.Windows.Forms.PictureBox picStatusImageVarified;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView dgvFP;
		private System.Windows.Forms.DateTimePicker dtpTo;
		private System.Windows.Forms.DateTimePicker dtpFrom;
		private System.Windows.Forms.Button btnRefreshList;
		public AxZKFPEngXControl.AxZKFPEngX fingerScanner;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnDisconnect;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox imgCandidatePhoto;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.PictureBox picThumb;
		private System.Windows.Forms.Button btnClear;
	}
}