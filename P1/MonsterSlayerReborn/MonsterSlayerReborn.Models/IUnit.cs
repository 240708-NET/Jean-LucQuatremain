namespace MonsterSlayerReborn.Models
{
    public interface IUnit
    {
        void SetHealth();
        void Attack(IUnit unit);
    }
}