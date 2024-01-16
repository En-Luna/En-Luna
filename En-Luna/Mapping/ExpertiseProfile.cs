using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class ExpertiseProfile : Profile
    {
        public ExpertiseProfile()
        {
            CreateMap<Expertise, ExpertiseViewModel>().ReverseMap();
            CreateMap<Expertise, ExpertiseEditViewModel>().ReverseMap();
        }
    }
}
