using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace En_Luna.ViewModels
{
    public class SpecialtyEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [DisplayName("Expertise")]
        public int ExpertiseId { get; set; }
        public SelectList? Expertises { get; set; }
    }
}
