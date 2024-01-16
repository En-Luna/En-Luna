namespace En_Luna.Data.Models
{
    /// <summary>
    /// The error log model. Used to record exceptions
    /// internally.
    /// </summary>
    public class ErrorLog
    {
        /// <summary>
        /// Gets or sets the error log identifier.
        /// </summary>
        /// <value>
        /// The error log identifier.
        /// </value>
        public Guid ErrorLogId { get; set; }

        /// <summary>
        /// Gets or sets the error location.
        /// </summary>
        /// <value>
        /// The error location.
        /// </value>
        public string ErrorLocation { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the error date.
        /// </summary>
        /// <value>
        /// The error date.
        /// </value>
        public DateTime ErrorDate { get; set; }
    }
}
