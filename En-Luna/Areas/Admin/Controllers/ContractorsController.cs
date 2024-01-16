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
    public class ContractorsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IContractorService _contractorService;
        private readonly IProfessionDisciplineService _professionDisciplineService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractorsController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="contractorService">The contractor service.</param>
        /// <param name="disciplineService">The discipline service.</param>
        /// <param name="professionService">The profession service.</param>
        /// <param name="professionDisciplineService">The profession discipline service.</param>
        public ContractorsController(IMapper mapper, 
            IContractorService contractorService, 
            IProfessionDisciplineService professionDisciplineService)
        {
            _mapper = mapper;
            _contractorService = contractorService;
            _professionDisciplineService = professionDisciplineService;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<Contractor> contractors = _contractorService.List();

            IPagedList<ContractorViewModel> contractorViewModels = contractors
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<Contractor, ContractorViewModel>(_mapper);

            ContractorIndexViewModel model = new ContractorIndexViewModel
            {
                Contractors = contractorViewModels
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
            Contractor? contractor = id.HasValue
                ? _contractorService.Get(x => x.Id == id.Value)
                : new Contractor();

            if (contractor == null)
            {
                return RedirectToAction("Index");
            }

            ContractorEditViewModel model = _mapper.Map<ContractorEditViewModel>(contractor);
            InstantiateRelatedModels(model);
            InstantiateSelectLists(model);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(ContractorEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InstantiateRelatedModels(model);
                InstantiateSelectLists(model);
                return View(model);
            }



            if (model.Id != 0)
            {
                Contractor? contractor = _contractorService.Get(x => x.Id == model.Id);
                _mapper.Map(model, contractor);
                _contractorService.Update(contractor);
            }
            else
            {
                Contractor contractor = _mapper.Map<Contractor>(model);
                _contractorService.Create(contractor);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            Contractor? contractor = _contractorService.Get(x => x.Id == id);

            if (contractor == null)
            {
                return Json(false);
            }

            _contractorService.Delete(contractor);

            return Json(true);
        }

        private void InstantiateRelatedModels(ContractorEditViewModel model)
        {
            model.Account = model.Account ?? new();
        }

        private void InstantiateSelectLists(ContractorEditViewModel model)
        {
            model.ProfessionDisciplines = new SelectList(
                _professionDisciplineService
                    .List()
                    .OrderBy(x => x.Profession.Name)
                    .ThenBy(x => x.Discipline.Name), 
                "Id", 
                "Name", 
                model.ProfessionDisciplineId
            );
        }
    }
}
