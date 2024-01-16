namespace En_Luna.Data.Models
{
    /// <summary>
    /// The project deliverable. Represents the expected
    /// result for a solicitation role.
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class ProjectDeliverable : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the file format.
        /// </summary>
        /// <value>
        /// The file format.
        /// </value>
        public string FileFormat { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; } = string.Empty;
    }
}
