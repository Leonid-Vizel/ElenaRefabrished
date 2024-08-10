using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FRDZSchool.Models.DatabaseModels
{
    public sealed class CustomUser : IdentityUser
    {
        [DisplayName("Имя")]
        //[Required(ErrorMessage = "Укажите имя!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? Name { get; set; }

        [DisplayName("Фамилия")]
        //[Required(ErrorMessage = "Укажите фамилию!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? Surname { get; set; }

        [DisplayName("Отчество")]
        //[Required(ErrorMessage = "Укажите отчество!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? Patronymic { get; set; }

        [DisplayName("Адрес")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? Address { get; set; }

        [DisplayName("Должность")]
        //[Required(ErrorMessage = "Укажите должность!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? Post { get; set; }

        [DisplayName("Дата рождения")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public DateTime? Birthday { get; set; }

        [DisplayName("Квалификация")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? Qualification { get; set; }

        [DisplayName("Стаж")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        //[Required(ErrorMessage = "Укажите стаж!")]
        [Range(0, 60)]
        public int? Experience { get; set; }

        [DisplayName("Фото")]
        public string? PhotoPath { get; set; }
    }
}
