// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;

namespace FRDZ_School_Web.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<CustomUser> _userManager;
        private readonly IUserStore<CustomUser> _userStore;
        private readonly IUserEmailStore<CustomUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<CustomUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserStore<CustomUser> userStore,
            SignInManager<CustomUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _roleManager = roleManager;
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
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Введите адрес электронной почты")]
            [EmailAddress]
            [Display(Name = "Эл.почта")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Введите паспорт")]
            [StringLength(25, ErrorMessage = "Пароль {0} должен содержать не менее {2} и не более {1} символов", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Пароль")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Подтверждение пароля")]
            [Compare("Password", ErrorMessage = "Пароли не совпадают")]
            public string ConfirmPassword { get; set; }

            public string? Role { get; set; }
            [ValidateNever]
            public IEnumerable<SelectListItem> RoleList { get; set; }

            //[DisplayName("Имя")]
            //[Required(ErrorMessage = "Укажите имя!")]
            //[MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            //public string Name { get; set; }

            //[DisplayName("Фамилия")]
            //[Required(ErrorMessage = "Укажите фамилию!")]
            //[MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            //public string Surname { get; set; }

            //[DisplayName("Отчество")]
            //[Required(ErrorMessage = "Укажите отчество!")]
            //[MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            //public string Patronymic { get; set; }

            //[DisplayName("Адрес")]
            //[MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            //public string? Address { get; set; }

            //[DisplayName("Должность")]
            //[Required(ErrorMessage = "Укажите должность!")]
            //[MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            //public string Post { get; set; }

            //[DisplayName("Дата рождения")]
            //[MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            //public DateTime? Birthday { get; set; }

            //[DisplayName("Квалификация")]
            //[MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            //public string? Qualification { get; set; }

            //[DisplayName("Стаж")]
            //[MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            //[Required(ErrorMessage = "Укажите стаж!")]
            //[Range(0, 60)]
            //public int Experience { get; set; }

            //[DisplayName("Телефон")]
            //[MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            //public string? PhoneNumber { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            //_roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            //_roleManager.CreateAsync(new IdentityRole(SD.Role_Teacher)).GetAwaiter().GetResult();
            //_roleManager.CreateAsync(new IdentityRole(SD.Role_Student)).GetAwaiter().GetResult();

            Input = new()
            {
                RoleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                })
            };

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.EmailConfirmed = true;

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                //user.Name = Input.Name;
                //user.Surname = Input.Surname;
                //user.Patronymic = Input.Patronymic;
                //user.Post = Input.Post;
                //user.Birthday = Input.Birthday;
                //user.Qualification = Input.Qualification;
                //user.Address = Input.Address;
                //user.PhoneNumber = Input.PhoneNumber;
                //user.Experience = Input.Experience;
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Пользователь создал новую учетную запись с паролем.");

                    if (String.IsNullOrEmpty(Input.Role))
                    {
                        await _userManager.AddToRoleAsync(user, Input.Role);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, Input.Role);
                    }

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
                        //return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return Redirect("/Identity/Account/Manage/Index");
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

        private CustomUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<CustomUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Не могу создать экземпляр '{nameof(CustomUser)}'. " +
                    $"Гарантировать, что '{nameof(CustomUser)}' не является абстрактным классом и имеет конструктор без параметров или, альтернативно, " +
                    $"переопределить страницу регистрации в /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<CustomUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("Для пользовательского интерфейса по умолчанию требуется хранилище пользователей с поддержкой электронной почты.");
            }
            return (IUserEmailStore<CustomUser>)_userStore;
        }
    }
}
