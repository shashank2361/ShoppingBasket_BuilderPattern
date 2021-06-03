using ShoppingBasket.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Core.Builder
{
    public interface  IBasketBuilder
    {

        IBasketBuilder CreateGiftVoucher(Basket basket );
        IBasketBuilder CreateOfferVoucher(Basket basket );
        IBasketBuilder CreateBasketItems(Basket basket );
        

    }
}
