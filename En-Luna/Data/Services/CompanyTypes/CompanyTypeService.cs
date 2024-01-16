using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class CompanyTypeService : BaseService<CompanyType>, ICompanyTypeService
    {
        public CompanyTypeService(ApplicationContext context) : base(context)
        {
        }
    }
}
