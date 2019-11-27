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
            Application.Run(new Form1());
        }

       public static void Connect(DataGridView dview1)
        {
            DataTable res = new DataTable();
            OpenSQL Results = new OpenSQL(UserInput.GetDocids());

            Results.Connection.Open();
            res.Load(Results.SQLQuery.ExecuteReader());
            Results.Connection.Close();
            dview1.DataSource = res;

        }
               
    }

    class UpdateProperties
    {
        public UpdateProperties()
        {

        }
    }
