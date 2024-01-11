using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Food> Foods { get; set; } = null!;

        public DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships between tables
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.customer)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.customerId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.food)
                .WithMany(f => f.Transactions)
                .HasForeignKey(t => t.foodId);

            modelBuilder.Entity<Customer>()
                .Property(c => c.customerId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Food>()
                .Property(c => c.foodId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Transaction>()
                .Property(c => c.transactionId)
                .ValueGeneratedOnAdd();
        }

    }
}
