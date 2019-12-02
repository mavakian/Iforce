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
            ((System.ComponentModel.ISupportInitialize)(this.dView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(16, 298);
            this.btnLaunch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(744, 116);
            this.btnLaunch.TabIndex = 0;
            this.btnLaunch.Text = "Kick the Tires...";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // dView1
            // 
            this.dView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dView1.Location = new System.Drawing.Point(16, 421);
            this.dView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dView1.Name = "dView1";
            this.dView1.Size = new System.Drawing.Size(744, 228);
            this.dView1.TabIndex = 1;
            // 
            // tboxServer
            // 
            this.tboxServer.Location = new System.Drawing.Point(207, 10);
            this.tboxServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tboxServer.Name = "tboxServer";
            this.tboxServer.Size = new System.Drawing.Size(552, 22);
            this.tboxServer.TabIndex = 2;
            // 
            // tboxDb
            // 
            this.tboxDb.Location = new System.Drawing.Point(207, 42);
            this.tboxDb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tboxDb.Name = "tboxDb";
            this.tboxDb.Size = new System.Drawing.Size(552, 22);
            this.tboxDb.TabIndex = 3;
            // 
            // tboxSQLUser
            // 
            this.tboxSQLUser.Location = new System.Drawing.Point(207, 74);
            this.tboxSQLUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tboxSQLUser.Name = "tboxSQLUser";
            this.tboxSQLUser.Size = new System.Drawing.Size(552, 22);
            this.tboxSQLUser.TabIndex = 4;
            // 
            // tboxPassword
            // 
            this.tboxPassword.Location = new System.Drawing.Point(207, 106);
            this.tboxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tboxPassword.Name = "tboxPassword";
            this.tboxPassword.Size = new System.Drawing.Size(552, 22);
            this.tboxPassword.TabIndex = 5;
            // 
            // tboxURL
            // 
            this.tboxURL.Location = new System.Drawing.Point(207, 138);
            this.tboxURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tboxURL.Name = "tboxURL";
            this.tboxURL.Size = new System.Drawing.Size(552, 22);
            this.tboxURL.TabIndex = 6;
            // 
            // tboxClientID
            // 
            this.tboxClientID.Location = new System.Drawing.Point(207, 170);
            this.tboxClientID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tboxClientID.Name = "tboxClientID";
            this.tboxClientID.Size = new System.Drawing.Size(552, 22);
            this.tboxClientID.TabIndex = 7;
            // 
            // tboxSecret
            // 
            this.tboxSecret.Location = new System.Drawing.Point(207, 202);
            this.tboxSecret.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tboxSecret.Name = "tboxSecret";
            this.tboxSecret.Size = new System.Drawing.Size(552, 22);
            this.tboxSecret.TabIndex = 8;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(12, 10);
            this.lblServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(139, 17);
            this.lblServer.TabIndex = 9;
            this.lblServer.Text = "SQL Server Instance";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(12, 42);
            this.lblDatabase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(178, 17);
            this.lblDatabase.TabIndex = 10;
            this.lblDatabase.Text = "Case SQL Database Name";
            // 
            // lblSQLUser
            // 
            this.lblSQLUser.AutoSize = true;
            this.lblSQLUser.Location = new System.Drawing.Point(12, 74);
            this.lblSQLUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSQLUser.Name = "lblSQLUser";
            this.lblSQLUser.Size = new System.Drawing.Size(105, 17);
            this.lblSQLUser.TabIndex = 11;
            this.lblSQLUser.Text = "SQL Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 106);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(101, 17);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "SQL Password";
            // 
            // lblIproURL
            // 
            this.lblIproURL.AutoSize = true;
            this.lblIproURL.Location = new System.Drawing.Point(12, 138);
            this.lblIproURL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIproURL.Name = "lblIproURL";
            this.lblIproURL.Size = new System.Drawing.Size(97, 17);
            this.lblIproURL.TabIndex = 13;
            this.lblIproURL.Text = "Ipro Web URL";
            // 
            // lblClient_id
            // 
            this.lblClient_id.AutoSize = true;
            this.lblClient_id.Location = new System.Drawing.Point(12, 170);
            this.lblClient_id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClient_id.Name = "lblClient_id";
            this.lblClient_id.Size = new System.Drawing.Size(93, 17);
            this.lblClient_id.TabIndex = 14;
            this.lblClient_id.Text = "API_Client_ID";
            // 
            // lblClientSecret
            // 
            this.lblClientSecret.AutoSize = true;
            this.lblClientSecret.Location = new System.Drawing.Point(12, 202);
            this.lblClientSecret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientSecret.Name = "lblClientSecret";
            this.lblClientSecret.Size = new System.Drawing.Size(96, 17);
            this.lblClientSecret.TabIndex = 15;
            this.lblClientSecret.Text = "Client _Secret";
            // 
            // tboxResultsID
            // 
            this.tboxResultsID.Location = new System.Drawing.Point(207, 234);
            this.tboxResultsID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tboxResultsID.Name = "tboxResultsID";
            this.tboxResultsID.Size = new System.Drawing.Size(68, 22);
            this.tboxResultsID.TabIndex = 16;
            // 
            // tboxRevUser
            // 
            this.tboxRevUser.Location = new System.Drawing.Point(207, 266);
            this.tboxRevUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tboxRevUser.Name = "tboxRevUser";
            this.tboxRevUser.Size = new System.Drawing.Size(552, 22);
            this.tboxRevUser.TabIndex = 17;
            // 
            // lblResultsID
            // 
            this.lblResultsID.AutoSize = true;
            this.lblResultsID.Location = new System.Drawing.Point(12, 234);
            this.lblResultsID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResultsID.Name = "lblResultsID";
            this.lblResultsID.Size = new System.Drawing.Size(121, 17);
            this.lblResultsID.TabIndex = 18;
            this.lblResultsID.Text = "Search Results ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 266);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Review Username";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(284, 235);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 23);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rchTxtBx1
            // 
            this.rchTxtBx1.Location = new System.Drawing.Point(16, 656);
            this.rchTxtBx1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rchTxtBx1.Name = "rchTxtBx1";
            this.rchTxtBx1.Size = new System.Drawing.Size(743, 227);
            this.rchTxtBx1.TabIndex = 21;
            this.rchTxtBx1.Text = "";
            // 
            // IForce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 890);
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
            this.Controls.Add(this.btnLaunch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "IForce";
            this.Text = "IForce";
            ((System.ComponentModel.ISupportInitialize)(this.dView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLaunch;
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
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RichTextBox rchTxtBx1;
    }
}

