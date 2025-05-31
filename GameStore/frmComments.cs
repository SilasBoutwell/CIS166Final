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
    public partial class frmComments : Form
    {
        public bool IsUserLoggedIn { get; private set; } = false;

        public frmComments()
        {
            InitializeComponent();

            pnlComments.AutoScroll = true;

            // Populate game titles
            string[] games = System.IO.File.ReadAllText("../../Data/Games.txt").ToString().Split('\n');
            foreach (string game in games)
            {
                if (game == "")
                    break;

                string[] parts = game.Split('|');
                string title = parts[1].Split(':')[1];

                if (!cboTitle.Items.Contains(title))
                {
                    cboTitle.Items.Add(title);
                }
            }
            cboTitle.SelectedIndex = 0;

            // Check for logged-in user
            if (!LoggedInUser.IsLoggedIn)
            {
                MessageBox.Show("You must log in to add a comment.");
                using (var loginForm = new frmLogin())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK && LoggedInUser.IsLoggedIn)
                    {
                        IsUserLoggedIn = true;
                        MessageBox.Show("Welcome to the comments " + LoggedInUser.Current.Username + "!");
                    }
                    else
                    {
                        MessageBox.Show("You must log in to add a comment.");
                        return;
                    }
                }
            }
            else
            {
                IsUserLoggedIn = true;
                MessageBox.Show("Welcome to the comments " + LoggedInUser.Current.Username + "!");
            }

            // Load comments for the selected game
            this.Shown += (s, e) => LoadComments();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            LoggedInUser.Logout();
            IsUserLoggedIn = false;
            MessageBox.Show("You have been signed out.");
            this.Close();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete your account?", "Delete Account", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string inputPassword = Microsoft.VisualBasic.Interaction.InputBox("Please enter your password to confirm account deletion:", "Confirm Account Deletion", "", -1, -1);
                if (string.IsNullOrEmpty(inputPassword))
                {
                    return;
                }
                else if (!User.VerifyPassword(inputPassword, LoggedInUser.Current.Password))
                {
                    MessageBox.Show("Incorrect password. Account deletion cancelled.");
                    LoggedInUser.Logout();
                    this.Close();
                }
                else
                {
                    UserDB.DeleteUser(LoggedInUser.Current.Username);
                    LoggedInUser.Logout();
                    MessageBox.Show("Your account has been deleted.");
                    this.Close();
                }
            }
        }

        private void LoadComments()
        {
            pnlComments.Controls.Clear();

            var allGames = GameStore.Data.GameDBFactory.CreateUniversalGameDB("../../Data/Games.txt").GetAllGames();
            string[] game = null;
            foreach (var g in allGames)
            {
                game.Append(g.ToString());
            }

            string[] games = System.IO.File.ReadAllText("../../Data/Games.txt").Split('\n');
            string timeStamp = null;

            // Normalize user input for comparison
            string selectedTitle = cboTitle.Text.Trim();
            string selectedDeveloper = cboDeveloper.Text.Trim();
            string selectedPublisher = cboPublisher.Text.Trim();
            string selectedGenre = cboGenre.Text.Trim();
            string selectedPlatform = cboPlatform.Text.Trim();
            string selectedRegion = cboRegion.Text.Trim();
            string selectedPriceStr = cboPrice.Text.Replace("$", "").Trim();
            decimal selectedPrice;
            if (!decimal.TryParse(selectedPriceStr, out selectedPrice))
            {
                MessageBox.Show("Invalid price format.", "Error");
                return;
            }

            // Find the matching game entry
            foreach (string gameLine in games)
            {
                if (string.IsNullOrWhiteSpace(gameLine))
                    continue;

                string[] parts = gameLine.Split('|');
                if (parts.Length < 8)
                    continue;

                string title = parts[1].Split(':')[1].Trim();
                string developer = parts[2].Split(':')[1].Trim();
                string publisher = parts[3].Split(':')[1].Trim();
                string genre = parts[4].Split(':')[1].Trim();
                string platform = parts[5].Split(':')[1].Trim();
                string region = parts[6].Split(':')[1].Trim();
                string priceStr = parts[7].Split(':')[1].Replace("$", "").Trim();
                decimal price;
                if (!decimal.TryParse(priceStr, out price))
                    continue;

                if (string.Equals(title, selectedTitle, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(developer, selectedDeveloper, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(publisher, selectedPublisher, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(genre, selectedGenre, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(platform, selectedPlatform, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(region, selectedRegion, StringComparison.OrdinalIgnoreCase) &&
                    price == selectedPrice)
                {
                    timeStamp = parts[0];
                    break;
                }
            }

            if (timeStamp == null)
            {
                MessageBox.Show("Could not find the selected game. Please check your selections.", "Error");
                return;
            }

            // Construct the selected Game object
            IGame selectedGame;
            switch (cboRegion.Text.Trim())
            {
                case "Europe":
                    selectedGame = new GameStore.Regions.Europe(timeStamp, selectedTitle, selectedDeveloper, selectedPublisher, selectedGenre, selectedPlatform, selectedRegion, selectedPrice);
                    break;
                case "North America":
                    selectedGame = new GameStore.Regions.NorthAmerica(timeStamp, selectedTitle, selectedDeveloper, selectedPublisher, selectedGenre, selectedPlatform, selectedRegion, selectedPrice);
                    break;
                case "Japan":
                    selectedGame = new GameStore.Regions.Japan(timeStamp, selectedTitle, selectedDeveloper, selectedPublisher, selectedGenre, selectedPlatform, selectedRegion, selectedPrice);
                    break;
                case "Korea":
                    selectedGame = new GameStore.Regions.Korea(timeStamp, selectedTitle, selectedDeveloper, selectedPublisher, selectedGenre, selectedPlatform, selectedRegion, selectedPrice);
                    break;
                case "Asia":
                    selectedGame = new GameStore.Regions.Asia(timeStamp, selectedTitle, selectedDeveloper, selectedPublisher, selectedGenre, selectedPlatform, selectedRegion, selectedPrice);
                    break;
                default:
                    MessageBox.Show("Invalid region selection.", "Error");
                    return;
            }

            var selectedGameString = selectedGame.ToString();

            // Get comments for the selected game
            var comments = CommentsDB.GetAllComments()
                .Where(c => CommentsDB.AreGamesEqual(c.Game, selectedGame))
                .ToList();

            int y = 10;
            int boxWidth = (int)(pnlComments.Width * 0.6); // 60% of panel width

            foreach (var comment in comments.OrderBy(c => c.DatePosted))
            {
                string displayText = $"{comment.DatePosted:MM-dd-yyyy HH:mm} {comment.Username}:\n{comment.Text}";

                Label lbl = new Label();
                lbl.Text = displayText;
                lbl.AutoSize = false;
                lbl.Width = boxWidth;
                lbl.MaximumSize = new Size(boxWidth, 0);
                lbl.TextAlign = ContentAlignment.TopLeft;
                lbl.Padding = new Padding(8);
                lbl.Font = new Font("Segoe UI", 8);

                bool isCurrentUser = LoggedInUser.Current != null && comment.Username != null &&
                                     comment.Username == LoggedInUser.Current.Username;

                lbl.BackColor = isCurrentUser ? Color.LightBlue : Color.LightGray;

                // Calculate height for wrapped text
                lbl.Height = TextRenderer.MeasureText(lbl.Text, lbl.Font, new Size(lbl.Width, int.MaxValue), TextFormatFlags.WordBreak).Height + 16;

                if (isCurrentUser)
                {
                    // Align all the way to the right
                    lbl.Left = pnlComments.Width - lbl.Width - 20;
                    lbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                }
                else
                {
                    // Align all the way to the left
                    lbl.Left = 10;
                    lbl.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                }

                lbl.Top = y;
                pnlComments.Controls.Add(lbl);
                y += lbl.Height + 10;
            }

            // Scroll to the bottom after all comments are added
            if (pnlComments.VerticalScroll.Visible)
            {
                pnlComments.VerticalScroll.Value = pnlComments.VerticalScroll.Maximum;
                pnlComments.PerformLayout();
            }
        }

        private void btnComment_Click(object sender, EventArgs e)
        {
            string commentText = txtComment.Text.Trim();
            if (string.IsNullOrEmpty(commentText))
            {
                MessageBox.Show("Please enter a comment.");
                return;
            }

            // Construct the selected Game object (reuse your logic from LoadComments)
            string[] games = System.IO.File.ReadAllText("../../Data/Games.txt").Split('\n');
            string timeStamp = null;

            string selectedTitle = cboTitle.Text.Trim();
            string selectedDeveloper = cboDeveloper.Text.Trim();
            string selectedPublisher = cboPublisher.Text.Trim();
            string selectedGenre = cboGenre.Text.Trim();
            string selectedPlatform = cboPlatform.Text.Trim();
            string selectedRegion = cboRegion.Text.Trim();
            string selectedPriceStr = cboPrice.Text.Replace("$", "").Trim();
            decimal selectedPrice;
            if (!decimal.TryParse(selectedPriceStr, out selectedPrice))
            {
                MessageBox.Show("Invalid price format.", "Error");
                return;
            }

            foreach (string gameLine in games)
            {
                if (string.IsNullOrWhiteSpace(gameLine))
                    continue;

                string[] parts = gameLine.Split('|');
                if (parts.Length < 8)
                    continue;

                string title = parts[1].Split(':')[1].Trim();
                string developer = parts[2].Split(':')[1].Trim();
                string publisher = parts[3].Split(':')[1].Trim();
                string genre = parts[4].Split(':')[1].Trim();
                string platform = parts[5].Split(':')[1].Trim();
                string region = parts[6].Split(':')[1].Trim();
                string priceStr = parts[7].Split(':')[1].Replace("$", "").Trim();
                decimal price;
                if (!decimal.TryParse(priceStr, out price))
                    continue;

                if (string.Equals(title, selectedTitle, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(developer, selectedDeveloper, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(publisher, selectedPublisher, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(genre, selectedGenre, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(platform, selectedPlatform, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(region, selectedRegion, StringComparison.OrdinalIgnoreCase) &&
                    price == selectedPrice)
                {
                    timeStamp = parts[0].Trim();
                    break;
                }
            }

            IGame selectedGame;
            switch (cboRegion.Text.Trim())
            {
                case "Europe":
                    selectedGame = new GameStore.Regions.Europe(timeStamp, selectedTitle, selectedDeveloper, selectedPublisher, selectedGenre, selectedPlatform, selectedRegion, selectedPrice);
                    break;
                case "North America":
                    selectedGame = new GameStore.Regions.NorthAmerica(timeStamp, selectedTitle, selectedDeveloper, selectedPublisher, selectedGenre, selectedPlatform, selectedRegion, selectedPrice);
                    break;
                case "Japan":
                    selectedGame = new GameStore.Regions.Japan(timeStamp, selectedTitle, selectedDeveloper, selectedPublisher, selectedGenre, selectedPlatform, selectedRegion, selectedPrice);
                    break;
                case "Korea":
                    selectedGame = new GameStore.Regions.Korea(timeStamp, selectedTitle, selectedDeveloper, selectedPublisher, selectedGenre, selectedPlatform, selectedRegion, selectedPrice);
                    break;
                case "Asia":
                    selectedGame = new GameStore.Regions.Asia(timeStamp, selectedTitle, selectedDeveloper, selectedPublisher, selectedGenre, selectedPlatform, selectedRegion, selectedPrice);
                    break;
                default:
                    MessageBox.Show("Invalid region selection.", "Error");
                    return;
            }

            var selectedGameString = selectedGame.ToString();

            var comments = CommentsDB.GetAllComments()
                .Where(c => CommentsDB.AreGamesEqual(c.Game, selectedGame))
                .ToList();

            // Create and add the comment
            var comment = new Comment(
                LoggedInUser.Current.Username,
                selectedGame,
                commentText,
                DateTime.Now
            );

            CommentsDB.AddComment(comment);

            // Refresh comments and clear input
            LoadComments();
            txtComment.Text = "";
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
                    string developer = parts[2].Split(':')[1];

                    if (!cboDeveloper.Items.Contains(developer))
                    {
                        cboDeveloper.Items.Add(developer);
                    }
                }
            }
            if (cboDeveloper.Items.Count > 0)
                cboDeveloper.SelectedIndex = 0;

            // Load comments
            LoadComments();
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
                    string item = parts[3].Split(':')[1];

                    if (!cboPublisher.Items.Contains(item))
                    {
                        cboPublisher.Items.Add(item);
                    }
                }
            }
            if (cboPublisher.Items.Count > 0)
                cboPublisher.SelectedIndex = 0;

            // Load comments
            LoadComments();
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
                    string item = parts[4].Split(':')[1];

                    if (!cboGenre.Items.Contains(item))
                    {
                        cboGenre.Items.Add(item);
                    }
                }
            }
            if (cboGenre.Items.Count > 0)
                cboGenre.SelectedIndex = 0;

            // Load comments
            LoadComments();
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
                    string item = parts[5].Split(':')[1];

                    if (!cboPlatform.Items.Contains(item))
                    {
                        cboPlatform.Items.Add(item);
                    }
                }
            }
            if (cboPlatform.Items.Count > 0)
                cboPlatform.SelectedIndex = 0;

            // Load comments
            LoadComments();
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
                    string item = parts[6].Split(':')[1];

                    if (!cboRegion.Items.Contains(item))
                    {
                        cboRegion.Items.Add(item);
                    }
                }
            }
            if (cboRegion.Items.Count > 0)
                cboRegion.SelectedIndex = 0;

            // Load comments
            LoadComments();
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
                    string item = parts[7].Split(':')[1];

                    if (!cboPrice.Items.Contains(item))
                    {
                        cboPrice.Items.Add(item);
                    }
                }
            }
            if (cboPrice.Items.Count > 0)
                cboPrice.SelectedIndex = 0;

            // Load comments
            LoadComments();
        }
    }
}
