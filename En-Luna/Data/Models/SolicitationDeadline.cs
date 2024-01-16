namespace En_Luna.Data.Models
{
    /// <summary>
    /// The solicitation deadline model. 
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class SolicitationDeadline : BaseEntity
    {
        /// <summary>
        /// Gets or sets the solicitation identifier.
        /// </summary>
        /// <value>
        /// The solicitation identifier.
        /// </value>
        public int SolicitationId { get; set; }

        /// <summary>
        /// Gets or sets the deadline type identifier.
        /// </summary>
        /// <value>
        /// The deadline type identifier.
        /// </value>
        public int DeadlineTypeId { get; set; }

        /// <summary>
        /// Gets or sets the deadline date.
        /// </summary>
        /// <value>
        /// The deadline date.
        /// </value>
        public DateTime DeadlineDate { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the solicitation.
        /// </summary>
        /// <value>
        /// The solicitation.
        /// </value>
        public virtual Solicitation? Solicitation { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the type of the deadline.
        /// </summary>
        /// <value>
        /// The type of the deadline.
        /// </value>
        public virtual DeadlineType? DeadlineType { get; set; }
    }
}
