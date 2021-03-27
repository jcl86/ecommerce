using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Domain
{
    public static class ProductMapper
    {
        public static Model.Product Map(this Product entity)
        {
            return new Model.Product()
            {
                Description = entity.Description,
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }

        public static IEnumerable<Model.Product> Map(this IEnumerable<Product> entityList)
        {
            return entityList.Select(x => x.Map()).ToList();
        }
    }

}
