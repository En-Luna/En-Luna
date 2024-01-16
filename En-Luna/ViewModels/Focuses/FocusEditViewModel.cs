using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace En_Luna.ViewModels
{
    public class FocusEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [DisplayName("Discipline")]
        public int DisciplineId { get; set; }
        public SelectList? Disciplines { get; set; }
    }
}
