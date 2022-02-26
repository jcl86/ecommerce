using System;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    [Service]
    public class ProductEraser
    {
        private readonly ProductFinder finder;
        private readonly IProductRepository productRepository;

        public ProductEraser(ProductFinder finder, IProductRepository productRepository)
        {
            this.finder = finder;
            this.productRepository = productRepository;
        }

        public async Task Delete(Guid productId)
        {
            var product = await finder.Find(productId);
            await productRepository.Delete(productId);
        }
    }
}
