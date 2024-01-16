using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class StatusUpdateProfile : Profile
    {
        public StatusUpdateProfile()
        {
            CreateMap<StatusUpdate, StatusUpdateViewModel>().ReverseMap();
            CreateMap<StatusUpdate, StatusUpdateEditViewModel>().ReverseMap();
        }
    }
}
