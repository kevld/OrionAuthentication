using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrionAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok();
        }

        [Authorize]
        [HttpGet("")]
        public IActionResult GetUserDataFromToken()
        {


            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("HasRoleAdmin")]
        public IActionResult HasRoleAdmin()
        {
            return Ok();
        }

        [Authorize(Roles = "User")]
        [HttpGet("HasRoleUser")]
        public IActionResult HasRoleUser()
        {
            return Ok();
        }
    }
}
