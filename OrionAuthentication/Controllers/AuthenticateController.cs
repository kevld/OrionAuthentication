using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrionAuthentication.DTO;
using OrionAuthentication.Services;

namespace OrionAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthenticateController(UserManager<IdentityUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Login);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized();
            
            IList<string> roles = await _userManager.GetRolesAsync(user);

            return Ok(_tokenService.GenerateToken(user, roles));
        }
    }
}
