using ShoppingBasket.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Core.Processor
{
    public interface IBasketProcessor
    {
        Basket Process(Basket basket);
    }
}
