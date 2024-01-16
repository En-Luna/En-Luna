using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class SolicitorService : BaseService<Solicitor>, ISolicitorService
    {
        public SolicitorService(ApplicationContext context) : base(context)
        {
        }
    }
}
