using Ecommerce.Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Domain
{
    public class UserRegister
    {
        private readonly UserManager<User> userManager;

        public UserRegister(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<User> CreateUser(Model.RegisterUser model)
        {
            var emailAddress = new EmailAddress(model.Email);

            var user = new User() { UserName = emailAddress.ToString(), Email = emailAddress.ToString() };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                throw new DomainException($"User {user} could not be created. {string.Join(", ", errors)}");
            }

            //Add roles, company, etc

            //await notifier.Notify(NotificationType.UserCreated, $"User {username} was created");
            
            return user;
        }
    }
}
