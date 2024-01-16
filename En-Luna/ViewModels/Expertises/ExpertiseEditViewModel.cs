using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace En_Luna.ViewModels
{
    public class ExpertiseEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [DisplayName("Focus")]
        public int FocusId { get; set; }
        public SelectList? Focuses { get; set; }

    }
}
