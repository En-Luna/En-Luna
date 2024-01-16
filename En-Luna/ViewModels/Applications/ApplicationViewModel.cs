namespace En_Luna.ViewModels
{
    public class ApplicationViewModel
    {
        public int Id { get; set; }
        public int SolicitationRoleId { get; set; }
        public int ContractorId { get; set; }
        public string UserId { get; set; }
        public string RoleDescription { get; set; }
        public string ContractorName { get; set; }
        public string ContractorProfession { get; set; }
        public string ContractorDiscipline { get; set; }
        public bool Accepted { get; set; }
        public bool PositionHasBeenFilled { get; set; }
    }
}
