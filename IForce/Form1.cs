using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
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
                Program.Connect(dView1, rchTxtBx1);
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
                Program.Search(dView1);
            };
                   
        }


    }
}
