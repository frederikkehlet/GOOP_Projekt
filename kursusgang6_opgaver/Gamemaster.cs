using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursusgang6_opgaver
{
    class Gamemaster : Referee
    {
        public Gamemaster(string firstName, string middleName, string lastName, string dateOfBirth, sex gender, string licenseAquired, string lincenseRenewed): 
            base(firstName, middleName, lastName, dateOfBirth, gender, licenseAquired, lincenseRenewed) {}
    }
}
