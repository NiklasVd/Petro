using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petro.Crypto
{
    [Serializable]
    public class CommunicationID
    {
        public readonly Guid globalId;
        public readonly Guid participantCreatorId;

        public CommunicationID(Guid globalId, Guid participantCreatorId)
        {
            this.globalId = globalId;
            this.participantCreatorId = participantCreatorId;
        }

        public static CommunicationID Generate(Participant generator)
        {
            return new CommunicationID(Guid.NewGuid(), generator.globalId);
        }
    }
}
