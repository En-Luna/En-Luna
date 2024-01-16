using System.Collections.ObjectModel;

namespace En_Luna.Data.Models
{
    /// <summary>
    /// The Expertise model. Represents any expertises
    /// that a focus may have.
    /// Think "I am a civil engineer that focuses on transportation with an
    /// expertise in traffic" or
    /// "I am a software engineer that focuses on web dev with an expertise in 
    /// back end dev"
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class Expertise : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the job subtype identifier.
        /// </summary>
        /// <value>
        /// The job subtype identifier.
        /// </value>
        public int FocusId { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the job subtype.
        /// </summary>
        /// <value>
        /// The job subtype.
        /// </value>
        public virtual Focus? Focus { get; set; }

        /// <summary>
        /// Gets or sets the specialties.
        /// </summary>
        /// <value>
        /// The specialties.
        /// </value>
        public virtual ICollection<Specialty> Specialties { get; set; } = new Collection<Specialty>();
    }
}
