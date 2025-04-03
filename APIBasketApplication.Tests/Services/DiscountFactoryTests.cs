using APIBasketApplication.Services.Discount;
using NUnit.Framework;
using ShoppingBasket.API.Services.Discount;
using System.Collections.Generic;

namespace APIBasketApplication.Tests.Services.Discount
{
    [TestFixture]
    public class DiscountFactoryTests
    {
        [Test]
        public void DiscountFactory_ShouldReturnCorrectDiscounts()
        {
            // Act
            var discounts = DiscountFactory.GetDiscounts();

            Assert.AreEqual(2, discounts.Count, "Discount factory should return two discounts");
            Assert.IsInstanceOfType(typeof(ApplesDiscount), discounts[0] , "First discount should be ApplesDiscount");
            Assert.IsInstanceOfType(typeof(BreadDiscount), discounts[1], "Second discount should be BreadDiscount");
        }
    }
}
