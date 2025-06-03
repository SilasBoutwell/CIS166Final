using GameStore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStore
{
    /// <summary>
    /// This class represents the main form of the game store application.
    /// </summary>
    public partial class frmGameStore : Form
    {
        public frmGameStore()
        {
            InitializeComponent();
            LoadGamesFromFile();
            UpdateTextBox();
            cboPriceFilter.SelectedIndex = 0;
        }

        private ItemList<IGame> gameList = new ItemList<IGame>();

        //Method to update the text box with the game list
        private void UpdateTextBox()
        {
            rchGameInventory.Clear();
            foreach (var game in gameList.GetAllItems())
            {
                rchGameInventory.AppendText(FormatGameForDisplay(game) + Environment.NewLine + Environment.NewLine);
            }
        }

        private void LoadGamesFromFile()
        {
            gameList = new ItemList<IGame>();
            string[] games = System.IO.File.ReadAllLines(@"../../Data/Games.txt");
            foreach (var gameStr in games)
            {
                if (!string.IsNullOrWhiteSpace(gameStr))
                {
                    IGame game = ParseGame(gameStr);
                    if (game == null)
                        MessageBox.Show("Could not parse: " + gameStr);
                    if (game != null)
                        gameList.AddItem(game);
                }
            }
        }

        private IGame ParseGame(string gameStr)
        {
            var parts = gameStr.Split('|');
            if (parts.Length != 8)
                return null;

            string timestamp = parts[0].Trim();
            string title = GetValue(parts[1]);
            string developer = GetValue(parts[2]);
            string publisher = GetValue(parts[3]);
            string genre = GetValue(parts[4]);
            string platform = GetValue(parts[5]);
            string region = GetValue(parts[6]);
            string priceStr = GetValue(parts[7]).Replace("$", "").Trim();

            decimal price;
            if (!decimal.TryParse(priceStr, out price))
                return null;

            switch (region)
            {
                case "Europe":
                    return new GameStore.Regions.Europe(timestamp, title, developer, publisher, genre, platform, region, price);
                case "North America":
                    return new GameStore.Regions.NorthAmerica(timestamp, title, developer, publisher, genre, platform, region, price);
                case "Japan":
                    return new GameStore.Regions.Japan(timestamp, title, developer, publisher, genre, platform, region, price);
                case "Korea":
                    return new GameStore.Regions.Korea(timestamp, title, developer, publisher, genre, platform, region, price);
                case "Asia":
                    return new GameStore.Regions.Asia(timestamp, title, developer, publisher, genre, platform, region, price);
                default:
                    return null;
            }
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
                MessageBox.Show("Game added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event handler to delete game 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Form deteleGame = new frmDeleteGame();
            if (deteleGame.ShowDialog() == DialogResult.OK)
            {
                IGame toDelete = (IGame)deteleGame.Tag;
                var deleteFilter = new DeleteGameFilter(toDelete);

                var updatedGames = gameList.GetAllItems()
                    .Where(g => !deleteFilter.IsMatch(g))
                    .ToList();

                gameList = new ItemList<IGame>();
                foreach (var g in updatedGames)
                    gameList.AddItem(g);

                System.IO.File.WriteAllLines(@"../../Data/Games.txt", updatedGames.Select(g => g.ToString()));

                GameStore.Data.CommentsDB.DeleteCommentsForGame(toDelete);
                LoadGamesFromFile();
                UpdateTextBox();
                MessageBox.Show("Game deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Event handler to view all games and clear filters
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            isPaginated = false;
            btnNext.Visible = false;
            btnPrevious.Visible = false;
            txtCurrentPage.Visible = false;
            txtCurrentPage.Text = "";
            txtFilter.Clear();
            cboPriceFilter.SelectedIndex = 0;
            LoadGamesFromFile();
            UpdateTextBox();
        }

        //Closes the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string FormatGameForDisplay(IGame game)
        {
            return game.ToString().Replace("|", Environment.NewLine);
        }

        private void cboPriceFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string selectedPrice = cboPriceFilter.SelectedItem?.ToString();
            IFilter<IGame> priceFilter = new PriceRangeFilter(selectedPrice);

            IEnumerable<IGame> filteredGames = gameList.GetAllItems();

            // Apply text filter if present
            if (!string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                var textFilter = new SearchGameFilter(txtFilter.Text);
                filteredGames = filteredGames.Where(g => textFilter.IsMatch(g));
            }

            // Apply price filter if not "Price Filter"
            if (selectedPrice != "Price Filter")
            {
                filteredGames = filteredGames.Where(g => priceFilter.IsMatch(g));
            }

            rchGameInventory.Clear();
            foreach (var game in filteredGames)
            {
                rchGameInventory.AppendText(FormatGameForDisplay(game) + Environment.NewLine + Environment.NewLine);
            }
        }

        private void btnComments_Click(object sender, EventArgs e)
        {
            using (var comments = new frmComments())
            {
                if (!comments.IsUserLoggedIn)
                {
                    return; // Do not proceed if the user is not logged in
                }

                comments.ShowDialog();
            }
        }

        private int currentPage = 1;
        private int pageSize = 10;
        private int totalGames = 0;
        private int totalPages = 0;
        private bool isPaginated = false;

        private void btnPaginate_Click(object sender, EventArgs e)
        {
            if (isPaginated)
            {
                isPaginated = false;
                btnNext.Visible = false;
                btnPrevious.Visible = false;
                txtCurrentPage.Visible = false;
                txtCurrentPage.Text = "";
                UpdateTextBox(); 
            }
            else
            {
                isPaginated = true;
                currentPage = 1;
                btnNext.Visible = true;
                btnPrevious.Visible = true;
                txtCurrentPage.Visible = true;
                LoadGamesPage();
            }
        }

        private void LoadGamesPage()
        {
            var allGames = gameList.GetAllItems();
            totalGames = allGames.Count;
            totalPages = (int)Math.Ceiling((double)totalGames / pageSize);

            var gamesToShow = allGames
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            rchGameInventory.Clear();
            foreach (var game in gamesToShow)
            {
                rchGameInventory.AppendText(FormatGameForDisplay(game) + Environment.NewLine + Environment.NewLine);
            }

            // Display current page info
            txtCurrentPage.Text = $"Page {currentPage} of {Math.Max(totalPages, 1)}";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadGamesPage();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadGamesPage();
            }
        }
    }
}
