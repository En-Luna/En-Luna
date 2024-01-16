using AutoMapper;
using En_Luna.Data;
using En_Luna.Data.Models;
using En_Luna.Extensions;
using En_Luna.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Jobbie.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProjectDeliverablesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectDeliverablesController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        public ProjectDeliverablesController(IMapper mapper, ApplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<ProjectDeliverable> projectDeliverables = _context.ProjectDeliverables.ToList();

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
                ? _context.ProjectDeliverables.FirstOrDefault(x => x.Id == id.Value)
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
                return View(model);
            }

            if (model.Id != 0)
            {
                ProjectDeliverable? projectDeliverable = _context.ProjectDeliverables.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, projectDeliverable);
                _context.ProjectDeliverables.Update(projectDeliverable);
            }
            else
            {
                ProjectDeliverable projectDeliverable = _mapper.Map<ProjectDeliverable>(model);
                _context.ProjectDeliverables.Add(projectDeliverable);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            ProjectDeliverable? projectDeliverable = _context.ProjectDeliverables.FirstOrDefault(x => x.Id == id);

            if (projectDeliverable == null)
            {
                return Json(false);
            }

            _context.ProjectDeliverables.Remove(projectDeliverable);
            _context.SaveChanges();

            return Json(true);
        }
    }
}
