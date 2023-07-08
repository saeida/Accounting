using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.CrudTest;

public partial class AccessControlList
{
    public long Id { get; set; }

    public long? RoleId { get; set; }

    public long? PermissionId { get; set; }

    public virtual Permission? Permission { get; set; }

    public virtual Role? Role { get; set; }
}
