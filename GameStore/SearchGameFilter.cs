using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    /// <summary>
    /// SearchGameFilter is a filter class that checks if a game matches the search term.
    /// </summary>
    public class SearchGameFilter : IFilter<Game>
    {
        private readonly string _searchTerm;

        public SearchGameFilter(string searchTerm)
        {
            _searchTerm = searchTerm?.ToLower() ?? string.Empty;
        }

        public bool IsMatch(Game game)
        {
            if (string.IsNullOrEmpty(_searchTerm) || game == null)
                return false;

            return (game.Title?.ToLower().Contains(_searchTerm) ?? false)
                || (game.Developer?.ToLower().Contains(_searchTerm) ?? false)
                || (game.Publisher?.ToLower().Contains(_searchTerm) ?? false)
                || (game.Genre?.ToLower().Contains(_searchTerm) ?? false)
                || (game.Platform?.ToLower().Contains(_searchTerm) ?? false)
                || (game.Region?.ToLower().Contains(_searchTerm) ?? false)
                || (game.Price.ToString("0.##").Contains(_searchTerm));
        }
    }
}
