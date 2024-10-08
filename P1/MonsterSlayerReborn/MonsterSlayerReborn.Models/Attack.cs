namespace MonsterSlayerReborn.Models
{
    public class Attack
    {
        public int modifier { get; set; }
        public string attackingUnit{ get; set; }
        public IUnit defendingUnit { get; set; }

        public Attack(int modifier, string attackingUnit, IUnit defendingUnit)
        {
            this.modifier = modifier;
            this.attackingUnit = attackingUnit;
            this.defendingUnit = defendingUnit;
        }

        public void AttackUnit()
        {
            Random rand = new Random();
            int damage = 0;
            int enemyAC = defendingUnit.ArmorClass;
            int roll = rand.Next(1, 21);

            if(roll == 20)
            {
                Console.WriteLine($"{attackingUnit} has crit!");
                Console.Write("Press any key to roll for damage: ");
                Console.ReadLine();
                for (int i = 0; i < 2; i++)
                {
                    damage += rand.Next(5, 13);
                }
                damage += this.modifier;
                defendingUnit.Health -= damage;
                Console.WriteLine($"{attackingUnit} attacks {defendingUnit.Name} for {damage} damage!");
            }
            else if(roll == 1)
            {
                Console.WriteLine($"{attackingUnit} has critically failed!");
                switch(rand.Next(1, 4))
                {
                    case 1:
                        Console.WriteLine("You might as well fall on your weapon.");
                        break;
                    case 2:
                        Console.WriteLine("Better luck next time!");
                        break;
                    case 3:
                        Console.WriteLine("How unfortunate.");
                        break;
                }
            }
            else if(roll + modifier > enemyAC)
            {
                Console.WriteLine($"{attackingUnit} lands a hit!");
                Console.Write("Press any key to roll for damage: ");
                Console.ReadLine();
                damage = rand.Next(1, 13) + modifier;
                defendingUnit.Health -= damage;
                Console.WriteLine($"{attackingUnit} attacks {defendingUnit.Name} for {damage} damage!");
            }
            else
            {
                Console.WriteLine($"{attackingUnit} misses their attack!");
                switch(rand.Next(1, 4))
                {
                    case 1:
                        Console.WriteLine("What a whiff.");
                        break;
                    case 2:
                        Console.WriteLine("Better luck next time!");
                        break;
                    case 3:
                        Console.WriteLine("You should try being better.");
                        break;
                }
            }
        }

    }
}