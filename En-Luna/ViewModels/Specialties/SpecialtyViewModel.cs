namespace En_Luna.ViewModels
{
    public class SpecialtyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ExpertiseId { get; set; }
        public ExpertiseViewModel? Expertise { get; set; }
    }
}
