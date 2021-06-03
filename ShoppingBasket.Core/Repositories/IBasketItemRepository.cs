using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Core.Repositories
{
    public interface IBasketItemRepository
    {
        IEnumerable<BasketItem> GetBasketItems();
        BasketItem GetBasketItem(int id);
    }
}
