public class Player
{
    // Player fields
    public string name{ get; set; }
    public int health{ get; set; }
    public PlayerClass playerClass{ get; set; }

    // Constructor to intialize a new player with input
    public Player(string name, PlayerClass playerClass)
    {
        this.name = name;
        this.playerClass = playerClass;
        setHealth(playerClass);
    }

    // Method to set the health of the player based on their chosen class type
    public void setHealth(PlayerClass playerClass){
        if(playerClass == PlayerClass.Mage)
        {
            this.health = 75;
        }
        else if(playerClass == PlayerClass.Barbarian)
        {
            this.health = 100;
        }
        else if(playerClass == PlayerClass.Warrior)
        {
            this.health = 125;
        }
    }

    // Attack method that simulates rolling a specified die based upon player class type and ensuing logic to update enemy health
    public void Attack(Enemy enemy)
    {
        Random rand = new Random();
        int damage;
        if(this.playerClass == PlayerClass.Warrior)
        {
            damage = rand.Next(1, 13);
            enemy.health -= damage;
            Console.WriteLine($"{name} attacks the {enemy.enemyType} for {damage} damage!");
        }
        else if(this.playerClass == PlayerClass.Mage)
        {
            damage = rand.Next(1, 21);
            enemy.health -= damage;
            Console.WriteLine($"{name} attacks the {enemy.enemyType} for {damage} damage!");
        }
        else if(this.playerClass == PlayerClass.Barbarian)
        {
            damage = rand.Next(1, 9);
            enemy.health -= damage;
            Console.WriteLine($"{name} attacks the {enemy.enemyType} for {damage} damage!");
        }
    }
}