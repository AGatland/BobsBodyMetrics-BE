using bobsbodymetrics.Models;
using Microsoft.AspNetCore.Identity;

namespace bobsbodymetrics.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user);
    }
}