using System;
using System.Collections.Generic;

namespace DEMO_dev.Domain.Entities;

public partial class Demo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Filepath { get; set; } = null!;

    public DateOnly SubmissionDate { get; set; }

    public virtual ICollection<ArtistDemo> ArtistDemos { get; set; } = new List<ArtistDemo>();

    public virtual ICollection<LabelDemo> LabelDemos { get; set; } = new List<LabelDemo>();
}
