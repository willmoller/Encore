using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encore.Views
{
    public partial class frmAdminView : Form
    {
        private User user;

        public frmAdminView(User newUser)
        {
            user = newUser;
            InitializeComponent();
        }

        private void frmAdminView_Load(object sender, EventArgs e)
        {
            string welcome = "Hello, " + user.FirstName + ".";
            lblHello.Text = welcome;

            //rdoUser.CheckedChanged += radioButtons_CheckChanged;
            //rdoBoard.CheckedChanged += radioButtons_CheckChanged;
            //rdoAll.CheckedChanged += radioButtons_CheckChanged;
        }

        private void radioButtons_CheckChanged(object sender, EventArgs e)
        {
            if (rdoUser.Checked)
            {
                List<User> users = UserDB.GetAllUsers();
                foreach (User user in users)
                {
                    lboList.Items.Add(user.UserID + "\t" + user.FirstName + "\t" + user.LastName);
                }
            }
            else if (rdoBoard.Checked)
            {

            }
            else
            {

            }
        }

        private void rdoUser_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
