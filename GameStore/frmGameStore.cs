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
            LoadGamesFromFile();
            UpdateTextBox();
        }

        private GameList gameList = new GameList();

        //Method to update the text box with the game list
        private void UpdateTextBox()
        {
            rchGameInventory.Clear();
            foreach (var game in gameList.GetAllGames())
            {
                rchGameInventory.AppendText(FormatGameForDisplay(game) + Environment.NewLine + Environment.NewLine);
            }
        }

        private void LoadGamesFromFile()
        {
            gameList = new GameList();
            string[] games = System.IO.File.ReadAllLines(@"../../Data/Games.txt");
            foreach (var gameStr in games)
            {
                if (!string.IsNullOrWhiteSpace(gameStr))
                {
                    Game game = ParseGame(gameStr);
                    if (game == null)
                        MessageBox.Show("Could not parse: " + gameStr);
                    if(game != null) 
                        gameList.AddGame(game);
                }
            }
        }

        private Game ParseGame(string gameStr)
        {
            var parts = gameStr.Split('|');

            if (parts.Length != 7)
                return null;

            string title = GetValue(parts[0]);
            string developer = GetValue(parts[1]);
            string publisher = GetValue(parts[2]);
            string genre = GetValue(parts[3]);
            string platform = GetValue(parts[4]);
            string region = GetValue(parts[5]);
            string priceStr = GetValue(parts[6]).Replace("$", "").Trim();

            decimal price;
            if (!decimal.TryParse(priceStr, out price))
                return null;

            return new Game(title, developer, publisher, genre, platform, region, price);
        }

        private string GetValue(string part)
        {
            var idx = part.IndexOf(':');
            if (idx == -1)
                return string.Empty;
            return part.Substring(idx + 1).Trim();
        }

        //Event handler to add a game
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addGame = new frmNewGame();
            if (addGame.ShowDialog() == DialogResult.OK)
            {
                LoadGamesFromFile();
                UpdateTextBox();
            }
        }

        // Event handler to delete game 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Form deteleGame = new frmDeleteGame();
            if (deteleGame.ShowDialog() == DialogResult.OK)
            {
                LoadGamesFromFile();
                UpdateTextBox();
            }
        }

        //Event handler to view all games and clear filters
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            UpdateTextBox();
        }

        //Closes the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            List<Game> gamesToDisplay;
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                gamesToDisplay = gameList.GetAllGames();
            }
            else
            {
                var filter = new SearchGameFilter(txtFilter.Text);
                gamesToDisplay = gameList.FilterGames(filter);
            }

            rchGameInventory.Clear();
            foreach (var game in gamesToDisplay)
            {
                rchGameInventory.AppendText(FormatGameForDisplay(game) + Environment.NewLine + Environment.NewLine);
            }
        }
        private string FormatGameForDisplay(Game game)
        {
            return game.ToString().Replace("|", Environment.NewLine);
        }
    }
}
