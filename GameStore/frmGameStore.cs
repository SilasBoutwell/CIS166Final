using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStore
{
    public partial class frmGameStore : Form
    {
        public frmGameStore()
        {
            InitializeComponent();
        }

        //Event handler to add a game
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addGame = new frmNewGame();
            addGame.ShowDialog();
        }

        //Closes the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
