using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class MatchResult
{
    public int MatchId { get; set; }

    public int ClubId { get; set; }

    public string? WinLose { get; set; }

    public int? GoalScore { get; set; }

    public int? Shots { get; set; }

    public int? Ontarget { get; set; }

    public int? Control { get; set; }

    public int? Fouls { get; set; }

    public int? Corners { get; set; }

    public int? Offsides { get; set; }

    public string? PlayStage { get; set; }

    public virtual Player Club { get; set; } = null!;

    public virtual Match Match { get; set; } = null!;
}
