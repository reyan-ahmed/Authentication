using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Identity.Models;

namespace Application.InputDTOs
{
    public class UserRegistration
    {
        [Display(Name = "Enter your First Name"), Required]
        public string FirstName { get; set; }

        [Display(Name = "Enter your Last Name"), Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string Id { get; set; }

        [Required]
        public string RoleId { get; set; }
    }
}
