using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication.JWT
{
    public class JwtOptionSetup:IConfigureOptions<JwtOptions>
    {
        public const string sectionName = "Jwt";
        private readonly IConfiguration _configuration;
        
        public JwtOptionSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(sectionName).Bind(options);
        }
    }
}
