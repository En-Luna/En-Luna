using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class ProjectDeliverableService : BaseService<ProjectDeliverable>, IProjectDeliverableService
    {
        public ProjectDeliverableService(ApplicationContext context) : base(context)
        {
        }
    }
}
