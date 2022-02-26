using System;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    [Service]
    public class ProductFinder
    {
        private readonly IProductRepository productRepository;

        public ProductFinder(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> Find(Guid productId)
        {
            var product = await productRepository.Get(productId);
            if (product is null)
            {
                throw new NotFoundException<Product>(productId);
            }
            return product;
        }
    }

}
