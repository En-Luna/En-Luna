using System.Collections.ObjectModel;

namespace En_Luna.Data.Models
{
    /// <summary>
    /// The profession model. Think "I am an ENGINEER". 
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class Profession : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether this instance has subtype.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has subtype; otherwise, <c>false</c>.
        /// </value>
        public bool HasSubtype { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has license.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has license; otherwise, <c>false</c>.
        /// </value>
        public bool HasLicense { get; set; }

        /// <summary>
        /// Navgiational property. Gets or sets the profession disciplines.
        /// </summary>
        /// <value>
        /// The profession disciplines.
        /// </value>
        public virtual ICollection<ProfessionDiscipline> ProfessionDisciplines { get; set; } = new Collection<ProfessionDiscipline>();
    }
}
