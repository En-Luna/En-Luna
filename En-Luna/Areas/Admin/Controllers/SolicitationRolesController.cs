using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.Data.Services;
using En_Luna.Extensions;
using En_Luna.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using X.PagedList;

namespace Jobbie.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SolicitationRolesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISolicitationRoleService _solicitationRoleService;
        private readonly ISolicitationService _solicitationService;
        private readonly IProjectDeliverableService _projectDeliverableService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolicitationRolesController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="solicitationRoleService">The solicitation role service.</param>
        /// <param name="solicitationService">The solicitation service.</param>
        /// <param name="projectDeliverableService">The project deliverable service.</param>
        public SolicitationRolesController(IMapper mapper, 
            ISolicitationRoleService solicitationRoleService, 
            ISolicitationService solicitationService, 
            IProjectDeliverableService projectDeliverableService)
        {
            _mapper = mapper;
            _solicitationRoleService = solicitationRoleService;
            _solicitationService = solicitationService;
            _projectDeliverableService = projectDeliverableService;
        }


        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<SolicitationRole> solicitationRoles = _solicitationRoleService.List();

            IPagedList<SolicitationRoleViewModel> solicitationRoleViewModels = solicitationRoles
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<SolicitationRole, SolicitationRoleViewModel>(_mapper);

            SolicitationRoleIndexViewModel model = new SolicitationRoleIndexViewModel
            {
                SolicitationRoles = solicitationRoleViewModels
            };

            return View(model);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
            SolicitationRole? solicitationRole = id.HasValue
                ? _solicitationRoleService.Get(x => x.Id == id.Value)
                : new SolicitationRole();

            if (solicitationRole == null)
            {
                return RedirectToAction("Index");
            }

            SolicitationRoleEditViewModel model = _mapper.Map<SolicitationRoleEditViewModel>(solicitationRole);
            InstantiateSelectLists(model);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(SolicitationRoleEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                SolicitationRole? solicitationRole = _solicitationRoleService.Get(x => x.Id == model.Id);
                _mapper.Map(model, solicitationRole);
                _solicitationRoleService.Update(solicitationRole);
            }
            else
            {
                SolicitationRole solicitationRole = _mapper.Map<SolicitationRole>(model);
                _solicitationRoleService.Create(solicitationRole);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Activate(int id)
        {
            SolicitationRole? solicitation = _solicitationRoleService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationRoleService.Activate(solicitation);

            return Json(true);
        }

        public JsonResult Deactivate(int id)
        {
            SolicitationRole? solicitation = _solicitationRoleService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationRoleService.Deactivate(solicitation);

            return Json(true);
        }

        public JsonResult Complete(int id, bool isComplete)
        {
            SolicitationRole? solicitation = _solicitationRoleService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationRoleService.Complete(solicitation, isComplete);

            return Json(true);
        }

        public JsonResult Approve(int id, bool isApproved)
        {
            SolicitationRole? solicitation = _solicitationRoleService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationRoleService.Approve(solicitation, isApproved);

            return Json(true);
        }

        public JsonResult Cancel(int id, bool isCancelled)
        {
            SolicitationRole? solicitation = _solicitationRoleService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationRoleService.Cancel(solicitation, isCancelled);

            return Json(true);
        }

        public JsonResult Delete(int id)
        {
            SolicitationRole? solicitationRole = _solicitationRoleService.Get(x => x.Id == id);

            if (solicitationRole == null)
            {
                return Json(false);
            }

            _solicitationRoleService.Delete(solicitationRole);

            return Json(true);
        }
        
        private void InstantiateSelectLists(SolicitationRoleEditViewModel model)
        {
            model.Solicitations = new SelectList(_solicitationService.List(), "Id", "Name", model.SolicitationId);
            model.ProjectDeliverables = new SelectList(_projectDeliverableService.List(), "Id", "Name", model.ProjectDeliverableId);
        }
    }
}
