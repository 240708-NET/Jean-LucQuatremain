namespace MonsterSlayerReborn.Models
{
    public class Enemy : IUnit
    {
        void SetHealth();
        void Attack(Player player);
    }
}