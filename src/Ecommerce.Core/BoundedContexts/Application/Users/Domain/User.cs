using Ecommerce.Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Domain
{
    public class User : IdentityUser, IEntity<string>
    {
        public ICollection<UserRole> UserRoles { get; set; }

        public IEnumerable<Model.RoleInCompany> GetCompanyRoles() => UserRoles.Select(x =>
            new Model.RoleInCompany()
            {
                Company = new Model.CompanySummary()
                {
                    Id = x.Company.Id,
                    Name = x.Company.Name
                },
                RoleName = x.Role.Name
            }).ToList();

        public override string ToString() => UserName;
    }
}
