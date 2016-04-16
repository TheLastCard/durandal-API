using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Durandal_API.Models
{
    public class DurandalDB : DbContext
    {

        public DbSet<ProductModel> Products { get; set; }

        public void Seed(DurandalDB Context)
        {
#if DEBUG
            // Create my debug (testing) objects here
            Context.Products.Add(new ProductModel() { Name = "Webcam", Price = 499, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec pretium fringilla nisi a egestas. Aliquam et augue euismod neque scelerisque malesuada ut nec sem. Sed hendrerit porta leo, sit amet mollis odio dapibus ut. Etiam efficitur posuere mi eu feugiat." });
            Context.Products.Add(new ProductModel() { Name = "Raspberry PI 3", Price = 749, Description = "Vivamus dignissim nulla eget mauris molestie elementum. Integer consequat ligula scelerisque velit feugiat, at accumsan massa tincidunt." });
            Context.Products.Add(new ProductModel() { Name = "Headphones", Price = 249, Description = "Pellentesque id turpis iaculis, convallis nisl vel, ullamcorper leo. Sed eu arcu sit amet ex consectetur elementum hendrerit nec nulla. Nullam varius consequat purus in tempor." });
            Context.Products.Add(new ProductModel() { Name = "Samsung 48\" Smart TV", Price = 299, Description = "Vestibulum sodales luctus eros, ac blandit tortor accumsan sit amet. Mauris vestibulum leo eros. Aenean ut ligula malesuada, convallis nunc malesuada, faucibus nisi." });
            Context.SaveChanges();
#endif
        }

        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<DurandalDB>
        {
            protected override void Seed(DurandalDB context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        static DurandalDB()
        {
#if DEBUG
            Database.SetInitializer<DurandalDB>(new DropCreateIfChangeInitializer());
#endif
        }
    }
}