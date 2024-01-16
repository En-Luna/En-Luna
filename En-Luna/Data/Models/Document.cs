namespace En_Luna.Data.Models
{
    /// <summary>
    /// The document model. Represents any uploaded
    /// document.
    /// </summary>
    public class Document : BaseEntity
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public string? UserId {get;set;}

        /// <summary>
        /// Gets or sets a value indicating whether this instance is verified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is verified; otherwise, <c>false</c>.
        /// </value>
        public bool IsVerified { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        public virtual User? User { get; set; }
    }
}
