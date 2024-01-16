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
    public class DisciplinesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDisciplineService _disciplineService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisciplinesController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="disciplineService"></param>
        public DisciplinesController(IMapper mapper, IDisciplineService disciplineService)
        {
            _mapper = mapper;
            _disciplineService = disciplineService;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<Discipline> disciplines = _disciplineService.List();

            IPagedList<DisciplineViewModel> disciplineViewModels = disciplines
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<Discipline, DisciplineViewModel>(_mapper);

            DisciplineIndexViewModel model = new DisciplineIndexViewModel
            {
                Disciplines = disciplineViewModels
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
            Discipline? discipline = id.HasValue
                ? _disciplineService.Get(x => x.Id == id.Value)
                : new Discipline();

            if (discipline == null)
            {
                return RedirectToAction("Index");
            }

            DisciplineEditViewModel model = _mapper.Map<DisciplineEditViewModel>(discipline);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(DisciplineEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                Discipline? discipline = _disciplineService.Get(x => x.Id == model.Id);
                _mapper.Map(model, discipline);
                _disciplineService.Update(discipline);
            }
            else
            {
                Discipline discipline = _mapper.Map<Discipline>(model);
                _disciplineService.Create(discipline);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            Discipline? discipline = _disciplineService.Get(x => x.Id == id);

            if (discipline == null)
            {
                return Json(false);
            }

            _disciplineService.Delete(discipline);

            return Json(true);
        }
    }
}
