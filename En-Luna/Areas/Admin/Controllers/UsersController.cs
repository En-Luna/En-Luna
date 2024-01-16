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
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="accountService"></param>
        public UsersController(IMapper mapper, ApplicationContext context)
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
            IEnumerable<User> accounts = _context.Users.ToList();

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
                ? _context.Users.FirstOrDefault(x => x.Id.Equals(id))
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
                User? account = _context.Users.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, account);
                _context.Users.Update(account);
            }
            else
            {
                User account = _mapper.Map<User>(model);
                _context.Users.Add(account);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult Delete(string id)
        {
            User? account = _context.Users.FirstOrDefault(x => x.Id.Equals(id));

            if (account == null)
            {
                return Json(false);
            }

            _context.Users.Remove(account);
            _context.SaveChanges();

            return Json(true);
        }

        public JsonResult Verify(int id)
        {
            User? account = _context.Users.FirstOrDefault(x => x.Id.Equals(id));

            if (account == null)
            {
                return Json(false);
            }

            account.IsVerified = true;
            _context.Users.Update(account);
            _context.SaveChanges();

            return Json(true);
        }

        private void InstantiateRelatedModels(UserEditViewModel model)
        {
            model.Address = model.Address ?? new();
            model.BankAccount = model.BankAccount ?? new();
            model.Contractor = model.Contractor ?? new();
        }

        private void InstantiateSelectLists(UserEditViewModel model)
        {
            model.Address.States = new SelectList(_context.States.ToList(), "Id", "Name", model.Address.StateId);
            model.Contractor.ProfessionDisciplines = new SelectList(
                _context.ProfessionDisciplines
                    .ToList()
                    .OrderBy(x => x.Profession.Name)
                    .ThenBy(x => x.Discipline.Name),
                "Id",
                "Name",
                model.Contractor.ProfessionDisciplineId
            );
            model.CompanyTypes = new SelectList(_context.CompanyTypes.ToList(), "Id", "Name", model.CompanyTypeId);
        }
    }
}
