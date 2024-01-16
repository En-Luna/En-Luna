using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<Address, AddressEditViewModel>().ReverseMap();
        }
    }
}
