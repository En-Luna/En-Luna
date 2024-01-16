// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;

namespace En_Luna.Areas.Identity.Pages.Account
{
    using AutoMapper;
    using En_Luna.Data;
    using En_Luna.Data.Models;
    using En_Luna.Data.Services;
    using En_Luna.Extensions;
    using En_Luna.ViewModels;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.ComponentModel;

    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserStore<User> _userStore;
        private readonly IUserEmailStore<User> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IStateService _stateService;
        private readonly IProfessionDisciplineService _professionDisciplineService;
        private readonly ICompanyTypeService _companyTypeService;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly IAddressService _addressService;

        public RegisterModel(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserStore<User> userStore,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IStateService stateService,
            IProfessionDisciplineService professionDisciplineService,
            ICompanyTypeService companyTypeService,
            IMapper mapper,
            ApplicationContext context,
            IAddressService addressService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _stateService = stateService;
            _professionDisciplineService = professionDisciplineService;
            _companyTypeService = companyTypeService;
            _mapper = mapper;
            _context = context;
            _addressService = addressService;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public UserEditViewModel Input { get; set; } = new();
        //public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Id { get; set; }
            public int AddressId { get; set; }
            public int BankAccountId { get; set; }
            public int ContractorId { get; set; }
            public int? SolicitorId { get; set; }

            [Required]
            [DisplayName("First Name")]
            public string FirstName { get; set; } = string.Empty;


            [Required]
            [DisplayName("Last Name")]
            public string LastName { get; set; } = string.Empty;

            [Required]
            [DisplayName("About Me")]
            public string AboutMe { get; set; } = string.Empty;

            [Required]
            [DisplayName("Phone")]
            public string PhoneNumber { get; set; } = string.Empty;

            [Required]
            [DisplayName("SSN")]
            public string SocialSecurityNumber { get; set; } = string.Empty;

            [Required]
            [DisplayName("Hours Available Per Week")]
            public int HoursAvailablePerWeek { get; set; }

            [DisplayName("Current Workload (Hours per Week)")]
            public int CurrentWorkload { get; set; } // todo this should be calculated in mapping profile

            [DisplayName("Verified")]
            public bool IsVerified { get; set; }

            [DisplayName("Employer Identification Number")]
            public string EmployerIdentificationNumber { get; set; } = string.Empty;

            [DisplayName("Company Name")]
            public string CompanyName { get; set; } = string.Empty;

            public int? CompanyTypeId { get; set; }

            [DisplayName("Company Type")]
            public SelectList? CompanyTypes { get; set; }

            [DisplayName("Solicitor?")]
            public bool IsSolicitor { get; set; }

            public BankAccountEditViewModel BankAccount { get; set; } = new();
            public AddressEditViewModel Address { get; set; } = new();
            public ContractorEditViewModel Contractor { get; set; } = new();
            public SolicitorEditViewModel Solicitor { get; set; } = new();
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            InstantiateRelatedModels();
            InstantiateSelectLists();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(Input);

                await _userStore.SetUserNameAsync(user, GenerateUsername(Input), CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await HandleRoles(user);

                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            InstantiateRelatedModels();
            InstantiateSelectLists();
            return Page();
        }

        private async Task HandleRoles(User user)
        {
            await _userManager.AddToRoleAsync(user, "Contractor");

            if (Input.IsSolicitor)
            {
                await _userManager.AddToRoleAsync(user, "Solicitor");
            }
        }

        private User CreateUser()
        {
            try
            {
                return Activator.CreateInstance<User>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(User)}'. " +
                    $"Ensure that '{nameof(User)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<User> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<User>)_userStore;
        }

        private void InstantiateRelatedModels()
        {
            Input.Address = Input.Address ?? new();
            Input.BankAccount = Input.BankAccount ?? new();
            Input.Contractor = Input.Contractor ?? new();
        }

        private void InstantiateSelectLists()
        {
            Input.Address.States = new SelectList(_stateService.List(), "Id", "Name", Input.Address.StateId);
            Input.Contractor.ProfessionDisciplines = new SelectList(
                _professionDisciplineService
                    .List()
                    .OrderBy(x => x.Profession.Name)
                    .ThenBy(x => x.Discipline.Name),
                "Id",
                "Name",
                Input.Contractor.ProfessionDisciplineId
            );
            Input.CompanyTypes = new SelectList(_companyTypeService.List(), "Id", "Name", Input.CompanyTypeId);
        }

        private string GenerateUsername(UserEditViewModel user)
        {
            var userName = $"{user.FirstName.Substring(0, 1)}{user.LastName}";

            var possibleDuplicateUsernames = _context.Users.Where(x => x.NormalizedUserName != null && x.NormalizedUserName.Contains(userName)).ToList();

            // if we have an account with the generated username
            if (possibleDuplicateUsernames.Any(x => x.NormalizedUserName != null && x.NormalizedUserName.RemoveDigits().Equals(userName.ToUpper())))
            {
                // get a count of how many accounts have the same user name
                int count = possibleDuplicateUsernames.Count(x => x.NormalizedUserName.RemoveDigits().Equals(userName.ToUpper()));

                // append the count + 1 to the username
                userName += count + 1;
            }

            return userName;
        }
    }
}
