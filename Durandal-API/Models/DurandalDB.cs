using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Durandal_API.Models
{
    public class DurandalDB : DbContext
    {
        public DurandalDB() : base("DefaultConnection")
        {
            Database.SetInitializer<DurandalDB>(new ProductDBInitializer());
        }

        public DbSet<ProductModel> Products { get; set; }

    }
}