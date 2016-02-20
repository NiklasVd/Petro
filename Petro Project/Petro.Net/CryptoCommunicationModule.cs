using Caseomatic.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Petro.Net
{
    public class CryptoCommunicationModule : ICommunicationModule
    {
        private static readonly BinaryFormatter binFormatter = new BinaryFormatter();

        public T ConvertReceive<T>(byte[] bytes) where T : IPacket
        {
            using (var mStream = new MemoryStream(bytes))
                return (T)binFormatter.Deserialize(mStream);
        }

        public byte[] ConvertSend<T>(T packet) where T : IPacket
        {
            using (var mStream = new MemoryStream())
            {
                binFormatter.Serialize(mStream, packet);
                return mStream.ToArray();
            }
        }
    }
}
