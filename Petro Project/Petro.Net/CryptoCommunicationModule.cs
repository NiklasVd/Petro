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
    public class CryptoCommunicationModule<TReceivePacket, TSendPacket>
        : ICommunicationModule<TReceivePacket, TSendPacket>
        where TReceivePacket : CryptoPacket where TSendPacket : CryptoPacket
    {
        private static readonly BinaryFormatter binFormatter = new BinaryFormatter();
        private static CryptoClientPacketType[] compressedClientPacketTypes = { CryptoClientPacketType.Request };
        private static CryptoServerPacketType[] compressedServerPacketTypes = { CryptoServerPacketType.AnswerRequest };

        public TReceivePacket ConvertReceive(byte[] bytes)
        {
            return PacketConverter.ToFlexPacket<TReceivePacket>(bytes);
        }

        public byte[] ConvertSend(TSendPacket packet)
        {
            return PacketConverter.ToFlexBytes(packet, false, true);
        }
    }
}
