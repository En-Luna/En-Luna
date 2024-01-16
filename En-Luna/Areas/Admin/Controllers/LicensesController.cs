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
    public class LicensesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ILicenseService _licenseService;
        private readonly IStateService _stateService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LicensesController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="userService">The account service.</param>
        /// <param name="service">The service.</param>
        /// <param name="stateService">The state service.</param>
        public LicensesController(IMapper mapper, IUserService userService, 
            ILicenseService service, IStateService stateService)
        {
            _mapper = mapper;
            _userService = userService;
            _licenseService = service;
            _stateService = stateService;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<License> licenses = _licenseService.List();

            IPagedList<LicenseViewModel> licenseViewModels = licenses
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<License, LicenseViewModel>(_mapper);

            LicenseIndexViewModel model = new LicenseIndexViewModel
            {
                Licenses = licenseViewModels
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
            License? license = id.HasValue
                ? _licenseService.Get(x => x.Id == id.Value)
                : new License();

            if (license == null)
            {
                return RedirectToAction("Index");
            }

            LicenseEditViewModel model = _mapper.Map<LicenseEditViewModel>(license);
            InstantiateSelectLists(model);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(LicenseEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                License? license = _licenseService.Get(x => x.Id == model.Id);
                _mapper.Map(model, license);
                _licenseService.Update(license);
            }
            else
            {
                License license = _mapper.Map<License>(model);
                _licenseService.Create(license);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            License? license = _licenseService.Get(x => x.Id == id);

            if (license == null)
            {
                return Json(false);
            }

            _licenseService.Delete(license);

            return Json(true);
        }

        public JsonResult Verify(int id)
        {
            License? license = _licenseService.Get(x => x.Id == id);

            if (license == null)
            {
                return Json(false);
            }

            _licenseService.Verify(license);

            return Json(true);
        }

        private void InstantiateSelectLists(LicenseEditViewModel model)
        {
            model.Contractors = new SelectList(
                _userService
                .List()
                .OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                .Select(
                    x => new { x.ContractorId, Name = $"{x.LastName}, {x.FirstName}"}), 
                "ContractorId", 
                "Name", 
                model.ContractorId
            );

            model.States = new SelectList(_stateService.List(), "Id", "Name", model.StateId);
        }
    }
}
