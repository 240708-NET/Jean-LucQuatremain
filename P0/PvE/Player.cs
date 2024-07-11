public class Player
{
    public string name{ get; set; }
    public int health{ get; set; }
    public PlayerClass playerClass{ get; set; }

    public Player(string name, PlayerClass playerClass)
    {
        this.name = name;
        this.playerClass = playerClass;
        setHealth(playerClass);
    }

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

    public void Attack(Enemy enemy)
    {
        Random rand = new Random();
        int damage;
        if(this.playerClass == PlayerClass.Warrior)
        {
            damage = rand.Next(1, 13);
            enemy.health -= damage;
            Console.WriteLine($"{name} attacks {enemy.enemyType} for {damage} damage!");
        }
        else if(this.playerClass == PlayerClass.Mage)
        {
            damage = rand.Next(1, 21);
            enemy.health -= damage;
            Console.WriteLine($"{name} attacks {enemy.enemyType} for {damage} damage!");
        }
        else if(this.playerClass == PlayerClass.Barbarian)
        {
            damage = rand.Next(1, 9);
            enemy.health -= damage;
            Console.WriteLine($"{name} attacks {enemy.enemyType} for {damage} damage!");
        }
    }
}