using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication.Permission
{
    public enum CustomerPermission
    {      

        View=1,
        Create=2,
        Edit=3,
        Delete=4,
        Print=5
    }

    public enum OrderPermission
    {

        View = 6,
        Create = 7,
        Edit = 8,
        Delete = 9,
     

    }
}
