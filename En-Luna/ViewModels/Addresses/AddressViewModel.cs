namespace En_Luna.ViewModels
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int StateId { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = "USA";
        public StateViewModel? State { get; set; }
    }
}
