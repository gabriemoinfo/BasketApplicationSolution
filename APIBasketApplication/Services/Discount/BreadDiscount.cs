using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using APIBasketApplication.Models;

namespace APIBasketApplication.Services.Discount
{
    public class BreadDiscount : IDiscount
    {
        public decimal ApplyDiscount(List<BasketItem> basket, StringBuilder receipt)
        {
            throw new NotImplementedException();
        }
    }
}