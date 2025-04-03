
using APIBasketApplication.Models;
using ShoppingBasket.API.Services.Discount;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.API.Services
{
    public class BasketProcessor
    {
        public static readonly Dictionary<string, decimal> Prices = new Dictionary<string, decimal>
        {
            {"Soup", 0.65m},
            {"Bread", 0.80m},
            {"Milk", 1.30m},
            {"Apples", 1.00m}
        };

        public string GenerateReceipt(List<BasketItem> basket)
        {
            decimal total = 0;
            decimal discount = 0;
            StringBuilder receipt = new StringBuilder("Receipt:\n");

            foreach (var item in basket)
            {
                if (!Prices.TryGetValue(item.Name, out decimal price))
                {
                    receipt.AppendLine($"Unknown item: {item.Name}");
                    continue;
                }

                decimal itemTotal = price * item.Quantity;
                receipt.AppendLine($"{item.Name} x{item.Quantity}: €{itemTotal:F2}");
                total += itemTotal;
            }

            var discounts = DiscountFactory.GetDiscounts();
            foreach (var discountStrategy in discounts)
            {
                discount += discountStrategy.ApplyDiscount(basket, receipt);
            }

            total -= discount;
            receipt.AppendLine($"Total: €{total:F2}");
            return receipt.ToString();
        }
    }
}
