using APIBasketApplication.Services.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingBasket.API.Services.Discount
{
    public static class DiscountFactory
    {
        public static List<IDiscount> GetDiscounts()
        {
            return new List<IDiscount>
            {
                new ApplesDiscount(),
                new BreadDiscount()
            };
        }
    }
}
