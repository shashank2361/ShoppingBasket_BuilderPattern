using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Core.Repositories
{
    public interface IGiftVoucherRepository
    {
        IEnumerable<GiftVoucher> GetGiftVouchers();
        GiftVoucher GetGiftVoucher(int id);
    }
}
