using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursusgang6_opgaver
{
    class Tournament 
    {
        public string Name { get; set; } 
        public int Year { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int NumOfPlayers { get; set; }
        public int NumOfMatches { get; set; }
        public Referee GameMaster { get; set; }

        private int InitialMatches(int numOfPlayers)
        {
            // returns half of the number of players, i.e. if there are 64 inital players, 32 matches need to be played
            if (numOfPlayers % 2 != 0) return 0;
            return numOfPlayers / 2;
        }

        public Tournament(int year, string fromDate, string toDate, int numOfPlayers)
        {
            Year = year;
            FromDate = DateTime.ParseExact(fromDate, "yyyy-MM-dd", null);
            ToDate = DateTime.ParseExact(toDate, "yyyy-MM-dd", null);
            NumOfPlayers = numOfPlayers;
            NumOfMatches = InitialMatches(NumOfPlayers);
        }

        public override string ToString()
        {
            return String.Format("Name: {0}\nFrom: {1} to {2}\nNumber of players: {3}",
                Name,FromDate.ToShortDateString(),ToDate.ToShortDateString(),NumOfPlayers);
        }

        public void SimulateTournament(TennisPlayer[] winners)
        {
            
        }

        private TennisPlayer Winner(TennisPlayer player)
        {
            return player;
        }

        private void ListPlayers(TennisPlayer[] playersArray)
        {
            foreach (var player in playersArray)
            {
                Console.WriteLine(player.FirstName + " " + player.LastName);
            }
        }
    }
}
