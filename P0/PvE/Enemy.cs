public class Enemy
{
    public EnemyType enemyType;
    public int health;

    public Enemy(EnemyType enemyType)
    {
        this.enemyType = enemyType;
    }

    public void setHealth(EnemyType enemyType){
        if(enemyType == EnemyType.Orc)
        {
            this.health = 100;
        }
        else if(enemyType == EnemyType.Fae)
        {
            this.health = 50;
        }
        else if(enemyType == EnemyType.Beast)
        {
            this.health = 75;
        }
        else if(enemyType == EnemyType.Behemoth)
        {
            this.health = 200;
        }
        else if(enemyType == EnemyType.Minotaur)
        {
            this.health = 150;
        }
    }

    public void Attack(Player player)
    {
        Random rand = new Random();
        int damage;
        if(this.enemyType == EnemyType.Fae)
        {
            damage = rand.Next(1, 7);
            player.health -= damage;
            Console.WriteLine($"The {this.enemyType} attacks {player.name} for {damage} damage!");
        }
    }
}