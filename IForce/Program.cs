using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace IForce
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IForce());
        }

        

        public static void Connect(DataGridView dview1, RichTextBox rchbx1)
        {
            DataTable res = new DataTable();
            OpenSQL Results = new OpenSQL(UserInput.GetDocids());

            rchbx1.AppendText(Environment.NewLine + "Opening Connection To SQL");
            Results.Connection.Open();

            rchbx1.AppendText(Environment.NewLine + "Executing SQL Reader");
            res.Load(Results.Cmd.ExecuteReader());

            rchbx1.AppendText(Environment.NewLine + "Closing Connection To SQL");
            Results.Connection.Close();

            rchbx1.AppendText(Environment.NewLine + "Displaying Data Table Results");
            dview1.DataSource = res;

            rchbx1.AppendText(Environment.NewLine + "Beginning File Copy");
            IForceApp.CopyAndRenameFiles(res, rchbx1);

            rchbx1.AppendText(Environment.NewLine + "File Copy Complete");
        }

        public static void Search(DataGridView dview1)
        {
            DataTable srch = new DataTable();
            OpenSQL Results = new OpenSQL(UserInput.GetDocids());
            try
            {
                Results.Connection.Open();
                srch.Load(Results.Cmd.ExecuteReader());
                Results.Connection.Close();
                dview1.DataSource = srch;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
            

        }

    }

    class UpdateProperties
    {
        public bool UpdateUserInputs(string server, string db, string sqluser, string pw, string url, string clientid, string secret, string id, string rvwuser)
        {
            bool success = false;
            try
            {
                if(server==String.Empty || db== String.Empty || sqluser== String.Empty || 
                    pw== String.Empty || url== String.Empty || clientid== String.Empty || 
                    secret== String.Empty || id == String.Empty || rvwuser == String.Empty)
                {
                    MessageBox.Show("One or more fields are empty. Please fill all fields");
                    
                }
                else
                {
                    UserInput.ServerName = server;
                    UserInput.CaseDataase = db;
                    UserInput.SQLUserName = sqluser;
                    UserInput.Password = pw;
                    UserInput.IproURL = url;
                    UserInput.Client_ID = clientid;
                    UserInput.Client_Secret = secret;
                    UserInput.ResultsID = Convert.ToInt32(id);
                    UserInput.ReviewUsername = rvwuser;
                    success = true;
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("One or more fields may be null. ERROR: "+ex.Message);
            }
            return success;
        }

        public bool UpdateSearchInputs(string server, string db, string sqluser, string pw, string id)
        {
            bool success = false;
            try
            {
                if (server == String.Empty || db == String.Empty || sqluser == String.Empty ||
                    pw == String.Empty || id == String.Empty)
                {
                    MessageBox.Show("One or more fields are empty. Please fill all fields");
                }
                else
                {
                    UserInput.ServerName = server;
                    UserInput.CaseDataase = db;
                    UserInput.SQLUserName = sqluser;
                    UserInput.Password = pw;
                    UserInput.ResultsID = Convert.ToInt32(id);
                    success = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("One or more fields may be null. ERROR: " + ex.Message);
            }
            return success;
        }

    }
}
