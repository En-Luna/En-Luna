using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class SolicitationDeadlineProfile : Profile
    {
        public SolicitationDeadlineProfile()
        {
            CreateMap<SolicitationDeadlineEditViewModel, SolicitationDeadline>();
            CreateMap<SolicitationDeadline, SolicitationDeadlineEditViewModel>()
                .ForMember(dest => dest.DeadlineTypes, opt => opt.Ignore());
        }
    }
}
