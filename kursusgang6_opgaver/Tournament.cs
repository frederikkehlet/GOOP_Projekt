using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursusgang6_opgaver
{
    class Tournament
    {
        public string Name { get { return "Wimbledon"; } } // you can't change the name of the tournament
        public int Year { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int NumOfPlayers { get; set; }
        public int NumOfMatches { get; }

        public Tournament(int year, string fromDate, string toDate, int numOfPlayers)
        {
            Year = year;
            FromDate = DateTime.ParseExact(fromDate, "yyyy-MM-dd", null);
            ToDate = DateTime.ParseExact(toDate, "yyyy-MM-dd", null);
            NumOfMatches = InitialMatches(numOfPlayers);
        }

        private int InitialMatches(int numOfPlayers)
        {
            // returns half of the number of players, i.e. if there are 64 inital players, 32 matches need to be played
            if (numOfPlayers % 2 != 0)
            {
                return 0;
            }
            return numOfPlayers / 2;
        }

        public override string ToString()
        {
            return String.Format("Name: {0}\nFrom: {1} to {2}\nNumber of players: {3}",
                Name,FromDate.ToShortDateString(),ToDate.ToShortDateString(),NumOfMatches);
        }

        public void SimulateTournament(int numOfPlayers)
        {
            int sumPlayer1 = 0, sumPlayer2 = 0;
            if (numOfPlayers % 2 == 0)
            {
                Random rnd = new Random();
                int p = 1; int i = 0;
                while (i < numOfPlayers / 2)
                {
                    Console.WriteLine("Player " + p + " vs Player " + (p + 1));
                    
                    int j = 0;
                    while (j < 3)
                    {
                        int[] Score = { rnd.Next(1, 7), rnd.Next(1, 7) }; // Array for the scores of one set
                        if (Score[0] != Score[1]) // no ties
                        {
                            sumPlayer1 += Score[0];
                            sumPlayer2 += Score[1];
                            Console.WriteLine(Score[0] + " - " + Score[1]);
                            j++;
                        }
                    }
                    i++;
                    Console.WriteLine("\n");
                }
            }
        }
    }
}
