using Domain.Model.Customer;
using System;
using System.Collections.Generic;

namespace Domain.Model.User;

public partial class AccessControlListModel
{
    public long Id { get; set; }

    public long? RoleId { get; set; }

    public long? PermissionId { get; set; }

    public virtual PermissionModel? Permission { get; set; }

    public virtual RoleModel? Role { get; set; }
}
