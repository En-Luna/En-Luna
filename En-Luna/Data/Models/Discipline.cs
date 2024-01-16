using System.Collections.ObjectModel;

namespace En_Luna.Data.Models
{
    /// <summary>
    /// The discipline model. Think "I am a CIVIL engineer" or
    /// "I am a SOFTWARE engineer"
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class Discipline : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Navigational property. Gets or sets the Focus.
        /// </summary>
        /// <value>
        /// The Focus.
        /// </value>
        public virtual ICollection<Focus>? Focuses { get; set; } = new Collection<Focus>();

        /// <summary>
        /// Navgiational property. Gets or sets the profession disciplines.
        /// </summary>
        /// <value>
        /// The profession disciplines.
        /// </value>
        public virtual ICollection<ProfessionDiscipline> ProfessionDisciplines { get; set; } = new Collection<ProfessionDiscipline>();
    }
}
