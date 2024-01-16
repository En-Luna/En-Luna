using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class ProfessionProfile : Profile
    {
        public ProfessionProfile()
        {
            CreateMap<Profession, ProfessionViewModel>().ReverseMap();
            CreateMap<Profession, ProfessionEditViewModel>().ReverseMap();
        }
    }
}
