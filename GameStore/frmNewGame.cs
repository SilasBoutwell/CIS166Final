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
        }

        //Event handler to add a game to the main form
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isValid())
            {

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
            if (String.IsNullOrWhiteSpace(txbTitle.Text))
            {
                MessageBox.Show("Please enter the game title", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (String.IsNullOrWhiteSpace(txbDeveloper.Text))
            {
                MessageBox.Show("Please enter the developer name", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (String.IsNullOrWhiteSpace(txbPublisher.Text))
            {
                MessageBox.Show("Please enter the publisher name", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //else if()

            else if (String.IsNullOrWhiteSpace(txbPlatform.Text))
            {
                MessageBox.Show("Please enter the platform name", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (cmbRegion.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a valid region option", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
