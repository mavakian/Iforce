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

        public static void Connect(DataGridView dview1)
        {
            DataTable res = new DataTable();
            OpenSQL Results = new OpenSQL(UserInput.GetDocids());

            Results.Connection.Open();
            res.Load(Results.Cmd.ExecuteReader());
            Results.Connection.Close();
            dview1.DataSource = res;

        }

        public static void Search(DataGridView dview1)
        {
            DataTable srch = new DataTable();
            OpenSQL Results = new OpenSQL(UserInput.GetDocids());

            Results.Connection.Open();
            srch.Load(Results.Cmd.ExecuteReader());
            Results.Connection.Close();
            dview1.DataSource = srch;

        }

    }

    class UpdateProperties
    {
        public UpdateProperties(string server, string db, string sqluser, string pw, string url, string clientid, string secret, string id, string rvwuser)
        {
            try
            {
                if(server==String.Empty || db== String.Empty || sqluser== String.Empty || 
                    pw== String.Empty || url== String.Empty || clientid== String.Empty || 
                    secret== String.Empty || id == String.Empty || rvwuser == String.Empty)
                {
                    MessageBox.Show("One or more fields are null. Please fill all fields");
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
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("One or more fields may be null. ERROR: "+ex.Message);
            }
        }
    }
}
