using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class SolicitationDeadlineService : BaseService<SolicitationDeadline>, ISolicitationDeadlineService
    {
        public SolicitationDeadlineService(ApplicationContext context) : base(context)
        {
        }
    }
}
