using Microsoft.EntityFrameworkCore;
using ObuvnoyWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObuvnoyWPF.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PickUpPoint> PickUpPoints { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDescription> ProductDescriptions { get; set; }
        public DbSet<ProductName> ProductNames { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<UnitName> UnitNames { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=obuvnoy.db");
        }
    }
}
