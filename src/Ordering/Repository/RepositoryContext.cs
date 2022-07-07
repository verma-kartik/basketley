using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Order>()
               .HasOne(x => x.ShippingAddress)
               .WithMany()
               .HasForeignKey(x => x.ShippingAddressId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(a => a.Order)
                .WithMany(c => c.OrderItems)
                .HasForeignKey(a => a.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}