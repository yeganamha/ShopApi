﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product:BaseEntity
    {
        
        public string? Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }

    }
}