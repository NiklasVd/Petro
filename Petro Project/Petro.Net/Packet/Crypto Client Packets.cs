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
    public class HandshakeCryptoClientPacket : CryptoClientPacket, IPacketRequestable
    {
        public readonly Participant participant;
        public readonly CommunicationID communicationId;

        public HandshakeCryptoClientPacket(Participant participant, CommunicationID communicationId) : base(CryptoClientPacketType.Handshake)
        {
            this.participant = participant;
            this.communicationId = communicationId;
        }
    }

    [Serializable]
    public class DisconnectCryptoClientPacket : CryptoClientPacket
    {
        public DisconnectCryptoClientPacket() : base(CryptoClientPacketType.Disconnect)
        {
        }
    }

    [Serializable]
    public class RequestCryptoClientPacket : CryptoClientPacket, IPacketRequestable
    {
        public RequestCryptoClientPacket() : base(CryptoClientPacketType.Request)
        {
        }
    }
}
