using System;
using System.Collections.Generic;

namespace DEMO_dev.Domain.Entities;

public partial class ArtistUser
{
    public int Id { get; set; }

    public int ArtistId { get; set; }

    public string UserId { get; set; } = null!;

    public virtual Artist Artist { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
