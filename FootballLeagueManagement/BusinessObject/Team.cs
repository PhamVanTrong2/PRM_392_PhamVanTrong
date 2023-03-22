using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Team
{
    public int PlayerId { get; set; }

    public int MatchId { get; set; }

    public bool? Starting { get; set; }

    public virtual Match Match { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
