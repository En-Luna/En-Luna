using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class ApplicationService : BaseService<Application>, IApplicationService
    {
        public ApplicationService(ApplicationContext context) : base(context)
        {
        }
    }
}
