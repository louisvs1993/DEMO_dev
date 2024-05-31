using System;
using System.Collections.Generic;

namespace DEMO_dev.Domain.Entities;

public partial class LabelDemo
{
    public int Id { get; set; }

    public int LabelId { get; set; }

    public int DemoId { get; set; }

    public virtual Demo Demo { get; set; } = null!;

    public virtual Label Label { get; set; } = null!;
}
