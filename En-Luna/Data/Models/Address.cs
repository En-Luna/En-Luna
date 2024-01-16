namespace En_Luna.Data.Models
{
    /// <summary>
    /// The address model.
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class Address : BaseEntity
    {
        /// <summary>
        /// Gets or sets the address1.
        /// </summary>
        /// <value>
        /// The address1.
        /// </value>
        public string Address1 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the address2.
        /// </summary>
        /// <value>
        /// The address2.
        /// </value>
        public string? Address2 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the state identifier.
        /// </summary>
        /// <value>
        /// The state identifier.
        /// </value>
        public int StateId { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        public string ZipCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string? Country { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public virtual State? State { get; set; }
    }
}
