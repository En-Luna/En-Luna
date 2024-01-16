namespace En_Luna.Data.Models
{
    /// <summary>
    /// The deadline type model.
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class DeadlineType : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; } = string.Empty;
    }
}
