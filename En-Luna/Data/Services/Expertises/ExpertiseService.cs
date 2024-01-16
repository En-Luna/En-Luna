using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class ExpertiseService : BaseService<Expertise>, IExpertiseService
    {
        public ExpertiseService(ApplicationContext context) : base(context)
        {
        }
    }
}
