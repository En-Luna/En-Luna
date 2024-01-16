using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateViewModel>().ReverseMap();
            CreateMap<State, StateEditViewModel>().ReverseMap();
        }
    }
}
