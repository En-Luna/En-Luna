using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class CompanyTypeProfile : Profile
    {
        public CompanyTypeProfile()
        {
            CreateMap<CompanyType, CompanyTypeViewModel>().ReverseMap();
            CreateMap<CompanyType, CompanyTypeEditViewModel>().ReverseMap();
        }
    }
}
