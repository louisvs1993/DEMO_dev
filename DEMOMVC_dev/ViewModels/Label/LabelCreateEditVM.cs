using DEMO_dev.Domain.Entities;
using DEMO_dev.Models;
using System.ComponentModel;

namespace DEMO_dev.ViewModels.Label
{
    public class LabelCreateEditVM
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Picture { get; set; }

        public string? Bio { get; set; }

        [DisplayName("Country")]
        public int CountryId { get; set; }

        public string CompanyNumber { get; set; } = null!;
    }
}
