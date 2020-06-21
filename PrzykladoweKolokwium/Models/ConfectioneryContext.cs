using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwium.Models
{
    public class ConfectioneryContext : DbContext
    {
        public ConfectioneryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ConfectioneryProduct> ConfectioneryProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasKey(c => new { c.IdOrder, c.IdConfectioneryProduct });

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    IdClient = 1,
                    Name = "Adam",
                    Surname = "Kowalski"
                },
                new Client
                {
                    IdClient = 2,
                    Name = "Ewa",
                    Surname = "Nowak"
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    IdEmployee = 1,
                    Name = "Aleksandra",
                    Surname = "Kowalska"
                },
                new Employee
                {
                    IdEmployee = 2,
                    Name = "Jan",
                    Surname = "Nowak"
                });
            modelBuilder.Entity<ConfectioneryProduct>().HasData(
                new ConfectioneryProduct
                {
                    IdConfectioneryProduct = 1,
                    Name = "Makowiec",
                    Type = "Ciasto"
                },
                new ConfectioneryProduct
                {
                    IdConfectioneryProduct = 2,
                    Name = "Sernik",
                    Type = "Ciasto"
                });
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    IdOrder = 1,
                    AcceptanceDate = DateTime.Now.AddDays(-1),
                    RealizationDate = DateTime.Now.AddDays(2),
                    Comments = null,
                    IdClient = 1,
                    IdEmployee = 1
                },
                new Order
                {
                    IdOrder = 2,
                    AcceptanceDate = DateTime.Now,
                    RealizationDate = DateTime.Now.AddDays(3),
                    Comments = "Na środę!",
                    IdClient = 2,
                    IdEmployee = 2
                });
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    IdOrder = 1,
                    IdConfectioneryProduct = 1,
                    Quantity = 15,
                    Comments = "Dużo"
                },
                new OrderItem
                {
                    IdOrder = 2,
                    IdConfectioneryProduct = 1,
                    Quantity = 2,
                    Comments = null
                },
                new OrderItem
                {
                    IdOrder = 2,
                    IdConfectioneryProduct = 2,
                    Quantity = 1,
                    Comments = null
                });
        }
    }
}
