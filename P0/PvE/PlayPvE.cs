public class PlayPvE
{
    public int numRounds{ get; set; }  = 1;// Default rounds is 1
    Player player = new Player();
    Enemy enemy= new Enemy();

    public void InitializeGame()
    {
        Console.WriteLine("Please choose a difficulty (Number of Rounds)");
        Console.Write("1, 2 or 3: ");
        numRounds = int32.Parse(Console.ReadLine());
        Console.WriteLine();
        
        Console.Write("What is your name hero?: ");
        string playerName = Console.ReadLine();
        while (!string.IsNullOrEmpty(playerName))
        {
            Console.Write("Please input a name for your character: ");
            playerName = Console.ReadLine();
            Console.WriteLine();
        }
        Console.WriteLine();

        Console.WriteLine($"{player.name}, what is your class?");
        Console.Write("1 for Mage, 2 for Barbarian, 3 for Warrior: ")
        string classChoice = Console.ReadLine();
        int classChoiceNum;
        while (!int.TryParse(classChoice, out classChoiceNum))
        {
            Console.Write("Please choose a valid class choice: 1 for Mage, 2 for Barbarian, 3 for Warrior");
            classChoice = Console.ReadLine();
            Console.WriteLine();
        }
        Console.WriteLine();

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
    }
}