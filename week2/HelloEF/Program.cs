using System;
using Microsoft.EntityFrameworkCore;

namespace HelloEF
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Again!");
            Pet MyPet = new Pet(){Name = "Peter", Cuteness = 10, Chaos = 2, Species = "Rabbit"};
            Console.WriteLine(MyPet.Speak());

            // string ConnectionString = File.ReadAllText("./connectionstring.txt");
            
            
            // DbContextOptions<DataContext> ContextOptions = new DbContextOptionsBuilder<DataContext>().UseSqlServer(ConnectionString).Options;
            //DataContext Context = new DataContext(ContextOptions);

            /*
            OR
                DbContextOptionsBuilder<DataContext> ContextOptions = new DbContextOptionsBuilder<DataContext>().UseSqlServer(ConnectionString);
                DataContext Context = new DataContext(ContextOptions.Options);
            */
        }
    }

    public class Pet
    {
        // Fields
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Cuteness { get; set; }
        public long? Chaos { get; set; }
        public string? Species { get; set; }

        // Constructors

        // Methods
        public string Speak()
        {
            return $"Hello, I'm {this.Name}!";
        }
    }

    public class DataContext : DbContext
    {
        // Fields
        public DbSet<Pet> Pets => Set<Pet>();

        // Constructors
        // public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        string connectionString = File.ReadAllText("./connectionstring.txt");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}