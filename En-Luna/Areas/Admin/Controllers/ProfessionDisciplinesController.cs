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
    public class ProfessionDisciplinesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDisciplineService _disciplineService;
        private readonly IProfessionService _professionService;
        private readonly IProfessionDisciplineService _professionDisciplineService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfessionDisciplinesController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="disciplineService">The discipline service.</param>
        /// <param name="professionService">The profession service.</param>
        /// <param name="professionDisciplineService">The profession discipline service.</param>
        public ProfessionDisciplinesController(IMapper mapper, 
            IDisciplineService disciplineService,
            IProfessionService professionService, 
            IProfessionDisciplineService professionDisciplineService)
        {
            _mapper = mapper;
            _disciplineService = disciplineService;
            _professionService = professionService;
            _professionDisciplineService = professionDisciplineService;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<ProfessionDiscipline> professionDiscipliness = _professionDisciplineService.List();

            IPagedList<ProfessionDisciplineViewModel> professionDisciplineViewModels = professionDiscipliness
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<ProfessionDiscipline, ProfessionDisciplineViewModel>(_mapper);

            ProfessionDisciplineIndexViewModel model = new ProfessionDisciplineIndexViewModel
            {
                ProfessionDisciplines = professionDisciplineViewModels
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
            ProfessionDiscipline? professionDiscipline = id.HasValue
                ? _professionDisciplineService.Get(x => x.Id == id.Value)
                : new ProfessionDiscipline();

            if (professionDiscipline == null)
            {
                return RedirectToAction("Index");
            }

            ProfessionDisciplineEditViewModel model = _mapper.Map<ProfessionDisciplineEditViewModel>(professionDiscipline);
            InstantiateSelectLists(model);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(ProfessionDisciplineEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                ProfessionDiscipline? professionDiscipline = _professionDisciplineService.Get(x => x.Id == model.Id);
                _mapper.Map(model, professionDiscipline);
                _professionDisciplineService.Update(professionDiscipline);
            }
            else
            {
                ProfessionDiscipline professionDiscipline = _mapper.Map<ProfessionDiscipline>(model);
                _professionDisciplineService.Create(professionDiscipline);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            ProfessionDiscipline? professionDiscipline = _professionDisciplineService.Get(x => x.Id == id);

            if (professionDiscipline == null)
            {
                return Json(false);
            }

            _professionDisciplineService.Delete(professionDiscipline);

            return Json(true);
        }

        private void InstantiateSelectLists(ProfessionDisciplineEditViewModel model)
        {
            model.Disciplines = new SelectList(_disciplineService.List(), "Id", "Name", model.DisciplineId);
            model.Professions = new SelectList(_professionService.List(), "Id", "Name", model.ProfessionId);
        }
    }
}
