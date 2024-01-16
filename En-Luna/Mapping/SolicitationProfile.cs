using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class SolicitationProfile : Profile
    {
        public SolicitationProfile()
        {
            CreateMap<Solicitation, SolicitationViewModel>()
                .ForMember(dest => dest.SolicitationRoles, opt => opt.MapFrom(
                    x => x.Roles
                ))
                .ForMember(x => x.DeadlineType, opt => opt.MapFrom(dest => dest.Deadline.DeadlineType));

            CreateMap<SolicitationEditViewModel, Solicitation>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(
                    x => x.SolicitationRoles
                ))
                .ForMember(dest => dest.Deadline, opt => opt.MapFrom(x => x.SolicitationDeadline));

            CreateMap<Solicitation, SolicitationEditViewModel>()
                .ForMember(dest => dest.States, opt => opt.Ignore())
                .ForMember(dest => dest.SolicitationRoles, opt => opt.MapFrom(
                    x => x.Roles
                ))
                .ForMember(dest => dest.SolicitationDeadline, opt => opt.MapFrom(x => x.Deadline));
        }
    }
}
