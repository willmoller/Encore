using Encore.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encore
{
    public partial class frmMainMenu : Form
    {
        private User user;
        public frmMainMenu(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            string[] boards =
            {
                "Select a board...",
                "Black", "Orange", "Yellow", "Purple", "Pink", "Green", "Blue"
            };

            foreach (String s in boards)
            {
                cboBoardSelection.Items.Add(s);
            }
            cboBoardSelection.SelectedIndex = 0;

            lblHello.Text = "Hello, " + user.FirstName + ".";
        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            if (cboBoardSelection.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a Board to play.", "Missing Board");
            } 
            else
            {
                frmGame gameForm = new frmGame(cboBoardSelection.SelectedIndex, user);
                this.Hide();
                gameForm.ShowDialog();
                this.Show();
            }
            
        }

        private void btnRules_Click(object sender, EventArgs e)
        {

        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            Hide();
            frmHighScores newScores = new frmHighScores(user);
            newScores.ShowDialog();
            Show();
        }
    }
}
