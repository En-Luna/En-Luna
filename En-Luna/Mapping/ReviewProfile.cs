using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewViewModel>().ReverseMap();
            CreateMap<Review, ReviewEditViewModel>().ReverseMap();
        }
    }
}
