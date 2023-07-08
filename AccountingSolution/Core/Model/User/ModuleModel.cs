using Domain.Model.Customer;
using System;
using System.Collections.Generic;

namespace Domain.Model.User;

public partial class ModuleModel
{
    public long Id { get; set; }

    public string? ModuleName { get; set; }

    public virtual ICollection<PermissionModel> Permissions { get; set; } = new List<PermissionModel>();
}
