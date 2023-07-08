using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.User
{
    public class UserModel
    {
       public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public bool IsActive { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
            public DateTime LastLoginDate { get; set; }
            public DateTime CreationDate { get; set; }
        public long? RoleId { get; set; }

        public virtual RoleModel? RoleModel { get; set; }

    }
}
