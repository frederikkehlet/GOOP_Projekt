﻿using System;
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
                char genderPlayer = char.Parse(Console.ReadLine());

                List<TennisPlayer> playersInTournament = new List<TennisPlayer>();
               
                // Load players
                if (genderPlayer == 'm')
                {
                    var Male = new ReadCSVFile(@"C:\Users\Frederik\source\repos\GOOP_Projekt2\kursusgang6_opgaver\Resources\MalePlayer.txt");
                    Male.LoadPlayers(sex.male, playerCount);
                    playersInTournament = Male.Players;
                }
                else if (genderPlayer == 'f')
                {
                    var Female = new ReadCSVFile(@"C:\Users\Frederik\source\repos\GOOP_Projekt2\kursusgang6_opgaver\Resources\FemalePlayer.txt");
                    Female.LoadPlayers(sex.female, playerCount);
                    playersInTournament = Female.Players;
                }
                else throw new GendersOfPlayersInMatchException("Gender format incorrect");

                Console.WriteLine("\nPlease enter the gender of referees (f/m): ");
                char genderRef = char.Parse(Console.ReadLine());

                List<Referee> refereesInTournament = new List<Referee>();

                // Load referees 
                if (genderRef == 'm')
                {
                    var Male = new ReadCSVFile(@"C:\Users\Frederik\source\repos\GOOP_Projekt2\kursusgang6_opgaver\Resources\MaleRefs.txt");
                    Male.LoadReferees(sex.male);
                    refereesInTournament = Male.Referees;
                }
                else if (genderRef == 'f')
                {
                    var Female = new ReadCSVFile(@"C:\Users\Frederik\source\repos\GOOP_Projekt2\kursusgang6_opgaver\Resources\FermaleRefs.txt");
                    Female.LoadReferees(sex.male);
                    refereesInTournament = Female.Referees;
                }
                else throw new GendersOfPlayersInMatchException("Gender format incorrect");

                Tournament tournament = new Tournament(name, year, fromDate, toDate, playersInTournament, refereesInTournament);
                
                Console.Clear();

                Console.WriteLine(tournament.ToString());
                // simulates tournament
                tournament.SimulateTournament();
            }
            catch (GendersOfPlayersInMatchException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (PlayerCountException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (TournamentDatesException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (StackOverflowException e)
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
