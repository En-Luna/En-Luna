using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class DeadlineTypeService : BaseService<DeadlineType>, IDeadlineTypeService
    {
        public DeadlineTypeService(ApplicationContext context) : base(context)
        {
        }
    }
}
