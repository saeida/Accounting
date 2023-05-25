

using Domain.Interface.Customer;
using Domain.Interface;
using Infrastructure.Persistence.Repositories.Customer;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)        
         
        {
            services.AddDbContext<CRUDTESTContext>(options =>
            {
                object p = options.UseSqlServer("Data Source=DESKTOP-LJH87UL;Initial Catalog=CRUDTEST;Integrated Security=True;Trusted_Connection=false;User ID=sa;Password=123456");
                ////  options.UseSqlServer(nooshDarooConnectionString);
                options.EnableSensitiveDataLogging();

            });




            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();

            return services;
        }
    }
}
