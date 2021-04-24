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
        private List<User> users;
        private User user;
        private List<int> idList;

        public frmAdminView(User newUser)
        {
            user = newUser;
            InitializeComponent();
        }

        private void frmAdminView_Load(object sender, EventArgs e)
        {
            string welcome = "Hello, " + user.FirstName + ".";
            lblHello.Text = welcome;

            rdoUser.CheckedChanged += radioButtons_CheckChanged;
            rdoBoard.CheckedChanged += radioButtons_CheckChanged;

            idList = new List<int>();
        }

        private void radioButtons_CheckChanged(object sender, EventArgs e)
        {
            // add code to empty list
            lvList.Items.Clear();

            if (rdoUser.Checked)
            {
                List<string[]> userStats = UserDB.GetUserStats();
                int i = 0;
                foreach (string[] user in userStats)
                {
                    lvList.Items.Add(user[0]);
                    lvList.Items[i].SubItems.Add(user[1]);
                    lvList.Items[i].SubItems.Add(user[2]);
                    lvList.Items[i].SubItems.Add(user[3]);
                    i++;
                }
            }
            else
            {
                List<string[]> boardStats = BoardDB.GetStatsAllBoards();
                int i = 0;
                foreach (string[] board in boardStats)
                {
                    lvList.Items.Add(board[0]);
                    lvList.Items[i].SubItems.Add(board[1]);
                    lvList.Items[i].SubItems.Add(board[2]);
                    lvList.Items[i].SubItems.Add(board[3]);
                    i++;
                }
            }
        }
    }
}
