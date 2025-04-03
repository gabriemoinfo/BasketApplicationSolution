
using ShoppingBasket.API.Services;
using System.Collections.Generic;
using APIBasketApplication.Models;
using NUnit.Framework;

namespace APIBasketApplication.Tests.Services
{
    [TestFixture]
    public class BasketProcessorTests
    {
        private BasketProcessor _basketProcessor;

        [SetUp]
        public void SetUp()
        {
            _basketProcessor = new BasketProcessor();
        }

        [Test]
        public void GenerateReceipt_ShouldCalculateTotalPriceCorrectly()
        {
            // Arrange
            var basket = new List<BasketItem>
            {
                new BasketItem { Name = "Soup", Quantity = 2 },
                new BasketItem { Name = "Bread", Quantity = 1 },
                new BasketItem { Name = "Apples", Quantity = 1 }
            };

            // Act
            var receipt = _basketProcessor.GenerateReceipt(basket);

            // Assert
            Assert.IsTrue(receipt.Contains("Total: €2.60"), "The total price should be €2.60");
            Assert.IsTrue(receipt.Contains("Soup x2: €1.30"), "The total for Soup should be €1.30");
            Assert.IsTrue(receipt.Contains("Discount on Apples: -€0.10"), "The discount on Apples should be applied");
        }

        [Test]
        public void GenerateReceipt_ShouldApplyBreadDiscountCorrectly()
        {
            // Arrange
            var basket = new List<BasketItem>
            {
                new BasketItem { Name = "Soup", Quantity = 2 },
                new BasketItem { Name = "Bread", Quantity = 1 }
            };

            // Act
            var receipt = _basketProcessor.GenerateReceipt(basket);

            // Assert
            Assert.IsTrue(receipt.Contains("Discount on Bread: -€0.40"), "The bread discount should be applied correctly");
            Assert.IsTrue(receipt.Contains("Total: €1.50"), "The total price should be €1.50 after discount");
        }
    }
}
