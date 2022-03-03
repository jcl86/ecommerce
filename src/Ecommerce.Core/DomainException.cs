namespace Ecommerce.Core.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }

        public DomainException(IEnumerable<string> errors) : base(string.Join(", ", errors)) { }
    }

}
