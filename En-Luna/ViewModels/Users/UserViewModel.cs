using System.Collections.ObjectModel;

namespace En_Luna.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; } = string.Empty;

        public int ContractorId { get; set; }

        public int? SolicitorId { get; set; }

        public int BankAccountId { get; set; }

        public int AddressId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string AboutMe { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public int? CompanyTypeId { get; set; }

        public string EmployerIdentificationNumber { get; set; } = string.Empty;

        public string SocialSecurityNumber { get; set; } = string.Empty;

        public bool IsVerified { get; set; }

        public int HoursAvailablePerWeek { get; set; }

        public int CurrentWorkload { get; set; }

        public double ContractorRating
        {
            get
            {
                return ContractorReviews.Average(x => x.Rating);
            }
        }

        public double SolicitorRating
        {
            get
            {
                return SolicitorReviews.Average(x => x.Rating);
            }
        }

        public virtual CompanyTypeViewModel? CompanyType { get; set; }

        public virtual ContractorViewModel? Contractor { get; set; }

        public virtual SolicitorViewModel? Solicitor { get; set; }

        public virtual BankAccountViewModel? BankAccount { get; set; }

        public virtual AddressViewModel? Address { get; set; }

        public virtual ICollection<DocumentViewModel> Documents { get; set; } = new Collection<DocumentViewModel>();

        public virtual ICollection<ReviewViewModel> ContractorReviews { get; set; } = new Collection<ReviewViewModel>();

        public virtual ICollection<ReviewViewModel> SolicitorReviews { get; set; } = new Collection<ReviewViewModel>();
    }
}
