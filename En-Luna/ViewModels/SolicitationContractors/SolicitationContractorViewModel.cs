using System.Collections.ObjectModel;

namespace En_Luna.ViewModels
{
    public class SolicitationContractorViewModel
    {
        public int Id { get; set; }
        public int ContractorId { get; set; }
        public int SolicitationId { get; set; }
        public int SolicitationRoleId { get; set; }
        public ContractorViewModel? Contractor { get; set; }
        public SolicitationViewModel? Solicitation { get; set; }
        public SolicitationRoleViewModel? SolicitationRole { get; set; }
        public ICollection<StatusUpdateViewModel> StatusUpdates { get; set; } = new Collection<StatusUpdateViewModel>();
    }
}
