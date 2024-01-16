using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class SolicitationContractorProfile : Profile
    {
        public SolicitationContractorProfile()
        {
            CreateMap<SolicitationContractor, SolicitationContractorViewModel>().ReverseMap();
            CreateMap<SolicitationContractor, SolicitationContractorEditViewModel>().ReverseMap();
        }
    }
}
