using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Entities;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Identity.Interface
{
    public interface IRoleService
    {
        Task<List<Role>> GetRolesByUserId(ApplicationUser applicationUser);
        Task<bool> Add(string roleName);
        Task<List<Role>> GetRoles();
        Task<IdentityResult> AssignRole(ApplicationUser applicationUser, string roleId);
        Task<Output> Remove(string roleName);
        Task<SelectList> ListOfRoles();
        Task<IdentityRole> Get(string roleId);
        Task Update(IdentityRole identityRole);
    }
}
