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
    public class ProfessionsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProfessionService _professionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfessionsController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public ProfessionsController(IMapper mapper, IProfessionService service)
        {
            _mapper = mapper;
            _professionService = service;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<Profession> professions = _professionService.List();

            IPagedList<ProfessionViewModel> professionViewModels = professions
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<Profession, ProfessionViewModel>(_mapper);

            ProfessionIndexViewModel model = new ProfessionIndexViewModel
            {
                Professions = professionViewModels
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
            Profession? profession = id.HasValue
                ? _professionService.Get(x => x.Id == id.Value)
                : new Profession();

            if (profession == null)
            {
                return RedirectToAction("Index");
            }

            ProfessionEditViewModel model = _mapper.Map<ProfessionEditViewModel>(profession);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(ProfessionEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                Profession? profession = _professionService.Get(x => x.Id == model.Id);
                _mapper.Map(model, profession);
                _professionService.Update(profession);
            }
            else
            {
                Profession profession = _mapper.Map<Profession>(model);
                _professionService.Create(profession);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            Profession? profession = _professionService.Get(x => x.Id == id);

            if (profession == null)
            {
                return Json(false);
            }

            _professionService.Delete(profession);

            return Json(true);
        }
    }
}
