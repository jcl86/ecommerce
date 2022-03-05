using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Domain
{
    public class LoginService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly ITokenGenerator tokenGenerator;

        public LoginService(SignInManager<User> signInManager, UserManager<User> userManager, ITokenGenerator tokenGenerator)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task<string> GetAuthenticationToken(Model.LoginRequest model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user is null)
            {
                throw new UnauthorizedAccessException(Account.Messages.LoginError);
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                throw new UnauthorizedAccessException(Account.Messages.LoginError);
            }

            string token = tokenGenerator.GenerateToken(user);
            return token;
        }
    }
}
