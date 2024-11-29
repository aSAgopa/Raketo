using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Raketo.Interfaces;
using Raketo.Models;
using Raketo.ViewModel;

namespace Raketo.Managers
{
    public class MarketDB : DbContext, IMarketDB
    {
        public DbSet<Beverages> BeveragesCategories { get; set; } = null!;
        public DbSet<Fish> FishCategories { get; set; } = null!;
        public DbSet<Meat> MeatCategories { get; set; } = null!;
        public DbSet<Vegetables> VegetablesCategories { get; set; } = null!;
        public DbSet<ProductViewModel> ClientsOrders { get; set; } = null!;
        
        public MarketDB(DbContextOptions<MarketDB> options)
                : base(options)
        {
            Database.EnsureCreated();
        }
        Task<int> IMarketDB.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
