using System;
using System.Collections.Generic;

namespace DEMO_dev.Domain.Entities;

public partial class LabelUser
{
    public int Id { get; set; }

    public int LabelId { get; set; }

    public string UserId { get; set; } = null!;

    public virtual Label Label { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
