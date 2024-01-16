using En_Luna.Data.Models;

namespace En_Luna.Data.Services
{
    public interface ISolicitationService : IBaseService<Solicitation>
    {
        /// <summary>
        /// Activates the specified solicitation.
        /// </summary>
        /// <param name="solicitation">The solicitation.</param>
        /// <returns></returns>
        public Solicitation Activate(Solicitation solicitation);

        /// <summary>
        /// Approves the specified solicitation.
        /// </summary>
        /// <param name="solicitation">The solicitation.</param>
        /// <param name="isApproved">if set to <c>true</c> [is approved].</param>
        /// <returns></returns>
        public Solicitation Approve(Solicitation solicitation, bool isApproved);

        /// <summary>
        /// Cancels the specified solicitation.
        /// </summary>
        /// <param name="solicitation">The solicitation.</param>
        /// <param name="isCancelled">if set to <c>true</c> [is cancelled].</param>
        /// <returns></returns>
        public Solicitation Cancel(Solicitation solicitation, bool isCancelled);

        /// <summary>
        /// Completes the specified solicitation.
        /// </summary>
        /// <param name="solicitation">The solicitation.</param>
        /// <param name="isComplete">if set to <c>true</c> [is complete].</param>
        /// <returns></returns>
        public Solicitation Complete(Solicitation solicitation, bool isComplete);

        /// <summary>
        /// Deactivates the specified solicitation.
        /// </summary>
        /// <param name="solicitation">The solicitation.</param>
        /// <returns></returns>
        public Solicitation Deactivate(Solicitation solicitation);
    }
}
