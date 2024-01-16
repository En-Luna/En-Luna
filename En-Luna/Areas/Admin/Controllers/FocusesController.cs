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
    public class FocusesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="FocusesController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public FocusesController(IMapper mapper, ApplicationContext context)
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
            IEnumerable<Focus> focuses = _context.Focuses.ToList();

            IPagedList<FocusViewModel> focusViewModels = focuses
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<Focus, FocusViewModel>(_mapper);

            FocusIndexViewModel model = new FocusIndexViewModel
            {
                Focuses = focusViewModels
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
            Focus? focus = id.HasValue
                ? _context.Focuses.FirstOrDefault(x => x.Id == id.Value)
                : new Focus();

            if (focus == null)
            {
                return RedirectToAction("Index");
            }

            FocusEditViewModel model = _mapper.Map<FocusEditViewModel>(focus);
            InstantiateSelectLists(model);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(FocusEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                Focus? focus = _context.Focuses.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, focus);
                _context.Focuses.Update(focus);
            }
            else
            {
                Focus focus = _mapper.Map<Focus>(model);
                _context.Focuses.Add(focus);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            Focus? focus = _context.Focuses.FirstOrDefault(x => x.Id == id);

            if (focus == null)
            {
                return Json(false);
            }

            _context.Focuses.Remove(focus);
            _context.SaveChanges();

            return Json(true);
        }

        private void InstantiateSelectLists(FocusEditViewModel model)
        {
            model.Disciplines = new SelectList(_context.Disciplines.ToList(), "Id", "Name", model.DisciplineId);
        }
    }
}
