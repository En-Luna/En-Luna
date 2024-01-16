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
    public class SolicitationsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolicitationsController"/> class.
        /// </summary>
        /// <param name="mapper"></param>>
        public SolicitationsController(IMapper mapper, ApplicationContext context)
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
            IEnumerable<Solicitation> solicitations = _context.Solicitations.ToList();

            IPagedList<SolicitationViewModel> solicitationViewModels = solicitations
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<Solicitation, SolicitationViewModel>(_mapper);

            SolicitationIndexViewModel model = new SolicitationIndexViewModel
            {
                Solicitations = solicitationViewModels
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
            Solicitation? solicitation = id.HasValue
                ? _context.Solicitations.FirstOrDefault(x => x.Id == id.Value)
                : new Solicitation();

            if (solicitation == null)
            {
                return RedirectToAction("Index");
            }

            SolicitationEditViewModel model = _mapper.Map<SolicitationEditViewModel>(solicitation);
            InstantiateSelectLists(model);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(SolicitationEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                Solicitation? solicitation = _context.Solicitations.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, solicitation);
                _context.Solicitations.Update(solicitation);
            }
            else
            {
                Solicitation solicitation = _mapper.Map<Solicitation>(model);
                _context.Solicitations.Add(solicitation);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult Activate(int id)
        {
            Solicitation? solicitation = _context.Solicitations.FirstOrDefault(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            solicitation.IsActive = true;
            _context.Solicitations.Update(solicitation);
            _context.SaveChanges();

            return Json(true);
        }
        
        public JsonResult Deactivate(int id)
        {
            Solicitation? solicitation = _context.Solicitations.FirstOrDefault(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }
            solicitation.IsActive = false;
            _context.Solicitations.Update(solicitation);
            _context.SaveChanges();

            return Json(true);
        }

        public JsonResult Complete(int id, bool isComplete)
        {
            Solicitation? solicitation = _context.Solicitations.FirstOrDefault(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            solicitation.IsComplete = isComplete;
            _context.Solicitations.Update(solicitation);
            _context.SaveChanges();

            return Json(true);
        }

        public JsonResult Approve(int id, bool isApproved)
        {
            // todo send approved in ajax post
            isApproved = true;

            Solicitation? solicitation = _context.Solicitations.FirstOrDefault(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            solicitation.IsApproved = isApproved;
            _context.Solicitations.Update(solicitation);
            _context.SaveChanges();

            return Json(true);
        }
        public JsonResult Cancel(int id, bool isCancelled)
        {
            Solicitation? solicitation = _context.Solicitations.FirstOrDefault(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            solicitation.IsCancelled = isCancelled;
            _context.Solicitations.Update(solicitation);
            _context.SaveChanges();

            return Json(true);
        }

        private void InstantiateSelectLists(SolicitationEditViewModel model)
        {
            model.States = new SelectList(_context.States.ToList(), "Id", "Name", model.StateId);
        }
    }
}
