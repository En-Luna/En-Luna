using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.Data.Services;
using En_Luna.Extensions;
using En_Luna.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using X.PagedList;

namespace Jobbie.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProjectDeliverablesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProjectDeliverableService _projectDeliverableService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectDeliverablesController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public ProjectDeliverablesController(IMapper mapper, IProjectDeliverableService service)
        {
            _mapper = mapper;
            _projectDeliverableService = service;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<ProjectDeliverable> projectDeliverables = _projectDeliverableService.List();

            IPagedList<ProjectDeliverableViewModel> projectDeliverableViewModels = projectDeliverables
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<ProjectDeliverable, ProjectDeliverableViewModel>(_mapper);

            ProjectDeliverableIndexViewModel model = new ProjectDeliverableIndexViewModel
            {
                ProjectDeliverables = projectDeliverableViewModels
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
            ProjectDeliverable? projectDeliverable = id.HasValue
                ? _projectDeliverableService.Get(x => x.Id == id.Value)
                : new ProjectDeliverable();

            if (projectDeliverable == null)
            {
                return RedirectToAction("Index");
            }

            ProjectDeliverableEditViewModel model = _mapper.Map<ProjectDeliverableEditViewModel>(projectDeliverable);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(ProjectDeliverableEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                ProjectDeliverable? projectDeliverable = _projectDeliverableService.Get(x => x.Id == model.Id);
                _mapper.Map(model, projectDeliverable);
                _projectDeliverableService.Update(projectDeliverable);
            }
            else
            {
                ProjectDeliverable projectDeliverable = _mapper.Map<ProjectDeliverable>(model);
                _projectDeliverableService.Create(projectDeliverable);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            ProjectDeliverable? projectDeliverable = _projectDeliverableService.Get(x => x.Id == id);

            if (projectDeliverable == null)
            {
                return Json(false);
            }

            _projectDeliverableService.Delete(projectDeliverable);

            return Json(true);
        }
    }
}
