using Ecommerce.Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Domain
{
    public class PasswordChanger
    {
        private readonly UserManager<User> userManager;

        public PasswordChanger(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task Change(string userId, string currentPassword, string newPassword)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user is null)
            {
                throw new NotFoundException<User>(userId);
            }

            var result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (!result.Succeeded)
            {
                throw new DomainException(result.Errors.Select(x => x.Description));
            }

        }
    }
}
