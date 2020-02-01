using System;
using System.Windows.Forms;

namespace IForce
{
    class UpdateProperties
    {
        public bool UpdateUserInputs(string server, string db, string sqluser, string pw, string url, string srchName, CheckedListBox chx)
        {
            bool success = false;
            try
            {
                if (server == String.Empty || db == String.Empty || sqluser == String.Empty ||
                    pw == String.Empty || url == String.Empty || srchName == String.Empty ||chx.SelectedItems.Count == 0)
                {
                    MessageBox.Show("One or more fields are empty. Please fill all fields and select a case.");

                }
                else
                {
                    UserInput.ServerName = server;
                    UserInput.ADDDatabase = db;
                    UserInput.SQLUserName = sqluser;
                    UserInput.Password = pw;
                    UserInput.IdentURL = url;
                    UserInput.SearchName = srchName;

                    success = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("One or more fields may be null. ERROR: " + ex.Message);
            }
            return success;
        }

        public bool UpdateSearchInputs(string server, string db, string sqluser, string pw, string url, CheckedListBox chx)
        {
            bool success = false;
            try
            {
                if (server == String.Empty || db == String.Empty || sqluser == String.Empty ||
                    pw == String.Empty || chx.SelectedItems.Count == 0)
                {
                    MessageBox.Show("One or more fields are empty. Please fill all fields and select a case");
                }
                else
                {
                    UserInput.ServerName = server;
                    UserInput.ADDDatabase = db;
                    UserInput.SQLUserName = sqluser;
                    UserInput.Password = pw;
                    UserInput.IdentURL = url;

                    success = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("One or more fields may be null. ERROR: " + ex.Message);
            }
            return success;
        }

        public bool UpdateConnectBtnInputs(string server, string db, string sqluser, string pw)
        {
            bool success = false;
            try
            {
                if (server == String.Empty || db == String.Empty || sqluser == String.Empty ||
                    pw == String.Empty)
                {
                    MessageBox.Show("One or more fields are empty. Please fill all fields");
                    IForce._iforce.btnConnect.Enabled = true;
                }
                else
                {
                    UserInput.ServerName = server;
                    UserInput.ADDDatabase = db;
                    UserInput.SQLUserName = sqluser;
                    UserInput.Password = pw;
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
