using ShoppingBasket.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Core
{
    public class OfferVoucher
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
        public bool CanBeAppliedToBasket { get; set; }
        public decimal Threshold { get; set; }
        public OfferVoucherType OfferVoucherType { get; set; }
        public Category ProductCategory { get; set; }
    }
}
