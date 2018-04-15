using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;

namespace tennis_tournament
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Tournament Simulator! Please enter the name of the tournament: ");
                string name = Console.ReadLine();

                Console.WriteLine("\nPlease enter the year of the tournament: ");
                int year = int.Parse(Console.ReadLine());

                Console.WriteLine("\nPlease enter the start date of the tournament (yyyy-MM-dd): ");
                string fromDate = Console.ReadLine();

                Console.WriteLine("\nPlease enter the end date of the tournament (yyyy-MM-dd): ");
                string toDate = Console.ReadLine();

                Console.WriteLine("\nPlease enter the number of players participating in the tournament");
                int playerCount = int.Parse(Console.ReadLine());

                Console.WriteLine("\nPlease enter the gender of players (f/m): ");
                char gender = char.Parse(Console.ReadLine());

                Gamemaster gamemaster = new Gamemaster("Kaj", "Kim", "Hansen", "1999-01-27", sex.male, "1999-01-01", "2009-01-01");

                var MalePlayers = new ReadCSVFile(@"..\Txt files\MalePlayer.txt");
                var FemalePlayers = new ReadCSVFile(@"..\Txt files\FemalePlayer.txt");
                MalePlayers.LoadPlayers(sex.male);
                FemalePlayers.LoadPlayers(sex.female);

                List<TennisPlayer> playersInTournament = new List<TennisPlayer>();

                if (gender == 'm') playersInTournament = MalePlayers.GetListOfPlayers(playerCount);
                else if (gender == 'f') playersInTournament = FemalePlayers.GetListOfPlayers(playerCount);
                else throw new GendersOfPlayersInMatchException("Gender format incorrect");

                Tournament tournament = new Tournament(name, year, toDate, fromDate, playersInTournament.Count, playersInTournament, gamemaster);

                Console.Clear();
                Console.WriteLine("Simulating...");
                System.Threading.Thread.Sleep(3000);

                Console.Clear();
                Console.WriteLine(tournament.ToString()); 

                tournament.SimulateTournament(playersInTournament); // simulates tournament

                Console.WriteLine(tournament.Matchcount + " total matches played in tournament");
            }
            catch (GendersOfPlayersInMatchException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (PlayerCountUnevenException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Press enter to restart or type 'exit' to exit");
                string input = Console.ReadLine();
                if (input == "exit") Environment.Exit(-1);
                else Main();
            }
        }
    }
}
