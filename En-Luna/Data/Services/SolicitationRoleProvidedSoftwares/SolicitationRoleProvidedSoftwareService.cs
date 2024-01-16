using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class SolicitationRoleProvidedSoftwareService : BaseService<SolicitationRoleProvidedSoftware>, ISolicitationRoleProvidedSoftwareService
    {
        public SolicitationRoleProvidedSoftwareService(ApplicationContext context) : base(context)
        {
        }
    }
}
