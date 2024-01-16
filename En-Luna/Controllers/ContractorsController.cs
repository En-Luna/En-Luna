using AutoMapper;
using En_Luna.Data;
using En_Luna.Data.Models;
using En_Luna.Extensions;
using En_Luna.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace En_Luna.Controllers
{
    [Route("Contractors")]
    //[Authorize(Roles = "Solicitor")]
    public class ContractorsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public ContractorsController(IMapper mapper, ApplicationContext context)
        {
            _mapper = mapper;
            _context = context;
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
            var contractor = _context.Contractors
                .Include("Solicitations.Solicitation")
                .FirstOrDefault(x => x.Id == contractorId);

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
