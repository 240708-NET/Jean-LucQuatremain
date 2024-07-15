namespace MonsterSlayerReborn.Models
{
    public class Player : IUnit
    {
        // Fields
        public string playerName { get; set; } = "";
        public PlayerClass playerClass{ get; set; }
        public int health { get; set; };

        // Methods
        public Player(string playerName, PlayerClass playerClass)
        {
            this.playerName = playerName;
            this.playerClass = playerClass;
            SetHealth();
        }

        void SetHealth()
        {
            switch(this.playerClass)
            {
                case PlayerClass.Mage:
                    this.health = 75;
                    break;
                case PlayerClass.Barbarian:
                    this.health = 100;
                    break;
                case PlayerClass.Warrior:
                    this.health = 125;
                    break;
            }
        }

        // Attack method COME BACK TO THIS TO FIX NAT 20 and WriteLines
        void Attack(Enemy enemy)
        {
            Random rand = new Random();
            int damage;
            switch(this.playerClass)
            {
                case PlayerClass.Mage:
                    damage = rand.Next(1, 21) + 4;
                    break;
                case PlayerClass.Barbarian:
                    damage = rand.Next(1, 21);
                    break;
                case PlayerClass.Warrior:
                    damage = rand.Next(1, 21) + 2;
                    break;
            }
        }
    }
}