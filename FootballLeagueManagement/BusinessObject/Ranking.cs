using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Ranking
{
    public int ClubId { get; set; }

    public string? ClubName { get; set; }

    public int? MatchPlayed { get; set; }

    public int? Won { get; set; }

    public int? Drawn { get; set; }

    public int? Lost { get; set; }

    public int? GoalDifference { get; set; }

    public virtual Club Club { get; set; } = null!;
}
