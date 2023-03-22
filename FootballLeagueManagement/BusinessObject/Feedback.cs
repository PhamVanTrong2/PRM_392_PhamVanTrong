using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Feedback
{
    public string Username { get; set; } = null!;

    public string Problem { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int RateId { get; set; }

    public int FeedbackId { get; set; }

    public virtual Rate Rate { get; set; } = null!;
}
