﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IForce
{
    public partial class IForce : Form
    {
        public IForce()
        {
            InitializeComponent();
            _iforce = this; //static instance of Form IForce to access rich text box for logging
        }
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
        //End move form


        public static void Logger(string text)
        {
            _iforce.rchTxtBx1.AppendText(Environment.NewLine + text);
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            btnConnect.Enabled = false;
            chxLstBx1.Enabled = false;
            rchTxtBx2.ReadOnly = true;
            
            UpdateProperties SetInputs = new UpdateProperties();
            if (SetInputs.UpdateUserInputs(tboxServer.Text,
                               tboxDb.Text,
                               tboxSQLUser.Text,
                               tboxPassword.Text,
                               tboxURL.Text,
                               tboxClientID.Text,
                               tboxSecret.Text,
                               tboxResultsID.Text,
                               tboxRevUser.Text) == true)
            {
                IForceApp.ConnectToImage(dView1, rchTxtBx1);
                
            };
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateProperties SetInputs = new UpdateProperties();
            if (SetInputs.UpdateSearchInputs(tboxServer.Text,
                               tboxDb.Text,
                               tboxSQLUser.Text,
                               tboxPassword.Text,
                               tboxResultsID.Text) == true)
                              
            {
                IForceApp.Search(dView1);
            };
                   
        }

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



        private void chxLstBx1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            IForceApp.SetCaseName(chxLstBx1, e);
                
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DocumentIterator.IterateDocuments(ReadDisk.getFilePaths(UserInput.OutputPath));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form Form2 = new Form();
            Form2.Width = 583;
            Form2.Height = 223;
            Form2.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Form2.Show();
            Form2.BackgroundImage = Properties.Resources.force;
            
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
           
            IForceApp.ResetSettingsToUI();

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
    }
}
