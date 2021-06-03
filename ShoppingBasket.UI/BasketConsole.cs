using ShoppingBasket.Core.Builder;
using ShoppingBasket.Core.Factory;
using ShoppingBasket.Core.Models;
using ShoppingBasket.Core.Repositories;
using ShoppingBasket.Core.Service;
using ShoppingBasket.Service.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.UI
{
    public class BasketConsole
    {
        private readonly IBasketBuilder basketBuilder;
        private readonly IBasketProcessorFactory basketProcessorFactory;
        private readonly IBasketService basketService;
        private readonly IProductRepository productRepository;
        private readonly IGiftVoucherRepository giftVoucherRepository;
        private readonly IOfferVoucherRepository offerVoucherRepository;

        public BasketConsole(IBasketBuilder basketBuilder , IBasketProcessorFactory basketProcessorFactory , IBasketService basketService , IProductRepository productRepository ,
            IGiftVoucherRepository giftVoucherRepository , IOfferVoucherRepository offerVoucherRepository)
        {
            this.basketBuilder = basketBuilder;
            this.basketProcessorFactory = basketProcessorFactory;
            this.basketService = basketService;
            this.productRepository = productRepository;
            this.giftVoucherRepository = giftVoucherRepository;
            this.offerVoucherRepository = offerVoucherRepository;
        }

        public async Task Run( )
        {
            Console.WriteLine("Shopping basket");
            ConsoleSetup(1);
            
            // Basket 1:
             var builder = new  BasketBuilder(basketProcessorFactory);
           // Scenario1(builder);

            var shoppingBasket = new Basket();

            Console.WriteLine($"Basket1 - Add   { productRepository.GetProduct(2).Name} ");
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(2), shoppingBasket);
            Console.WriteLine($"Basket1 - Add   { productRepository.GetProduct(5).Name} ");
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(5), shoppingBasket);
            builder.CreateBasketItems(shoppingBasket);

            shoppingBasket = builder.Build();
            Console.WriteLine($"Basket1 - Total : £{shoppingBasket.Total}");
            Console.WriteLine("No vouchers applied");
 
            
            var basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);
            Console.WriteLine($"Basket1 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket1 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");
 
            //.
            // Basket 2:
            ConsoleSetup(2);


           // Scenario2(builder);

              

            shoppingBasket = new Basket();


            Console.WriteLine($"Basket2 - Add   { productRepository.GetProduct(1).Name} ");
              Console.WriteLine($"Basket2 - Add   { productRepository.GetProduct(2).Name} ");
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(1), shoppingBasket);          
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(2), shoppingBasket);

            builder.CreateBasketItems(shoppingBasket);
            shoppingBasket = builder.Build();

            Console.WriteLine($"Basket2 - Total : £{shoppingBasket.Total}");

            Console.WriteLine($"Basket2 - gift voucher { giftVoucherRepository.GetGiftVoucher(1).Code} applied " );
            var giftVoucher = giftVoucherRepository.GetGiftVoucher(1);
            shoppingBasket.GiftVouchers.Add(giftVoucher);

            builder.CreateOfferVoucher(shoppingBasket).CreateGiftVoucher(shoppingBasket);

            shoppingBasket = builder.Build();


            basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);
            Console.WriteLine($"Basket2 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket2 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");


 


            // Basket 3:

            ConsoleSetup(3);
      

              shoppingBasket = new Basket();

            Console.WriteLine($"Basket3 - Add   { productRepository.GetProduct(7).Name} ");
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(7), shoppingBasket);

            Console.WriteLine($"Basket3 - Add   { productRepository.GetProduct(4).Name} ");
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(4), shoppingBasket);
            builder.CreateBasketItems(shoppingBasket);
            Console.WriteLine($"Basket3 - Total : £{shoppingBasket.Total}");
            var offerVoucher = offerVoucherRepository.GetOffVoucher(1);
            Console.WriteLine($"Basket3 - offer voucher   { offerVoucherRepository.GetOffVoucher(1).Code} applied ");

            shoppingBasket.OfferVoucher = offerVoucher;
            builder.CreateOfferVoucher(shoppingBasket).CreateGiftVoucher(shoppingBasket);

            shoppingBasket = builder.Build();
 
            basketService.GetBasketTotal(shoppingBasket);
            basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);
            Console.WriteLine($"Basket3 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket3 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

 


            // Basket 4:
            ConsoleSetup(3);
 
              shoppingBasket = new Basket();


            Console.WriteLine($"Basket4 - Add   { productRepository.GetProduct(7).Name} ");
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(7), shoppingBasket);

            Console.WriteLine($"Basket4 - Add   { productRepository.GetProduct(4).Name} ");
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(4), shoppingBasket);

            Console.WriteLine($"Basket4 - Add   { productRepository.GetProduct(5).Name} ");
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(5), shoppingBasket);
            builder.CreateBasketItems(shoppingBasket);
            Console.WriteLine($"Basket4 - Total : £{shoppingBasket.Total}");


            offerVoucher = offerVoucherRepository.GetOffVoucher(1);
            Console.WriteLine($"Basket4 - offer Voucher { offerVoucherRepository.GetOffVoucher(1).Code} applied ");

            shoppingBasket.OfferVoucher = offerVoucher;

            builder.CreateOfferVoucher(shoppingBasket).CreateGiftVoucher(shoppingBasket);

            shoppingBasket = builder.Build();

            basketService.GetBasketTotal(shoppingBasket);
            basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);
            Console.WriteLine($"Basket4 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket4 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

 


            // Basket 5:
            ConsoleSetup(5);
            shoppingBasket = new Basket();
            Console.WriteLine($"Basket5 - Add   { productRepository.GetProduct(7).Name} ");
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(7), shoppingBasket);
            Console.WriteLine($"Basket5 - Add   { productRepository.GetProduct(4).Name} ");
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(4), shoppingBasket);
            builder.CreateBasketItems(shoppingBasket);
            Console.WriteLine($"Basket5 - Total : £{shoppingBasket.Total}");
            giftVoucher = giftVoucherRepository.GetGiftVoucher(1);
            Console.WriteLine($"Basket5 - Gift Voucher { giftVoucherRepository.GetGiftVoucher(1).Code}  applied ");
            shoppingBasket.GiftVouchers.Add(giftVoucher);
            offerVoucher = offerVoucherRepository.GetOffVoucher(2);
            Console.WriteLine($"Basket5 - Offer Voucher { offerVoucherRepository.GetOffVoucher(2).Code} applied ");
            shoppingBasket.OfferVoucher = offerVoucher;
            builder.CreateOfferVoucher(shoppingBasket).CreateGiftVoucher(shoppingBasket);
            shoppingBasket = builder.Build();
            basketService.GetBasketTotal(shoppingBasket);
            basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);
            Console.WriteLine($"Basket5 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket5 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

 

            // Basket 6:
            ConsoleSetup(6);
        
            shoppingBasket = new Basket();
            Console.WriteLine($"Basket6 - Add   { productRepository.GetProduct(7).Name} ");
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(7), shoppingBasket);
            Console.WriteLine($"Basket6 - Add   { productRepository.GetProduct(6).Name} ");
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(6), shoppingBasket);
            builder.CreateBasketItems(shoppingBasket);
            Console.WriteLine($"Basket6 - Total : £{shoppingBasket.Total}");
            offerVoucher = offerVoucherRepository.GetOffVoucher(1);
            Console.WriteLine($"Basket6 - offer voucher Add   { offerVoucherRepository.GetOffVoucher(1).Code} ");
            shoppingBasket.OfferVoucher = offerVoucher;
            builder.CreateOfferVoucher(shoppingBasket).CreateGiftVoucher(shoppingBasket);
            shoppingBasket = builder.Build();
            basketService.GetBasketTotal(shoppingBasket);
            basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);
            Console.WriteLine($"Basket6 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket6 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

 

            // Basket 7:
            ConsoleSetup(7); 
            shoppingBasket = new Basket();
            Console.WriteLine($"Basket7 - Add   { productRepository.GetProduct(7).Name} ");
            shoppingBasket = basketService.AddtemToBasket(productRepository.GetProduct(7), shoppingBasket);
            builder.CreateBasketItems(shoppingBasket);
            Console.WriteLine($"Basket7 - Total : £{shoppingBasket.Total}");
            giftVoucher = giftVoucherRepository.GetGiftVoucher(2);
            shoppingBasket.GiftVouchers.Add(giftVoucher);
            Console.WriteLine($"Basket7 - Gift Voucher Add   { giftVoucher.Code} applied");

            builder.CreateGiftVoucher(shoppingBasket);

            shoppingBasket = builder.Build();
            basketService.GetBasketTotal(shoppingBasket);
            basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);
            Console.WriteLine($"Basket7 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket7 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

            shoppingBasket = basketService.EmptyBasketItems(shoppingBasket);

            await Task.CompletedTask;


        }



        private void ConsoleSetup(int scenarioId)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"******** {scenarioId} ******************");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}