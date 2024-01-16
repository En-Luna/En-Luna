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
    public class DeadlineTypesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDeadlineTypeService _deadlineTypeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeadlineTypesController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="deadlineTypeService"></param>
        public DeadlineTypesController(IMapper mapper, IDeadlineTypeService deadlineTypeService)
        {
            _mapper = mapper;
            _deadlineTypeService = deadlineTypeService;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<DeadlineType> deadlineTypes = _deadlineTypeService.List();

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
                ? _deadlineTypeService.Get(x => x.Id == id.Value)
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
                DeadlineType? deadlineType = _deadlineTypeService.Get(x => x.Id == model.Id);
                _mapper.Map(model, deadlineType);
                _deadlineTypeService.Update(deadlineType);
            }
            else
            {
                DeadlineType deadlineType = _mapper.Map<DeadlineType>(model);
                _deadlineTypeService.Create(deadlineType);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            DeadlineType? deadlineType = _deadlineTypeService.Get(x => x.Id == id);

            if (deadlineType == null)
            {
                return Json(false);
            }

            _deadlineTypeService.Delete(deadlineType);

            return Json(true);
        }
    }
}
