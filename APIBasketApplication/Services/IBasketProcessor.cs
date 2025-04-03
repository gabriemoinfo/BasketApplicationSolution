using APIBasketApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBasketApplication.Services
{
    public interface IBasketProcessor
    {
        string GenerateReceipt(List<BasketItem> basket);
    }
}
