using System;
using System.Collections.Generic;
using System.Linq;
using AuthApp.Models;

namespace AuthApp.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}