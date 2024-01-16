using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Document, DocumentViewModel>().ReverseMap();
            CreateMap<Document, DocumentEditViewModel>().ReverseMap();
        }
    }
}
