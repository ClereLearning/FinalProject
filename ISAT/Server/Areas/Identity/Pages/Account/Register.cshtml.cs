// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using ISAT.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.CodeAnalysis.Operations;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace ISAT.Server.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]

        public InputModel Input { get; set; }

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
        /// 
        public class ValidateTokenFromUser: ValidationAttribute 
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                String tokenFromUser = Convert.ToString(value);
                

                switch (tokenFromUser.Trim())
                {
                    case "4E7BDFA8-0F70-4015-B820-EC22CE22083B": //Interviewer
                        return ValidationResult.Success;
                        break;
                    case "3309A5E8-23EB-4A89-B594-DB0F7561212E": //Administrative
                        return ValidationResult.Success;
                        break;
                    case "7197C2CF-207B-4550-90E2-89F676FDDC73": //Researcher
                        return ValidationResult.Success;
                        break;
                    default:
                        return new ValidationResult(ErrorMessage);
                        break;
                }

                return base.IsValid(value, validationContext);
            }
        }
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

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; } = string.Empty;

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; } = string.Empty;

            [Required]
            [Display(Name = "Social Name")]
            public string SocialName { get; set; } = string.Empty;

            [Required]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; } = string.Empty;

            [Required]
            [Display(Name = "Token")]
            [ValidateTokenFromUser(ErrorMessage = "Invalid Token. Please verify.")]
            public string Token { get; set; } = string.Empty;

            /*
             [Display(Name = "User`s Type")]
             public UsersType? UsersType { get; set; }            
            */
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            //DropDown = new SelectList(UsersTypes.)
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            // verifying token
            bool TokenOk = false;
            var claimResearcher = new Claim("Researcher", "Researcher");
            var claimAdministrative = new Claim("Administrative", "Administrative");
            var claimInterviewer = new Claim("Interviewer", "Interviewer");

            var adminRole = new IdentityRole("Administrative");
            adminRole.NormalizedName = adminRole.Name.ToLower();

            var interviewerRole = new IdentityRole("Interviewer");
            interviewerRole.NormalizedName = interviewerRole.Name.ToLower();

            var researcherRole = new IdentityRole("Researcher");
            researcherRole.NormalizedName = researcherRole.Name.ToLower();

            Claim claimReg = null;
            IdentityRole roleReg = null;
            switch (Input.Token.Trim())
            {
                case "4E7BDFA8-0F70-4015-B820-EC22CE22083B": //Interviewer
                    TokenOk = true;
                    claimReg = claimInterviewer;
                    roleReg = interviewerRole;
                    break;
                case "3309A5E8-23EB-4A89-B594-DB0F7561212E": //Administrative
                    TokenOk = true;
                    claimReg = claimAdministrative;
                    roleReg = adminRole;
                    break;
                case "7197C2CF-207B-4550-90E2-89F676FDDC73": //Researcher
                    TokenOk = true;
                    claimReg = claimResearcher;
                    roleReg = researcherRole;
                    break;
                default:
                    TokenOk = true;
                    break;
            }

            if(!TokenOk)
            {
                _logger.LogInformation("Invalid Token ");
                return Page();
            }
            

            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                //customizing users information
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.SocialName = Input.SocialName;
                user.PhoneNumber = Input.PhoneNumber;
                user.Inactive = false;
                //user.UsersType = Input.UsersType;

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    //adding claim
                    var claimsUser = await _userManager.AddClaimAsync(user, claimReg );

                    //adding Role

                    var roleUser = await _userManager.AddToRoleAsync(user, roleReg.Name);


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
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
