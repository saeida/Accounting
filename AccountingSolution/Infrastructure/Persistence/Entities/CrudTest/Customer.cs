using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities.CrudTest;

public partial class Customer
{
    public long Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public long? PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public string BankAccountNumber { get; set; } = null!;
}
