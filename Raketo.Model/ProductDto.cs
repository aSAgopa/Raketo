using Raketo.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raketo.Model
{
    internal class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Products Categorie { get; set; }
        public int Quantity { get; set; }
        public double? Price { get; set; }
    }
}
