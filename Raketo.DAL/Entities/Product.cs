using Raketo.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raketo.DAL.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public Products Category { get; set; }
        public int Quantity { get; set; }
        public double? Price { get; set; }
        
    }
}
