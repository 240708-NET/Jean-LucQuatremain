namespace MonsterSlayerReborn.Models
{
    public class Enemy : IUnit
    {
        // Fields
        public string Name { get; set; } = "";
        public EnemyType enemyType { get; set; }
        public int Health { get; set; }
        public int ArmorClass { get; set; }

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
            switch (this.enemyType)
            {
                case EnemyType.Fae:
                    this.Health = 50;
                    break;
                case EnemyType.Beast:
                    this.Health = 70;
                    break;
                case EnemyType.Orc:
                    this.Health = 90;
                    break;
                case EnemyType.Minotaur:
                    this.Health = 110;
                    break;
                case EnemyType.Behemoth:
                    this.Health = 125;
                    break;
            }
        }

        // Method to set the enemy's AC according to enemy type
        public void SetAC()
        {
            switch (this.enemyType)
            {
                case EnemyType.Fae:
                    this.ArmorClass = 4;
                    break;
                case EnemyType.Beast:
                    this.ArmorClass = 6;
                    break;
                case EnemyType.Orc:
                    this.ArmorClass = 8;
                    break;
                case EnemyType.Minotaur:
                    this.ArmorClass = 10;
                    break;
                case EnemyType.Behemoth:
                    this.ArmorClass = 12;
                    break;
            }
        }

        // Method to set enemy's name during enemy construction
        public void SetName()
        {
            switch (this.enemyType)
            {
                case EnemyType.Fae:
                    this.Name = "Puck";
                    break;
                case EnemyType.Beast:
                    this.Name = "Fenrir";
                    break;
                case EnemyType.Orc:
                    this.Name = "Gorbag";
                    break;
                case EnemyType.Minotaur:
                    this.Name = "Asterius";
                    break;
                case EnemyType.Behemoth:
                    this.Name = "Behemoth";
                    break;
            }
        }

        // Method to call the Attack class to perform attack functionality based on enemy type and the player they are facing
        public void Attack(IUnit unit)
        {
            Attack attackInstance;
            if (unit is Player player)
            {
                switch (this.enemyType)
                {
                    case EnemyType.Fae:
                        attackInstance = new Attack(0, this.Name, player);
                        attackInstance.AttackUnit();
                        break;
                    case EnemyType.Beast:
                        attackInstance = new Attack(2, this.Name, player);
                        attackInstance.AttackUnit();
                        break;
                    case EnemyType.Orc:
                        attackInstance = new Attack(1, this.Name, player);
                        attackInstance.AttackUnit();
                        break;
                    case EnemyType.Minotaur:
                        attackInstance = new Attack(4, this.Name, player);
                        attackInstance.AttackUnit();
                        break;
                    case EnemyType.Behemoth:
                        attackInstance = new Attack(6, this.Name, player);
                        attackInstance.AttackUnit();
                        break;
                }
            }
        }
    }
}