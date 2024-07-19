namespace MonsterSlayerReborn.Models
{
    public interface IUnit
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int ArmorClass { get; set; }
        public void SetHealth();
        public void SetAC();
        public void Attack(IUnit unit);
    }
}