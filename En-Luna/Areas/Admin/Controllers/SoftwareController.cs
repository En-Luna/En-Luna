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
    public class SoftwareController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SoftwareController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        public SoftwareController(IMapper mapper, ApplicationContext context)
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
            IEnumerable<Software> softwares = _context.Software.ToList();

            IPagedList<SoftwareViewModel> softwareViewModels = softwares
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<Software, SoftwareViewModel>(_mapper);

            SoftwareIndexViewModel model = new SoftwareIndexViewModel
            {
                Software = softwareViewModels
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
            Software? software = id.HasValue
                ? _context.Software.FirstOrDefault(x => x.Id == id.Value)
                : new Software();

            if (software == null)
            {
                return RedirectToAction("Index");
            }

            SoftwareEditViewModel model = _mapper.Map<SoftwareEditViewModel>(software);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(SoftwareEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id != 0)
            {
                Software? software = _context.Software.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, software);
                _context.Software.Update(software);
            }
            else
            {
                Software software = _mapper.Map<Software>(model);
                _context.Software.Add(software);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            Software? software = _context.Software.FirstOrDefault(x => x.Id == id);

            if (software == null)
            {
                return Json(false);
            }

            _context.Software.Remove(software);
            _context.SaveChanges();

            return Json(true);
        }
    }
}
