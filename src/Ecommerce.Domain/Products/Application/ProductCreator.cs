using Ecommerce.Model;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    [Service]
    public class ProductCreator
    {
        private readonly dbcontext productRepository;

        public ProductCreator(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> Create(CreateProduct dto)
        {
            var product = new Product(dto.Name, dto.Description, dto.Price);
            await productRepository.Create(product);
            return product;
        }
    }
}
