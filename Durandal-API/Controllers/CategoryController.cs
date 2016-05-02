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

namespace Durandal_API.Controllers
{
    public class CategoryController : ApiController
    {
        private DurandalDB db = new DurandalDB();

        // GET: api/Category
        public IQueryable<CategoryModel> GetCategories()
        {
            return db.Categories;
        }

        // GET: api/Category/5
        [ResponseType(typeof(CategoryModel))]
        public async Task<IHttpActionResult> GetCategoryModel(int id)
        {
            CategoryModel categoryModel = await db.Categories.FindAsync(id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return Ok(categoryModel);
        }

        // PUT: api/Category/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategoryModel(int id, CategoryModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryModel.Id)
            {
                return BadRequest();
            }

            db.Entry(categoryModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryModelExists(id))
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

        // POST: api/Category
        [ResponseType(typeof(CategoryModel))]
        public async Task<IHttpActionResult> PostCategoryModel(CategoryModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(categoryModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categoryModel.Id }, categoryModel);
        }

        // DELETE: api/Category/5
        [ResponseType(typeof(CategoryModel))]
        public async Task<IHttpActionResult> DeleteCategoryModel(int id)
        {
            CategoryModel categoryModel = await db.Categories.FindAsync(id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            db.Categories.Remove(categoryModel);
            await db.SaveChangesAsync();

            return Ok(categoryModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryModelExists(int id)
        {
            return db.Categories.Count(e => e.Id == id) > 0;
        }
    }
}