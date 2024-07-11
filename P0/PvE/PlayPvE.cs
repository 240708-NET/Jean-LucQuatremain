public class PlayPvE
{
    public int numRounds{ get; set; }  = 1;// Default rounds is 1
    Player player = new Player();
    

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
        while (!int.TryParse(roundChoice, out numRounds))
        {
            Console.WriteLine("Please choose a valid numerical choice: ");
            roundChoice = Console.ReadLine();
            Console.WriteLine();
        }
        Console.WriteLine();
        
        // Get user character name
        Console.Write("What is your name hero?: ");
        string playerName = Console.ReadLine();
        // Validate that the user has entered a name
        while (!string.IsNullOrEmpty(playerName))
        {
            Console.Write("Please input a name for your character: ");
            playerName = Console.ReadLine();
            Console.WriteLine();
        }
        Console.WriteLine();

        // Get user class choice
        Console.WriteLine($"{player.name}, what is your class?");
        Console.Write("1 for Mage, 2 for Barbarian, 3 for Warrior: ")
        string classChoice = Console.ReadLine();
        int classChoiceNum;
        // Validate user class choice
        while (!int.TryParse(classChoice, out classChoiceNum))
        {
            Console.Write("Please choose a valid class choice: 1 for Mage, 2 for Barbarian, 3 for Warrior");
            classChoice = Console.ReadLine();
            Console.WriteLine();
        }
        Console.WriteLine();

        // Use user choice to intiailize their character, class defaults to Barbarian if a valid choice was not made
        switch(classChoiceNum)
        {
            case 1:
                player.name = playerName;
                player.Class = PlayerClass.Mage;
                break;
            case 2:
                player.name = playerName;
                player.Class = PlayerClass.Barbarian;
                break;
            case 3:
                player.name = playerName;
                player.Class = PlayerClass.Warrior;
                break;
            default:
                player.name = playerName;
                player.Class = PlayerClass.Barbarian;
                break;
        }

        player.setHealth(player.Class);

        Console.WriteLine("Player selection has been made!");
        if(numRounds == 1)
        {
            Console.WriteLine("Let's enter the dungeon and fight the enemy!")
        }
        else
        {
            Console.WriteLine("Let's enter the first dungeon!")
        }
    }


    // Method to play the game
    public void PlayGame()
    {
        Random randEnemy = new Random();

        // If user chose 1 round or chose invalid round choice default to 1 round
        if(numRounds == 1)
        {
            Enemy enemy = new Enemy();
            int monsterType = randEnemy.Next(0, 5);
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





        }
    }
}