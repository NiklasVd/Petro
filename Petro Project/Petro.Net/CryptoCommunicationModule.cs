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
        private static CryptoClientPacketType[] compressedClientPacketTypes = { CryptoClientPacketType.Request };
        private static CryptoServerPacketType[] compressedServerPacketTypes = { CryptoServerPacketType.AnswerRequest };

        public T ConvertReceive<T>(byte[] bytes) where T : IPacket
        {
            return PacketConverter.ToFlexPacket<T>(bytes);
        }

        public byte[] ConvertSend<T>(T packet) where T : IPacket
        {
            return PacketConverter.ToFlexBytes(packet, false, true);
        }
    }
}
