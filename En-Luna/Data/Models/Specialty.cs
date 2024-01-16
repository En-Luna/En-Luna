namespace En_Luna.Data.Models
{
    /// <summary>
    /// The specialty model. Represents any specialties
    /// an expertise might have. Think "I am a civil engineer that focuses on transportation with an
    /// expertise in traffic who specializes in roadway design" or
    /// "I am a software engineer that focuses on web dev with an expertise in 
    /// back end dev who specializes in .NET"
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class Specialty : BaseEntity
    {
        /// <summary>
        /// Gets or sets the expertise identifier.
        /// </summary>
        /// <value>
        /// The expertise identifier.
        /// </value>
        public int ExpertiseId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the expertise.
        /// </summary>
        /// <value>
        /// The expertise.
        /// </value>
        public virtual Expertise? Expertise { get; set; }
    }
}
