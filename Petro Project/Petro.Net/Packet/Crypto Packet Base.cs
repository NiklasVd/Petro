using Caseomatic.Net;
using Petro.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petro.Net
{
    [Serializable]
    public class CryptoPacket : IPacket
    {
        protected readonly CryptoContainer container;

        public CommunicationID SenderCommunicationID
        {
            get
            {
                return Get<CommunicationID>("CommunicationID");
            }
        }

        public CryptoPacket(Enum type)
        {
            container.Add(new CryptoItem("Type", type));
        }

        public T Get<T>(string itemId)
        {
            return container[itemId].Decrypt<T>();
        }

        internal void Sign(CommunicationID communicationId)
        {
            container.Add(new CryptoItem("CommunicationID", communicationId));
        }
    }

    [Serializable]
    public class CryptoClientPacket : CryptoPacket, IClientPacket
    {
        public CryptoClientPacketType Type
        {
            get
            {
                return Get<CryptoClientPacketType>("Type");
            }
        }

        public CryptoClientPacket(CryptoClientPacketType type) : base(type)
        {
        }
    }
    public class CryptoServerPacket : CryptoPacket, IServerPacket
    {
        public CryptoServerPacketType Type
        {
            get
            {
                return Get<CryptoServerPacketType>("Type");
            }
        }

        public CryptoServerPacket(CryptoServerPacketType type) : base(type)
        {
        }
    }
}
