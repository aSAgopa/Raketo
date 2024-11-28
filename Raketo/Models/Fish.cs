using Raketo.Interfaces;
namespace Raketo.Models
{
    public class Fish : IProducts
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? CategoriesName { get; set; } = "Fish Products";
        public int Quantity { get; set; }
        public double? Price { get; set; }
        public int CategoresID { get; set; } = 2;
        public int Count { get; set; }

    }
}
