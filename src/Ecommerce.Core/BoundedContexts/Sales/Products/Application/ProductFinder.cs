using Ecommerce.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Sales.Domain
{
    [Service]
    public class ProductFinder
    {
        private readonly Data.ApplicationDbContext context;

        public ProductFinder(Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Product> Find(string productId)
        {
            var product = await context.Products.FindAsync(productId);
            if (product is null)
            {
                throw new NotFoundException<Product>(productId);
            }
            return product;
        }
    }

}
