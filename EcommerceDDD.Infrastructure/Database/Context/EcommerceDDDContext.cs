﻿using EcommerceDDD.Domain.Carts;
using EcommerceDDD.Domain.Core.Messaging;
using EcommerceDDD.Domain.Customers;
using EcommerceDDD.Domain.Orders;
using EcommerceDDD.Domain.Payments;
using EcommerceDDD.Domain.Products;
using EcommerceDDD.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EcommerceDDD.Infrastructure.Database.Context
{
    public sealed class EcommerceDDDContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<StoredEvent> StoredEvents { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public EcommerceDDDContext(DbContextOptions<EcommerceDDDContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new StoredMessageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        }
    }
}