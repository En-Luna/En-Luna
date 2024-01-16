namespace En_Luna.ViewModels
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int AccountId { get; set; }
        public bool IsVerified { get; set; }

        //todo will need related account
    }
}
