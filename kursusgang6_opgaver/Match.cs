using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tennis_tournament
{
    class Match
    {
        Random rnd = new Random(DateTime.Now.Millisecond);
        private int sets;
        private int player1Wins = 0, player2Wins = 0;

        public TennisPlayer Player1 { get; }
        public TennisPlayer Player2 { get; }
        public Referee Ref { get; }

        // The Sets property is determined by equivalent gender
        public int Sets
        {
            get { return sets; }
            set
            {
                if (Player1.Gender == sex.male && Player2.Gender == sex.male)
                    sets = 5;
                else if (Player1.Gender == sex.female && Player2.Gender == sex.female)
                    sets = 3;
                else throw new GendersOfPlayersInMatchException("Genders do not match");
            }
        }

        // Constructor
        public Match(TennisPlayer player1, TennisPlayer player2, Referee Ref)
        {
            Player1 = player1;
            Player2 = player2;
            Sets = sets;
            this.Ref = Ref;
        }

        public override string ToString()
        {
            string player1Name = String.Format("{0} {1} {2}",
            Player1.FirstName, Player1.MiddleName, Player1.LastName);

            string player2Name = String.Format("{0} {1} {2}",
            Player2.FirstName, Player2.MiddleName, Player2.LastName);

            return String.Format("{0} vs {1}\nReferee: {2}",
            player1Name, player2Name, (Ref.FirstName + " " + Ref.LastName));
        }

        public TennisPlayer SimulateMatch()
        {
            int[,] menMatch = new int[5, 2];
            int[,] womenMatch = new int[3, 2];
            int setcounter = 0;

            // Men's single
            if (Sets == 5)
            {
                while (player1Wins < 3 && player2Wins < 3)
                {
                    int[] set = SimulateSet();

                    if (set[0] == 6) player1Wins++;
                    else player2Wins++;

                    menMatch[setcounter, 0] = set[0];
                    menMatch[setcounter, 1] = set[1];
                    setcounter++;
                }
                PrintMatchResults(menMatch);
            }
            // Women's single
            else if (Sets == 3)
            {
                while (player1Wins < 2 && player2Wins < 2)
                {
                    int[] set = SimulateSet();

                    if (set[0] == 6) player1Wins++;
                    else player2Wins++;

                    womenMatch[setcounter, 0] = set[0];
                    womenMatch[setcounter, 1] = set[1];
                    setcounter++;
                }
                PrintMatchResults(womenMatch);
            }
            SetsInGame(setcounter);
            return GetWinner(player1Wins, player2Wins);
        }

        // method for determining winner
        private TennisPlayer GetWinner(int player1Wins, int player2Wins)
        {
            if (player1Wins > player2Wins)
            {
                Console.WriteLine(Player1.FirstName + " " + Player1.LastName + " wins!\n");
                return Player1;
            }
            else
            {
                Console.WriteLine(Player2.FirstName + " " + Player2.LastName + " wins!\n");
                return Player2;
            }
        }

        // method for printing match results
        private void PrintMatchResults(int[,] multiArray)
        {
            for (int i = 0; i < multiArray.GetLength(0); i++)
            {
                if (multiArray[i, 0] == 0 && multiArray[i, 1] == 0) break;
                else Console.Write(multiArray[i, 0] + " - " + multiArray[i, 1] + "\n");
            }
        }

        // method for simulating the result of one set
        private int[] SimulateSet()
        {
            int[] point = new int[2];

            while ((point[0] < 6) && (point[1] < 6))
            {
                int serve = rnd.Next(1, 3); // used to determine who wins the point (1 and 2)

                if (serve == 1) point[0]++; // the point goes to player 1
                else point[1]++; // the point goes to player 2
            }
            return point;
        }

        // method for displaying number of sets played in the game
        private void SetsInGame(int sets)
        {
            Console.WriteLine("Sets in game: " + sets);
        }
    }
}
