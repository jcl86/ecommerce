using Ecommerce.Core.Domain;

namespace Ecommerce.Sales.Domain
{
    [Service]
    public class ProductCreator
    {
        private readonly Data.ApplicationDbContext context;

        public ProductCreator(Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Product> Create(Model.CreateProduct dto)
        {
            var product = new Product(dto.Name, dto.Description, dto.Price);
            context.Add(product);
            await context.SaveChangesAsync();
            return product;
        }
    }
}
