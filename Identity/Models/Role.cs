using System;
namespace Identity.Models
{
    public class Role
    {
        public Role(string roleId, string roleName)
        {
            Id = roleId;
            Name = roleName;
        }
        public Role() {
        }
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
