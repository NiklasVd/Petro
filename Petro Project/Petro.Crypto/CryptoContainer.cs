using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petro.Crypto
{
    public class CryptoContainer : IPetroContainer<CryptoItem>
    {
        private readonly Dictionary<string, CryptoItem> items;
        public CryptoItem this[string itemId]
        {
            get { return items[itemId]; }
        }

        public void Add(CryptoItem item)
        {
            items.Add(item.ID, item);
        }

        public void Remove(CryptoItem item)
        {
            items.Remove(item.ID);
        }

        public void Remove(string itemId)
        {
            items.Remove(itemId);
        }
    }
}
