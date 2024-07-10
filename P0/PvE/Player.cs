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

    public void Attack(Enemy enemy)
    {
        Random rand = new Random();
        int damage;
        if(this.Class == PlayerClass.Warrior)
        {
            damage = rand.Next(1, 12);
            enemy.health -= damage;
            Console.WriteLine($"{name} attacks {enemy.name} for {damage} damage!");
        }
        else if(this.Class == PlayerClass.Mage)
        {
            damage = rand.Next(1, 20);
            enemy.health -= damage;
            Console.WriteLine($"{name} attacks {enemy.name} for {damage} damage!");
        }
        else if(this.Class == PlayerClass.Barbarian)
        {
            damage = rand.Next(1, 8);
            enemy.health -= damage;
            Console.WriteLine($"{name} attacks {enemy.name} for {damage} damage!");
        }
    }
}