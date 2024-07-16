namespace MonsterSlayerReborn.Models
{
    public interface IUnit
    {
        public void SetHealth();
        public void SetAC();
        public void Attack(IUnit unit);
    }
}