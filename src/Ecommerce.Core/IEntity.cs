namespace Ecommerce.Core.Domain
{
    public interface IEntity<T>
    {
        public T Id { get; }
    }
}
