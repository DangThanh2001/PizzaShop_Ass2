using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Entity;

namespace PizzaShop.Data
{
    public class PizzaShopContext : DbContext
    {
        public PizzaShopContext (DbContextOptions<PizzaShopContext> options)
            : base(options)
        {
        }

        public DbSet<PizzaShop.Entity.Account> accounts { get; set; }
        public DbSet<PizzaShop.Entity.Category> categories { get; set; }
        public DbSet<PizzaShop.Entity.Customers> customers { get; set; }
        public DbSet<PizzaShop.Entity.Orders> orders { get; set; }
        public DbSet<PizzaShop.Entity.Products> products { get; set; }
        public DbSet<PizzaShop.Entity.Supply> supplies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("accounts");
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Customers>().ToTable("customers");
            modelBuilder.Entity<Orders>().ToTable("orders");
            modelBuilder.Entity<Products>().ToTable("products");
            modelBuilder.Entity<Supply>().ToTable("supplies");
        }
    }
}
