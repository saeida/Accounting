using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.CrudTest;

public partial class Role
{
    public long Id { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<AccessControlList> AccessControlLists { get; set; } = new List<AccessControlList>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
