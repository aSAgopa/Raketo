using Raketo.Models;
using Raketo.ViewModel;

namespace Raketo.Interfaces
{
    public interface IRepository
    {
        public Task<IEnumerable<IProducts?>> GetProductsAsync(int id);

        public ProductViewModel? AddProduct(int id);

        public Task AddCategoryAsync(ProductViewModel products);

        public Task DeleteCategoryAsync(int id, int forId);

        public ProductViewModel CreateModel(int id, int forId);

        public Task UpdateProductAsync(ProductViewModel product);

        public Task<ProductViewModel> BuildingOrders(int count, string? name, double? price);

        public Task ChangeQuantity(int categoriesId, int id, int count);
       
    }
}
