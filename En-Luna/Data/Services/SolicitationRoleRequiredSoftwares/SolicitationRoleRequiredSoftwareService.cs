using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class SolicitationRoleRequiredSoftwareService : BaseService<SolicitationRoleRequiredSoftware>, ISolicitationRoleRequiredSoftwareService
    {
        public SolicitationRoleRequiredSoftwareService(ApplicationContext context) : base(context)
        {
        }
    }
}
