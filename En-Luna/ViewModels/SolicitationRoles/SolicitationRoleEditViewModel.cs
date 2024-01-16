using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace En_Luna.ViewModels
{
    public class SolicitationRoleEditViewModel
    {
        public int Id { get; set; }

        [DisplayName("Lump Sum")]
        public double LumpSum { get; set; }

        [DisplayName("Hourly Rate")]
        public double HourlyRate { get; set; }

        [DisplayName("Sign-on Bonus")]
        public double SignBonus { get; set; }

        [Required]
        [DisplayName("Workload (Hours per Week)")]
        public double Workload { get; set; }

        public string Description { get; set; } = string.Empty;

        [Required]
        [DisplayName("Deliverable Deadline")]
        [DataType(DataType.Date)]
        public DateTime DeliverableDeadline { get; set; } = DateTime.Now.AddMonths(1);

        [DisplayName("Contractor Terminated")]
        public bool ContractorTerminated { get; set; }

        [DisplayName("Contractor Paid")]
        public bool ContractorPaid { get; set; }

        [DisplayName("Has Contractor")]
        public bool HasContractor { get; set; }

        [DisplayName("Complete")]
        public bool IsComplete { get; set; }

        [DisplayName("Cancelled")]
        public bool IsCancelled { get; set; }

        [DisplayName("Approved")]
        public bool IsApproved { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [Required]
        [DisplayName("Solicitation")]
        public int SolicitationId { get; set; }
        public SelectList? Solicitations { get; set; }

        [DisplayName("Project Deliverable")]
        public int? ProjectDeliverableId { get; set; }
        public SelectList? ProjectDeliverables { get; set; }
        
        [DisplayName("Profession Discipline")]
        public int? RequiredProfessionDisciplineId { get; set; }
        public SelectList? ProfessionDisciplines { get; set; }

        public List<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();

        public List<SoftwareViewModel> RequiredSoftware { get; set; } = new List<SoftwareViewModel>();

        public List<SoftwareViewModel> ProvidedSoftware { get; set; } = new List<SoftwareViewModel>();
    }
}
