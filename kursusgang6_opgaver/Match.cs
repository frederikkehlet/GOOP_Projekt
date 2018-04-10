using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursusgang6_opgaver
{
    class Match 
    {
        private Random rnd = new Random(DateTime.Now.Millisecond);
        private int sets;
        private string matchType;

        public TennisPlayer Player1 { get; }
        public TennisPlayer Player2 { get; }
        public Referee Ref { get; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }

        public string Single
        {
            get { return matchType; }
            set
            {
                if (Player1.Gender == sex.male && Player2.Gender == sex.male)
                    matchType = "Men's Single";
                else if (Player1.Gender == sex.female && Player2.Gender == sex.female)
                    matchType = "Women's Single";
                else
                    matchType = null;
            }
        }

        public int Sets
        {
            get { return sets; }
            set
            {
                if (Single == "Men's Single") sets = 5;
                else if (Single == "Women's Single") sets = 3;
                else Single = null;
            }
        }

        public Match(TennisPlayer player1, TennisPlayer player2, Referee Ref)
        {
            if (player1.Gender != player2.Gender)
            {
                throw new GendersOfPlayersInMatchException("Genders do not match");
            }
            else
            {
                Player1 = player1;
                Player2 = player2;
                Single = matchType;
                Sets = sets;
                this.Ref = Ref;
                Player1Score = 0;
                Player2Score = 0;
            }         
        }

        public override string ToString()
        {
            if (Single == null) return null;
            else
            {
                string player1Name = String.Format("{0} {1} {2}", Player1.FirstName,
                    Player1.MiddleName, Player1.LastName);
                string player2Name = String.Format("{0} {1} {2}", Player2.FirstName,
                    Player2.MiddleName, Player2.LastName);

                return String.Format("Match: {0}\nSets: {1}\n{2} vs {3}\nReferee: {4}",
                    Single, Sets, player1Name, player2Name, (Ref.FirstName + " " + Ref.LastName));
            }
        }

        // Simulates a match based on gender, displays match result and returns a winner
        public TennisPlayer SimulateMatch()
        {
            Console.WriteLine(Player1.FirstName + " " + Player1.LastName +
                " vs " + Player2.FirstName + " " + Player2.LastName);

            int player1Wins = 0, player2Wins = 0;
            int[,] menMatch = new int[5, 2];
            int[,] womenMatch = new int[3, 2];
            int setcounter = 0;

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
                if (multiArray[i, 0] == 00) break;
                else Console.Write(multiArray[i, 0] + " - " + multiArray[i, 1]);
                Console.WriteLine();
            }
        }

        // method for simulating the result of one set
        private int[] SimulateSet()
        {
            int[] point = new int[2];

            while ((point[0] < 6) && (point[1] < 6))
            {
                int serve = rnd.Next(1, 3);

                if (serve == 1) point[0]++;
                else point[1]++;
            }
            return point;
        }
    }
}
