using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IAuthService
    {
        public Task<IdentityResult> Register(ApplicationUser user, string password);
        public Task<SignInResult> Login(string email, string password);
    }
}
