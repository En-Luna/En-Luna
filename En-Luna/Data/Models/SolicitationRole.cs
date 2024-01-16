using System.Collections.ObjectModel;

namespace En_Luna.Data.Models
{
    /// <summary>
    /// The solicitation role model. Represents a specific role
    /// for the job.
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class SolicitationRole : BaseEntity
    {
        /// <summary>
        /// Gets or sets the solicitation identifier.
        /// </summary>
        /// <value>
        /// The solicitation identifier.
        /// </value>
        public int SolicitationId { get; set; }

        /// <summary>
        /// Gets or sets the project deliverable identifier.
        /// </summary>
        /// <value>
        /// The project deliverable identifier.
        /// </value>
        public int ProjectDeliverableId  { get; set; }

        /// <summary>
        /// Gets or sets the required profession discipline identifier.
        /// </summary>
        public int? RequiredProfessionDisciplineId {  get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has contractor.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has contractor; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>Marked true when contractor has been hired by solicitor.</remarks>
        public bool HasContractor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is complete.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is cancelled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is cancelled; otherwise, <c>false</c>.
        /// </value>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is approved.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is approved; otherwise, <c>false</c>.
        /// </value>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>This is true when Solicitation is active and the Solicitor has activated the SolicitationRole</remarks>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the lump sum.
        /// </summary>
        /// <value>
        /// The lump sum.
        /// </value>
        public double LumpSum { get; set; }

        /// <summary>
        /// Gets or sets the hourly rate.
        /// </summary>
        /// <value>
        /// The hourly rate.
        /// </value>
        public double HourlyRate { get; set; }

        /// <summary>
        /// Gets or sets the sign bonus.
        /// </summary>
        /// <value>
        /// The sign bonus.
        /// </value>
        /// <remarks>Amount paid when contractor is hired for project. non-refundable.</remarks>
        public double SignBonus  { get; set; }

        /// <summary>
        /// Gets or sets the workload.
        /// </summary>
        /// <value>
        /// The workload.
        /// </value>
        /// <remarks>Amount of hours the role should take. Used to help estimate contractors available time.</remarks>
        public double Workload  { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the deliverable deadline.
        /// </summary>
        /// <value>
        /// The deliverable deadline.
        /// </value>
        public DateTime DeliverableDeadline  { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [contractor terminated].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [contractor terminated]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>When Contractor is fired by Solicitor the SolicitationRole can be readvertised on the platform</remarks>
        public bool ContractorTerminated  { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [contractor paid].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [contractor paid]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>Verified by site mods when project complete </remarks>
        public bool ContractorPaid { get; set; }

        /// <summary>
        /// Gets or sets the solicitation.
        /// </summary>
        /// <value>
        /// The solicitation.
        /// </value>
        public virtual Solicitation? Solicitation { get; set; }

        /// <summary>
        /// Gets or sets the project deliverable.
        /// </summary>
        /// <value>
        /// The project deliverable.
        /// </value>
        public virtual ProjectDeliverable? ProjectDeliverable { get; set; }
        
        /// <summary>
        /// Gets or sets the required profession discipline.
        /// </summary>
        public virtual ProfessionDiscipline? RequiredProfessionDiscipline { get; set; }
        /// <summary>
        /// Gets or sets the reviews.
        /// </summary>
        /// <value>
        /// The reviews.
        /// </value>
        public virtual ICollection<Review> Reviews { get; set; } = new Collection<Review>();

        /// <summary>
        /// Gets or sets the required software for the role.
        /// </summary>
        /// <value>
        /// The required software.
        /// </value>
        public virtual ICollection<SolicitationRoleRequiredSoftware> RequiredSoftware { get; set; } = new Collection<SolicitationRoleRequiredSoftware>();

        /// <summary>
        /// Gets or sets the provided software for the role.
        /// </summary>
        /// <value>
        /// The provided software.
        /// </value>
        public virtual ICollection<SolicitationRoleProvidedSoftware> ProvidedSoftware { get; set; } = new Collection<SolicitationRoleProvidedSoftware>();
    }
}
