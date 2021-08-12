using System.Collections.Generic;
using Identity.Entities;
using Identity.Models;

namespace Identity.Interface
{
    public interface IAuthenticationService
    {
        object GenerateToken(ApplicationUser applicationUser, List<Role> roles);
    }
}
