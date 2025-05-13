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
            UpdateTextBox();
        }

        //Method to update the text box with the game list
        private void UpdateTextBox()
        {
            rchGameInventory.Clear();
            string[] games = System.IO.File.ReadAllText(@"../../Data/Games.txt").Split('|');
            foreach (var game in games)
            {
                rchGameInventory.AppendText(game + Environment.NewLine);
            }
        }

        //Event handler to add a game
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addGame = new frmNewGame();
            if (addGame.ShowDialog() == DialogResult.OK)
            {
                UpdateTextBox();
            }
        }

        // Event handler to delete game 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Form deteleGame = new frmDeleteGame();
            deteleGame.ShowDialog();
        }

        //Event handler to view all games and clear filters
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            //
            //Code to clear the filters in here
            //
        }

        //Closes the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
