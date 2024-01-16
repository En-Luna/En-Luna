namespace En_Luna.Data.Models
{
    public class Application : BaseEntity
    {
        public int ContractorId { get; set; }
        public int SolicitationRoleId { get; set; }
        public bool Accepted { get; set; }

        public Contractor Contractor { get; set; }
        public SolicitationRole SolicitationRole { get; set; }
    }
}
