using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class DeadlineTypeProfile : Profile
    {
        public DeadlineTypeProfile()
        {
            CreateMap<DeadlineType, DeadlineTypeViewModel>().ReverseMap();
            CreateMap<DeadlineType, DeadlineTypeEditViewModel>().ReverseMap();
        }
    }
}
