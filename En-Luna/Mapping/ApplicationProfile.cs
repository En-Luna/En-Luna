using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ApplicationViewModel, Application>();
            CreateMap<Application, ApplicationViewModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(x => x.Contractor.Account.Id))
                .ForMember(dest => dest.ContractorName, opt => opt.MapFrom(x => $"{x.Contractor.Account.FirstName} {x.Contractor.Account.LastName}"))
                .ForMember(dest => dest.ContractorProfession, opt => opt.MapFrom(
                    x => x.Contractor.ProfessionDiscipline.Profession.Name
                ))
                .ForMember(dest => dest.ContractorDiscipline, opt => opt.MapFrom(
                    x => x.Contractor.ProfessionDiscipline.Discipline.Name
                ))
                .ForMember(dest => dest.RoleDescription, opt => opt.MapFrom(
                    x => x.SolicitationRole.Description
                ))
                .ForMember(dest => dest.PositionHasBeenFilled, opt => opt.MapFrom(
                    x => x.SolicitationRole.HasContractor
                ));
        }
    }
}
