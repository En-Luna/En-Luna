using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class DisciplineProfile : Profile
    {
        public DisciplineProfile()
        {
            CreateMap<Discipline, DisciplineViewModel>().ReverseMap();
            CreateMap<Discipline, DisciplineEditViewModel>().ReverseMap();
        }
    }
}
