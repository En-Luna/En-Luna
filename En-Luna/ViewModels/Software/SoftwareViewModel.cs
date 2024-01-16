namespace En_Luna.ViewModels
{
    public class SoftwareViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsSubscription { get; set; }
        public double SubscriptionMonthlyCost { get; set; }
        public double InitialPurchaseCost { get; set; }
    }
}
