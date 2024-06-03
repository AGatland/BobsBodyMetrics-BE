using bobsbodymetrics.Models;

namespace bobsbodymetrics.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}