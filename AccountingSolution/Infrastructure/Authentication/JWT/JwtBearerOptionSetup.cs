using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication.JWT
{
    public class JwtBearerOptionSetup : IConfigureNamedOptions<JwtBearerOptions>
    {
        public readonly JwtOptions _jwtOptions;

        public JwtBearerOptionSetup (IOptions<JwtOptions> jwtOptions )
        {
            _jwtOptions = jwtOptions.Value;
        }
        public void Configure(string name, JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuerSigningKey = true, // this will validate the 3rd part of the jwt token using the secret that we added in the appsettings and verify we have generated the jwt token
                                                 // سبب خواهد شد تا میان‌افزار اعتبارسنجی، بررسی کند که آیا توکن دریافتی از سمت کاربر توسط برنامه‌ی ما امضاء شده‌است یا خیر؟
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), // Add the secret key to our Jwt encryption
                ValidateIssuer = true,//سروری که آن توکن را ایجاد کرده است را معتبر می سازید؟
                ValidateAudience = true,//طمینان حاصل می کنید که گیرنده توکن مجاز به دریافت آن است
                RequireExpirationTime = false,
                ValidateLifetime = true,//به معنای بررسی خودکار طول عمر توکن دریافتی از سمت کاربر است. اگر توکن منقضی شده باشد، اعتبارسنجی به صورت خودکار خاتمه خواهد یافت.
                //  بررسی می کنید که توکن منقضی نشده باشد و کلید امضای صادرکننده معتبر باشد. 

                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Audience,

                // Allow to use seconds for expiration of token
                // Required only when token lifetime less than 5 minutes
                //ه معنای تنظیم یک تلرانس و حد تحمل مدت زمان منقضی شدن توکن در حالت ValidateLifetime است. در اینجا به صفر تنظیم شده‌است.
                ClockSkew = TimeSpan.Zero
            };
        }

        public void Configure(JwtBearerOptions options)
        {
            Configure(Options.DefaultName, options);
        }
    }
}
