using ShoppingBasket.Core.Factory;
using ShoppingBasket.Core.Processor;
using ShoppingBasket.Core.Service;
using ShoppingBasket.Service.Processor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Service.Factory
{
    public class BasketProcessorFactory : IBasketProcessorFactory
    {        
        public IBasketProcessor CreateGiftVoucherProcessorFactory()
        { 
            return new GiftVoucherProcessor(); 
        }

        public IBasketProcessor CreateOfferVoucherProcessorFactory()
        {
            return new OfferVoucherProcessor();
        }

        public IBasketProcessor CreateProductProcessorFactory()
        {
            return new ProductProcessor( );
        }

    }
}
