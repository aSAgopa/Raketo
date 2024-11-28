using Raketo.Interfaces;
namespace Raketo.Models
{
    public class Meat : IProducts
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CategoriesName { get; set; } = "Meat Products";
        public int Quantity { get; set; }
        public double? Price { get; set; }
        public int CategoresID { get; set; } = 3;
        public int Count { get; set; }
    }
}
