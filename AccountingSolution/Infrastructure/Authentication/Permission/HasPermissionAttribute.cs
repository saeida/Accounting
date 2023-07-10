using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication.Permission
{
    public sealed class HasPermissionAttribute:AuthorizeAttribute
    {
        public HasPermissionAttribute(object permission)
        {
            if (!(permission is Enum))
            {
                throw new ArgumentException("Argument must be an enum");
            }

            Policy = Convert.ToInt32(permission).ToString();
        }
    }
}
