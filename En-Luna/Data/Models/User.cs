using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;

namespace En_Luna.Data.Models
{
    /// <summary>
    /// The user model. An account must have a contractor related to it,
    /// but can also have a solicitor record. I.E a user must be a contractor,
    /// but can also hire/create jobs.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Gets or sets the contractor identifier.
        /// </summary>
        /// <value>
        /// The contractor identifier.
        /// </value>
        public int ContractorId { get; set; }

        /// <summary>
        /// Gets or sets the solicitor identifier.
        /// </summary>
        /// <value>
        /// The solicitor identifier.
        /// </value>
        public int? SolicitorId { get; set; }

        /// <summary>
        /// Gets or sets the bank account identifier.
        /// </summary>
        /// <value>
        /// The bank account identifier.
        /// </value>
        public int BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets the address identifier.
        /// </summary>
        /// <value>
        /// The address identifier.
        /// </value>
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the about me.
        /// </summary>
        /// <value>
        /// The about me.
        /// </value>
        public string AboutMe { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        /// <remarks>Not required.</remarks>
        public string CompanyName { get; set;} = string.Empty;

        /// <summary>
        /// Gets or sets the company type identifier.
        /// </summary>
        /// <value>
        /// The company type identifier.
        /// </value>
        public int? CompanyTypeId { get; set; }

        /// <summary>
        /// Gets or sets the employer identification number.
        /// </summary>
        /// <value>
        /// The employer identification number.
        /// </value>
        /// <remarks>Employer Identification Number string needed if company type is LLC not required for account</remarks>
        public string EmployerIdentificationNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the social security number.
        /// </summary>
        /// <value>
        /// The social security number.
        /// </value>
        /// <remarks>Social Security Number required for tax purposes but not needed to create Account</remarks>
        public string SocialSecurityNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is verified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is verified; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>Account must be approved with BankAccount, SSN, ect before being allowed to be a Contractor</remarks>
        public bool IsVerified { get; set; }

        /// <summary>
        /// Gets or sets the hours available per week.
        /// </summary>
        /// <value>
        /// The hours available per week.
        /// </value>
        /// <remarks>User enters the amount of hours per week they are available to work.</remarks>
        public int HoursAvailablePerWeek { get; set; }

        /// <summary>
        /// Gets or sets the current workload.
        /// </summary>
        /// <value>
        /// The current workload.
        /// </value>
        /// <remarks>Value calculated by current amount of hours required per active solicitation.</remarks>
        public int CurrentWorkload { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the type of the company.
        /// </summary>
        /// <value>
        /// The type of the company.
        /// </value>
        public virtual CompanyType? CompanyType { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the contractor.
        /// </summary>
        /// <value>
        /// The contractor.
        /// </value>
        public virtual Contractor? Contractor { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the solicitor.
        /// </summary>
        /// <value>
        /// The solicitor.
        /// </value>
        public virtual Solicitor? Solicitor { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the bank account.
        /// </summary>
        /// <value>
        /// The bank account.
        /// </value>
        public virtual BankAccount? BankAccount { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public virtual Address? Address { get; set; }

        /// <summary>
        /// Navigational property. Gets or sets the documents.
        /// </summary>
        /// <value>
        /// The documents.
        /// </value>
        public virtual ICollection<Document> Documents { get; set; } = new Collection<Document>();

        /// <summary>
        /// Gets or sets the contractor reviews.
        /// </summary>
        /// <value>
        /// The contractor reviews.
        /// </value>
        /// <remarks>The total reviews given to the contractor side of the account.</remarks>
        public virtual ICollection<Review> ContractorReviews { get; set; } = new Collection<Review>();

        /// <summary>
        /// Gets or sets the solicitor reviews.
        /// </summary>
        /// <value>
        /// The solicitor reviews.
        /// </value>
        public virtual ICollection<Review> SolicitorReviews { get; set; } = new Collection<Review>();

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }
    }
}
