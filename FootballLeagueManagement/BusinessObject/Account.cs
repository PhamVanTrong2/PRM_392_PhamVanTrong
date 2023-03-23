using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Account
{
    public string Username { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public DateTime? Dob { get; set; }

    public int? ClubId { get; set; }

    public virtual Player? Club { get; set; }

    public virtual ICollection<Role> Roles { get; } = new List<Role>();
}
