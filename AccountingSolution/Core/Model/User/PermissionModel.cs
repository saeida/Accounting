using Domain.Model.User;
using System;
using System.Collections.Generic;

namespace Domain.Model.Customer;

public partial class PermissionModel
{
    public long Id { get; set; }

    public string? PermissionType { get; set; }

    public long? ModuleId { get; set; }

    public virtual ICollection<AccessControlListModel> AccessControlLists { get; set; } = new List<AccessControlListModel>();

    public virtual ModuleModel? Module { get; set; }
}
