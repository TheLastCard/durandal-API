using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Durandal_API.Models
{
    public class DurandalDB : IdentityDbContext<ApplicationUser>
    {
        public DurandalDB():base("name=DurandalDB")
        {
        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>()
                .HasRequired(t => t.Category);

            base.OnModelCreating(modelBuilder);
        }

        public static DurandalDB Create()
        {
            return new DurandalDB();
        }
    }
}