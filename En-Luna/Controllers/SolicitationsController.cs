using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.Data.Services;
using En_Luna.Email;
using En_Luna.Extensions;
using En_Luna.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using X.PagedList;

namespace En_Luna.Controllers
{
    [Route("Solicitations")]
    [Authorize(Roles = "Solicitor")]
    public class SolicitationsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IApplicationService _applicationService;
        private readonly IContractorService _contractorService;
        private readonly IDeadlineTypeService _deadlineTypeService;
        private readonly IEmailSender _emailSender;
        private readonly IProfessionDisciplineService _professionDisciplineService;
        private readonly IProjectDeliverableService _projectDeliverableService;
        private readonly ISolicitationService _solicitationService;
        private readonly ISolicitationRoleService _solicitationRoleService;
        private readonly IStateService _stateService;
        private readonly UserManager<User> _userManager;

        private readonly string[] _toAddresses = new string[] { "enluna.info@gmail.com", "cstalde1@gmail.com" };

        public SolicitationsController(IMapper mapper, IContractorService contractorService, IEmailSender emailSender, IDeadlineTypeService deadlineTypeService, 
            IProfessionDisciplineService professionDisciplineService, IProjectDeliverableService projectDeliverableService,
            ISolicitationService solicitationService, IStateService stateService, UserManager<User> userManager, IApplicationService applicationService, ISolicitationRoleService solicitationRoleService)
        {
            _mapper = mapper;
            _contractorService = contractorService;
            _emailSender = emailSender;
            _deadlineTypeService = deadlineTypeService;
            _professionDisciplineService = professionDisciplineService;
            _projectDeliverableService = projectDeliverableService;
            _solicitationService = solicitationService;
            _stateService = stateService;
            _userManager = userManager;
            _applicationService = applicationService;
            _solicitationRoleService = solicitationRoleService;
        }

        [HttpGet("{id:int}/{page:int?}")]
        public IActionResult Index(int id, int? page)
        {
            IEnumerable<Solicitation> solicitations = _solicitationService.List(x => x.SolicitorId == id && x.IsActive);

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
                ? _solicitationService.Get(x => x.Id == id.Value)
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

            if (model.Id != 0)
            {
                Solicitation? solicitation = _solicitationService.Get(x => x.Id == model.Id);
                _mapper.Map(model, solicitation);
                _solicitationService.Update(solicitation);

                var message = new Message(_toAddresses, 
                    "Solicitation Updated", 
                    "There is an existing solicitation updated that needs reviewed. TODO give this html markup"
                );

                _emailSender.SendEmail(message);
            }
            else
            {
                Solicitation solicitation = _mapper.Map<Solicitation>(model);
                _solicitationService.Create(solicitation);

                var message = new Message(_toAddresses,
                    "New Solicitation Posted for Review",
                    "There is a new solicitation posted that needs reviewed. TODO give this html markup"
                );

                _emailSender.SendEmail(message);
            }

            return RedirectToAction("Index", "Solicitations", new { Id = model.SolicitorId });
        }

        [HttpGet("Applicants/{id:int}/{page:int?}")]
        public IActionResult Applicants(int id, int? page)
        {
            var solicitationRoles = _solicitationRoleService.List(x => x.SolicitationId == id);
            var applications = _applicationService.List(x => solicitationRoles.Select(x => x.Id).Contains(x.SolicitationRoleId));

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
            var contractor = _contractorService.Get(x => x.Id == contractorId);

            if (contractor == null) 
            {
                return RedirectToAction("Index", "Home");
            }

            IEnumerable<Solicitation> solicitations = _solicitationService.List(x => x.Roles, x => 
                x.IsActive
                && x.IsApproved
                && !x.IsDeleted
                && !x.IsCancelled
                && !x.IsComplete
                && x.Roles.Select(r => r.RequiredProfessionDisciplineId).Contains(contractor.ProfessionDisciplineId)
            );

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
            Solicitation? solicitation = _solicitationService.Get(x => x.Id == solicitationId);

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
            var contractor = _contractorService.Get(x => x.Id == contractorId);

            var solicitationRole = _solicitationRoleService
                .Get(x => 
                    x.SolicitationId == solicitationId 
                    && x.RequiredProfessionDisciplineId == contractor.ProfessionDisciplineId
            );

            if (solicitationRole == null)
            {
                return RedirectToAction("Search", new { contractorId });
            }
            
            var application = _applicationService
                .Get(x => x.SolicitationRoleId == solicitationRole.Id && x.ContractorId == contractorId)
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
            _applicationService.Create(application);

            var message = new Message(_toAddresses,
                "Application Received",
                "There is an application for solicitation. TODO give this html markup"
            );

            _emailSender.SendEmail(message);

            return Json(true);
        }

        public JsonResult Activate(int id)
        {
            //todo add logic that informs admin of activity

            Solicitation? solicitation = _solicitationService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationService.Activate(solicitation);

            return Json(true);
        }

        [HttpPost("Deactivate")]
        public JsonResult Deactivate(int id)
        {
            //todo add logic that informs admin of activity

            Solicitation? solicitation = _solicitationService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationService.Deactivate(solicitation);

            return Json(true);
        }

        public JsonResult Complete(int id, bool isComplete)
        {
            //todo add logic that informs admin of activity

            Solicitation? solicitation = _solicitationService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationService.Complete(solicitation, isComplete);

            return Json(true);
        }

        public JsonResult Cancel(int id, bool isCancelled)
        {
            //todo add logic that informs admin of activity

            Solicitation? solicitation = _solicitationService.Get(x => x.Id == id);

            if (solicitation == null)
            {
                return Json(false);
            }

            _solicitationService.Cancel(solicitation, isCancelled);

            return Json(true);
        }

        private void InstantiateSelectLists(SolicitationEditViewModel model)
        {
            model.SolicitationDeadline.DeadlineTypes = new SelectList(
                _deadlineTypeService.List(),
                "Id",
                "Name",
                model.SolicitationDeadline?.DeadlineTypeId ?? 0
            );

            model.SolicitationRole.ProjectDeliverables = new SelectList(
                _projectDeliverableService.List(), 
                "Id", 
                "Name", 
                model.SolicitationRole.ProjectDeliverableId
            );

            model.SolicitationRole.ProfessionDisciplines = new SelectList(
                _professionDisciplineService.List(), 
                "Id", 
                "Name", 
                model.SolicitationRole.RequiredProfessionDisciplineId
            );

            model.States = new SelectList(_stateService.List(), "Id", "Name", model.StateId);
            model.TimeZones = new SelectList(TimeZoneInfo.GetSystemTimeZones(), "Id", "DisplayName");
        }

    }
}
