using System.Collections.ObjectModel;

namespace En_Luna.Data.Models
{
    /// <summary>
    /// The solicitation model. Represents a job.
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class Solicitation : BaseEntity
    {
        /// <summary>
        /// Gets or sets the solicitor identifier.
        /// </summary>
        /// <value>
        /// The solicitor identifier.
        /// </value>
        public int SolicitorId { get; set; }

        /// <summary>
        /// Gets or sets the solicitation title.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>This is true when a project has filled the required Roles needed,
        /// and all Contractors and the Solicitor have accepted the StartDate</remarks>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is complete.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is approved.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is approved; otherwise, <c>false</c>.
        /// </value>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is cancelled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is cancelled; otherwise, <c>false</c>.
        /// </value>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [pending approval].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [pending approval]; otherwise, <c>false</c>.
        /// </value>
        public bool PendingApproval { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the county.
        /// </summary>
        /// <value>
        /// The county.
        /// </value>
        public string County { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public int StateId { get; set; }

        /// <summary>
        /// Gets or sets the shared drive URL.
        /// </summary>
        /// <value>
        /// The shared drive URL.
        /// </value>
        public string SharedDriveUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the estimated end date.
        /// </summary>
        /// <value>
        /// The estimated end date.
        /// </value>
        public DateTime EstimatedEndDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the team meeting time.
        /// </summary>
        /// <value>
        /// The team meeting time.
        /// </value>
        public DateTime TeamMeetingTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the timezone for the team meeting time.
        /// </summary>
        public string? TimeZone { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the solicitor.
        /// </summary>
        /// <value>
        /// The solicitor.
        /// </value>
        public virtual Solicitor? Solicitor { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the deadline.
        /// </summary>
        /// <value>
        /// The deadline.
        /// </value>
        public virtual SolicitationDeadline? Deadline { get; set; } = new();

        /// <summary>
        /// Navigational property. Gets or sets the contractors.
        /// </summary>
        /// <value>
        /// The contractors.
        /// </value>
        public virtual ICollection<SolicitationContractor> Contractors { get; set; } = new Collection<SolicitationContractor>();

        /// <summary>
        /// Navigational property. Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        /// <remarks>The required roles for the solicitation.</remarks>
        public virtual ICollection<SolicitationRole> Roles { get; set; } = new Collection<SolicitationRole>();

        /// <summary>
        /// Gets or sets the states.
        /// </summary>
        /// <value>
        /// The states.
        /// </value>
        public virtual ICollection<State> States { get; set; } = new Collection<State>();

    }
}
