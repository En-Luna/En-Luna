using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class FocusService : BaseService<Focus>, IFocusService
    {
        public FocusService(ApplicationContext context) : base(context)
        {
        }
    }
}
