using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace En_Luna.ViewModels
{
    public class SolicitationViewModel
    {
        public int Id { get; set; }

        public int SolicitorId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public bool IsComplete { get; set; }

        public bool IsApproved { get; set; }

        public bool IsCancelled { get; set; }

        public DateTime StartDate { get; set; }

        public string City { get; set; } = string.Empty;

        public string County { get; set; } = string.Empty;

        [DisplayName("Shared Drive Url")]
        public string SharedDriveUrl { get; set; } = string.Empty;

        [DisplayName("Estimated End Date")]
        [DataType(DataType.Date)]
        public DateTime EstimatedEndDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayName("Team Meeting Time")]
        public DateTime TeamMeetingTime { get; set; }

        [DisplayName("Time Zone")]
        public string? TimeZone { get; set; }

        [DisplayName("Submitted By: ")]
        public SolicitorViewModel? Solicitor { get; set; }

        public virtual ICollection<SolicitationContractorViewModel> Contractors { get; set; } = new Collection<SolicitationContractorViewModel>();

        public virtual ICollection<SolicitationRoleViewModel> SolicitationRoles { get; set; } = new Collection<SolicitationRoleViewModel>();

        public DeadlineTypeViewModel? DeadlineType { get; set; } // todo flatten with automapper
        
        public StateViewModel State { get; set; }
    }
}
