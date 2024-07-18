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

            string ConnectionString = "Server=localhost;User=sa;Password=Peterrabbit2020!;Database=Pet;TrustServerCertificate=true;";
            DataContext Context = new DataContext(options => options.UseSqlServer(ConnectionString));
        
        
        }
    }

    class Pet
    {
        // Fields
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cuteness { get; set; }
        public long Chaos { get; set; }
        public string Species { get; set; }

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
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
    }
}