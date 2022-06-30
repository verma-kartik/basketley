﻿using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer>? Customers { get; set; }  
        public DbSet<Address>? Addresses { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Address>()
        //        .HasOne(a => a.Customer)
        //        .WithMany(c => c.Addresses)
        //        .HasForeignKey(a => a.CustomerId)
        //        .IsRequired()
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
