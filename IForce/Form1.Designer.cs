using System;
using System.Windows.Forms;

namespace IForce
{
    partial class IForce
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IForce));
            this.btnLaunch = new System.Windows.Forms.Button();
            this.dView1 = new System.Windows.Forms.DataGridView();
            this.tboxServer = new System.Windows.Forms.TextBox();
            this.tboxDb = new System.Windows.Forms.TextBox();
            this.tboxSQLUser = new System.Windows.Forms.TextBox();
            this.tboxPassword = new System.Windows.Forms.TextBox();
            this.tboxURL = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblSQLUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lbIdentURL = new System.Windows.Forms.Label();
            this.tboxResultsID = new System.Windows.Forms.TextBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.rchTxtBx1 = new System.Windows.Forms.RichTextBox();
            this.chxLstBx1 = new System.Windows.Forms.CheckedListBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.rchTxtBx2 = new System.Windows.Forms.RichTextBox();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.btnAPISearch = new System.Windows.Forms.Button();
            this.lblDocCount = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSearchName = new System.Windows.Forms.Label();
            this.tbxSearchName = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLaunch
            // 
            this.btnLaunch.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLaunch.FlatAppearance.BorderSize = 0;
            this.btnLaunch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnLaunch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaunch.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLaunch.Location = new System.Drawing.Point(9, 528);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(439, 109);
            this.btnLaunch.TabIndex = 10;
            this.btnLaunch.Text = "Image Document Set";
            this.btnLaunch.UseVisualStyleBackColor = false;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // dView1
            // 
            this.dView1.AllowUserToAddRows = false;
            this.dView1.AllowUserToDeleteRows = false;
            this.dView1.AllowUserToOrderColumns = true;
            this.dView1.AllowUserToResizeRows = false;
            this.dView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dView1.EnableHeadersVisualStyles = false;
            this.dView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dView1.Location = new System.Drawing.Point(573, 458);
            this.dView1.Name = "dView1";
            this.dView1.ReadOnly = true;
            this.dView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dView1.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            this.dView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.dView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gray;
            this.dView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dView1.Size = new System.Drawing.Size(567, 179);
            this.dView1.TabIndex = 16;
            // 
            // tboxServer
            // 
            this.tboxServer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tboxServer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxServer.ForeColor = System.Drawing.SystemColors.Window;
            this.tboxServer.Location = new System.Drawing.Point(152, 33);
            this.tboxServer.Name = "tboxServer";
            this.tboxServer.Size = new System.Drawing.Size(415, 19);
            this.tboxServer.TabIndex = 1;
            // 
            // tboxDb
            // 
            this.tboxDb.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tboxDb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxDb.ForeColor = System.Drawing.SystemColors.Window;
            this.tboxDb.Location = new System.Drawing.Point(152, 59);
            this.tboxDb.Name = "tboxDb";
            this.tboxDb.Size = new System.Drawing.Size(415, 19);
            this.tboxDb.TabIndex = 2;
            // 
            // tboxSQLUser
            // 
            this.tboxSQLUser.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tboxSQLUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxSQLUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSQLUser.ForeColor = System.Drawing.SystemColors.Window;
            this.tboxSQLUser.Location = new System.Drawing.Point(152, 85);
            this.tboxSQLUser.Name = "tboxSQLUser";
            this.tboxSQLUser.Size = new System.Drawing.Size(415, 19);
            this.tboxSQLUser.TabIndex = 3;
            // 
            // tboxPassword
            // 
            this.tboxPassword.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tboxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxPassword.ForeColor = System.Drawing.SystemColors.Window;
            this.tboxPassword.Location = new System.Drawing.Point(152, 111);
            this.tboxPassword.Name = "tboxPassword";
            this.tboxPassword.PasswordChar = '*';
            this.tboxPassword.Size = new System.Drawing.Size(415, 19);
            this.tboxPassword.TabIndex = 4;
            this.tboxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tboxPassword_KeyDown);
            // 
            // tboxURL
            // 
            this.tboxURL.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tboxURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxURL.ForeColor = System.Drawing.SystemColors.Window;
            this.tboxURL.Location = new System.Drawing.Point(152, 136);
            this.tboxURL.Name = "tboxURL";
            this.tboxURL.Size = new System.Drawing.Size(415, 19);
            this.tboxURL.TabIndex = 5;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(6, 38);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(106, 13);
            this.lblServer.TabIndex = 9;
            this.lblServer.Text = "SQL Server Instance";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(6, 64);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(137, 13);
            this.lblDatabase.TabIndex = 10;
            this.lblDatabase.Text = "IPRO SVC Database Name";
            // 
            // lblSQLUser
            // 
            this.lblSQLUser.AutoSize = true;
            this.lblSQLUser.Location = new System.Drawing.Point(6, 90);
            this.lblSQLUser.Name = "lblSQLUser";
            this.lblSQLUser.Size = new System.Drawing.Size(79, 13);
            this.lblSQLUser.TabIndex = 11;
            this.lblSQLUser.Text = "SQL Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(6, 116);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(77, 13);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "SQL Password";
            // 
            // lbIdentURL
            // 
            this.lbIdentURL.AutoSize = true;
            this.lbIdentURL.Location = new System.Drawing.Point(6, 141);
            this.lbIdentURL.Name = "lbIdentURL";
            this.lbIdentURL.Size = new System.Drawing.Size(100, 13);
            this.lbIdentURL.TabIndex = 13;
            this.lbIdentURL.Text = "Identity Server URL";
            // 
            // tboxResultsID
            // 
            this.tboxResultsID.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tboxResultsID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxResultsID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxResultsID.ForeColor = System.Drawing.SystemColors.Window;
            this.tboxResultsID.Location = new System.Drawing.Point(152, 475);
            this.tboxResultsID.Name = "tboxResultsID";
            this.tboxResultsID.Size = new System.Drawing.Size(52, 19);
            this.tboxResultsID.TabIndex = 16;
            this.tboxResultsID.Text = "0";
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(488, 492);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(82, 13);
            this.lblResults.TabIndex = 18;
            this.lblResults.Text = "Search Results:";
            // 
            // rchTxtBx1
            // 
            this.rchTxtBx1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rchTxtBx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rchTxtBx1.ForeColor = System.Drawing.Color.Aqua;
            this.rchTxtBx1.Location = new System.Drawing.Point(573, 33);
            this.rchTxtBx1.Name = "rchTxtBx1";
            this.rchTxtBx1.ReadOnly = true;
            this.rchTxtBx1.Size = new System.Drawing.Size(567, 243);
            this.rchTxtBx1.TabIndex = 12;
            this.rchTxtBx1.Text = "";
            this.rchTxtBx1.WordWrap = false;
            this.rchTxtBx1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rchTxtBx1_LinkClicked);
            this.rchTxtBx1.TextChanged += new System.EventHandler(this.rchTxtBx1_TextChanged);
            // 
            // chxLstBx1
            // 
            this.chxLstBx1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chxLstBx1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chxLstBx1.CheckOnClick = true;
            this.chxLstBx1.ForeColor = System.Drawing.Color.Aqua;
            this.chxLstBx1.FormattingEnabled = true;
            this.chxLstBx1.Location = new System.Drawing.Point(152, 190);
            this.chxLstBx1.Name = "chxLstBx1";
            this.chxLstBx1.Size = new System.Drawing.Size(415, 255);
            this.chxLstBx1.Sorted = true;
            this.chxLstBx1.TabIndex = 7;
            this.chxLstBx1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chxLstBx1_ItemCheck);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.ForeColor = System.Drawing.SystemColors.Window;
            this.btnConnect.Location = new System.Drawing.Point(152, 161);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(415, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnImport.Enabled = false;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.SystemColors.Window;
            this.btnImport.Location = new System.Drawing.Point(454, 528);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(113, 109);
            this.btnImport.TabIndex = 11;
            this.btnImport.Text = "Import Images";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClose.Location = new System.Drawing.Point(1108, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 23);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMin
            // 
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMin.Location = new System.Drawing.Point(1070, 4);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(32, 23);
            this.btnMin.TabIndex = 32;
            this.btnMin.Text = "_";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.button2_Click);
            // 
            // rchTxtBx2
            // 
            this.rchTxtBx2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rchTxtBx2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rchTxtBx2.DetectUrls = false;
            this.rchTxtBx2.ForeColor = System.Drawing.Color.Silver;
            this.rchTxtBx2.Location = new System.Drawing.Point(573, 282);
            this.rchTxtBx2.Name = "rchTxtBx2";
            this.rchTxtBx2.Size = new System.Drawing.Size(567, 170);
            this.rchTxtBx2.TabIndex = 14;
            this.rchTxtBx2.Text = "";
            this.rchTxtBx2.WordWrap = false;
            this.rchTxtBx2.TextChanged += new System.EventHandler(this.rchTxtBx2_TextChanged);
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnResetSettings.FlatAppearance.BorderSize = 0;
            this.btnResetSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta;
            this.btnResetSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSettings.Location = new System.Drawing.Point(1070, 404);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(43, 19);
            this.btnResetSettings.TabIndex = 15;
            this.btnResetSettings.Text = "Reset";
            this.btnResetSettings.UseVisualStyleBackColor = false;
            this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
            // 
            // btnAPISearch
            // 
            this.btnAPISearch.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAPISearch.FlatAppearance.BorderSize = 0;
            this.btnAPISearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkViolet;
            this.btnAPISearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAPISearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAPISearch.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAPISearch.Location = new System.Drawing.Point(501, 458);
            this.btnAPISearch.Name = "btnAPISearch";
            this.btnAPISearch.Size = new System.Drawing.Size(66, 19);
            this.btnAPISearch.TabIndex = 9;
            this.btnAPISearch.Text = "Search";
            this.btnAPISearch.UseVisualStyleBackColor = false;
            this.btnAPISearch.Click += new System.EventHandler(this.APISearch_Click_1);
            // 
            // lblDocCount
            // 
            this.lblDocCount.AutoSize = true;
            this.lblDocCount.Location = new System.Drawing.Point(6, 492);
            this.lblDocCount.Name = "lblDocCount";
            this.lblDocCount.Size = new System.Drawing.Size(61, 13);
            this.lblDocCount.TabIndex = 37;
            this.lblDocCount.Text = "Doc Count:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(149, 492);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 38;
            this.lblCount.Text = "0";
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSaveLog.FlatAppearance.BorderSize = 0;
            this.btnSaveLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta;
            this.btnSaveLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSaveLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveLog.Location = new System.Drawing.Point(1070, 226);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(43, 19);
            this.btnSaveLog.TabIndex = 13;
            this.btnSaveLog.Text = "Save";
            this.btnSaveLog.UseVisualStyleBackColor = false;
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(535, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 40;
            this.label1.Text = "IForce";
            // 
            // lblSearchName
            // 
            this.lblSearchName.AutoSize = true;
            this.lblSearchName.Location = new System.Drawing.Point(6, 463);
            this.lblSearchName.Name = "lblSearchName";
            this.lblSearchName.Size = new System.Drawing.Size(72, 13);
            this.lblSearchName.TabIndex = 41;
            this.lblSearchName.Text = "Search Name";
            // 
            // tbxSearchName
            // 
            this.tbxSearchName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbxSearchName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSearchName.ForeColor = System.Drawing.SystemColors.Window;
            this.tbxSearchName.Location = new System.Drawing.Point(152, 458);
            this.tbxSearchName.Name = "tbxSearchName";
            this.tbxSearchName.Size = new System.Drawing.Size(343, 19);
            this.tbxSearchName.TabIndex = 8;
            this.tbxSearchName.Text = "001";
            this.tbxSearchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSearchName_KeyDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::IForce.Properties.Resources.swat47px;
            this.pictureBox2.Location = new System.Drawing.Point(2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // IForce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1148, 647);
            this.Controls.Add(this.tbxSearchName);
            this.Controls.Add(this.lblSearchName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveLog);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblDocCount);
            this.Controls.Add(this.btnResetSettings);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.chxLstBx1);
            this.Controls.Add(this.rchTxtBx1);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lbIdentURL);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblSQLUser);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.tboxURL);
            this.Controls.Add(this.tboxPassword);
            this.Controls.Add(this.tboxSQLUser);
            this.Controls.Add(this.tboxDb);
            this.Controls.Add(this.tboxServer);
            this.Controls.Add(this.dView1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.rchTxtBx2);
            this.Controls.Add(this.btnAPISearch);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IForce";
            this.Text = "IForce";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IForce_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        public System.Windows.Forms.Button btnLaunch;
        public System.Windows.Forms.Button btnConnect;
        public System.Windows.Forms.DataGridView dView1;
        public System.Windows.Forms.TextBox tboxServer;
        public System.Windows.Forms.TextBox tboxDb;
        public System.Windows.Forms.TextBox tboxSQLUser;
        public System.Windows.Forms.TextBox tboxPassword;
        public System.Windows.Forms.TextBox tboxURL;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblSQLUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lbIdentURL;
        public System.Windows.Forms.TextBox tboxResultsID;
        private System.Windows.Forms.Label lblResults;
        public System.Windows.Forms.Button btnAPISearch;
        public System.Windows.Forms.RichTextBox rchTxtBx1;
        public System.Windows.Forms.CheckedListBox chxLstBx1;
        public Button btnImport;
        private Button btnClose;
        private PictureBox pictureBox2;
        private Button btnMin;
        public RichTextBox rchTxtBx2;
        private Button btnResetSettings;
        private Label lblDocCount;
        public Label lblCount;
        private Button btnSaveLog;
        private Label label1;
        private Label lblSearchName;
        public TextBox tbxSearchName;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

