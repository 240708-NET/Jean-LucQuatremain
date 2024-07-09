class Program
{
	static void Main( string[] args )
	{
		int targetNumber;
		int guessNumber;
		string guessString;
		int roundCount = 0;

		Console.WriteLine("Welcome to High-Or-Low!");

		// Computer should choose a random number
		// User should be able to sbumit guesses
		// If the guess is high the computer should say so
		// If the guess is low the computer should say so
		// The player wins when they guess the target number
		
		// Produce a random integer to be guessed by the user
		Random random = new Random();
		targetNumber = random.Next(11);	

		do
		{
			roundCount++;
			Console.Write("Guess the number between 0 and 10: ");
			// Get user input
			guessString = Console.ReadLine();

			guessNumber = Int32.Parse(guessString);

			if(guessNumber == targetNumber)
			{
				Console.WriteLine($"You guessed the right number! You did it in {roundCount} tries!");
			}
			else if(guessNumber > targetNumber)
			{
				Console.WriteLine("Oops, too high!");
			}
			else
			{
				Console.WriteLine("Oops, too low!");
			}
		} while (guessNumber != targetNumber);
		Console.WriteLine("Thanks for playing High-Or-Low!");
	}
}
