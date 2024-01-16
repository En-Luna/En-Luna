using System.ComponentModel;

namespace En_Luna.ViewModels
{
    public class BankAccountEditViewModel
    {
        public int Id { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; } = string.Empty;

        [DisplayName("Routing Number")]
        public string RoutingNumber { get; set; } = string.Empty;

        [DisplayName("Account Type")]
        public string AccountType { get; set; } = string.Empty;

        [DisplayName("Account Number")]
        public string AccountNumber { get; set; } = string.Empty;

        [DisplayName("Verified")]
        public bool IsVerified { get; set; }
    }
}
