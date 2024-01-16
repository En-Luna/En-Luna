using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class DisciplineService : BaseService<Discipline>, IDisciplineService
    {
        public DisciplineService(ApplicationContext context) : base(context)
        {
        }
    }
}
