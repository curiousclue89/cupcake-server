using CupcakeServer.Models.Items;
using CupcakeServer.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace CupcakeServer.Models
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<UserCard> UserCard { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<ItemAttribute> ItemAttributes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Deliveries)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItems)
                .WithOne(e => e.Order)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
