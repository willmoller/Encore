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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool valid = true;
            string message = "";
            User newUser = new User();
            if (UserDB.DoesUsernameExist(txtUsername.Text))
            {
                valid = false;
                message += "Username is already in use.";
            }
            else
            {
                newUser.Username = txtUsername.Text;
            }

            if (txtPassword1.Text == txtPassword2.Text)
            {
                newUser.setPassword(txtPassword2.Text);
            } else
            {
                valid = false;
                message += "\nPasswords do not match.";
            }

            newUser.Role = "player";
            newUser.FirstName = txtFirstName.Text;
            newUser.LastName = txtLastName.Text;
            if (!valid)
            {
                MessageBox.Show(message, "Error");
            } else
            {
                UserDB.AddUser(newUser);
                MessageBox.Show("Thanks for Registering " + newUser.FirstName + "!", "Registration Complete");
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
