namespace Ecommerce.Application.Domain
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
