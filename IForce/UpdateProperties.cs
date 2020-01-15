﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.IO;
namespace IForce
{
    class UpdateProperties
    {
        public bool UpdateUserInputs(string server, string db, string sqluser, string pw, string url, CheckedListBox chx)
        {
            bool success = false;
            try
            {
                if (server == String.Empty || db == String.Empty || sqluser == String.Empty ||
                    pw == String.Empty || url == String.Empty ||  chx.SelectedItems.Count == 0)
                {
                    MessageBox.Show("One or more fields are empty. Please fill all fields and select a case.");

                }
                else
                {
                    UserInput.ServerName = server;
                    UserInput.ADDDatabase = db;
                    UserInput.SQLUserName = sqluser;
                    UserInput.Password = pw;
                    UserInput.IproURL = url;
                    
                    success = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("One or more fields may be null. ERROR: " + ex.Message);
            }
            return success;
        }

        public bool UpdateSearchInputs(string server, string db, string sqluser, string pw, CheckedListBox chx)
        {
            bool success = false;
            try
            {
                if (server == String.Empty || db == String.Empty || sqluser == String.Empty ||
                    pw == String.Empty ||  chx.SelectedItems.Count == 0)
                {
                    MessageBox.Show("One or more fields are empty. Please fill all fields and select a case");
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

        public bool UpdateConnectBtnInputs(string server, string db, string sqluser, string pw)
        {
            bool success = false;
            try
            {
                if (server == String.Empty || db == String.Empty || sqluser == String.Empty ||
                    pw == String.Empty)
                {
                    MessageBox.Show("One or more fields are empty. Please fill all fields");
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
