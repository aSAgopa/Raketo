using Microsoft.EntityFrameworkCore;
using Raketo.DAL.Entities;
using Raketo.Model.Enums;
using System.Collections.Generic;
using System.Reflection.Emit;



namespace Raketo.DAL
{
    public class MarketDBContext : DbContext
    {
        public MarketDBContext(DbContextOptions<MarketDBContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(200);
                entity.Property(p => p.Price)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");
            });
        }
    }
}
