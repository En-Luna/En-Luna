using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class ContractorSoftwareService : BaseService<ContractorSoftware>, IContractorSoftwareService
    {
        public ContractorSoftwareService(ApplicationContext context) : base(context)
        {
        }
    }
}
