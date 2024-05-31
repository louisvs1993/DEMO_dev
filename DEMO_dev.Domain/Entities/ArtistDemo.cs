using System;
using System.Collections.Generic;

namespace DEMO_dev.Domain.Entities;

public partial class ArtistDemo
{
    public int Id { get; set; }

    public int ArtistId { get; set; }

    public int DemoId { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual Demo Demo { get; set; } = null!;
}
