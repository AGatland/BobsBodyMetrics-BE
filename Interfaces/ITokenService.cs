using bobsbodymetrics.Models;

namespace bobsbodymetrics.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}