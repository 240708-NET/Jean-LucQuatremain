namespace MonsterSlayerReborn.Models
{
    public class Enemy : IUnit
    {
        // Fields
        public string name { get; set; } = "";
        public EnemyType enemyType{ get; set; }
        public int health { get; set; };
        public int armorClass { get; set; }

        // Methods
        // Constructor to build enemy based on randomizer in gameplay
        public Enemy(EnemyType enemyType)
        {
            this.enemyType = enemyType;
            SetName();
            SetHealth();
            SetAC();
        }

        // Method to set enemy health according to the enemy's type
        public void SetHealth()
        {
            switch(this.enemyType)
            {
                case enemyType.Fae:
                    this.health = 50;
                    break;
                case enemyType.Beast:
                    this.health = 70;
                    break;
                case enemyType.Orc:
                    this.health = 90;
                    break;
                case enemyType.Minotaur:
                    this.health = 110;
                    break;
                case enemyType.Behemoth:
                    this.health = 125;
                    break;
            }
        }

        // Method to set the enemy's AC according to enemy type
        public void SetAC()
        {
            switch(this.enemyType)
            {
                case EnemyType.Fae:
                    this.armorClass = 4;
                    break;
                case EnemyType.Beast:
                    this.armorClass = 6;
                    break;
                case EnemyType.Orc:
                    this.armorClass = 8;
                    break;
                case EnemyType.Minotaur:
                    this.armorClass = 10;
                    break;
                case EnemyType.Behemoth:
                    this.armorClass = 12;
                    break;
            }
        }

        // Method to set enemy's name during enemy construction
        public void SetName()
        {
            switch(this.enemyType)
            {
                case EnemyType.Fae:
                    this.name = "Puck";
                    break;
                case EnemyType.Beast:
                    this.name = "Fenrir";
                    break;
                case EnemyType.Orc:
                    this.name = "Gorbag";
                    break;
                case EnemyType.Minotaur:
                    this.name = "Asterius";
                    break;
                case EnemyType.Behemoth:
                    this.name = "Behemoth";
                    break;
            }
        }

        // Method to call the Attack class to perform attack functionality based on enemy type and the player they are facing
        public void Attack(Player player)
        {
            switch(this.enemyType)
            {
                case EnemyType.Fae:
                    Attack attack = new Attack(0, this.name, player);
                    attack.Attack();
                    break;
                case EnemyType.Beast:
                    Attack attack = new Attack(2, this.name, player);
                    attack.Attack();
                    break;
                case EnemyType.Orc:
                    Attack attack = new Attack(1, this.name, player);
                    attack.Attack();
                    break;
                case EnemyType.Minotaur:
                    Attack attack = new Attack(4, this.name, player);
                    attack.Attack();
                    break;
                case EnemyType.Behemoth:
                    Attack attack = new Attack(6, this.name, player);
                    attack.Attack();
                    break;
            }
        }
    }
}