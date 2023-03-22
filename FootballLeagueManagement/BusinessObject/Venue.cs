using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Venue
{
    public int VenueId { get; set; }

    public string? Name { get; set; }

    public int? AudienceCapacity { get; set; }

    public virtual ICollection<Match> Matches { get; } = new List<Match>();
}
