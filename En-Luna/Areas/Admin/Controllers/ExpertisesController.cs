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
    public class ExpertisesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpertisesController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public ExpertisesController(IMapper mapper, ApplicationContext context)
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
            IEnumerable<Expertise> expertises = _context.Expertises.ToList();

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
                ? _context.Expertises.FirstOrDefault(x => x.Id == id.Value)
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
                Expertise? expertise = _context.Expertises.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, expertise);
                _context.Expertises.Update(expertise);
            }
            else
            {
                Expertise expertise = _mapper.Map<Expertise>(model);
                _context.Expertises.Add(expertise);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            Expertise? expertise = _context.Expertises.FirstOrDefault(x => x.Id == id);

            if (expertise == null)
            {
                return Json(false);
            }

            _context.Expertises.Remove(expertise);
            _context.SaveChanges();

            return Json(true);
        }

        private void InstantiateSelectLists(ExpertiseEditViewModel model)
        {
            model.Focuses = new SelectList(_context.Focuses.ToList(), "Id", "Name", model.FocusId);
        }
    }
}
