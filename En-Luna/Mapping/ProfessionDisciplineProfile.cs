using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class ProfessionDisciplineProfile : Profile
    {
        public ProfessionDisciplineProfile()
        {
            CreateMap<ProfessionDiscipline, ProfessionDisciplineViewModel>().ReverseMap();
            CreateMap<ProfessionDiscipline, ProfessionDisciplineEditViewModel>().ReverseMap();
        }
    }
}
