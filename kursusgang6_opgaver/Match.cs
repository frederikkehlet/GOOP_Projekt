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
                else sets = 2;
            }
        }

        public Match(TennisPlayer player1, TennisPlayer player2, Referee Ref)
        {
            Player1 = player1;
            Player2 = player2;
            Single = matchType;
            Sets = sets;
            this.Ref = Ref;
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
    }
}
