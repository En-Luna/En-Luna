namespace En_Luna.Data.Models
{
    /// <summary>
    /// The status update model. Represents any update
    /// for a solicitation. Can be made by contractor or solicitor.
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class StatusUpdate : BaseEntity
    {
        /// <summary>
        /// Gets or sets the solicitation contractor identifier.
        /// </summary>
        /// <value>
        /// The solicitation contractor identifier.
        /// </value>
        public int? SolicitationContractorId { get; set; }

        /// <summary>
        /// Gets or sets the solicitor identifier.
        /// </summary>
        /// <value>
        /// The solicitor identifier.
        /// </value>
        public int? SolicitorId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Navigational property. Gets or sets the contractor.
        /// </summary>
        /// <value>
        /// The contractor.
        /// </value>
        public virtual SolicitationContractor? Contractor { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the solicitor.
        /// </summary>
        /// <value>
        /// The solicitor.
        /// </value>
        public virtual Solicitor? Solicitor { get; set; }
    }
}
