using System;

namespace Ecommerce.Domain
{
    public class NotFoundException<T> : NotFoundException
    {
        public NotFoundException(string id) : base($"{typeof(T)} with id {id} was not found") { }
        public NotFoundException(int id) : this(id.ToString()) { }
        public NotFoundException(Guid id) : this(id.ToString()) { }
    }

    public abstract class NotFoundException : Exception
    {
        public NotFoundException(string message = "Item was not found") : base(message) { }
    }
}
