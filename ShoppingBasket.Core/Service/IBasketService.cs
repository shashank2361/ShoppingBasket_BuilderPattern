using ShoppingBasket.Core.Models;
using ShoppingBasket.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Core.Service
{
    public interface IBasketService
    {

        IEnumerable<BasketItem> GetBasketItems(Basket _basket);
        Basket AddtemToBasket(Product product , Basket _basket);
        Basket EmptyBasketItems(Basket _basket);
        BasketServiceResponse GetBasketTotal(Basket _basket);
    }
}
