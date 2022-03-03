using AutoMapper;
using Ecommerce.Sales.Domain;

namespace Ecommerce.Core.Domain
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            MapProducts();


            void MapProducts()
            {
                CreateMap<Product, Sales.Model.Product>()
                    .ReverseMap();
                        // .ForMember(dst => dst.Description, cfg => cfg.Ignore());
            }
        }
    }
}
