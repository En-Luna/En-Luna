using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class StateService : BaseService<State>, IStateService
    {
        public StateService(ApplicationContext context) : base(context)
        {
        }
    }
}
