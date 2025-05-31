using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public static class CommentsDB
    {
        private static List<Comment> comments = new List<Comment>();
        private static readonly string CommentsFilePath = "../../Data/Comments.txt";

        static CommentsDB()
        {
            LoadCommentsFromFile();
        }

        // Add a comment to the database
        public static void AddComment(Comment comment)
        {
            comments.Add(comment);
            SaveCommentsToFile();
        }

        // Remove a comment from the database
        public static void DeleteCommentsForGame(IGame game)
        {
            comments = comments.Where(c => !AreGamesEqual(c.Game, game)).ToList();
            SaveCommentsToFile();
        }

        // Get all comments for a specific game
        //public static List<Comment> GetCommentsForGame(IGame game)
        //{
        //    return comments.Where(c => AreGamesEqual(c.Game, game)).ToList();
        //}

        public static List<Comment> GetAllComments()
        {
            LoadCommentsFromFile();
            return new List<Comment>(comments);
        }

        // Helper method to compare games by value (not by reference)
        public static bool AreGamesEqual(IGame g1, IGame g2)
        {
            return g1 != null && g2 != null &&
                   g1.Title == g2.Title &&
                   g1.Developer == g2.Developer &&
                   g1.Publisher == g2.Publisher &&
                   g1.Genre == g2.Genre &&
                   g1.Platform == g2.Platform &&
                   g1.Region == g2.Region &&
                   g1.Price == g2.Price;
        }

        private static void SaveCommentsToFile()
        {
            var lines = comments.Select(c => c.ToString()).ToArray();
            File.WriteAllLines(CommentsFilePath, lines);
        }

        private static void LoadCommentsFromFile()
        {
            comments.Clear();
            if (!File.Exists(CommentsFilePath))
                return;

            var lines = File.ReadAllLines(CommentsFilePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length < 4)
                    continue;

                DateTime datePosted;
                if (!DateTime.TryParse(parts[0], out datePosted))
                    continue;

                string username = parts[1];

                int priceIndex = -1;
                for (int i = 2; i < parts.Length; i++)
                {
                    if (parts[i].TrimStart().StartsWith("Price:", StringComparison.OrdinalIgnoreCase))
                    {
                        priceIndex = i;
                        break;
                    }
                }
                if (priceIndex == -1 || priceIndex + 1 >= parts.Length)
                    continue;

                string gameString = string.Join("|", parts, 2, priceIndex - 2) + "|" + parts[priceIndex];
                string text = string.Join("|", parts, priceIndex + 1, parts.Length - priceIndex - 1);

                // Parse gameString using region classes
                IGame game = ParseGame(gameString.Trim());
                if (game == null)
                    continue;

                comments.Add(new Comment(username, game, text, datePosted));
            }
        }

        // Helper for parsing a game string into a region class
        private static IGame ParseGame(string gameStr)
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

        private static string GetValue(string part)
        {
            var idx = part.IndexOf(':');
            if (idx == -1)
                return string.Empty;
            return part.Substring(idx + 1).Trim();
        }
    }
}
