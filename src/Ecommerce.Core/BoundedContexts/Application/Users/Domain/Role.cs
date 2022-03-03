using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Domain
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
