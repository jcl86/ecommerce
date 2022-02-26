namespace Ecommerce.Model
{
    public static partial class Endpoints
    {
        public static class Products
        {
            public const string Base = "api/products";

            public static string Get(Guid id) => $"{Base}/{id}";
            public static string GetAll = Base;
            public static string Create = Base;
            public static string Update(Guid id) => $"{Base}/{id}";
            public static string Delete(Guid id) => $"{Base}/{id}";
        }
    }
}
