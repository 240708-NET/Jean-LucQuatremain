public class PlayPvE
{
    // Variables and objects used through the class
    public int numRounds { get; set; } = 1;// Default rounds is 1
    public bool userWin = false;
    Player player = new Player("Default", PlayerClass.Barbarian);


    // Method used to intizlize game state
    public void InitializeGame()
    {
        Console.WriteLine("Welcome to Monster Slayer!");
        Console.WriteLine();
        Console.WriteLine();

        // Get user input for game difficulty
        Console.WriteLine("Please choose a difficulty (Number of Rounds)");
        Console.Write("1, 2 or 3: ");
        string roundChoice = Console.ReadLine();
        // Validate choice of rounds is a number (defaults to 1 based off initilization and simple validation)
        int rounds;
        while (!int.TryParse(roundChoice, out rounds))
        {
            Console.WriteLine("Please choose a valid numerical choice (1, 2, or 3): ");
            roundChoice = Console.ReadLine();
            Console.WriteLine();
        }
        numRounds = rounds;
        Console.WriteLine();

        // Get user character name
        Console.Write("What is your name hero?: ");
        string playerName = Console.ReadLine();
        // Validate that the user has entered a name by checking if the string is null or empty
        while (string.IsNullOrEmpty(playerName))
        {
            Console.Write("Please input a name for your character: ");
            playerName = Console.ReadLine();
            Console.WriteLine();
        }
        Console.WriteLine();

        // Get user class choice
        Console.WriteLine($"{playerName}, what is your class?");
        Console.Write("1 for Mage, 2 for Barbarian, 3 for Warrior: ");
        string classChoice = Console.ReadLine();
        int classChoiceNum;
        // Validate user class choice by ensuring the input is a number between 1 and 3 inclusive
        while (!int.TryParse(classChoice, out classChoiceNum) || classChoiceNum < 1 || classChoiceNum > 3)
        {
            Console.Write("Please choose a valid class choice: 1 for Mage, 2 for Barbarian, 3 for Warrior: ");
            classChoice = Console.ReadLine();
            Console.WriteLine();
        }
        Console.WriteLine();

        // Use user choice to intiailize their character, class defaults to Barbarian if a valid choice was not made
        switch (classChoiceNum)
        {
            case 1:
                player.name = playerName;
                player.playerClass = PlayerClass.Mage;
                break;
            case 2:
                player.name = playerName;
                player.playerClass = PlayerClass.Barbarian;
                break;
            case 3:
                player.name = playerName;
                player.playerClass = PlayerClass.Warrior;
                break;
        }

        // Set player health before game starts to ensure proper game state
        player.setHealth(player.playerClass);

        // Prepare for beginning of gameplay based on rounds to play
        Console.WriteLine("Player selection has been made!");
        if (numRounds == 1)
        {
            Console.WriteLine("Let's enter the dungeon and fight the enemy!");
            Console.WriteLine("Press any key to continue: ");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Let's enter the first dungeon!");
            Console.WriteLine("Press any key to continue: ");
            Console.ReadLine();
        }
    }


    // Method to play the game
    public void PlayGame()
    {
        // Loop to play through the rounds that the user chose or defaulted to
        for (int i = 0; i < numRounds; i++)
        {
            // Function call for each "room" a player will battle
            PlayRound();
            // Check to see if the user won the previous round and if there are more rounds to play and reward the player
            if (i + 1 < numRounds && userWin)
            {
                Console.WriteLine("Congratulations on clearing that room! For winning your health is restored for the next battle!");
                player.setHealth(player.playerClass);
                Console.WriteLine("Press any key to continue: ");
                Console.ReadLine();
            }
            // Check to see if the player won and the game has reached the final round already
            else if (i + 1 == numRounds && userWin)
            {
                Console.WriteLine("Congratulations on clearing the entire dungeon!");
                Console.WriteLine($"Great job {player.name}, you truly are a Hero!");
            }
            // Check if user lost
            else if (!userWin)
            {
                Console.WriteLine($"You put up a valiant effort {player.name}. Maybe you will slay the enemy next time.");
                break;
            }
        }
        Console.WriteLine("Thank you for playing Monster Slayer, see you next time!");
    }

    // Method of gameplay used to generate a random enemy and actual "play" mechanics of simulation dice rolls
    private void PlayRound()
    {
        Random randEnemy = new Random();

        // Generate a random enemy from the "pool" of potential enemies to fight
        EnemyType randomEnemyType = (EnemyType)randEnemy.Next(0, 5);
        Enemy enemy = new Enemy(randomEnemyType);

        // While both characters are alive do another round of gameplay
        while (player.health > 0 && enemy.health > 0)
        {
            // Pause so player can attack
            Console.Write("Enter any key to attack: ");
            Console.ReadLine();
            // Player turn to attack the enemy and validate if the player defeated the enemy
            player.Attack(enemy);
            if (enemy.health <= 0)
            {
                Console.WriteLine($"You have defeated the {enemy.enemyType}!");
                userWin = true;
                break;
            }

            // Pause so enemy can attack
            Console.Write("Enter any key for enemy to attack: ");
            Console.ReadLine();
            // Enemy turn to attack the player and validate if the enemy defeated the player
            enemy.Attack(player);
            if(player.health <= 0)
            {
                Console.WriteLine($"You were defeated by the {enemy.enemyType}.");
                userWin = false;
                break;
            }

            //Round by round output of current game state
            Console.WriteLine($"{player.name} Health: {player.health}");
            Console.WriteLine($"{enemy.enemyType} Health: {enemy.health}");
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }
    }
}