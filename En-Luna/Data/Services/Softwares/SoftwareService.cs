using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class SoftwareService : BaseService<Software>, ISoftwareService
    {
        public SoftwareService(ApplicationContext context) : base(context)
        {
        }
    }
}
