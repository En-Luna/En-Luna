using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    public interface ISolicitationRoleService : IBaseService<SolicitationRole>
    {
        /// <summary>
        /// Activates the specified solicitation.
        /// </summary>
        /// <param name="solicitation">The solicitation.</param>
        /// <returns></returns>
        public SolicitationRole Activate(SolicitationRole solicitation);

        /// <summary>
        /// Approves the specified solicitation.
        /// </summary>
        /// <param name="solicitation">The solicitation.</param>
        /// <param name="isApproved">if set to <c>true</c> [is approved].</param>
        /// <returns></returns>
        public SolicitationRole Approve(SolicitationRole solicitation, bool isApproved);

        /// <summary>
        /// Cancels the specified solicitation.
        /// </summary>
        /// <param name="solicitation">The solicitation.</param>
        /// <param name="isCancelled">if set to <c>true</c> [is cancelled].</param>
        /// <returns></returns>
        public SolicitationRole Cancel(SolicitationRole solicitation, bool isCancelled);

        /// <summary>
        /// Completes the specified solicitation.
        /// </summary>
        /// <param name="solicitation">The solicitation.</param>
        /// <param name="isComplete">if set to <c>true</c> [is complete].</param>
        /// <returns></returns>
        public SolicitationRole Complete(SolicitationRole solicitation, bool isComplete);

        /// <summary>
        /// Deactivates the specified solicitation.
        /// </summary>
        /// <param name="solicitation">The solicitation.</param>
        /// <returns></returns>
        public SolicitationRole Deactivate(SolicitationRole solicitation);
    }
}
