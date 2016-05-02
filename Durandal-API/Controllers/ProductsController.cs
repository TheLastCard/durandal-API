using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Durandal_API.Models;
using System.Web.Http.Cors;

namespace Durandal_API.Controllers
{
    public class ProductsController : ApiController
    {
        private DurandalDB db = new DurandalDB();

        // GET: api/Products
        public async Task<ICollection<ProductModel>> GetProducts()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return await db.Products.ToListAsync();
        }

        // GET: api/Products/5
        [ResponseType(typeof(ProductModel))]
        public async Task<IHttpActionResult> GetProductModel(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            ProductModel productModel = await db.Products.Include(x => x.Category).FirstAsync(x => x.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return Ok(productModel);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductModel(int id, ProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productModel.Id)
            {
                return BadRequest();
            }

            var categoryId = productModel.Id;
            productModel.Category = db.Categories.Find(categoryId);

            db.Entry(productModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(ProductModel))]
        public async Task<IHttpActionResult> PostProductModel(ProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(productModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productModel.Id }, productModel);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(ProductModel))]
        public async Task<IHttpActionResult> DeleteProductModel(int id)
        {
            ProductModel productModel = await db.Products.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }

            db.Products.Remove(productModel);
            await db.SaveChangesAsync();

            return Ok(productModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductModelExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}