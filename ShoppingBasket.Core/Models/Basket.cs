using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ShoppingBasket.Core.Models
{
    public class Basket
    {
     
        public List<BasketItem> BasketItems { get; set; } 
        public List<GiftVoucher> GiftVouchers { get; set; }
        public OfferVoucher OfferVoucher { get; set; }
        public IList<string> Messages { get; set; } = new List<string>();
        public decimal Total { get; set; }

        public Basket()
        {
            BasketItems = new List<BasketItem>();
            GiftVouchers = new List<GiftVoucher>();
        }
    }
}
