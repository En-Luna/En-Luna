using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class ContractorProfile : Profile
    {
        public ContractorProfile()
        {
            CreateMap<Contractor, ContractorViewModel>().ReverseMap();
            CreateMap<Contractor, ContractorEditViewModel>().ReverseMap();
        }
    }
}
