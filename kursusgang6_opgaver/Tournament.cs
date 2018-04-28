/*
  The Tournament class is where the tournament simulation is run. The class has the following properties: a name, a year, a start and end date, 
  the number of players and initial matches, a list of players and referees, and finally the game master. In addition, there are two instance variables, roundcounter and matchcounter, 
  which are used to keep track of the number of rounds and matches in the tournament. Their initial value are set to 1.
   
  The class has the following methods: InitialMatches(), SetGameMaster(), ToString(), SimulateTournament(), ListPlayersByFirstName(), ListPlayersByLastName(), and two overloaded methods that can add and remove 
  players and referees from the tournament. The InitialMatches() method simply calculates how many initial matches are to be played, by taking the number of players and returning half of that number. The method also
  checks if the number of players is even, and if it's not, it will throw a custom PlayerCountException. 
  The SetGameMaster() method picks a random referee from the referee list, and maps the properties to a new Gamemaster object.
  
  SimulateTournament() is a recursive void method, that executes a round every time the method is called. The method calls a SimulateMatch() method in a while loop, and removes the loser of the match from the 
  player list. It will do so, untill all losers of the round have been removed. The list is now halved, and the method then calls itself. 
  It will call itself recursively untill there's only one player left in the list, which is the winner.

  The Tournament class has a constructor that takes formal parameters that correspond to the properties. The NumOfPlayers,NumOfMatches are read-only. 
  The number of players are set by the length of the player list, and then the number of matches are set by calling the InitialMatches() method with the NumOfPlayers property as the actual parameter.
*/
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

        int roundCounter = 1;

        // properties
        public string Name { get; set; }
        public int Year { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int NumOfPlayers { get; }
        public int NumOfMatches { get; }
        public List<TennisPlayer> PlayersInTournament { get; set; }
        public List<Referee> RefereesInTournament { get; set; }
        public Gamemaster Gamemaster { get; set; }

        // constructor
        public Tournament(string name, int year, string fromDate, string toDate, List<TennisPlayer> playersInTournament, List<Referee> refereesInTournament)
        {
            Name = name;
            Year = year;
            FromDate = DateTime.ParseExact(fromDate, "yyyy-MM-dd", null);
            ToDate = DateTime.ParseExact(toDate, "yyyy-MM-dd", null);

            if (FromDate > ToDate) throw new TournamentDatesException("Dates are incorrect");

            NumOfPlayers = playersInTournament.Count;
            NumOfMatches = InitialMatches(NumOfPlayers);
            PlayersInTournament = playersInTournament;
            RefereesInTournament = refereesInTournament;
            Gamemaster = SetGamemaster();
        }

        private int InitialMatches(int numOfPlayers)
        {
            // if the log base 2 of the number of players is not a whole number, the input is invalid
            if (Math.Log(numOfPlayers, 2) % 1 != 0) throw new PlayerCountException("Invalid number of players");
            
            // returns half of the number of players, i.e. if there are 64 initial players, 32 initial matches need to be played
            if (numOfPlayers % 2 != 0) throw new PlayerCountException("Player count uneven");
            else return numOfPlayers / 2;
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

            // return game master
            Gamemaster gamemaster = new Gamemaster(firstName, middleName, lastName, dateOfBirth, gender, nationality, licenseAquired, licenseRenewed);
            return gamemaster;
        }

        public void SimulateTournament()
        {
            int matchCounter = 1;
            int PlayersInRound = PlayersInTournament.Count;

            if (PlayersInTournament.Count == 1) // base case is one player left, i.e. the winner
            {
                Console.WriteLine("The winner is \n" + PlayersInTournament[0]);
            }
            else
            {
                Console.WriteLine("-------------------- ROUND " + roundCounter + " --------------------");

                int currentPlayer = 0;

                while (PlayersInTournament.Count != PlayersInRound / 2)
                {
                    if (roundCounter == Math.Log(NumOfPlayers, 2)) Console.WriteLine("FINAL");
                    else Console.WriteLine("Round: " + roundCounter + " Match: " + matchCounter);

                    Match match = new Match(PlayersInTournament[currentPlayer], PlayersInTournament[currentPlayer + 1], RefereesInTournament[rnd.Next(1, RefereesInTournament.Count)]);

                    Console.WriteLine(match.ToString());

                    TennisPlayer winner = match.SimulateMatch();

                    // remove the loser from the list
                    if (winner != PlayersInTournament[currentPlayer])
                        RemoveFromTournament(PlayersInTournament[currentPlayer]);
                    else
                        RemoveFromTournament(PlayersInTournament[currentPlayer + 1]);

                    currentPlayer++;
                    matchCounter++;
                }
                Console.WriteLine("---------------- END OF ROUND " + roundCounter + " ----------------- \n");
                roundCounter++;

                SimulateTournament(); // recursive call
            }
        }

        public void ListPlayersByFirstName()
        {
            List<TennisPlayer> OrderedList = PlayersInTournament.OrderBy(p => p.FirstName).ToList();

            int playersListed = 0;
            foreach (var player in OrderedList)
            {
                Console.WriteLine(player.ToString());
                playersListed++;
            }
            Console.WriteLine("Players listed: " + playersListed);
        }

        public void ListPlayersByLastName()
        {
            List<TennisPlayer> OrderedList = PlayersInTournament.OrderBy(p => p.LastName).ToList();

            int playersListed = 0;
            foreach (var player in OrderedList)
            {
                Console.WriteLine(player.ToString());
                playersListed++;
            }
            Console.WriteLine("Players listed: " + playersListed);
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

        public override string ToString()
        {
            return String.Format("Name: {0}\nFrom: {1} to {2}\nNumber of players: {3}" +
                "\nNumber of initial matches: {4}\n\nGamemaster: \n{5}",
                Name, FromDate.ToShortDateString(), ToDate.ToShortDateString(), NumOfPlayers, NumOfMatches, Gamemaster);
        }
    }
}
