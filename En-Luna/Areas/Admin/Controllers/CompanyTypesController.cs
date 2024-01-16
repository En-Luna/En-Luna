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
    public class CompanyTypesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICompanyTypeService _companyTypeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyTypesController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="companyTypeService"></param>
        public CompanyTypesController(IMapper mapper, ICompanyTypeService companyTypeService)
        {
            _mapper = mapper;
            _companyTypeService = companyTypeService;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<CompanyType> companyTypes = _companyTypeService.List();

            IPagedList<CompanyTypeViewModel> companyTypeViewModels = companyTypes
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<CompanyType, CompanyTypeViewModel>(_mapper);

            CompanyTypeIndexViewModel model = new CompanyTypeIndexViewModel
            {
                CompanyTypes = companyTypeViewModels
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
            CompanyType? companyType = id.HasValue
                ? _companyTypeService.Get(x => x.Id == id.Value)
                : new CompanyType();

            if (companyType == null)
            {
                return RedirectToAction("Index");
            }

            CompanyTypeEditViewModel model = _mapper.Map<CompanyTypeEditViewModel>(companyType);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(CompanyTypeEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                CompanyType? companyType = _companyTypeService.Get(x => x.Id == model.Id);
                _mapper.Map(model, companyType);
                _companyTypeService.Update(companyType);
            }
            else
            {
                CompanyType companyType = _mapper.Map<CompanyType>(model);
                _companyTypeService.Create(companyType);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            CompanyType? companyType = _companyTypeService.Get(x => x.Id == id);

            if (companyType == null)
            {
                return Json(false);
            }

            _companyTypeService.Delete(companyType);

            return Json(true);
        }
    }
}
