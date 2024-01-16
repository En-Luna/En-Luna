using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace En_Luna.ViewModels
{
    public class AddressEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Address1 { get; set; } = string.Empty;

        public string? Address2 { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        public string? Country { get; set; }

        [Required]
        public int StateId { get; set; }
        public SelectList? States { get; set; }
    }
}
