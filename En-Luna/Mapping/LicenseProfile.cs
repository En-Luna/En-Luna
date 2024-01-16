using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class LicenseProfile : Profile
    {
        public LicenseProfile()
        {
            CreateMap<License, LicenseViewModel>().ReverseMap();
            CreateMap<License, LicenseEditViewModel>().ReverseMap();
        }
    }
}
