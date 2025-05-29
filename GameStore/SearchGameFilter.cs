using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    /// <summary>
    /// Checks if a game matches the search term.
    /// </summary>
    public class SearchGameFilter : IFilter<IGame>
    {
        private readonly string _searchTerm;

        public SearchGameFilter(string searchTerm)
        {
            _searchTerm = searchTerm?.ToLowerInvariant() ?? "";
        }

        public bool IsMatch(IGame game)
        {
            if (string.IsNullOrWhiteSpace(_searchTerm)) return true;
            return (game.Title?.ToLowerInvariant().Contains(_searchTerm) ?? false)
                || (game.Developer?.ToLowerInvariant().Contains(_searchTerm) ?? false)
                || (game.Publisher?.ToLowerInvariant().Contains(_searchTerm) ?? false)
                || (game.Genre?.ToLowerInvariant().Contains(_searchTerm) ?? false)
                || (game.Platform?.ToLowerInvariant().Contains(_searchTerm) ?? false)
                || (game.Region?.ToLowerInvariant().Contains(_searchTerm) ?? false);
        }
    }
}
