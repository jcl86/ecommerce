using Ecommerce.Model;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    public class ProductCreator
    {
        private readonly IProductRepository productRepository;

        public ProductCreator(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> Create(CreateProduct dto)
        {
            var product = new Product(dto.Id, dto.Name, dto.Description, dto.Price);
            await productRepository.Create(product);
            return product;
        }
    }
}
