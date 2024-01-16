using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class ProjectDeliverableProfile : Profile
    {
        public ProjectDeliverableProfile()
        {
            CreateMap<ProjectDeliverable, ProjectDeliverableViewModel>().ReverseMap();
            CreateMap<ProjectDeliverable, ProjectDeliverableEditViewModel>().ReverseMap();
        }
    }
}
