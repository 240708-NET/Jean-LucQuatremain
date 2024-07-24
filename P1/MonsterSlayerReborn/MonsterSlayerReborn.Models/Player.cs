namespace MonsterSlayerReborn.Models
{
    public class Player : IUnit
    {
        // Fields
        public int Id { get; private set; }
        public string Name { get; set; } = "";
        public PlayerClass playerClass { get; set; }
        public int Health { get; set; }
        public int ArmorClass { get; set; }

        // Methods

        // Parameterless constructor for EF Core
        public Player()
        {
        }
        
        // Constructor to build player character after receiving user inputs during game initialization
        public Player(string playerName, PlayerClass playerClass)
        {
            this.Name = playerName;
            this.playerClass = playerClass;
            SetHealth();
            SetAC();
        }

        // Method to set player health according to the player's class
        public void SetHealth()
        {
            switch (this.playerClass)
            {
                case PlayerClass.Mage:
                    this.Health = 75;
                    break;
                case PlayerClass.Barbarian:
                    this.Health = 100;
                    break;
                case PlayerClass.Warrior:
                    this.Health = 125;
                    break;
            }
        }

        // Method to set the character's AC according to class type
        public void SetAC()
        {
            switch (this.playerClass)
            {
                case PlayerClass.Mage:
                    this.ArmorClass = 10;
                    break;
                case PlayerClass.Barbarian:
                    this.ArmorClass = 12;
                    break;
                case PlayerClass.Warrior:
                    this.ArmorClass = 14;
                    break;
            }
        }

        // Method to call the Attack class to perform attack functionality based on character class and the enemy they are facing
        public void Attack(IUnit unit)
        {
            Attack attackInstance;
            if (unit is Enemy enemy)
            {
                switch (this.playerClass)
                {
                    case PlayerClass.Mage:
                        attackInstance = new Attack(4, this.Name, enemy);
                        attackInstance.AttackUnit();
                        break;
                    case PlayerClass.Barbarian:
                        attackInstance = new Attack(0, this.Name, enemy);
                        attackInstance.AttackUnit();
                        break;
                    case PlayerClass.Warrior:
                        attackInstance = new Attack(2, this.Name, enemy);
                        attackInstance.AttackUnit();
                        break;
                }
            }
        }
    }
}