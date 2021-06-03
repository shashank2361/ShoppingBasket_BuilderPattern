using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Core.Responses
{
    public class BasketServiceResponse
    {
        public List<string> Notifications { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public decimal BasketTotal { get; set; }
    }
}
