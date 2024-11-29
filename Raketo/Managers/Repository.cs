using Raketo.Interfaces;
using Microsoft.EntityFrameworkCore;
using Raketo.Models;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using Raketo.ViewModel;
using Azure;
using System.Net.WebSockets;

namespace Raketo.Managers
{
    public class Repository : IRepository
    {

        public IMarketDB DB { get; set; }
        public Repository(IMarketDB dB)
        {
            DB = dB;
        }
        public async Task<IEnumerable<IProducts?>> GetProductsAsync(int id)
        {


            if (id == 1)
            {
                var count = await DB.BeveragesCategories.CountAsync();
                if (count <= 0)
                {
                    await DB.BeveragesCategories.AddAsync(new Beverages());
                    await DB.SaveChangesAsync();
                    return await DB.BeveragesCategories.ToListAsync();
                }

                else return await DB.BeveragesCategories.ToListAsync();

            }
            if (id == 2)
            {
                var count = await DB.FishCategories.CountAsync();
                if (count <= 0)
                {
                    await DB.FishCategories.AddAsync(new Fish());
                    await DB.SaveChangesAsync();
                    return await DB.FishCategories.ToListAsync();
                }
                else return await DB.FishCategories.ToListAsync();
            }
            if (id == 3)
            {
                var count = await DB.MeatCategories.CountAsync();
                if (count <= 0)
                {
                    await DB.MeatCategories.AddAsync(new Meat());
                    await DB.SaveChangesAsync();
                    return await DB.MeatCategories.ToListAsync();
                }
                else return await DB.MeatCategories.ToListAsync();

            }
            if (id == 4)
            {
                var count = await DB.VegetablesCategories.CountAsync();
                if (count <= 0)
                {
                    await DB.VegetablesCategories.AddAsync(new Vegetables());
                    await DB.SaveChangesAsync();
                    return await DB.VegetablesCategories.ToListAsync();
                }
                else return await DB.VegetablesCategories.ToListAsync();
            }
            else return Enumerable.Empty<IProducts>();
        }
        public ProductViewModel? AddProduct(int id)
        {

            if (id == 1)
            {
                return new ProductViewModel { CategoresID = 1, CategoriesName = "Beverages" };
            }
            if (id == 2)
            {
                return new ProductViewModel { CategoresID = 2, CategoriesName = "Fish" };
            }
            if (id == 3)
            {
                return new ProductViewModel { CategoresID = 3, CategoriesName = "Meat" };
            }
            if (id == 4)
            {
                return new ProductViewModel { CategoresID = 4, CategoriesName = "Vegetables" };
            }
            else return null;
        }
        public async Task AddCategoryAsync(ProductViewModel products)
        {
            if (products.CategoresID == 1)
            {
                var result = new Beverages()
                {
                    Name = products.Name,
                    Quantity = products.Quantity,
                    Price = products.Price,


                };
                await DB.BeveragesCategories.AddAsync(result);
                await DB.SaveChangesAsync();
            }
            if (products.CategoresID == 2)
            {
                var result = new Fish()
                {
                    Name = products.Name,
                    Quantity = products.Quantity,
                    Price = products.Price,
                };
                await DB.FishCategories.AddAsync(result);
                await DB.SaveChangesAsync();
            }
            if (products.CategoresID == 3)
            {
                var result = new Meat()
                {
                    Name = products.Name,
                    Quantity = products.Quantity,
                    Price = products.Price,
                };
                await DB.MeatCategories.AddAsync(result);
                await DB.SaveChangesAsync();
            }
            if (products.CategoresID == 4)
            {
                var result = new Vegetables()
                {
                    Name = products.Name,
                    Quantity = products.Quantity,
                    Price = products.Price,
                };
                await DB.VegetablesCategories.AddAsync(result);
                await DB.SaveChangesAsync();
            }


        }
        public async Task DeleteCategoryAsync(int id, int forId)
        {
            if (forId == 1)
            {

                var category = await DB.BeveragesCategories.FirstOrDefaultAsync(x => x.Id == id);
                if (category != null)
                {
                    DB.BeveragesCategories.Remove(category);
                    await DB.SaveChangesAsync();

                }

            }
            if (forId == 2)
            {

                var category = await DB.FishCategories.FirstOrDefaultAsync(x => x.Id == id);
                if (category != null)
                {
                    DB.FishCategories.Remove(category);
                    await DB.SaveChangesAsync();

                }

            }
            if (forId == 3)
            {

                var category = await DB.MeatCategories.FirstOrDefaultAsync(x => x.Id == id);
                if (category != null)
                {
                    DB.MeatCategories.Remove(category);
                    await DB.SaveChangesAsync();

                }

            }
            if (forId == 4)
            {

                var category = await DB.VegetablesCategories.FirstOrDefaultAsync(x => x.Id == id);
                if (category != null)
                {
                    DB.VegetablesCategories.Remove(category);
                    await DB.SaveChangesAsync();

                }

            }

        }
        public ProductViewModel CreateModel(int id, int forId)
        {
            if (forId == 1)
            {
                var category = DB.BeveragesCategories.FirstOrDefault(x => x.Id == id);

                if (category != null)
                {
                    var product = new ProductViewModel()
                    {
                        CategoresID = 1,
                        Name = category.Name,
                        Quantity = category.Quantity,
                        Id = category.Id,
                        Price = category.Price,
                        CategoriesName = category.CategoriesName
                    };
                    return product;
                }
            }
            if (forId == 2)
            {
                var category = DB.FishCategories.FirstOrDefault(x => x.Id == id);

                if (category != null)
                {
                    var product = new ProductViewModel()
                    {
                        CategoresID = 2,
                        Name = category.Name,
                        Quantity = category.Quantity,
                        Id = category.Id,
                        Price = category.Price,
                        CategoriesName = category.CategoriesName
                    };
                    return product;
                }
            }
            if (forId == 3)
            {
                var category = DB.MeatCategories.FirstOrDefault(x => x.Id == id);

                if (category != null)
                {
                    var product = new ProductViewModel()
                    {
                        CategoresID = 3,
                        Name = category.Name,
                        Quantity = category.Quantity,
                        Id = category.Id,
                        Price = category.Price,
                        CategoriesName = category.CategoriesName
                    };
                    return product;
                }

            }
            if (forId == 4)
            {
                var category = DB.VegetablesCategories.FirstOrDefault(x => x.Id == id);

                if (category != null)
                {
                    var product = new ProductViewModel()
                    {
                        CategoresID = 4,
                        Name = category.Name,
                        Quantity = category.Quantity,
                        Id = category.Id,
                        Price = category.Price,
                        CategoriesName = category.CategoriesName
                    };
                    return product;
                }
            }
            return null!;

        }
        public async Task UpdateProductAsync(ProductViewModel product)
        {
            if (product.CategoresID == 1)
            {
                var result = new Beverages()
                {
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Id = product.Id,
                    Price = product.Price
                };
                DB.BeveragesCategories.Update(result);
                await DB.SaveChangesAsync();

            }
            if (product.CategoresID == 2)
            {
                var result = new Fish()
                {
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Id = product.Id,
                    Price = product.Price
                };
                DB.FishCategories.Update(result);
                await DB.SaveChangesAsync();

            }
            if (product.CategoresID == 3)
            {
                var result = new Meat()
                {
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Id = product.Id,
                    Price = product.Price
                };
                DB.MeatCategories.Update(result);
                await DB.SaveChangesAsync();

            }
            if (product.CategoresID == 4)
            {
                var result = new Vegetables()
                {
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Id = product.Id,
                    Price = product.Price
                };
                DB.VegetablesCategories.Update(result);
                await DB.SaveChangesAsync();

            }

        }
        public async Task<ProductViewModel> BuildingOrders( int count, string? name, double? price)
        {
            var product = new ProductViewModel()
            {
                Name = name,
                Count = count,
                Price = price
            };
            await DB.ClientsOrders.AddAsync(product);
            await DB.SaveChangesAsync();
            return product;
        }
        public async Task ChangeQuantity(int categoriesId, int id, int count)
        {
            if (categoriesId == 1)
            {
                var product = await DB.BeveragesCategories.FirstOrDefaultAsync(c => c.Id == id);
                if (product == null)
                {
                    throw new ArgumentException($"Элемент не найден.");
                }
                product.Quantity -= count;
                await DB.SaveChangesAsync();
            } if (categoriesId == 2)
            {
                var product = await DB.FishCategories.FirstOrDefaultAsync(c => c.Id == id);
                if (product == null)
                {
                    throw new ArgumentException($"Элемент не найден.");
                }
                product.Quantity -= count;
                await DB.SaveChangesAsync();
            } if (categoriesId == 3)
            {
                var product = await DB.MeatCategories.FirstOrDefaultAsync(c => c.Id == id);
                if (product == null)
                {
                    throw new ArgumentException($"Элемент не найден.");
                }
                product.Quantity -= count;
                await DB.SaveChangesAsync();
            } if (categoriesId == 4)
            {
                var product = await DB.VegetablesCategories.FirstOrDefaultAsync(c => c.Id == id);
                if (product == null)
                {
                    throw new ArgumentException($"Элемент не найден.");
                }
                product.Quantity -= count;
                await DB.SaveChangesAsync();
            }
            
        }

    }
}


