using APIBasketApplication.Models;
using ShoppingBasket.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;

namespace APIBasketApplication.Controllers
{
    public class BasketController : ApiController
    {
        private readonly BasketProcessor _basketProcessor;
        public BasketController(BasketProcessor basketProcessor)
        {
            _basketProcessor = basketProcessor;
        }

        [HttpPost]
        [Route("api/basket/calculate")]
        public IHttpActionResult CalculateTotal([FromBody] List<BasketItem> basket)
        {
            if (basket == null || !basket.Any())
                return BadRequest("Basket cannot be empty");

            var receipt = _basketProcessor.GenerateReceipt(basket);
            return Ok(receipt);
        }
    }
}