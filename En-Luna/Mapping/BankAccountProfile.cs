using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.ViewModels;

namespace Jobbie.Web.Mapping
{
    public class BankAccountProfile : Profile
    {
        public BankAccountProfile()
        {
            CreateMap<BankAccount, BankAccountViewModel>().ReverseMap();
            CreateMap<BankAccount, BankAccountEditViewModel>().ReverseMap();
        }
    }
}
