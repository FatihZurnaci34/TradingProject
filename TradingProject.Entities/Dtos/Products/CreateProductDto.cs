﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingProject.Entities.Dtos.Products
{
    public class CreateProductDto
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int SubcategoryId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
    }
}
