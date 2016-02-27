using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Petro.Crypto
{
    [Serializable]
    public class CryptoItem : IPetroItem
    {
        private static readonly BinaryFormatter binFormatter = new BinaryFormatter();

        private string id;
        public string ID
        {
            get { return id; }
            private set { id = value; }
        }

        private byte[] data;
        public byte[] Data
        {
            get { return data; }
            private set { data = value; }
        }

        public CryptoItem(string id)
        {
            this.id = id;
        }
        public CryptoItem(string id, object dataObj) : this(id)
        {
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
                data = mStream.ToArray();
            }
        }
    }
}
