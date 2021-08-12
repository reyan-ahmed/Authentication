using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Entities;
using Identity.Models;

namespace Identity.Interface
{
    public interface IUserService
    {
        Task<Output> Add(ApplicationUser applicationUser, string password, string roleId);
        Task<List<ApplicationUser>> GetAll();
        Task<Output> Remove(string id);
        Task<Output> Update(ApplicationUser applicationUser);
        Task<Output> Get(string id);
        Task<Output> ValidateUser(string username, string password);
        void Signout();
    }
}
