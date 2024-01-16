using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.Data.Services;
using En_Luna.Extensions;
using En_Luna.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace En_Luna.Controllers
{
    [Route("Contractors")]
    //[Authorize(Roles = "Solicitor")]
    public class ContractorsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IContractorService _contractorService;

        public ContractorsController(IMapper mapper, IContractorService contractorService)
        {
            _mapper = mapper;
            _contractorService = contractorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AvailableContractors()
        {
            return View();
        }

        [HttpGet("Contracts/{contractorId:int}/{page:int?}")]
        public IActionResult Contracts(int contractorId, int? page)
        {
            var contractor = _contractorService.Get("Solicitations.Solicitation", x => x.Id == contractorId);

            if (contractor == null)
            {
                return RedirectToAction("Index");
            }

            IPagedList<SolicitationViewModel> solicitationViewModels = contractor.Solicitations.Select(x => x.Solicitation)
                .ToPagedList(page ?? 1, Constants.Constants.PageSize)
                .Map<Solicitation, SolicitationViewModel>(_mapper);

            SolicitationIndexViewModel model = new SolicitationIndexViewModel
            {
                Solicitations = solicitationViewModels
            };

            return View(model);
        }
    }
}
