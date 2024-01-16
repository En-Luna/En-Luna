namespace En_Luna.Data.Models
{
    /// <summary>
    /// The company type model.
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class CompanyType : BaseEntity
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
