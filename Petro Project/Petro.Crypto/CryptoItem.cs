using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Petro.Crypto
{
    [Serializable]
    public class CryptoItem : IPetroItem
    {
        private static readonly BinaryFormatter binFormatter = new BinaryFormatter();

        public string ID
        {
            get;
            private set;
        }

        public byte[] Data
        {
            get;
            private set;
        }

        public CryptoItem(string id, byte[] data)
        {
            ID = id;
            Data = data;
        }
        public CryptoItem(string id, object dataObj)
        {
            ID = id;
            Encrypt(dataObj);
        }

        public T Decrypt<T>()
        {
            using (var mStream = new MemoryStream(Data))
                return (T)binFormatter.Deserialize(mStream);
        }
        public void Encrypt<T>(T dataObject)
        {
            using (var mStream = new MemoryStream())
            {
                binFormatter.Serialize(mStream, dataObject);
                Data = mStream.ToArray();
            }
        }
    }
}
