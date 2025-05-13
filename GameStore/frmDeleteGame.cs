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
            string[] games = System.IO.File.ReadAllText("../../Data/Games.txt").ToString().Split('\n');
            foreach (string game in games)
            {
                if (game == "")
                    break;

                string[] parts = game.Split('|');
                string title = parts[0].Split(':')[1];

                if (!cboTitle.Items.Contains(title))
                {
                    cboTitle.Items.Add(title);
                }
            }
            cboTitle.SelectedIndex = 0;
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

        private void cboTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] games = System.IO.File.ReadAllText("../../Data/Games.txt").ToString().Split('\n');
            foreach (string game in games)
            {
                if (game.Contains(cboTitle.Text))
                {
                    if (game == "")
                        break;

                    string[] parts = game.Split('|');
                    string developer = parts[2].Split(':')[1];

                    if (!cboDeveloper.Items.Contains(developer))
                    {
                        cboDeveloper.Items.Add(developer);
                    }
                }
            }
            if (cboDeveloper.Items.Count > 0)
                cboDeveloper.SelectedIndex = 0;
        }

        private void cboDeveloper_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPublisher.Items.Clear();
            string[] developers = System.IO.File.ReadAllText("../../Data/Games.txt").ToString().Split('\n');
            foreach (string developer in developers)
            {
                if (developer.Contains(cboTitle.Text) && developer.Contains(cboDeveloper.Text))
                {
                    if (developer == "")
                        break;

                    string[] parts = developer.Split('|');
                    string publisher = parts[3].Split(':')[1];

                    if (!cboPublisher.Items.Contains(publisher))
                    {
                        cboPublisher.Items.Add(publisher);
                    }
                }
            }
            if (cboPublisher.Items.Count > 0)
                cboPublisher.SelectedIndex = 0;
        }
    }
}
