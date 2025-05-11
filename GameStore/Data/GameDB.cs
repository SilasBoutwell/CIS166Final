using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public class GameDB
    {
        public GameDB() { }

        //Method to add a game to the list
        public void AddGame(Game game)
        {
            System.IO.File.WriteAllText("Games.txt", game.ToString());
        }

        //Method to remove a game from the list
        public void RemoveGame(Game game)
        {
            // Assuming we are removing the game by title
            var games = System.IO.File.ReadAllLines("Games.txt").ToList();
            games.RemoveAll(g => g.StartsWith(game.Title));
            System.IO.File.WriteAllLines("Games.txt", games);
        }
    }
}
