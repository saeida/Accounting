using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.CrudTest;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public string Mobile { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime LastLoginDate { get; set; }

    public DateTime CreationDate { get; set; }

    public long? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}
