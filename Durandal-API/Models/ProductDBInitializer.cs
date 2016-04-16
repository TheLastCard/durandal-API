using System.Collections.Generic;
using System.Data.Entity;

namespace Durandal_API.Models
{
    public class ProductDBInitializer : DropCreateDatabaseAlways<DurandalDB>
    {
        protected override void Seed(DurandalDB context)
        {
            IList<ProductModel> defaultProductModels = new List<ProductModel>();

            defaultProductModels.Add(new ProductModel() { Name = "Webcam", Price = 499, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec pretium fringilla nisi a egestas. Aliquam et augue euismod neque scelerisque malesuada ut nec sem. Sed hendrerit porta leo, sit amet mollis odio dapibus ut. Etiam efficitur posuere mi eu feugiat." });
            defaultProductModels.Add(new ProductModel() { Name = "Raspberry PI 3", Price = 749, Description = "Vivamus dignissim nulla eget mauris molestie elementum. Integer consequat ligula scelerisque velit feugiat, at accumsan massa tincidunt." });
            defaultProductModels.Add(new ProductModel() { Name = "Headphones", Price = 249, Description = "Pellentesque id turpis iaculis, convallis nisl vel, ullamcorper leo. Sed eu arcu sit amet ex consectetur elementum hendrerit nec nulla. Nullam varius consequat purus in tempor." });
            defaultProductModels.Add(new ProductModel() { Name = "Samsung 48\" Smart TV", Price = 299, Description = "Vestibulum sodales luctus eros, ac blandit tortor accumsan sit amet. Mauris vestibulum leo eros. Aenean ut ligula malesuada, convallis nunc malesuada, faucibus nisi." });

            foreach (ProductModel std in defaultProductModels)
                context.Products.Add(std);

            base.Seed(context);
        }
    }
}
