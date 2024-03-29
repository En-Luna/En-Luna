﻿using AutoMapper;
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
    public class BankAccountsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountsController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        public BankAccountsController(IMapper mapper, ApplicationContext context)
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
            IEnumerable<BankAccount> accounts = _context.BankAccounts.ToList();

            IPagedList<BankAccountViewModel> accountViewModels = accounts
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<BankAccount, BankAccountViewModel>(_mapper);

            BankAccountIndexViewModel model = new BankAccountIndexViewModel
            {
                BankAccounts = accountViewModels
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
            BankAccount? account = id.HasValue
                ? _context.BankAccounts.FirstOrDefault(x => x.Id == id.Value)
                : new BankAccount();

            if (account == null)
            {
                return RedirectToAction("Index");
            }

            BankAccountEditViewModel model = _mapper.Map<BankAccountEditViewModel>(account);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(BankAccountEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id != 0)
            {
                BankAccount? account = _context.BankAccounts.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, account);
                _context.BankAccounts.Update(account);
            }
            else
            {
                BankAccount account = _mapper.Map<BankAccount>(model);
                _context.BankAccounts.Add(account);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            BankAccount? account = _context.BankAccounts.FirstOrDefault(x => x.Id == id);

            if (account == null)
            {
                return Json(false);
            }

            _context.BankAccounts.Remove(account);
            _context.SaveChanges();

            return Json(true);
        }
        public JsonResult Verify(int id)
        {
            BankAccount? account = _context.BankAccounts.FirstOrDefault(x => x.Id == id);

            if (account == null)
            {
                return Json(false);
            }

            account.IsVerified = true;
            _context.BankAccounts.Update(account);
            _context.SaveChanges();

            return Json(true);
        }
    }
}
