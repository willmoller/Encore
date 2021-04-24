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
    public partial class frmHighScores : Form
    {
        private User user;
        public frmHighScores(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void frmHighScores_Load(object sender, EventArgs e)
        {
            lblName.Text = user.FirstName + " " + user.LastName + "'s High Scores";
            double[] userStats = UserDB.GetUserStatsById(user.UserID);

            txtAverage.Text = userStats[0].ToString();
            txtTotalPlays.Text = userStats[1].ToString();

            List<string[]> userPlays = UserDB.GetUserPlaysByID(user.UserID);
            int i = 0;

            foreach (string[] play in userPlays)
            {
                lvHighScores.Items.Add(play[0]);
                lvHighScores.Items[i].SubItems.Add(play[1]);
                lvHighScores.Items[i].SubItems.Add(play[2]);
                i++;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
