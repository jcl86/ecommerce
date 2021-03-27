using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    public interface IProductRepository
    {
        Task<Product> Get(Guid productId);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Create(Product product);
        Task Update(Product product);
        Task Delete(Guid productId);
    }

}
