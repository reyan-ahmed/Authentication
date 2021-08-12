using System;
using System.ComponentModel.DataAnnotations;

namespace Application.InputDTOs
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
