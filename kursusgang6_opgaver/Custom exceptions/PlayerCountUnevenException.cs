using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tennis_tournament
{
    public class PlayerCountUnevenException : Exception
    {
        public PlayerCountUnevenException(string message): base(message) { }
    }
}
