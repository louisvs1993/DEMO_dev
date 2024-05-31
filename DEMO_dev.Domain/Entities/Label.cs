using System;
using System.Collections.Generic;

namespace DEMO_dev.Domain.Entities;

public partial class Label
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Picture { get; set; }

    public string? Bio { get; set; }

    public int CountryId { get; set; }

    public string CompanyNumber { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<LabelDemo> LabelDemos { get; set; } = new List<LabelDemo>();

    public virtual ICollection<LabelUser> LabelUsers { get; set; } = new List<LabelUser>();
}
