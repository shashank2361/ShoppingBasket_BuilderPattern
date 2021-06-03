using ShoppingBasket.Core;
using ShoppingBasket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.DAL.Repositories
{
    public class BasketItemRepository : IBasketItemRepository
    {
        private IEnumerable<BasketItem> _basketItems;


        private readonly IProductRepository _productRepository;

        public BasketItemRepository(IProductRepository productRepository)
        {

            _productRepository = productRepository;
            _basketItems = new List<BasketItem>
            {
                new BasketItem
                {
                    Id = 1,
                    Product = _productRepository.GetProduct(1),
                    Quantity = 1

                },
                new BasketItem
                {
                    Id = 2,
                    Product = new Product {Id =3,Name ="Hat",Price=25.00m,Category = Category.Clothes },

                    Quantity = 3

                },
                new BasketItem
                {
                    Id = 3,
                    Product = _productRepository.GetProduct(7),

                    Quantity = 6

                },
            };


        }

        public IEnumerable<BasketItem> GetBasketItems()
        {
            return _basketItems;
        }

        public BasketItem GetBasketItem(int id)
        {
            return _basketItems.FirstOrDefault(x => x.Id == id);
        }
    }
}
