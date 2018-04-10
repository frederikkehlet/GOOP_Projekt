using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace kursusgang6_opgaver
{
    class ReadCSVFile
    {
        private List<TennisPlayer> players = new List<TennisPlayer>();
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
        
        public void LoadMalePlayers()
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
                var player = new TennisPlayer(firstName, middleName, lastName, birthdate, nationality, sex.male);
                players.Add(player);
            }
        }

        public void LoadFemalePlayers()
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
                var player = new TennisPlayer(firstName, middleName, lastName, birthdate, nationality, sex.female);
                players.Add(player);
            }
        }

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
