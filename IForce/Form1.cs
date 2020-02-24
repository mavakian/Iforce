using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IForce
{
    public partial class IForce : Form
    {
        public BackgroundWorker worker1; 
        public IForce()
        {
            InitializeComponent();
            _iforce = this; //static instance of Form IForce to access rich text box for logging
            IForceApp.UpdateTextFieldsFromConfig();
            //this.worker1 = new BackgroundWorker();
            //this.worker1.DoWork += new DoWorkEventHandler(worker1_DoWork);
            //this.worker1.ProgressChanged += new ProgressChangedEventHandler(worker1_ProgressChanged);
            //this.worker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker1_RunWorkerCompleted);
            //this.worker1.WorkerReportsProgress = true;

            //CopyFileOptions options = new CopyFileOptions()
            //{
            //    Dtable = this,
            //    RchBx = this
            //};
            //worker1.RunWorkerAsync(options);
        }

        //private async void ExampleMethod()
        //{
        //    await Task.Run(() => AsyncExample());
        //    //do something else
        //}

        //private Task AsyncExample()
        //{
        //    Task.CompletedTask
        //}

        //public void worker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    var options = (CopyFileOptions)sender;
        //    IForceApp.CopyAndRenameFiles(options.Dtable, options.RchBx);
        //}l

        //public void worker1_ProgressChanged(object sender, ProgressChangedEventArgs)
        //{
        //    var options = (CopyFileOptions)sender;
        //}

        //public void StartCopyWorker(CopyFileOptions options)
        //{
        //    this.worker1 = new BackgroundWorker();
        //    this.worker1.DoWork += new DoWorkEventHandler(worker1_DoWork);
        //    this.worker1.ProgressChanged += new ProgressChangedEventHandler(worker1_ProgressChanged);
        //    //this.worker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker1_RunWorkerCompleted);
        //    this.worker1.WorkerReportsProgress = true;
        //    worker1.RunWorkerAsync(options);
        //}
        //For logging
        public static IForce _iforce;

        //to move the form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void IForce_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        delegate void SetTextCallback(string text);
        //End move form
        public static void Logger(string text)
        {
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (_iforce.rchTxtBx1.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(Logger);
                    _iforce.Invoke(d, new object[] { text });
                }
                else
                {
                   _iforce.rchTxtBx1.AppendText(Environment.NewLine + DateTime.Now.ToString() + " " + text);
                }
            
        }

        //public static void Logger(string text)
        //{
        //    _iforce.rchTxtBx1.AppendText(Environment.NewLine + DateTime.Now.ToString() + " " + text);
        //}
        public static void ListLogger(string text)
        {
            _iforce.rchTxtBx1.AppendText(Environment.NewLine + text);
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            btnAPISearch.Enabled = false;
            btnConnect.Enabled = false;
            btnImport.Enabled = false;
            chxLstBx1.Enabled = false;
            rchTxtBx2.ReadOnly = true;
            btnLaunch.Enabled = false;
            

            UpdateProperties SetInputs = new UpdateProperties();
            if (SetInputs.UpdateUserInputs(tboxServer.Text,
                               tboxDb.Text,
                               tboxSQLUser.Text,
                               tboxPassword.Text,
                               tboxURL.Text,
                               tbxSearchName.Text,
                               chxLstBx1) == true)
            {
                IForceApp.ConnectToImage(dView1, rchTxtBx1);

            };
           
            

        }

        private void APISearch_Click_1(object sender, EventArgs e)
        {
            UpdateProperties SetInputs = new UpdateProperties();
            if (SetInputs.UpdateSearchInputs(tboxServer.Text,
                               tboxDb.Text,
                               tboxSQLUser.Text,
                               tboxPassword.Text,
                               tboxURL.Text,
                               chxLstBx1) == true)

            {
                IForceApp.ExecuteEclipseSearch();
            };
        }

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    UpdateProperties SetInputs = new UpdateProperties();
        //    if (SetInputs.UpdateSearchInputs(tboxServer.Text,
        //                       tboxDb.Text,
        //                       tboxSQLUser.Text,
        //                       tboxPassword.Text,
        //                       //tboxResultsID.Text,
        //                       tboxURL.Text,
        //                       chxLstBx1) == true)
                              
        //    {
        //        //IForceApp.Search(dView1);
        //    };
                   
        //}

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            UpdateProperties SetInputs = new UpdateProperties();
            if (SetInputs.UpdateConnectBtnInputs(tboxServer.Text,
                               tboxDb.Text,
                               tboxSQLUser.Text,
                               tboxPassword.Text)== true)

            {
                rchTxtBx1.AppendText("Retrieving case list.");
                IForceApp.GetDatabaseList(chxLstBx1);
            }; 
        }



        public void chxLstBx1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            IForceApp.SetCaseName(chxLstBx1, e);

            btnImport.Enabled = true;

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (chxLstBx1.SelectedItems.Count > 0)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = $"Choose a PDF image folder to import into case {UserInput.CaseName}";
                fbd.ShowNewFolderButton = true;
                fbd.SelectedPath = UserInput.CaseDir;


                if (fbd.ShowDialog() == DialogResult.OK)
                {

                    ReadDisk files = new ReadDisk();
                    new DocumentIterator(files.getFilePaths(fbd.SelectedPath));
                }
            }
            else
            {
                MessageBox.Show("Select a case.");
            }
           
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            try
            {
                IForceApp.ResetSettingsToUI();
            }
            catch { IForce.Logger("Unable to reset settings. Connect to a case first."); }
            
        }

        private void rchTxtBx1_TextChanged(object sender, EventArgs e)
        {
            rchTxtBx1.ScrollToCaret();
        }

        private void rchTxtBx2_TextChanged(object sender, EventArgs e)
        {
            UserInput.SaveSettings();
        }

        private void rchTxtBx1_LinkClicked(object sender, LinkClickedEventArgs e)
        {

            string dir = e.LinkText.ToString();
            if (Directory.Exists(dir))
            {
                System.Diagnostics.Process.Start("Explorer.exe", @"/select," + dir);
            }
            else
            {
                //FilePath doesn't exist!
                // handle the error appropriately...
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form Form2 = new Form();
            Form2.Width = 500;
            Form2.Height = 500;
            Form2.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Form2.Show();
            Form2.BackgroundImage = Properties.Resources.new_swat_logo2;
            
        }



        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            IForceApp.SaveLog();
        }

        private void tboxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConnect.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void tbxSearchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAPISearch.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
    }
}
