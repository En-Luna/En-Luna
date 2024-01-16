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
    public class DeadlineTypesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeadlineTypesController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        public DeadlineTypesController(IMapper mapper, ApplicationContext context)
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
            IEnumerable<DeadlineType> deadlineTypes = _context.DeadlineTypes.ToList();

            IPagedList<DeadlineTypeViewModel> deadlineTypeViewModels = deadlineTypes
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<DeadlineType, DeadlineTypeViewModel>(_mapper);

            DeadlineTypeIndexViewModel model = new DeadlineTypeIndexViewModel
            {
                DeadlineTypes = deadlineTypeViewModels
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
            DeadlineType? deadlineType = id.HasValue
                ? _context.DeadlineTypes.FirstOrDefault(x => x.Id == id.Value)
                : new DeadlineType();

            if (deadlineType == null)
            {
                return RedirectToAction("Index");
            }

            DeadlineTypeEditViewModel model = _mapper.Map<DeadlineTypeEditViewModel>(deadlineType);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(DeadlineTypeEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                DeadlineType? deadlineType = _context.DeadlineTypes.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, deadlineType);
                _context.DeadlineTypes.Update(deadlineType);
            }
            else
            {
                DeadlineType deadlineType = _mapper.Map<DeadlineType>(model);
                _context.DeadlineTypes.Add(deadlineType);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            DeadlineType? deadlineType = _context.DeadlineTypes.FirstOrDefault(x => x.Id == id);

            if (deadlineType == null)
            {
                return Json(false);
            }

            _context.DeadlineTypes.Remove(deadlineType);
            _context.SaveChanges();

            return Json(true);
        }
    }
}
