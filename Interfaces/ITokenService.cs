using bobsbodymetrics.Models;
using Microsoft.AspNetCore.Identity;

namespace bobsbodymetrics.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}