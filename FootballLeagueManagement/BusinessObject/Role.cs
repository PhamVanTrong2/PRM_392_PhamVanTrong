using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Account> Usernames { get; } = new List<Account>();
}
