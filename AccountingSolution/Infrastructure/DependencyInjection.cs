

using Domain.Interface.Customer;
using Domain.Interface;
using Infrastructure.Persistence.Repositories.Customer;
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

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)        
         
        {

            var assembly = typeof(DependencyInjection).Assembly;

            services.AddDbContext<CRUDTESTContext>(options =>
            {
                object p = options.UseSqlServer("Data Source=DESKTOP-LJH87UL;Initial Catalog=CRUDTEST;Integrated Security=True;Trusted_Connection=false; Encrypt=False;User ID=sa;Password=123456");
                ////  options.UseSqlServer(nooshDarooConnectionString);
                options.EnableSensitiveDataLogging();

            });

         

            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();          
            services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();
            services.AddScoped<IUserCommandRepository, UserCommandRepository>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            
            services.AddAutoMapper(assembly);
        
            return services;
        }
    }
}
