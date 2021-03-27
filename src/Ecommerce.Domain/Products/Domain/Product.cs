using System;

namespace Ecommerce.Domain
{
    public class Product
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public void UpdateName(string value) => Name = value; 

        public string Description { get; private set; }
        public void UpdateDescription(string value) => Description = value; 

        public decimal Price { get; private set; }
        public void UpdatePrice(decimal value) => Price = value; 

        public Product(Guid id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public override string ToString() => Name;
    }

}
