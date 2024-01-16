using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class ContractorService : BaseService<Contractor>, IContractorService
    {
        public ContractorService(ApplicationContext context) : base(context)
        {
        }
    }
}
