﻿PlayPvE game = new PlayPvE();
string playAgain = "n";

// Do-while loop to play the game again or end execution
do
{
game.InitializeGame();
game.PlayGame();
Console.Write("Do you want to play again? (y/n): ");
playAgain = Console.ReadLine().ToLower();
} while(playAgain.Equals("y"));