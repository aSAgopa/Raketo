﻿using Raketo.Model.Enums;
using System;
using System.Collections.Generic;
namespace Raketo.Model
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Products Category { get; set; }
        public int Quantity { get; set; }
        public double? Price { get; set; }
    }
}
