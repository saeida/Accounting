



using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Domain.Interface.User;
using Infrastructure.Persistence.Repositories.User;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Authentication.JWT;

using Microsoft.AspNetCore.Authorization;
using Infrastructure.Authentication.Permission;
using System.Collections;
using Domain.Interface.Jwt;
using Infrastructure.Persistence.Entities.Samina;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)        
         
        {

            var assembly = typeof(DependencyInjection).Assembly;

        

            services.AddDbContext<SaminaDbContext>(options =>
            {
                //  object p = options.UseSqlServer("Data Source=DESKTOP-LJH87UL;Initial Catalog=SaminaDB;Integrated Security=True;Trusted_Connection=false; Encrypt=False;User ID=sa;Password=123456");
                
                object p = options.UseSqlServer("Data Source=62.60.130.138\\SAMINA;Initial Catalog=SaminaDB;Integrated Security=True;Trusted_Connection=false; Encrypt=False;User ID=sa;Password=Mh123456@");
                ////  options.UseSqlServer(nooshDarooConnectionString);
                options.EnableSensitiveDataLogging();

            });

         
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();
            services.AddScoped<IUserCommandRepository, UserCommandRepository>();
            services.AddScoped<ITokenCommandRepository, TokenCommandRepository>();
            services.AddScoped<ITokenQueryRepository, TokenQueryRepository>();
            services.AddScoped<IPermissionService, PermissionService>();
    

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();


            services.AddAutoMapper(assembly);
        
            return services;
        }
    }
}
