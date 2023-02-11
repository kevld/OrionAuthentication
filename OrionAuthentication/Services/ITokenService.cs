using Microsoft.AspNetCore.Identity;

namespace OrionAuthentication.Services
{
    public interface ITokenService
    {
        public string GenerateToken(IdentityUser user, IList<string> roles);
    }
}
