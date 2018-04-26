using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tennis_tournament
{
    class Tournament
    {
        Random rnd = new Random(DateTime.Now.Millisecond);
        private int roundCounter = 1;
        private int matchCounter = 1;

        public string Name { get; set; }
        public int Year { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int NumOfPlayers { get; set; }
        public int NumOfMatches { get; }
        public List<TennisPlayer> PlayersInTournament { get; set; }
        Gamemaster Gamemaster { get; }
        public List<Referee> RefereesInTournament { get; }

        private int InitialMatches(int numOfPlayers)
        {
            // returns half of the number of players, i.e. if there are 64 initial players, 32 initial matches need to be played
            if (numOfPlayers % 2 != 0) throw new PlayerCountUnevenException("Player count uneven");
            else return numOfPlayers / 2;
        }

        public Tournament(string name, int year, string fromDate, string toDate,
            int numOfPlayers, List<TennisPlayer> playersInTournament, List<Referee> refereesInTournament)
        {
            Name = name;
            Year = year;
            FromDate = DateTime.ParseExact(fromDate, "yyyy-MM-dd", null);
            ToDate = DateTime.ParseExact(toDate, "yyyy-MM-dd", null);
            NumOfPlayers = numOfPlayers;
            NumOfMatches = InitialMatches(NumOfPlayers);
            PlayersInTournament = playersInTournament;
            RefereesInTournament = refereesInTournament;
            Gamemaster = SetGamemaster();
        }

        private Gamemaster SetGamemaster()
        {
            // pick a random referee and set to game master           
            Referee referee = RefereesInTournament[rnd.Next(1, RefereesInTournament.Count)];

            // Map the properties
            string firstName = referee.FirstName;
            string middleName = referee.MiddleName;
            string lastName = referee.LastName;
            string dateOfBirth = referee.DateOfBirth.ToString("yyyy-MM-dd");
            sex gender = referee.Gender;
            string nationality = referee.Nationality;
            string licenseAquired = referee.LicenseAquired.ToString("yyyy-MM-dd");
            string licenseRenewed = referee.LicenseRenewed.ToString("yyyy-MM-dd");

            Gamemaster gamemaster = new Gamemaster(firstName, middleName, lastName, dateOfBirth, gender, nationality, licenseAquired, licenseRenewed);
            return gamemaster;
        }

        public override string ToString()
        {
            return String.Format("Name: {0}\nFrom: {1} to {2}\nNumber of players: {3}" +
                "\nNumber of initial matches: {4}\n\nGamemaster: \n{5}",
                Name, FromDate.ToShortDateString(), ToDate.ToShortDateString(), NumOfPlayers, NumOfMatches, Gamemaster);
        }

        // Recursive method that simulates a tournament
        public void SimulateTournament()
        {
            int PlayersInRound = PlayersInTournament.Count;

            if (PlayersInTournament.Count == 1) // base case is one player left, i.e. the winner
            {
                Console.WriteLine("The winner is \n" + PlayersInTournament[0]);
                Console.WriteLine((matchCounter - 1) + " total matches played in tournament");
            }
            else
            {
                Console.WriteLine("-------------------- ROUND " + roundCounter + " --------------------");

                int currentPlayer = 0;

                while (PlayersInTournament.Count != PlayersInRound / 2)
                {
                    Console.WriteLine("Match " + matchCounter);
                    Match match = new Match(PlayersInTournament[currentPlayer], PlayersInTournament[currentPlayer + 1], RefereesInTournament[rnd.Next(1, RefereesInTournament.Count)]);
                    Console.WriteLine(match.ToString());

                    TennisPlayer winner = match.SimulateMatch();

                    System.Threading.Thread.Sleep(1000);
                    if (winner != PlayersInTournament[currentPlayer])
                    {
                        RemoveFromTournament(PlayersInTournament[currentPlayer]);
                    }
                    else
                    {
                        RemoveFromTournament(PlayersInTournament[currentPlayer + 1]);
                    }
                    currentPlayer++;
                    matchCounter++;
                }
                Console.WriteLine("---------------- END OF ROUND " + roundCounter + " ----------------- \n");
                roundCounter++;

                SimulateTournament(); // recursive call
            }
        }

        // overloaded methods to add and remove players/referees
        public void AddToTournament(TennisPlayer player)
        {
            PlayersInTournament.Add(player);
        }

        public void AddToTournament(Referee referee)
        {
            RefereesInTournament.Add(referee);
        }

        public void RemoveFromTournament(TennisPlayer player)
        {
            PlayersInTournament.Remove(player);
        }

        public void RemoveFromTournament(Referee referee)
        {
            RefereesInTournament.Remove(referee);
        }
    }
}
