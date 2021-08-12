using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Entities;
using Identity.Interface;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Identity.Services
{
    public class RoleService : IRoleService
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;


        public RoleService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<Role>> GetRolesByUserId(ApplicationUser applicationUser)
        {
            var assignedRoles = new List<Role>();
            var roles = await _roleManager.Roles.ToListAsync();
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    if (await _userManager.IsInRoleAsync(applicationUser, role.Name))
                    {
                        assignedRoles.Add(new Role
                        {
                            Id = role.Id,
                            Name = role.Name
                        });
                    }
                }
            }

            return assignedRoles;
        }

        public async Task<bool> Add(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }

            return true;
        }

        public async Task<IdentityResult> AssignRole(ApplicationUser applicationUser, string roleId)
        {

            var role = await _roleManager.FindByIdAsync(roleId);
            var currentUser = await _userManager.FindByNameAsync(applicationUser.UserName);
            var roleresult = await _userManager.AddToRoleAsync(currentUser, role.Name);
            return roleresult;
        }

        public async Task<List<Role>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var returnValue = new List<Role>();
            foreach (var item in roles)
            {
                returnValue.Add(new Role(item.Id, item.Name));
            }
            return returnValue;
        }


        public async Task<Output> Remove(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded)
            {
                var errors = new List<Error>();
                foreach (IdentityError error in result.Errors)
                {
                    errors.Add(new Error() { Code = error.Code, Description = error.Description });
                }

                return new Output(result.Succeeded, errors, null);
            }

            return new Output(true, null, null);
        }

        public async Task<SelectList> ListOfRoles()
        {
            var roles = await GetRoles();

            var list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Please select role",
                Value = ""
            });

            foreach (var role in roles)
            {
                list.Add(new SelectListItem()
                {
                    Text = role.Name,
                    Value = role.Id
                });
            }

            return new SelectList(list, "Value", "Text");
        }

    }
}
