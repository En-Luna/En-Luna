using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class StatusUpdateService : BaseService<StatusUpdate>, IStatusUpdateService
    {
        public StatusUpdateService(ApplicationContext context) : base(context)
        {
        }
    }
}
