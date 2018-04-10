﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace kursusgang6_opgaver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var Player1 = new TennisPlayer("Frederik", "Kehlet", "1994-09-28", "Dansk", sex.male);
                var Player2 = new TennisPlayer("Frederik", "Kvist", "Aarup", "1995-06-29", "Dansk", sex.male);
                var Player3 = new TennisPlayer("Andreas", "Hansen", "1996-07-10", "Norsk", sex.male);
                var Player4 = new TennisPlayer("Mike", "Pedersen", "1992-01-15", "Svensk", sex.male);
                var Player5 = new TennisPlayer("Peter", "Kehlet", "1966-09-21", "Tysk", sex.male);
                var Player6 = new TennisPlayer("Thomas", "Hansen", "1970-02-19", "Dansk", sex.male);
                var Player7 = new TennisPlayer("Jakob", "Hundahl", "1988-07-14", "Norsk", sex.male);
                var Player8 = new TennisPlayer("Patrick", "Øgaard", "Jensen", "1992-04-15", "Dansk", sex.male);

                Referee Ref = new Referee("Ricco", "Jacobsen", "1957-01-01", sex.male, "1994-03-11", "2017-10-01");

                TennisPlayer[] playersArray = { Player1, Player2, Player3,
                    Player4, Player5, Player6, Player7, Player8 };

                
                // Console.WriteLine(Player4.Age(Player4.DateOfBirth)); 
                var Match1 = new Match(Player2, Player1, Ref);
                var Match2 = new Match(Player3, Player4, Ref); 
                var Match3 = new Match(Player1, Player3, Ref);

                var winner = Match1.SimulateMatch(Player2, Player1);

                Tournament tournament1 = new Tournament(2017, "2017-06-22", "2017-06-27", 8);
                // tournament1.SimulateTournament(playersArray, playersArray.Length);
                
                Console.ReadLine();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //DateTime date = new DateTime(1994, 09, 28);
            //DateTime date1 = new DateTime(2016, 10, 24);
            // Console.WriteLine(String.Format("{0} {1}",date.DayOfWeek,date1.DayOfWeek));
            // DK 24-12-2001
            // US 12/24/2001
            // ISO 2001-12-24 
            /* var wife = new Person("Anna", null);
            var husband = new Person("Bent", wife);
            wife.Spouse = husband;
            Console.WriteLine(String.Format("{0}\n{1}",wife.ToString(),husband.ToString()));*/
            
           
        }
    }
}
