using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    /// <summary>
    /// Interface that defines a mechanism for determining whether a specified item matches a given condition.
    /// </summary>
    /// <typeparam name="T">The type of the item to evaluate.</typeparam>
    public interface IFilter<T>
    {
        bool IsMatch(T item);
    }
}
