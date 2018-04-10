using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursusgang6_opgaver
{
    public class PlayerCountUnevenException : Exception
    {
        public PlayerCountUnevenException(string message): base(message) { }
    }
}
