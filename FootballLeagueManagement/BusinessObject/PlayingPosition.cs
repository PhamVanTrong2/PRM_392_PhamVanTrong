using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class PlayingPosition
{
    public string PositionId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Player> Players { get; } = new List<Player>();
}
