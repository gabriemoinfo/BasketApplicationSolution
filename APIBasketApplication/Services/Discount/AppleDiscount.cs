using APIBasketApplication.Models;
using ShoppingBasket.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace APIBasketApplication.Services.Discount
{
    public class ApplesDiscount : IDiscount
    {
        public decimal ApplyDiscount(List<BasketItem> basket, StringBuilder receipt)
        {
            var apples = basket.FirstOrDefault(i => i.Name == "Apples");
            if (apples != null)
            {
                decimal discount = apples.Quantity * BasketProcessor.Prices["Apples"] * 0.10m;
                receipt.AppendLine($"Discount on Apples: -€{discount:F2}");
                return discount;
            }
            return 0;
        }
    }
}