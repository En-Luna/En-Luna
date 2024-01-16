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
    public class StatesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStateService _stateService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatesController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public StatesController(IMapper mapper, IStateService service)
        {
            _mapper = mapper;
            _stateService = service;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<State> states = _stateService.List();

            IPagedList<StateViewModel> stateViewModels = states
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<State, StateViewModel>(_mapper);

            StateIndexViewModel model = new StateIndexViewModel
            {
                States = stateViewModels
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
            State? state = id.HasValue
                ? _stateService.Get(x => x.Id == id.Value)
                : new State();

            if (state == null)
            {
                return RedirectToAction("Index");
            }

            StateEditViewModel model = _mapper.Map<StateEditViewModel>(state);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(StateEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                State? state = _stateService.Get(x => x.Id == model.Id);
                _mapper.Map(model, state);
                _stateService.Update(state);
            }
            else
            {
                State state = _mapper.Map<State>(model);
                _stateService.Create(state);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            State? state = _stateService.Get(x => x.Id == id);

            if (state == null)
            {
                return Json(false);
            }

            _stateService.Delete(state);

            return Json(true);
        }
    }
}
