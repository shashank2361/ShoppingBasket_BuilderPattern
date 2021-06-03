 
using ShoppingBasket.Core.Models;
using ShoppingBasket.Core.Processor;
using ShoppingBasket.Core.Service;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShoppingBasket.Core;

namespace ShoppingBasket.Service.Processor
{
    public class OfferVoucherProcessor : IBasketProcessor
    {
 
        private bool _isOfferApplied;

 
        public Basket Process(Basket basket)
        {
 
            if (basket.OfferVoucher == null)
                return basket;

            basket = ValidateOfferVoucherForThreshold(basket);



            if (!BasketHasErrors(basket) && basket.OfferVoucher.OfferVoucherType == OfferVoucherType.Basket)
            {
                basket.Total = basket.Total - basket.OfferVoucher.Value;
                _isOfferApplied = true;
            }

            if (!BasketHasErrors(basket) && !_isOfferApplied && basket.OfferVoucher.OfferVoucherType == OfferVoucherType.Product)
            {
                basket.Total = ValidateOfferVoucherForProducts(basket).Total;
            }

            if (!BasketHasErrors(basket) && !_isOfferApplied)
            {
                basket.Messages.Add($"There are no products in your basket applicable to voucher Voucher {basket.OfferVoucher.Code}.");
            }

            return basket;


        }

        private  Basket ValidateOfferVoucherForThreshold(Basket basket)
        {
            
            var basketsTotal =  basket.BasketItems.Where (x => x.Product.Category != Category.GiftVoucher).Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);
            //var basketsTotal = _basketService.GetBasketItems(basket).Where (x => x.Product.Category != Category.GiftVoucher).Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);

            if (basketsTotal < basket.OfferVoucher.Threshold)
            {
                var additonalAmountToSpend = basket.OfferVoucher.Threshold - basketsTotal + 0.01m;
                basket.Messages.Add($"You have not reached the spend threshold for voucher {basket.OfferVoucher.Code}. Spend another £{additonalAmountToSpend} to receive £{basket.OfferVoucher.Value} discount from your basket total.");
                basketsTotal = basket.Total;
                
                
            }

            basket.Total = basketsTotal;

            return basket;
        }

        private Basket ValidateOfferVoucherForProducts(Basket basket)
        {
            var basketsTotal = 0.00m;


           // foreach (var basketItem in _basketService.GetBasketItems(basket))
            foreach (var basketItem in basket.BasketItems)
            {
                if (basketItem.Product.Category == basket.OfferVoucher.ProductCategory && !_isOfferApplied)
                {
                    _isOfferApplied = true;
                    var productPrice = basketItem.Product.Price * basketItem.Quantity;
                    productPrice -= basket.OfferVoucher.Value;
                    productPrice = productPrice >= 0 ? productPrice : 0m;
                    basketsTotal += productPrice;
                }
                else
                {
                    basketsTotal += basketItem.Product.Price  * basketItem.Quantity;
                }
            }

            basket.Total = basketsTotal;
            return basket;
        }


        private static bool BasketHasErrors(Basket basket)
        {
            return basket.Messages.Count > 0;
        }


    }
}
