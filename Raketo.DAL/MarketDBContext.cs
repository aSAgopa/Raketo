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

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; } = null!; 
        public DbSet<Order> Orders { get; set; } = null!; 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(150);
            });
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

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Amount)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");
                entity.Property(o => o.Price)
                      .HasColumnType("decimal(18,2)");

                entity.HasOne(o => o.User)
                      .WithMany(o => o.Orders)
                      .HasForeignKey(o => o.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
