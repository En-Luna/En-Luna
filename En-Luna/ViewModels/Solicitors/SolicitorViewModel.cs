using System.Collections.ObjectModel;

namespace En_Luna.ViewModels
{
    public class SolicitorViewModel
    {
        public int Id { get; set; }
        public UserViewModel? Account { get; set; }
        public ICollection<SolicitationViewModel> Solicitations { get; set; } = new Collection<SolicitationViewModel>();
        public ICollection<StatusUpdateViewModel> StatusUpdates { get; set; } = new Collection<StatusUpdateViewModel>();
    }
}
