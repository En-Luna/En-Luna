using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class SpecialtyService : BaseService<Specialty>, ISpecialtyService
    {
        public SpecialtyService(ApplicationContext context) : base(context)
        {
        }
    }
}
