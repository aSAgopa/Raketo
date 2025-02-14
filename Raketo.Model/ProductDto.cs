using Raketo.Model.Enums;

namespace Raketo.Model
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public Products Category { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
