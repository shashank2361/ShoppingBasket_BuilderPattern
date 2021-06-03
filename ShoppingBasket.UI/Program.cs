using Microsoft.Extensions.DependencyInjection;
using ShoppingBasket.Core.Builder;
using ShoppingBasket.Core.Factory;
using ShoppingBasket.Core.Processor;
using ShoppingBasket.Core.Repositories;
using ShoppingBasket.Core.Service;
using ShoppingBasket.DAL.Repositories;
using ShoppingBasket.Service.Builder;
using ShoppingBasket.Service.Factory;
using ShoppingBasket.Service.Processor;
using ShoppingBasket.Service.Service;
using System;

namespace ShoppingBasket.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

             var services = ConfigureServices();
             var serviceProvider = services.BuildServiceProvider();
                serviceProvider.GetService<BasketConsole>().Run().Wait();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            //var config = LoadConfiguration();
            //services.AddSingleton(config);



            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IGiftVoucherRepository,   GiftVoucherRepository>();
            services.AddScoped<IOfferVoucherRepository,  OfferVoucherRepository>();
            services.AddScoped<IBasketItemRepository , BasketItemRepository   >();
             services.AddScoped<IBasketBuilder ,  BasketBuilder   >();
            
            services.AddScoped< IBasketProcessor , GiftVoucherProcessor   >();
            services.AddScoped< IBasketProcessor , OfferVoucherProcessor   >();
            services.AddScoped< IBasketProcessor , ProductProcessor   >();
            services.AddScoped< IBasketProcessorFactory , BasketProcessorFactory   >();
            services.AddScoped<IBasketService,  BasketService>();
            services.AddTransient<BasketConsole>();


            return services;

        }

    }
}
