﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Inherits from the Referee class, and thus also indirectly from Person class
 */ 
namespace tennis_tournament
{
    class Gamemaster : Referee
    {
        public Gamemaster(string firstName, string middleName, string lastName, string dateOfBirth, sex gender, string nationality, string licenseAquired, string lincenseRenewed): 
            base(firstName, middleName, lastName, dateOfBirth, gender, nationality, licenseAquired, lincenseRenewed) {}
    }
}
