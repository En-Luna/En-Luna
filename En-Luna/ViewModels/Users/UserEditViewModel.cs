using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace En_Luna.ViewModels
{
    public class UserEditViewModel
    {
        public UserEditViewModel()
        {
            if (this.Id == null)
            {
                this.Id = Guid.NewGuid().ToString();
            }
        }

        public string? Id { get; set; }
        public int AddressId { get; set; }
        public int BankAccountId { get; set; }
        public int ContractorId { get; set; }
        public int? SolicitorId { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;


        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("About Me")]
        public string AboutMe { get; set; } = string.Empty;

        [Required]
        [DisplayName("Phone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [DisplayName("SSN")]
        public string SocialSecurityNumber { get; set; } = string.Empty;

        [Required]
        [DisplayName("Hours Available Per Week")]
        public int HoursAvailablePerWeek { get; set; }

        [DisplayName("Current Workload (Hours per Week)")]
        public int CurrentWorkload { get; set; } // todo this should be calculated in mapping profile

        [DisplayName("Verified")]
        public bool IsVerified { get; set; }

        [DisplayName("Employer Identification Number")]
        public string EmployerIdentificationNumber { get; set; } = string.Empty;

        [DisplayName("Company Name")]
        public string CompanyName { get; set; } = string.Empty;

        public int? CompanyTypeId { get; set; }

        [DisplayName("Company Type")]
        public SelectList? CompanyTypes { get; set; }

        [DisplayName("Solicitor?")]
        public bool IsSolicitor { get; set; }

        public BankAccountEditViewModel BankAccount { get; set; } = new();
        public AddressEditViewModel Address { get; set; } = new();
        public ContractorEditViewModel Contractor { get; set; } = new();
        public SolicitorEditViewModel Solicitor { get; set; } = new();
    }
}
