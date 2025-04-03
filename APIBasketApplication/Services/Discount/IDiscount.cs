using APIBasketApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace APIBasketApplication.Services.Discount
{
    public interface IDiscount
    {
        decimal ApplyDiscount(List<BasketItem> basket, StringBuilder receipt);
    }
}