using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace En_Luna.ViewModels
{
    public class SolicitationDeadlineEditViewModel
    {
        public int Id { get; set; }
        public int SolicitationId { get; set; }

        [DisplayName("Deadline Type")]
        public int DeadlineTypeId { get; set; }

        [Required]
        [DisplayName("Deadline Date")]
        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; } = DateTime.Now;

        public SelectList? DeadlineTypes { get; set; }
    }
}
