using AutoMapper;
using En_Luna.Data;
using En_Luna.Data.Models;
using En_Luna.Extensions;
using En_Luna.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly UserManager<User> _userManager;

        public ContractorsController(IMapper mapper, ApplicationContext context, UserManager<User> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("Contracts/{contractorId:int}/{page:int?}")]
        public IActionResult Contracts(int contractorId, int? page)
        {
            var contractor = _context.Contractors
                .Include("SolicitationRoles.Solicitation")
                .FirstOrDefault(x => x.Id == contractorId);

            if (contractor == null)
            {
                return RedirectToAction("Index");
            }

            IPagedList<SolicitationRoleViewModel> solicitationViewModels = contractor.SolicitationRoles
                .ToPagedList(page ?? 1, Constants.Constants.PageSize)
                .Map<SolicitationRole, SolicitationRoleViewModel>(_mapper);

            SolicitationRoleIndexViewModel model = new SolicitationRoleIndexViewModel
            {
                SolicitationRoles = solicitationViewModels
            };

            return View(model);
        }

        [HttpGet("View/{solicitationRoleId:int}")]
        public async Task<IActionResult> View(int solicitationRoleId)
        {
            var solicitationRole = _context.SolicitationRoles
                .Include("Solicitation.Solicitor.Account")
                .Include("Solicitation.Deadline.DeadlineType")
                .Include(x => x.ProjectDeliverable)
                .FirstOrDefault(x => x.Id == solicitationRoleId);

            if (solicitationRole == null) 
            {
                var user = await _userManager.GetUserAsync(User);
                return RedirectToAction("Contracts", new { user.ContractorId });
            }

            var model = _mapper.Map<SolicitationRoleViewModel>(solicitationRole);
            return View(model);
        }
    }
}
