namespace En_Luna.Data.Models
{
    /// <summary>
    /// The contractor software model. Represents the
    /// types of software the contractor has at their disposal.
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class ContractorSoftware : BaseEntity
    {
        /// <summary>
        /// Gets or sets the contractor identifier.
        /// </summary>
        /// <value>
        /// The contractor identifier.
        /// </value>
        public int ContractorId { get; set; }

        /// <summary>
        /// Gets or sets the software identifier.
        /// </summary>
        /// <value>
        /// The software identifier.
        /// </value>
        public int SoftwareId { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the contractor.
        /// </summary>
        /// <value>
        /// The contractor.
        /// </value>
        public virtual Contractor? Contractor { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the software.
        /// </summary>
        /// <value>
        /// The software.
        /// </value>
        public virtual Software? Software { get; set; }
    }
}
