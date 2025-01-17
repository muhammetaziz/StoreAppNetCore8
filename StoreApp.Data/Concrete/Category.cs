﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }= string.Empty;
        public string Url { get; set; }=string.Empty ;// Arama Yapma için.
        public List<Product> Products { get; set; } = new();
    }
}
