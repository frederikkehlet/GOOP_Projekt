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
        public List<TennisPlayer> Players = new List<TennisPlayer>();
        public List<Referee> Referees = new List<Referee>();
        public string FilePath { get; set; }
        public string Delimiter { get; set; }

        public ReadCSVFile(string filePath, string delimiter = "|")
        {
            FilePath = filePath;
            Delimiter = delimiter;
        }

        public void LoadPlayers(sex gender, int playerCount)
        {
            int playersAdded = 0;
            TextFieldParser par = new TextFieldParser(FilePath);
            par.TextFieldType = FieldType.Delimited;
            par.SetDelimiters(Delimiter);

            while (!par.EndOfData && playersAdded < playerCount)
            {
                string[] fields = par.ReadFields();
                string firstName = fields[1];
                string middleName = fields[2];
                string lastName = fields[3];
                string birthdate = fields[4];
                string nationality = fields[5];
                // create player object
                var player = new TennisPlayer(firstName, middleName, lastName, birthdate, nationality, gender);
                Players.Add(player);
                playersAdded++;
            }
            par.Close();
        }

        public void LoadReferees(sex gender)
        {
            TextFieldParser par = new TextFieldParser(FilePath);
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
                Referees.Add(referee);
            }
            par.Close();
        }
    }
}
