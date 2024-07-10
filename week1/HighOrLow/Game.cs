class Game
{
    // Fields

    Random random = new Random();
    int targetNumber;
    private int guessNumber;
    public string guessString = "";
    private int roundCount = 0;

    // Methods

    // Constructor for Game objects
    public Game()
    {
        this.targetNumber = random.Next(11);
        this.guessString = "";
    }

    // Method that runs the logic of the high low game
    public void PlayGame()
    {
        roundCount = 0;
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
    }
}