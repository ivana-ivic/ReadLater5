using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadLater5API.Helpers
{
    public interface IJwtHelper
    {
        public string GenerateJwtToken(IdentityUser user);
        public string GetUserIdFromToken(string token);
    }
}
