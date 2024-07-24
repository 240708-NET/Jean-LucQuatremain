using MonsterSlayerReborn.Models;

namespace MonsterSlayerReborn.Gameplay
{
    public class Game
    {
        public int gameId { get; set; }
        public string difficulty { get; set; }
        public int difficultyLevel { get; set; }
        private bool userWin = false;
        public Player player { get; set; }
        public int roundsPlayed = 0;

        public void InitializeGame()
        {
            Console.WriteLine("Welcome to Monster Slayer!\n\n");
            GetDifficulty();
            InitializePlayer();
        }

        public void Play()
        {
            bool keepPlaying = false;

            Console.WriteLine("Let's enter the first dungeon!");
            Console.WriteLine("Press any key to continue: ");
            Console.ReadLine();
            do
            {
                PlayRound();
                roundsPlayed++;
                if (userWin)
                {
                    Console.WriteLine("Congratulations on clearing that room! For winning your health is restored for the next battle!");
                    player.SetHealth();
                    Console.Write("Would you like to keep playing?(y/n): ");
                    string keepPlayingStr = Console.ReadLine();
                    bool validInput = false;
                    while(!validInput)
                    {
                        if (keepPlayingStr == "y" || keepPlayingStr == "Y")
                        {
                            keepPlaying = true;
                            validInput = true;
                        }
                        else if (keepPlayingStr == "n" || keepPlayingStr == "N")
                        {
                            keepPlaying = false;
                            validInput = true;
                        }
                        else
                        {
                            Console.Write("Please input a valid repsonse (y/n): ");
                            keepPlayingStr = Console.ReadLine();
                            validInput = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"You put up a valiant effort {player.Name}. Maybe you will slay the enemy next time.");
                }
            } while (userWin && keepPlaying);

            Console.WriteLine("Thank you for playing Monster Slayer: Reborn!");
        }

        // Method used to get player choice of game difficulty
        private void GetDifficulty()
        {
            Console.WriteLine("Please choose the difficulty you would like to play on.");
            Console.Write("Easy, normal, or hard: ");
            difficulty = Console.ReadLine();
            while (string.IsNullOrEmpty(difficulty))
            {
                Console.WriteLine("Please input a difficulty to play on: Easy Normal Hard");
            }

            bool validInput = false;
            difficulty = difficulty.ToLower();
            while (!validInput)
            {
                if (difficulty == "e" || difficulty == "easy")
                {
                    this.difficultyLevel = 2;
                    validInput = true;
                }
                else if (difficulty == "n" || difficulty == "normal")
                {
                    this.difficultyLevel = 3;
                    validInput = true;
                }
                else if (difficulty == "h" || difficulty == "hard")
                {
                    this.difficultyLevel = 5;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Please input a valid difficulty level:");
                    Console.Write("Easy (e), Normal (n), or Hard (h): ");
                    difficulty = Console.ReadLine();
                }
            }

            Console.WriteLine($"Okay, you will be playing on {difficulty} difficulty.\n\n");
        }

        // Method used to get player character information and initialize the player object
        private void InitializePlayer()
        {
            Console.WriteLine("Now onto character creation!");
            Console.Write("What is your name hero?: ");
            string pName = Console.ReadLine();
            while (string.IsNullOrEmpty(pName))
            {
                Console.Write("Please enter a name for your character: ");
                pName = Console.ReadLine();
            }
            Console.WriteLine();

            Console.WriteLine($"{pName}, choose your class!");
            Console.Write("1 for Mage, 2 for Barbarian, 3 for Warrior: ");
            string classChoice = Console.ReadLine();
            int classChoiceNum = 0;
            // Validate user class choice by ensuring the input is a number between 1 and 3 inclusive
            while (!int.TryParse(classChoice, out classChoiceNum) || classChoiceNum < 1 || classChoiceNum > 3)
            {
                Console.Write("Please choose a valid class choice: 1 for Mage, 2 for Barbarian, 3 for Warrior: ");
                classChoice = Console.ReadLine();
            }
            Console.WriteLine();

            Console.WriteLine("Player selection has been made!");
            switch (classChoiceNum)
            {
                case 1:
                    player = new Player(pName, PlayerClass.Mage);
                    Console.WriteLine($"{player.Name} the Mage, prepare for battle!");
                    break;
                case 2:
                    player = new Player(pName, PlayerClass.Barbarian);
                    Console.WriteLine($"{player.Name} the Barbarian, prepare for battle!");
                    break;
                case 3:
                    player = new Player(pName, PlayerClass.Warrior);
                    Console.WriteLine($"{player.Name} the Warrior, prepare for battle!");
                    break;
            }
        }

        public void PlayRound()
        {
            Random randEnemy = new Random();
            EnemyType randomEnemyType = (EnemyType)randEnemy.Next(0, difficultyLevel);
            Enemy enemy = new Enemy(randomEnemyType);

            Console.WriteLine($"{player.Name} you approach {enemy.Name} in this room.");
            Console.WriteLine("Please press enter when you are ready to battle!");
            Console.ReadLine();

            // While both characters are alive do another round of gameplay
            while (player.Health > 0 && enemy.Health > 0)
            {
                // Pause so player can attack
                Console.Write("Enter any key to roll die and attack: ");
                Console.ReadLine();
                // Player turn to attack the enemy and validate if the player defeated the enemy
                player.Attack(enemy);
                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"You have defeated {enemy.Name}!");
                    userWin = true;
                    break;
                }

                // Pause so enemy can attack
                Console.Write("Enter any key for enemy to roll die and attack: ");
                Console.ReadLine();
                // Enemy turn to attack the player and validate if the enemy defeated the player
                enemy.Attack(player);
                if (player.Health <= 0)
                {
                    Console.WriteLine($"You were defeated by {enemy.Name}.");
                    userWin = false;
                    break;
                }

                //Round by round output of current game state
                Console.WriteLine($"{player.Name} Health: {player.Health}");
                Console.WriteLine($"{enemy.Name} Health: {enemy.Health}");
                Console.WriteLine("Press any key to continue..");
                Console.ReadLine();
            }
        }
    }
}