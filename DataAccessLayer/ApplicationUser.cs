using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ApplicationUser : IdentityUser
    {
        public string NombreCompleto { get; set; }
        public string Rol { get; set; }
    }
}
