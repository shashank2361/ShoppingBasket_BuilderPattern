using ShoppingBasket.Core;
using ShoppingBasket.Core.Models;
using ShoppingBasket.Core.Processor;
using ShoppingBasket.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Service.Processor
{
    public class GiftVoucherProcessor : IBasketProcessor
    {
        public Basket Process(Basket basket)
        {



            if (basket.GiftVouchers != null && basket.GiftVouchers.Any())
            {
                var totalExlucdegiftVoutcher = basket.BasketItems.Where( x=>x.Product.Category != Category.GiftVoucher).Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);
                totalExlucdegiftVoutcher -= basket.GiftVouchers.Sum(x => x.Value);
                if (totalExlucdegiftVoutcher < 0)
                {
                        totalExlucdegiftVoutcher += basket.GiftVouchers.Sum(x => x.Value);
                }
                else
                {
                    totalExlucdegiftVoutcher = basket.GiftVouchers.Sum(x => x.Value);
                }

                basket.Total -= totalExlucdegiftVoutcher;
                //if (basket.Total > basket.GiftVouchers.Sum(x => x.Value))
                //{

                //}
                //basket.Total -= basket.GiftVouchers.Sum(x => x.Value);
               
            }
             return basket;
        }
    }
}
