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
            new UpdateProperties(tboxServer.Text,
                                 tboxDb.Text,
                                 tboxSQLUser.Text,
                                 tboxPassword.Text,
                                 tboxURL.Text,
                                 tboxClientID.Text,
                                 tboxSecret.Text,
                                 tboxResultsID.Text,
                                 tboxRevUser.Text);
            Program.Connect(dView1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Program.Search(dView1);
        }


    }
}
