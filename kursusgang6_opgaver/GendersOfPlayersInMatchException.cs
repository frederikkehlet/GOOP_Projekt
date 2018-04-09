using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursusgang6_opgaver
{
    public class GendersOfPlayersInMatchException : Exception
    {
        public GendersOfPlayersInMatchException(string message) : base(message) { }
    }
}
