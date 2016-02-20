using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petro.Net
{
    [Serializable]
    public enum CryptoClientPacketType : byte
    {
        Handshake,
        Disconnect,
        Request
    }

    [Serializable]
    public enum CryptoServerPacketType : byte
    {
        AnswerHandshake,
        Abort,
        AnswerRequest
    }
}
