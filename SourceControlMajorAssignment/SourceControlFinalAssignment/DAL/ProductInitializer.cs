using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SourceControlFinalAssignment.Models;

namespace SourceControlFinalAssignment.DAL
{
    public class ProductInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            var products = new List<Product>
            {
                new Product{Id=1,ProductName="iPhone",Category="Smartphones",Price=23990,Quantity=5,ShortDesc="This is the iPhone.",}
            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
        }

    }
}