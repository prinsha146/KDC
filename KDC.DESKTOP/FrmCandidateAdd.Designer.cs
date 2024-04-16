namespace KDC.DESKTOP
{
    partial class FrmCandidateAdd
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCandidateAdd));
			this.lblStatus = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			this.dgvFP = new System.Windows.Forms.DataGridView();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.btnRefreshList = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.picStatusImageVarified = new System.Windows.Forms.PictureBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.picFingerPrint = new System.Windows.Forms.PictureBox();
			this.lstCurrentStatus = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.imgCandidatePhoto = new System.Windows.Forms.PictureBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkThumb = new System.Windows.Forms.CheckBox();
			this.txtCandidateId = new System.Windows.Forms.TextBox();
			this.chkThumbNotTaken = new System.Windows.Forms.CheckBox();
			this.txtCandidateName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCandidatePassport = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.fingerScanner = new AxZKFPEngXControl.AxZKFPEngX();
			this.btnEnroll = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvFP)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picStatusImageVarified)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picFingerPrint)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgCandidatePhoto)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fingerScanner)).BeginInit();
			this.SuspendLayout();
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblStatus.AutoSize = true;
			this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatus.Location = new System.Drawing.Point(206, 289);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(15, 15);
			this.lblStatus.TabIndex = 34;
			this.lblStatus.Text = "--";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(109, 262);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 16);
			this.label4.TabIndex = 33;
			this.label4.Text = "Device Status";
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Enabled = false;
			this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDisconnect.Location = new System.Drawing.Point(485, 251);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(85, 35);
			this.btnDisconnect.TabIndex = 32;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnConnect.Location = new System.Drawing.Point(390, 251);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(85, 35);
			this.btnConnect.TabIndex = 31;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
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
			this.dgvFP.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFP_CellDoubleClick);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dgvFP);
			this.groupBox1.Controls.Add(this.dtpTo);
			this.groupBox1.Controls.Add(this.dtpFrom);
			this.groupBox1.Controls.Add(this.btnRefreshList);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(560, 233);
			this.groupBox1.TabIndex = 48;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Candidate List";
			// 
			// picStatusImageVarified
			// 
			this.picStatusImageVarified.Location = new System.Drawing.Point(53, 256);
			this.picStatusImageVarified.Name = "picStatusImageVarified";
			this.picStatusImageVarified.Size = new System.Drawing.Size(31, 30);
			this.picStatusImageVarified.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picStatusImageVarified.TabIndex = 49;
			this.picStatusImageVarified.TabStop = false;
			this.picStatusImageVarified.Visible = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(372, 302);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(87, 16);
			this.label6.TabIndex = 54;
			this.label6.Text = "Finger Image";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 302);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 16);
			this.label5.TabIndex = 53;
			this.label5.Text = "Finger Scan Status";
			// 
			// picFingerPrint
			// 
			this.picFingerPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.picFingerPrint.Location = new System.Drawing.Point(375, 321);
			this.picFingerPrint.Name = "picFingerPrint";
			this.picFingerPrint.Size = new System.Drawing.Size(192, 186);
			this.picFingerPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picFingerPrint.TabIndex = 52;
			this.picFingerPrint.TabStop = false;
			// 
			// lstCurrentStatus
			// 
			this.lstCurrentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstCurrentStatus.FormattingEnabled = true;
			this.lstCurrentStatus.ItemHeight = 16;
			this.lstCurrentStatus.Location = new System.Drawing.Point(11, 327);
			this.lstCurrentStatus.Name = "lstCurrentStatus";
			this.lstCurrentStatus.Size = new System.Drawing.Size(322, 180);
			this.lstCurrentStatus.TabIndex = 51;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.imgCandidatePhoto);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnClear);
			this.panel1.Location = new System.Drawing.Point(578, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(312, 532);
			this.panel1.TabIndex = 55;
			// 
			// imgCandidatePhoto
			// 
			this.imgCandidatePhoto.Location = new System.Drawing.Point(83, 34);
			this.imgCandidatePhoto.Name = "imgCandidatePhoto";
			this.imgCandidatePhoto.Size = new System.Drawing.Size(156, 145);
			this.imgCandidatePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgCandidatePhoto.TabIndex = 31;
			this.imgCandidatePhoto.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkThumb);
			this.groupBox2.Controls.Add(this.txtCandidateId);
			this.groupBox2.Controls.Add(this.chkThumbNotTaken);
			this.groupBox2.Controls.Add(this.txtCandidateName);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.txtCandidatePassport);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(9, 211);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(294, 240);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Candidate Details";
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// chkThumb
			// 
			this.chkThumb.AutoSize = true;
			this.chkThumb.Checked = true;
			this.chkThumb.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkThumb.Location = new System.Drawing.Point(16, 204);
			this.chkThumb.Name = "chkThumb";
			this.chkThumb.Size = new System.Drawing.Size(142, 20);
			this.chkThumb.TabIndex = 46;
			this.chkThumb.Text = "Update Finger Print";
			this.chkThumb.UseVisualStyleBackColor = true;
			// 
			// txtCandidateId
			// 
			this.txtCandidateId.Location = new System.Drawing.Point(147, 158);
			this.txtCandidateId.Name = "txtCandidateId";
			this.txtCandidateId.Size = new System.Drawing.Size(123, 22);
			this.txtCandidateId.TabIndex = 45;
			this.txtCandidateId.Text = "0";
			this.txtCandidateId.Visible = false;
			// 
			// chkThumbNotTaken
			// 
			this.chkThumbNotTaken.AutoSize = true;
			this.chkThumbNotTaken.Location = new System.Drawing.Point(16, 163);
			this.chkThumbNotTaken.Name = "chkThumbNotTaken";
			this.chkThumbNotTaken.Size = new System.Drawing.Size(126, 20);
			this.chkThumbNotTaken.TabIndex = 44;
			this.chkThumbNotTaken.Text = "Thumb not taken";
			this.chkThumbNotTaken.UseVisualStyleBackColor = true;
			this.chkThumbNotTaken.CheckedChanged += new System.EventHandler(this.chkThumbNotTaken_CheckedChanged);
			// 
			// txtCandidateName
			// 
			this.txtCandidateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCandidateName.Location = new System.Drawing.Point(16, 51);
			this.txtCandidateName.Name = "txtCandidateName";
			this.txtCandidateName.ReadOnly = true;
			this.txtCandidateName.Size = new System.Drawing.Size(254, 24);
			this.txtCandidateName.TabIndex = 27;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(10, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 16);
			this.label1.TabIndex = 26;
			this.label1.Text = "Candidate";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(13, 93);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 16);
			this.label2.TabIndex = 28;
			this.label2.Text = "Passport";
			// 
			// txtCandidatePassport
			// 
			this.txtCandidatePassport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCandidatePassport.Location = new System.Drawing.Point(16, 124);
			this.txtCandidatePassport.MaxLength = 8;
			this.txtCandidatePassport.Name = "txtCandidatePassport";
			this.txtCandidatePassport.ReadOnly = true;
			this.txtCandidatePassport.Size = new System.Drawing.Size(254, 24);
			this.txtCandidatePassport.TabIndex = 29;
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(42, 469);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(85, 30);
			this.btnSave.TabIndex = 27;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnClear
			// 
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
			this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClear.Location = new System.Drawing.Point(190, 469);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(85, 30);
			this.btnClear.TabIndex = 26;
			this.btnClear.Text = "Clear  ";
			this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// fingerScanner
			// 
			this.fingerScanner.Enabled = true;
			this.fingerScanner.Location = new System.Drawing.Point(11, 262);
			this.fingerScanner.Name = "fingerScanner";
			this.fingerScanner.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("fingerScanner.OcxState")));
			this.fingerScanner.Size = new System.Drawing.Size(24, 24);
			this.fingerScanner.TabIndex = 50;
			this.fingerScanner.OnImageReceived += new AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEventHandler(this.fingerScanner_OnImageReceived);
			this.fingerScanner.OnEnroll += new AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEventHandler(this.fingerScanner_OnEnroll);
			this.fingerScanner.OnCapture += new AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEventHandler(this.fingerScanner_OnCapture);
			this.fingerScanner.OnFingerTouching += new System.EventHandler(this.fingerScanner_OnFingerTouching);
			this.fingerScanner.OnFingerLeaving += new System.EventHandler(this.fingerScanner_OnFingerLeaving);
			// 
			// btnEnroll
			// 
			this.btnEnroll.Enabled = false;
			this.btnEnroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEnroll.Location = new System.Drawing.Point(296, 251);
			this.btnEnroll.Name = "btnEnroll";
			this.btnEnroll.Size = new System.Drawing.Size(85, 35);
			this.btnEnroll.TabIndex = 56;
			this.btnEnroll.Text = "Enroll";
			this.btnEnroll.UseVisualStyleBackColor = true;
			this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
			// 
			// FrmCandidateAdd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(893, 546);
			this.Controls.Add(this.btnEnroll);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.picFingerPrint);
			this.Controls.Add(this.lstCurrentStatus);
			this.Controls.Add(this.fingerScanner);
			this.Controls.Add(this.picStatusImageVarified);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnDisconnect);
			this.Controls.Add(this.btnConnect);
			this.Name = "FrmCandidateAdd";
			this.Text = "FrmCandidateAdd";
			this.Load += new System.EventHandler(this.FrmCandidateAdd_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvFP)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picStatusImageVarified)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picFingerPrint)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.imgCandidatePhoto)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.fingerScanner)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.DataGridView dgvFP;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picStatusImageVarified;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picFingerPrint;
        private System.Windows.Forms.ListBox lstCurrentStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCandidateName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCandidatePassport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkThumbNotTaken;
        public AxZKFPEngXControl.AxZKFPEngX fingerScanner;
        private System.Windows.Forms.TextBox txtCandidateId;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.CheckBox chkThumb;
		private System.Windows.Forms.PictureBox imgCandidatePhoto;
	}
}