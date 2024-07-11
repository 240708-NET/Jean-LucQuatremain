public class Player
{
    public string name{ get; set; }
    public int health = 100;
    public PlayerClass Class{ get; set; }

    public Player(string name, PlayerClass playerClass)
    {
        this.name = name;
        Class = playerClass;
    }

    public void setHealth(PlayerClass playerClass){
        if(playerClass == playerClass.Mage)
        {
            this.health = 75;
        }
        else if(playerClass == playerClass.Barbarian)
        {
            this.health = 100;
        }
        else if(playerClass == playerClass.Warrior)
        {
            this.health = 125;
        }
    }

    public void Attack(Enemy enemy)
    {
        Random rand = new Random();
        int damage;
        if(this.Class == PlayerClass.Warrior)
        {
            damage = rand.Next(1, 13);
            enemy.health -= damage;
            Console.WriteLine($"{name} attacks {enemy.name} for {damage} damage!");
        }
        else if(this.Class == PlayerClass.Mage)
        {
            damage = rand.Next(1, 21);
            enemy.health -= damage;
            Console.WriteLine($"{name} attacks {enemy.name} for {damage} damage!");
        }
        else if(this.Class == PlayerClass.Barbarian)
        {
            damage = rand.Next(1, 9);
            enemy.health -= damage;
            Console.WriteLine($"{name} attacks {enemy.name} for {damage} damage!");
        }
    }
}