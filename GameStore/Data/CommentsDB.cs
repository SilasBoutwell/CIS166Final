using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public class CommentsDB
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

        // Get all comments for a specific game
        public static List<Comment> GetCommentsForGame(Game game)
        {
            // Use a value-based comparison for Game if needed
            return comments.Where(c => AreGamesEqual(c.Game, game)).ToList();
        }

        public static List<Comment> GetAllComments()
        {
            return new List<Comment>(comments);
        }

        // Helper method to compare games by value (not by reference)
        public static bool AreGamesEqual(Game g1, Game g2)
        {
            return g1 != null && g2 != null &&
                   string.Equals(g1.Title?.Trim(), g2.Title?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(g1.Developer?.Trim(), g2.Developer?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(g1.Publisher?.Trim(), g2.Publisher?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(g1.Genre?.Trim(), g2.Genre?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(g1.Platform?.Trim(), g2.Platform?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(g1.Region?.Trim(), g2.Region?.Trim(), StringComparison.OrdinalIgnoreCase) &&
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

                // Correct count for Join: (priceIndex - 2)
                string gameString = string.Join("|", parts, 2, priceIndex - 2) + "|" + parts[priceIndex];

                // The rest is the comment text (may contain '|')
                string text = string.Join("|", parts, priceIndex + 1, parts.Length - priceIndex - 1);

                Game game;
                try
                {
                    System.Diagnostics.Debug.WriteLine($"Parsing game string: '{gameString}'");
                    game = Game.Parse(gameString.Trim());
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Failed to parse game string: '{gameString}' - {ex.Message}");
                    continue;
                }
                comments.Add(new Comment(username, game, text, datePosted));

                System.Diagnostics.Debug.WriteLine($"Loaded {comments.Count} comments from file.");
            }
        }
    }
}
