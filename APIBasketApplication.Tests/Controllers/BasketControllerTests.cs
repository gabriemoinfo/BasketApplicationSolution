using NUnit.Framework;
using Moq;
using ShoppingBasket.API.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using APIBasketApplication.Controllers;
using APIBasketApplication.Models;

namespace APIBasketApplication.Tests.Controllers
{
    [TestFixture]
    public class BasketControllerTests
    {
        private BasketProcessor _basketProcessorMock;
        private BasketController _controller;

        [SetUp]
        public void SetUp()
        {
            _basketProcessorMock = new BasketProcessor();
            _controller = new BasketController(_basketProcessorMock);
        }

        [Test]
        public void CalculateTotal_ShouldReturnBadRequest_WhenBasketIsEmpty()
        {
            // Arrange
            List<BasketItem> basket = null;

            // Act
            var result = _controller.CalculateTotal(basket);

            // Assert
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(result);
        }

        [Test]
        public void CalculateTotal_ShouldReturnCorrectReceipt_WhenBasketIsValid()
        {
            // Arrange
            var basket = new List<BasketItem>
            {
                new BasketItem { Name = "Soup", Quantity = 2 },
                new BasketItem { Name = "Bread", Quantity = 1 },
                new BasketItem { Name = "Apples", Quantity = 1 }
            };

            var expectedReceipt = "Receipt:\nSoup x2: €1.30\nBread x1: €0.80\nApples x1: €1.00\nDiscount on Apples: -€0.10\nTotal: €2.60";

            //_basketProcessorMock(bp => bp.GenerateReceipt(It.IsAny<List<BasketItem>>())).Returns(expectedReceipt);

            // Act
            var result = _controller.CalculateTotal(basket) as OkNegotiatedContentResult<string>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedReceipt, result.Content);
        }
    }
}
