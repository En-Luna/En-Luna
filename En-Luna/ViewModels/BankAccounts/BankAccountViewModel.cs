namespace En_Luna.ViewModels
{
    public class BankAccountViewModel
    {
        public int Id { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string RoutingNumber { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
    }
}
