using Ecommerce.Model;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    [Service]
    public class ProductUpdater
    {
        private readonly ProductFinder finder;
        private readonly IProductRepository productRepository;

        public ProductUpdater(ProductFinder finder, IProductRepository productRepository)
        {
            this.finder = finder;
            this.productRepository = productRepository;
        }

        public async Task Update(Guid productId, UpdateProduct dto)
        {
            var product = await finder.Find(productId);
            product.UpdateName(dto.Name);
            product.UpdatePrice(dto.Price);
            product.UpdateDescription(dto.Description);
            await productRepository.Update(product);
        }
    }
}
