using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Entities;
using Identity.Interface;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IRoleService _roleService;


        public UserService(UserManager<ApplicationUser> userManager,
             IRoleService roleService, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleService = roleService;
            _signInManager = signInManager;
        }

        public async Task<Output> Add(ApplicationUser applicationUser, string password, string roleId)
        {
            var addUser = await _userManager.CreateAsync(applicationUser, password);
            if (!addUser.Succeeded)
            {
                var errors = new List<Error>();
                foreach (IdentityError error in addUser.Errors)
                {
                    errors.Add(new Error() { Code = error.Code, Description = error.Description });
                }

                return new Output(addUser.Succeeded, errors, applicationUser);
            }

            var assignRoleToCurrentUser = await _roleService.AssignRole(applicationUser, roleId);
            if (!assignRoleToCurrentUser.Succeeded)
            {
                var errors = new List<Error>();
                foreach (IdentityError error in assignRoleToCurrentUser.Errors)
                {
                    errors.Add(new Error() { Code = error.Code, Description = error.Description });
                }

                return new Output(assignRoleToCurrentUser.Succeeded, errors, applicationUser);
            }


            return new Output(true, null, applicationUser);
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            return await _userManager.Users.ToListAsync();
        }


        public async Task<Output> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                var errors = new List<Error>();
                errors.Add(new Error() { Code = "Null", Description = "Id is null" });
                return new Output(false, errors, null);
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                var errors = new List<Error>();
                errors.Add(new Error() { Code = "Record Not Found", Description = $"User Cannot find by Id {id}" });
                return new Output(false, errors, null);
            }

            return new Output(true, null, user);
        }

        public async Task<Output> Remove(string id)
        {
            var user = await Get(id);

            var result = await _userManager.DeleteAsync(user.ApplicationUser);
            if (!result.Succeeded)
            {
                var errors = new List<Error>();
                foreach (IdentityError error in result.Errors)
                {
                    errors.Add(new Error() { Code = error.Code, Description = error.Description });
                }
                return new Output(result.Succeeded, errors, user.ApplicationUser);
            }

            return new Output(user.Result, user.Errors, user.ApplicationUser);
        }

        public async Task<Output> Update(ApplicationUser userRegistration)
        {
            var user = await Get(userRegistration.Id);

            user.ApplicationUser.FirstName = userRegistration.FirstName;
            user.ApplicationUser.LastName = userRegistration.LastName;
            user.ApplicationUser.Email = userRegistration.Email;
            user.ApplicationUser.UserName = userRegistration.Email;

            var result = await _userManager.UpdateAsync(user.ApplicationUser);
            if (!result.Succeeded)
            {
                var errors = new List<Error>();
                foreach (IdentityError error in result.Errors)
                {
                    errors.Add(new Error() { Code = error.Code, Description = error.Description });
                }
                return new Output(result.Succeeded, errors, user.ApplicationUser);
            }
            return new Output(result.Succeeded, null, user.ApplicationUser);
        }

        public async Task<Output> ValidateUser(string username, string password)
        {
            var applicationUser = await _userManager.FindByNameAsync(username);
            if (applicationUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
                if (result.Succeeded)
                {
                    var errors = new List<Error>();
                    errors.Add(new Error() { Code = "", Description = PasswordVerificationResult.Failed.ToString() });
                    return new Output(false, errors, applicationUser);
                }

                return new Output(true, null, applicationUser);
            }
            return new Output(false, null, null);
        }

        public async void Signout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
