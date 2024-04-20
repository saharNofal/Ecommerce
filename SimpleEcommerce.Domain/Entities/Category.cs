﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; }

    }
}
