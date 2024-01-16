using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    /// <inheritdoc />
    public class SolicitationRoleService : BaseService<SolicitationRole>, ISolicitationRoleService
    {
        public SolicitationRoleService(ApplicationContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public SolicitationRole Activate(SolicitationRole solicitation)
        {
            solicitation.IsActive = true;
            _context.SolicitationRoles.Update(solicitation);
            _context.SaveChanges();
            return solicitation;
        }

        /// <inheritdoc />
        public SolicitationRole Approve(SolicitationRole solicitation, bool isApproved)
        {
            solicitation.IsApproved = isApproved;
            _context.SolicitationRoles.Update(solicitation);
            _context.SaveChanges();
            return solicitation;
        }

        /// <inheritdoc />
        public SolicitationRole Cancel(SolicitationRole solicitation, bool isCancelled)
        {
            solicitation.IsCancelled = isCancelled;
            _context.SolicitationRoles.Update(solicitation);
            _context.SaveChanges();
            return solicitation;
        }

        /// <inheritdoc />
        public SolicitationRole Complete(SolicitationRole solicitation, bool isComplete)
        {
            solicitation.IsComplete = isComplete;
            _context.SolicitationRoles.Update(solicitation);
            _context.SaveChanges();
            return solicitation;
        }

        /// <inheritdoc />
        public SolicitationRole Deactivate(SolicitationRole solicitation)
        {
            solicitation.IsActive = false;
            _context.SolicitationRoles.Update(solicitation);
            _context.SaveChanges();
            return solicitation;
        }
    }
}
