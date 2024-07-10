string userChoice = "";
int userWin = 0;
int compWin = 0;
string[] choices = {"rock", "paper", "scissors"};
Random rand = new Random();
string compChoice = "";
char keepPlaying = 'y';

Console.WriteLine("Welcome to Rock-Paper-Scissors!");
Console.Write("Please choose your hand (Rock, Paper, or Scissors): ");

do
{
	while(userWin != 2 && compWin != 2)
	{
		// Get user input for gameplay
		userChoice = Console.ReadLine().ToLower();

		// Validate user input
		while (!userChoice.Equals("rock") && !userChoice.Equals("paper") && !userChoice.Equals("scissors"))
		{
			Console.WriteLine("Please input one of the choices (Rock, Paper, or Scissors)");
			userChoice = Console.ReadLine().ToLower();
		}

		compChoice = choices[rand.Next(0,3)];

		if(compChoice.Equals("rock"))
		{
			if(userChoice.Equals("rock"))
			{
				Console.WriteLine("You tied! Try again!");
				continue;
			}
			else if(userChoice.Equals("paper"))
			{
				Console.WriteLine("You won this round!");
				userWin++;
			}
			else
			{
				Console.WriteLine("You lost this round!");
				compWin++;
			}
		}
		else if(compChoice.Equals("paper"))
		{
			if(userChoice.Equals("paper"))
			{
				Console.WriteLine("You tied! Try again!");
				continue;
			}
			else if(userChoice.Equals("scissors"))
			{
				Console.WriteLine("You won this round!");
				userWin++;
			}
			else
			{
				Console.WriteLine("You lost this round!");
				compWin++;
			}
		}
		else
		{
			if(userChoice.Equals("scissors"))
			{
				Console.WriteLine("You tied! Try again!");
			}
			else if(userChoice.Equals("rock"))
			{
				Console.WriteLine("You won this round!");
				userWin++;
			}
			else
			{
				Console.WriteLine("You lost this round!");
				compWin++;
			}
		}
	}

	if(userWin == 2)
	{
		Console.WriteLine("You won the game! Great job!");
		Console.Write("Would you like to play again? y/n: ");
		keepPlaying = Console.ReadLine().ToLower().ToCharArray()[0];
	}
	else if(compWin == 2)
	{
		Console.WriteLine("You lost the game. Maybe you'll win next time!");
		Console.Write("Would you like to play again? y/n: ");
		keepPlaying = Console.ReadLine().ToLower().ToCharArray()[0];
	}
} while(keepPlaying.Equals('y'));

Console.WriteLine("Thank you for playing Rock Paper Scissors!");
