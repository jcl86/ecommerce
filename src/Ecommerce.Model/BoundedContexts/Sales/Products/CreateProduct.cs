using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Sales.Model
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
