using AutoMapper;
using En_Luna.Data;
using En_Luna.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace En_Luna.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public UsersController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActionResult Details(string id)
        {
            var user = _context.Users
                .Include("Address.State")
                .Include("Contractor.ProfessionDiscipline")
                .FirstOrDefault(x => x.Id == id);

            if (user == null) 
            {
                return RedirectToAction("Index", "Home");
            }

            var model = _mapper.Map<UserEditViewModel>(user);
            InstantiateSelectLists(model);

            return View(model);
        }


        private void InstantiateSelectLists(UserEditViewModel model)
        {
            model.Address.States = new SelectList(_context.States.ToList(), "Id", "Name", model.Address.StateId);
            model.Contractor.ProfessionDisciplines = new SelectList(
                _context.ProfessionDisciplines
                    .Include(x => x.Profession)
                    .Include(x => x.Discipline)
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
