using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Player
{
    public int PlayerId { get; set; }

    public string? Name { get; set; }

    public string? Dob { get; set; }

    public int? CountryId { get; set; }

    public string? PositionId { get; set; }

    public string? Height { get; set; }

    public string? Weight { get; set; }

    public string? Image { get; set; }

    public int? ClubId { get; set; }

    public virtual ICollection<Card> Cards { get; } = new List<Card>();

    public virtual ICollection<Goal> Goals { get; } = new List<Goal>();

    public virtual PlayingPosition? Position { get; set; }

    public virtual ICollection<Team> Teams { get; } = new List<Team>();
}
