using AutoMapper;
using Ecommerce.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize(Policies.IsSuperAdministrator)]
    public class UsersController : ControllerBase
    {
        private readonly UserFinder userFinder;
        private readonly UserEraser userEraser;
        private readonly IMapper mapper;

        public UsersController(UserFinder userFinder, UserEraser userEraser, IMapper mapper)
        {
            this.userFinder = userFinder;
            this.userEraser = userEraser;
            this.mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Model.User>> GetById(string userId)
        {
            var entity = await userFinder.Find(userId);
            var result = mapper.Map<Model.User>(entity);
            return result;
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            await userEraser.Delete(userId);
            return NoContent();
        }
    }
}
