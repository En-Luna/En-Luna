using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class SoftwareProfile : Profile
    {
        public SoftwareProfile()
        {
            CreateMap<Software, SoftwareViewModel>().ReverseMap();
            CreateMap<Software, SoftwareEditViewModel>().ReverseMap();
        }
    }
}
