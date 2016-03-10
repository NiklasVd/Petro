using Petro.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petro.Net
{
    [Serializable]
    public class AnswerHandshakeCryptoServerPacket : CryptoServerPacket 
    {
        public HandshakeStatus Status
        {
            get
            {
                return Get<HandshakeStatus>("Status");
            }
        }

        public AnswerHandshakeCryptoServerPacket(HandshakeStatus status)
            : base(CryptoServerPacketType.AnswerHandshake)
        {
            container.Add(new CryptoItem("Status", status));
        }

        public enum HandshakeStatus : byte
        {
            Success,
            Failure // Split into more detailed errors
        }
    }

    [Serializable]
    public class AbortConnectionCryptoServerPacket : CryptoServerPacket
    {
        public AbortReason Reason
        {
            get
            {
                return Get<AbortReason>("Reason");
            }
        }

        public AbortConnectionCryptoServerPacket(AbortReason reason) : base(CryptoServerPacketType.AbortConnection)
        {
            container.Add(new CryptoItem("Reason", reason));
        }

        public enum AbortReason : byte
        {
            Manual,
            Security,
            WrongCommunicationID,
            Unknown
        }
    }

    [Serializable]
    public class AnswerRequestCryptoServerPacket : CryptoServerPacket
    {
        public AnswerRequestCryptoServerPacket() : base(CryptoServerPacketType.AnswerRequest)
        {
        }
    }
}
