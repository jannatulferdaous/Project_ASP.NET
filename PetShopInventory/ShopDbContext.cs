using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace PetShopInventory
{
    internal class ShopDbContext : DbContext
    {
        private readonly string _connectionString;

        public ShopDbContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
        }

        public ShopDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
                optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(GetUsers().ToArray());


        }
        public List<User> GetUsers()
        {
            return new List<User>
            {
                new User { Id = 1,UserName="admin",Password="123456"}
            };
        }


        public DbSet<Fish> Fish { get; set; }
        public DbSet<Cat> cats { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Chicken> Chickens { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Purchase> Purchases { get; set;}
        public DbSet<Sale> Sales { get; set; }
        
    }
}
