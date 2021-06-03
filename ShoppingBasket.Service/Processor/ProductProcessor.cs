using ShoppingBasket.Core.Models;
using ShoppingBasket.Core.Processor;
using ShoppingBasket.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Service.Processor
{

    public class ProductProcessor : IBasketProcessor
    {


    public Basket Process(Basket basket)
        {
            basket.Total = basket.BasketItems.Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);
           // basket.Total = _basketService.GetBasketItems(basket).Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);
            return basket;
        }
    }
}
