using GameStore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationLibrary;

namespace GameStore
{
    /// <summary>
    /// Represents the form for adding a new game to the database.
    /// </summary>
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

        //Method for data validation
        private bool isValid()
        {
            if (txtTitle.Text.Contains(":") ||
                txtDeveloper.Text.Contains(":") ||
                txtPublisher.Text.Contains(":") ||
                txtGenre.Text.Contains(":") ||
                txtPlatform.Text.Contains(":"))
            {
                MessageBox.Show("Please do not use ':' in any of the fields", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (cboRegion.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a valid region option", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (cboRegion.Text == "Select a Region")
            {
                MessageBox.Show("Please select a valid region option", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtTitle.Text == "" ||
                txtDeveloper.Text == "" ||
                txtPublisher.Text == "" ||
                txtGenre.Text == "" ||
                txtPlatform.Text == "" ||
                txtPrice.Text == "")
            {
                MessageBox.Show("Please fill in all fields", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return Validator.IsPresent(txtTitle) &&
                   Validator.IsPresent(txtDeveloper) &&
                   Validator.IsPresent(txtPublisher) &&
                   Validator.IsPresent(txtGenre) &&
                   Validator.IsPresent(txtPlatform) &&
                   Validator.IsPresent(txtPrice) &&
                   Validator.IsDecimal(txtPrice) &&
                   Validator.IsWithinRange(txtPrice, 0, 1000);
        }
    }
}
