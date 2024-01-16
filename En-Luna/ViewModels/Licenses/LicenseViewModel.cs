
namespace En_Luna.ViewModels
{
    public class LicenseViewModel
    {
        public int Id { get; set; }
        public int ContractorId { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public bool IsVerified { get; set; }
        public string LicenseNumber { get; set; } = string.Empty;
        public ContractorViewModel? Contractor { get; set; }
        public StateViewModel? State { get; set; }
    }
}
