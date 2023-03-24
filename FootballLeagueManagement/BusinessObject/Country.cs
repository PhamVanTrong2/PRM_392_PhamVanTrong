using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Country
{
    public int CountryId { get; set; }

    public string? Name { get; set; }

    public string? ShortName { get; set; }

    public virtual ICollection<Club> Clubs { get; } = new List<Club>();

    public virtual ICollection<Referee> Referees { get; } = new List<Referee>();
}
