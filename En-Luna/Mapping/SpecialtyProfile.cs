using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class SpecialtyProfile : Profile
    {
        public SpecialtyProfile()
        {
            CreateMap<Specialty, SpecialtyViewModel>().ReverseMap();
            CreateMap<Specialty, SpecialtyEditViewModel>().ReverseMap();
        }
    }
}
