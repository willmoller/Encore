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

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            frmGame gameForm = new frmGame();
            this.Hide();
            gameForm.ShowDialog();
            this.Close();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {

        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {

        }
    }
}
