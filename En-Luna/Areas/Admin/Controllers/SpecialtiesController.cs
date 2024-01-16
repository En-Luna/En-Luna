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
    public class SpecialtiesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialtiesController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public SpecialtiesController(IMapper mapper, ApplicationContext context)
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
            IEnumerable<Specialty> specialtys = _context.Specialties.ToList();

            IPagedList<SpecialtyViewModel> specialtyViewModels = specialtys
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<Specialty, SpecialtyViewModel>(_mapper);

            SpecialtyIndexViewModel model = new SpecialtyIndexViewModel
            {
                Specialties = specialtyViewModels
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
            Specialty? specialty = id.HasValue
                ? _context.Specialties.FirstOrDefault(x => x.Id == id.Value)
                : new Specialty();

            if (specialty == null)
            {
                return RedirectToAction("Index");
            }

            SpecialtyEditViewModel model = _mapper.Map<SpecialtyEditViewModel>(specialty);
            InstantiateSelectLists(model);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(SpecialtyEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                Specialty? specialty = _context.Specialties.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, specialty);
                _context.Specialties.Update(specialty);
            }
            else
            {
                Specialty specialty = _mapper.Map<Specialty>(model);
                _context.Specialties.Add(specialty);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            Specialty? specialty = _context.Specialties.FirstOrDefault(x => x.Id == id);

            if (specialty == null)
            {
                return Json(false);
            }

            _context.Specialties.Remove(specialty);
            _context.SaveChanges();

            return Json(true);
        }

        private void InstantiateSelectLists(SpecialtyEditViewModel model)
        {
            model.Expertises = new SelectList(_context.Expertises.ToList(), "Id", "Name", model.ExpertiseId);
        }
    }
}
