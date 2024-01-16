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
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _accountService;
        private readonly ICompanyTypeService _companyTypeService;
        private readonly IProfessionDisciplineService _professionDisciplineService;
        private readonly IStateService _stateService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="accountService"></param>
        public UsersController(IMapper mapper, 
            IUserService accountService, 
            ICompanyTypeService companyTypeService,
            IProfessionDisciplineService professionDisciplineService, 
            IStateService stateService)
        {
            _mapper = mapper;
            _accountService = accountService;
            _companyTypeService = companyTypeService;
            _professionDisciplineService = professionDisciplineService;
            _stateService = stateService;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<User> accounts = _accountService.List();

            IPagedList<UserViewModel> accountViewModels = accounts
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<User, UserViewModel>(_mapper);

            UserIndexViewModel model = new UserIndexViewModel
            {
                Users = accountViewModels
            };

            return View(model);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IActionResult Edit(string? id)
        {
            User? account = !string.IsNullOrWhiteSpace(id)
                ? _accountService.Get(x => x.Id.Equals(id))
                : new User();

            if (account == null)
            {
                return RedirectToAction("Index");
            }

            UserEditViewModel model = _mapper.Map<UserEditViewModel>(account);
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
        public IActionResult Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InstantiateRelatedModels(model);
                InstantiateSelectLists(model);
                return View(model);
            }

            if (model.IsSolicitor && model.SolicitorId == null)
            {
                model.Solicitor = new();
            }

            if (!string.IsNullOrWhiteSpace(model.Id))
            {
                User? account = _accountService.Get(x => x.Id == model.Id);
                _mapper.Map(model, account);
                _accountService.Update(account);
            }
            else
            {
                User account = _mapper.Map<User>(model);
                _accountService.Create(account);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Delete(string id)
        {
            User? account = _accountService.Get(x => x.Id.Equals(id));

            if (account == null)
            {
                return Json(false);
            }

            _accountService.Delete(account);

            return Json(true);
        }

        public JsonResult Verify(int id)
        {
            User? account = _accountService.Get(x => x.Id.Equals(id));

            if (account == null)
            {
                return Json(false);
            }

            _accountService.Verify(account);

            return Json(true);
        }

        private void InstantiateRelatedModels(UserEditViewModel model)
        {
            model.Address = model.Address ?? new();
            model.BankAccount = model.BankAccount ?? new();
            model.Contractor = model.Contractor ?? new();
            //model.Solicitor = model.Solicitor ?? new();
        }

        private void InstantiateSelectLists(UserEditViewModel model)
        {
            model.Address.States = new SelectList(_stateService.List(), "Id", "Name", model.Address.StateId);
            model.Contractor.ProfessionDisciplines = new SelectList(
                _professionDisciplineService
                    .List()
                    .OrderBy(x => x.Profession.Name)
                    .ThenBy(x => x.Discipline.Name),
                "Id",
                "Name",
                model.Contractor.ProfessionDisciplineId
            );
            model.CompanyTypes = new SelectList(_companyTypeService.List(), "Id", "Name", model.CompanyTypeId);
        }
    }
}
