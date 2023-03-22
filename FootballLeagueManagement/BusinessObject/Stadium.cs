using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Stadium
{
    public int StadiumId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Club> Clubs { get; } = new List<Club>();
}
