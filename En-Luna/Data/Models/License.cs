namespace En_Luna.Data.Models
{
    /// <summary>
    /// The license model. Represents any license a contractor
    /// may have.
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class License : BaseEntity
    {
        /// <summary>
        /// Gets or sets the contractor identifier.
        /// </summary>
        /// <value>
        /// The contractor identifier.
        /// </value>
        public int ContractorId { get; set; }

        /// <summary>
        /// Gets or sets the state identifier.
        /// </summary>
        /// <value>
        /// The state identifier.
        /// </value>
        public int StateId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is verified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is verified; otherwise, <c>false</c>.
        /// </value>
        public bool IsVerified { get; set; }

        /// <summary>
        /// Gets or sets the government identifier.
        /// </summary>
        /// <value>
        /// The government identifier.
        /// </value>
        public string LicenseNumber { get; set; } = string.Empty;

        /// <summary>
        /// Navigational property. Gets or sets the contractor.
        /// </summary>
        /// <value>
        /// The contractor.
        /// </value>
        public virtual Contractor? Contractor { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public virtual State? State { get; set; }
    }
}
