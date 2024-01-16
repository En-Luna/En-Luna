using AutoMapper;
using En_Luna.Data;
using En_Luna.Data.Models;
using En_Luna.Email;
using En_Luna.Extensions;
using En_Luna.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using X.PagedList;

namespace En_Luna.Controllers
{
    [Route("Solicitations")]
    [Authorize(Roles = "Solicitor")]
    public class SolicitationsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;

        private readonly string[] _toAddresses = new string[] { "enluna.info@gmail.com", "cstalde1@gmail.com" };

        public SolicitationsController(IMapper mapper, IEmailSender emailSender, ApplicationContext context, UserManager<User> userManager)
        {
            _mapper = mapper;
            _emailSender = emailSender;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("{id:int}/{page:int?}")]
        public IActionResult Index(int id, int? page)
        {
            IEnumerable<Solicitation> solicitations = _context.Solicitations.Where(x => x.SolicitorId == id && x.IsActive).ToList();

            IPagedList<SolicitationViewModel> solicitationViewModels = solicitations
                .ToPagedList(page ?? 1, Constants.Constants.PageSize)
                .Map<Solicitation, SolicitationViewModel>(_mapper);

            SolicitationIndexViewModel model = new SolicitationIndexViewModel
            {
                Solicitations = solicitationViewModels
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            var isSolicitor = await _userManager.IsInRoleAsync(user, "Solicitor");
            
            if (!isSolicitor || user.SolicitorId == null)
            {
                return RedirectToAction("Index");
            }

            Solicitation? solicitation = id.HasValue
                ? _context.Solicitations.FirstOrDefault(x => x.Id == id.Value)
                : new Solicitation();

            if (solicitation == null)
            {
                return RedirectToAction("Index");
            }

            solicitation.SolicitorId = user.SolicitorId.Value;

            SolicitationEditViewModel model = _mapper.Map<SolicitationEditViewModel>(solicitation);
            InstantiateSelectLists(model);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SolicitationEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InstantiateSelectLists(model);
                return View(model);
            }

            // marked pending approval until the admin approves the solicitation
            model.PendingApproval = true;
            model.TeamMeetingTime = TimeZoneInfo.ConvertTime(model.TeamMeetingTime, TimeZoneInfo.FindSystemTimeZoneById(model.TimeZone));

            Message? message = default;

            if (model.Id != 0)
            {
                Solicitation? solicitation = _context.Solicitations.FirstOrDefault(x => x.Id == model.Id);
                _mapper.Map(model, solicitation);
                _context.Solicitations.Update(solicitation);

                message = new Message(_toAddresses, 
                    "Solicitation Updated", 
                    "There is an existing solicitation updated that needs reviewed. TODO give this html markup"
                );
            }
            else
            {
                Solicitation solicitation = _mapper.Map<Solicitation>(model);
                _context.Solicitations.Add(solicitation);

                message = new Message(_toAddresses,
                    "New Solicitation Posted for Review",
                    "There is a new solicitation posted that needs reviewed. TODO give this html markup"
                );
            }

            _context.SaveChanges();
            _emailSender.SendEmail(message);

            return RedirectToAction("Index", "Solicitations", new { Id = model.SolicitorId });
        }

        [HttpGet("Applicants/{id:int}/{page:int?}")]
        public IActionResult Applicants(int id, int? page)
        {
            var solicitationRoles = _context.SolicitationRoles.Where(x => x.SolicitationId == id).ToList();
            var applications = _context.Applications.Where(x => solicitationRoles.Select(x => x.Id).Contains(x.SolicitationRoleId)).ToList();

            IPagedList<ApplicationViewModel> applicationsViewModels = applications
                .ToPagedList(page ?? 1, Constants.Constants.PageSize)
                .Map<Application, ApplicationViewModel>(_mapper);

            ApplicationIndexViewModel model = new ApplicationIndexViewModel
            {
                Applications = applicationsViewModels
            };

            return View(model);
        }

        [HttpGet("Search/{contractorId:int}/{page:int}")]
        public IActionResult Search(int contractorId, int? page)
        {
            var contractor = _context.Contractors.FirstOrDefault(x => x.Id == contractorId);

            if (contractor == null) 
            {
                return RedirectToAction("Index", "Home");
            }

            IEnumerable<Solicitation> solicitations = _context.Solicitations
                .Include(x => x.Roles)
                .Where(x =>
                    x.IsActive
                    && x.IsApproved
                    && !x.IsDeleted
                    && !x.IsCancelled
                    && !x.IsComplete
                    && x.Roles.Select(r => r.RequiredProfessionDisciplineId).Contains(contractor.ProfessionDisciplineId)
                )
                .ToList();

            IPagedList<SolicitationViewModel> solicitationViewModels = solicitations
                .ToPagedList(page ?? 1, Constants.Constants.PageSize)
                .Map<Solicitation, SolicitationViewModel>(_mapper);

            SolicitationIndexViewModel model = new SolicitationIndexViewModel
            {
                Solicitations = solicitationViewModels
            };

            return View(model);
        }

        [HttpGet("View/{solicitationId:int}")]
        public async Task<IActionResult> View(int solicitationId)
        {
            Solicitation? solicitation = _context.Solicitations
                .Include("Deadline.DeadlineType")
                .Include(x => x.Roles)
                .Include("Roles.ProjectDeliverable")
                .Include("Roles.RequiredProfessionDiscipline.Profession")
                .Include("Roles.RequiredProfessionDiscipline.Discipline")
                .Include("Solicitor.Account")
                .FirstOrDefault(x => x.Id == solicitationId);

            if (solicitation == null)
            {
                return RedirectToAction("Search");
            }

            SolicitationViewModel model = _mapper.Map<SolicitationViewModel>(solicitation);

            return View(model);
        }

        [HttpGet("Apply/{solicitationId:int}/{contractorId:int}")]
        public IActionResult Apply(int solicitationId, int contractorId)
        {
            var contractor = _context.Contractors.FirstOrDefault(x => x.Id == contractorId);

            var solicitationRole = _context.SolicitationRoles
                .FirstOrDefault(x => 
                    x.SolicitationId == solicitationId 
                    && x.RequiredProfessionDisciplineId == contractor.ProfessionDisciplineId
            );

            if (solicitationRole == null)
            {
                return RedirectToAction("Search", new { contractorId });
            }
            
            var application = _context.Applications
                .FirstOrDefault(x => x.SolicitationRoleId == solicitationRole.Id && x.ContractorId == contractorId)
                ?? new Application
                {
                    ContractorId = contractorId,
                    SolicitationRoleId = solicitationRole.Id,
                };

            ApplicationViewModel model = _mapper.Map<ApplicationViewModel>(application);

            return PartialView(model);
        }

        [HttpPost("Apply")]
        public JsonResult Apply(ApplicationViewModel model)
        {
            var application = _mapper.Map<Application>(model);
            _context.Applications.Add(application);
            _context.SaveChanges(); 

            var message = new Message(_toAddresses,
                "Application Received",
                "There is an application for solicitation. TODO give this html markup"
            );

            _emailSender.SendEmail(message);

            return Json(true);
        }

        public JsonResult Activate(int id)
        {
            Solicitation? solicitation = _context.Solicitations.FirstOrDefault(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            solicitation.IsActive = true;
            _context.Solicitations.Update(solicitation);
            _context.SaveChanges();

            return Json(true);
        }

        [HttpPost("Deactivate")]
        public JsonResult Deactivate(int id)
        {
            Solicitation? solicitation = _context.Solicitations.FirstOrDefault(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            solicitation.IsActive = false;
            _context.Solicitations.Update(solicitation);
            _context.SaveChanges();

            return Json(true);
        }

        public JsonResult Complete(int id, bool isComplete)
        {
            Solicitation? solicitation = _context.Solicitations.FirstOrDefault(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            solicitation.IsComplete = isComplete;
            _context.Solicitations.Update(solicitation);
            _context.SaveChanges();

            return Json(true);
        }

        public JsonResult Cancel(int id, bool isCancelled)
        {
            Solicitation? solicitation = _context.Solicitations.FirstOrDefault(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            solicitation.IsCancelled = isCancelled;
            _context.Solicitations.Update(solicitation);
            _context.SaveChanges();

            return Json(true);
        }

        private void InstantiateSelectLists(SolicitationEditViewModel model)
        {
            model.SolicitationDeadline.DeadlineTypes = new SelectList(
                _context.DeadlineTypes.ToList(),
                "Id",
                "Name",
                model.SolicitationDeadline?.DeadlineTypeId ?? 0
            );

            model.SolicitationRole.ProjectDeliverables = new SelectList(
                _context.ProjectDeliverables.ToList(), 
                "Id", 
                "Name", 
                model.SolicitationRole.ProjectDeliverableId
            );

            model.SolicitationRole.ProfessionDisciplines = new SelectList(
                _context.ProfessionDisciplines
                    .Include(x => x.Profession)
                    .Include(x => x.Discipline)
                    .ToList(), 
                "Id", 
                "Name", 
                model.SolicitationRole.RequiredProfessionDisciplineId
            );

            model.States = new SelectList(_context.States.ToList(), "Id", "Name", model.StateId);
            model.TimeZones = new SelectList(TimeZoneInfo.GetSystemTimeZones(), "Id", "DisplayName");
        }

    }
}
