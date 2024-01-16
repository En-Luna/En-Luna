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
    public class ProfessionDisciplinesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfessionDisciplinesController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public ProfessionDisciplinesController(IMapper mapper, ApplicationContext context)
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
            IEnumerable<ProfessionDiscipline> professionDiscipliness = _context.ProfessionDisciplines.ToList();

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
                ? _context.ProfessionDisciplines.FirstOrDefault(x => x.Id == id.Value)
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
                ProfessionDiscipline? professionDiscipline = _context.ProfessionDisciplines.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, professionDiscipline);
                _context.ProfessionDisciplines.Update(professionDiscipline);
            }
            else
            {
                ProfessionDiscipline professionDiscipline = _mapper.Map<ProfessionDiscipline>(model);
                _context.ProfessionDisciplines.Add(professionDiscipline);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            ProfessionDiscipline? professionDiscipline = _context.ProfessionDisciplines.FirstOrDefault(x => x.Id == id);

            if (professionDiscipline == null)
            {
                return Json(false);
            }

            _context.ProfessionDisciplines.Remove(professionDiscipline);
            _context.SaveChanges();

            return Json(true);
        }

        private void InstantiateSelectLists(ProfessionDisciplineEditViewModel model)
        {
            model.Disciplines = new SelectList(_context.Disciplines.ToList(), "Id", "Name", model.DisciplineId);
            model.Professions = new SelectList(_context.Professions.ToList(), "Id", "Name", model.ProfessionId);
        }
    }
}
