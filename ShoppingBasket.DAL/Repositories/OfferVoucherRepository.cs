using ShoppingBasket.Core;
using ShoppingBasket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.DAL.Repositories
{
    public class OfferVoucherRepository : IOfferVoucherRepository
    {
        private readonly IEnumerable<OfferVoucher> _offerVouchers;

        public OfferVoucherRepository( )
        {
            _offerVouchers = new List<OfferVoucher>
            {
                new OfferVoucher
                {
                    Id = 1,
                    Code = "YYY-YYY",
                    Value = 5.00m,
                    Threshold = 50m,
                    OfferVoucherType = OfferVoucherType.Product,
                    ProductCategory = Category.HeadGear
                },
                new OfferVoucher
                {
                    Id = 2,
                    Code = "YYY-YYY",
                    Value = 5.00m,
                    Threshold = 50m,
                    OfferVoucherType = OfferVoucherType.Basket
                }

            };
            ;


        }


        public OfferVoucher GetOffVoucher(int id)
        {
                return _offerVouchers.FirstOrDefault(x => x.Id == id);        }

        public IEnumerable<OfferVoucher> GetOffVouchers()
        {
                return _offerVouchers;        
        }
    }
}
