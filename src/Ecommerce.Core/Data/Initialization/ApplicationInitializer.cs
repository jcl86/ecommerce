using Ecommerce.Application.Domain;
using Ecommerce.Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Data
{
    public class ApplicationInitializer
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserCredentials defaultAdministrator;

        public ApplicationInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, UserCredentials defaultAdministrator)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.defaultAdministrator = defaultAdministrator;
        }

        public async Task SeedUsers()
        {
            if (defaultAdministrator is null || defaultAdministrator.Username.IsEmpty())
            {
                throw new DomainException("Default administrator must have a value");
            }

            if ((await userManager.FindByEmailAsync(defaultAdministrator.Username)) is null)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = RoleNames.SuperAdministrator, NormalizedName = RoleNames.SuperAdministrator.ToUpper() });

                var user = new User
                {
                    UserName = defaultAdministrator.Username,
                    Email = defaultAdministrator.Username
                };

                var result = await userManager.CreateAsync(user, defaultAdministrator.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, RoleNames.SuperAdministrator);
                }
            }
        }
    }
}
