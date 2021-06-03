using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
    }
}
