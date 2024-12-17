using Raketo.Model.Enums;

namespace Raketo.ViewModel
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Products Categorie { get; set; }
        public int Quantity { get; set; }
        public double? Price { get; set; }
    }

}    

