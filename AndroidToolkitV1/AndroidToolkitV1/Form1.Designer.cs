namespace AndroidToolkitV1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSDK = new System.Windows.Forms.Button();
            this.btnBkupCont = new System.Windows.Forms.Button();
            this.btnResSD = new System.Windows.Forms.Button();
            this.btnBackupSD = new System.Windows.Forms.Button();
            this.btnResCont = new System.Windows.Forms.Button();
            this.btnRebootR = new System.Windows.Forms.Button();
            this.btnResPic = new System.Windows.Forms.Button();
            this.btnBkupPic = new System.Windows.Forms.Button();
            this.btnReboot = new System.Windows.Forms.Button();
            this.btnFolderBkup = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkDownload = new System.Windows.Forms.LinkLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.picDefault = new System.Windows.Forms.PictureBox();
            this.btnWebDl = new System.Windows.Forms.Button();
            this.lblStats = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnShowHide = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picNotReady = new System.Windows.Forms.PictureBox();
            this.picReady = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNotReady)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReady)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSDK
            // 
            this.btnSDK.Location = new System.Drawing.Point(270, 12);
            this.btnSDK.Name = "btnSDK";
            this.btnSDK.Size = new System.Drawing.Size(131, 42);
            this.btnSDK.TabIndex = 0;
            this.btnSDK.Text = "Download SDK";
            this.btnSDK.UseVisualStyleBackColor = true;
            this.btnSDK.Click += new System.EventHandler(this.btnSDK_Click);
            // 
            // btnBkupCont
            // 
            this.btnBkupCont.Enabled = false;
            this.btnBkupCont.Location = new System.Drawing.Point(286, 139);
            this.btnBkupCont.Name = "btnBkupCont";
            this.btnBkupCont.Size = new System.Drawing.Size(131, 42);
            this.btnBkupCont.TabIndex = 1;
            this.btnBkupCont.Text = "Backup Contacts";
            this.btnBkupCont.UseVisualStyleBackColor = true;
            this.btnBkupCont.Click += new System.EventHandler(this.btnBkupCont_Click);
            // 
            // btnResSD
            // 
            this.btnResSD.Enabled = false;
            this.btnResSD.Location = new System.Drawing.Point(12, 187);
            this.btnResSD.Name = "btnResSD";
            this.btnResSD.Size = new System.Drawing.Size(131, 42);
            this.btnResSD.TabIndex = 3;
            this.btnResSD.Text = "Restore /sdcard/";
            this.btnResSD.UseVisualStyleBackColor = true;
            this.btnResSD.Click += new System.EventHandler(this.btnResSD_Click);
            // 
            // btnBackupSD
            // 
            this.btnBackupSD.Enabled = false;
            this.btnBackupSD.Location = new System.Drawing.Point(12, 139);
            this.btnBackupSD.Name = "btnBackupSD";
            this.btnBackupSD.Size = new System.Drawing.Size(131, 42);
            this.btnBackupSD.TabIndex = 2;
            this.btnBackupSD.Text = "Backup /sdcard/";
            this.btnBackupSD.UseVisualStyleBackColor = true;
            this.btnBackupSD.Click += new System.EventHandler(this.btnBackupSD_Click);
            // 
            // btnResCont
            // 
            this.btnResCont.Enabled = false;
            this.btnResCont.Location = new System.Drawing.Point(286, 187);
            this.btnResCont.Name = "btnResCont";
            this.btnResCont.Size = new System.Drawing.Size(131, 42);
            this.btnResCont.TabIndex = 5;
            this.btnResCont.Text = "Restore Contacts";
            this.btnResCont.UseVisualStyleBackColor = true;
            this.btnResCont.Click += new System.EventHandler(this.btnResCont_Click);
            // 
            // btnRebootR
            // 
            this.btnRebootR.Enabled = false;
            this.btnRebootR.Location = new System.Drawing.Point(601, 235);
            this.btnRebootR.Name = "btnRebootR";
            this.btnRebootR.Size = new System.Drawing.Size(131, 42);
            this.btnRebootR.TabIndex = 9;
            this.btnRebootR.Text = "Reboot Recovery";
            this.btnRebootR.UseVisualStyleBackColor = true;
            this.btnRebootR.Click += new System.EventHandler(this.btnRebootR_Click);
            // 
            // btnResPic
            // 
            this.btnResPic.Enabled = false;
            this.btnResPic.Location = new System.Drawing.Point(149, 187);
            this.btnResPic.Name = "btnResPic";
            this.btnResPic.Size = new System.Drawing.Size(131, 42);
            this.btnResPic.TabIndex = 8;
            this.btnResPic.Text = "Restore /DCIM/";
            this.btnResPic.UseVisualStyleBackColor = true;
            this.btnResPic.Click += new System.EventHandler(this.btnResPic_Click);
            // 
            // btnBkupPic
            // 
            this.btnBkupPic.Enabled = false;
            this.btnBkupPic.Location = new System.Drawing.Point(149, 139);
            this.btnBkupPic.Name = "btnBkupPic";
            this.btnBkupPic.Size = new System.Drawing.Size(131, 42);
            this.btnBkupPic.TabIndex = 7;
            this.btnBkupPic.Text = "Backup /DCIM/";
            this.btnBkupPic.UseVisualStyleBackColor = true;
            this.btnBkupPic.Click += new System.EventHandler(this.btnBkupPic_Click);
            // 
            // btnReboot
            // 
            this.btnReboot.Enabled = false;
            this.btnReboot.Location = new System.Drawing.Point(601, 187);
            this.btnReboot.Name = "btnReboot";
            this.btnReboot.Size = new System.Drawing.Size(131, 42);
            this.btnReboot.TabIndex = 6;
            this.btnReboot.Text = "Reboot";
            this.btnReboot.UseVisualStyleBackColor = true;
            this.btnReboot.Click += new System.EventHandler(this.btnReboot_Click);
            // 
            // btnFolderBkup
            // 
            this.btnFolderBkup.Enabled = false;
            this.btnFolderBkup.Location = new System.Drawing.Point(423, 164);
            this.btnFolderBkup.Name = "btnFolderBkup";
            this.btnFolderBkup.Size = new System.Drawing.Size(131, 42);
            this.btnFolderBkup.TabIndex = 10;
            this.btnFolderBkup.Text = "Backup specific folder";
            this.btnFolderBkup.UseVisualStyleBackColor = true;
            this.btnFolderBkup.Click += new System.EventHandler(this.btnFolderBkup_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(689, 404);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(23, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "null";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(561, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "This toolkit is for testing purposes only";
            // 
            // lnkDownload
            // 
            this.lnkDownload.AutoSize = true;
            this.lnkDownload.Location = new System.Drawing.Point(293, 57);
            this.lnkDownload.Name = "lnkDownload";
            this.lnkDownload.Size = new System.Drawing.Size(81, 13);
            this.lnkDownload.TabIndex = 13;
            this.lnkDownload.TabStop = true;
            this.lnkDownload.Text = "Download Here";
            this.lnkDownload.Visible = false;
            this.lnkDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDownload_LinkClicked);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // picDefault
            // 
            this.picDefault.BackgroundImage = global::AndroidToolkitV1.Properties.Resources.android;
            this.picDefault.Location = new System.Drawing.Point(601, 12);
            this.picDefault.Name = "picDefault";
            this.picDefault.Size = new System.Drawing.Size(131, 145);
            this.picDefault.TabIndex = 15;
            this.picDefault.TabStop = false;
            this.picDefault.Visible = false;
            // 
            // btnWebDl
            // 
            this.btnWebDl.Location = new System.Drawing.Point(270, 73);
            this.btnWebDl.Name = "btnWebDl";
            this.btnWebDl.Size = new System.Drawing.Size(131, 29);
            this.btnWebDl.TabIndex = 16;
            this.btnWebDl.Text = "Downloaded from Web";
            this.btnWebDl.UseVisualStyleBackColor = true;
            this.btnWebDl.Click += new System.EventHandler(this.btnWebDl_Click);
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Location = new System.Drawing.Point(630, 403);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(53, 13);
            this.lblStats.TabIndex = 17;
            this.lblStats.Text = "STATUS:";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(95, 247);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtStatus.Size = new System.Drawing.Size(445, 100);
            this.txtStatus.TabIndex = 18;
            // 
            // btnShowHide
            // 
            this.btnShowHide.Location = new System.Drawing.Point(466, 353);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(75, 23);
            this.btnShowHide.TabIndex = 19;
            this.btnShowHide.Text = "Show / Hide";
            this.btnShowHide.UseVisualStyleBackColor = true;
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 46);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picNotReady
            // 
            this.picNotReady.BackgroundImage = global::AndroidToolkitV1.Properties.Resources.android_notready;
            this.picNotReady.Location = new System.Drawing.Point(601, 12);
            this.picNotReady.Name = "picNotReady";
            this.picNotReady.Size = new System.Drawing.Size(131, 145);
            this.picNotReady.TabIndex = 21;
            this.picNotReady.TabStop = false;
            this.picNotReady.Visible = false;
            // 
            // picReady
            // 
            this.picReady.BackgroundImage = global::AndroidToolkitV1.Properties.Resources.android_ready;
            this.picReady.Location = new System.Drawing.Point(601, 13);
            this.picReady.Name = "picReady";
            this.picReady.Size = new System.Drawing.Size(131, 144);
            this.picReady.TabIndex = 22;
            this.picReady.TabStop = false;
            this.picReady.Visible = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 438);
            this.Controls.Add(this.picReady);
            this.Controls.Add(this.picNotReady);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnShowHide);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnWebDl);
            this.Controls.Add(this.picDefault);
            this.Controls.Add(this.lnkDownload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnFolderBkup);
            this.Controls.Add(this.btnRebootR);
            this.Controls.Add(this.btnResPic);
            this.Controls.Add(this.btnBkupPic);
            this.Controls.Add(this.btnReboot);
            this.Controls.Add(this.btnResCont);
            this.Controls.Add(this.btnResSD);
            this.Controls.Add(this.btnBackupSD);
            this.Controls.Add(this.btnBkupCont);
            this.Controls.Add(this.btnSDK);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Android Toolkit v1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNotReady)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReady)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSDK;
        private System.Windows.Forms.Button btnBkupCont;
        private System.Windows.Forms.Button btnResSD;
        private System.Windows.Forms.Button btnBackupSD;
        private System.Windows.Forms.Button btnResCont;
        private System.Windows.Forms.Button btnRebootR;
        private System.Windows.Forms.Button btnResPic;
        private System.Windows.Forms.Button btnBkupPic;
        private System.Windows.Forms.Button btnReboot;
        private System.Windows.Forms.Button btnFolderBkup;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkDownload;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox picDefault;
        private System.Windows.Forms.Button btnWebDl;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnShowHide;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picNotReady;
        private System.Windows.Forms.PictureBox picReady;
    }
}

