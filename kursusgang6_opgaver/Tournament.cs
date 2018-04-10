﻿using System;
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
        public int NumOfMatches { get; }
        public List<TennisPlayer> PlayersInTournament { get; set; }
        Gamemaster Gamemaster { get; }
        Referee Ref { get; }
        public int Matchcount { get; set; }

        private int InitialMatches(int numOfPlayers)
        {
            // returns half of the number of players, i.e. if there are 64 initial players, 32 matches need to be played
            if (numOfPlayers % 2 != 0)
            {
                return 0;
            }
            return numOfPlayers / 2;
        }

        public Tournament(string name, int year, string fromDate, string toDate, int numOfPlayers, List<TennisPlayer> playersInTournament, Gamemaster gamemaster)
        {
            Name = name;
            Year = year;
            FromDate = DateTime.ParseExact(fromDate, "yyyy-MM-dd", null);
            ToDate = DateTime.ParseExact(toDate, "yyyy-MM-dd", null);
            NumOfPlayers = numOfPlayers;
            NumOfMatches = InitialMatches(NumOfPlayers);
            if (NumOfMatches == 0) throw new PlayerCountUnevenException("Player count uneven");
            PlayersInTournament = playersInTournament;
            Gamemaster = gamemaster;
        }


        public override string ToString()
        {
            return String.Format("Name: {0}\nFrom: {1} to {2}\nNumber of players: {3}" +
                "\nNumber of initial matches: {4}\n\nGamemaster: \n{5}",
                Name, FromDate.ToShortDateString(), ToDate.ToShortDateString(), NumOfPlayers, NumOfMatches, Gamemaster);
        }

        public void SimulateTournament(List<TennisPlayer> playersInTournament)
        {
            if (playersInTournament.Count == 1)
            {
                Console.WriteLine("The winner is " + playersInTournament[0]);
            }
            else
            {
                List<TennisPlayer> winners = new List<TennisPlayer>();
                int i = 0;
                while (winners.Count != playersInTournament.Count / 2)
                {
                    Match match = new Match(playersInTournament[i], playersInTournament[i + 1], Ref);
                    var winner = match.SimulateMatch();
                    if (winner == playersInTournament[i])
                    {
                        winners.Add(playersInTournament[i]);
                    }
                    else
                    {
                        winners.Add(playersInTournament[i + 1]);
                    }
                    i = i + 2;
                    Matchcount++;
                }
                SimulateTournament(winners);
            }
        }

        public void AddPlayerToTournament(TennisPlayer player)
        {
            PlayersInTournament.Add(player);
        }

        public void RemovePlayerFromTournament(TennisPlayer player)
        {
            PlayersInTournament.Remove(player);
        }
    }
}
