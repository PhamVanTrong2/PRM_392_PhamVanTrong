using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Rate
{
    public int RateId { get; set; }

    public string RateName { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();
}
