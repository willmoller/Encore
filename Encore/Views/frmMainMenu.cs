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
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            string[] boards =
            {
                "Select a board...",
                "Black", "Orange", "Yellow", "Purple"
            };

            foreach (String s in boards)
            {
                cboBoardSelection.Items.Add(s);
            }
            cboBoardSelection.SelectedIndex = 0;
        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            if (cboBoardSelection.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a Board to play.", "Missing Board");
            } 
            else
            {
                frmGame gameForm = new frmGame(cboBoardSelection.SelectedIndex);
                this.Hide();
                gameForm.ShowDialog();
                this.Close();
            }
            
        }

        private void btnRules_Click(object sender, EventArgs e)
        {

        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {

        }
    }
}
