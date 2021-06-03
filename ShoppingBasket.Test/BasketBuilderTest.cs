using Moq;
using ShoppingBasket.Core;
using ShoppingBasket.Core.Builder;
using ShoppingBasket.Core.Factory;
using ShoppingBasket.Core.Models;
using ShoppingBasket.Core.Repositories;
using ShoppingBasket.Core.Service;
using ShoppingBasket.Service.Builder;
using ShoppingBasket.Service.Factory;
using ShoppingBasket.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ShoppingBasket.Test
{
    public class BasketBuilderTest
    {

        Basket shoppingBasket; 
        List<BasketItem>  _basketItems = new List<BasketItem>();
        private readonly IBasketBuilder builder;
        private readonly IBasketProcessorFactory basketProcessorFactory;
        private readonly IBasketService basketService;
        private readonly IProductRepository productRepository;
        private readonly IGiftVoucherRepository giftVoucherRepository;
        private readonly IOfferVoucherRepository offerVoucherRepository;
 
        public BasketBuilderTest()
        {
            _basketItems = new List<BasketItem>
            {
                new BasketItem
                {
                    Id = 1,
                    Product = new Product {Id =3,Name ="Hat",Price=25.00m,Category = Category.Clothes },
                    Quantity = 1
                },
                new BasketItem
                {
                    Id = 2,
                    Product = new Product {Id =5,Name ="Head Light",Price=3.50m,Category = Category.HeadGear },
                    Quantity = 1
                },
                new BasketItem
                {
                    Id = 3,
                    Product =   new Product {Id =7,Name ="Gloves",Price=25.00m,Category = Category.Gloves},
                    Quantity = 6

                },
            };
              shoppingBasket = new Basket();
              shoppingBasket.BasketItems = _basketItems;

            basketProcessorFactory = new BasketProcessorFactory();
            basketService = new BasketService();
          
        }
        [Fact]
        public void CreateProductBasket_NoVouchers_CheckTotals ()
        {

            //Arrange           
          
            var totalBasket = shoppingBasket.BasketItems.Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);
            var builder = new  BasketBuilder(basketProcessorFactory);
       
            //Act
            builder.CreateBasketItems(shoppingBasket);
            shoppingBasket = builder.Build();


            var basketServiceResponse =  basketService.GetBasketTotal(shoppingBasket);

            //Assert 
            Assert.Equal(totalBasket, shoppingBasket.Total);
            Assert.Equal(totalBasket, basketServiceResponse.BasketTotal);


        }

        [Fact]
        public void CreateProductBasket_ApplyOneGifTVoucher_CheckTotals()
        {
            //Arrange
            var totalBasket = shoppingBasket.BasketItems.Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);
            var giftVoucher = new GiftVoucher { Id = 1, Code = "XXX-XXX", Value = 15m };
            shoppingBasket.GiftVouchers.Add(giftVoucher);
            var totalafterApplyingGiftVoucher = totalBasket - giftVoucher.Value;    

            //Act
            var builder = new BasketBuilder(basketProcessorFactory) ;
            builder.CreateBasketItems(shoppingBasket).CreateGiftVoucher(shoppingBasket);
            shoppingBasket = builder.Build();
            var basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);
            //Assert 
          
            Assert.Equal(totalafterApplyingGiftVoucher, basketServiceResponse.BasketTotal);


        }


        [Fact]
        public void CreateProductBasket_ApplyMultiGifTVoucher_CheckTotals()
        {
            //Arrange
            var totalBasket = shoppingBasket.BasketItems.Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);
            var _giftVouchers = new List<GiftVoucher>
            {
                new GiftVoucher {Id = 1,Code = "XXX-XXX", Value = 5m},
                new GiftVoucher {Id = 2,Code = "XXX-XXX", Value = 30m}
            };
            shoppingBasket.GiftVouchers = _giftVouchers;

            var totalafterApplyingGiftVoucher = totalBasket - _giftVouchers.Sum(x => x.Value);

            //Act
            var builder = new BasketBuilder(basketProcessorFactory);
            builder.CreateBasketItems(shoppingBasket).CreateGiftVoucher(shoppingBasket);
            shoppingBasket = builder.Build();
            var basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);
            //Assert 

            Assert.Equal(totalafterApplyingGiftVoucher, basketServiceResponse.BasketTotal);


        }



        [Fact]
        public void CreateProductBasketOfGifTVoucher_ApplyGifTVoucher_CheckTotals()
        {
            //Arrange
            var _basketItems = new List<BasketItem>
            {
                new BasketItem
                {
                    Id = 1,
                    Product = new Product {Id =6,Name ="Gift Voucher",Price=30.00m,Category = Category.GiftVoucher},
                    Quantity = 2
                },
                new BasketItem
                {
                    Id = 2,
                    Product = new Product {Id =5,Name ="Head Light",Price=3.50m,Category = Category.HeadGear },
                    Quantity = 1
                }
            };
            var _giftVouchers = new List<GiftVoucher>
            {
                new GiftVoucher {Id = 1,Code = "XXX-XXX", Value = 5m},

            };
            shoppingBasket.BasketItems = _basketItems;
            shoppingBasket.GiftVouchers = _giftVouchers;


            var totalBasket = shoppingBasket.BasketItems.Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);
           
 
 
            //Act
            var builder = new BasketBuilder(basketProcessorFactory);
            builder.CreateBasketItems(shoppingBasket).CreateGiftVoucher(shoppingBasket);
            shoppingBasket = builder.Build();
            var basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);
            //Assert 

            Assert.Equal(60m, basketServiceResponse.BasketTotal);


        }

        [Fact]
        public void CreateProductBasketAboveThreshold_ApplyOfferVoucher_CheckTotals()
        {
            //Arrange
            var totalBasket = shoppingBasket.BasketItems.Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);

            var offerVoucher = new OfferVoucher
            {
                Id = 1,
                Code = "YYY-YYY",
                Value = 5.00m,
                Threshold = 50m,
                OfferVoucherType = OfferVoucherType.Product,
                ProductCategory = Category.Gloves
            };

            shoppingBasket.OfferVoucher = offerVoucher;

            var totalBasketaftervoucher = totalBasket - offerVoucher.Value;
            //Act
            var builder = new BasketBuilder(basketProcessorFactory);
            builder.CreateBasketItems(shoppingBasket).CreateOfferVoucher(shoppingBasket);
            shoppingBasket = builder.Build();
            var basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);
            //Assert 

            Assert.Equal(totalBasketaftervoucher, basketServiceResponse.BasketTotal);


        }

        [Fact]
        public void CreateProductBasketBelowThreshold_ApplyOfferVoucher_CheckTotals()
        {
            //Arrange

           var _basketItems = new List<BasketItem>
            {
                new BasketItem
                {
                    Id = 1,
                    Product = new Product {Id =3,Name ="Hat",Price=25.00m,Category = Category.Clothes },
                    Quantity = 1
                },
                new BasketItem
                {
                    Id = 2,
                    Product = new Product {Id =5,Name ="Head Light",Price=3.50m,Category = Category.HeadGear },
                    Quantity = 1
                },
                new BasketItem
                {
                    Id = 3,
                    Product =   new Product {Id =7,Name ="Gloves",Price=15.00m,Category = Category.Gloves},
                    Quantity = 1

                },
            };
            var totalBasket = shoppingBasket.BasketItems.Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);

            var offerVoucher = new OfferVoucher
            {
                Id = 1,
                Code = "YYY-YYY",
                Value = 5.00m,
                Threshold = 50m,
                OfferVoucherType = OfferVoucherType.Product,
                ProductCategory = Category.Gloves
            };

            shoppingBasket.OfferVoucher = offerVoucher;
            shoppingBasket.BasketItems = _basketItems;

            var totalBasketaftervoucher = totalBasket - offerVoucher.Value;
            //Act
            var builder = new BasketBuilder(basketProcessorFactory);
            builder.CreateBasketItems(shoppingBasket).CreateOfferVoucher(shoppingBasket);
            shoppingBasket = builder.Build();
            var basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);
            //Assert 

            Assert.False( basketServiceResponse.Success);
            Assert.True( basketServiceResponse.Notifications != null );


        }



    }
}
