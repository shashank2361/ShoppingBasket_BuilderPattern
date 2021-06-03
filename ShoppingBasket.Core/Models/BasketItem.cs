using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Core
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string BasketItemId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
