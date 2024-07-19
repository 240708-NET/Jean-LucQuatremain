using System;
using Microsoft.EntityFrameworkCore;
using MonsterSlayerReborn.Models;
using MonsterSlayerReborn.Gameplay;

namespace MonsterSlayerReborn.Repo
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games => Set<Game>();
        public GameContext(DbContextOptions<GameContext> options) : base(options){}
    }
}