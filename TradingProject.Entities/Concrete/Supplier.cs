﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Core.Entities;

namespace TradingProject.Entities.Concrete
{
    public class Supplier : User
    {
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public int NumberOfProducts { get; set; }

        public ICollection<Product> Products { get; set; }

        public Supplier()
        {

        }
    }
}
