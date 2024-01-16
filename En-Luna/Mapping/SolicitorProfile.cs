using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class SolicitorProfile : Profile
    {
        public SolicitorProfile()
        {
            CreateMap<Solicitor, SolicitorViewModel>().ReverseMap();
            CreateMap<Solicitor, SolicitorEditViewModel>().ReverseMap();
        }
    }
}
