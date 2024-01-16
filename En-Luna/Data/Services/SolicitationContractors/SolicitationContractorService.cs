using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class SolicitationContractorService : BaseService<SolicitationContractor>, ISolicitationContractorService
    {
        public SolicitationContractorService(ApplicationContext context) : base(context)
        {
        }
    }
}
