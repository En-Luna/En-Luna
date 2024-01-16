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
    public class ExpertisesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IExpertiseService _expertiseService;
        private readonly IFocusService _focusService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpertisesController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="service">The service.</param>
        /// <param name="focusService">The focus service.</param>
        public ExpertisesController(IMapper mapper, IExpertiseService service, IFocusService focusService)
        {
            _mapper = mapper;
            _expertiseService = service;
            _focusService = focusService;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<Expertise> expertises = _expertiseService.List();

            IPagedList<ExpertiseViewModel> expertiseViewModels = expertises
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<Expertise, ExpertiseViewModel>(_mapper);

            ExpertiseIndexViewModel model = new ExpertiseIndexViewModel
            {
                Expertises = expertiseViewModels
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
            Expertise? expertise = id.HasValue
                ? _expertiseService.Get(x => x.Id == id.Value)
                : new Expertise();

            if (expertise == null)
            {
                return RedirectToAction("Index");
            }

            ExpertiseEditViewModel model = _mapper.Map<ExpertiseEditViewModel>(expertise);
            InstantiateSelectLists(model);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(ExpertiseEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                Expertise? expertise = _expertiseService.Get(x => x.Id == model.Id);
                _mapper.Map(model, expertise);
                _expertiseService.Update(expertise);
            }
            else
            {
                Expertise expertise = _mapper.Map<Expertise>(model);
                _expertiseService.Create(expertise);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            Expertise? expertise = _expertiseService.Get(x => x.Id == id);

            if (expertise == null)
            {
                return Json(false);
            }

            _expertiseService.Delete(expertise);

            return Json(true);
        }

        private void InstantiateSelectLists(ExpertiseEditViewModel model)
        {
            model.Focuses = new SelectList(_focusService.List(), "Id", "Name", model.FocusId);
        }
    }
}
