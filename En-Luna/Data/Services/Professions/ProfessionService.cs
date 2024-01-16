using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class ProfessionService : BaseService<Profession>, IProfessionService
    {
        public ProfessionService(ApplicationContext context) : base(context)
        {
        }
    }
}
