using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Core.Repositories
{
    public interface IOfferVoucherRepository
    {
        IEnumerable<OfferVoucher> GetOffVouchers();
        OfferVoucher GetOffVoucher(int id);
    }
}