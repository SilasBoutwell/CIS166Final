using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    public class GameList
    {
        private List<Game> games;

        public GameList()
        {
            games = new List<Game>();
        }

        //Method to add a game to the list
        public void AddGame(Game game)
        {
            games.Add(game);
        }

        //Method to remove a game from the list
        public void RemoveGame(Game game)
        {
            games.Remove(game);
        }

        //Method to get all games in the list
        public List<Game> GetAllGames()
        {
            return games;
        }

        public List<Game> FilterGames(IGameFilter filter)
        {
            if (filter == null)
                return new List<Game>(games);

            return games.Where(game => filter.IsMatch(game)).ToList();
        }
    }
}
