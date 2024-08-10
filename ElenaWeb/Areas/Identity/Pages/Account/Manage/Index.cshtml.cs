// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FRDZSchool.Models.DatabaseModels;

namespace FRDZ_School_Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly IWebHostEnvironment _env;

        public IndexModel(
            UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager,
            IWebHostEnvironment env)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _env = env;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        public string Id { get; set; }

        public IFormFile Photo { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

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
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [DisplayName("Имя")]
            //[Required(ErrorMessage = "Укажите имя!")]
            [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            public string Name { get; set; }

            [DisplayName("Фамилия")]
            //[Required(ErrorMessage = "Укажите фамилию!")]
            [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            public string Surname { get; set; }

            [DisplayName("Отчество")]
            //[Required(ErrorMessage = "Укажите отчество!")]
            [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            public string Patronymic { get; set; }

            [DisplayName("Адрес")]
            [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            public string Address { get; set; }

            [DisplayName("Должность")]
            //[Required(ErrorMessage = "Укажите должность!")]
            [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            public string Post { get; set; }

            [DisplayName("Дата рождения")]
            [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            public DateTime? Birthday { get; set; }

            [DisplayName("Квалификация")]
            [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            public string Qualification { get; set; }

            [DisplayName("Стаж")]
            [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            //[Required(ErrorMessage = "Укажите стаж!")]
            [Range(0, 60)]
            public int? Experience { get; set; }

            [DisplayName("Фото")]
            public string PhotoPath { get; set; }
        }

        private async Task LoadAsync(CustomUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var name = user.Name;
            var surname = user.Surname;
            var patronymic = user.Patronymic;
            var post = user.Post;
            var birthday = user.Birthday;
            var address = user.Address;
            var qualification = user.Qualification;
            var experience = user.Experience;
            var photoPath = user.PhotoPath;

            Username = userName;
            Id = user.Id;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Patronymic = patronymic,
                Address = address,
                Qualification = qualification,
                Birthday = birthday,
                Post = post,
                Name = name,
                Surname = surname,
                Experience = experience,
                PhotoPath = photoPath
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile photo)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var name = user.Name;
            var surname = user.Surname;
            var patronymic = user.Patronymic;
            var post = user.Post;
            var birthday = user.Birthday;
            var address = user.Address;
            var qualification = user.Qualification;
            var experience = user.Experience;

            if (Input.Patronymic != patronymic)
            {
                user.Patronymic = Input.Patronymic;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Birthday != birthday)
            {
                user.Birthday = Input.Birthday;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Address != address)
            {
                user.Address = Input.Address;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Qualification != qualification)
            {
                user.Qualification = Input.Qualification;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Post != post)
            {
                user.Post = Input.Post;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Name != name)
            {
                user.Name = Input.Name;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Surname != surname)
            {
                user.Surname = Input.Surname;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Experience != experience)
            {
                user.Experience = Input.Experience;
                await _userManager.UpdateAsync(user);
            }

            if (Photo != null)
            {
                Guid guid = Guid.NewGuid();
                string extension = Path.GetExtension(Photo.FileName);
                string completePath = $"{_env.WebRootPath}/images/teachers/{guid}{extension}";
                while (System.IO.File.Exists(completePath))
                {
                    guid = Guid.NewGuid();
                    completePath = $"{_env.WebRootPath}/images/teachers/{guid}{extension}";
                }
                try
                {
                    using (FileStream createStream = new FileStream(completePath, FileMode.Create))
                    {
                        await Photo.CopyToAsync(createStream);
                    }
                    if (user.PhotoPath != null && System.IO.File.Exists($"{_env.WebRootPath}/images/teachers/{user.PhotoPath}"))
                    {
                        System.IO.File.Delete($"{_env.WebRootPath}/images/teachers/{user.PhotoPath}");
                    }
                }
                catch
                {
                    ModelState.AddModelError("File", "Ошибка загрузки файла!");
                }
                user.PhotoPath = $"{guid}{extension}";
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Ваш профиль обновлён!";
            return RedirectToPage();
        }
    }
}
