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
    /// <summary>
    /// Delete game form to allow user to delete a game from the database.
    /// </summary>
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
            Game game = new Game(
                cboTitle.Text,
                cboDeveloper.Text,
                cboPublisher.Text,
                cboGenre.Text,
                cboPlatform.Text,
                cboRegion.Text,
                decimal.Parse(cboPrice.Text.Replace("$", "")));

            this.Tag = game;
            this.DialogResult = DialogResult.OK;
        }

        //Event handler to close form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //*****
        //Following code is to populate the combo boxes
        //*****

        private void cboTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDeveloper.Items.Clear();
            string[] games = System.IO.File.ReadAllText("../../Data/Games.txt").ToString().Split('\n');
            foreach (string game in games)
            {
                if (game.Contains(cboTitle.Text))
                {
                    if (game == "")
                        break;

                    string[] parts = game.Split('|');
                    string developer = parts[1].Split(':')[1];

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
                    string item = parts[2].Split(':')[1];

                    if (!cboPublisher.Items.Contains(item))
                    {
                        cboPublisher.Items.Add(item);
                    }
                }
            }
            if (cboPublisher.Items.Count > 0)
                cboPublisher.SelectedIndex = 0;
        }

        private void cboPublisher_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboGenre.Items.Clear();
            string[] genres = System.IO.File.ReadAllText("../../Data/Games.txt").ToString().Split('\n');
            foreach (string genre in genres)
            {
                if (genre.Contains(cboTitle.Text) && 
                    genre.Contains(cboDeveloper.Text) &&
                    genre.Contains(cboPublisher.Text))
                {
                    if (genre == "")
                        break;

                    string[] parts = genre.Split('|');
                    string item = parts[3].Split(':')[1];

                    if (!cboGenre.Items.Contains(item))
                    {
                        cboGenre.Items.Add(item);
                    }
                }
            }
            if (cboGenre.Items.Count > 0)
                cboGenre.SelectedIndex = 0;
        }

        private void cboGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPlatform.Items.Clear();
            string[] platforms = System.IO.File.ReadAllText("../../Data/Games.txt").ToString().Split('\n');
            foreach (string platform in platforms)
            {
                if (platform.Contains(cboTitle.Text) &&
                    platform.Contains(cboDeveloper.Text) &&
                    platform.Contains(cboPublisher.Text) &&
                    platform.Contains(cboGenre.Text))
                {
                    if (platform == "")
                        break;

                    string[] parts = platform.Split('|');
                    string item = parts[4].Split(':')[1];

                    if (!cboPlatform.Items.Contains(item))
                    {
                        cboPlatform.Items.Add(item);
                    }
                }
            }
            if (cboPlatform.Items.Count > 0)
                cboPlatform.SelectedIndex = 0;
        }

        private void cboPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboRegion.Items.Clear();
            string[] regions = System.IO.File.ReadAllText("../../Data/Games.txt").ToString().Split('\n');
            foreach (string region in regions)
            {
                if (region.Contains(cboTitle.Text) &&
                    region.Contains(cboDeveloper.Text) &&
                    region.Contains(cboPublisher.Text) &&
                    region.Contains(cboGenre.Text) &&
                    region.Contains(cboRegion.Text))
                {
                    if (region == "")
                        break;

                    string[] parts = region.Split('|');
                    string item = parts[5].Split(':')[1];

                    if (!cboRegion.Items.Contains(item))
                    {
                        cboRegion.Items.Add(item);
                    }
                }
            }
            if (cboRegion.Items.Count > 0)
                cboRegion.SelectedIndex = 0;
        }

        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPrice.Items.Clear();
            string[] prices = System.IO.File.ReadAllText("../../Data/Games.txt").ToString().Split('\n');
            foreach (string price in prices)
            {
                if (price.Contains(cboTitle.Text) &&
                    price.Contains(cboDeveloper.Text) &&
                    price.Contains(cboPublisher.Text) &&
                    price.Contains(cboGenre.Text) &&
                    price.Contains(cboRegion.Text) &&
                    price.Contains(cboPrice.Text))
                {
                    if (price == "")
                        break;

                    string[] parts = price.Split('|');
                    string item = parts[6].Split(':')[1];

                    if (!cboPrice.Items.Contains(item))
                    {
                        cboPrice.Items.Add(item);
                    }
                }
            }
            if (cboPrice.Items.Count > 0)
                cboPrice.SelectedIndex = 0;
        }
    }
}
