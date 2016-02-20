using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petro
{
    [Serializable]
    public class Participant
    {
        public readonly string name;
        public readonly Guid globalId;

        public Participant(string name)
        {
            this.name = name;
            globalId = Guid.NewGuid();
        }
    }
}
