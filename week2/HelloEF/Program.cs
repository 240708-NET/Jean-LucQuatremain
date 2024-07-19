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

            // string ConnectionString = File.ReadAllText("./connectionstring.txt");
        
            // DbContextOptions<DataContext> ContextOptions = new DbContextOptionsBuilder<DataContext>().UseSqlServer(ConnectionString).Options;
            //DataContext Context = new DataContext(ContextOptions);

            /*
            OR
                DbContextOptionsBuilder<DataContext> ContextOptions = new DbContextOptionsBuilder<DataContext>().UseSqlServer(ConnectionString);
                DataContext Context = new DataContext(ContextOptions.Options);
            */

            // Pet MyPet = CreatePet(MyPet);
            MyPet = GetPet(MyPet);

            Console.WriteLine(MyPet.Speak());
        }

        public static Pet GetPet(Pet MyPet)
        {
            using (var context = new DataContext())
            {
                var found = 
                    from p in context.Pets.ToList()
                    where p.Name == MyPet.Name
                        && p.Cuteness == MyPet.Cuteness
                        && p.Chaos == MyPet.Chaos
                        && p.Species == MyPet.Species
                    select p;

                return found.FirstOrDefault();
            }
        }

        public static Pet GetPetById(int id)
        {
            using (var context = new DataContext())
            {
                Pet pet = context.Pets.Find(id);
                return pet;
            }
        }

        public static Pet CreatePet(Pet newPet)
        {
            using (var context = new DataContext())
            {
                context.Add(newPet);
                context.SaveChanges();
                
                return GetPet(newPet);
            }
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