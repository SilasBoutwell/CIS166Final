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
    public partial class frmDeleteGame : Form
    {
        public frmDeleteGame()
        {
            InitializeComponent();
        }

        //Event that deletes game
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Code to delete the game in here
        }

        //Event handler to close form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
