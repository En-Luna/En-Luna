using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class SolicitationRoleProfile : Profile
    {
        public SolicitationRoleProfile()
        {
            CreateMap<SolicitationRole, SolicitationRoleViewModel>().ReverseMap();
            CreateMap<SolicitationRole, SolicitationRoleEditViewModel>().ReverseMap();
            CreateMap<SolicitationRole, SolicitationRoleViewModel>()
                .ForMember(dest => dest.ProjectDeliverable, opt => opt.MapFrom(x => x.ProjectDeliverable))
                .ForMember(dest => dest.RequiredProfessionDiscipline, opt => opt.MapFrom(x => x.RequiredProfessionDiscipline)); 
        
            CreateMap<SolicitationRoleViewModel, SolicitationRole>()
                .ForMember(dest => dest.ProjectDeliverable, opt => opt.MapFrom(x => x.ProjectDeliverable))
                .ForMember(dest => dest.RequiredProfessionDiscipline, opt => opt.Ignore());
            
        
        }
    }
}
