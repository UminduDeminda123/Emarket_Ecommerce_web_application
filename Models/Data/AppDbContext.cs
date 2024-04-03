using eMarket.Models;
using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dealer_Product>().HasKey(am => new
            {
                am.DealerId,
                am.ProductId
            });

            modelBuilder.Entity<Dealer_Product>().HasOne(m => m.Product).WithMany(am => am.Dealers_Products).HasForeignKey(m => m.ProductId);
            modelBuilder.Entity<Dealer_Product>().HasOne(m => m.Dealer).WithMany(am => am.Dealers_Products).HasForeignKey(m => m.DealerId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Dealer_Product> Dealers_Products { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}