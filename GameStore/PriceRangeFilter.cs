using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    /// <summary>
    /// Implements IFilter interface to filter games based on their price range.
    /// </summary>
    public class PriceRangeFilter : IFilter<IGame>
    {
        private readonly decimal? min;
        private readonly decimal? max;

        public PriceRangeFilter(string range)
        {
            switch (range)
            {
                case "Free":
                    min = 0m;
                    max = 0m;
                    break;
                case "$1-$19":
                    min = 1m;
                    max = 19m;
                    break;
                case "$20-$49":
                    min = 20m;
                    max = 49m;
                    break;
                case "$50-$99":
                    min = 50m;
                    max = 99m;
                    break;
                case "$100+":
                    min = 100m;
                    max = null;
                    break;
                default:
                    min = null;
                    max = null;
                    break;
            }
        }

        public bool IsMatch(IGame game)
        {
            if (!min.HasValue && !max.HasValue) return true;
            if (min.HasValue && game.Price < min.Value) return false;
            if (max.HasValue && game.Price > max.Value) return false;
            return true;
        }
    }
}
