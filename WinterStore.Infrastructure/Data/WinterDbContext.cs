using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WinterStore.Domain.Entities;

namespace WinterStore.Infrastructure.Data
{
    public class WinterDbContext : DbContext
    {
        public WinterDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WinterDbContext).Assembly);
        }
    }
}
