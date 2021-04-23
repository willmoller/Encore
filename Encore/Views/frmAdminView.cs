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
            rdoAll.CheckedChanged += radioButtons_CheckChanged;

            idList = new List<int>();
        }

        private void radioButtons_CheckChanged(object sender, EventArgs e)
        {
            // add code to empty list
            lvList.Items.Clear();
            idList.Clear();

            if (rdoUser.Checked)
            {
                users = UserDB.GetAllUsers();
                //lboList.Items.Add("User ID\tFirst\tLast\n");
                foreach (User user in users)
                {
                    lvList.Items.Add(user.UserID.ToString()).SubItems.Add(user.FirstName + " " + user.LastName);
                    idList.Add(user.UserID);
                }
            }
            else if (rdoBoard.Checked)
            {
                List<Board> boards = BoardDB.GetAllBoards();
                //lboList.Items.Add("Board ID\tName\n");
                foreach (Board board in boards)
                {
                    lvList.Items.Add(board.BoardID.ToString()).SubItems.Add(board.BoardName);
                    idList.Add(board.BoardID);
                }
            }
            else
            {
                //lvList.Enabled = false;
                lvList.Items.Add("ALL").SubItems.Add("GAMES PLAYED");
                // get all users and the average of all user scores to 1 decimal place
                List<double> stats = BoardDB.GetStatsAllBoards();
                txtAverage.Text = Math.Round(stats[0], 1).ToString();
                txtPlays.Text = Math.Round(stats[1], 1).ToString();
            }
        }

        private void rdoUser_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = lvList.SelectedIndices;
            if (rdoUser.Checked)
            {
                List<double> stats = UserDB.GetStatsByUser(1);
                txtAverage.Text = Math.Round(stats[0], 1).ToString();
                txtPlays.Text = Math.Round(stats[1], 1).ToString();
            }
            else if (rdoBoard.Checked)
            {
                List<double> stats = BoardDB.GetStatsByBoard(1);
                txtAverage.Text = Math.Round(stats[0], 1).ToString();
                txtPlays.Text = Math.Round(stats[1], 1).ToString();
            }
        }
    }
}
