﻿using System;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IForce));
            this.btnLaunch = new System.Windows.Forms.Button();
            this.dView1 = new System.Windows.Forms.DataGridView();
            this.tboxServer = new System.Windows.Forms.TextBox();
            this.tboxDb = new System.Windows.Forms.TextBox();
            this.tboxSQLUser = new System.Windows.Forms.TextBox();
            this.tboxPassword = new System.Windows.Forms.TextBox();
            this.tboxURL = new System.Windows.Forms.TextBox();
            this.tboxClientID = new System.Windows.Forms.TextBox();
            this.tboxSecret = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblSQLUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblIproURL = new System.Windows.Forms.Label();
            this.lblClient_id = new System.Windows.Forms.Label();
            this.lblClientSecret = new System.Windows.Forms.Label();
            this.tboxResultsID = new System.Windows.Forms.TextBox();
            this.tboxRevUser = new System.Windows.Forms.TextBox();
            this.lblResultsID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rchTxtBx1 = new System.Windows.Forms.RichTextBox();
            this.chxLstBx1 = new System.Windows.Forms.CheckedListBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnMin = new System.Windows.Forms.Button();
            this.rchTxtBx2 = new System.Windows.Forms.RichTextBox();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDocCount = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnLaunch.Location = new System.Drawing.Point(9, 503);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(439, 109);
            this.btnLaunch.TabIndex = 0;
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
            this.dView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dView1.EnableHeadersVisualStyles = false;
            this.dView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dView1.Location = new System.Drawing.Point(573, 458);
            this.dView1.Name = "dView1";
            this.dView1.ReadOnly = true;
            this.dView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dView1.RowHeadersVisible = false;
            this.dView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.dView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.dView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Gray;
            this.dView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dView1.Size = new System.Drawing.Size(567, 154);
            this.dView1.TabIndex = 1;
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
            this.tboxServer.TabIndex = 2;
            this.tboxServer.Text = "tst-supsql001\\sup16";
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
            this.tboxDb.TabIndex = 3;
            this.tboxDb.Text = "mja_add_34";
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
            this.tboxSQLUser.TabIndex = 4;
            this.tboxSQLUser.Text = "mavakiansql";
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
            this.tboxPassword.TabIndex = 5;
            this.tboxPassword.Text = "iprotech";
            // 
            // tboxURL
            // 
            this.tboxURL.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tboxURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxURL.ForeColor = System.Drawing.SystemColors.Window;
            this.tboxURL.Location = new System.Drawing.Point(152, 372);
            this.tboxURL.Name = "tboxURL";
            this.tboxURL.Size = new System.Drawing.Size(415, 19);
            this.tboxURL.TabIndex = 6;
            this.tboxURL.Text = "https://tst-suptrk034:1125";
            // 
            // tboxClientID
            // 
            this.tboxClientID.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tboxClientID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxClientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxClientID.ForeColor = System.Drawing.SystemColors.Window;
            this.tboxClientID.Location = new System.Drawing.Point(152, 398);
            this.tboxClientID.Name = "tboxClientID";
            this.tboxClientID.Size = new System.Drawing.Size(415, 19);
            this.tboxClientID.TabIndex = 7;
            this.tboxClientID.Text = "nucleus_service";
            // 
            // tboxSecret
            // 
            this.tboxSecret.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tboxSecret.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxSecret.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSecret.ForeColor = System.Drawing.SystemColors.Window;
            this.tboxSecret.Location = new System.Drawing.Point(152, 424);
            this.tboxSecret.Name = "tboxSecret";
            this.tboxSecret.Size = new System.Drawing.Size(415, 19);
            this.tboxSecret.TabIndex = 8;
            this.tboxSecret.Text = "3F9EB1DF9BCA44628EB0987BFD76C9D98EB70B84388A4B7DBC45757C6D351246";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(6, 33);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(106, 13);
            this.lblServer.TabIndex = 9;
            this.lblServer.Text = "SQL Server Instance";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(6, 59);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(137, 13);
            this.lblDatabase.TabIndex = 10;
            this.lblDatabase.Text = "IPRO SVC Database Name";
            // 
            // lblSQLUser
            // 
            this.lblSQLUser.AutoSize = true;
            this.lblSQLUser.Location = new System.Drawing.Point(6, 85);
            this.lblSQLUser.Name = "lblSQLUser";
            this.lblSQLUser.Size = new System.Drawing.Size(79, 13);
            this.lblSQLUser.TabIndex = 11;
            this.lblSQLUser.Text = "SQL Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(6, 111);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(77, 13);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "SQL Password";
            // 
            // lblIproURL
            // 
            this.lblIproURL.AutoSize = true;
            this.lblIproURL.Location = new System.Drawing.Point(6, 372);
            this.lblIproURL.Name = "lblIproURL";
            this.lblIproURL.Size = new System.Drawing.Size(76, 13);
            this.lblIproURL.TabIndex = 13;
            this.lblIproURL.Text = "Ipro Web URL";
            // 
            // lblClient_id
            // 
            this.lblClient_id.AutoSize = true;
            this.lblClient_id.Location = new System.Drawing.Point(6, 398);
            this.lblClient_id.Name = "lblClient_id";
            this.lblClient_id.Size = new System.Drawing.Size(73, 13);
            this.lblClient_id.TabIndex = 14;
            this.lblClient_id.Text = "API_Client_ID";
            // 
            // lblClientSecret
            // 
            this.lblClientSecret.AutoSize = true;
            this.lblClientSecret.Location = new System.Drawing.Point(6, 424);
            this.lblClientSecret.Name = "lblClientSecret";
            this.lblClientSecret.Size = new System.Drawing.Size(73, 13);
            this.lblClientSecret.TabIndex = 15;
            this.lblClientSecret.Text = "Client _Secret";
            // 
            // tboxResultsID
            // 
            this.tboxResultsID.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tboxResultsID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxResultsID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxResultsID.ForeColor = System.Drawing.SystemColors.Window;
            this.tboxResultsID.Location = new System.Drawing.Point(152, 450);
            this.tboxResultsID.Name = "tboxResultsID";
            this.tboxResultsID.Size = new System.Drawing.Size(52, 19);
            this.tboxResultsID.TabIndex = 16;
            this.tboxResultsID.Text = "2";
            // 
            // tboxRevUser
            // 
            this.tboxRevUser.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tboxRevUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxRevUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxRevUser.ForeColor = System.Drawing.SystemColors.Window;
            this.tboxRevUser.Location = new System.Drawing.Point(152, 476);
            this.tboxRevUser.Name = "tboxRevUser";
            this.tboxRevUser.Size = new System.Drawing.Size(415, 19);
            this.tboxRevUser.TabIndex = 17;
            this.tboxRevUser.Text = "administrator@iprotech.com";
            // 
            // lblResultsID
            // 
            this.lblResultsID.AutoSize = true;
            this.lblResultsID.Location = new System.Drawing.Point(6, 450);
            this.lblResultsID.Name = "lblResultsID";
            this.lblResultsID.Size = new System.Drawing.Size(93, 13);
            this.lblResultsID.TabIndex = 18;
            this.lblResultsID.Text = "Search Results ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 476);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Review Username";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSearch.Location = new System.Drawing.Point(210, 450);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 19);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rchTxtBx1
            // 
            this.rchTxtBx1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rchTxtBx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rchTxtBx1.ForeColor = System.Drawing.Color.Cyan;
            this.rchTxtBx1.Location = new System.Drawing.Point(573, 33);
            this.rchTxtBx1.Name = "rchTxtBx1";
            this.rchTxtBx1.ReadOnly = true;
            this.rchTxtBx1.Size = new System.Drawing.Size(567, 243);
            this.rchTxtBx1.TabIndex = 21;
            this.rchTxtBx1.Text = "";
            this.rchTxtBx1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rchTxtBx1_LinkClicked);
            this.rchTxtBx1.TextChanged += new System.EventHandler(this.rchTxtBx1_TextChanged);
            // 
            // chxLstBx1
            // 
            this.chxLstBx1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chxLstBx1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chxLstBx1.CheckOnClick = true;
            this.chxLstBx1.ForeColor = System.Drawing.Color.Cyan;
            this.chxLstBx1.FormattingEnabled = true;
            this.chxLstBx1.Location = new System.Drawing.Point(148, 167);
            this.chxLstBx1.Name = "chxLstBx1";
            this.chxLstBx1.Size = new System.Drawing.Size(415, 195);
            this.chxLstBx1.Sorted = true;
            this.chxLstBx1.TabIndex = 22;
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
            this.btnConnect.Location = new System.Drawing.Point(152, 138);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(415, 23);
            this.btnConnect.TabIndex = 23;
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
            this.btnImport.Location = new System.Drawing.Point(454, 503);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(113, 109);
            this.btnImport.TabIndex = 26;
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
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, -3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 30);
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
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
            this.rchTxtBx2.ForeColor = System.Drawing.SystemColors.Window;
            this.rchTxtBx2.Location = new System.Drawing.Point(573, 282);
            this.rchTxtBx2.Name = "rchTxtBx2";
            this.rchTxtBx2.Size = new System.Drawing.Size(567, 170);
            this.rchTxtBx2.TabIndex = 33;
            this.rchTxtBx2.Text = "";
            this.rchTxtBx2.TextChanged += new System.EventHandler(this.rchTxtBx2_TextChanged);
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnResetSettings.FlatAppearance.BorderSize = 0;
            this.btnResetSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta;
            this.btnResetSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSettings.Location = new System.Drawing.Point(1070, 418);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(43, 19);
            this.btnResetSettings.TabIndex = 35;
            this.btnResetSettings.Text = "Reset";
            this.btnResetSettings.UseVisualStyleBackColor = false;
            this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(282, 450);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 19);
            this.button1.TabIndex = 36;
            this.button1.Text = "APISearch";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblDocCount
            // 
            this.lblDocCount.AutoSize = true;
            this.lblDocCount.Location = new System.Drawing.Point(387, 453);
            this.lblDocCount.Name = "lblDocCount";
            this.lblDocCount.Size = new System.Drawing.Size(61, 13);
            this.lblDocCount.TabIndex = 37;
            this.lblDocCount.Text = "Doc Count:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(454, 453);
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
            this.btnSaveLog.Location = new System.Drawing.Point(1070, 245);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(43, 19);
            this.btnSaveLog.TabIndex = 39;
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
            // IForce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1148, 625);
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
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblResultsID);
            this.Controls.Add(this.tboxRevUser);
            this.Controls.Add(this.tboxResultsID);
            this.Controls.Add(this.lblClientSecret);
            this.Controls.Add(this.lblClient_id);
            this.Controls.Add(this.lblIproURL);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblSQLUser);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.tboxSecret);
            this.Controls.Add(this.tboxClientID);
            this.Controls.Add(this.tboxURL);
            this.Controls.Add(this.tboxPassword);
            this.Controls.Add(this.tboxSQLUser);
            this.Controls.Add(this.tboxDb);
            this.Controls.Add(this.tboxServer);
            this.Controls.Add(this.dView1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.rchTxtBx2);
            //this.Controls.Add(this.button1);
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
        private System.Windows.Forms.DataGridView dView1;
        private System.Windows.Forms.TextBox tboxServer;
        private System.Windows.Forms.TextBox tboxDb;
        private System.Windows.Forms.TextBox tboxSQLUser;
        private System.Windows.Forms.TextBox tboxPassword;
        private System.Windows.Forms.TextBox tboxURL;
        private System.Windows.Forms.TextBox tboxClientID;
        private System.Windows.Forms.TextBox tboxSecret;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblSQLUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblIproURL;
        private System.Windows.Forms.Label lblClient_id;
        private System.Windows.Forms.Label lblClientSecret;
        private System.Windows.Forms.TextBox tboxResultsID;
        private System.Windows.Forms.TextBox tboxRevUser;
        private System.Windows.Forms.Label lblResultsID;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.RichTextBox rchTxtBx1;
        public System.Windows.Forms.CheckedListBox chxLstBx1;
        public Button btnImport;
        private Button btnClose;
        private PictureBox pictureBox2;
        private Button btnMin;
        public RichTextBox rchTxtBx2;
        private Button btnResetSettings;
        private Button button1;
        private Label lblDocCount;
        public Label lblCount;
        private Button btnSaveLog;
        private Label label1;
    }
}

