using ShoppingBasket.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}