using System;
using System.Collections.Generic;
using System.IO;
using MonsterSlayerReborn.Gameplay;
using MonsterSlayerReborn.Repo;


namespace MonsterSlayerReborn.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            string playAgain = "n";
            int menuChoice;
            ServerRepo repo = new ServerRepo(File.ReadAllText("./connectionstring.txt"));

            Console.WriteLine("Welcome to Monster Slayer: Reborn!");

            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. View Past Games");
                Console.WriteLine("0. Exit Game");
                Console.Write("Please choose a menu option: ");
                while (!int.TryParse(Console.ReadLine(), out menuChoice) || menuChoice < 0 || menuChoice > 2)
                {
                    Console.Write("Please input a valid numerical menu choice: ");
                }

                switch (menuChoice)
                {
                    case 0:
                        // Exit game
                        break;
                    case 1:
                        // Play the game
                        do
                        {
                            game.InitializeGame();
                            game.Play();

                            repo.SaveGameInfo(game);

                            Console.Write("Do you want to play again? (y/n): ");
                            playAgain = Console.ReadLine().ToLower();
                        } while (playAgain.Equals("y"));
                        break;
                    case 2:
                        // View past games
                        Console.WriteLine("Here are the past games played:");
                        List<Game> gameList = repo.GetPastGames();

                        foreach (var g in gameList)
                        {
                            Console.WriteLine($"Player: {g.Player.Name} Class: {g.Player.playerClass} Difficulty: {g.difficulty} Rounds Completed: {g.roundsPlayed}");
                        }
                        break;
                }
            } while (menuChoice != 0);
        }
    }
}