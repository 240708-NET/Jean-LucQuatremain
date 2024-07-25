using System;
using Microsoft.EntityFrameworkCore;
using MonsterSlayerReborn.Models;
using MonsterSlayerReborn.Gameplay;

namespace MonsterSlayerReborn.Repo
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public GameContext(DbContextOptions<GameContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .HasOne(g => g.Player)
            .WithMany()
            .HasForeignKey(g => g.PlayerId);  // Assuming PlayerId is the foreign key in Game
    }
    }
}