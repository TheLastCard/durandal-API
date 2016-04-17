using Durandal_API.Models;
using Durandal_API.Models.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Durandal_API.Controllers
{
    [RoutePrefix("api/Basket")]
    public class BasketController : ApiController
    {
        private DurandalDB db = new DurandalDB();

        // GET: api/Basket
        [ResponseType(typeof(Basket))]
        public IHttpActionResult GetBasket()
        {
            if (null != HttpContext.Current.Session["basket"])
            {
                return Ok((Basket)HttpContext.Current.Session["basket"]);
            }
            return Ok(new Basket());
        }

        // POST: api/Basket/PostProductToBasket/{Id}/{Amount}
        [Route("PostProductToBasket/{Id}/{Amount}")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult PostProductToBasket(int Id, int Amount)
        {
            Basket basket = new Basket();
            var product = db.Products.SingleOrDefault(x => x.Id == Id);
            if(null == product || 1 > Amount)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            if(null != HttpContext.Current.Session["basket"])
            {
                basket = (Basket)HttpContext.Current.Session["basket"];
            }
            basket.Products.Add(new BasketItem()
            {
                Product = product,
                Amount = Amount
            });

            HttpContext.Current.Session["basket"] = basket;

            return StatusCode(HttpStatusCode.OK);
        }
    }
}
