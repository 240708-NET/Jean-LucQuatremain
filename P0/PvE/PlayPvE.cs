public class PlayPvE
{
    public int numRounds { get; set; } = 1;// Default rounds is 1
    Player player = new Player("Default", PlayerClass.Barbarian);

    public bool userWin = false;


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
        // Validate choice of rounds
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
        // Validate that the user has entered a name
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
        // Validate user class choice
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

        player.setHealth(player.playerClass);

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
        // If user chose 1 round or chose invalid round choice default to 1 round
        for (int i = 0; i < numRounds; i++)
        {
            PlayRound();
            if (i + 1 < numRounds && userWin)
            {
                Console.WriteLine("Congratulations on clearing that room! For winning your health is restored for the next battle!");
                player.setHealth(player.playerClass);
                Console.WriteLine("Press any key to continue: ");
                Console.ReadLine();
            }
            else if (i + 1 == numRounds && userWin)
            {
                Console.WriteLine("Congrats on clearing the entire dungeon!");
                Console.WriteLine($"Great job {player.name}, you truly are a Hero!");
            }
            else if (!userWin)
            {
                Console.WriteLine($"You put up a valiant effort {player.name}. Maybe you will slay the enemy next time.");
                break;
            }
        }
        Console.WriteLine("Thank you for playing Monster Slayer, see you next time!");
    }



    private void PlayRound()
    {
        Random randEnemy = new Random();

        // Generate a random enemy from the "pool" of potential enemies to fight
        EnemyType randomEnemyType = (EnemyType)randEnemy.Next(0, 5);
        Enemy enemy = new Enemy(randomEnemyType);

        /*
        switch (monsterType)
        {
            case 0:
                enemy.enemyType = EnemyType.Fae;
                enemy.setHealth(enemy.enemyType);
                break;
            case 1:
                enemy.enemyType = EnemyType.Beast;
                enemy.setHealth(enemy.enemyType);
                break;
            case 2:
                enemy.enemyType = EnemyType.Orc;
                enemy.setHealth(enemy.enemyType);
                break;
            case 3:
                enemy.enemyType = EnemyType.Minotaur;
                enemy.setHealth(enemy.enemyType);
                break;
            case 4:
                enemy.enemyType = EnemyType.Behemoth;
                enemy.setHealth(enemy.enemyType);
                break;
        }

        */

        while (player.health > 0 && enemy.health > 0)
        {
            player.Attack(enemy);
            if (enemy.health <= 0)
            {
                Console.WriteLine($"You have defeated the {enemy.enemyType}!");
                userWin = true;
                break;
            }

            enemy.Attack(player);
            if(player.health <= 0)
            {
                Console.WriteLine($"You were defeated by the {enemy.enemyType}.");
                userWin = false;
                break;
            }

            Console.WriteLine($"{player.name} Health: {player.health}");
            Console.WriteLine($"{enemy.enemyType} Health: {enemy.health}");
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }
    }
}