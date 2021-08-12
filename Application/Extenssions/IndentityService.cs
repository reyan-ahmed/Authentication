using System;
using System.Security.Claims;
using Identity.Interface;
using Identity.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extenssions
{
    public static class IndentityService
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRoleService, RoleService>();
            return services;
        }
    }
   
}
