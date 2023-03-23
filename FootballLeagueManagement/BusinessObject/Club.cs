using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Player
{
    public int ClubId { get; set; }

    public string? Name { get; set; }

    public string? YearCreated { get; set; }

    public int? CountryId { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public int? StadiumId { get; set; }

    public string? LogoUrl { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual Country? Country { get; set; }

    public virtual ICollection<Match> MatchGuests { get; } = new List<Match>();

    public virtual ICollection<Match> MatchHosts { get; } = new List<Match>();

    public virtual ICollection<MatchResult> MatchResults { get; } = new List<MatchResult>();

    public virtual Ranking? Ranking { get; set; }

    public virtual Stadium? Stadium { get; set; }
}
