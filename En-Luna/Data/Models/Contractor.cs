using System.Collections.ObjectModel;

namespace En_Luna.Data.Models
{
    /// <summary>
    /// The contractor model.
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class Contractor : BaseEntity
    {
        /// <summary>
        /// Gets or sets the profession discipline identifier.
        /// </summary>
        /// <value>
        /// The profession discipline identifier.
        /// </value>
        public int ProfessionDisciplineId { get; set; }

        /// <summary>
        /// Gets or sets the profession discipline.
        /// </summary>
        /// <value>
        /// The profession discipline.
        /// </value>
        public virtual ProfessionDiscipline? ProfessionDiscipline { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        public virtual User? Account { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the licenses.
        /// </summary>
        /// <value>
        /// The licenses.
        /// </value>
        public virtual ICollection<License> Licenses { get; set; } = new Collection<License>();

        /// <summary>
        /// Navigational property. Gets or sets the solicitations.
        /// </summary>
        /// <value>
        /// The solicitations.
        /// </value>
        public virtual ICollection<SolicitationContractor> Solicitations { get; set; } = new Collection<SolicitationContractor>();

        /// <summary>
        /// Gets or sets the available software the contractor can use.
        /// </summary>
        /// <value>
        /// The available software.
        /// </value>
        public virtual ICollection<ContractorSoftware> AvailableSoftware { get; set; } = new Collection<ContractorSoftware>();
    }
}
