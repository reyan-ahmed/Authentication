using System;
using System.Collections.Generic;
using Identity.Entities;

namespace Identity.Models
{
    public class Output
    {
        public Output(bool result, List<Error> errors, ApplicationUser applicationUser)
        {
            Result = result;
            Errors = errors;
            ApplicationUser = applicationUser;
        }

        public bool Result { get; set; } = false;
        public List<Error> Errors { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

    public class Error
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
