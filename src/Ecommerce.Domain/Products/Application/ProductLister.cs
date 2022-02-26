using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    [Service]
    public class ProductLister
    {
        private readonly IProductRepository productRepository;

        public ProductLister(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> ToList()
        {
            var list = await productRepository.GetAll();
            return list;
        }
    }

}
