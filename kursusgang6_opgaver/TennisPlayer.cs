using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Inherits from Person - the TennisPlayer class is identical 
 */
namespace tennis_tournament
{
    public class TennisPlayer : Person
    {
        public TennisPlayer(string firstName, string middleName, string lastName, string birthDate,
            string nationality, sex gender) : base(firstName,middleName,lastName,birthDate,nationality,gender) { }
    }
}
