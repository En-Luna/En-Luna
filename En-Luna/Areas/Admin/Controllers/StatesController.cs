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
    public class StatesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatesController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        public StatesController(IMapper mapper, ApplicationContext context)
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
            IEnumerable<State> states = _context.States.ToList();

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
                ? _context.States.FirstOrDefault(x => x.Id == id.Value)
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
                State? state = _context.States.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, state);
                _context.States.Update(state);
            }
            else
            {
                State state = _mapper.Map<State>(model);
                _context.States.Add(state);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            State? state = _context.States.FirstOrDefault(x => x.Id == id);

            if (state == null)
            {
                return Json(false);
            }

            _context.States.Remove(state);
            _context.SaveChanges();

            return Json(true);
        }
    }
}
