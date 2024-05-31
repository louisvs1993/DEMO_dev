using System;
using System.Collections.Generic;

namespace DEMO_dev.Domain.Entities;

public partial class Artist
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Picture { get; set; }

    public string? Bio { get; set; }

    public virtual ICollection<ArtistDemo> ArtistDemos { get; set; } = new List<ArtistDemo>();

    public virtual ICollection<ArtistUser> ArtistUsers { get; set; } = new List<ArtistUser>();
}
