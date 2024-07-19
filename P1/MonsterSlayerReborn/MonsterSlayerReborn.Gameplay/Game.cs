using MonsterSlayerReborn.Models;

namespace MonsterSlayerReborn.Gameplay
{
    public class Game
    {
        public string difficulty { get; set; }
        public int difficultyLevel { get; set; }
        public bool userWin = false;
        Player player;
        public int roundsPlayed = 0;

        public void InitializeGame()
        {
            Console.WriteLine("Welcome to Monster Slayer!\n\n");
            GetDifficulty();
            InitializePlayer();



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
    }
}