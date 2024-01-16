using AutoMapper;
using En_Luna.Data;
using En_Luna.Data.Models;
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
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LicensesController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public LicensesController(IMapper mapper, ApplicationContext context)
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
            IEnumerable<License> licenses = _context.Licenses.ToList();

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
                ? _context.Licenses.FirstOrDefault(x => x.Id == id.Value)
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
                License? license = _context.Licenses.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, license);
                _context.Licenses.Update(license);
            }
            else
            {
                License license = _mapper.Map<License>(model);
                _context.Licenses.Add(license);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            License? license = _context.Licenses.FirstOrDefault(x => x.Id == id);

            if (license == null)
            {
                return Json(false);
            }

            _context.Licenses.Remove(license);
            _context.SaveChanges();

            return Json(true);
        }

        public JsonResult Verify(int id)
        {
            License? license = _context.Licenses.FirstOrDefault(x => x.Id == id);

            if (license == null)
            {
                return Json(false);
            }

            license.IsVerified = true;
            _context.Licenses.Update(license);
            _context.SaveChanges();

            return Json(true);
        }

        private void InstantiateSelectLists(LicenseEditViewModel model)
        {
            model.Contractors = new SelectList(
                _context.Users
                    .ToList()
                    .OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                    .Select(x => new { x.ContractorId, Name = $"{x.LastName}, {x.FirstName}"}), 
                "ContractorId", 
                "Name", 
                model.ContractorId
            );

            model.States = new SelectList(_context.States.ToList(), "Id", "Name", model.StateId);
        }
    }
}
