namespace IForce
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
            this.button1 = new System.Windows.Forms.Button();
            this.dView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblSQLUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblIproURL = new System.Windows.Forms.Label();
            this.lblClient_id = new System.Windows.Forms.Label();
            this.lblClientSecret = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.lblResultsID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 588);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(560, 131);
            this.button1.TabIndex = 0;
            this.button1.Text = "Kick the Tires...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dView1
            // 
            this.dView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dView1.Location = new System.Drawing.Point(2, 242);
            this.dView1.Name = "dView1";
            this.dView1.Size = new System.Drawing.Size(560, 340);
            this.dView1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(407, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(155, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(407, 20);
            this.textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(155, 60);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(407, 20);
            this.textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(155, 86);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(407, 20);
            this.textBox4.TabIndex = 5;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(155, 112);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(407, 20);
            this.textBox5.TabIndex = 6;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(155, 138);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(407, 20);
            this.textBox6.TabIndex = 7;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(155, 164);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(407, 20);
            this.textBox7.TabIndex = 8;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(9, 8);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(106, 13);
            this.lblServer.TabIndex = 9;
            this.lblServer.Text = "SQL Server Instance";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(9, 34);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(135, 13);
            this.lblDatabase.TabIndex = 10;
            this.lblDatabase.Text = "Case SQL Database Name";
            // 
            // lblSQLUser
            // 
            this.lblSQLUser.AutoSize = true;
            this.lblSQLUser.Location = new System.Drawing.Point(9, 60);
            this.lblSQLUser.Name = "lblSQLUser";
            this.lblSQLUser.Size = new System.Drawing.Size(79, 13);
            this.lblSQLUser.TabIndex = 11;
            this.lblSQLUser.Text = "SQL Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(9, 86);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(77, 13);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "SQL Password";
            // 
            // lblIproURL
            // 
            this.lblIproURL.AutoSize = true;
            this.lblIproURL.Location = new System.Drawing.Point(9, 112);
            this.lblIproURL.Name = "lblIproURL";
            this.lblIproURL.Size = new System.Drawing.Size(76, 13);
            this.lblIproURL.TabIndex = 13;
            this.lblIproURL.Text = "Ipro Web URL";
            // 
            // lblClient_id
            // 
            this.lblClient_id.AutoSize = true;
            this.lblClient_id.Location = new System.Drawing.Point(9, 138);
            this.lblClient_id.Name = "lblClient_id";
            this.lblClient_id.Size = new System.Drawing.Size(73, 13);
            this.lblClient_id.TabIndex = 14;
            this.lblClient_id.Text = "API_Client_ID";
            // 
            // lblClientSecret
            // 
            this.lblClientSecret.AutoSize = true;
            this.lblClientSecret.Location = new System.Drawing.Point(9, 164);
            this.lblClientSecret.Name = "lblClientSecret";
            this.lblClientSecret.Size = new System.Drawing.Size(73, 13);
            this.lblClientSecret.TabIndex = 15;
            this.lblClientSecret.Text = "Client _Secret";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(155, 190);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(52, 20);
            this.textBox8.TabIndex = 16;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(155, 216);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(407, 20);
            this.textBox9.TabIndex = 17;
            // 
            // lblResultsID
            // 
            this.lblResultsID.AutoSize = true;
            this.lblResultsID.Location = new System.Drawing.Point(9, 190);
            this.lblResultsID.Name = "lblResultsID";
            this.lblResultsID.Size = new System.Drawing.Size(93, 13);
            this.lblResultsID.TabIndex = 18;
            this.lblResultsID.Text = "Search Results ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Review Username";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(213, 191);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 19);
            this.button2.TabIndex = 20;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 723);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblResultsID);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.lblClientSecret);
            this.Controls.Add(this.lblClient_id);
            this.Controls.Add(this.lblIproURL);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblSQLUser);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblSQLUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblIproURL;
        private System.Windows.Forms.Label lblClient_id;
        private System.Windows.Forms.Label lblClientSecret;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label lblResultsID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}

