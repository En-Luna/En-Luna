using System.Collections.ObjectModel;

namespace En_Luna.Data.Models
{
    /// <summary>
    /// The focus model. Represents any focuses a discipline might have.
    /// Think "I am a civil engineer that FOCUSES ON TRANSPORTATION"
    /// or "I am a software engineer that FOCUSES ON WEB DEV"
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class Focus : BaseEntity
    {
        /// <summary>
        /// Gets or sets the discipline identifier.
        /// </summary>
        /// <value>
        /// The discipline identifier.
        /// </value>
        public int DisciplineId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the discipline.
        /// </summary>
        /// <value>
        /// The discipline.
        /// </value>
        public virtual Discipline? Discipline { get; set; }

        /// <summary>
        /// Gets or sets the expertises.
        /// </summary>
        /// <value>
        /// The expertises.
        /// </value>
        public virtual ICollection<Expertise> Expertises { get; set; } = new Collection<Expertise>();
    }
}
