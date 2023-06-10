using Application;
using FluentValidation;
using Infrastructure;
using Microsoft.AspNetCore.Localization;
using Serilog;
using System.Globalization;
using WebAPI.Middlewares;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

          
            // Set the default culture of the application
            var defaultCulture = new CultureInfo("fa-IR");
            CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
            CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;

            // Set the language for error messages
            //ValidatorOptions.LanguageManager.Culture = new CultureInfo("en-US");


            builder.Services.AddControllers();

            builder.Services.AddInfrastructure().AddApplication();


          //  builder.Services.AddHttpClient("MyHttpClient").AddHttpMessageHandler(() => new HeaderHandler("Accept-Language", "fa-IR"));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add IHttpContextAccessor to the service collection
            builder.Services.AddHttpContextAccessor();

          


         


            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));



        var app = builder.Build();

          


            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}