namespace En_Luna.Data.Models
{
    /// <summary>
    /// The solicitation role provided software. Represents
    /// the software that will be provided for use for a specific
    /// solicitation role.
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class SolicitationRoleProvidedSoftware : BaseEntity
    {
        /// <summary>
        /// Gets or sets the solicitation role identifier.
        /// </summary>
        /// <value>
        /// The solicitation role identifier.
        /// </value>
        public int SolicitationRoleId { get; set; }

        /// <summary>
        /// Gets or sets the software identifier.
        /// </summary>
        /// <value>
        /// The software identifier.
        /// </value>
        public int SoftwareId { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the solicitation role.
        /// </summary>
        /// <value>
        /// The solicitation role.
        /// </value>
        public virtual SolicitationRole? SolicitationRole { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the software.
        /// </summary>
        /// <value>
        /// The software.
        /// </value>
        public virtual Software? Software { get; set; }
    }
}
