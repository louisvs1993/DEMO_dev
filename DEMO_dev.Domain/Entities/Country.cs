using System;
using System.Collections.Generic;

namespace DEMO_dev.Domain.Entities;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Initials { get; set; } = null!;

    public virtual ICollection<Label> Labels { get; set; } = new List<Label>();
}
