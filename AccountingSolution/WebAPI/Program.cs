using Application;
using FluentValidation;
using Infrastructure;
using Infrastructure.Authentication.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Configuration;
using System.Globalization;
using System.Text;
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
          //  builder.Services.AddSwaggerGen();

            // Add IHttpContextAccessor to the service collection
            builder.Services.AddHttpContextAccessor();


            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PresentationAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                  });



            });



            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            //builder.Services.ConfigureOptions<JwtOptionSetup>();
            //builder.Services.ConfigureOptions<JwtBearerOptionSetup>();

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("jwt"));
            var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true, // this will validate the 3rd part of the jwt token using the secret that we added in the appsettings and verify we have generated the jwt token
                                                 // سبب خواهد شد تا میان‌افزار اعتبارسنجی، بررسی کند که آیا توکن دریافتی از سمت کاربر توسط برنامه‌ی ما امضاء شده‌است یا خیر؟
                IssuerSigningKey = new SymmetricSecurityKey(key), // Add the secret key to our Jwt encryption
                ValidateIssuer = true,//سروری که آن توکن را ایجاد کرده است را معتبر می سازید؟
                ValidateAudience = true,//طمینان حاصل می کنید که گیرنده توکن مجاز به دریافت آن است
                RequireExpirationTime = false,
                ValidateLifetime = true,//به معنای بررسی خودکار طول عمر توکن دریافتی از سمت کاربر است. اگر توکن منقضی شده باشد، اعتبارسنجی به صورت خودکار خاتمه خواهد یافت.
                                        //  بررسی می کنید که توکن منقضی نشده باشد و کلید امضای صادرکننده معتبر باشد. 

                // Allow to use seconds for expiration of token
                // Required only when token lifetime less than 5 minutes
                //ه معنای تنظیم یک تلرانس و حد تحمل مدت زمان منقضی شدن توکن در حالت ValidateLifetime است. در اینجا به صفر تنظیم شده‌است.
                ClockSkew = TimeSpan.Zero
            };

            builder.Services.AddSingleton(tokenValidationParameters);


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(jwt =>
           {
               jwt.SaveToken = true;

               jwt.TokenValidationParameters = tokenValidationParameters;
           });




            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));



        var app = builder.Build();

          


            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();
         

            app.MapControllers();

            app.Run();
        }
    }
}