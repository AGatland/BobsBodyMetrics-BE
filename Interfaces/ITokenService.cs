using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bobsbodymetrics.Models;

namespace bobsbodymetrics.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}