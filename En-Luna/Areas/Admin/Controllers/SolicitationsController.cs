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
    public class SolicitationsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISolicitationService _solicitationService;
        private readonly IStateService _stateService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolicitationsController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public SolicitationsController(IMapper mapper, ISolicitationService service, IStateService stateService)
        {
            _mapper = mapper;
            _solicitationService = service;
            _stateService = stateService;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<Solicitation> solicitations = _solicitationService.List();

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
                ? _solicitationService.Get(x => x.Id == id.Value)
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
                Solicitation? solicitation = _solicitationService.Get(x => x.Id == model.Id);
                _mapper.Map(model, solicitation);
                _solicitationService.Update(solicitation);
            }
            else
            {
                Solicitation solicitation = _mapper.Map<Solicitation>(model);
                _solicitationService.Create(solicitation);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Activate(int id)
        {
            Solicitation? solicitation = _solicitationService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationService.Activate(solicitation);

            return Json(true);
        }
        
        public JsonResult Deactivate(int id)
        {
            Solicitation? solicitation = _solicitationService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationService.Deactivate(solicitation);

            return Json(true);
        }

        public JsonResult Complete(int id, bool isComplete)
        {
            Solicitation? solicitation = _solicitationService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationService.Complete(solicitation, isComplete);

            return Json(true);
        }

        public JsonResult Approve(int id, bool isApproved)
        {
            // todo send approved in ajax post
            isApproved = true;

            Solicitation? solicitation = _solicitationService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationService.Approve(solicitation, isApproved);

            return Json(true);
        }
        public JsonResult Cancel(int id, bool isCancelled)
        {
            Solicitation? solicitation = _solicitationService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationService.Cancel(solicitation, isCancelled);

            return Json(true);
        }

        private void InstantiateSelectLists(SolicitationEditViewModel model)
        {
            model.States = new SelectList(_stateService.List(), "Id", "Name", model.StateId);
        }
    }
}
