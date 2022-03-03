using Ecommerce.Domain;
using Ecommerce.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly LoginService loginService;
        private readonly UserRegister userRegister;
        private readonly PasswordChanger passwordChanger;

        public AccountController(LoginService loginService, 
            UserRegister userRegister, 
            PasswordChanger passwordChanger)
        {
            this.loginService = loginService;
            this.userRegister = userRegister;
            this.passwordChanger = passwordChanger;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationSuccessResponse>> Authenticate(LoginRequest model)
        {
            string token = await loginService.GetAuthenticationToken(model);

            return Ok(new AuthenticationSuccessResponse()
            {
                Username = model.Email,
                Token = token
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<Model.User>> Register(RegisterUser model)
        {
            var user = await userRegister.CreateUser(model);
            return Ok(new Model.User()
            {
                Id = user.Id,
                Username = user.ToString(),
                Roles = user.UserRoles.Select(x => x.Role.Name)
            });
        }

        [Authorize]
        [HttpPut("change-password")]
        public async Task<IActionResult> UpdatePassword(ChangePasswordRequest model)
        {
            var currentUser = User.GetUserId();
            await passwordChanger.Change(currentUser, model.CurrentPassword, model.NewPassword);
            return NoContent();
        }
    }
}
