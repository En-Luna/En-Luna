namespace En_Luna.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public int? ContractorAccountId { get; set; }
        public int? SolicitorAccountId { get; set; }
        public int ReviewerId { get; set; }
        public int SolicitationRoleId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
