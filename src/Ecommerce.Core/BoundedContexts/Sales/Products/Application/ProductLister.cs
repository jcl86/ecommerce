using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Sales.Domain
{
    [Service]
    public class ProductLister
    {
        private readonly Data.ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductLister(Data.ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Model.Product>> ToList()
        {
            var list = await context.Products.AsNoTracking()
                .ProjectTo<Model.Product>(mapper.ConfigurationProvider)
                .ToListAsync();
            return list;
        }
    }

}
