using CORE_API.AUthServiceInfra;
using CORE_API.MOdels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CORE_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthAppController : ControllerBase
    {
        AUthService service;
        public AuthAppController(AUthService service)
        {
            this.service = service;
        }

        [HttpPost]
        [ActionName("register")]
        public async Task<ResponseObject<RegisterNewUser>> Register(RegisterNewUser user)
        { 
            ResponseObject<RegisterNewUser> response = await service.CreateUserAsync(user);
            return response;
        }

    }
}
