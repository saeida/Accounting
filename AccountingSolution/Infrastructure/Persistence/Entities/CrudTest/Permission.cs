using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.CrudTest;

public partial class Permission
{
    public long Id { get; set; }

    public string? PermissionType { get; set; }

    public long? ModuleId { get; set; }

    public virtual ICollection<AccessControlList> AccessControlLists { get; set; } = new List<AccessControlList>();

    public virtual Module? Module { get; set; }
}
