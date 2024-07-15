using MonsterSlayerReborn.Gameplay;

namespace MonsterSlayerReborn.Models
{
    public class Player : IUnit
    {
        // Fields
        public string name { get; set; } = "";
        public PlayerClass playerClass{ get; set; }
        public int health { get; set; };
        public int armorClass { get; set; }

        // Methods
        public Player(string playerName, PlayerClass playerClass)
        {
            this.name = playerName;
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

        void SetAC()
        {
            switch(this.playerClass)
            {
                case PlayerClass.Mage:
                    this.armorClass = 10;
                    break;
                case PlayerClass.Barbarian:
                    this.armorClass = 12;
                    break;
                case PlayerClass.Warrior:
                    this.armorClass = 14;
                    break;
            }
        }

        void Attack(Enemy enemy)
        {
            switch(this.playerClass)
            {
                case PlayerClass.Mage:
                    Attack attack = new Attack(4, this.name, enemy);
                    attack.Attack();
                    break;
                case PlayerClass.Barbarian:
                    Attack attack = new Attack(0, this.name, enemy);
                    attack.Attack();
                    break;
                case PlayerClass.Warrior:
                    Attack attack = new Attack(2, this.name, enemy);
                    attack.Attack();
                    break;
            }
        }



    }
}