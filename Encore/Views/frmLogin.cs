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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtUsername.Text;
            string pwd = txtPassword.Text;

            User user = UserDB.UserLogin(userId, pwd);

            if (user != null)
            {
                if (user.Role == "player")
                {
                    this.Hide();
                    frmMainMenu main = new frmMainMenu(user);
                    main.ShowDialog();
                    this.Show();
                } else
                {
                    this.Hide();
                    frmAdminView admin = new frmAdminView(user);
                    admin.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Invalid Credentials");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Hide();
            frmRegister register = new frmRegister();
            register.ShowDialog();
            Show();
        }
    }
}
