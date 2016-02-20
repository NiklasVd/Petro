using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petro
{
    public interface IPetroContainer<T>
    {
        void Add(T item);
        void Remove(string itemId);
        void Remove(T item);
    }
}
