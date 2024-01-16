using En_Luna.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class ProfessionDisciplineService : BaseService<ProfessionDiscipline>, IProfessionDisciplineService
    {
        public ProfessionDisciplineService(ApplicationContext context) : base(context)
        {
        }

        public override ICollection<ProfessionDiscipline> List()
        {
            return _context.ProfessionDisciplines
                .Include(x => x.Profession)
                .Include(x => x.Discipline)
                .ToList();
        }
    }
}
