using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.CrudTest;

public partial class Module
{
    public long Id { get; set; }

    public string? ModuleName { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
