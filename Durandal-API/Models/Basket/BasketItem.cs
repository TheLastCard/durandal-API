using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Durandal_API.Models.Basket
{
    public class BasketItem
    {
        public ProductModel Product { get; set; }
        public int Amount { get; set; }
    }
}