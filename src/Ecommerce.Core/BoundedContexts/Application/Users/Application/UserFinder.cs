using Ecommerce.Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Domain
{
    public class UserFinder
    {
        private readonly UserManager<User> userManager;

        public UserFinder(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<User> Find(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user is null)
            {
                throw new NotFoundException<User>(userId);
            }

            return user;
        }

        public async Task<User> FindByEmail(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user is null)
            {
                throw new NotFoundException($"User with email {email} was not found");
            }

            return user;
        }
    }
}
