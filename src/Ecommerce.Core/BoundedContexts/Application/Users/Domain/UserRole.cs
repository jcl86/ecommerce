using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Domain
{
    public class UserRole : IdentityUserRole<string>
    {
        public User User { get; set; }
        public Role Role { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
