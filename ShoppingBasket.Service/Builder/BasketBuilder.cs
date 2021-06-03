using ShoppingBasket.Core;
using ShoppingBasket.Core.Builder;
using ShoppingBasket.Core.Factory;
using ShoppingBasket.Core.Models;
using ShoppingBasket.Core.Processor;
using ShoppingBasket.Core.Service;
using ShoppingBasket.Service.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Service.Builder
{
    public class BasketBuilder : IBasketBuilder
    {
        private Basket _basket;
        private readonly IBasketProcessorFactory _basketProcessorFactory;

        public BasketBuilder(   IBasketProcessorFactory basketProcessorFactory)
        {
             _basketProcessorFactory = basketProcessorFactory;
        }
        
        
        public IBasketBuilder CreateGiftVoucher( Basket basket  )
        {

           //IBasketProcessor basketProcessor = _basketProcessorFactory.CreateGiftVoucherProcessorFactory();
            //_basket = basketProcessor.Process(basket);
            _basket =  _basketProcessorFactory.CreateGiftVoucherProcessorFactory().Process(basket);
            return this;
        }

        public IBasketBuilder CreateOfferVoucher(Basket basket    )
        {
            
           _basket = _basketProcessorFactory.CreateOfferVoucherProcessorFactory().Process(basket);
            return this;
        }

        public IBasketBuilder CreateBasketItems( Basket basket   )
        {
            //_basket.BasketItems = basketItems;
            _basket = _basketProcessorFactory.CreateProductProcessorFactory().Process(basket);
            return this;
        }

        public Basket Build() {

            if (_basket.Total < 0)
            {
                _basket.Total = 0;
            }
            return _basket;
        }
    }
}
