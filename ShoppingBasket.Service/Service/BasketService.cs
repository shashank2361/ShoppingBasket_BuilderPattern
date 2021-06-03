using ShoppingBasket.Core;
using ShoppingBasket.Core.Models;
using ShoppingBasket.Core.Responses;
using ShoppingBasket.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Service.Service
{
    public class BasketService : IBasketService
    {

    
        public Basket EmptyBasketItems(Basket _basket)
        {
            _basket.BasketItems.Clear();
             
            return _basket;
        }


        public IEnumerable<BasketItem> GetBasketItems( Basket _basket)
        {
            return _basket.BasketItems;
        }


        public Basket AddtemToBasket(Product product , Basket _basket)
        {
            var basketItem = _basket.BasketItems?.FirstOrDefault(x => x.Product.Id == product.Id);

            if (basketItem != null)
                basketItem.Quantity++;
            else
            {
                

                 _basket.BasketItems.Add(new BasketItem
                {
                    BasketItemId = GetBasketItemId(),
                    Product = product,
                    Quantity = 1
                });
                //_basket.BasketItems = basketItems;

            }



            return _basket;
        }

        private static string GetBasketItemId()
        {
            return Guid.NewGuid().ToString();
        }


        public BasketServiceResponse GetBasketTotal(Basket _basket)
        {
            try
            {
                if ( !_basket.BasketItems.Any())

                    return new BasketServiceResponse()
                    {
                        Notifications = new List<string> { "Your shopping basket is empty" },
                        Success = true,
                        BasketTotal = 0.0m
                    };


                 

                return new BasketServiceResponse
                {
                     Notifications = _basket.Messages?.ToList(),
                    BasketTotal = _basket.Total,
                    Success = _basket.Messages.Count() > 0 ? false :true
                };


            }
            catch (Exception exception)
            {
                return new BasketServiceResponse
                {
                    ErrorMessage = $"Failed to calculate basket total {exception.Message}",
                    Success = false,
                    BasketTotal = 0.0m
                };
            }

        }
    }

}
 
