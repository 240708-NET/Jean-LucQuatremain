using System;
using MonsterSlayerReborn.Models;
using MonsterSlayerReborn.Gameplay;
using Microsoft.EntityFrameworkCore;

namespace MonsterSlayerReborn.Repo
{
    public class ServerRepo : IRepo
    {
        static readonly string connectionstring = "";
        static GameContext context;

        public ServerRepo( string SC )
        {
            DbContextOptions<GameContext> options;
            options = new DbContextOptionsBuilder<GameContext>()
                .UseSqlServer(connectionstring)
                .Options;
            context = new GameContext(options);
        }

        public void SaveGameInfo(Game game)
        {
            context.Games.Add(game);
            context.SaveChanges();
        }

        public List<Game> GetPastGames()
        {
            return context.Games.ToList();
        }
    }
}