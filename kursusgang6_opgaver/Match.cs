using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursusgang6_opgaver
{
    class Match
    {
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
            Player1 = player1;
            Player2 = player2;
            Single = matchType;
            Sets = sets;
            this.Ref = Ref;
            Player1Score = 0;
            Player2Score = 0;
        }

        public override string ToString()
        {
            if (Single == null) return null;
            else
            {
                string player1Name = String.Format("{0} {1} {2}", Player1.FirstName, Player1.MiddleName, Player1.LastName);
                string player2Name = String.Format("{0} {1} {2}", Player2.FirstName, Player2.MiddleName, Player2.LastName);

                return String.Format("Match: {0}\nSets: {1}\n{2} vs {3}\nReferee: {4}",
                    Single, Sets, player1Name, player2Name, (Ref.FirstName + " " + Ref.LastName));
            }
        }

        // functionality for getting winner of game
        public string GetWinner(TennisPlayer player1, TennisPlayer player2, int player1Score, int player2Score)
        {
            if (player1Score > player2Score) return player1.FirstName + " " + player1.LastName;
            else return player2.FirstName + " " + player2.LastName;
        }

        public void SimulateMatch()
        {
            try
            {
                Random rnd = new Random();
                int player1Wins = 0;
                int player2Wins = 0;
                int[] set = new int[2];
                int[,] sets = new int[5, 2];
                int setcounter = 0;
                int setresult1 = 0, setresult2 = 0;

                set = SimulateSet();
                while ((player1Wins != 5 && player2Wins != 5))
                {
                    // spiller 1 vinder settet
                    if (set[0] == 6)
                    {
                        setresult1 = 6;
                        setresult2 = rnd.Next(1, 6);
                        player1Wins++;
                    }
                    else
                    {
                        setresult2 = 6;
                        setresult1 = rnd.Next(1, 6);
                        player2Wins++;
                    }
                    sets[setcounter, 0] = setresult1;
                    sets[setcounter, 1] = setresult2;
                    setcounter++;

                    set = SimulateSet();
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }   
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private int[] SimulateSet()
        {

            Random rnd = new Random();
            int[] points = new int[2];

            while ((points[0] < 6) && (points[1] < 6)) // while løkken kører indtil én af spillerne har fået 6 point
            {
                int serve = rnd.Next(1, 3);

                if (serve == 1) points[0]++; // player 1 vinder serven
                else points[1]++; // player 2 vinder serven
            }

            return points;
        }
    }
}
