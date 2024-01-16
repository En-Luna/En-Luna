using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace En_Luna.Data.Models
{
    /// <summary>
    /// The profession discipline model. Represents the various
    /// combinations of profession and discipline.
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class ProfessionDiscipline : BaseEntity
    {
        /// <summary>
        /// Gets or sets the job type identifier.
        /// </summary>
        /// <value>
        /// The job type identifier.
        /// </value>
        public int ProfessionId { get; set; }

        /// <summary>
        /// Gets or sets the job subtype identifier.
        /// </summary>
        /// <value>
        /// The job subtype identifier.
        /// </value>
        public int DisciplineId { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the type of the job.
        /// </summary>
        /// <value>
        /// The type of the job.
        /// </value>
        public virtual Profession? Profession { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the job subtype.
        /// </summary>
        /// <value>
        /// The job subtype.
        /// </value>
        public virtual Discipline? Discipline { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the contractors.
        /// </summary>
        /// <value>
        /// The contractors.
        /// </value>
        public virtual ICollection<Contractor> Contractors { get; set; } = new Collection<Contractor>();

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [NotMapped]
        public string Name
        {
            get
            {
                return $"{this.Profession?.Name} - {this.Discipline?.Name}";
            }
        }
    }
}
