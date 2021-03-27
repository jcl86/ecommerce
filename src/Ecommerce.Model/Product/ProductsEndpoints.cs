using System;

namespace Ecommerce.Model
{
    public class ProductsEndpoints
    {
        public const string Base = "api/products";

        public static string Get(Guid id) => $"{Base}/{id}";
        public static string GetAll = Base;
        public static string Create = Base;
        public static string Update(Guid id) => $"{Base}/{id}";
        public static string Delete(Guid id) => $"{Base}/{id}";
    }
}
