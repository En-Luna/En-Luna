namespace En_Luna.Data.Models
{
    /// <summary>
    /// The state model.
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class State : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the abbreviation.
        /// </summary>
        /// <value>
        /// The abbreviation.
        /// </value>
        public string Abbreviation { get; set; } = string.Empty;
    }
}
