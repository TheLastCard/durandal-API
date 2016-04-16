namespace Durandal_API.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Durandal_API.Models.DurandalDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Durandal_API.Models.DurandalDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );

            context.Products.AddOrUpdate(
                new ProductModel() { Name = "Webcam", Price = 499, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec pretium fringilla nisi a egestas. Aliquam et augue euismod neque scelerisque malesuada ut nec sem. Sed hendrerit porta leo, sit amet mollis odio dapibus ut. Etiam efficitur posuere mi eu feugiat." },
                new ProductModel() { Name = "Raspberry PI 3", Price = 749, Description = "Vivamus dignissim nulla eget mauris molestie elementum. Integer consequat ligula scelerisque velit feugiat, at accumsan massa tincidunt." },
                new ProductModel() { Name = "Headphones", Price = 249, Description = "Pellentesque id turpis iaculis, convallis nisl vel, ullamcorper leo. Sed eu arcu sit amet ex consectetur elementum hendrerit nec nulla. Nullam varius consequat purus in tempor." },
                new ProductModel() { Name = "Samsung 48\" Smart TV", Price = 299, Description = "Vestibulum sodales luctus eros, ac blandit tortor accumsan sit amet. Mauris vestibulum leo eros. Aenean ut ligula malesuada, convallis nunc malesuada, faucibus nisi." }
            );
            context.SaveChanges();
        }
    }
}
