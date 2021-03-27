using System;

namespace Ecommerce.Domain
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Guid id, string name = null) : base($"{name ?? "object"} with id {id} was not found") { }
    }

}
