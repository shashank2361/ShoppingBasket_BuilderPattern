using ShoppingBasket.Core.Processor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Core.Factory
{
    public interface  IBasketProcessorFactory
    {
        IBasketProcessor   CreateGiftVoucherProcessorFactory();
        IBasketProcessor   CreateOfferVoucherProcessorFactory();
        IBasketProcessor   CreateProductProcessorFactory();
    }
}
