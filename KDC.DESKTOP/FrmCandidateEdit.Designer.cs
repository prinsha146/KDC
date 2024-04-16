namespace KDC.DESKTOP
{
    partial class FrmCandidateEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCandidateEdit));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkThumbNotTaken = new System.Windows.Forms.CheckBox();
            this.imgCandidatePhoto = new System.Windows.Forms.PictureBox();
            this.lblCameraStatus = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnCameraConnect = new System.Windows.Forms.Button();
            this.lblCamera = new System.Windows.Forms.Label();
            this.ddlCameraList = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtCandidateName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCandidatePassport = new System.Windows.Forms.TextBox();
            this.Gender = new System.Windows.Forms.Label();
            this.rdbMale = new System.Windows.Forms.RadioButton();
            this.rdbFemale = new System.Windows.Forms.RadioButton();
            this.imgCandidateVideo = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.picFingerPrint = new System.Windows.Forms.PictureBox();
            this.lstCurrentStatus = new System.Windows.Forms.ListBox();
            this.picStatusImageVarified = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvFP = new System.Windows.Forms.DataGridView();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.fingerScanner = new AxZKFPEngXControl.AxZKFPEngX();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCandidatePhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCandidateVideo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFingerPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusImageVarified)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerScanner)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkThumbNotTaken);
            this.groupBox2.Controls.Add(this.imgCandidatePhoto);
            this.groupBox2.Controls.Add(this.lblCameraStatus);
            this.groupBox2.Controls.Add(this.btnCapture);
            this.groupBox2.Controls.Add(this.btnCameraConnect);
            this.groupBox2.Controls.Add(this.lblCamera);
            this.groupBox2.Controls.Add(this.ddlCameraList);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.txtCandidateName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtCandidatePassport);
            this.groupBox2.Controls.Add(this.Gender);
            this.groupBox2.Controls.Add(this.rdbMale);
            this.groupBox2.Controls.Add(this.rdbFemale);
            this.groupBox2.Controls.Add(this.imgCandidateVideo);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 479);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Candidate Details";
            // 
            // chkThumbNotTaken
            // 
            this.chkThumbNotTaken.AutoSize = true;
            this.chkThumbNotTaken.Location = new System.Drawing.Point(90, 348);
            this.chkThumbNotTaken.Name = "chkThumbNotTaken";
            this.chkThumbNotTaken.Size = new System.Drawing.Size(125, 20);
            this.chkThumbNotTaken.TabIndex = 44;
            this.chkThumbNotTaken.Text = "Thumn not taken";
            this.chkThumbNotTaken.UseVisualStyleBackColor = true;
            // 
            // imgCandidatePhoto
            // 
            this.imgCandidatePhoto.Location = new System.Drawing.Point(237, 101);
            this.imgCandidatePhoto.Name = "imgCandidatePhoto";
            this.imgCandidatePhoto.Size = new System.Drawing.Size(133, 134);
            this.imgCandidatePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCandidatePhoto.TabIndex = 43;
            this.imgCandidatePhoto.TabStop = false;
            // 
            // lblCameraStatus
            // 
            this.lblCameraStatus.AutoSize = true;
            this.lblCameraStatus.Location = new System.Drawing.Point(161, 125);
            this.lblCameraStatus.Name = "lblCameraStatus";
            this.lblCameraStatus.Size = new System.Drawing.Size(45, 16);
            this.lblCameraStatus.TabIndex = 42;
            this.lblCameraStatus.Text = "Status";
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(154, 203);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(80, 30);
            this.btnCapture.TabIndex = 41;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            // 
            // btnCameraConnect
            // 
            this.btnCameraConnect.Location = new System.Drawing.Point(154, 167);
            this.btnCameraConnect.Name = "btnCameraConnect";
            this.btnCameraConnect.Size = new System.Drawing.Size(80, 30);
            this.btnCameraConnect.TabIndex = 40;
            this.btnCameraConnect.Text = "&Camera Ready";
            this.btnCameraConnect.UseVisualStyleBackColor = true;
            // 
            // lblCamera
            // 
            this.lblCamera.AutoSize = true;
            this.lblCamera.Location = new System.Drawing.Point(13, 69);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(56, 16);
            this.lblCamera.TabIndex = 39;
            this.lblCamera.Text = "Camera";
            // 
            // ddlCameraList
            // 
            this.ddlCameraList.FormattingEnabled = true;
            this.ddlCameraList.Location = new System.Drawing.Point(90, 61);
            this.ddlCameraList.Name = "ddlCameraList";
            this.ddlCameraList.Size = new System.Drawing.Size(178, 24);
            this.ddlCameraList.TabIndex = 38;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(282, 58);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(85, 30);
            this.btnRefresh.TabIndex = 37;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // txtCandidateName
            // 
            this.txtCandidateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCandidateName.Location = new System.Drawing.Point(90, 246);
            this.txtCandidateName.Name = "txtCandidateName";
            this.txtCandidateName.ReadOnly = true;
            this.txtCandidateName.Size = new System.Drawing.Size(280, 24);
            this.txtCandidateName.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Candidate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Passport";
            // 
            // txtCandidatePassport
            // 
            this.txtCandidatePassport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCandidatePassport.Location = new System.Drawing.Point(90, 283);
            this.txtCandidatePassport.MaxLength = 8;
            this.txtCandidatePassport.Name = "txtCandidatePassport";
            this.txtCandidatePassport.ReadOnly = true;
            this.txtCandidatePassport.Size = new System.Drawing.Size(280, 24);
            this.txtCandidatePassport.TabIndex = 29;
            // 
            // Gender
            // 
            this.Gender.AutoSize = true;
            this.Gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gender.Location = new System.Drawing.Point(10, 318);
            this.Gender.Name = "Gender";
            this.Gender.Size = new System.Drawing.Size(53, 16);
            this.Gender.TabIndex = 33;
            this.Gender.Text = "Gender";
            // 
            // rdbMale
            // 
            this.rdbMale.AutoSize = true;
            this.rdbMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMale.Location = new System.Drawing.Point(90, 318);
            this.rdbMale.Name = "rdbMale";
            this.rdbMale.Size = new System.Drawing.Size(56, 20);
            this.rdbMale.TabIndex = 32;
            this.rdbMale.Text = "Male";
            this.rdbMale.UseVisualStyleBackColor = true;
            // 
            // rdbFemale
            // 
            this.rdbFemale.AutoSize = true;
            this.rdbFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbFemale.Location = new System.Drawing.Point(210, 320);
            this.rdbFemale.Name = "rdbFemale";
            this.rdbFemale.Size = new System.Drawing.Size(72, 20);
            this.rdbFemale.TabIndex = 31;
            this.rdbFemale.Text = "Female";
            this.rdbFemale.UseVisualStyleBackColor = true;
            // 
            // imgCandidateVideo
            // 
            this.imgCandidateVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgCandidateVideo.Location = new System.Drawing.Point(13, 101);
            this.imgCandidateVideo.Name = "imgCandidateVideo";
            this.imgCandidateVideo.Size = new System.Drawing.Size(136, 134);
            this.imgCandidateVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCandidateVideo.TabIndex = 25;
            this.imgCandidateVideo.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(174, 489);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(296, 489);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 30);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Clear  ";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Location = new System.Drawing.Point(618, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 532);
            this.panel1.TabIndex = 67;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(403, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 66;
            this.label6.Text = "Finger Image";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 65;
            this.label5.Text = "Finger Scan Status";
            // 
            // picFingerPrint
            // 
            this.picFingerPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picFingerPrint.Location = new System.Drawing.Point(406, 320);
            this.picFingerPrint.Name = "picFingerPrint";
            this.picFingerPrint.Size = new System.Drawing.Size(192, 186);
            this.picFingerPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFingerPrint.TabIndex = 64;
            this.picFingerPrint.TabStop = false;
            // 
            // lstCurrentStatus
            // 
            this.lstCurrentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCurrentStatus.FormattingEnabled = true;
            this.lstCurrentStatus.ItemHeight = 16;
            this.lstCurrentStatus.Location = new System.Drawing.Point(8, 326);
            this.lstCurrentStatus.Name = "lstCurrentStatus";
            this.lstCurrentStatus.Size = new System.Drawing.Size(322, 180);
            this.lstCurrentStatus.TabIndex = 63;
            // 
            // picStatusImageVarified
            // 
            this.picStatusImageVarified.Location = new System.Drawing.Point(50, 255);
            this.picStatusImageVarified.Name = "picStatusImageVarified";
            this.picStatusImageVarified.Size = new System.Drawing.Size(31, 30);
            this.picStatusImageVarified.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStatusImageVarified.TabIndex = 61;
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
            this.groupBox1.Size = new System.Drawing.Size(592, 233);
            this.groupBox1.TabIndex = 60;
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
            this.dgvFP.RowHeadersWidth = 25;
            this.dgvFP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFP.Size = new System.Drawing.Size(586, 158);
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
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(203, 288);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(15, 15);
            this.lblStatus.TabIndex = 59;
            this.lblStatus.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(106, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 58;
            this.label4.Text = "Device Status";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(421, 250);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(85, 35);
            this.btnConnect.TabIndex = 56;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(516, 250);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(85, 35);
            this.btnDisconnect.TabIndex = 57;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // fingerScanner
            // 
            this.fingerScanner.Enabled = true;
            this.fingerScanner.Location = new System.Drawing.Point(8, 261);
            this.fingerScanner.Name = "fingerScanner";
            this.fingerScanner.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("fingerScanner.OcxState")));
            this.fingerScanner.Size = new System.Drawing.Size(24, 24);
            this.fingerScanner.TabIndex = 62;
            // 
            // FrmCandidateEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 546);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picFingerPrint);
            this.Controls.Add(this.lstCurrentStatus);
            this.Controls.Add(this.picStatusImageVarified);
            this.Controls.Add(this.fingerScanner);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnDisconnect);
            this.Name = "FrmCandidateEdit";
            this.Text = "FrmCandidateEdit";
            this.Load += new System.EventHandler(this.FrmCandidateEdit_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCandidatePhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCandidateVideo)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFingerPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusImageVarified)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerScanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkThumbNotTaken;
        private System.Windows.Forms.PictureBox imgCandidatePhoto;
        private System.Windows.Forms.Label lblCameraStatus;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnCameraConnect;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.ComboBox ddlCameraList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtCandidateName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCandidatePassport;
        private System.Windows.Forms.Label Gender;
        private System.Windows.Forms.RadioButton rdbMale;
        private System.Windows.Forms.RadioButton rdbFemale;
        private System.Windows.Forms.PictureBox imgCandidateVideo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picFingerPrint;
        private System.Windows.Forms.ListBox lstCurrentStatus;
        private System.Windows.Forms.PictureBox picStatusImageVarified;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvFP;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        public AxZKFPEngXControl.AxZKFPEngX fingerScanner;
    }
}