using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace En_Luna.ViewModels
{
    public class LicenseEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Contractor")]
        public int ContractorId { get; set; }
        public SelectList? Contractors { get; set; }

        [Required]
        [DisplayName("State")]
        public int StateId { get; set; }
        public SelectList? States { get; set; }

        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }

        [DisplayName("Verified?")]
        public bool IsVerified { get; set; }

        [Required]
        [DisplayName("License Number")]
        public string LicenseNumber { get; set; } = string.Empty;
    }
}
