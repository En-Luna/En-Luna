using System.ComponentModel;

namespace En_Luna.ViewModels
{
    public class ProjectDeliverableEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [DisplayName("File Format")]
        public string FileFormat { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
