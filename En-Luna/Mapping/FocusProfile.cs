using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class FocusProfile : Profile
    {
        public FocusProfile()
        {
            CreateMap<Focus, FocusViewModel>().ReverseMap();
            CreateMap<Focus, FocusEditViewModel>().ReverseMap();
        }
    }
}
