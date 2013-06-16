using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.IO.Compression;
using Ionic.Zip;


 

namespace AndroidToolkitV1
{
    
    public partial class Form1 : Form
    {
        //common variables that can be used by all methods/functions
        string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string sdkFolder; 
        //set cmd path from sdkFolder string
        string cmd;
        //sdkfolder correct
        bool adbFound;
        //adb variables
        string adb = "\\adb.exe";
        string devices ="/c adb devices";
        string reboot = "/c adb reboot";
        string recovery = "/c adb reboot recovery";
        string pictureBackup = "/c adb pull /sdcard/dcim/camera/ ";
        string backupLocation;
        string sdCardBackup = "/c adb pull /sdcard/ ";
        string backupContacts;
        string adbPush = "/c adb push ";
        string restorePics = " /sdcard/dcim/camera/";
        string restoreSdcard = " /sdcard/";
        string restoreContacts;
        string backupFolder; 

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //Blank out status
            lblStatus.Text = "Waiting...";
            // Add a link to the LinkLabel.
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "http://dl.google.com/android/adt/adt-bundle-windows-x86-20130522.zip";
            lnkDownload.Links.Add(link);
            btnWebDl.Enabled = false;
            btnWebDl.Visible = false;
            lnkDownload.Enabled = false;

         }

        //trouble downloading ?
        private void lnkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
        private void btnSDK_Click(object sender, EventArgs e)
        {
            //check if client already has SDK or not?
            string message = "Do you have the Android SDK already?";
            string title = "Problem?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message,title ,buttons, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Point me to the SDK folder then make disable the download button/link and enable other buttons
                    btnSDK.Enabled = false;
                    lnkDownload.Enabled = false;
                    SDKFolder();
                }
                else
                {
                    string message2 = "This method is slower, you can download from the link below, are you sure you want to continue?";
                    string title2 = "Attention";
                    MessageBoxButtons buttons2 = MessageBoxButtons.OKCancel;
                    DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Warning);
                        if (result2 == DialogResult.OK)
                        {

            
            // the URL to download the file from
            string sUrlToReadFileFrom = "http://dl.google.com/android/adt/adt-bundle-windows-x86-20130522.zip";
            // the path to write the file to
            string sFilePathToWriteFileTo = Path.Combine(desktopFolder, "adt-bundle-windows-x86-20130522.zip");
            WebClient client = new WebClient();
            //client.DownloadProgressChanged += client_DownloadProgressChanged;
            client.DownloadFileCompleted += client_DownloadFileCompleted;
            client.DownloadFileAsync(new Uri(sUrlToReadFileFrom), (sFilePathToWriteFileTo));
        }
            else
            {
                lnkDownload.Visible = true;
                lnkDownload.Enabled = true;
                btnSDK.Enabled = false;
                btnWebDl.Visible = true;
                btnWebDl.Enabled = true;
                
            }
        }   
    }

        

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string message = "Download Complete, the file is on your Desktop, do you want me to extract it for you?";
            string title = "Message";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message,title ,buttons, MessageBoxIcon.Question);
             if (result == DialogResult.Yes)
             {

                 Extract();
             }
             else
             {
                 cancel();
             }
                    

        }

        private void downloadCanceled()
        {
            
            MessageBox.Show("Download Canceled","Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        void cancel()
        {
            MessageBox.Show("Extraction Canceled, please extract the file before proceeding", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            SDKFolder();
        }

        
        void Extract()
            {                              
                 string zipPath = Path.Combine(desktopFolder, "adt-bundle-windows-x86-20130522.zip");
                 string extractPath = Path.Combine(desktopFolder, "Android");
                 //extract .zip file 
                 ZipFile zip = ZipFile.Read(zipPath);
                 Directory.CreateDirectory(extractPath);
                 zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                 SDKFolder();

            }

        /* void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
         {
            progressBar1.Maximum = (int)e.TotalBytesToReceive / 100;
            progressBar1.Value = (int)e.BytesReceived / 100;
            long total = (e.TotalBytesToReceive / 1024) / 1024;
            long recieved = (e.BytesReceived / 1024) / 1024;
            lblStatus.Text = "" + recieved + "/" + total + " Mb";
        }
        */

        public void SDKFolder()
        {         
            //Location of SDK given by user saved as string to use for buttons 
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                MessageBox.Show("Please select the 'platform-tools' folder located within the SDK folder", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dlg.Description = "Select the 'platform-tools' folder";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    sdkFolder = dlg.SelectedPath;
                    adbExists();
                }
                else
                {
            //else use the downloaded and extracted location
            sdkFolder = Path.Combine(desktopFolder, "Android\\adt-bundle-windows-x86-20130522\\sdk\\platform-tools");
                adbExists();
        }
        }
}

        private void btnWebDl_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Please Extract the downloaded .zip","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SDKFolder();
            
        }

        private void adbExists()
        {                       
            //make sure adb.exe and the adb .dlls are in the folder path selected
            
            string filepath = sdkFolder + adb;
            if (File.Exists(filepath)) 
                //&& (File.Exists(sdkFolder + "AdbWinApi.dll")) && (File.Exists(sdkFolder + "AdbWinUsbApi.dll")))
            {
                adbFound = true;
                deviceConnected();
              
            }
            else
            {
                MessageBox.Show("I cant seem to find the right files, check you have selected the right path ( <<sdk>>/platform-tools/ )", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SDKFolder();
            }

           
 

        }
        void stillConnected()
        {
            string line;
            Process adb = new Process();
            adb.StartInfo.WorkingDirectory = @"" + sdkFolder;
            adb.StartInfo.FileName = "cmd.exe";
            adb.StartInfo.Arguments = devices;
            adb.StartInfo.RedirectStandardInput = true;
            adb.StartInfo.RedirectStandardOutput = true;
            adb.StartInfo.RedirectStandardError = true;
            adb.StartInfo.UseShellExecute = false;
            adb.StartInfo.CreateNoWindow = true;

            adb.Start();
            line = adb.StandardOutput.ReadToEnd();
            txtStatus.Text = line;

            while (!adb.HasExited)
            {
                Application.DoEvents();
            }
            //check for null value
            string nulVal = line;
            if (nulVal == "")
            {
                deviceConnected();
            }
            else
            {
                char last = line[line.Length - 9];
                string ch = last.ToString();


                if (ch == "e")
                {

                }
                else
                {
                    txtStatus.Text = "Device not found";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Busy";
                    //disable buttons
                    btnBackupSD.Enabled = false;
                    btnBkupCont.Enabled = false;
                    btnBkupPic.Enabled = false;
                    btnReboot.Enabled = false;
                    btnRebootR.Enabled = false;
                    btnResCont.Enabled = false;
                    btnResPic.Enabled = false;
                    btnResSD.Enabled = false;

                    deviceConnected();
                }

            }
        }
        void deviceConnected()
        {
            if (adbFound == true)
            {
                string message2 = "Please plug in your device, ensure that 'USB Debugging' is enabled, this might freeze the app for a minuite.\nNOTE: you might need to unplug and replug your device a couple of times";
                MessageBox.Show(message2, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string line;
                Process adb = new Process();
                adb.StartInfo.WorkingDirectory = @"" + sdkFolder;
                adb.StartInfo.FileName = "cmd.exe";
                adb.StartInfo.Arguments = devices;
                adb.StartInfo.RedirectStandardInput = true;
                adb.StartInfo.RedirectStandardOutput = true;                
                adb.StartInfo.RedirectStandardError = true;                      
                adb.StartInfo.UseShellExecute = false;
                adb.StartInfo.CreateNoWindow = true;
                

                adb.Start();

                line = adb.StandardOutput.ReadToEnd();
                txtStatus.Text = line;

                while (!adb.HasExited)
                {
                    Application.DoEvents();
                }
                
                //check for null value

                string nulVal = line;
                if (nulVal == "")
                {
                    deviceConnected();
                }
                else
                {
                    char last = line[line.Length - 9];
                    string ch = last.ToString();


                    if (ch == "e")
                    {
                        picDefault.Visible = false;
                        picNotReady.Visible = false;
                        picReady.Visible = true;
                        ready();

                    }
                    else
                    {
                        picDefault.Visible = false;
                        picNotReady.Visible = true;
                        picReady.Visible = false;
                        deviceConnected();
                    }
                }
            }
        }
        private void btnBackupSD_Click(object sender, EventArgs e)
        {
            stillConnected();
            
                //reset backuplocation
                string backupLocation = "";

                //set backupLocation
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    MessageBox.Show("Please select a folder to backup to", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dlg.Description = "Select folder";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        backupLocation = dlg.SelectedPath;
                    }
                }
               
                //bakcup the sdcard
                string line;
                Process adb = new Process();
                adb.StartInfo.WorkingDirectory = @"" + sdkFolder;
                adb.StartInfo.FileName = "cmd.exe";
                adb.StartInfo.Arguments = (sdCardBackup + "\"" + backupLocation + "\"");
                adb.StartInfo.RedirectStandardInput = true;
                adb.StartInfo.RedirectStandardOutput = true;
                adb.StartInfo.RedirectStandardError = true;
                adb.StartInfo.UseShellExecute = false;
                adb.StartInfo.CreateNoWindow = true;

                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Visible = true;
                lblStatus.Text = "Busy";

                adb.Start();

                line = adb.StandardOutput.ReadToEnd();
                txtStatus.Text = line;

                while (!adb.HasExited)
                {
                    Application.DoEvents();
                }
                                        
                              
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Visible = true;
                lblStatus.Text = "Busy";
                
                ready();
            }
            
        
   

            private void btnCancel_Click(object sender, EventArgs e)
            {
                //cancel
            }

            private void btnResSD_Click(object sender, EventArgs e)
            {
                //restore sdcard
                stillConnected();

                //reset backuplocation
                string backupLocation = "";

                //set backupLocation
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    MessageBox.Show("Please select a folder to restore from", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dlg.Description = "Select folder";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        backupLocation = dlg.SelectedPath;
                    }
                }

                //restore the sdcard
                string line;
                Process adb = new Process();
                adb.StartInfo.WorkingDirectory = @"" + sdkFolder;
                adb.StartInfo.FileName = "cmd.exe";
                adb.StartInfo.Arguments = (adbPush + "\"" + backupLocation + "\"" + restoreSdcard );
                adb.StartInfo.RedirectStandardInput = true;
                adb.StartInfo.RedirectStandardOutput = true;
                adb.StartInfo.RedirectStandardError = true;
                adb.StartInfo.UseShellExecute = false;
                adb.StartInfo.CreateNoWindow = true;

                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Visible = true;
                lblStatus.Text = "Busy";

                adb.Start();

                line = adb.StandardOutput.ReadToEnd();
                txtStatus.Text = line;

                while (!adb.HasExited)
                {
                    Application.DoEvents();
                }



                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Visible = true;
                lblStatus.Text = "Busy";

                ready();
            }

            private void btnBkupPic_Click(object sender, EventArgs e)
            {
               stillConnected();
            
                //reset backuplocation
                string backupLocation = "";

                //set backupLocation
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    MessageBox.Show("Please select a folder to backup to", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dlg.Description = "Select folder";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        backupLocation = dlg.SelectedPath;
                    }
                }
               
                //bakcup the picture
                string line;
                Process adb = new Process();
                adb.StartInfo.WorkingDirectory = @"" + sdkFolder;
                adb.StartInfo.FileName = "cmd.exe";
                adb.StartInfo.Arguments = (pictureBackup + "\"" + backupLocation + "\"");
                adb.StartInfo.RedirectStandardInput = true;
                adb.StartInfo.RedirectStandardOutput = true;
                adb.StartInfo.RedirectStandardError = true;
                adb.StartInfo.UseShellExecute = false;
                adb.StartInfo.CreateNoWindow = true;

                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Visible = true;
                lblStatus.Text = "Busy";

                adb.Start();

                line = adb.StandardOutput.ReadToEnd();
                txtStatus.Text = line;

                while (!adb.HasExited)
                {
                    Application.DoEvents();
                }              
                //adb.WaitForExit();
                                             
              
                
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Visible = true;
                lblStatus.Text = "Busy";
                
                ready();
                    
               
            }
                    

                    
            

            private void btnResPic_Click(object sender, EventArgs e)
            {
                //restore pictures
                stillConnected();

                //reset backuplocation
                string backupLocation = "";

                //set restore folder
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    MessageBox.Show("Please select a folder to restore from", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dlg.Description = "Select folder";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        backupLocation = dlg.SelectedPath;
                    }
                }

                //restoring the pictures
                string line;
                Process adb = new Process();
                adb.StartInfo.WorkingDirectory = @"" + sdkFolder;
                adb.StartInfo.FileName = "cmd.exe";
                adb.StartInfo.Arguments = (adbPush + "\"" + backupLocation + "\"" + restorePics);
                adb.StartInfo.RedirectStandardInput = true;
                adb.StartInfo.RedirectStandardOutput = true;
                adb.StartInfo.RedirectStandardError = true;
                adb.StartInfo.UseShellExecute = false;
                adb.StartInfo.CreateNoWindow = true;

                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Visible = true;
                lblStatus.Text = "Busy";

                adb.Start();

               // line = adb.StandardOutput.ReadToEnd();
               // txtStatus.Text = line;

                while (!adb.HasExited)
                {
                    Application.DoEvents();
                }



                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Visible = true;
                lblStatus.Text = "Busy";

                ready();
            }

            private void btnBkupCont_Click(object sender, EventArgs e)
            {
               // backupContacts contacts
           
            }
            

            private void btnResCont_Click(object sender, EventArgs e)
            {
                //restore contacts
            }

            private void btnFolderBkup_Click(object sender, EventArgs e)
            {
                //backup from a certain folder
             
            }
                
            

            private void btnReboot_Click(object sender, EventArgs e)
            {
                //reboot phone
               // stillConnected();

               
                string line;
                Process adb = new Process();
                adb.StartInfo.WorkingDirectory = @"" + sdkFolder;
                adb.StartInfo.FileName = "cmd.exe";
                adb.StartInfo.Arguments = reboot;
                adb.StartInfo.RedirectStandardInput = true;
                adb.StartInfo.RedirectStandardOutput = true;
                adb.StartInfo.RedirectStandardError = true;
                adb.StartInfo.UseShellExecute = false;
                adb.StartInfo.CreateNoWindow = true;

                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Visible = true;
                lblStatus.Text = "Busy";

                adb.Start();
                line = adb.StandardOutput.ReadToEnd();
                txtStatus.Text = line;

                while (!adb.HasExited)
                {
                    Application.DoEvents();
                }



                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Visible = true;
                lblStatus.Text = "Busy";
                //disable buttons
                btnBackupSD.Enabled = false;
                btnBkupCont.Enabled = false;
                btnBkupPic.Enabled = false;
                btnReboot.Enabled = false;
                btnRebootR.Enabled = false;
                btnResCont.Enabled = false;
                btnResPic.Enabled = false;
                btnResSD.Enabled = false;

                MessageBox.Show("Your device has been rebooted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                deviceConnected();
                
            }

            private void btnRebootR_Click(object sender, EventArgs e)
            {
                //reboot recovery mode
                
                stillConnected();

               
                string line;
                Process adb = new Process();
                adb.StartInfo.WorkingDirectory = @"" + sdkFolder;
                adb.StartInfo.FileName = "cmd.exe";
                adb.StartInfo.Arguments = recovery;
                adb.StartInfo.RedirectStandardInput = true;
                adb.StartInfo.RedirectStandardOutput = true;
                adb.StartInfo.RedirectStandardError = true;
                adb.StartInfo.UseShellExecute = false;
                adb.StartInfo.CreateNoWindow = true;

                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Visible = true;
                lblStatus.Text = "Busy";

                adb.Start();
                line = adb.StandardOutput.ReadToEnd();
                txtStatus.Text = line;

                while (!adb.HasExited)
                {
                    Application.DoEvents();
                }



                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Visible = true;
                lblStatus.Text = "Busy";

                //disable buttons
                btnBackupSD.Enabled = false;
                btnBkupCont.Enabled = false;
                btnBkupPic.Enabled = false;
                btnReboot.Enabled = false;
                btnRebootR.Enabled = false;
                btnResCont.Enabled = false;
                btnResPic.Enabled = false;
                btnResSD.Enabled = false;

                deviceConnected();
            }
            

            void ready()
            {
                //action completed 
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Ready";
                //enable buttons
                btnBackupSD.Enabled = true;
                btnBkupCont.Enabled = false;
                btnBkupPic.Enabled = true;
                btnReboot.Enabled = true;
                btnRebootR.Enabled = true;
                btnResCont.Enabled = false;
                btnResPic.Enabled = true;
                btnResSD.Enabled = true;
               
                MessageBox.Show("Your device has been detected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void btnShowHide_Click(object sender, EventArgs e)
            {
                if (txtStatus.Multiline == true)
                {
                    txtStatus.Multiline = false;
                    btnShowHide.Location = new Point(466, 273);

                }
                else
                {
                    txtStatus.Multiline = true;
                    btnShowHide.Location = new Point(466, 353);
                }
            }
    
    }

    
}

                
                

            
        
       
    
    
   
    
    



      
