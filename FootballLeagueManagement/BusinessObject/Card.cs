using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Card
{
    public int PlayerId { get; set; }

    public int MatchId { get; set; }

    public int? CardTime { get; set; }

    public bool? CardType { get; set; }

    public int CardId { get; set; }

    public virtual Match Match { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
