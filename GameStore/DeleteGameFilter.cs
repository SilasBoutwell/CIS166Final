using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    /// <summary>
    /// Checks if a game matches the target game for deletion.
    /// </summary>
    public class DeleteGameFilter : IFilter<IGame>
    {
        private readonly IGame _target;

        public DeleteGameFilter(IGame target)
        {
            _target = target;
        }

        public bool IsMatch(IGame game)
        {
            return
                string.Equals(game.TimeStamp?.Trim(), _target.TimeStamp?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals(game.Title?.Trim(), _target.Title?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals(game.Developer?.Trim(), _target.Developer?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals(game.Publisher?.Trim(), _target.Publisher?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals(game.Genre?.Trim(), _target.Genre?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals(game.Platform?.Trim(), _target.Platform?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals(game.Region?.Trim(), _target.Region?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                game.Price == _target.Price;
        }
    }
}
