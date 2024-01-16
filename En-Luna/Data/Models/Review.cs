namespace En_Luna.Data.Models
{
    /// <summary>
    /// The review model. 
    /// </summary>
    /// <seealso cref="En_Luna.Models.BaseEntity" />
    public class Review : BaseEntity
    {
        /// <summary>
        /// Gets or sets the contractor account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        /// <remarks>This relates to the account the review is for.</remarks>
        public string? ContractorUserId { get; set; }

        /// <summary>
        /// Gets or sets the solicitor account identifier.
        /// </summary>
        /// <value>
        /// The solicitor account identifier.
        /// </value>
        public string? SolicitorUserId { get; set; }

        /// <summary>
        /// Gets or sets the reviewer identifier.
        /// </summary>
        /// <value>
        /// The reviewer identifier.
        /// </value>
        /// <remarks>This relates to the account that created the review.</remarks>
        public int ReviewerId { get; set; } // TODO We need to have this point to something. Maybe a new table?

        /// <summary>
        /// Gets or sets the solicitation role identifier.
        /// </summary>
        /// <value>
        /// The solicitation role identifier.
        /// </value>
        public int SolicitationRoleId { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        /// <remarks>The number rating given to the account for the review. I.E. 1-5 stars, etc.</remarks>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        /// <value>
        /// The review.
        /// </value>
        /// <remarks>The descriptive review left for the account</remarks>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Navigational property. Gets or sets the contractor account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        public virtual User? ContractorUser { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the solicitor account.
        /// </summary>
        /// <value>
        /// The solicitor account.
        /// </value>
        public virtual User? SolicitorUser { get; set; }
    }
}
