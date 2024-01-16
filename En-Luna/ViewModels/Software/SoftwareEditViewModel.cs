using System.ComponentModel;

namespace En_Luna.ViewModels
{
    public class SoftwareEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [DisplayName("Subscription?")]
        public bool IsSubscription { get; set; }

        [DisplayName("Monthly Subscription Cost")]
        public double SubscriptionMonthlyCost { get; set; }

        [DisplayName("Initial Purchase Cost")]
        public double InitialPurchaseCost { get; set; }
    }
}
