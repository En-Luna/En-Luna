using AutoMapper;
using En_Luna.Data;
using En_Luna.Data.Models;
using En_Luna.Extensions;
using En_Luna.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Jobbie.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SolicitationRolesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolicitationRolesController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public SolicitationRolesController(IMapper mapper, ApplicationContext context)
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
            IEnumerable<SolicitationRole> solicitationRoles = _context.SolicitationRoles.ToList();

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
                ? _context.SolicitationRoles.FirstOrDefault(x => x.Id == id.Value)
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
                SolicitationRole? solicitationRole = _context.SolicitationRoles.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, solicitationRole);
                _context.SolicitationRoles.Update(solicitationRole);
            }
            else
            {
                SolicitationRole solicitationRole = _mapper.Map<SolicitationRole>(model);
                _context.SolicitationRoles.Add(solicitationRole);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult Activate(int id)
        {
            SolicitationRole? solicitationRole = _context.SolicitationRoles.FirstOrDefault(x => x.Id == id);

            if (solicitationRole == null)
            {
                return Json(false);
            }

            solicitationRole.IsActive = true;
            _context.SolicitationRoles.Update(solicitationRole);
            _context.SaveChanges();

            return Json(true);
        }

        public JsonResult Deactivate(int id)
        {
            SolicitationRole? solicitationRole = _context.SolicitationRoles.FirstOrDefault(x => x.Id == id);

            if (solicitationRole == null)
            {
                return Json(false);
            }

            solicitationRole.IsActive = false;
            _context.SolicitationRoles.Update(solicitationRole);
            _context.SaveChanges();

            return Json(true);
        }

        public JsonResult Complete(int id, bool isComplete)
        {
            SolicitationRole? solicitationRole = _context.SolicitationRoles.FirstOrDefault(x => x.Id == id);

            if (solicitationRole == null)
            {
                return Json(false);
            }

            solicitationRole.IsComplete = isComplete;
            _context.SolicitationRoles.Update(solicitationRole);
            _context.SaveChanges();

            return Json(true);
        }

        public JsonResult Approve(int id, bool isApproved)
        {
            SolicitationRole? solicitationRole = _context.SolicitationRoles.FirstOrDefault(x => x.Id == id);

            if (solicitationRole == null)
            {
                return Json(false);
            }

            solicitationRole.IsApproved = isApproved;
            _context.SolicitationRoles.Update(solicitationRole);
            _context.SaveChanges();

            return Json(true);
        }

        public JsonResult Cancel(int id, bool isCancelled)
        {
            SolicitationRole? solicitationRole = _context.SolicitationRoles.FirstOrDefault(x => x.Id == id);

            if (solicitationRole == null)
            {
                return Json(false);
            }

            solicitationRole.IsCancelled = isCancelled;
            _context.SolicitationRoles.Update(solicitationRole);
            _context.SaveChanges();

            return Json(true);
        }

        public JsonResult Delete(int id)
        {
            SolicitationRole? solicitationRole = _context.SolicitationRoles.FirstOrDefault(x => x.Id == id);

            if (solicitationRole == null)
            {
                return Json(false);
            }

            _context.SolicitationRoles.Remove(solicitationRole);
            _context.SaveChanges();

            return Json(true);
        }
        
        private void InstantiateSelectLists(SolicitationRoleEditViewModel model)
        {
            model.Solicitations = new SelectList(_context.Solicitations.ToList(), "Id", "Name", model.SolicitationId);
            model.ProjectDeliverables = new SelectList(_context.ProjectDeliverables.ToList(), "Id", "Name", model.ProjectDeliverableId);
        }
    }
}
