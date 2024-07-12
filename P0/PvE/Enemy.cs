public class Enemy
{
    public EnemyType enemyType{ get; set; }
    public int health{ get; set; }

    public Enemy(EnemyType type)
    {
        enemyType = type;
        setHealth(type);
    }

    public void setHealth(EnemyType type)
    {

        switch (type)
        {
            case EnemyType.Fae:
                health = 25;
                break;
            case EnemyType.Beast:
                health = 50;
                break;
            case EnemyType.Orc:
                health = 75;
                break;
            case EnemyType.Minotaur:
                health = 100;
                break;
            case EnemyType.Behemoth:
                health = 125;
                break;
        }
        /*
        if(enemyType == EnemyType.Orc)
        {
            this.health = 75;
        }
        else if(enemyType == EnemyType.Fae)
        {
            this.health = 25;
        }
        else if(enemyType == EnemyType.Beast)
        {
            this.health = 50;
        }
        else if(enemyType == EnemyType.Behemoth)
        {
            this.health = 125;
        }
        else if(enemyType == EnemyType.Minotaur)
        {
            this.health = 100;
        }
        */
    }

    public void Attack(Player player)
    {
        Random rand = new Random();
        int damage;
        if(this.enemyType == EnemyType.Fae)
        {
            damage = rand.Next(1, 5);
            player.health -= damage;
            Console.WriteLine($"The {this.enemyType} attacks {player.name} for {damage} damage!");
        }
        else if(this.enemyType == EnemyType.Beast)
        {
            damage = rand.Next(1, 7);
            player.health -= damage;
            Console.WriteLine($"The {this.enemyType} attacks {player.name} for {damage} damage!");
        }
        else if(this.enemyType == EnemyType.Orc)
        {
            damage = rand.Next(1, 9);
            player.health -= damage;
            Console.WriteLine($"The {this.enemyType} attacks {player.name} for {damage} damage!");
        }
        else if(this.enemyType == EnemyType.Minotaur)
        {
            damage = rand.Next(1, 13);
            player.health -= damage;
            Console.WriteLine($"The {this.enemyType} attacks {player.name} for {damage} damage!");
        }
        else if(this.enemyType == EnemyType.Behemoth)
        {
            damage = rand.Next(1, 21);
            player.health -= damage;
            Console.WriteLine($"The {this.enemyType} attacks {player.name} for {damage} damage!");
        }
    }
}