using ShoppingBasket.Core;
using ShoppingBasket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.DAL.Repositories
{
    public class GiftVoucherRepository : IGiftVoucherRepository
    {
        private IEnumerable<GiftVoucher> _giftVouchers;


        public GiftVoucherRepository()
        {
            _giftVouchers = new List<GiftVoucher>
            {
                new GiftVoucher {Id = 1,Code = "XXX-XXX", Value = 5m},
                new GiftVoucher {Id = 2,Code = "XXX-XXX", Value = 30m}
            };
        }
        public GiftVoucher GetGiftVoucher(int id)
        {
            return _giftVouchers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GiftVoucher> GetGiftVouchers()
        {
            return _giftVouchers;
        }
    }
}
