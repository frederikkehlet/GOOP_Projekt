using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace tennis_tournament
{
    class ReadCSVFile
    {
        private List<TennisPlayer> players = new List<TennisPlayer>();
        private List<Referee> referees = new List<Referee>();
        public string FileName { get; set; }
        public string Delimiter { get; set; }

        public ReadCSVFile(string fileName, string delimiter = "|")
        {
            FileName = fileName;
            Delimiter = delimiter;
        }

        public List<TennisPlayer> GetListOfPlayers()
        {
            return players;
        }

        public List<TennisPlayer> GetListOfPlayers(int numOfPlayers)
        {
            List<TennisPlayer> specifiedListOfPlayers = new List<TennisPlayer>();
            for (int i = 0; i < numOfPlayers; i++)
            {
                specifiedListOfPlayers.Add(players[i]);
            }
            return specifiedListOfPlayers;
        }

        public void LoadPlayers(sex gender)
        {
            TextFieldParser par = new TextFieldParser(FileName);
            par.TextFieldType = FieldType.Delimited;
            par.SetDelimiters(Delimiter);

            while (!par.EndOfData)
            {
                string[] fields = par.ReadFields();
                string firstName = fields[1];
                string middleName = fields[2];
                string lastName = fields[3];
                string birthdate = fields[4];
                string nationality = fields[5];
                // create player object
                var player = new TennisPlayer(firstName, middleName, lastName, birthdate, nationality, gender);
                players.Add(player);
            }
        }

        public void LoadReferees(sex gender)
        {
            TextFieldParser par = new TextFieldParser(FileName);
            par.TextFieldType = FieldType.Delimited;
            par.SetDelimiters(Delimiter);

            while (!par.EndOfData)
            {
                string[] fields = par.ReadFields();
                string firstName = fields[1];
                string middleName = fields[2];
                string lastName = fields[3];
                string birthdate = fields[4];
                string nationality = fields[5];
                string licenseAquired = fields[7];
                string licenseRenewed = fields[8];

                var referee = new Referee(firstName, middleName, lastName, birthdate, 
                    gender, nationality, licenseAquired, licenseRenewed);
                referees.Add(referee);
            }
        }

        // list players by first name method
        public void SortByFirstName(List<TennisPlayer> players)
        {
            players.Sort();
        }
        // list player by last name method
        // needs functionality that picks a random referee and makes it the gamemaster

        public override string ToString()
        {
            string result = "";
            foreach (var player in players)
            {
                result += player + "\n";
            }
            return result;
        }
    }
}
