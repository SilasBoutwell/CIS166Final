using GameStore.Data;
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
    public partial class frmNewGame : Form
    {
        public frmNewGame()
        {
            InitializeComponent();
            cboRegion.SelectedIndex = 0;
        }

        //Event handler to add a game to the main form
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                Game game = new Game(
                    txtTitle.Text,
                    txtDeveloper.Text,
                    txtPublisher.Text,
                    txtGenre.Text,
                    txtPlatform.Text,
                    cboRegion.SelectedItem.ToString(),
                    decimal.Parse(txtPrice.Text));

                GameDB.Save(game);
                this.DialogResult = DialogResult.OK;
            }
        }

        //Event handler to close the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Method to data validation
        private bool isValid()
        {
            if (String.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter the game title", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (String.IsNullOrWhiteSpace(txtDeveloper.Text))
            {
                MessageBox.Show("Please enter the developer name", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (String.IsNullOrWhiteSpace(txtPublisher.Text))
            {
                MessageBox.Show("Please enter the publisher name", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (String.IsNullOrWhiteSpace(txtGenre.Text))
            {
                MessageBox.Show("Please enter the publisher name", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (String.IsNullOrWhiteSpace(txtPlatform.Text))
            {
                MessageBox.Show("Please enter the platform name", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (cboRegion.Text == "Select a Region")
            {
                MessageBox.Show("Please select a valid region option", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (String.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please enter the publisher name", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (price < 0)
            {
                MessageBox.Show("Please enter a valid price", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
