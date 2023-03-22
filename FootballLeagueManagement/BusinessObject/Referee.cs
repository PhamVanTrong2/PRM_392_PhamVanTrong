using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Referee
{
    public int RefereeId { get; set; }

    public string? RefereeName { get; set; }

    public int? CountryId { get; set; }

    public DateTime? Dob { get; set; }

    public string? Image { get; set; }

    public int? YearStarted { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Match> Matches { get; } = new List<Match>();
}
