using Raketo.Interfaces;
namespace Raketo.Models
    
{
    public class Beverages : IProducts
    {
        public double? Price { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CategoriesName { get; set; } = "Beverages";
        public int Quantity { get; set; }
        public int CategoresID { get; set; } = 1;
        public int Count { get; set; }


    }
}
