using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Match
{
    public int MatchId { get; set; }

    public DateTime? PlayDate { get; set; }

    public int HostId { get; set; }

    public int GuestId { get; set; }

    public int RefereeId { get; set; }

    public int? TourseasonId { get; set; }

    public string? PlayStage { get; set; }

    public int? VenueId { get; set; }

    public virtual ICollection<Card> Cards { get; } = new List<Card>();

    public virtual ICollection<Goal> Goals { get; } = new List<Goal>();

    public virtual Player Guest { get; set; } = null!;

    public virtual Player Host { get; set; } = null!;

    public virtual ICollection<MatchResult> MatchResults { get; } = new List<MatchResult>();

    public virtual Referee Referee { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; } = new List<Team>();

    public virtual Venue? Venue { get; set; }
}
