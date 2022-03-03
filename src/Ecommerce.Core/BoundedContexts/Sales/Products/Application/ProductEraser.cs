using Ecommerce.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Sales.Domain
{
    [Service]
    public class ProductEraser
    {
        private readonly ProductFinder finder;
        private readonly Data.ApplicationDbContext context;

        public ProductEraser(ProductFinder finder, Data.ApplicationDbContext context)
        {
            this.finder = finder;
            this.context = context;
        }

        public async Task Delete(string productId)
        {
            var product = await finder.Find(productId);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
