using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    public interface IGame : IComparable<IGame>
    {
        string TimeStamp { get; set; }
        string Title { get; set; }
        string Developer { get; set; }
        string Publisher { get; set; }
        string Genre { get; set; }
        string Platform { get; set; }
        string Region { get; set; }
        decimal Price { get; set; }

        string ToString();
    }
}
