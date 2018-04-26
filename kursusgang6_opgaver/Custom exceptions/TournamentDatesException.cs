using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tennis_tournament
{
    class TournamentDatesException : Exception
    {
        public TournamentDatesException(string message) : base(message) { }
    }
}
