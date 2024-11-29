using Microsoft.EntityFrameworkCore;
using Raketo.Managers;
using Raketo.Models;
using Raketo.ViewModel;

namespace Raketo.Interfaces
{
    public interface IMarketDB
    { 
        public DbSet<Beverages> BeveragesCategories { get; set; } 
        public DbSet<Fish> FishCategories { get; set; } 
        public DbSet<Meat> MeatCategories { get; set; } 
        public DbSet<Vegetables> VegetablesCategories { get; set; }
        public DbSet<ProductViewModel> ClientsOrders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
